using Genshin_Checker.App.HoYoLab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Genshin_Checker.UI.Control.GameRecord.CharacterDetail;
using LiveChartsCore.Drawing;
using static Genshin_Checker.App.HoYoLab.Account;

namespace Genshin_Checker.Window.ExWindow.GameRecords
{
    public partial class CharacterDetail : Form
    {
        PictureBox picture;
        List<TalentInfo> MainTalent;
        List<TalentInfo> SubTalent;
        WeaponDetail WeaponDetail;
        List<ConstellationInfo> Constellation;
        List<ArtifactInfo> ArtifactInfos;
        Image? CharacterBanner;
        private CancellationTokenSource? cts;
        private SemaphoreSlim _semaphore;
        bool IsLoading = false;
        int TempCharacterID = 0;
        public CharacterDetail()
        {
            InitializeComponent();
            Icon = Icon.FromHandle(resource.icon.Battle_Chronicle.GetHicon());
            picture = new();
            panel1.Resize += pictureBox1_Resize;
            panel1.Controls.Add(picture);
            picture.Location = new(0, 0);
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
            MainTalent = new();
            SubTalent = new();
            Constellation = new();
            ArtifactInfos = new();
            _semaphore= new SemaphoreSlim(1,1);
            WeaponDetail = new WeaponDetail() { Dock=DockStyle.Top};
            groupBox2.Controls.Add(WeaponDetail);
        }
        public async void DataUpdate(Account account,int characterID,string name)
        {

            await _semaphore.WaitAsync(); // ロックを取得する
            try
            {
                if (TempCharacterID == characterID) return;
                TempCharacterID = characterID;
                if (cts != null) cts.Cancel(true);
                cts = new();
                if (Store.EnkaData.Data.Characters == null) return;
                var character = Store.EnkaData.Data.Characters[$"{characterID}"];
                var gacha = character.SideIconName.Replace("UI_AvatarIcon_Side_", "UI_Gacha_AvatarImg_");

                //キャラクター情報の取得
                var Detail = await account.Characters.GetData();
                var CharacterInfo = Detail.avatars.Find(a => a.id == characterID);
                if (CharacterInfo == null) throw new ArgumentNullException("キャラクターが所持されていません。");

                Text = $"キャラクター詳細 - {CharacterInfo.name} (UID:{account.UID})";
                IsLoading = true;
                ImageReload(true);
                //概要
                label1.Text = $"{name}";
                label2.Text = $"Lv.{CharacterInfo.level}";
                label4.Text = $"好感度Lv.{CharacterInfo.fetter}";
                int constellation = CharacterInfo.constellations.FindAll(a => a.is_actived).Count;
                if (constellation == 0) label5.Text = "";
                else if (constellation == 6) label5.Text = "【完凸】";
                else label5.Text = $"【{constellation}凸】";
                pictureBox1.Image = await App.WebRequest.ImageGetRequest($"https://static-api.misaki-chan.world/genshin-checker/asset/element/type-1/{CharacterInfo.element.ToLower()}.png");

                //武器
                var weapon = CharacterInfo.weapon;
                WeaponDetail.UpdateData(weapon.rarity, weapon.icon, weapon.name, weapon.level, weapon.affix_level);

                //天賦
                Panel_MainTalent.SuspendLayout();
                Panel_SubTalent.SuspendLayout();
                foreach (var control in MainTalent)
                {
                    Panel_MainTalent.Controls.Remove(control);
                    control.Dispose();
                }
                MainTalent.Clear();
                foreach (var control in SubTalent)
                {
                    Panel_SubTalent.Controls.Remove(control);
                    control.Dispose();
                }
                SubTalent.Clear();
                panel5.Visible = true;
                try
                {
                    var data = await account.CharacterDetail.GetData(characterID);
                    var list = data.skill_list.FindAll(a => a.max_level != 1);
                    list.Reverse();
                    foreach (var main in list)
                    {
                        var info = new TalentInfo(main.icon, main.name, $"Lv. {main.level_current}", "ここに概要");
                        info.Dock = DockStyle.Top;
                        Panel_MainTalent.Controls.Add(info);
                        MainTalent.Add(info);
                    }
                    list = data.skill_list.FindAll(a => a.max_level == 1);
                    list.Reverse();
                    foreach (var sub in list)
                    {
                        var info = new TalentInfo(sub.icon, sub.name, $"", "ここに概要");
                        info.Dock = DockStyle.Top;
                        Panel_SubTalent.Controls.Add(info);
                        SubTalent.Add(info);
                    }
                    Error_TalentPanel.Visible = false;
                    Button_TalentHideShow.Visible = true;
                }
                catch (HoYoLabAPIException ex)
                {
                    string hint = "";
                    switch (ex.Retcode)
                    {
                        case -502002:
                            hint = "このエラーはゲーム内アクセスが許可されていない場合に発生します。\n一度HoYoLabモバイルアプリを開き、「育成計算機」の許可設定からゲーム内のキャラクターデータのアクセスを許可してください。";
                            break;
                    }
                    textBox1.Lines = $"エラーコード : {ex.Retcode}\nメッセージ : {ex.APIMessage}\n{hint}".Split('\n');
                    Error_TalentPanel.Visible = true;
                    Button_TalentHideShow.Visible = false;

                }
                catch (Exception ex)
                {

                    textBox1.Lines = $"{ex.GetType()}\n{ex.Message}".Split('\n');
                    Error_TalentPanel.Visible = true;
                    Button_TalentHideShow.Visible = false;
                    new ErrorMessage("天賦情報取得時にエラーが発生しました。", ex.ToString()).ShowDialog();
                }

                Panel_MainTalent.ResumeLayout();
                Panel_SubTalent.ResumeLayout();
                //命ノ星座
                ConstellationPanel.SuspendLayout();
                foreach (var control in Constellation)
                {
                    ConstellationPanel.Controls.Remove(control);
                    control.Dispose();
                }
                Constellation.Clear();
                for (int i = 6; i >= 1; i--)
                {
                    var data = CharacterInfo.constellations.Find(a => a.pos == i);
                    if (data == null) continue;
                    var info = new ConstellationInfo(data.name, data.icon, data.is_actived)
                    {
                        Dock = DockStyle.Top
                    };
                    ConstellationPanel.Controls.Add(info);
                    Constellation.Add(info);
                }
                ConstellationPanel.ResumeLayout();
                //聖遺物
                ArtifactLayout.SuspendLayout();
                foreach (var control in ArtifactInfos)
                {
                    ArtifactLayout.Controls.Remove(control);
                    control.Dispose();
                }
                ArtifactInfos.Clear();
                for (int i = 1; i <= 5; i++)
                {
                    var data = CharacterInfo.reliquaries.Find(a => a.pos == i);
                    ArtifactInfo? control = null;
                    if (data == null)
                    {
                        control = new(i, null, 0, "未装備");
                    }
                    else
                    {
                        control = new(i, data.icon, data.rarity, $"+{data.level}");
                    }
                    ArtifactLayout.Controls.Add(control);
                    ArtifactInfos.Add(control);
                }
                ArtifactLayout.ResumeLayout();

                CharacterBanner = await App.WebRequest.ImageGetRequest($"https://enka.network/ui/{gacha}.png", cts.Token);

                IsLoading = false;
                ImageReload(true);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private void pictureBox1_Resize(object? sender, EventArgs e)
        {
            ImageReload();
        }
        void ImageReload(bool reload = false)
        {
            if (IsLoading)
            {
                var old = picture.Image;
                picture.Image = resource.GenshinAsset.loading;
                picture.Dock = DockStyle.Fill;
                picture.SizeMode = PictureBoxSizeMode.CenterImage;
                old?.Dispose();
            }
            else
            {
                if (CharacterBanner != null && (panel1.Height != picture.Height || reload))
                {
                    var old = picture.Image;
                    double zoom = (double)panel1.Height / CharacterBanner.Height;
                    Size size = new((int)(CharacterBanner.Width * zoom), (int)(CharacterBanner.Height * zoom));
                    if (size.Width <= 0 || size.Height <= 0) return;
                    picture.Dock = DockStyle.None;
                    picture.SizeMode = PictureBoxSizeMode.AutoSize;
                    picture.Image = new Bitmap(CharacterBanner, new((int)(CharacterBanner.Width * zoom), (int)(CharacterBanner.Height * zoom)));
                    old?.Dispose();
                }
                picture.Location = new(-picture.Width / 2 + panel1.Width / 2, 0);
            }
        }

        private void Button_TalentHideShow_Click(object sender, EventArgs e)
        {
            Panel_SubTalent.Visible = !Panel_SubTalent.Visible;
            if(Panel_SubTalent.Visible)
            {
                Button_TalentHideShow.Text = "隠す ▲";
            }
            else
            {
                Button_TalentHideShow.Text = "もっと見る ▼";
            }
        }
    }
}
