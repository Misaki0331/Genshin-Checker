using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.API
{
    public class Profile
    {
        /// <summary>
        /// ネームカードの背景URL
        /// </summary>
        public string namecard { get; set; } = "";
        /// <summary>
        /// アイコンURL
        /// </summary>
        public string icon { get; set; } = "";
        /// <summary>
        /// 名前
        /// </summary>
        public string name { get; set; } = "";
        /// <summary>
        /// ステータスメッセージ
        /// </summary>
        public string message { get; set; } = "";
        /// <summary>
        /// アカウントUID
        /// </summary>
        public int uid { get; set; } = 0;
        /// <summary>
        /// プロフィールのバッジ情報
        /// </summary>
        public List<Badge> badges { get; set; } = new();
    }
    public class Badge
    {
        /// <summary>
        /// バッジに表示するテキスト
        /// </summary>
        public string name { get; set; } = "";
        /// <summary>
        /// 色情報
        /// </summary>
        public BadgeColor color { get; set; } = new();
        /// <summary>
        /// ツールチップ情報
        /// </summary>
        public ToolTip tooltip { get; set; } = new();
        /// <summary>
        /// アイコン
        /// </summary>
        public string? icon { get; set; } = null;
    }
    public class BadgeColor
    {
        /// <summary>
        /// 背景色
        /// </summary>
        public string bg { get; set; } = "#FFFFAF";
        /// <summary>
        /// 文字色
        /// </summary>
        public string fg { get; set; } = "#202020";
    }
}
