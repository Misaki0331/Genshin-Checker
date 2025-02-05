using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Genshin_Checker.GUI.Window.PopupWindow
{
    /// <summary>
    /// UpdateNotice.xaml の相互作用ロジック
    /// </summary>
    public partial class UpdateNotice : System.Windows.Window
    {
        public UpdateNotice()
        {
            InitializeComponent();
        }

        private void CloseLink_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenLink_Click(object sender, EventArgs e)
        {
            var link = "https://github.com/Misaki0331/Genshin-Checker/releases/latest";
            ProcessStartInfo pi = new ProcessStartInfo()
            {
                FileName = link,
                UseShellExecute = true,
            };
            if (link != null) Process.Start(pi);
        }

        private void UpdateNotice_Load(object sender, EventArgs e)
        {
            VersionText.Text = $"{Core.General.AppUpdater.CurrentVersion} → {Core.General.AppUpdater.NewVersion}";
            LatestUpdate.Text = $"Latest : {Core.General.AppUpdater.LatestReleaseTime.ToLocalTime()}";
            Body.Text = Core.General.AppUpdater.UpdateBody;
            DownloadSize.Text = $"{Core.General.AppUpdater.ApplicationSize / 1024.0 / 1024.0:0.000} MB";
            DownloadCount.Text = $"{Core.General.AppUpdater.DownloadCount:#,##0}";
        }
    }
}
