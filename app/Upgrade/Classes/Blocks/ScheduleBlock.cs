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
    class ScheduleBlock : Block
    {
        private Label nameSched;
        private TextBox direct;
        private TextBox targetLabel;
        private TextBox descrLabel;
        private Label timeLabel;
        private Label time_range;
        private PictureBox deleteButton;

        private PictureBox[] daysPicture = new PictureBox[7];
        GlobalData.DayOfWeek[] days = new GlobalData.DayOfWeek[7];


        public ScheduleBlock(FlowLayoutPanel flowPanel,
                           int idShed,
                           string nameSchedule,
                           string nameDirect,
                           string directMark,
                           string target,
                           string textTask,
                           string descrTask,
                           string time,
                           string time_finish) 
        {
            id_record = idShed;
            this.flowPanel = flowPanel;

            nameSched = new Label();
            direct = new TextBox();
            targetLabel = new TextBox();
            timeLabel = new Label();
            time_range = new Label();
            deleteButton = new PictureBox();

            nameSched.Left = 30;
            nameSched.Top = 25;
            nameSched.Width = 348;
            nameSched.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 20);
            nameSched.BackColor = Color.White;
            nameSched.Text = nameSchedule;

            deleteButton.SizeMode = PictureBoxSizeMode.AutoSize;
            deleteButton.BackColor = Color.White;
            deleteButton.Image = Properties.Resources.deleteButton;
            deleteButton.Top = nameSched.Top;
            deleteButton.Left = nameSched.Left + nameSched.Width;
            deleteButton.Cursor = Cursors.Hand;
            deleteButton.Click += DeleteButton_Click;

            int step = 0;
            for (int i = 0; i < daysPicture.Length; i++)
            {
                days[i] = new GlobalData.DayOfWeek();
                days[i].SetIdDay(i+1);
                daysPicture[i] = new PictureBox();
                daysPicture[i].AccessibleName = i.ToString();
                daysPicture[i].SizeMode = PictureBoxSizeMode.AutoSize;
                daysPicture[i].BackColor = Color.White;
                daysPicture[i].Enabled = false;

                if (i == 0)
                {
                    daysPicture[i].Image = Properties.Resources.box_monday_off;
                }
                else if (i==1) 
                {
                    daysPicture[i].Image = Properties.Resources.box_tuesday_off;
                }
                else if (i == 2)
                {
                    daysPicture[i].Image = Properties.Resources.box_wednesday_off;
                }
                else if (i == 3)
                {
                    daysPicture[i].Image = Properties.Resources.box_thursday_off;
                }
                else if (i == 4)
                {
                    daysPicture[i].Image = Properties.Resources.box_friday_off;
                }
                else if (i == 5)
                {
                    daysPicture[i].Image = Properties.Resources.box_saturday_off;
                }
                else if (i == 6)
                {
                    daysPicture[i].Image = Properties.Resources.box_sunday_off;
                }

                if (i == 0)
                {
                    daysPicture[i].Left = nameSched.Left;
                }
                else 
                {
                    step += 53;
                    daysPicture[i].Left = nameSched.Left + step;
                }
                daysPicture[i].Top = nameSched.Top + nameSched.Height + 15;
                daysPicture[i].Cursor = Cursors.Hand;
                daysPicture[i].Click += dayBlock_Click;
            }

            List<int> setDays = new List<int>();

            string commandText = @"SELECT day.id_day
                FROM schedule 
                INNER JOIN sched_task ON sched_task.id_sched = schedule.id_sched
                INNER JOIN day ON day.id_day = sched_task.id_day
                INNER JOIN task ON task.id_task = sched_task.id_task
                INNER JOIN target ON task.id_target = target.id_target 
                INNER JOIN direction ON target.id_direct = direction.id_direct 
                INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct 
                INNER JOIN user ON user_dir.id_user = user.id_user 
                WHERE user.id_user = @user AND schedule.id_sched = @idSched";

            SQLiteCommand command = new SQLiteCommand(commandText, ServiceData.connect);
            command.Parameters.AddWithValue("@user", User.userId);
            command.Parameters.AddWithValue("@idSched", id_record);

            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    setDays.Add(reader.GetInt32(0));            
                }
            }

            if (setDays.Count != 0) 
            {
                for (int i = 0; i < days.Length; i++) 
                {
                    for (int j = 0; j < setDays.Count; j++) 
                    {
                        if (days[i].GetIdDay() == setDays[j]) 
                        {
                            if (i == 0)
                            {
                                daysPicture[i].Image = Properties.Resources.box_monday_on;
                            }
                            else if (i == 1)
                            {
                                daysPicture[i].Image = Properties.Resources.box_tuesday_on;
                            }
                            else if (i == 2)
                            {
                                daysPicture[i].Image = Properties.Resources.box_wednesday_on;
                            }
                            else if (i == 3)
                            {
                                daysPicture[i].Image = Properties.Resources.box_thursday_on;
                            }
                            else if (i == 4)
                            {
                                daysPicture[i].Image = Properties.Resources.box_friday_on;
                            }
                            else if (i == 5)
                            {
                                daysPicture[i].Image = Properties.Resources.box_saturday_on;
                            }
                            else if (i == 6)
                            {
                                daysPicture[i].Image = Properties.Resources.box_sunday_on;
                            }
                        }
                    }
                }
            }


            direct.BorderStyle = BorderStyle.None;
            direct.Left = nameSched.Left + 4;
            direct.Top = nameSched.Top + nameSched.Height + 58;
            direct.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 14);
            direct.ForeColor = System.Drawing.ColorTranslator.FromHtml(directMark);
            direct.BackColor = Color.White;
            direct.Text = nameDirect;
            direct.WordWrap = true;
            direct.ReadOnly = true;
            direct.MaximumSize = new Size(142, 18);
            direct.Width = 7 * direct.Text.Length + 5;

            targetLabel.BorderStyle = BorderStyle.None;
            targetLabel.Left = direct.Left + direct.Width;
            targetLabel.Top = direct.Top;
            targetLabel.Width = 120;
            targetLabel.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 14);
            targetLabel.ForeColor = Color.Gray;
            targetLabel.BackColor = Color.White;
            targetLabel.Text = "- " + target;
            targetLabel.WordWrap = true;
            targetLabel.ReadOnly = true;
            targetLabel.Width = 250 - direct.Width;

            textLabel.Left = direct.Left - 4;
            textLabel.Top = direct.Top + 20;
            textLabel.Width = 275;
            textLabel.Font = GlobalData.GetFont(Enums.TypeFont.Bold, 18);
            textLabel.Text = textTask;
            if (textLabel.Text.Length >= 28)
            {
                textLabel.Height = 42 * (textLabel.Text.Length / 28);
            }
            else
            {
                textLabel.Height = 21;
            }

            if (descrTask != "")
            {
                descrLabel = new TextBox();
                descrLabel.Left = textLabel.Left;
                descrLabel.Top = textLabel.Top + textLabel.Height + 10;
                descrLabel.Width = 300;
                descrLabel.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 14);
                descrLabel.BackColor = Color.White;
                descrLabel.ForeColor = Color.Gray;
                descrLabel.BorderStyle = BorderStyle.None;
                descrLabel.Multiline = true;
                descrLabel.ReadOnly = true;
                descrLabel.Text = descrTask;
                if (descrLabel.Text.Length >= 28)
                {
                    descrLabel.Height = 18 * (descrLabel.Text.Length / 28);
                }
                else
                {
                    descrLabel.Height = 18;
                }
            }

            timeLabel.Height = 27;
            timeLabel.Width = 74;
            timeLabel.Left = textLabel.Left + textLabel.Width + 20;
            timeLabel.Top = textLabel.Top - 25;
            timeLabel.Text = time;
            timeLabel.TextAlign = ContentAlignment.MiddleRight;
            timeLabel.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 26);
            timeLabel.ForeColor = Design.mainColor;
            timeLabel.BackColor = Color.White;

            time_range.Height = 27;
            time_range.Width = 110;
            time_range.Left = timeLabel.Left - 40;
            time_range.Top = timeLabel.Top + timeLabel.Height;
            time_range.Text = time + " - " + time_finish;
            time_range.TextAlign = ContentAlignment.MiddleRight;
            time_range.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 15);
            time_range.ForeColor = Color.Gray;
            time_range.BackColor = Color.White;

            box_top.Image = Properties.Resources.box_sched_top;
            box_top.SizeMode = PictureBoxSizeMode.AutoSize;
            box_top.Top = 0;
            box_top.BackColor = Color.Transparent;

            box_center.Image = Properties.Resources.box_sched_center;
            box_center.SizeMode = PictureBoxSizeMode.StretchImage;
            box_center.BackColor = Color.Transparent;
            box_center.Top = box_top.Height;
            box_center.Width = 420;
            box_center.Height = (nameSched.Height + 
                daysPicture[0].Height + direct.Height + textLabel.Height + 50) - box_top.Height + 5;

            box_bottom.Image = Properties.Resources.box_sched_bottom;
            box_bottom.SizeMode = PictureBoxSizeMode.AutoSize;
            box_bottom.BackColor = Color.Transparent;

            panel.Width = box_center.Width;
            panel.Controls.Add(box_top);
            panel.Controls.Add(box_center);
            panel.Controls.Add(box_bottom);
            panel.Controls.Add(nameSched);
            panel.Controls.Add(deleteButton);
            panel.Controls.Add(direct);
            panel.Controls.Add(targetLabel);
            panel.Controls.Add(textLabel);
            if (descrLabel != null)
            {
                panel.Controls.Add(descrLabel);
                box_center.Height += descrLabel.Height;
            }
            panel.Controls.Add(timeLabel);
            panel.Controls.Add(time_range);

            for (int i = 0; i < days.Length; i++)
            {
                panel.Controls.Add(daysPicture[i]);
            }

            box_bottom.Top = box_top.Height + box_center.Height;
            panel.Height = box_top.Height + box_center.Height + box_bottom.Height + 4;
            box_top.SendToBack();
            box_center.SendToBack();
            box_bottom.SendToBack();

            flowPanel.Controls.Add(panel);

            Design.heightContentShedule += panel.Height;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить расписание?\n\n\"" + nameSched.Text + "\"",
                                "Сообщение", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceData.commandText = @"DELETE FROM schedule WHERE id_sched = @idSched";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.Parameters.AddWithValue("@idSched", this.id_record);
                ServiceData.command.ExecuteNonQuery();

                Design.HidePanel(panel, flowPanel, Enums.TypeBlock.Schedule);
            }
        }

        private void dayBlock_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((PictureBox)sender).AccessibleName);
            if (id == 0)
            {
                days[id].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Понедельник);
            }
            else if (id == 1) 
            {
                days[id].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Вторник);
            }
            else if (id == 2)
            {
                days[id].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Среда);
            }
            else if (id == 3)
            {
                days[id].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Четверг);
            }
            else if (id == 4)
            {
                days[id].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Пятница);
            }
            else if (id == 5)
            {
                days[id].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Суббота);
            }
            else if (id == 6)
            {
                days[id].ChangeStatus(((PictureBox)sender), Enums.DayOfWeek.Воскресенье);
            }
        }
    }
}
