using ComponentFactory.Krypton.Toolkit;
using Nevron.Nov.Graphics;
using Nevron.Nov.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Upgrade.Classes.Blocks;
using Upgrade.Forms;

namespace Upgrade.Classes
{
    public partial class MainWorkingForm : Form
    {

        [DllImport("Gdi32.dll")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect,
                                                       int nTopRect,
                                                       int nRightRect,
                                                       int nBottomRect,
                                                       int nWidthEllipse,
                                                       int nHeightEllipse);
        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        UIComboBox[] uiComboBox = new UIComboBox[2];
        Filter filter;
        private static List<int> idFailedTasks = new List<int>();
        System.Windows.Forms.Timer timerTime;

        public MainWorkingForm()
        {
            InitializeComponent();
            this.Load += MainWorkingForm_Load;
            this.BackColor = Design.backColor;
            hide_border_tabs.BackColor = Design.backColor;
        }

        private void TimerTime_Tick(object sender, EventArgs e) 
        {
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;

            string hours_minutes = "", seconds = "";

            if (h < 10)
            {
                hours_minutes += "0" + h;
            }
            else
            {
                hours_minutes += h;
            }

            hours_minutes += ":";

            if (m < 10)
            {
                hours_minutes += "0" + m;
            }
            else
            {
                hours_minutes += m;
            }

            hours_minutes += ":";

            if (s < 10)
            {
                seconds += "0" + s;
            }
            else
            {
                seconds += s;
            }
            if (s == 30)
            {
                InstallFailedTask();
            }

            label_time.Text = hours_minutes;
            label_seconds.Text = seconds;
        }

        private void MainWorkingForm_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(-1, -1, 1366, 768, 78, 78);
            SetWindowRgn(this.Handle, hRgn, true);

            WindowManager.SetFlowPanelTask(flowTasks, flowNotes, flowDirect, flowTarget, flowTaskTarget);

            // создание компонентов главного пункта меню
            SetTabProfile();

            // создание компонентов пункта меню с направлениями и целями
            SetTabDirection_Target();

            timerTime = new System.Windows.Forms.Timer();
            timerTime.Interval = 1000;
            timerTime.Tick += TimerTime_Tick;
            timerTime.Start();

            // установка и запуск таймера в новом потоке 
            TimerCallback funcCallback = new TimerCallback(Callback);
            System.Threading.Timer timer = new System.Threading.Timer(funcCallback, 0, 0, 60000);  // 1 минута
        }

        private async void SetTabProfile() 
        {
            string[] labelsPeriod = { "Прошлая неделя",
                                      "Вчера",
                                      "Сегодня",
                                      "Завтра",
                                      "Текущая неделя"};

            string[] labelsStatus = { "Все задачи",
                                      "Выполненные",
                                      "Невыполненные"};

            GlobalComponents.notFoundTask = not_found_task;
            GlobalComponents.notFoundNote = not_found_note;

            uiComboBox[1] = new UIComboBox(tab_profile, panel_period, "status", labelsStatus, null, null, panel_filter);
            uiComboBox[0] = new UIComboBox(tab_profile, panel_status_task, "period", labelsPeriod, label_today, uiComboBox[1].GetPanel(), panel_filter);

            await WindowManager.SetPanelsMainWindow();
            GlobalComponents.labelPeriod = sublabel_week_stat;
            WeeklyStatistic.SetStatistic(tab_profile, panel_week_stat, performLastWeek, performCurrentWeek, faceIndicator);

            Design.SetMarkCurrentDay(day_mark);
            GlobalData.scroller_task = new Scroller(tab_profile, flowTasks, Design.heightContentTasks);
            GlobalData.scroller_note = new Scroller(tab_profile, flowNotes, Design.heightContentNotes);
            filter = new Filter(tab_profile, panel_filter);
        }

        private async void SetTabDirection_Target()
        {
            GlobalComponents.labelDirect = label_name_direct;
            GlobalComponents.labelTarget = label_name_target;
            GlobalComponents.notFoundTarget = not_found_target;
            GlobalComponents.notFoundTaskTarget = not_found_task_target;
            GlobalComponents.status_mark = status_mark;

            await WindowManager.SetDirectBlock();
            GlobalData.scroller_direct = new Scroller(tab_targets, flowDirect, Design.heightContentDirection);
            GlobalData.scroller_target = new Scroller(tab_targets, flowTarget, Design.heightContentTarget);
            GlobalData.scroller_task_target = new Scroller(tab_targets, flowTaskTarget, Design.heightContentTaskTarget);
        }

