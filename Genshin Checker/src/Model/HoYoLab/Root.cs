using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*-----------------------------------------------------------------------------+
| 【API共通】                                                                  |
| APIの仕様 : APIのエラー番号とメッセージが表示される。                        |
| 利用可能端末 : すべて                                                        |
| URL : すべてのAPI URL                                                        |
+-----------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.HoYoLab
{
    public class Root<T>
    {
        /// <summary>
        /// HoYoLab内部エラーコード<br/>
        /// 成功した場合は0が返され、失敗した場合は0以外が返される。
        /// </summary>
        [JsonProperty("retcode")]
        public int Retcode { get; set; } = int.MinValue;

        /// <summary>
        /// HoYoLab内部エラーメッセージ<br/>
        /// 成功した場合は「<c>OK</c>」が返され、失敗した場合はエラーメッセージ文が返される。
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; } = "";
        
        /// <summary>
        /// 詳細なデータ<br/>
        /// <typeparamref name="T"/>に基づいてデータが返される。<br/>
        /// これは取得できない場合、<c>null</c>が返される。<br/>
        /// <c>null</c>である場合は<c>retcode</c>と<c>message</c>でエラーの原因を取得することが可能。
        /// </summary>
        [JsonProperty("data")]
        public T? Data { get; set; }
    }
}
