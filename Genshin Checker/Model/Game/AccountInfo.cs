using Genshin_Checker.Model.HoYoLab.CharacterDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.Game.AccountInfo
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }
    public class Data
    {
        /// <summary>
        /// ゲームの種類(原神グローバル版だと"hk4e_global"固定
        /// </summary>
        public string game { get; set; } = string.Empty;
        /// <summary>
        /// ゲームサーバー
        /// </summary>
        public string region { get; set; } = string.Empty;
        /// <summary>
        /// ゲーム内UID
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// ゲーム内名前
        /// </summary>
        public string nickname { get; set; } = string.Empty;
        /// <summary>
        /// 通行証アカウントID
        /// </summary>
        public int aid { get; set; }
    }
}
