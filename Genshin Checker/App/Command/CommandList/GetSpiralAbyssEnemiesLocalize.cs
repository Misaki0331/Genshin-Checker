using ABI.System;
using Genshin_Checker.App.Command;
using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Model.UserData.SpiralAbyss.v1;
using Genshin_Checker.Window.Popup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.Command.CommandList
{
    public class GetLocalize : Command
    {
        public override string Name => "get-localize";
        public override string Description => "各言語のローカライズを取得します。";

        public override async Task Execute(params string[] parameters)
        {
            if(parameters.Length < 2)
            {
                Console($"GetLocalize [SpiralAbyss]\n[SpiralAbyss] : 深境螺旋の敵情報を取得");
                return;
            }
            switch(parameters[1].ToLower()) {
                case "spiralabyss":
                    await SpiralAbyss(parameters);
                    break;
                default:
                    Console($"Get-Localize [SpiralAbyss]");
                    Console($"SpiralAbyss [old] : 深境螺旋の敵情報を取得。oldを付けると前回の深境螺旋の敵情報を取得します。");
                    break;

            }
            return;
        }

        private async Task SpiralAbyss(params string[] parameters)
        {
            bool IsOld = false;
            if (parameters.Length >= 3 && parameters[2].ToLower() == "old")
            {
                IsOld = true;
                Console($"過去データを取得します。");
            }
            Account? ValidAccount = null;
            foreach(var account in Genshin_Checker.Store.Accounts.Data)
            {
                var data = IsOld?await account.SpiralAbyss.GetOld():await account.SpiralAbyss.GetCurrent();
                bool IsValid = true;
                if (data == null) continue;
                var floor = data.Data.floors.FindAll(a => a.index >= 9);
                floor.ForEach(a =>
                {
                    if(a.levels.Count<3) IsValid= false;
                });
                if (IsValid)
                {
                    ValidAccount = account;
                    break;
                }
            }
            if(ValidAccount == null) {
                Console("条件に見合ったアカウントがありません。");
                return;
            }

            List<string> imageURL = new();
            Dictionary<string, V1> Datas = new();
            var langs = await HoYoLab.Static.LocalizeInfo.GetLanguages();
            if (langs.Data == null) throw new ArgumentNullException(nameof(langs.Data), "languages data is null");
            foreach (var lan in langs.Data.langs) {
                Datas.Add(lan.value,ValidAccount.SpiralAbyss.Convert(await ValidAccount.Endpoint.GetSpiralAbyss(!IsOld, new System.Globalization.CultureInfo(lan.value))));
                Console($"Getting Localize : {Path.GetFileName(lan.value)}");
            }
            Model.Command.SpiralAbyssLocalize.Root result = new();
            var a = Datas.First().Value.Data.floors.FindAll(a => a.index >= 9);
            result.ID = Datas.First().Value.Data.schedule_id;
            a.ForEach(floor =>
            {
                var f = new Model.Command.SpiralAbyssLocalize.Floor();
                f.Index = floor.index;
                floor.levels.ForEach(level =>
                {
                    var l = new Model.Command.SpiralAbyssLocalize.Level();
                    l.Index = level.index;
                    level.battles.ForEach(battles =>
                    {
                        var b = new Model.Command.SpiralAbyssLocalize.Battle();
                        b.Index=battles.index;
                        battles.enemies.ForEach(enemies =>
                        {
                            var e = new Model.Command.SpiralAbyssLocalize.EnemyInfo();
                            e.ImageSource = Path.GetFileName(enemies.RemoteIconPath);
                            imageURL.Add(enemies.RemoteIconPath);
                            e.Level = enemies.level;
                            foreach (var s in Datas)
                            {
                                var b2 = s.Value.Data.floors.Find(a => a.index == floor.index)?
                                .levels.Find(a=>a.index==level.index)?
                                .battles.Find(a=>a.index==battles.index)?
                                .enemies.Find(a=>a.RemoteIconPath==enemies.RemoteIconPath);
                                if (b2 == null)
                                {
                                    Console("敵情報が読み込めませんでした。");
                                    return;
                                }
                                e.LocalizeName.Add(s.Key, b2.name);
                            }

                            b.Enemies.Add(e);
                        });
                        l.Battles.Add(b);
                    });
                    f.Levels.Add(l);
                });
                result.Floors.Add(f);
            });
            foreach(var url in imageURL)
            {

                string imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "spiral-abyss", "image",Path.GetFileName(url)); // 例: "C:\\Images\\myImage.png"
                var directry = Path.GetDirectoryName(imagePath);
                if(directry== null)
                {
                    Console("ディレクトリが取得できませんでした。");
                    return;
                }
                if (!Directory.Exists(directry)) Directory.CreateDirectory(directry);
                
                // 画像を保存する
                SaveImage(imagePath, await App.WebRequest.ImageGetRequest(url));

                Console($"Saved to {Path.GetFileName(url)}");
            }
            var sr = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "spiral-abyss",$"{result.ID}.json"));
            await sr.WriteAsync(JsonConvert.SerializeObject(result));
            sr.Close();
            Clipboard.SetText(JsonConvert.SerializeObject(result));
            Console($"Done!\r\n");
            new ErrorMessage("クリップボードに取得しました。", $"{JsonConvert.SerializeObject(result)}","螺旋のローカライズ取得完了").ShowDialog();
        }
        static bool SaveImage(string path, Image image)
        {
            var directry = Path.GetDirectoryName(path);
            if (directry == null)
            {
                return false;
            }
            if (!Directory.Exists(directry)) Directory.CreateDirectory(directry);
            // 画像が既に存在する場合は上書き
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // 画像を指定したパスに保存
            image.Save(path, ImageFormat.Png);
            return true;
        }
    }
}
