using Nevron.Nov.WinFormControls;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Upgrade.Classes;

namespace Upgrade.Classes
{
    class TaskBlock
    {
        private int count_subtasks = 0, success_subtasks = 0, id_task;

        private GlobalData.StatusTask statusTask = GlobalData.StatusTask.Empty; 

        private FlowLayoutPanel flowPanel; 
        private Panel panel;
        private PictureBox box_top;
        private PictureBox box_center;
        private PictureBox box_bottom;
        private PictureBox line;
        private PictureBox more;
        private PictureBox check;
        private Label dateLabel;
        private Label day;
        private TextBox direct;
        private TextBox targetLabel;
        private TextBox textLabel;
        private TextBox descrLabel;
        private Label timeLabel;
        private Label time_range;
        private FlowLayoutPanel flowPanelSubtasks;

        private List<SubTaskBlock> subTaskBlocks;

        private enum DayOfWeek { 
            Понедельник = 2,
            Вторник = 3,
            Среда = 4,
            Четверг = 5,
            Пятница = 6,
            Суббота = 7,
            Воскресенье = 1 
        };

        public TaskBlock(FlowLayoutPanel flowPanel,
                         int id_task,
                         string date,
                         string time,
                         string time_finish,
                         string direction,
                         string target,
                         string text, 
                         string descr,
                         int failed,
                         int status) 
        {
            this.id_task = id_task;
            this.flowPanel = flowPanel;

            panel = new Panel();
            box_top = new PictureBox();
            box_center = new PictureBox();
            box_bottom = new PictureBox();
            line = new PictureBox();
            more = new PictureBox();
            check = new PictureBox();
            dateLabel = new Label();
            day = new Label();
            direct = new TextBox();
            targetLabel = new TextBox();
            textLabel = new TextBox();
            timeLabel = new Label();
            time_range = new Label();

            dateLabel.Left = 24;
            dateLabel.Top = 25;
            dateLabel.Width = 80;
            dateLabel.Font = GlobalData.GetFont(GlobalData.TypeFont.Standart, 12);
            dateLabel.ForeColor = Design.mainColor;
            dateLabel.BackColor = Color.White;
            dateLabel.Text = date;

            string[] dateValues = dateLabel.Text.Split('.');
            DateTime dateTask = new DateTime(
                Convert.ToInt32(dateValues[2]), 
                Convert.ToInt32(dateValues[1]), 
                Convert.ToInt32(dateValues[0]));
            DayOfWeek dayOfWeek = (DayOfWeek)Enum.GetValues(typeof(DayOfWeek)).GetValue(Convert.ToInt32(dateTask.DayOfWeek));

            day.Text = dayOfWeek.ToString();
            day.Left = 105;
            day.Top = 25;
            day.Width = day.Text.Length * 11;
            day.Font = GlobalData.GetFont(GlobalData.TypeFont.Standart, 12);
            day.ForeColor = Color.Gray;
            day.BackColor = Color.White;
            

            direct.BorderStyle = BorderStyle.None;
            direct.Left = 66;
            direct.Top = 55;
            direct.Font = GlobalData.GetFont(GlobalData.TypeFont.Standart, 11);
            direct.ForeColor = Design.mainColor;
            direct.BackColor = Color.White;
            direct.Text = direction;
            direct.WordWrap = true;
            direct.ReadOnly = true;
            direct.MaximumSize = new Size(142,18); 
            direct.Width = 9 * direct.Text.Length - 7;

            targetLabel.BorderStyle = BorderStyle.None;
            targetLabel.Left = direct.Left + direct.Width;
            targetLabel.Top = direct.Top;
            targetLabel.Width = 120;
            targetLabel.Font = GlobalData.GetFont(GlobalData.TypeFont.Standart, 11);
            targetLabel.ForeColor = Color.Gray;
            targetLabel.BackColor = Color.White;
            targetLabel.Text = "- " + target;
            targetLabel.WordWrap = true;
            targetLabel.ReadOnly = true;
            targetLabel.Width = 250 - direct.Width;

            textLabel.Left = 63;
            textLabel.Top = direct.Top + 20;
            textLabel.Width = 255;
            textLabel.Font = GlobalData.GetFont(GlobalData.TypeFont.Medium, 14);
            textLabel.BackColor = Color.White;
            textLabel.ForeColor = Color.Black;
            textLabel.BorderStyle = BorderStyle.None;
            textLabel.ReadOnly = true;
            textLabel.Multiline = true;
            textLabel.Text = text;
            if (textLabel.Text.Length >= 28)
            {
                textLabel.Height = 21 * (textLabel.Text.Length / 28);
            }
            else 
            {
                textLabel.Height = 21;
            }

            if (descr != "")
            {
                descrLabel = new TextBox();
                descrLabel.Left = 62;
                descrLabel.Top = textLabel.Top + textLabel.Height + 10;
                descrLabel.Width = 255;
                descrLabel.Font = GlobalData.GetFont(GlobalData.TypeFont.Standart, 11);
                descrLabel.BackColor = Color.White;
                descrLabel.ForeColor = Color.Gray;
                descrLabel.BorderStyle = BorderStyle.None;
                descrLabel.Multiline = true;
                descrLabel.ReadOnly = true;
                descrLabel.Text = descr;
                if (descrLabel.Text.Length >= 28)
                {
                    descrLabel.Height = 18 * (descrLabel.Text.Length / 28);
                }
                else
                {
                    descrLabel.Height = 18;
                }
            }

            if (failed == 1)
            {
                statusTask = GlobalData.StatusTask.Failed;
                check.AccessibleName = "failed";
                check.Image = Properties.Resources.check_fail;
            }
            else
            {
                if (status == 0)
                {
                    check.AccessibleName = "undone";
                    check.Image = Properties.Resources.check_off;
                }
                else if (status == 1)
                {
                    statusTask = GlobalData.StatusTask.Done;
                    check.AccessibleName = "done";
                    check.Image = Properties.Resources.check_done;
                }
            }

            string commandText = @"SELECT 
                subtask.text, subtask.status 
                FROM subtask 
                INNER JOIN task ON subtask.id_task = task.id_task
                WHERE task.id_task = @id_task";

            SQLiteCommand command = new SQLiteCommand(commandText, ServiceData.connect);
            command.Parameters.AddWithValue("@id_task", id_task);

            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                flowPanelSubtasks = new FlowLayoutPanel();
                flowPanelSubtasks.Size = new Size(255, 0);
                flowPanelSubtasks.Left = textLabel.Left - 1;
                flowPanelSubtasks.BackColor = Color.White;
                flowPanelSubtasks.FlowDirection = FlowDirection.TopDown;
                flowPanelSubtasks.AutoSize = true;
                flowPanelSubtasks.Top = textLabel.Top + textLabel.Height + 5;
                if (descrLabel != null) 
                {
                    flowPanelSubtasks.Top += descrLabel.Height + 10; 
                }
                flowPanelSubtasks.Top += 10;

                subTaskBlocks = new List<SubTaskBlock>();
                while (reader.Read())
                {
                    count_subtasks++;
                    subTaskBlocks.Add(new SubTaskBlock(this, flowPanelSubtasks, reader.GetString(0)));
                    flowPanelSubtasks.Height += subTaskBlocks.Last().GetHeight();
                }
                flowPanelSubtasks.Height += 10;
            }

