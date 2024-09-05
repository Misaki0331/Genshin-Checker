using System.Drawing.Drawing2D;

namespace Genshin_Checker.App.General.UI
{
    public static class DrawControl
    {
        /// <summary>
        /// 縁取りされた文字を描画します。
        /// </summary>
        /// <param name="g">ラベルのGraphic (Label.Paintイベントで取得)</param>
        /// <param name="label">ラベルコントロール</param>
        /// <param name="fontColor">文字色</param>
        /// <param name="outlineColor">縁取りの色</param>
        /// <param name="outlineWidth">線の太さ</param>
        public static void DrawOutlineString(Graphics g, Label label, Color fontColor, Color outlineColor, int outlineWidth)
        {
            ///Todo: LabelからPictureBoxに変更
            using GraphicsPath path = new();
            double dpi = label.DeviceDpi / 96.0;
            using Pen pen = new(outlineColor, outlineWidth) { LineJoin = LineJoin.Round };
            using SolidBrush brush = new(fontColor);
            StringFormat format = StringFormat.GenericTypographic;
            switch (label.TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    format.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    format.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    format.Alignment = StringAlignment.Far;
                    break;
            }
            switch (label.TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    format.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    format.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    format.LineAlignment = StringAlignment.Far;
                    break;
            }
            path.AddString(label.Text, label.Font.FontFamily, (int)label.Font.Style, (label.Font.Size) * 1.25f*(float)dpi, label.ClientRectangle, StringFormat.GenericTypographic);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawPath(pen, path);
            g.FillPath(brush, path);
        }
        /// <summary>
        /// 画像を基準としてコントロールの背景を再描画します。
        /// </summary>
        /// <param name="graphics">Control.Paintイベントで取得したGraphicsクラス</param>
        /// <param name="image">背景にする画像</param>
        /// <param name="pictureControl">背景にされている基準のコントロール</param>
        /// <param name="OverrideControl">背景に再描画させるコントロール</param>
        public static void DrawBackground(Graphics graphics, Image? image, Control pictureControl, Control OverrideControl)
        {
            graphics.Clear(OverrideControl.BackColor);
            Point window = pictureControl.PointToClient(Point.Empty);
            Point location = OverrideControl.PointToClient(pictureControl.PointToClient(new(-window.X * 2, -window.Y * 2)));
            if(image!=null)graphics.DrawImage(image, location);
        }
        public static Bitmap BitmapInterpolation(Image image, int width, int height, InterpolationMode mode = InterpolationMode.HighQualityBilinear)
        {
            return BitmapInterpolation((Bitmap)image, width, height, mode);
        }
        public static Bitmap BitmapInterpolation(Bitmap bitmap, int width, int height, InterpolationMode mode=InterpolationMode.HighQualityBilinear)
        {
            Bitmap canvas = new(width, height);
            Graphics g = Graphics.FromImage(canvas);
            //補間方法として最近傍補間を指定する
            g.InterpolationMode =mode;
            //画像を拡大縮小して描画する
            g.DrawImage(bitmap, 0, 0, width, height);
            g.Dispose();
            return canvas;
        }
    }
}
