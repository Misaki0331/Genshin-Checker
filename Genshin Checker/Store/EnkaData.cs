using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Genshin_Checker.Model.EnkaNetwork.Store;
using Genshin_Checker.Window;
using Microsoft.VisualBasic;
using Genshin_Checker.Window.Popup;
using Genshin_Checker.App.General;

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
            FailReload.Tick += (s, e) => GetStoreData(false);
        }
        public Dictionary<int, Model.EnkaNetwork.Store.Namecard.Icon>? Namecard { 
            get {
                if (_namecard == null)
                { GetNameCard(); return null; }
                else return _namecard; 
            } 
            private set { _namecard = value; } 
        }
        private Dictionary<int, Model.EnkaNetwork.Store.Namecard.Icon>? _namecard;
        public Dictionary<string, Dictionary<string, string>>? Locale
        {
            get
            {
                if (_locale == null)
                { GetLocale(); return null; }
                else return _locale;
            }
            private set { _locale = value; }
        }

        private Dictionary<string, Dictionary<string, string>>? _locale;
        public Dictionary<string, Model.EnkaNetwork.Store.Characters.Data>? Characters
        {
            get
            {
                if (_characters == null)
                { GetCharacters(); return null; }
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
                if (_affixes == null)
                { GetAffixes(); return null; }
                else return _affixes;
            }
            private set { _affixes = value; }
        }
        private Dictionary<int, Model.EnkaNetwork.Store.Affixes.Data>? _affixes;

        public Dictionary<int, Model.EnkaNetwork.Store.Pfps.Data>? Pfps
        {
            get
            {
                if (_affixes == null)
                { GetPfps(); return null; }
                else return _pfps;
            }
            private set { _pfps = value; }
        }
        private Dictionary<int, Model.EnkaNetwork.Store.Pfps.Data>? _pfps;


        async void GetNameCard()
        {
            var json = await App.WebRequest.GeneralGetRequest("https://api.enka.network/store/namecards.json");
            var namecard = JsonChecker<Dictionary<int, Model.EnkaNetwork.Store.Namecard.Icon>>.Check(json);
            if (namecard != null) Namecard = namecard;
        }
        async void GetLocale()
        {
            var json = await App.WebRequest.GeneralGetRequest("https://api.enka.network/store/loc.json");
            var locale = JsonChecker<Dictionary<string, Dictionary<string, string>>>.Check(json);
            if (locale != null) Locale = locale;
        }
        async void GetCharacters()
        {
            var json = await App.WebRequest.GeneralGetRequest("https://api.enka.network/store/characters.json");
            var characters = JsonChecker<Dictionary<string, Model.EnkaNetwork.Store.Characters.Data>>.Check(json);
            if (characters != null) Characters = characters;
        }
        async void GetPfps()
        {
            var json = await App.WebRequest.GeneralGetRequest("https://api.enka.network/store/pfps.json");
            var pfps = JsonChecker<Dictionary<int, Model.EnkaNetwork.Store.Pfps.Data>>.Check(json);
            if (pfps != null) Pfps = pfps;
        }
        /*
        async void GetCostumes()
        {
            var json = await App.WebRequest.GeneralGetRequest("https://api.enka.network/store/costumes.json");
            var costumes = JsonChecker<Dictionary<int, Model.EnkaNetwork.Store.Costumes.Data>>.Check(json);
            if (costumes != null) Costumes = costumes;
        }*/
        async void GetAffixes()
        {
            var json = await App.WebRequest.GeneralGetRequest("https://api.enka.network/store/affixes.json");
            var affixes = JsonChecker<Dictionary<int, Model.EnkaNetwork.Store.Affixes.Data>>.Check(json);
            if (affixes != null) Affixes = affixes;
        }

        public void GetStoreData(bool IsReload=false)
        {
            FailReload.Stop();
            try
            {
                if (_namecard == null || IsReload) GetNameCard();
                if (_locale == null || IsReload) GetLocale();
                if (_characters == null || IsReload) GetCharacters();
                //if (_costumes == null || IsReload) GetCostumes();
                if (_affixes == null || IsReload) GetAffixes();
                if (_pfps == null || IsReload) GetPfps();
            }
            catch (Exception ex)
            {
                if(!IsReload)FailReload.Start();
                new ErrorMessage("Download Failed", $"Fail to load Enka.network static data.\n{ex.GetType()}\n{ex.Message}").Show();
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