            timeLabel.Height = 27;
            timeLabel.Width = 74;
            timeLabel.Left = 346;
            timeLabel.Top = 52;
            timeLabel.Text = time;
            timeLabel.Font = GlobalData.GetFont(GlobalData.TypeFont.Medium, 18);
            timeLabel.ForeColor = Design.mainColor;
            timeLabel.BackColor = Color.White;

            time_range.Height = 27;
            time_range.Width = 110;
            time_range.Left = 316;
            time_range.Top = 79;
            time_range.Text = time + " - " + time_finish;
            time_range.Font = GlobalData.GetFont(GlobalData.TypeFont.Standart, 12);
            time_range.ForeColor = Color.Gray;
            time_range.BackColor = Color.White;

            box_top.Image = Properties.Resources.task_box_top;
            box_top.SizeMode = PictureBoxSizeMode.AutoSize;
            box_top.Top = 0;
            box_top.BackColor = Color.Transparent;

            box_center.Image = Properties.Resources.task_box_center;
            box_center.SizeMode = PictureBoxSizeMode.StretchImage;
            box_center.BackColor = Color.Transparent;
            box_center.Top = box_top.Height;
            box_center.Width = 430;
            box_center.Height = textLabel.Height + 35;
            if (descr != "")
            {
                box_center.Height += descrLabel.Height + 10;
            }
            if (flowPanelSubtasks != null)
            {
                box_center.Height += flowPanelSubtasks.Height + 25;
            }

