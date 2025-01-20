using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.API
{
    public class ToolTip
    {
        /// <summary>
        /// タイトル
        /// </summary>
        public string title { get; set; } = "";
        /// <summary>
        /// 説明文
        /// </summary>
        public string? description { get; set; } = null;
    }
}
