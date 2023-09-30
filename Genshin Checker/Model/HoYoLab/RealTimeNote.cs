using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*-----------------------------------------------------------------------------+
| 機能名 : リアルタイムノート                                                  |
| APIの仕様 : 現在の樹脂・探索派遣・デイリーの状況をリアルタイムで取得         |
| 利用可能端末 : HoYoLabモバイル                                               |
| URL : https://bbs-api-os.hoyolab.com/game_record/genshin/api/dailyNote       |
| パラメーター :                                                               |
|   server: [String] アカウントのサーバー、アジア圏の場合は「os_asia」         |
|   role_id: [Number] ゲーム内UID アジア圏なら8から始まる9桁 例: 「800000000」 |
+-----------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.HoYoLab.RealTimeNote
{
    public class Data
    {
        /// <summary>
        /// 【樹脂】<br/>現在の樹脂の数
        /// </summary>
        public int current_resin { get; set; }
        /// <summary>
        /// 【樹脂】<br/>現段階で最大まで貯まる樹脂の数
        /// </summary>
        public int max_resin { get; set; }
        /// <summary>
        /// 【樹脂】<br/>樹脂を最大まで貯めるのにかかる時間(単位：秒)
        /// </summary>
        public string resin_recovery_time { get; set; } = "";
        /// <summary>
        /// 【デイリー任務】<br/>完了済みの任務の数<br/>
        /// </summary>
        public int finished_task_num { get; set; }
        /// <summary>
        /// 【デイリー任務】<br/>現段階の任務の上限数<br/>
        /// </summary>
        public int total_task_num { get; set; }
        /// <summary>
        /// 【デイリー任務】<br/>全任務達成報酬受取済か<br/>
        /// </summary>
        public bool is_extra_task_reward_received { get; set; }
        /// <summary>
        /// 【週ボス】<br/>週ボスの残り樹脂割引回数<br/>
        /// </summary>
        public int remain_resin_discount_num { get; set; }
        /// <summary>
        /// 【週ボス】<br/>現段階の週ボスの樹脂割引上限回数<br/>
        /// </summary>
        public int resin_discount_num_limit { get; set; }
        /// <summary>
        /// 【探索派遣】<br/>探索派遣済みの人数<br/>
        /// </summary>
        public int current_expedition_num { get; set; }
        /// <summary>
        /// 【探索派遣】<br/>現状の探索派遣上限の人数<br/>
        /// </summary>
        public int max_expedition_num { get; set; }
        /// <summary>
        /// 【探索派遣】<br/>探索派遣の詳細データ<br/>
        /// </summary>
        public List<Expedition> expeditions { get; set; } = new();
        public int current_home_coin { get; set; }
        public int max_home_coin { get; set; }
        public string home_coin_recovery_time { get; set; } = "";
        public string calendar_url { get; set; } = "";
        public Transformer transformer { get; set; } = new();
    }

    public class Expedition
    {
        //注意 : このデータから探索派遣にいるキャラクター情報を入手することはできません。

        /// <summary>
        /// <para>【探索派遣詳細】</para>
        /// <para>キャラクターの横顔画像のURL</para>
        /// 備考 : アイコンURLはハッシュ化されている
        /// </summary>
        public string avatar_side_icon { get; set; } = "";
        /// <summary>
        /// <para>【探索派遣詳細】</para>
        /// <para>現在の探索派遣のステータス</para>
        /// <c>"OnGoing"</c> : 探索中<br/>
        /// <c>"Finished"</c> : 探索完了/報酬受取可能
        /// </summary>
        public string status { get; set; } = "";
        /// <summary>
        /// <para>【探索派遣詳細】</para>
        /// <para>該当キャラクターの探索派遣が完了する残り時間</para>
        /// 単位は「秒」<br/>
        /// <c>status</c> が <c>"Finished"</c> の場合は常に <c>"0"</c> になる。<br/>
        /// <c>int.TryParse()</c>必須
        /// </summary>
        public string remained_time { get; set; } = "";
    }
    public class Transformer
    {
        /// <summary>
        /// <para>【参量物質変化器】</para>
        /// <para>該当アイテムが入手済みであるか</para>
        /// </summary>
        public bool obtained { get; set; }
        /// <summary>
        /// <para>【参量物質変化器】</para>
        /// <para>再度使用ができるまでの時間と使用可能であるかどうか</para>
        /// 注意 : これは正確な時間を示すわけではありません。<br/>
        /// <c>Day</c>, <c>Hour</c>, <c>Minute</c>, <c>Second</c>のうちいずれかで一番大きい値のみデータが入ります。
        /// </summary>
        public RecoveryTime recovery_time { get; set; } = new();

        /// <summary>
        /// <para>【参量物質変化器】</para>
        /// <para>不明</para>
        /// </summary>
        public string wiki { get; set; } = "";
        /// <summary>
        /// <para>【参量物質変化器】</para>
        /// <para>不明</para>
        /// </summary>
        public bool noticed { get; set; }
        /// <summary>
        /// <para>【参量物質変化器】</para>
        /// <para>不明</para>
        /// </summary>
        public string latest_job_id { get; set; } = "";
    }

    public class RecoveryTime
    {
        /// <summary>
        /// <para>【参量物質変化器】</para>
        /// <para>残り日数</para>
        /// この値が <c>1</c> 以上である場合、 <c>24</c> 時間以上の残り時間があります。
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// <para>【参量物質変化器】</para>
        /// <para>残り時間</para>
        /// この値が <c>1</c> 以上である場合、 <c>1</c> 時間～ <c>24</c> 時間未満の残り時間があります。
        /// </summary>
        public int Hour { get; set; }
        /// <summary>
        /// <para>【参量物質変化器】</para>
        /// <para>残り分</para>
        /// この値が <c>1</c> 以上である場合、 <c>1</c> 分～ <c>60</c> 分未満の残り時間があります。
        /// </summary>
        public int Minute { get; set; }
        /// <summary>
        /// <para>【参量物質変化器】</para>
        /// <para>残り秒</para>
        /// この値が <c>1</c> 以上である場合、 <c>1</c> 秒～ <c>60</c> 秒未満の残り時間があります。
        /// </summary>
        public int Second { get; set; }
        /// <summary>
        /// <para>【参量物質変化器】</para>
        /// <para>再度利用可能かどうか</para>
        /// <c>True</c> : クールタイムが終了していつでも使用できる状態<br/>
        /// <c>False</c> : クールタイムが存在しており残り時間が <c>Day</c>, <c>Hour</c>, <c>Minute</c>, <c>Second</c> のいずれかで1以上になる。
        /// </summary>
        public bool reached { get; set; }
    }
}
