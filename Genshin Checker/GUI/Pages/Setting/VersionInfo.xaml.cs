﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Genshin_Checker.GUI.Pages.Setting
{
    /// <summary>
    /// General.xaml の相互作用ロジック
    /// </summary>
    public partial class VersionInfo : Page
    {
        public EventHandler<string>? ErrorHandle;
        public VersionInfo()
        {
            InitializeComponent();
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            ProcessStartInfo pi = new()
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true,
            };
            Process.Start(pi);
            e.Handled = true;
        }
    }
}
