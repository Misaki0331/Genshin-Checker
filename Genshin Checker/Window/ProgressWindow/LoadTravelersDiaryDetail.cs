using Genshin_Checker.App.HoYoLab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.Window.ProgressWindow
{
    public partial class LoadTravelersDiaryDetail : Form
    {
        Account account;
        List<int> month;
        Mode mode;
        public LoadTravelersDiaryDetail(Account account,Mode mode=Mode.All,List<int>? months=null )
        {
            InitializeComponent();
            this.account= account;
            this.mode = mode;
            months??=new List<int>() { 0 };
            this.month = months;
        }
        public enum Mode
        {
            Primogems,
            Mora,
            All
        }
        private void LoadTravelersDiaryDetail_Load(object sender, EventArgs e)
        {

        }

        private async void delay_Tick(object sender, EventArgs e)
        {
            delay.Stop();
            try
            {
                account.TravelersDiaryDetail.ProgressChanged += ProgressChanged;
                account.TravelersDiaryDetail.ProgressCompreted += ProgressCompreted;
                await account.TravelersDiaryDetail.Correct(month,(TravelersDiaryDetail.CorrectMode)mode);
            }catch(Exception ex)
            {
                new ErrorMessage("データベースからの取得に失敗しました。", $"{ex}").ShowDialog();
            }
            finally
            {
                account.TravelersDiaryDetail.ProgressChanged -= ProgressChanged;
                account.TravelersDiaryDetail.ProgressCompreted -= ProgressCompreted;
            }
            Done();

        }

        private void ProgressCompreted(object? sender, EventArgs e)
        {
            //account.TravelersDiaryDetail.ProgressChanged -= ProgressChanged;
            //account.TravelersDiaryDetail.ProgressCompreted -= ProgressCompreted;
        }

        private void ProgressChanged(object? sender, TravelersDiaryDetail.ProgressState e)
        {
            label1.Text = $"{(e.month==0?"今":$"{e.month}")}月分の{e.mode}の履歴を取得中... \n現在取得中のページ : {e.CurrentPage}ページ目\n累計取得ページ数 : {e.TotalPage}\n進捗率 : {e.Progress:0.0}%";
            int progress = (int)e.Progress;
            if(progress < 0) progress = 0;
            if (progress > 100) progress = 100;
            progressBar1.Value= progress;

        }
        bool IsEnded = false;
        void Done()
        {
            this.Invoke(() =>
            {
                IsEnded= true;
                Close();
            });
        }
        private void LoadTravelersDiaryDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!IsEnded)e.Cancel = true;
        }
    }
}
