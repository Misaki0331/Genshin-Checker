using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        List<ExplorationLevel> Levels;
        public Exploration(Root area)
        {
            Area = area;
            ProgressBar = new();
            Levels = new();
            InitializeComponent();
            ContainLoad();
        }
        /// <summary>
        /// リソースを解放
        /// </summary>
        public void Release()
        {
            foreach(var ex in ProgressBar)
                ex.Dispose();
            foreach (var ex in Levels)
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
        private async void ContainLoad() {

            ExContain_MapIcon.Image = CreateNegativeImage(await App.WebRequest.ImageGetRequest(Area.Images.Icon));
            ExContain_MapName.Text = Area.Name;
            for(int i=Area.Progress.Count-1;i>=0;i--)
            {
                var progress = Area.Progress[i];
                var control = new ExplorationProgressBar(progress)
                {
                    Dock = DockStyle.Top
                };
                ExContain_ProgressPanel.Controls.Add(control);
                ProgressBar.Add(control);
            }


            for (int i = Area.Levels.Count - 1; i >= 0; i--)
            {
                var levels = Area.Levels[i];
                var control = new ExplorationLevel(levels)
                {
                    Dock = DockStyle.Top
                };
                ExContain_Index.Controls.Add(control);
                Levels.Add(control);
            }
        }
    }
}
