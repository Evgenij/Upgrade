﻿using Nevron.Nov.UI;
using System;
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

        Scroller scroller_task;
        Scroller scroller_note;
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

            await WindowManager.CreateMainWindow(flowTasks, WindowManager.TypeBlock.Tasks);
            await WindowManager.CreateMainWindow(flowNotes, WindowManager.TypeBlock.Notes);

            scroller_task = new Scroller(tab_profile, flowTasks);
            scroller_note = new Scroller(tab_profile, flowNotes);

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

            timerTime = new Timer();
            timerTime.Interval = 1000;
            timerTime.Tick += TimerTime_Tick;
            timerTime.Start();

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

        private void period_SelectedIndexChanged(Nevron.Nov.Dom.NValueChangeEventArgs arg)
        {
            MessageBox.Show(period.SelectedIndex.ToString()); 
        }

        private void flowTasks_ControlRemoved(object sender, ControlEventArgs e)
        {
            scroller_task.Refresh();
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
            scroller_note.Refresh();
        }
    }
}
