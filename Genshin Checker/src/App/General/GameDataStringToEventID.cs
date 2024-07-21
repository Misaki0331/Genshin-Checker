namespace Genshin_Checker.App.General
{
    public static class GameDataStringToEventID
    {
        //ここには旅人手帳に記載されないであろう入手・消費経路の補完
        readonly static Dictionary<string, int> EventPairs = new()
        {
            {"Purchased Genesis Crystals",-1 }, //創生結晶の購入
            {"Purchased Blessing of the Welkin Moon",-2 }, //創生結晶の購入

            {"Exchanged Genesis Crystals for Primogems",-11 }, //創生結晶から原石へ変換
            {"Blessing of the Welkin Moon daily reward",-12 }, //空月の祝福の報酬
            {"BP reward",-13 }, //空月の祝福の報酬
            {"Shop purchase" ,-21 }, //ショップ購入・消費
            {"Purchased BP Level",-22 }, //紀行のレベル購入
            {"Other Primogem redemption",-99 }, //その他で原石使用(主に樹脂など)
            {"Item crafting material",-101 }, //その他で原石使用(主に樹脂など)
            {"Revitalized Petrified Tree (Domain)",-102 }, //秘境で入手
            {"Trounce Blossom challenge reward", -103 }, //週ボス
            {"Ley Line Blossom challenge reward", -104 }, //地脈
            {"Obtained from Wish",-1000 }, //祈願で入手
            {"Exchanged in the Shop",-201 }, //スターダスト・スターライト交換

        };

        public static int GetIDFromString(string en_name)
        {
            if (EventPairs.TryGetValue(en_name, out int id))
                return id;
            return int.MinValue;
        }
    }
}
