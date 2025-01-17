namespace Genshin_Checker.Core.HoYoLab
{
    public class Characters : Base
    {
        public Characters(Account account) : base(account, 300000)
        {
            ServerUpdate.Elapsed += Timeout_Tick;
        }
        private Model.HoYoLab.Characters.Data? CharacterData = null;
        private void Timeout_Tick(object? sender, EventArgs e)
        {
            ServerUpdate.Stop();
        }
        public async Task<Model.HoYoLab.Characters.Data> GetData()
        {
            if (CharacterData == null || !ServerUpdate.Enabled)
            {
                var data = await account.Endpoint.GetCharacters();
                CharacterData= data;
                ServerUpdate.Start();
                return data;
            }
            else
            {
                return CharacterData;
            }
        }
    }
}
