namespace Genshin_Checker.App.HoYoLab
{
    public class LoginBonus:Base
    {
        public LoginBonus(Account account) : base(account, 1000)
        {
            ServerUpdate.Elapsed += ServerUpdate_Tick;
        }
        //ToDo: ログボ処理を書く
        private void ServerUpdate_Tick(object? sender, EventArgs e)
        {
        }

        public async Task<bool> ExecuteLogin()
        {
            var data = await account.Endpoint.LoginBonusSignIn();
            if (data.code == "ok") return true;
            return false;
        }
    }
}
