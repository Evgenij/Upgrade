using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Upgrade.Forms;

namespace Upgrade.Classes.Blocks
{
    class TargetBlock : Block
    {
        private Label labelPerform;
        private Label labelStat;
        private PictureBox[] buttons = new PictureBox[4];
        private string nameTarget;

        public TargetBlock(FlowLayoutPanel flowPanel, int id_target, string nameTarget) 
        {
            this.id_record = id_target;
            this.nameTarget = nameTarget;
            this.flowPanel = flowPanel;
            labelPerform = new Label();
            labelStat = new Label();

            textLabel.Left = 22;
            textLabel.Top = 20;
            textLabel.Width = 255;
            textLabel.Height = 21;
            textLabel.Font = GlobalData.GetFont(Enums.TypeFont.Bold, 20);
            for (int i = 0; i < nameTarget.Length; i++) 
            {
                if (i == 17) 
                {
                    textLabel.Text += Environment.NewLine;
                    textLabel.Height = 45 * (textLabel.Text.Length / 17);
                }
                textLabel.Text += nameTarget[i];
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
                "WHERE target.id_target = {0} AND user.id_user = {1}", id_record, User.userId);

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
                "WHERE target.id_target = {0} AND task.status = 1 AND user.id_user = {1}", id_record, User.userId);

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
            labelPerform.Font = GlobalData.GetFont(Enums.TypeFont.Bold, 33);
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
            labelStat.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 14);
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
                    buttons[i].Image = Properties.Resources.delete_off;
                    buttons[i].Left = textLabel.Left;
                }
                else if (i == 1)
                {
                    buttons[i].Image = Properties.Resources.dir_sett_off;
                    buttons[i].Left = 44;
                }
                else if (i == 2)
                {
                    buttons[i].Image = Properties.Resources.dir_find_off;
                    buttons[i].Left = 67;
                }
                else if (i == 3)
                {
                    buttons[i].Image = Properties.Resources.tar_task_off;
                    buttons[i].Left = 90;
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

            Design.heightContentTarget += panel.Height;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            if (((PictureBox)sender).AccessibleName == "1")
            {
                ((PictureBox)sender).Image = Properties.Resources.delete_off;
            }
            else if (((PictureBox)sender).AccessibleName == "2")
            {
                ((PictureBox)sender).Image = Properties.Resources.dir_sett_off;
            }
            else if (((PictureBox)sender).AccessibleName == "3")
            {
                ((PictureBox)sender).Image = Properties.Resources.dir_find_off;
            }
            else if (((PictureBox)sender).AccessibleName == "4")
            {
                ((PictureBox)sender).Image = Properties.Resources.tar_task_off;
            }
        }

        private void button_MouseHover(object sender, EventArgs e)
        {
            if (((PictureBox)sender).AccessibleName == "1")
            {
                ((PictureBox)sender).Image = Properties.Resources.delete_on;
            }
            else if (((PictureBox)sender).AccessibleName == "2")
            {
                ((PictureBox)sender).Image = Properties.Resources.dir_sett_on;
            }
            else if (((PictureBox)sender).AccessibleName == "3")
            {
                ((PictureBox)sender).Image = Properties.Resources.dir_find_on;
            }
            else if (((PictureBox)sender).AccessibleName == "4")
            {
                ((PictureBox)sender).Image = Properties.Resources.tar_task_on;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).AccessibleName == "1")
            {
                if (MessageBox.Show("Вы действительно хотите удалить цель?\n\n\"" + nameTarget + "\"",
                                "Сообщение", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ServiceData.commandText = @"DELETE FROM target WHERE id_target = @idTarget";
                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                    ServiceData.command.Parameters.AddWithValue("@idTarget", this.id_record);
                    ServiceData.command.ExecuteNonQuery();

                    Design.HidePanel(panel, flowPanel, Enums.TypeBlock.Target);
                }
            }
            else if (((PictureBox)sender).AccessibleName == "2")
            {
                GlobalData.changeTarget = true;
                WindowManager.idTarget = id_record;

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
            else if (((PictureBox)sender).AccessibleName == "3")
            {
                GlobalComponents.status_mark.Left = 900;
                GlobalData.id_target = id_record;
                Design.RefreshPanel(WindowManager.flowPanelTaskTarget);
                GlobalComponents.labelTarget.Text = nameTarget;
                Design.heightContentTaskTarget = 0;

                string commandText = string.Format("SELECT " +
                    "task.id_task, task.date, task.time, task.time_finish, direction.name, direction.color_mark, " +
                    "target.name, task.text, task.descr, task.failed, task.status FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE target.id_target = {0} AND task.status = 0 AND task.failed = 0 AND user.id_user = {1} ORDER BY task.date",
                    this.id_record, User.userId);

                SQLiteCommand command = new SQLiteCommand(commandText, ServiceData.connect);

                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    GlobalComponents.notFoundTaskTarget.Visible = false;     
                    List<TaskBlock> tasks = new List<TaskBlock>();

                    while (reader.Read())
                    {
                        tasks.Add(new TaskBlock(
                            WindowManager.flowPanelTaskTarget,
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetString(7),
                            reader.GetValue(8).ToString(),
                            reader.GetInt32(9),
                            reader.GetInt32(10)));
                    }
                }
                else
                {
                    GlobalComponents.notFoundTaskTarget.Visible = true;
                }

                if (WindowManager.flowPanelTaskTarget.Height < Design.heightContentTaskTarget)
                {
                    GlobalComponents.task_targetScrollTipTop.Visible = true;
                    GlobalComponents.task_targetScrollTipBottom.Visible = true;
                }
                else
                {
                    GlobalComponents.task_targetScrollTipTop.Visible = false;
                    GlobalComponents.task_targetScrollTipBottom.Visible = false;
                }
            }
            else if (((PictureBox)sender).AccessibleName == "2")
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
        }
    }
}
