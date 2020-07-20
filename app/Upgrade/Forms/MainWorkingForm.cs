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
using System.Threading.Tasks;
using System.Windows.Forms;
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
        Timer timerTime;

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
            label_time.Text = hours_minutes;
            label_seconds.Text = seconds;
        }

        private async void MainWorkingForm_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(-1, -1, 1366, 768, 78, 78);
            SetWindowRgn(this.Handle, hRgn, true);

            string[] labelsPeriod = { "Прошлая неделя",
                                      "Вчера",
                                      "Сегодня",
                                      "Завтра",
                                      "Текущая неделя"};

            string[] labelsStatus = { "Все задачи",
                                      "Выполненные",
                                      "Невыполненные"};

            uiComboBox[1] = new UIComboBox(tab_profile, panel_period, "status", labelsStatus, null, null);
            uiComboBox[0] = new UIComboBox(tab_profile, panel_status_task, "period", labelsPeriod, label_today, uiComboBox[1].GetPanel());
            

            WindowManager.SetFlowPanelTask(flowTasks);
            WindowManager.SetFlowPanelNote(flowNotes);
            await WindowManager.SetTaskBlock();
            await WindowManager.SetNoteBlock();
            WeeklyStatistic.SetStatistic(tab_profile, panel_week_stat, performLastWeek, performCurrentWeek, faceIndicator, sublabel_week_stat);
            Design.SetMarkCurrentDay(day_mark);

            GlobalData.scroller_task = new Scroller(tab_profile, flowTasks, Design.heightContentTasks);
            GlobalData.scroller_note = new Scroller(tab_profile, flowNotes, Design.heightContentNotes);
            filter = new Filter(tab_profile, panel_filter);

            timerTime = new Timer();
            timerTime.Interval = 1000;
            timerTime.Tick += TimerTime_Tick;
            timerTime.Start();
        }

        public void SetPeriod(int index) 
        {
            WindowManager.period = (Enums.Period)index;
        }

        private void profile_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Design.Direction.Vertical, active_item.Top, 100);
            tabs.SelectedTab = tab_profile;
            active_item.Image = Properties.Resources.profile;
        }

        private void targets_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Design.Direction.Vertical, active_item.Top, 160);
            tabs.SelectedTab = tab_targets;
            active_item.Image = Properties.Resources.tardets;
        }

        private void stat_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Design.Direction.Vertical, active_item.Top, 220);
            tabs.SelectedTab = tab_stat;
            active_item.Image = Properties.Resources.stat;
        }

        private void schedule_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Design.Direction.Vertical, active_item.Top, 280);
            tabs.SelectedTab = tab_sched;
            active_item.Image = Properties.Resources.schedule;
        }

        private void settings_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Design.Direction.Vertical, active_item.Top, 340);
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
            Design.MovePanel(active_item, Design.Direction.Vertical, active_item.Top, 280);
            tabs.SelectedTab = tab_sched;
            active_item.Image = Properties.Resources.schedule;
        }

        private void flowNotes_ControlRemoved(object sender, ControlEventArgs e)
        {
            GlobalData.scroller_note.Refresh(Design.heightContentNotes);
        }

        private void addTask_Click(object sender, EventArgs e)
        {
            //
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

            exit_from_profile.BackColor = Color.FromArgb(234, 235, 240);

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
    }
}
