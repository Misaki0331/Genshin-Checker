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
        public ToolTip tooltip { get; set; } = new();

    }
}
