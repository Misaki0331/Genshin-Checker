using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Size = System.Windows.Size;

namespace Genshin_Checker.GUI.StyleTemplete
{
    public class WidthFixedPanel : WrapPanel
    {
        protected override Size MeasureOverride(Size constraint)
        {
            // 既定の動作である幅によるラップ機能を保持しつつ
            // 必要以上に幅が広がらないように制約を追加できます。
            var size = base.MeasureOverride(constraint);
            if (double.IsInfinity(constraint.Width)) constraint.Width = size.Width;
            return new Size(constraint.Width, size.Height);
        }
    }
}
