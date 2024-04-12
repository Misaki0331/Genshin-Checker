using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App
{
    public static class LocalizeManager
    {
        static CultureInfo CurrentLanguage = new("en-US");
        public static void SetLanguage(string? language=null)
        {
            if (language == null) language = CultureInfo.CurrentCulture.Name;
            //言語設定
            if (language == "ja-JP" || language == "ja")
            {
                CurrentLanguage = new("ja-JP");
            }
            else
            {
                CurrentLanguage = new("en-US");
            }
            Thread.CurrentThread.CurrentUICulture = CurrentLanguage;
            Thread.CurrentThread.CurrentCulture = CurrentLanguage;
        }
        private static string GetShortLanguage()
        {
            if (CurrentLanguage.Name.StartsWith("zh"))
            {
                return CurrentLanguage.Name;
            }
            else return CurrentLanguage.Name.Split("-")[0];
        }
        public static CultureInfo Current { get => new(CurrentLanguage.Name); }
        /// <summary>
        /// 長い言語コードを返す
        /// <code>日本語：ja-jp<br/>
        /// 英語：en-us<br/>
        /// 簡体中国語：zh-cn<br/>
        /// 繁体中国語：zh-tw</code>
        /// </summary>
        public static string CurrentLong { get => CurrentLanguage.Name.ToLower(); }
        /// <summary>
        /// 中国語を除く短い言語コードを返す
        /// <code>日本語：ja<br/>
        /// 英語：en<br/>
        /// 簡体中国語：zh-cn<br/>
        /// 繁体中国語：zh-tw</code>
        /// </summary>
        public static string CurrentShort { get => GetShortLanguage(); }
    }
}
