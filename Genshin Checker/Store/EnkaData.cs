using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Genshin_Checker.Model.EnkaNetwork.Store;

namespace Genshin_Checker.Store
{
    internal class EnkaData
    {
        static EnkaData? _instance = null;
        public static EnkaData Data { get => _instance ??= new EnkaData(); }
        private EnkaData()
        {
            Namecard = new();
            Locale = new();
            Characters = new();
            Costumes = new();
            Affixes = new();

        }
        public Dictionary<int,Model.EnkaNetwork.Store.Namecard.Icon> Namecard { get; private set; }
        public Dictionary<string, Dictionary<string, string>> Locale { get; private set; }
        public Dictionary<string, Model.EnkaNetwork.Store.Characters.Data> Characters { get; private set; }
        public Dictionary<int, Model.EnkaNetwork.Store.Costumes.Data> Costumes { get; private set; }
        public Dictionary<int,Model.EnkaNetwork.Store.Affixes.Data> Affixes { get; private set; }
        public async void GetStoreData()
        {
            var json = await App.WebRequest.GeneralGetRequest("https://raw.githubusercontent.com/EnkaNetwork/API-docs/master/store/namecards.json");
            var namecard = JsonConvert.DeserializeObject<Dictionary<int,Model.EnkaNetwork.Store.Namecard.Icon>>(json);
            if (namecard != null) Namecard = namecard;
            else throw new ArgumentNullException(nameof(namecard));
            json = await App.WebRequest.GeneralGetRequest("https://raw.githubusercontent.com/EnkaNetwork/API-docs/master/store/loc.json");
            var locale = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
            if (locale != null) Locale = locale;
            else throw new ArgumentNullException(nameof(locale));
            json = await App.WebRequest.GeneralGetRequest("https://raw.githubusercontent.com/EnkaNetwork/API-docs/master/store/characters.json");
            var characters = JsonConvert.DeserializeObject<Dictionary<string, Model.EnkaNetwork.Store.Characters.Data>>(json);
            if (characters != null) Characters = characters;
            else throw new ArgumentNullException(nameof(characters));
            json = await App.WebRequest.GeneralGetRequest("https://raw.githubusercontent.com/EnkaNetwork/API-docs/master/store/costumes.json");
            var costumes = JsonConvert.DeserializeObject<Dictionary<int,Model.EnkaNetwork.Store.Costumes.Data>>(json);
            if (costumes != null) Costumes = costumes;
            else throw new ArgumentNullException(nameof(costumes));
            json = await App.WebRequest.GeneralGetRequest("https://raw.githubusercontent.com/EnkaNetwork/API-docs/master/store/affixes.json");
            var affixes = JsonConvert.DeserializeObject<Dictionary<int, Model.EnkaNetwork.Store.Affixes.Data>>(json);
            if (affixes != null) Affixes = affixes;
            else throw new ArgumentNullException(nameof(affixes));

        }
        public class Convert
        {
            public class Namecard
            {
                public static string? GetNameCardURL(int id)
                {
                    try
                    {
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
        }
    }
}
