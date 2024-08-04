using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.Window.Popup
{
    public partial class FatalError : Form
    {
        public FatalError(Exception ex)
        {
            InitializeComponent();
            textBox1.Lines = CrashLog(ex).Split('\n');
            label2.Text = ex.GetType().ToString();
            if (ex.GetType() == typeof(System.NullReferenceException)) label2.Text = "∧＿∧\r\n(　´∀｀)＜ぬるぽ";
            if (string.IsNullOrEmpty(crashreportpath)) button3.Enabled = false;
            TopMost = true;
            StartPosition = FormStartPosition.CenterScreen;
        }
        static string errormessage = "";
        public static string CrashLog(Exception ex)
        {
            if (!string.IsNullOrEmpty(crashreportpath)) return errormessage;
            StringBuilder ErrorMessage = new();
            string message = ex.Message;
            if (ex.GetType() == typeof(System.NullReferenceException)) message = "　　 （　・∀・）　　　|　|　ｶﾞｯ\r\n　　と　　　　）　 　 |　|\r\n　　　 Ｙ　/ノ　　　 人\r\n　　　　 /　）　 　 < 　>__Λ∩\r\n　　 ＿/し'　／／. Ｖ｀Д´）/ \r\n　　（＿フ彡　　　　　 　　/";
            ErrorMessage.Append($"【エラーの定義名】\n{ex.GetType()}\n\n");
            ErrorMessage.Append($"【エラーの内容】\n{message}\n\n");
            ErrorMessage.Append($"【ソース情報】\n{(ex.Source ?? "不明")}\n\n");
            ErrorMessage.Append($"【エラーの情報】\n{ex}\n\n");
            var name = System.Reflection.Assembly.GetExecutingAssembly().GetName();
            ErrorMessage.Append($"【バージョン】\n{name.Name} {name.Version}\n\n");
            crashreportpath = CrashReport(ErrorMessage.ToString());
            errormessage = ErrorMessage.ToString();
            return errormessage;
        }
        public static string GetCrashLogPath()
        {
            return crashreportpath;
        }
        static string SpecText = "";
        static string crashreportpath = "";
        static string GetString()
        {
            SpecText = "";
            ManagementClass mc = new("Win32_OperatingSystem");
            var moc = mc.GetInstances();
            int cnt = 1;
            foreach (var mo in moc)
            {
                SpecText += $"- OS情報 No.{cnt} -\n"
                    + $"エディション : {mo["Caption"]}\n"
                    + $"バージョン : {mo["Version"]}\n"
                    + $"ビルド番号 : {mo["BuildNumber"]}\n"
                    + $"空き物理メモリ : {Convert.ToInt32(mo["FreePhysicalMemory"]) / 1024.0:#,##0.00} MB / "
                    + $"{Convert.ToInt32(mo["TotalVisibleMemorySize"]) / 1024.0:#,##0.00} MB\n"
                    + $"空き仮想メモリ : {Convert.ToInt32(mo["FreeVirtualMemory"]) / 1024.0:#,##0.00} MB / "
                    + $"{Convert.ToInt32(mo["TotalVirtualMemorySize"]) / 1024.0:#,##0.00} MB\n\n";
                cnt++;
                mo.Dispose();
            }
            SpecText += "\n";

            mc = new("Win32_ComputerSystemProduct");
            moc = mc.GetInstances();
            cnt = 1;
            foreach (var mo in moc)
            {
                SpecText += $"- コンピュータ情報 No.{cnt} -\n"
                    + $"製造会社名 : {mo.Properties["Vendor"].Value}\n"
                    + $"モデル名 : {mo.Properties["Name"].Value}\n"
                    + $"モデルバージョン : {mo.Properties["Version"].Value}\n"
                    + $"PCの概要 : {mo.Properties["Caption"].Value}\n\n";
                cnt++;
                mo.Dispose();
            }
            SpecText += "\n";

            mc = new("CIM_System");
            moc = mc.GetInstances();
            cnt = 1;
            foreach (var mo in moc)
            {
                SpecText += $"- 利用者情報 No.{cnt} -\n"
                    + $"ドメイン : {mo.Properties["Domain"].Value}\n"
                    + $"PCの名称 : {mo.Properties["Vendor"].Value}\n"
                    + $"管理者 : {mo.Properties["PrimaryOwnerName"].Value}\n\n";
                mo.Dispose();
                cnt++;
            }
            SpecText += $"使用ユーザー : {Environment.UserName}\n\n";
            mc = new("Win32_Processor");
            moc = mc.GetInstances();
            cnt = 1;
            foreach (ManagementObject mo in moc.Cast<ManagementObject>())
            {
                SpecText += $"- CPU情報 No.{cnt} -\n"
                    + $"デバイスID : {mo["DeviceID"]}\n"
                    + $"CPU型番 : {mo["Name"]}\n"
                    + $"最大クロック周波数 : {mo["MaxClockSpeed"]} MHz\n"
                    + $"L2キャッシュサイズ : {mo["L2CacheSize"]} KB\n\n";
                cnt++;
            }
            return SpecText;
        }
        public static string CrashReport(string index)
        {
            try
            {
                GetString();
                var save = $"ErrorLog/{DateTime.Now:yyyyMMdd-HHmmssfff}.txt";
                var dir = Path.GetDirectoryName(save);
                if (!Directory.Exists(dir) && dir != null) Directory.CreateDirectory(dir);
                var Enc = Encoding.GetEncoding("UTF-8");
                var writer = new StreamWriter(save, true, Enc);
                var name = System.Reflection.Assembly.GetExecutingAssembly().GetName();
                writer.WriteLine($"{name.Name}はエラーが発生したため、動作を停止しました。");
                writer.WriteLine($"発生時刻 : {DateTime.Now}");
                writer.WriteLine($"----------エラーの内容----------");
                writer.WriteLine(index.Replace("\r", string.Empty).Replace("\n", Environment.NewLine));
                writer.WriteLine($"----------ユーザー環境----------");
                writer.WriteLine(GetString().Replace("\r", string.Empty).Replace("\n", Environment.NewLine));
                writer.WriteLine($"{name.Name}が起動された実行ファイル : {Environment.ProcessPath ?? "該当なし"}");
                writer.WriteLine($"{name.Name}の実行フォルダ : {Environment.CurrentDirectory}");
                writer.WriteLine($"{name.Name}のバージョン : {name.Version}");
                writer.WriteLine($"正規OSバージョン名 : {Environment.OSVersion}");
                writer.WriteLine($"ランタイムバージョン名 : {Environment.Version}");
                writer.WriteLine($"OS : {(Environment.Is64BitOperatingSystem ? "64ビット" : "32ビット")} プロセッサ : {(Environment.Is64BitProcess ? "64ビット" : "32ビット")}");
                writer.WriteLine($"システム起動時間 : {TimeSpan.FromMilliseconds(Environment.TickCount64)}");
                writer.Close();
                Log.Info(GetString());
                Log.Info($"クラッシュレポートは \"{save}\" に保存しました。");
                return Path.GetFullPath(save);
            }
            catch (Exception ex)
            {
                Log.Error("クラッシュレポートの保存に失敗しました。");
                Log.Error(ex);
                return String.Empty;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string cmd = "";
            string[] args = Environment.GetCommandLineArgs();
            for (int i = 1; i < args.Length; i++)
            {
                if (1 < i)
                {
                    cmd += " ";
                }
                cmd += "\"" + args[i] + "\"";
            }
            //新たにアプリケーションを起動する
            System.Diagnostics.Process.Start(Application.ExecutablePath, cmd);

            //現在のアプリケーションを終了する
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using var ps1 = new Process();
            ps1.StartInfo.UseShellExecute = true;
            ps1.StartInfo.FileName = crashreportpath;
            ps1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var link = "https://github.com/Misaki0331/Genshin-Checker/releases/latest";
            ProcessStartInfo pi = new ProcessStartInfo()
            {
                FileName = link,
                UseShellExecute = true,
            };
            if (link != null) Process.Start(pi);
        }
    }
}
