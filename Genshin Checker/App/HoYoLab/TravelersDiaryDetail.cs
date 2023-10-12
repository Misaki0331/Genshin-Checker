using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.HoYoLab
{
    public class TravelersDiaryDetail : Base
    {
        public class ProgressState
        {
            internal ProgressState(int cp, int tp, int cpr, int tpr, double progress = double.NaN)
            {
                if (double.IsNaN(progress)) progress = cpr / tpr;
                CurrentPage = cp;
                TotalPage = tp;
                CurrentProcess = cpr;
                TotalProcess = tpr;
            }
            public readonly double Progress;
            public readonly int CurrentPage;
            public readonly int TotalPage;
            public readonly int CurrentProcess;
            public readonly int TotalProcess;
        }
        public class ProgressReport
        {
            public event EventHandler<ProgressChangedEventArgs>? ProgressChanged;

            public void Report(int percentComplete)
            {
                ProgressChanged?.Invoke(this, new ProgressChangedEventArgs(percentComplete, null));
            }
        }
        public enum CorrectMode
        {
            Primogems,
            Mora,
            All
        }
        public async Task MyAsyncMethod(IProgress<ProgressState> progress,List<int> months,CorrectMode mode=CorrectMode.All)
        {
            int totalcount = 1;
            int searchcount = 1;
            foreach (var month in months)
            {
                if (mode == CorrectMode.All || mode == CorrectMode.Primogems)
                {
                    var data = await account.GetTravelersDiaryDetail(1, 1, month);
                    if (data.List.Count != 0)
                    {
                        var date = DateTime.Parse(data.List[0].Time);
                        var days = Registry.GetValue("HistoryPrimogems", $"UserData/{uid}/Date/{date.Year}/{date.Month:00}/{date.Day:00}", true);
                        for (int i = 2; i < 10000; i++)
                        {
                            progress.Report(new(totalcount, searchcount, 0, 0));
                            totalcount++;

                        }
                    }
                }
            }
        }
        public TravelersDiaryDetail(Account account) : base(account, 300000)
        {
            ServerUpdate.Tick += ServerUpdate_Tick;
        }

        private void ServerUpdate_Tick(object? sender, EventArgs e)
        {
            ServerUpdate.Stop();





            ServerUpdate.Start();
        }

    }
}