        private void profile_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 100);
            tabs.SelectedTab = tab_profile;
            active_item.Image = Properties.Resources.profile;
        }

        private void targets_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 160);
            tabs.SelectedTab = tab_targets;
            active_item.Image = Properties.Resources.tardets;
        }

        private void stat_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 220);
            tabs.SelectedTab = tab_stat;
            active_item.Image = Properties.Resources.stat;
        }

        private void schedule_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 280);
            tabs.SelectedTab = tab_sched;
            active_item.Image = Properties.Resources.schedule;
        }

        private void settings_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 340);
            tabs.SelectedTab = tab_sett;
            active_item.Image = Properties.Resources.settings;
        }

        private void flowTasks_ControlRemoved(object sender, ControlEventArgs e)
        {
            GlobalData.scroller_task.Refresh(Design.heightContentTasks);
        }

        private void exit_from_profile_MouseHover(object sender, EventArgs e)
        {
            exit_from_profile.ForeColor = Design.mainColor;
        }

        private void exit_from_profile_MouseLeave(object sender, EventArgs e)
        {
            exit_from_profile.ForeColor = Color.DimGray;
        }

        private void label_my_passwords_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 280);
            tabs.SelectedTab = tab_sched;
            active_item.Image = Properties.Resources.schedule;
        }

        private void flowNotes_ControlRemoved(object sender, ControlEventArgs e)
        {
            GlobalData.scroller_note.Refresh(Design.heightContentNotes);
        }

        private void addTask_Click(object sender, EventArgs e)
        {
            if (GlobalData.addTaskForm == null)
            {
                GlobalData.addTaskForm = new AddTaskForm();
                GlobalData.addTaskForm.ShowDialog();
            }
            else
            {
                GlobalData.addTaskForm.ShowDialog();
            }
        }

        private void exit_from_profile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из аккаунта?",
                               "Сообщение",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                INIManager.WriteString("Settings", "remember_me", "off");
                GlobalData.reg_authForm.Show();
            }
        }

        private void MainWorkingForm_Shown(object sender, EventArgs e)
        {
            panel_menu.BackColor = Design.mainColor;

            tab_profile.BackColor = Design.backColor;
            tab_targets.BackColor = Design.backColor;
            tab_stat.BackColor = Design.backColor;
            tab_sched.BackColor = Design.backColor;
            tab_sett.BackColor = Design.backColor;

            label_today.ForeColor = Design.mainColor;
            sublabel_note.ForeColor = Design.mainColor;
            sublabel_week_stat.ForeColor = Design.mainColor;
            sublabel_direct.ForeColor = Design.mainColor;
            label_name_direct.ForeColor = Design.mainColor;
            label_name_target.ForeColor = Design.mainColor;

            exit_from_profile.BackColor = Color.FromArgb(234, 235, 240);

            day_mark.Inactive1 = Design.mainColor;
            day_mark.Inactive2 = Design.mainColor;
            day_mark.Active1 = Design.mainColor;
            day_mark.Active2 = Design.mainColor;
            day_mark.StrokeColor = Design.mainColor;

            status_mark.Inactive1 = Design.mainColor;
            status_mark.Inactive2 = Design.mainColor;
            status_mark.Active1 = Design.mainColor;
            status_mark.Active2 = Design.mainColor;
            status_mark.StrokeColor = Design.mainColor;

            not_found_note.BringToFront();
            not_found_target.BringToFront();
            not_found_task.BringToFront();
            not_found_task_target.BringToFront();

            calendar.BringToFront();
            calendar.StateCheckedNormal.Day.Back.Color1 = Color.FromArgb(
                                                                    Design.mainColorOpacity.A + 40,
                                                                    Design.mainColorOpacity.R,
                                                                    Design.mainColorOpacity.G,
                                                                    Design.mainColorOpacity.B);
            calendar.StateCheckedNormal.Day.Back.Color2 = Color.FromArgb(
                                                                    Design.mainColorOpacity.A + 40,
                                                                    Design.mainColorOpacity.R,
                                                                    Design.mainColorOpacity.G,
                                                                    Design.mainColorOpacity.B);
            calendar.StateCheckedNormal.Day.Border.Color1 = Color.FromArgb(
                                                                    Design.mainColorOpacity.R - 5,
                                                                    Design.mainColorOpacity.G - 5,
                                                                    Design.mainColorOpacity.B - 5);
            calendar.StateCheckedNormal.Day.Border.Color2 = Color.FromArgb(
                                                                    Design.mainColorOpacity.R - 5,
                                                                    Design.mainColorOpacity.G - 5,
                                                                    Design.mainColorOpacity.B - 5);

            calendar.StateCheckedTracking.Day.Border.Width = 1;
            calendar.StateCheckedTracking.Day.Back.Color1 = Color.FromArgb(
                                                                    Design.mainColorOpacity.A + 40,
                                                                    Design.mainColorOpacity.R,
                                                                    Design.mainColorOpacity.G,
                                                                    Design.mainColorOpacity.B);
            calendar.StateCheckedTracking.Day.Back.Color2 = Color.FromArgb(
                                                                    Design.mainColorOpacity.A + 40,
                                                                    Design.mainColorOpacity.R,
                                                                    Design.mainColorOpacity.G,
                                                                    Design.mainColorOpacity.B);
            calendar.StateCheckedTracking.Day.Border.Color1 = Color.FromArgb(
                                                                    Design.mainColorOpacity.R - 5,
                                                                    Design.mainColorOpacity.G - 5,
                                                                    Design.mainColorOpacity.B - 5);
            calendar.StateCheckedTracking.Day.Border.Color2 = Color.FromArgb(
                                                                    Design.mainColorOpacity.R - 5,
                                                                    Design.mainColorOpacity.G - 5,
                                                                    Design.mainColorOpacity.B - 5);

            SetStyleButtons();

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 110, 110);
            Region rgn = new Region(path);
            user_photo.Region = rgn;
            user_photo.BackColor = Color.White;

            user_login.Text = User.user_login;
            achieves.Text = User.user_achieves.ToString();
            perform.Text = User.user_perform + "%";
            user_photo.Image = User.user_photo.Image;

            block_for_focus.Focus();
        }

        private void SetStyleButtons() 
        {
            addTask.ForeColor = Design.mainColor;
            addTask.Inactive1 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTask.Inactive2 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTask.Active1 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTask.Active2 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTask.StrokeColor = Color.FromArgb(20,
                                                 Design.mainColor.R,
                                                 Design.mainColor.G,
                                                 Design.mainColor.B);
            addTask.MouseDown += button_MouseDown;
            addTask.MouseUp += button_MouseUp;

            addNote.ForeColor = Design.mainColor;
            addNote.Inactive1 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addNote.Inactive2 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addNote.Active1 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addNote.Active2 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addNote.StrokeColor = Color.FromArgb(20,
                                                 Design.mainColor.R,
                                                 Design.mainColor.G,
                                                 Design.mainColor.B);
            addNote.MouseDown += button_MouseDown;
            addNote.MouseUp += button_MouseUp;

            addDirect.ForeColor = Design.mainColor;
            addDirect.Inactive1 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDirect.Inactive2 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDirect.Active1 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDirect.Active2 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDirect.StrokeColor = Color.FromArgb(20,
                                                 Design.mainColor.R,
                                                 Design.mainColor.G,
                                                 Design.mainColor.B);
            addDirect.MouseDown += button_MouseDown;
            addDirect.MouseUp += button_MouseUp;

            addTarget.ForeColor = Design.mainColor;
            addTarget.Inactive1 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTarget.Inactive2 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTarget.Active1 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTarget.Active2 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTarget.StrokeColor = Color.FromArgb(20,
                                                 Design.mainColor.R,
                                                 Design.mainColor.G,
                                                 Design.mainColor.B);
            addTarget.MouseDown += button_MouseDown;
            addTarget.MouseUp += button_MouseUp;
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            ((AltoControls.AltoButton)sender).ForeColor = Design.mainColor;
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            ((AltoControls.AltoButton)sender).ForeColor = Color.White;
        }

        public static void Callback(object obj)
        {
            ServiceData.commandText = string.Format("SELECT task.id_task FROM task " +
                "INNER JOIN target ON target.id_target = task.id_target " +
                "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                "WHERE user_dir.id_user = {0} AND task.status = 0 AND task.failed = 0 AND task.date = '{1}.{2}.{3}' AND task.time_finish < '{4}:{5}'", 
                    User.user_id, 
                    DateTime.Now.ToString("dd"), 
                    DateTime.Now.ToString("MM"), 
                    DateTime.Now.ToString("yyyy"),
                    DateTime.Now.ToString("HH"),
                    DateTime.Now.ToString("mm"));

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                while (ServiceData.reader.Read())
                {
                    idFailedTasks.Add(ServiceData.reader.GetInt32(0));
                }
            }
        }

        private static async void InstallFailedTask() 
        {
            if (idFailedTasks.Count != 0)
            {
                for (int i = 0; i < idFailedTasks.Count; i++)
                {
                    ServiceData.commandText = string.Format("SELECT task.id_task, direction.name, target.name, task.text FROM task " +
                       "INNER JOIN target ON target.id_target = task.id_target " +
                       "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                       "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                       "WHERE task.id_task = {0}", idFailedTasks[i]);

                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                    ServiceData.reader = ServiceData.command.ExecuteReader();
                    if (ServiceData.reader.HasRows)
                    {
                        ServiceData.reader.Read();
                        string commandText;
                        SQLiteCommand command;

                        if (MessageBox.Show("Вышло время выполнения задачи:\n\n" +
                                            "Направление: " + ServiceData.reader.GetString(1) + "\n" +
                                            "Цель: " + ServiceData.reader.GetString(2) + "\n" +
                                            "Задача: " + ServiceData.reader.GetString(3) + "\n\n" +
                                            "Вы выполнили эту задачу?", "Сообщение",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            commandText = @"UPDATE task SET failed = 0, status = 1 WHERE id_task = @id_task";
                        }
                        else
                        {
                            commandText = @"UPDATE task SET failed = 1, status = 0 WHERE id_task = @id_task";
                        }

                        command = new SQLiteCommand(commandText, ServiceData.connect);
                        command.Parameters.AddWithValue("@id_task", idFailedTasks[i]);
                        command.ExecuteNonQuery();
                    }
                }

                Design.RefreshPanel(WindowManager.flowPanelTasks);
                await WindowManager.SetTaskBlock();
                GlobalData.scroller_task.Refresh(Design.heightContentTasks);
                WeeklyStatistic.Refresh();

                idFailedTasks.Clear();
            }
        }

        private void status_task_none_Click(object sender, EventArgs e)
        {
            GlobalComponents.status_mark.Left = 900;
            Design.heightContentTaskTarget = 0;
            Design.RefreshPanel(WindowManager.flowPanelTaskTarget);

            ServiceData.commandText = string.Format("SELECT " +
                "task.id_task, task.date, task.time, task.time_finish, direction.name, direction.color_mark, " +
                "target.name, task.text, task.descr, task.failed, task.status FROM task " +
                "INNER JOIN target ON task.id_target = target.id_target " +
                "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                "INNER JOIN user ON user_dir.id_user = user.id_user " +
                "WHERE target.id_target = {0} AND task.status = 0 AND task.failed = 0", GlobalData.id_target);

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                List<TaskBlock> tasks = new List<TaskBlock>();

                while (ServiceData.reader.Read())
                {
                    tasks.Add(new TaskBlock(
                        WindowManager.flowPanelTaskTarget,
                        Convert.ToInt32(ServiceData.reader.GetValue(0)),
                        ServiceData.reader.GetString(1),
                        ServiceData.reader.GetString(2),
                        ServiceData.reader.GetString(3),
                        ServiceData.reader.GetString(4),
                        ServiceData.reader.GetString(5),
                        ServiceData.reader.GetString(6),
                        ServiceData.reader.GetString(7),
                        ServiceData.reader.GetValue(8).ToString(),
                        Convert.ToInt32(ServiceData.reader.GetValue(9)),
                        Convert.ToInt32(ServiceData.reader.GetValue(10))));
                }
            }
            GlobalData.scroller_task_target.Refresh(Design.heightContentTaskTarget);

            if (Design.heightContentTaskTarget == 0)
            {
                GlobalComponents.notFoundTaskTarget.Visible = true;
            }
            else
            {
                GlobalComponents.notFoundTaskTarget.Visible = false;
            }
        }

        private void status_task_done_Click(object sender, EventArgs e)
        {
            GlobalComponents.status_mark.Left = 923;
            Design.heightContentTaskTarget = 0;
            Design.RefreshPanel(WindowManager.flowPanelTaskTarget);

            ServiceData.commandText = string.Format("SELECT " +
                "task.id_task, task.date, task.time, task.time_finish, direction.name,  direction.color_mark, " +
                "target.name, task.text, task.descr, task.failed, task.status FROM task " +
                "INNER JOIN target ON task.id_target = target.id_target " +
                "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                "INNER JOIN user ON user_dir.id_user = user.id_user " +
                "WHERE target.id_target = {0} AND task.status = 1 AND task.failed = 0", GlobalData.id_target);

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                List<TaskBlock> tasks = new List<TaskBlock>();
                PictureBox boxStatus = new PictureBox();

                boxStatus = new PictureBox();
                boxStatus.SizeMode = PictureBoxSizeMode.CenterImage;
                boxStatus.Width = 430;
                boxStatus.Height = 35;
                boxStatus.Image = Properties.Resources.done_tasks;
                WindowManager.flowPanelTaskTarget.Controls.Add(boxStatus);
                Design.heightContentTasks += boxStatus.Height;

                while (ServiceData.reader.Read())
                {
                    tasks.Add(new TaskBlock(
                        WindowManager.flowPanelTaskTarget,
                        Convert.ToInt32(ServiceData.reader.GetValue(0)),
                        ServiceData.reader.GetString(1),
                        ServiceData.reader.GetString(2),
                        ServiceData.reader.GetString(3),
                        ServiceData.reader.GetString(4),
                        ServiceData.reader.GetString(5),
                        ServiceData.reader.GetString(6),
                        ServiceData.reader.GetString(7),
                        ServiceData.reader.GetValue(8).ToString(),
                        Convert.ToInt32(ServiceData.reader.GetValue(9)),
                        Convert.ToInt32(ServiceData.reader.GetValue(10))));
                }
            }
            GlobalData.scroller_task_target.Refresh(Design.heightContentTaskTarget);

            if (Design.heightContentTaskTarget == 0)
            {
                GlobalComponents.notFoundTaskTarget.Visible = true;
            }
            else
            {
                GlobalComponents.notFoundTaskTarget.Visible = false;
            }
        }

        private void status_task_fail_Click(object sender, EventArgs e)
        {
            GlobalComponents.status_mark.Left = 947;
            Design.heightContentTaskTarget = 0;
            Design.RefreshPanel(WindowManager.flowPanelTaskTarget);

            ServiceData.commandText = string.Format("SELECT " +
                "task.id_task, task.date, task.time, task.time_finish, direction.name,  direction.color_mark, " +
                "target.name, task.text, task.descr, task.failed, task.status FROM task " +
                "INNER JOIN target ON task.id_target = target.id_target " +
                "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                "INNER JOIN user ON user_dir.id_user = user.id_user " +
                "WHERE target.id_target = {0} AND task.status = 0 AND task.failed = 1", GlobalData.id_target);

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                List<TaskBlock> tasks = new List<TaskBlock>();
                PictureBox boxStatus = new PictureBox();

                boxStatus = new PictureBox();
                boxStatus.SizeMode = PictureBoxSizeMode.CenterImage;
                boxStatus.Width = 430;
                boxStatus.Height = 35;
                boxStatus.Image = Properties.Resources.fail_tasks;
                WindowManager.flowPanelTaskTarget.Controls.Add(boxStatus);
                Design.heightContentTasks += boxStatus.Height;

                while (ServiceData.reader.Read())
                {
                    tasks.Add(new TaskBlock(
                        WindowManager.flowPanelTaskTarget,
                        Convert.ToInt32(ServiceData.reader.GetValue(0)),
                        ServiceData.reader.GetString(1),
                        ServiceData.reader.GetString(2),
                        ServiceData.reader.GetString(3),
                        ServiceData.reader.GetString(4),
                        ServiceData.reader.GetString(5),
                        ServiceData.reader.GetString(6),
                        ServiceData.reader.GetString(7),
                        ServiceData.reader.GetValue(8).ToString(),
                        Convert.ToInt32(ServiceData.reader.GetValue(9)),
                        Convert.ToInt32(ServiceData.reader.GetValue(10))));
                }
            }
            GlobalData.scroller_task_target.Refresh(Design.heightContentTaskTarget);

            if (Design.heightContentTaskTarget == 0)
            {
                GlobalComponents.notFoundTaskTarget.Visible = true;
            }
            else
            {
                GlobalComponents.notFoundTaskTarget.Visible = false;
            }
        }

        private void addNote_Click(object sender, EventArgs e)
        {
            if (GlobalData.addNoteForm == null)
            {
                GlobalData.addNoteForm = new AddNoteForm();
                GlobalData.addNoteForm.ShowDialog();
            }
            else 
            {
                GlobalData.addNoteForm.ShowDialog();
            }
        }

        private void addDirect_Click(object sender, EventArgs e)
        {
            if (GlobalData.addDirectionForm == null)
            {
                GlobalData.addDirectionForm = new AddDirectionForm();
                GlobalData.addDirectionForm.ShowDialog();
            }
            else
            {
                GlobalData.addDirectionForm.ShowDialog();
            }
        }

        private void addTarget_Click(object sender, EventArgs e)
        {
            if (GlobalData.addTargetForm == null)
            {
                GlobalData.addTargetForm = new AddTargetForm();
                GlobalData.addTargetForm.ShowDialog();
            }
            else
            {
                GlobalData.addTargetForm.ShowDialog();
            }
        }
    }
}
