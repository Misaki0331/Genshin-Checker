using Genshin_Checker.GUI.Window.PopupWindow;
using Genshin_Checker.Core.General;

namespace Genshin_Checker.Store
{
    internal class EnkaData
    {
        static EnkaData? _instance = null;
        public static EnkaData Data { get => _instance ??= new EnkaData(); }
        private EnkaData()
        {
            FailReload = new()
            {
                Interval = 5000
            };
            FailReload.Tick += async(s, e) => await GetStoreData(false);
        }
        public Dictionary<int, Model.EnkaNetwork.Store.Namecard.Icon>? Namecard { 
            get {
                if (_namecard == null) return null; 
                else return _namecard; 
            } 
            private set { _namecard = value; } 
        }
        private Dictionary<int, Model.EnkaNetwork.Store.Namecard.Icon>? _namecard;
        public Dictionary<string, Dictionary<string, string>>? Locale
        {
            get
            {
                if (_locale == null) return null; 
                else return _locale;
            }
            private set { _locale = value; }
        }

        private Dictionary<string, Dictionary<string, string>>? _locale;
        public Dictionary<string, Model.EnkaNetwork.Store.Characters.Data>? Characters
        {
            get
            {
                if (_characters == null)return null; 
                else return _characters;
            }
            private set { _characters = value; }
        }
        private Dictionary<string, Model.EnkaNetwork.Store.Characters.Data>? _characters;
        /*
        public Dictionary<int, Model.EnkaNetwork.Store.Costumes.Data>? Costumes
        {
            get
            {
                if (_costumes == null)
                { GetCostumes(); return null; }
                else return _costumes;
            }
            private set { _costumes = value; }
        }
        private Dictionary<int, Model.EnkaNetwork.Store.Costumes.Data>? _costumes;*/
        public Dictionary<int,Model.EnkaNetwork.Store.Affixes.Data>? Affixes
        {
            get
            {
                if (_affixes == null) return null; 
                else return _affixes;
            }
            private set { _affixes = value; }
        }
        private Dictionary<int, Model.EnkaNetwork.Store.Affixes.Data>? _affixes;

        public Dictionary<int, Model.EnkaNetwork.Store.Pfps.Data>? Pfps
        {
            get
            {
                if (_pfps == null)return null;
                else return _pfps;
            }
            private set { _pfps = value; }
        }
        private Dictionary<int, Model.EnkaNetwork.Store.Pfps.Data>? _pfps;


        async Task GetNameCard()
        {
            var json = await Core.WebRequest.GeneralGetRequest("https://api.enka.network/store/namecards.json");
            var namecard = JsonChecker<Dictionary<int, Model.EnkaNetwork.Store.Namecard.Icon>>.Check(json);
            if (namecard != null) Namecard = namecard;
        }
        async Task GetLocale()
        {
            var json = await Core.WebRequest.GeneralGetRequest("https://api.enka.network/store/loc.json");
            var locale = JsonChecker<Dictionary<string, Dictionary<string, string>>>.Check(json);
            if (locale != null) Locale = locale;
        }
        async Task GetCharacters()
        {
            var json = await Core.WebRequest.GeneralGetRequest("https://api.enka.network/store/characters.json");
            var characters = JsonChecker<Dictionary<string, Model.EnkaNetwork.Store.Characters.Data>>.Check(json);
            if (characters != null) Characters = characters;
        }
        async Task GetPfps()
        {
            var json = await Core.WebRequest.GeneralGetRequest("https://api.enka.network/store/pfps.json");
            var pfps = JsonChecker<Dictionary<int, Model.EnkaNetwork.Store.Pfps.Data>>.Check(json);
            if (pfps != null) Pfps = pfps;
        }
        /*
        async void GetCostumes()
        {
            var json = await Core.WebRequest.GeneralGetRequest("https://api.enka.network/store/costumes.json");
            var costumes = JsonChecker<Dictionary<int, Model.EnkaNetwork.Store.Costumes.Data>>.Check(json);
            if (costumes != null) Costumes = costumes;
        }*/
        async Task GetAffixes()
        {
            var json = await Core.WebRequest.GeneralGetRequest("https://api.enka.network/store/affixes.json");
            var affixes = JsonChecker<Dictionary<int, Model.EnkaNetwork.Store.Affixes.Data>>.Check(json);
            if (affixes != null) Affixes = affixes;
        }

        public async Task GetStoreData(bool IsReload=false)
        {
            FailReload.Stop();
            try
            {
                await Task.Run(() => {
                    try
                    {
                        Task.WaitAll(
                        Task.Run(async () => { if (_namecard == null || IsReload) await GetNameCard(); }),
                        Task.Run(async () => { if (_locale == null || IsReload) await GetLocale(); }),
                        Task.Run(async () => { if (_characters == null || IsReload) await GetCharacters(); }),
                        Task.Run(async () => { if (_affixes == null || IsReload) await GetAffixes(); }),
                        Task.Run(async () => { if (_pfps == null || IsReload) await GetPfps(); })
                        );
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                    }
                }
                );
            }
            catch (Exception ex)
            {
                if(!IsReload)FailReload.Start();
                Log.Error($"Download Failed! - Static Data (Enka.network)\n{ex.GetType()} - {ex.Message}");
                Dialog.Error("Download Failed", $"Fail to load Enka.network static data.\n{ex.GetType()}\n{ex.Message}");
            }
        }
        System.Windows.Forms.Timer FailReload;
        public class Convert
        {
            public class Namecard
            {
                public static string? GetNameCardURL(int id)
                {
                    try
                    {
                        if (Data.Namecard == null) return null;
                        var namecard = Data.Namecard[id];
                        if (namecard != null) return $"https://enka.network/ui/{namecard.icon}.png";
                        return null;

                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            public class AvaterIcon
            {
                public static string? GetIconURL(int id)
                {
                    try
                    {
                        if (Data.Pfps == null) return null;
                        var icon = Data.Pfps[id];
                        if (icon != null) return $"https://enka.network/ui/{icon.iconPath.Replace("_Circle","")}.png";
                        return null;

                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
    }
}
