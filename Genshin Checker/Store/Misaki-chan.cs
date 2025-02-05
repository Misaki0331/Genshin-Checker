using Genshin_Checker.Core;
using Genshin_Checker.Core.General;
using Genshin_Checker.GUI.Window.PopupWindow;

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
                if (_character == null)
                {
                    Task.Run(async() => await GetCharacter());
                    return _character;
                }
                else return _character;
            }
            private set { _character = value; }
        }
        private Model.Misaki_chan.Character.Root? _character;

        public Model.Misaki_chan.info.Root? Info
        {
            get
            {
                if (_info == null)
                {
                    Task.Run(async() => await GetInfo());
                    return _info;
                }
                else return _info;
            }
            private set { _info = value; }
        }
        private Model.Misaki_chan.info.Root? _info;

        public Model.Misaki_chan.character_story.Root? CharacterStory
        {
            get
            {
                if (_characterStory == null)
                {
                    Task.Run(async() => await GetCharacterStory());
                    return _characterStory;
                }
                else return _characterStory;
            }
            private set { _characterStory = value; }
        }
        private Model.Misaki_chan.character_story.Root? _characterStory;

        async Task GetCharacter()
        {
            var json = await Core.WebRequest.GeneralGetRequest("https://static-api.misaki-chan.world/genshin-checker/app/characters.json");
            var character = JsonChecker<Model.Misaki_chan.Character.Root>.Check(json);
            if (character != null) _character = character;
        }

        async Task GetInfo()
        {
            var json = await Core.WebRequest.GeneralGetRequest("https://static-api.misaki-chan.world/genshin-checker/app/info.json");
            var info = JsonChecker<Model.Misaki_chan.info.Root>.Check(json);
            if (info != null) _info = info;
        }

        async Task GetCharacterStory()
        {
            var lang = LocalizeManager.CurrentShort;
            var json = await Core.WebRequest.GeneralGetRequest($"https://static-api.misaki-chan.world/genshin-checker/wiki/story/{lang}.json");
            var charastory = JsonChecker<Model.Misaki_chan.character_story.Root>.Check(json);
            if (charastory != null) _characterStory = charastory;
        }
        public async Task GetStoreData(bool IsReload = false)
        {
            FailReload.Stop();
            try
            {
                await Task.Run(() => { try
                    {
                        Task.WaitAll(
                    Task.Run(async () => { if (_info == null || IsReload) await GetInfo(); }),
                    Task.Run(async () => { if (_character == null || IsReload) await GetCharacter(); }),
                    Task.Run(async () => { if (_characterStory == null || IsReload) await GetCharacterStory(); })
                        );
                    }
                    catch (Exception ex) {
                        Log.Error(ex);
                    } });
            }
            catch (Exception ex)
            {
                if (!IsReload) FailReload.Start();
                Log.Error($"Download Failed! - Static Data (misaki-chan.world)\n{ex.GetType()} - {ex.Message}");
                Dialog.Error("Download Failed", $"Fail to load misaki-chan.world static data.\n{ex.GetType()}\n{ex.Message}");
            }
        }
        System.Windows.Forms.Timer FailReload;
    }
}