            box_bottom.Image = Properties.Resources.task_box_bottom;
            box_bottom.SizeMode = PictureBoxSizeMode.AutoSize;
            box_bottom.BackColor = Color.Transparent;
            box_bottom.Top = box_top.Height + box_center.Height - 5;

            line.Image = Properties.Resources.task_line;
            line.Left = 165;
            line.Top = 35;
            line.Width = 220;
            line.Height = 1;
            line.BackColor = Color.White;

            more.Image = Properties.Resources.more_off;
            more.SizeMode = PictureBoxSizeMode.CenterImage;
            more.Height = 20;
            more.Width = 10;
            more.Left = 398;
            more.Top = 25;
            more.BackColor = Color.White;
            more.Cursor = Cursors.Hand;
            more.MouseHover += More_MouseHover;
            more.MouseLeave += More_MouseLeave;

            check.SizeMode = PictureBoxSizeMode.AutoSize;
            check.BackColor = Color.White;
            check.Left = 28;
            check.Top = 57;
            check.Cursor = Cursors.Hand;
            check.MouseHover += Check_MouseHover;
            check.MouseLeave += Check_MouseLeave;
            check.Click += Check_Click;

            panel.Width = 430;
            panel.Height = box_top.Height + box_center.Height + box_bottom.Height + 4;

            panel.Controls.Add(dateLabel);
            panel.Controls.Add(day);
            panel.Controls.Add(direct);
            panel.Controls.Add(targetLabel);
            panel.Controls.Add(textLabel);
            if (descr != "") 
            {
                panel.Controls.Add(descrLabel);
            }
            if (flowPanelSubtasks != null) 
            {
                panel.Controls.Add(flowPanelSubtasks);
            }

            panel.Controls.Add(timeLabel);
            panel.Controls.Add(time_range);
            panel.Controls.Add(line);
            panel.Controls.Add(more);
            panel.Controls.Add(check);
            panel.Controls.Add(box_top);
            panel.Controls.Add(box_center);
            panel.Controls.Add(box_bottom);
            flowPanel.Controls.Add(panel);
        }

        public void AddSuccessSubtasks() 
        {
            success_subtasks++;
            if (count_subtasks == success_subtasks) 
            {
                ServiceData.commandText = @"UPDATE task SET status = 1 WHERE id_task = @id_task";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.Parameters.AddWithValue("@id_task", this.id_task);
                ServiceData.command.ExecuteNonQuery();

                check.AccessibleName = "done";
                check.Image = Properties.Resources.check_done;
                Design.HidePanel(panel, flowPanel);
            }
        }

        public void DeleteSuccessSubtasks()
        {
            success_subtasks--;
        }

        public GlobalData.StatusTask GetStatus() 
        {
            return statusTask;
        }

        private void Check_MouseLeave(object sender, EventArgs e)
        {
            if (check.AccessibleName != "failed")
            {
                if (check.AccessibleName != "done")
                {
                    check.Image = Properties.Resources.check_off;
                }
            }
        }

        private void Check_MouseHover(object sender, EventArgs e)
        {
            if (check.AccessibleName != "failed")
            {
                if (check.AccessibleName != "done")
                {
                    check.Image = Properties.Resources.check_on;
                }
            }
        }

        private void Check_Click(object sender, EventArgs e)
        {
            if (check.AccessibleName == "undone")
            {
                if (count_subtasks == 0)
                {
                    ServiceData.commandText = @"UPDATE task SET status = 1 WHERE id_task = @id_task";
                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                    ServiceData.command.Parameters.AddWithValue("@id_task", this.id_task);
                    ServiceData.command.ExecuteNonQuery();

                    check.AccessibleName = "done";
                    check.Image = Properties.Resources.check_done;
                    Design.HidePanel(panel, flowPanel);
                }
            }
        }

        private void More_MouseLeave(object sender, EventArgs e)
        {
            more.Image = Properties.Resources.more_off;
        }

        private void More_MouseHover(object sender, EventArgs e)
        {
            more.Image = Properties.Resources.more_on;
        }
    }
}
