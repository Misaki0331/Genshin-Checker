using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using LiveChartsCore.Kernel.Sketches;
using System.Globalization;
using Genshin_Checker.App.HoYoLab;
using System.Diagnostics;

namespace Genshin_Checker.Window
{
    public partial class TravelersDiary : Form
    {
        Account account;
        List<int> month_index= new();


        private readonly PieChart PrimogemsType;

        System.Drawing.Text.PrivateFontCollection pfc = new();
        public TravelersDiary(Account account)
        {
            InitializeComponent();
            this.account = account;
            this.Text = $"旅人手帳 (UID:{account.UID})";
            PrimogemsType = new PieChart
            {
                Font = new Font("MS Gothic UI", 12, FontStyle.Regular),
                Dock = DockStyle.Fill,
                Size = new(tabPage2.Width, tabPage2.Height),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                InitialRotation = -90,
                Series = new List<ISeries>
                {
                },
            };
            try
            {
                //resource内のフォントの呼び出し
                byte[] fontBuf = resource.font.DSEG7Classic_BoldItalic;
                IntPtr fontBufPtr = Marshal.AllocCoTaskMem(fontBuf.Length);
                Marshal.Copy(fontBuf, 0, fontBufPtr, fontBuf.Length);
                pfc.AddMemoryFont(fontBufPtr, fontBuf.Length);
                Marshal.FreeCoTaskMem(fontBufPtr);
                Today_Primogem.Font = new(pfc.Families[0], 32, FontStyle.Bold | FontStyle.Italic);
                Today_Mora.Font = new(pfc.Families[0], 32, FontStyle.Bold | FontStyle.Italic);
                Month_Primogem.Font = new(pfc.Families[0], 32, FontStyle.Bold | FontStyle.Italic);
                Month_Mora.Font = new(pfc.Families[0], 32, FontStyle.Bold | FontStyle.Italic);
                Icon = Icon.FromHandle(resource.icon.Icon_TravelerDirty.GetHicon());
                if (account.TravelersDiary.Data.Data != null)
                {

                    foreach (int i in account.TravelersDiary.Data.Data.optional_month)
                    {
                        month_index.Add(i);
                        comboBox1.Items.Add($"{i} 月");
                    }

                    comboBox1.SelectedIndex =
                        comboBox1.Items.Count - 1;
                }
                tabPage2.SuspendLayout();
                tabPage2.Controls.Add(PrimogemsType);
                tabPage2.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                var n = new ErrorMessage(ex.GetType().ToString(), ex.Message);
                n.ShowDialog(this);
                Close();
            }
            UIUpdate_Tick(new object(),EventArgs.Empty);
        }

        private void UIUpdate_Tick(object sender, EventArgs e)
        {
            if (account.IsDisposed) Close();
            if (account.TravelersDiary.Data.Data == null)
            {

            }
            else
            {
                var data = account.TravelersDiary.Data.Data;
                Today_Primogem.Text = $"{data.day_data.current_primogems}";
                Today_Mora.Text = $"{data.day_data.current_mora}";
            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled= false;
            try
            {
                //グラフ内は文字化けしているのでus-enにしておく
                var data = await account.GetTravelersDiaryInfo(month_index[comboBox1.SelectedIndex],new("us-en"));
                Month_Primogem.Text = $"{data.month_data.current_primogems}";
                Month_Mora.Text = $"{data.month_data.current_mora}";
                Month_Primogem.Text = $"{data.month_data.current_primogems}";
                Month_Mora.Text = $"{data.month_data.current_mora}";
                var primodiff = data.month_data.current_primogems - data.month_data.last_primogems;
                var moradiff = data.month_data.current_mora - data.month_data.last_mora;
                if (primodiff > 0) Month_Primogem_Diff.ForeColor = Color.LimeGreen;
                else if (primodiff < 0) Month_Primogem_Diff.ForeColor = Color.Red;
                else Month_Primogem_Diff.ForeColor = Color.White;
                Month_Primogem_Diff.Text = $"{(primodiff > 0 ? "+" : "")}{primodiff.ToString("#,##0")}";
                if (moradiff > 0) Month_Mora_Diff.ForeColor = Color.LimeGreen;
                else if (moradiff < 0) Month_Mora_Diff.ForeColor = Color.Red;
                else Month_Mora_Diff.ForeColor = Color.White;
                Month_Mora_Diff.Text = $"{(moradiff > 0 ? "+" : "")}{moradiff.ToString("#,##0")}";
                var Series = new List<ISeries>();
                foreach (var a in data.month_data.group_by)
                {
                    if(a.num!=0)Series.Add(new PieSeries<double> { Values = new List<double>() { a.num }, Name = $"{a.action} ({a.percent}%)",  });
                }
                PrimogemsType.Series = Series;

            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex);
            }
            comboBox1.Enabled= true;
        }
    }
}
