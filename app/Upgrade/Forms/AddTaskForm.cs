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

using Upgrade.Classes;
using Upgrade.Classes.Components;

namespace Upgrade.Forms
{
    public partial class AddTaskForm : Form
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


        UITrackBar[] uiTrackBars = new UITrackBar[4];
        GlobalData.DayOfWeek[] days = new GlobalData.DayOfWeek[7];

        private List<GlobalData.DataContainer> targets = new List<GlobalData.DataContainer>();
        private int index_target = 0;


        private List<Subtask> subtasks = new List<Subtask>();


        public AddTaskForm()
        {
            InitializeComponent();
            this.Load += Form_Load;

            for (int i = 0; i < days.Length; i++) 
            {
                days[i] = new GlobalData.DayOfWeek();
            }

            ServiceData.commandText = string.Format("SELECT DISTINCT target.id_target, target.name FROM target " +
                "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                "INNER JOIN user ON user.id_user = user_dir.id_user " +
                "WHERE user.id_user = {0}", User.user_id);
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                while (ServiceData.reader.Read())
                {
                    targets.Add(new GlobalData.DataContainer(ServiceData.reader.GetInt32(0), ServiceData.reader.GetString(1)));
                }
            }
            target.Text = targets.First().GetName();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, this.Width, this.Height, 55, 55);
            SetWindowRgn(this.Handle, hRgn, true);

            addTaskButton.ForeColor = Design.mainColor;
            addTaskButton.Active1 = Design.mainColorOpacity;
            addTaskButton.Active2 = Design.mainColorOpacity;
            addTaskButton.StrokeColor = Design.mainColor;

            uiTrackBars[0] = new UITrackBar(this, 391, 389, taskStartHour, Enums.TypeTime.hour);
            uiTrackBars[1] = new UITrackBar(this, 391, 417, taskStartMinute, Enums.TypeTime.minute);
            uiTrackBars[2] = new UITrackBar(this, 618, 389, taskEndHour, Enums.TypeTime.hour);
            uiTrackBars[3] = new UITrackBar(this, 618, 417, taskEndMinute, Enums.TypeTime.minute);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void day1_Click(object sender, EventArgs e)
        {
            days[0].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Понедельник);
        }

        private void day2_Click(object sender, EventArgs e)
        {
            days[1].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Вторник);
        }

        private void day3_Click(object sender, EventArgs e)
        {
            days[2].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Среда);
        }

        private void day4_Click(object sender, EventArgs e)
        {
            days[3].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Четверг);
        }

        private void day5_Click(object sender, EventArgs e)
        {
            days[4].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Пятница);
        }

        private void day6_Click(object sender, EventArgs e)
        {
            days[5].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Суббота);
        }

        private void day7_Click(object sender, EventArgs e)
        {
            days[6].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Воскресенье);
        }

        private void prev_Click(object sender, EventArgs e)
        {
            if (index_target >= 1)
            {
                index_target--;
                target.Text = targets.ElementAt(index_target).GetName();
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (index_target < (targets.Count - 1) && index_target >= 0)
            {
                index_target++;
                target.Text = targets.ElementAt(index_target).GetName();
            }
        }

        private void prev_MouseHover(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.prev_on;
        }

        private void prev_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.prev_off;
        }

        private void next_MouseHover(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.next_on;
        }

        private void next_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.next_off;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "введите текст задачи" ||
                ((TextBox)sender).Text == "введите описание задачи")
            {
                ((TextBox)sender).Text = null;
                ((TextBox)sender).Font = GlobalData.GetFont(Enums.TypeFont.Regular, 16);
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).ForeColor = Color.DarkGray;
                ((TextBox)sender).Font = GlobalData.GetFont(Enums.TypeFont.Regular, 16);
                if (((TextBox)sender).Name == "task_name")
                {
                    ((TextBox)sender).Text = "введите текст задачи";
                }
                else if (((TextBox)sender).Name == "task_descr")
                {
                    ((TextBox)sender).Text = "введите описание задачи";
                }
            }
        }

        private void buttonAddSubtask_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Design.mainColor;
        }

        private void buttonAddSubtask_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.DarkGray;
        }

        private void taskStartHour_TextChanged(object sender, EventArgs e)
        {
            taskHour.Text = ((TextBox)sender).Text;
        }

        private void taskStartMinute_TextChanged(object sender, EventArgs e)
        {
            taskMinute.Text = ((TextBox)sender).Text;
        }

        private void buttonAddSubtask_Click(object sender, EventArgs e)
        {
            subtasks.Add(new Subtask(flowPanelSubtasks));
        }
    }
}
