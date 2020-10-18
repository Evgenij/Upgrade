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
    class DirectionBlock : Block
    {
        private Label labelPerform;
        private Label labelStat;
        private static AltoControls.AltoButton colorMark;
        private PictureBox[] buttons = new PictureBox[3];

        public DirectionBlock(FlowLayoutPanel flowPanel,
                              int id_direct, 
                              string nameDirect, 
                              string mark) 
        {
            this.id_record = id_direct;
            labelPerform = new Label();
            labelStat = new Label();

            textLabel.Left = 22;
            textLabel.Top = 20;
            textLabel.Width = 255;
            textLabel.Height = 21;
            textLabel.Font = GlobalData.GetFont(Enums.TypeFont.Bold, 20);
            for (int i = 0; i < nameDirect.Length; i++)
            {
                if (i == 19)
                {
                    textLabel.Text += Environment.NewLine;
                    textLabel.Height = 45 * (textLabel.Text.Length / 19);
                }
                textLabel.Text += nameDirect[i];
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
                "WHERE direction.id_direct = {0}", id_record);

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
                "WHERE direction.id_direct = {0} AND task.status = 1", id_record);

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
                    buttons[i].Image = Properties.Resources.dir_sett_off;
                    buttons[i].Left = box_center.Width - buttons[i].Width - 22;
                }
                else if (i == 1)
                {
                    buttons[i].Image = Properties.Resources.dir_find_off;
                    buttons[i].Left = box_center.Width - buttons[i].Width - 45;
                }
                else if (i == 2)
                {
                    buttons[i].Image = Properties.Resources.dir_target_off;
                    buttons[i].Left = box_center.Width - buttons[i].Width - 69;
                }

                buttons[i].MouseHover += button_MouseHover;
                buttons[i].MouseLeave += button_MouseLeave;
                buttons[i].Click += button_Click;
                buttons[i].Cursor = Cursors.Hand;
            }

            colorMark = new AltoControls.AltoButton();
            colorMark.Top = box_bottom.Top - 10;
            colorMark.Left = textLabel.Left + 4;
            colorMark.Inactive1 = System.Drawing.ColorTranslator.FromHtml(mark);
            colorMark.Inactive2 = System.Drawing.ColorTranslator.FromHtml( mark);
            colorMark.Active1 = System.Drawing.ColorTranslator.FromHtml(mark);
            colorMark.Active2 = System.Drawing.ColorTranslator.FromHtml(mark);
            colorMark.Stroke = true;
            colorMark.StrokeColor = System.Drawing.ColorTranslator.FromHtml(mark);
            colorMark.Radius = 4;
            colorMark.Width = 60;
            colorMark.Height = 10;
            //colorMark.Cursor = Cursors.Hand;

            panel.Width = 305;
            panel.Height = box_top.Height + box_center.Height + box_bottom.Height;

            panel.Controls.Add(box_top);
            panel.Controls.Add(box_center);
            panel.Controls.Add(box_bottom);
            panel.Controls.Add(textLabel);
            panel.Controls.Add(colorMark);
            panel.Controls.Add(labelPerform);
            panel.Controls.Add(labelStat);
            box_bottom.BringToFront();
            textLabel.BringToFront();
            colorMark.BringToFront();
            labelPerform.BringToFront();
            labelStat.BringToFront();
            for (int i = 0; i < buttons.Length; i++)
            {
                panel.Controls.Add(buttons[i]);
                buttons[i].BringToFront();
            }
            flowPanel.Controls.Add(panel);

            Design.heightContentDirection += panel.Height;
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
                Design.heightContentTarget = 0;
                Design.RefreshPanel(WindowManager.flowPanelTarget);
                GlobalComponents.labelDirect.Text = this.textLabel.Text;

                ((PictureBox)sender).Image = Properties.Resources.dir_find_set;

                string commandText = string.Format("SELECT target.id_target, target.name FROM target " +
                    "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                    "WHERE direction.id_direct = {0}", this.id_record);

                SQLiteCommand command = new SQLiteCommand(commandText, ServiceData.connect);

                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    List<TargetBlock> targets = new List<TargetBlock>();
                    while (reader.Read())
                    {
                        targets.Add(new TargetBlock(WindowManager.flowPanelTarget, reader.GetInt32(0), reader.GetString(1)));   
                    }
                }
                GlobalData.scroller_target.Refresh(Design.heightContentTarget);

                if (Design.heightContentTarget == 0)
                {
                    GlobalComponents.notFoundTarget.Visible = true;
                }
                else
                {
                    GlobalComponents.notFoundTarget.Visible = false;
                }
            }
            else if (((PictureBox)sender).AccessibleName == "3")
            {
                ((PictureBox)sender).Image = Properties.Resources.dir_target_on;

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
}
