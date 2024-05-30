using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.API.UserInfo
{
    public class Root
    {
        /// <summary>
        /// プロフィール情報
        /// </summary>
        public Profile profile { get; set; } = new();
        /// <summary>
        /// コンポーネント情報
        /// </summary>
        public List<Component> components { get; set; } = new();
        /// <summary>
        /// エラー情報
        /// </summary>
        public string? error = null;
    }
    public class Component
    {
        /// <summary>
        /// タイトル
        /// </summary>
        public string title { get; set; } = "";
        /// <summary>
        /// 開催終了のUnix時間
        /// </summary>
        public int? endtime { get; set; } = null;
        /// <summary>
        /// 行情報
        /// </summary>
        public List<Row> rows { get; set; } = new();
        /// <summary>
        /// クリック時の遷移先リンク
        /// </summary>
        public string clickto { get; set; } = "";
    }
    public class Row
    {
        /// <summary>
        /// アイコンURL
        /// </summary>
        public string icon { get; set; } = "";
        /// <summary>
        /// アイコンオーバーレイURL
        /// </summary>
        public string icon_overlay { get; set; } = "";
        /// <summary>
        /// 左側の値
        /// </summary>
        public string value { get; set; } = "";
        /// <summary>
        /// 右側の小さな値
        /// </summary>
        public string? max_value { get; set; } = null;
        /// <summary>
        /// 下側の値
        /// </summary>
        public string? bottom_value { get; set; } = null;
        /// <summary>
        /// ツールチップ情報
        /// </summary>
        public API.ToolTip tooltip { get; set; } = new();

    }
}
