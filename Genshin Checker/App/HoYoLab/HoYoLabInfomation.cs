using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.HoYoLab
{
    public class HoYoLabInfomation
    {
        private Account account;

        public bool IsDisposed { get; private set; } = false;
        public void Dispose()
        {
            IsDisposed = true;
            ServerUpdate.Stop();
        }
        public HoYoLabInfomation(Account account)
        {
            this.account = account;
            ServerUpdate = new()
            {
                Interval = 10,
                Enabled = true,
            };
            ServerUpdate.Tick += ServerUpdate_Tick;
        }
        public Model.HoYoLab.MainMaterial.Root Data { get; private set; } = new();
        private async void ServerUpdate_Tick(object? sender, EventArgs e)
        {
            if (IsDisposed) return;
            ServerUpdate.Stop();

            if (!account.IsAuthed)
            {
                ServerUpdate.Interval = 1000;
                ServerUpdate.Start();
                return;
            }
            try
            {
                var json = await GetData();
                Data = new() { Data = json, Message = "OK" };

            }
            catch (Account.HoYoLabAPIException ex)
            {
                Data.Message = $"HoYoLab API Error\n{ex.Message}";
                Data.Retcode = ex.Retcode;
                Trace.WriteLine(Data.Message);
            }
            catch (Exception ex)
            {
                Data.Message = $"{ex.GetType()}\n{ex.Message}";
                Data.Retcode = ex.HResult;
                Trace.WriteLine(Data.Message);
            }

            ServerUpdate.Interval = 300000;
            ServerUpdate.Start();
        }


        public int uid { get => account.UID; }

        private readonly System.Windows.Forms.Timer ServerUpdate;

        private async Task<Model.HoYoLab.MainMaterial.Data> GetData()
        {
            return (await account.Endpoint.GetHoYoLabMaterial());
        }
        public CodeList GetCodeList()
        {
            var result = new CodeList();
            if (Data.Data == null) return result;
            foreach(var data in Data.Data.modules)
            {
                switch (data.module_type)
                {
                    case 7:
                        {
                            foreach (var code in data.exchange_group.bonuses)
                            {
                                var items = new List<CodeList.Item>();
                                foreach (var item in code.icon_bonuses)
                                {
                                    items.Add(new() { iconurl = item.icon_url, itemnum = item.bonus_num });
                                }
                                result.Codes.Add(new() { Code = code.exchange_code, ExpairUtc = new DateTime(1970, 1, 1).AddSeconds(code.offline_at), items = items });
                            }

                            var summaryitems = new List<CodeList.Item>();
                            foreach (var item in data.exchange_group.bonuses_summary.icon_bonuses)
                            {
                                summaryitems.Add(new() { iconurl = item.icon_url, itemnum = item.bonus_num });

                            }
                            result.SummaryItems= summaryitems;
                        }
                        break;
                }
            }
            return result;
        }
        public class CodeList
        {
            public List<Item> SummaryItems = new();
            public List<CodeData> Codes = new();
            public class CodeData
            {
                public string Code = "";
                public DateTime ExpairUtc = DateTime.MinValue;
                public List<Item> items = new();
            }

            public class Item
            {
                public string name = "";
                public string iconurl = "";
                public int itemnum = 0;
            }
        }

    }
}
