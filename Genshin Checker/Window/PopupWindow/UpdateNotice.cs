using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.Window.PopupWindow
{
    public partial class UpdateNotice : Form
    {
        public UpdateNotice()
        {
            InitializeComponent();
            pictureBox1.Image = resource.PaimonsPaint.Furina_3;
            Icon = Icon.FromHandle(new Bitmap(pictureBox1.Image).GetHicon());
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
            VersionText.Text = $"{App.General.AppUpdater.CurrentVersion} → {App.General.AppUpdater.NewVersion}";
            LatestUpdate.Text = $"Latest : {App.General.AppUpdater.LatestReleaseTime}";
            Body.Lines = App.General.AppUpdater.UpdateBody.Split("\n");
            DownloadSize.Text = $"{App.General.AppUpdater.ApplicationSize / 1024.0 / 1024.0:0.000} MB";
            DownloadCount.Text = $"{App.General.AppUpdater.DownloadCount:#,##0}";
        }
    }
}
