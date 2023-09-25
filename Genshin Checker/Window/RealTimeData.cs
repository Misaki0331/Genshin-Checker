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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Genshin_Checker.Window
{
    public partial class RealTimeData : Form
    {
        public RealTimeData()
        {
            InitializeComponent();
            ServerUpdate.Interval = 1;
        }
        App.Store.RealTimeNote.Root Note = new();
        Stopwatch LatestUpdate= new();
        int UpdateTemp = 0;
        private async void ServerUpdate_Tick(object sender, EventArgs e)
        {
            ServerUpdate.Enabled = false;
            try
            {
                Note = await App.RealTimeNote.getNote();
                LatestUpdate.Restart();

                if (int.TryParse(Note.data.resin_recovery_time, out int time))
                    UpdateTemp = time / 60;
                else UpdateTemp = 0;

                if (UpdateTemp <= 0)
                {
                    ServerUpdate.Enabled = true;
                    ServerUpdate.Interval = 60000;
                }
                else
                {
                    ServerUpdate.Interval = 1;
                }
                Trace.WriteLine($"API - {Note.message}");
            }
            catch (Exception ex)
            {
                Note.retcode = ex.HResult;
                Note.message = $"{ex.GetType()}\n{ex.Message}";
            }

        }

        private void UiUpdate_Tick(object sender, EventArgs e)
        {
            if (Note.message == "OK")
            {
                panel_main.Visible = true;
                panel_Error.Visible = false;
                label1.Text = Note.data.current_resin.ToString();
                label2.Text = $"/{Note.data.max_resin}";
                if (int.TryParse(Note.data.resin_recovery_time, out int time))
                {
                    time -= (int)LatestUpdate.Elapsed.TotalSeconds;
                    if (time <= 0)
                    {
                        label3.Text = "最大まで回復済";
                    }
                    else
                    {
                        label3.Text = $"残り {(time / 3600)}:{(time / 60 % 60):00}:{(time % 60):00}";
                    }
                }
                else
                {
                    label3.Text = $"{Note.data.resin_recovery_time}";
                }
                //label7.Text = $"{Note.data.current_home_coin}";
                if (time / 60 != UpdateTemp)
                {
                    UpdateTemp = time / 60;
                    ServerUpdate.Enabled = true;
                }
                if (Note.data.is_extra_task_reward_received)
                {
                    label4.Text = $"達成済み";
                }else
                if (Note.data.total_task_num == Note.data.finished_task_num)
                {
                    label4.Text = $"報酬未受取";
                }
                else
                {
                    label4.Text = $"{Note.data.finished_task_num}/{Note.data.total_task_num}";
                }

                label5.Text = $"{Note.data.current_home_coin}";
                label6.Text = $"/{Note.data.max_home_coin}";
                if (int.TryParse(Note.data.home_coin_recovery_time, out time))
                {
                    time -= (int)LatestUpdate.Elapsed.TotalSeconds;
                    if (time <= 0)
                    {
                        label7.Text = "最大まで回復済";
                    }
                    else
                    {
                        label7.Text = $"残り {(time / 3600)}:{(time / 60 % 60):00}:{(time % 60):00}";
                    }
                }
                label8.Text = $"残り {Note.data.remain_resin_discount_num} 回 / {Note.data.resin_discount_num_limit} 回";

                var transformer = Note.data.transformer.recovery_time;
                time = transformer.Hour*3600+transformer.Minute*60+transformer.Second;
                time -= (int)LatestUpdate.Elapsed.TotalSeconds;
                if (time < 0||transformer.reached)
                {
                    label9.Text = "利用可能";
                }
                else
                {
                    label9.Text = $"残り {(time / 3600)}:{(time / 60 % 60):00}:{(time % 60):00}";
                }
                label_expendition_num.Text = $"{Note.data.current_expedition_num} / {Note.data.max_expedition_num}";
                var ex_panel = new List<Panel>() { panel_expendition_1, panel_expendition_2, panel_expendition_3, panel_expendition_4, panel_expendition_5 };
                var ex_icon = new List<PictureBox>() { icon_expendition_1, icon_expendition_2, icon_expendition_3, icon_expendition_4, icon_expendition_5 };
                var ex_label = new List<Label>() { label_expendition_1, label_expendition_2, label_expendition_3, label_expendition_4, label_expendition_5 };
                for (int i = 0; i < 5; i++)
                {
                    if (Note.data.expeditions.Count > i)
                    {
                        var expedition = new App.Store.RealTimeNote.Expedition()
                        {
                            remained_time = Note.data.expeditions[i].remained_time,
                            status = Note.data.expeditions[i].status,
                            avatar_side_icon = Note.data.expeditions[i].avatar_side_icon
                        };
                        ex_panel[i].Visible = true;
                        if (expedition.avatar_side_icon != ex_icon[i].Name) ex_icon[i].Load(expedition.avatar_side_icon);
                        ex_icon[i].Name = expedition.avatar_side_icon;
                        if (int.TryParse(expedition.remained_time, out time))
                        {
                            time -= (int)LatestUpdate.Elapsed.TotalSeconds;
                            if (time <= 0)
                            {
                                ex_label[i].Text = "探索完了";
                            }
                            else
                            {
                                ex_label[i].Text = $"{(time / 3600)}:{(time / 60 % 60):00}:{(time % 60):00}";
                            }
                        }
                    }
                    else
                    {
                        ex_panel[i].Visible = false;
                    }
                }
            }
            else
            {

                panel_main.Visible = false;
                panel_Error.Visible = true;
                if (Note.retcode != 0)
                {
                    label10.Text = "エラーが発生しました。";
                    label_ErrorMessage.Text = $"エラーコード : {Note.retcode}\n{Note.message}";
                }
                else
                {
                    label10.Text = "データを取得中です...";
                    label_ErrorMessage.Text = "";
                }
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Auth_Click(object sender, EventArgs e)
        {
            var browser = new BrowserApp.BattleAuth();
            browser.ShowDialog(this);
            ServerUpdate.Stop();
            ServerUpdate.Interval = 1;
            ServerUpdate.Start();
        }
    }
}
