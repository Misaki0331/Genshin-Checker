using Newtonsoft.Json;
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
    public class Root : Model.HoYoLab.Root<Data>
    {
    }

    public class Data
    {
        /// <summary>
        /// <para>【樹脂】</para>
        /// 現在の樹脂の数
        /// </summary>
        public int current_resin { get; set; }
        /// <summary>
        /// <para>【樹脂】</para>
        /// 現段階で最大まで貯まる樹脂の数
        /// </summary>
        public int max_resin { get; set; }
        /// <summary>
        /// <para>【樹脂】</para>
        /// 樹脂を最大まで貯めるのにかかる時間(単位：秒)
        /// </summary>
        public string resin_recovery_time { get; set; } = "";
        /// <summary>
        /// <para>【デイリー任務】</para>
        /// 完了済みの任務の数<br/>
        /// </summary>
        public int finished_task_num { get; set; }
        /// <summary>
        /// <para>【デイリー任務】</para>
        /// 現段階の任務の上限数<br/>
        /// </summary>
        public int total_task_num { get; set; }
        /// <summary>
        /// <para>【デイリー任務】</para>
        /// 全任務達成報酬受取済か<br/>
        /// </summary>
        public bool is_extra_task_reward_received { get; set; }
        /// <summary>
        /// <para>【週ボス】</para>
        /// 週ボスの残り樹脂割引回数<br/>
        /// </summary>
        public int remain_resin_discount_num { get; set; }
        /// <summary>
        /// <para>【週ボス】</para>
        /// 現段階の週ボスの樹脂割引上限回数<br/>
        /// </summary>
        public int resin_discount_num_limit { get; set; }
        /// <summary>
        /// <para>【探索派遣】</para>
        /// 探索派遣済みの人数<br/>
        /// </summary>
        public int current_expedition_num { get; set; }
        /// <summary>
        /// <para>【探索派遣】</para>
        /// 現状の探索派遣上限の人数<br/>
        /// </summary>
        public int max_expedition_num { get; set; }
        /// <summary>
        /// <para>【探索派遣】</para>
        /// 探索派遣の詳細データ<br/>
        /// </summary>
        public List<Expedition> expeditions { get; set; } = new();
        /// <summary>
        /// <para>【塵歌壺】</para>
        /// 現在の貯蓄済みの洞天宝銭の数<br/>
        /// </summary>
        public int current_home_coin { get; set; }
        /// <summary>
        /// <para>【塵歌壺】</para>
        /// 最大で貯蓄可能な洞天宝銭の数<br/>未開放の場合は <c>0</c> 固定になる<br/>
        /// </summary>
        public int max_home_coin { get; set; }
        /// <summary>
        /// <para>【塵歌壺】</para>
        /// 洞天宝銭の貯蓄が最大まで貯めるのにかかる時間(単位：秒)<br/>
        /// </summary>
        public string home_coin_recovery_time { get; set; } = "";
        public string calendar_url { get; set; } = "";
        /// <summary>
        /// <para>【参量物質変化器】</para>
        /// <para>参量物質変化器の詳細データ</para>
        /// </summary>
        public Transformer transformer { get; set; } = new();
        /// <summary>
        /// <para>【デイリー状況】</para>
        /// <para>デイリー任務と冒険修練に関するデータ</para>
        /// </summary>
        public DailyTask daily_task { get; set; } = new();
        /// <summary>
        /// <para>【魔神任務の進行状況】</para>
        /// <para>魔神任務のデータ</para>
        /// </summary>
        public ArchonQuestProgress archon_quest_progress { get; set; } = new();
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

    public class TaskReward
    {
        /// <summary>
        /// <para>【デイリー任務クリア状況】</para>
        /// <para>2つの状態で管理されている。</para>
        /// <para><c>TaskRewardStatusTakenAward</c> : 該当任務はクリア済<br/>
        /// <c>TaskRewardStatusUnfinished</c> : 該当任務は未クリア</para>
        /// </summary>
        public string status { get; set; } = string.Empty;
    }
    //ToDo:魔神任務をする
    public class ArchonQuestData
    {
        /// <summary>
        /// <para>【魔神任務】</para>
        /// <para>ステータス</para>
        /// <para><c>StatusNotOpen</c> : まだ任務を始めていない
        /// 他にもあるがToDo</para>
        /// </summary>
        public string status { get; set; } = string.Empty;
        /// <summary>
        /// <para>【魔神任務】</para>
        /// <para>現在のチャプター</para>
        /// 注意 : 返ってくるのは数値ではありません。<br/>
        /// 「<c>第一章 第一幕</c>」と文字列で返ってきます。
        /// </summary>
        public string chapter_num { get; set; } = string.Empty;
        /// <summary>
        /// <para>【魔神任務】</para>
        /// <para>チャプター名</para>
        /// 例 : <c>罪人の円舞曲</c>
        /// </summary>
        public string chapter_title { get; set; } = string.Empty;
        /// <summary>
        /// <para>【魔神任務】</para>
        /// <para>任務内部番号</para>
        /// </summary>
        public int id { get; set; }
    }
    public class ArchonQuestProgress
    {
        public List<ArchonQuestData> list { get; set; } = new();
        /// <summary>
        /// 【魔神任務】
        /// 解放済みかどうか
        /// </summary>
        public bool is_open_archon_quest { get; set; }
        /// <summary>
        /// 【魔神任務】
        /// 現在の解放済み魔神任務を全て読了しているかどうか
        /// </summary>
        public bool is_finish_all_mainline { get; set; }
        /// <summary>
        /// 【魔神任務】
        /// 該当の任務が完了しているかどうか
        /// </summary>
        public bool is_finish_all_interchapter { get; set; }
        public string wiki_url { get; set; } = string.Empty;
    }
    //Todo: デイリーの検証を行う
    public class AttendanceReward
    {
        /// <summary>
        /// <para>【冒険修練】</para>
        /// <para>ステータス</para>
        /// <para><c>AttendanceRewardStatusForbid</c> : 利用不可(禁止マーク)<br/>
        /// <c>AttendanceRewardStatusTakenAward</c> : 受取済み(チェックマーク)<br/>
        /// <c>AttendanceRewardStatusWaitTaken</c> : 達成済み(受取可)<br/>
        /// <c>AttendanceRewardStatusFinishedNonReward</c> : 達成済み(受取不可)<br/>
        /// <c>AttendanceRewardStatusUnfinished</c> : 未達成</para>
        /// </summary>
        public string status { get; set; } = string.Empty;
        /// <summary>
        /// <para>【冒険修練】</para>
        /// <para>進捗率</para>
        /// <para>最小値 : <c>0</c><br/>
        /// 最大値 : <c>2000</c></para>
        /// 備考 : 利用不可状態でも値は表示される。
        /// </summary>
        public int progress { get; set; } = 0;
    }

    public class DailyTask
    {
        /// <summary>
        /// <para>【デイリー任務】</para>
        /// <para>デイリー報酬獲得可能回数</para>
        /// </summary>
        public int total_num { get; set; }
        /// <summary>
        /// <para>【デイリー任務】</para>
        /// <para>デイリー報酬獲得済みの回数</para>
        /// </summary>
        public int finished_num { get; set; }
        /// <summary>
        /// <para>【デイリー任務】</para>
        /// <para>全任務達成時の追加報酬受取済であるか</para>
        /// </summary>
        public bool is_extra_task_reward_received { get; set; }
        /// <summary>
        /// <para>【デイリー任務】</para>
        /// <para>デイリー任務の達成状況</para>
        /// </summary>
        public List<TaskReward> task_rewards { get; set; } = new();
        /// <summary>
        /// <para>【デイリー任務】</para>
        /// <para>全任務達成時の報酬受取済であるか</para>
        /// </summary>
        public List<AttendanceReward> attendance_rewards { get; set; } = new();
        /// <summary>
        /// <para>【デイリー任務】</para>
        /// <para>冒険修練が解放済みかどうか</para>
        /// </summary>
        public bool attendance_visible { get; set; }
    }
}
