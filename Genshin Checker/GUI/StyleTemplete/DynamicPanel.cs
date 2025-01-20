using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Panel = System.Windows.Controls.Panel;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace Genshin_Checker.GUI.StyleTemplete
{
    public class DynamicWrapPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            double totalWidth = availableSize.Width;
            if (InternalChildren.Count == 0) 
                return availableSize;

            // 最小のコントロール幅を計算
            double minItemWidth = 0;
            foreach (UIElement child in InternalChildren)
            {
                child.Measure(availableSize);
                minItemWidth = Math.Max(minItemWidth, child.DesiredSize.Width);
            }

            // ウィンドウ幅に応じた列数の計算
            int columns = (int)(totalWidth / minItemWidth);
            if (columns == 0) columns = 1;

            // 列の数に基づいて新しい横幅を計算（余りがないように）
            double itemWidth = totalWidth / columns;

            double[] rowHeights = new double[(int)Math.Ceiling((double)InternalChildren.Count / columns)];

            // 各行の最大高さを計算
            for (int i = 0; i < InternalChildren.Count; i++)
            {
                int row = i / columns;
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

            // 最小幅を取得して列数を決定
            double minItemWidth = 0;
            foreach (UIElement child in InternalChildren)
            {
                minItemWidth = Math.Max(minItemWidth, child.DesiredSize.Width);
            }

            // 列数を計算（余りが出ないように）
            int columns = (int)(totalWidth / minItemWidth);
            if (columns == 0) columns = 1;

            // 列の幅を余りが出ないように均等に調整
            double itemWidth = totalWidth / columns;

            double[] rowHeights = new double[(int)Math.Ceiling((double)InternalChildren.Count / columns)];

            // 各行の最大高さを計算
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

                // 子要素を配置（横幅は均等、縦は行ごとに異なる）
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
