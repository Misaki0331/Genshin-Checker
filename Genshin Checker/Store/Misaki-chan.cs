using Genshin_Checker.App.General;
using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Model.HoYoLab.Characters;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Window.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Store
{
    internal class Misaki_chan
    {
        static Misaki_chan? _instance = null;
        public static Misaki_chan Data { get => _instance ??= new Misaki_chan(); }
        private Misaki_chan()
        {
            FailReload = new()
            {
                Interval = 5000
            };
            FailReload.Tick += async (s, e) => await GetStoreData(false);
        }
        public Model.Misaki_chan.Character.Root? Characters
        {
            get
            {
                if (_character == null) return null;
                else return _character;
            }
            private set { _character = value; }
        }
        public Model.Misaki_chan.Character.Root? _character;
        

        async Task GetCharacter()
        {
            var json = await App.WebRequest.GeneralGetRequest("https://static-api.misaki-chan.world/genshin-checker/app/characters.json");
            var character = JsonChecker<Model.Misaki_chan.Character.Root>.Check(json);
            if (character != null) _character = character;
        }
        public async Task GetStoreData(bool IsReload = false)
        {
            FailReload.Stop();
            try
            {
                if (_character == null || IsReload) await GetCharacter();
            }
            catch (Exception ex)
            {
                if (!IsReload) FailReload.Start();
                new ErrorMessage("Download Failed", $"Fail to load misaki-chan.world static data.\n{ex.GetType()}\n{ex.Message}").Show();
            }
        }
        System.Windows.Forms.Timer FailReload;
    }
}
