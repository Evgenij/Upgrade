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
                ((TextBox)sender).Text == "введите описание задачи" ||
                ((TextBox)sender).Text == "введите название расписания")
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
                else if (((TextBox)sender).Name == "sched_name")
                {
                    ((TextBox)sender).Text = "введите название расписания";
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

            if (Convert.ToInt32(taskEndHour.Text) < Convert.ToInt32(taskStartHour.Text))
            {
                taskEndHour.Text = taskStartHour.Text;
            }
        }

        private void taskStartMinute_TextChanged(object sender, EventArgs e)
        {
            taskMinute.Text = ((TextBox)sender).Text;

            if (Convert.ToInt32(taskEndMinute.Text) < Convert.ToInt32(taskStartMinute.Text))
            {
                taskEndMinute.Text = taskStartMinute.Text;
            }
        }

        private void buttonAddSubtask_Click(object sender, EventArgs e)
        {
            subtasks.Add(new Subtask(flowPanelSubtasks));
        }

        private async void addTaskButton_Click(object sender, EventArgs e)
        {
            if (task_name.Text != "введите текст задачи")
            {
                try
                {
                    int id_sched = 0, id_task = 0;

                    if (sched_name.Text != "введите название расписания")
                    {

                        ServiceData.commandText = @"INSERT INTO schedule (name) VALUES(@name)";
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                        ServiceData.command.Parameters.AddWithValue("@name", sched_name.Text);
                        ServiceData.command.ExecuteNonQuery();

                        ServiceData.commandText = "SELECT id_sched FROM schedule";
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                        ServiceData.reader = ServiceData.command.ExecuteReader();
                        if (ServiceData.reader.HasRows)
                        {
                            while (ServiceData.reader.Read())
                            {
                                id_sched = ServiceData.reader.GetInt32(0);
                            }
                        }
                    }

                    // --------------

                    string descr;
                    if (task_descr.Text != "введите описание задачи")
                    {
                        descr = task_descr.Text;
                    }
                    else 
                    {
                        descr = null;
                    }

                    bool taskAdding = false;
                    if (Convert.ToInt32(taskStartHour.Text) <= Convert.ToInt32(taskEndHour.Text)) 
                    {
                        taskAdding = true;
                    }


                    if (taskAdding == true)
                    {
                        ServiceData.commandText = @"INSERT INTO task (id_target, text, descr, date, time, time_finish, failed, status) " +
                            "VALUES (@target, @text, @descr, @date, @time, @time_finish, 0, 0)";
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                        ServiceData.command.Parameters.AddWithValue("@target", targets.ElementAt(index_target).GetId());
                        ServiceData.command.Parameters.AddWithValue("@text", task_name.Text);
                        ServiceData.command.Parameters.AddWithValue("@descr", descr);
                        ServiceData.command.Parameters.AddWithValue("@date", dateTime.Value.ToString("dd.MM.yyyy"));
                        ServiceData.command.Parameters.AddWithValue("@time", taskHour.Text + ":" + taskMinute.Text);
                        ServiceData.command.Parameters.AddWithValue("@time_finish", taskEndHour.Text + ":" + taskEndMinute.Text);
                        ServiceData.command.ExecuteNonQuery();

                        ServiceData.commandText = "SELECT id_task FROM task";
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                        ServiceData.reader = ServiceData.command.ExecuteReader();
                        if (ServiceData.reader.HasRows)
                        {
                            while (ServiceData.reader.Read())
                            {
                                id_task = ServiceData.reader.GetInt32(0);
                            }
                        }

                        // --------------

                        if (subtasks.Count > 0)
                        {
                            foreach (Subtask subtask in subtasks)
                            {
                                if (subtask.GetText() != "delete")
                                {
                                    MessageBox.Show(subtask.GetText());
                                    ServiceData.commandText = @"INSERT INTO subtask (id_task, text) VALUES (@id_task, @text)";
                                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                                    ServiceData.command.Parameters.AddWithValue("@id_task", id_task);
                                    ServiceData.command.Parameters.AddWithValue("@text", subtask.GetText());
                                    ServiceData.command.ExecuteNonQuery();
                                }
                            }
                        }

                        // --------------

                        if (id_sched != 0)
                        {
                            foreach (GlobalData.DayOfWeek day in days)
                            {
                                if (day.GetStatus() == true)
                                {
                                    ServiceData.commandText = string.Format("INSERT INTO sched_task (id_sched, id_task, id_day) " +
                                        "VALUES ({0}, {1}, {2})",
                                        id_sched,
                                        id_task,
                                        day.GetIdDay());

                                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                                    ServiceData.command.ExecuteNonQuery();
                                }
                            }
                        }


                        string successString = "Задача";

                        if (id_sched != 0)
                        {
                            successString += " и расписание созданы!";
                        }
                        else
                        {
                            successString += " создана!";
                        }

                        MessageBox.Show(
                            successString,
                            "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Design.RefreshPanel(WindowManager.flowPanelTasks);
                        await WindowManager.SetTaskBlock();

                        this.Close();
                    }
                    else 
                    {
                        MessageBox.Show(
                           "Время завершения задачи не может быть меньше времени его начала.",
                           "Ошибка создания задачи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Не удалось создать задачу...\n-\nОшибка: " + ex.Message,
                        "Ошибка создания задачи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(
                    "Вы не ввели название задачи...",
                    "Ошибка создания задачи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sched_name_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "введите название расписания" || ((TextBox)sender).Text.Length == 0)
            {
                //flowPanelDays.Enabled = false;
                flowPanelDays.Cursor = Cursors.No;
                foreach (Control control in flowPanelDays.Controls) 
                {
                    control.Cursor = Cursors.No;
                }
            }
            else 
            {
                flowPanelDays.Enabled = true;
                flowPanelDays.Cursor = Cursors.Default;
                foreach (Control control in flowPanelDays.Controls)
                {
                    control.Cursor = Cursors.Hand;
                }
            }
        }
    }
}
