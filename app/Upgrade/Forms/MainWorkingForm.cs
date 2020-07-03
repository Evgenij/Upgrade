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

        public MainWorkingForm()
        {
            InitializeComponent();
            this.Load += MainWorkingForm_Load;
            this.BackColor = Design.backColor;

            panel_menu.BackColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            tab_profile.BackColor = Design.backColor;
            tab_targets.BackColor = Design.backColor;
            tab_stat.BackColor = Design.backColor;
            tab_sched.BackColor = Design.backColor;
            tab_sett.BackColor = Design.backColor;
        }

        private void MainWorkingForm_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(-1, -1, 1366, 768, 78, 78);
            SetWindowRgn(this.Handle, hRgn, true);

            List<TaskBlock> taskBlock = new List<TaskBlock>();

            ServiceData.commandText = @"SELECT 
                task.id_task, task.date, task.time, direction.name, target.name, task.text, task.descr FROM task 
                INNER JOIN target ON task.id_target = target.id_target 
                INNER JOIN direction ON target.id_direct = direction.id_direct 
                INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct
                INNER JOIN user ON user_dir.id_user = user.id_user 
                WHERE user.id_user = 3
                ORDER BY task.time";
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                while (ServiceData.reader.Read())
                {
                    taskBlock.Add(new TaskBlock(
                        flowTasks,
                        Convert.ToInt32(ServiceData.reader.GetValue(0)),
                        ServiceData.reader.GetString(1),
                        ServiceData.reader.GetString(2),
                        ServiceData.reader.GetString(3),
                        ServiceData.reader.GetString(4),
                        ServiceData.reader.GetString(5),
                        ServiceData.reader.GetValue(6).ToString()));
                }
            }

            Scroller scroller = new Scroller(tab_profile, flowTasks);

            MessageBox.Show(flowTasks.VerticalScroll.Maximum.ToString());

            block_for_focus.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
