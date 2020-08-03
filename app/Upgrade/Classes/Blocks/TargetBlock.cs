using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Classes.Blocks
{
    class TargetBlock : Block
    {
        private Label labelPerform;
        private Label labelStat;
        private PictureBox[] buttons = new PictureBox[3];
        private FlowLayoutPanel flowTasks;
        private PictureBox[] boxStatus = new PictureBox[2];

        public TargetBlock(FlowLayoutPanel flowPanel, FlowLayoutPanel taskFlowPanel, int id_target, string nameTarget) 
        {
            this.id_record = id_target;
            labelPerform = new Label();
            labelStat = new Label();
            flowTasks = taskFlowPanel;

            textLabel.Left = 20;
            textLabel.Top = 17;
            textLabel.Width = 255;
            textLabel.Font = GlobalData.GetFont(Enums.TypeFont.Medium, 14);
            textLabel.BackColor = Color.White;
            textLabel.ForeColor = Color.Black;
            textLabel.BorderStyle = BorderStyle.None;
            textLabel.ReadOnly = true;
            textLabel.Multiline = true;
            textLabel.Text = nameTarget;
            if (textLabel.Text.Length >= 28)
            {
                textLabel.Height = 42 * (textLabel.Text.Length / 28);
            }
            else
            {
                textLabel.Height = 21;
            }

            box_top.Image = Properties.Resources.direct_box_top;
            box_top.SizeMode = PictureBoxSizeMode.AutoSize;
            box_top.Top = 0;
            box_top.BackColor = Color.Transparent;

            box_center.Image = Properties.Resources.direct_box_center;
            box_center.SizeMode = PictureBoxSizeMode.StretchImage;
            box_center.BackColor = Color.Transparent;
            box_center.Top = box_top.Height;
            box_center.Width = 305;
            box_center.Height = textLabel.Height + 55;

            box_bottom.Image = Properties.Resources.direct_box_bottom;
            box_bottom.SizeMode = PictureBoxSizeMode.AutoSize;
            box_bottom.BackColor = Color.Transparent;
            box_bottom.Top = box_top.Height + box_center.Height;

            double countTasks = 0, countDoneTasks = 0;
            string commandText = string.Format("SELECT count(task.id_task) FROM task " +
                "INNER JOIN target ON task.id_target = target.id_target " +
                "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                "INNER JOIN user ON user_dir.id_user = user.id_user " +
                "WHERE target.id_target = {0}", id_record);

            SQLiteCommand command = new SQLiteCommand(commandText, ServiceData.connect);

            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                countTasks = reader.GetInt32(0);
                if (countTasks == 0)
                {
                    countTasks = 1;
                }
            }

            commandText = string.Format("SELECT count(task.id_task) FROM task " +
                "INNER JOIN target ON task.id_target = target.id_target " +
                "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                "INNER JOIN user ON user_dir.id_user = user.id_user " +
                "WHERE target.id_target = {0} AND task.status = 1", id_record);

            command = new SQLiteCommand(commandText, ServiceData.connect);

            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                countDoneTasks = reader.GetInt32(0);
            }
            else
            {
                countDoneTasks = 0;
            }

            labelPerform.Width = 90;
            labelPerform.Height = 40;
            labelPerform.Left = box_center.Width - labelPerform.Width - 10;
            labelPerform.Top = textLabel.Top - 3;
            labelPerform.TextAlign = ContentAlignment.MiddleRight;
            labelPerform.Text = (Math.Ceiling((countDoneTasks * 100) / countTasks)).ToString() + "%";
            labelPerform.Font = GlobalData.GetFont(Enums.TypeFont.Medium, 25);
            labelPerform.ForeColor = Design.mainColor;
            labelPerform.BackColor = Color.White;

            labelStat.Width = 90;
            labelStat.Height = 18;
            labelStat.Left = box_center.Width - labelStat.Width - 17;
            labelStat.Top = labelPerform.Top + labelPerform.Height - 3;
            labelStat.TextAlign = ContentAlignment.MiddleRight;
            if (countTasks == 1 && countDoneTasks == 0)
            {
                labelStat.Text = countDoneTasks.ToString() + " из " + (countTasks - 1).ToString();
            }
            else
            {
                labelStat.Text = countDoneTasks.ToString() + " из " + countTasks.ToString();
            }
            labelStat.Font = GlobalData.GetFont(Enums.TypeFont.Standart, 12);
            labelStat.ForeColor = Color.DarkGray;
            labelStat.BackColor = Color.White;

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new PictureBox();
                buttons[i].AccessibleName = (i + 1).ToString();
                buttons[i].Top = box_bottom.Top - 13;
                buttons[i].SizeMode = PictureBoxSizeMode.AutoSize;
                buttons[i].BackColor = Color.White;

                if (i == 0)
                {
                    buttons[i].Image = Properties.Resources.dir_sett_off;
                    buttons[i].Left = 22;
                }
                else if (i == 1)
                {
                    buttons[i].Image = Properties.Resources.dir_find_off;
                    buttons[i].Left = 47;
                }
                else if (i == 2)
                {
                    buttons[i].Image = Properties.Resources.dir_target_off;
                    buttons[i].Left = 73;
                }

                buttons[i].MouseHover += button_MouseHover;
                buttons[i].MouseLeave += button_MouseLeave;
                buttons[i].Click += button_Click;
                buttons[i].Cursor = Cursors.Hand;
            }

            panel.Width = 305;
            panel.Height = box_top.Height + box_center.Height + box_bottom.Height;

            panel.Controls.Add(box_top);
            panel.Controls.Add(box_center);
            panel.Controls.Add(box_bottom);
            panel.Controls.Add(textLabel);
            panel.Controls.Add(labelPerform);
            panel.Controls.Add(labelStat);
            box_bottom.BringToFront();
            textLabel.BringToFront();
            labelPerform.BringToFront();
            labelStat.BringToFront();
            for (int i = 0; i < buttons.Length; i++)
            {
                panel.Controls.Add(buttons[i]);
                buttons[i].BringToFront();
            }
            flowPanel.Controls.Add(panel);
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            if (((PictureBox)sender).AccessibleName == "1")
            {
                ((PictureBox)sender).Image = Properties.Resources.dir_sett_off;
            }
            else if (((PictureBox)sender).AccessibleName == "2")
            {
                ((PictureBox)sender).Image = Properties.Resources.dir_find_off;
            }
            else if (((PictureBox)sender).AccessibleName == "3")
            {
                ((PictureBox)sender).Image = Properties.Resources.dir_target_off;
            }
        }

        private void button_MouseHover(object sender, EventArgs e)
        {
            if (((PictureBox)sender).AccessibleName == "1")
            {
                ((PictureBox)sender).Image = Properties.Resources.dir_sett_on;
            }
            else if (((PictureBox)sender).AccessibleName == "2")
            {
                ((PictureBox)sender).Image = Properties.Resources.dir_find_on;
            }
            else if (((PictureBox)sender).AccessibleName == "3")
            {
                ((PictureBox)sender).Image = Properties.Resources.dir_target_on;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).AccessibleName == "1")
            {
                ((PictureBox)sender).Image = Properties.Resources.dir_sett_on;
            }
            else if (((PictureBox)sender).AccessibleName == "2")
            {
                string[] sql_command = new string[3];
                // все задачи
                sql_command[0] = "AND task.status = 0 AND task.failed = 0 ";
                // выполненные задачи
                sql_command[1] = "AND task.status = 1 AND task.failed = 0 ";
                // проваленные задачи
                sql_command[2] = "AND task.failed = 1 ";

                for (int i = 0; i < sql_command.Length; i++)
                {
                    ((PictureBox)sender).Image = Properties.Resources.dir_find_set;
                    string commandText = string.Format("SELECT " +
                        "task.id_task, task.date, task.time, task.time_finish, direction.name, " +
                        "target.name, task.text, task.descr, task.failed, task.status FROM task " +
                        "INNER JOIN target ON task.id_target = target.id_target " +
                        "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                        "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                        "INNER JOIN user ON user_dir.id_user = user.id_user " +
                        "WHERE target.id_target = {0}" + sql_command[i], this.id_record);

                    SQLiteCommand command = new SQLiteCommand(commandText, ServiceData.connect);

                    SQLiteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<TaskBlock> tasks = new List<TaskBlock>();
                        if (i == 1)
                        {
                            boxStatus[0] = new PictureBox();
                            boxStatus[0].SizeMode = PictureBoxSizeMode.CenterImage;
                            boxStatus[0].Width = 430;
                            boxStatus[0].Height = 35;
                            boxStatus[0].Image = Properties.Resources.done_tasks;
                            flowTasks.Controls.Add(boxStatus[0]);
                            Design.heightContentTasks += boxStatus[0].Height;
                        }
                        else if (i == 2)
                        {
                            boxStatus[1] = new PictureBox();
                            boxStatus[1].SizeMode = PictureBoxSizeMode.CenterImage;
                            boxStatus[1].Width = 430;
                            boxStatus[1].Height = 35;
                            boxStatus[1].Image = Properties.Resources.fail_tasks;
                            flowTasks.Controls.Add(boxStatus[1]);
                            Design.heightContentTasks += boxStatus[1].Height;
                        }

                        while (reader.Read())
                        {
                            tasks.Add(new TaskBlock(
                                        flowTasks,
                                        Convert.ToInt32(ServiceData.reader.GetValue(0)),
                                        ServiceData.reader.GetString(1),
                                        ServiceData.reader.GetString(2),
                                        ServiceData.reader.GetString(3),
                                        ServiceData.reader.GetString(4),
                                        ServiceData.reader.GetString(5),
                                        ServiceData.reader.GetString(6),
                                        ServiceData.reader.GetValue(7).ToString(),
                                        Convert.ToInt32(ServiceData.reader.GetValue(8)),
                                        Convert.ToInt32(ServiceData.reader.GetValue(9))));
                        }
                    }
                }
            }
            else if (((PictureBox)sender).AccessibleName == "3")
            {
                ((PictureBox)sender).Image = Properties.Resources.dir_target_on;
            }
        }
    }
}
