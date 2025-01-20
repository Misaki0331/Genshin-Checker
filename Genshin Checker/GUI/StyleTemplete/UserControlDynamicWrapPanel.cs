using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Panel = System.Windows.Controls.Panel;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace Genshin_Checker.GUI.StyleTemplete
{
    //良い感じに
    public class UserControlDynamicWrapPanel : Panel
    {
        public double MinItemWidth { get; set; } = 100; // 最小幅
        public double MaxItemWidth { get; set; } = 300; // 最大幅

        protected override Size MeasureOverride(Size availableSize)
        {
            double totalWidth = availableSize.Width;

            // 子要素の最小幅を基準にして列数を決定
            double itemWidth = MaxItemWidth;
            int columns = (int)(totalWidth / itemWidth);

            // 列数を調整して、minWidthとmaxWidthの間で最適な幅を計算
            while (itemWidth > MinItemWidth && columns > 0 && (totalWidth / columns) > MaxItemWidth)
            {
                columns++;
                itemWidth = totalWidth / columns;
            }
            if (columns < 1 || (itemWidth < MinItemWidth && columns > 2))
            {
                itemWidth = totalWidth;
                columns--;
                if (columns < 1) columns = 1;
            }

            double[] rowHeights = new double[(int)Math.Ceiling((double)InternalChildren.Count / columns)];

            // 各行ごとの最大高さを計算
            for (int i = 0; i < InternalChildren.Count; i++)
            {
                int row = i / columns;
                InternalChildren[i].Measure(new Size(itemWidth, availableSize.Height));
                rowHeights[row] = Math.Max(rowHeights[row], InternalChildren[i].DesiredSize.Height);
            }

            double totalHeight = 0;
            foreach (var height in rowHeights)
            {
                totalHeight += height;
            }

            // 全体のサイズを返す
            return new Size(totalWidth, totalHeight);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double totalWidth = finalSize.Width;

            // 子要素の最小幅を基準にして列数を決定
            double itemWidth = MaxItemWidth;
            int columns = (int)(totalWidth / itemWidth);

            // 列数を調整して、minWidthとmaxWidthの間で最適な幅を計算
            while (itemWidth > MinItemWidth && columns > 0 && (totalWidth / columns) > MaxItemWidth)
            {
                columns++;
                itemWidth = totalWidth / columns;
            }

            if (columns < 1 || (itemWidth < MinItemWidth && columns > 1))
            {
                itemWidth = totalWidth;
                columns--;
                if (columns < 1) columns = 1;
            }
            if (itemWidth < MinItemWidth && columns>1)
            {
                itemWidth = MinItemWidth;
            }

            double[] rowHeights = new double[(int)Math.Ceiling((double)InternalChildren.Count / columns)];

            // 各行ごとの最大高さを計算
            for (int i = 0; i < InternalChildren.Count; i++)
            {
                int row = i / columns;
                rowHeights[row] = Math.Max(rowHeights[row], InternalChildren[i].DesiredSize.Height);
            }

            double x = 0, y = 0;
            int column = 0, currentRow = 0;

            // 各子要素を配置
            for (int i = 0; i < InternalChildren.Count; i++)
            {
                UIElement child = InternalChildren[i];

                if (column >= columns)
                {
                    column = 0;
                    x = 0;
                    y += rowHeights[currentRow];
                    currentRow++;
                }

                // 子要素を配置（横幅は計算された等分の幅、縦は行ごとに異なる）
                Rect rect = new Rect(new Point(x, y), new Size(itemWidth, rowHeights[currentRow]));
                child.Arrange(rect);

                x += itemWidth;
                column++;
            }

            double totalHeight = 0;
            foreach (var height in rowHeights)
            {
                totalHeight += height;
            }

            return new Size(finalSize.Width, totalHeight);
        }
    }
}
