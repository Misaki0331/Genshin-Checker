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
            CharacterBanner = await App.WebRequest.ImageGetRequest($"https://enka.network/ui/{gacha}.png");
            var Detail = await account.Characters.GetData();
            var CharacterInfo = Detail.avatars.Find(a => a.id == characterID);
            if (CharacterInfo == null) throw new ArgumentNullException("キャラクターが所持されていません。");
            label1.Text = $"{name}";
            label2.Text = $"{CharacterInfo.name}  Lv.{CharacterInfo.level}";
            pictureBox1.Image = await App.WebRequest.ImageGetRequest($"https://static-api.misaki-chan.world/genshin-checker/asset/element/type-1/{CharacterInfo.element.ToLower()}.png");
            ImageReload(true);
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
            var data = await account.Endpoint.GetCharacterDetail(characterID);
            var list = data.skill_list.FindAll(a => a.max_level != 1);
            list.Reverse();
            foreach (var main in list) {
                var info = new TalentInfo(main.icon,main.name,$"Lv. {main.level_current}","ここに概要");
                info.Dock = DockStyle.Top;
                Panel_MainTalent.Controls.Add(info);
                MainTalent.Add(info);
            }
            list = data.skill_list.FindAll(a => a.max_level == 1);
            list.Reverse();
            foreach (var sub in list) {
                var info = new TalentInfo(sub.icon, sub.name, $"", "ここに概要");
                info.Dock= DockStyle.Top;
                Panel_SubTalent.Controls.Add(info);
                SubTalent.Add(info);
            }

            Panel_MainTalent.ResumeLayout();
            Panel_SubTalent.ResumeLayout();
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
