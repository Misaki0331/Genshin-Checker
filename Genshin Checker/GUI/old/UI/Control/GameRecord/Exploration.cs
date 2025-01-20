using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Genshin_Checker.Model.UI.GameRecords.Exploration;
using Genshin_Checker.UI.Control.GameRecord;

namespace Genshin_Checker.Window.Contains
{
    public partial class Exploration : UserControl
    {
        Root Area;
        List<ExplorationProgressBar> ProgressBar;
        List<ExplorationProgressBarMini> AreaDetail;
        List<ExplorationLevel> Levels;
        public Exploration(Root area)
        {
            Area = area;
            ProgressBar = new();
            Levels = new();
            AreaDetail = new();
            InitializeComponent();
            groupBox1.AutoSizeMode = AutoSizeMode.GrowOnly;
            DetailPanel.AutoSizeMode = AutoSizeMode.GrowOnly;
            ContainLoad();
        }
        /// <summary>
        /// リソースを解放
        /// </summary>
        public void Release()
        {
            this.SuspendLayout();
            foreach (var ex in ProgressBar)
                ex.Dispose();
            foreach (var ex in Levels)
                ex.Dispose();
            foreach (var ex in AreaDetail)
                ex.Dispose();
            Dispose();
        }
        private static Image CreateNegativeImage(Image img)
        {
            //ネガティブイメージの描画先となるImageオブジェクトを作成
            Bitmap negaImg = new Bitmap(img.Width, img.Height);
            //negaImgのGraphicsオブジェクトを取得
            Graphics g = Graphics.FromImage(negaImg);

            //ColorMatrixオブジェクトの作成
            System.Drawing.Imaging.ColorMatrix cm =
                new System.Drawing.Imaging.ColorMatrix();
            //ColorMatrixの行列の値を変更して、色が反転されるようにする
            cm.Matrix00 = -1;
            cm.Matrix11 = -1;
            cm.Matrix22 = -1;
            cm.Matrix33 = 1;
            cm.Matrix40 = cm.Matrix41 = cm.Matrix42 = cm.Matrix44 = 1;

            //ImageAttributesオブジェクトの作成
            System.Drawing.Imaging.ImageAttributes ia =
                new System.Drawing.Imaging.ImageAttributes();
            //ColorMatrixを設定する
            ia.SetColorMatrix(cm);

            //ImageAttributesを使用して色が反転した画像を描画
            g.DrawImage(img,
                new Rectangle(0, 0, img.Width, img.Height),
                0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

            //リソースを解放する
            g.Dispose();

            return negaImg;
        }
        private async void ContainLoad()
        {

            ExContain_MapIcon.Image = CreateNegativeImage(await Core.WebRequest.ImageGetRequest(Area.Images.Icon));
            ExContain_MapName.Text = Area.Name;
            var AreaProgress = Area.Progress.FindAll(a => true);
            AreaProgress.Reverse();
            foreach (var progress in AreaProgress)
            {
                //非表示ならスキップ。
                if (!progress.IsVisible) continue;
                var control = new ExplorationProgressBar(progress)
                {
                    Dock = DockStyle.Top
                };
                ExContain_ProgressPanel.Controls.Add(control);
                ProgressBar.Add(control);
            }
            if (Area.Oculus != null)
            {
                OculusCount.Text = $"{Area.Oculus.Name} : {Area.Oculus.Count}";
            }
            else OculusCount.Visible = false;


            var AreaLevels = Area.Levels.FindAll(a => true);
            AreaLevels.Reverse();
            foreach (var levels in AreaLevels)
            {
                var control = new ExplorationLevel(levels)
                {
                    Dock = DockStyle.Top
                };
                ExContain_Index.Controls.Add(control);
                Levels.Add(control);
            }

            var AreaDetail = Area.AreaDetailProgress.FindAll(a => true);
            AreaDetail.Reverse();
            foreach (var level in AreaDetail)
            {
                var control = new ExplorationProgressBarMini(level)
                {
                    Dock = DockStyle.Top
                };
                groupBox1.Controls.Add(control);
                this.AreaDetail.Add(control);
            }
            if (Area.IsDetailEnabled)
            {
                ExContain_ShowDetailButton.Visible = true;
            }

        }

        private void AreaDetailPanel_SizeChanged(object sender, EventArgs e)
        {
        }

        private void ExContain_ShowDetailButton_Click(object sender, EventArgs e)
        {
            ExContain_ShowDetailButton.Visible = false;
            ExContain_HideDetailButton.Visible = true;
            DetailPanel.Visible = true;
        }

        private void ExContain_HideDetailButton_Click(object sender, EventArgs e)
        {
            ExContain_ShowDetailButton.Visible = true;
            ExContain_HideDetailButton.Visible = false;
            DetailPanel.Visible = false;
        }
    }
}
