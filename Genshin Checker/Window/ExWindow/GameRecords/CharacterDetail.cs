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
        public CharacterDetail()
        {
            InitializeComponent();
            picture = new();
            panel1.Resize += pictureBox1_Resize;
            panel1.Controls.Add(picture);
            picture.Location = new(0, 0);
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
            MainTalent = new();
            SubTalent = new();
        }
        Image CharacterBanner;
        public async void DataUpdate(Account account,int characterID,string name)
        {
            if (Store.EnkaData.Data.Characters == null) return;
            var character = Store.EnkaData.Data.Characters[$"{characterID}"];
            var gacha = character.SideIconName.Replace("UI_AvatarIcon_Side_", "UI_Gacha_AvatarImg_");
            var Detail = await account.Characters.GetData();
            var CharacterInfo = Detail.avatars.Find(a => a.id == characterID);
            if (CharacterInfo == null) throw new ArgumentNullException("キャラクターが所持されていません。");
            label1.Text = $"{name}";
            label2.Text = $"{CharacterInfo.name}  Lv.{CharacterInfo.level}";
            pictureBox1.Image = await App.WebRequest.ImageGetRequest($"https://static-api.misaki-chan.world/genshin-checker/asset/element/type-1/{CharacterInfo.element.ToLower()}.png");


            Panel_MainTalent.SuspendLayout();
            Panel_SubTalent.SuspendLayout();
            foreach(var control in MainTalent)
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
                label4.Text = $"エラーコード : {ex.Retcode}\nメッセージ : {ex.APIMessage}\n{hint}";
                Error_TalentPanel.Visible = true;
                Button_TalentHideShow.Visible = false;
                
            }catch(Exception ex)
            {

                label4.Text = $"{ex.GetType()}\n{ex.Message}";
                Error_TalentPanel.Visible = true;
                Button_TalentHideShow.Visible = false;
                new ErrorMessage("天賦情報取得時にエラーが発生しました。", ex.ToString()).ShowDialog();
            }

            Panel_MainTalent.ResumeLayout();
            Panel_SubTalent.ResumeLayout();

            CharacterBanner = await App.WebRequest.ImageGetRequest($"https://enka.network/ui/{gacha}.png");
            ImageReload(true);

        }

        private void pictureBox1_Resize(object? sender, EventArgs e)
        {
            ImageReload();
        }
        void ImageReload(bool reload = false)
        {
            if (panel1.Height != picture.Height||reload)
            {
                var old = picture.Image;
                double zoom = (double) panel1.Height/ CharacterBanner.Height;
                picture.Image = new Bitmap(CharacterBanner,new((int)(CharacterBanner.Width * zoom), (int)(CharacterBanner.Height * zoom)));
                if(old!=null)old.Dispose();
            }
            picture.Location=new(-picture.Width /2 + panel1.Width / 2,0);
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
