using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Classes
{
    class SubTaskBlock : Block
    {
        private PictureBox check;
        private TaskBlock taskBlock;

        public SubTaskBlock(TaskBlock parentTaskBlock, Control flowPanel, int id_subtask, string textSubTask, int status)
        {
            this.id_record = id_subtask;
            panel = new Panel();
            check = new PictureBox();
            textLabel = new TextBox();
            taskBlock = parentTaskBlock;

            panel.Width = 265;
            panel.BackColor = Color.Transparent;
            panel.Cursor = Cursors.Hand;
            panel.Click += Click;

            check.AccessibleName = "undone";
            if (taskBlock.GetStatus() == Enums.StatusTask.Done)
            {
                check.Image = Properties.Resources.check_small_done;
            }
            else if (taskBlock.GetStatus() == Enums.StatusTask.Failed)
            {
                check.Image = Properties.Resources.check_small_fail;
            }
            else 
            {
                if (status == 1)
                {
                    check.AccessibleName = "done";
                    check.Image = Properties.Resources.check_small_done;
                }
                else 
                {
                    check.Image = Properties.Resources.check_small_off;
                }
            }
            check.SizeMode = PictureBoxSizeMode.AutoSize;
            check.BackColor = Color.White;
            check.Cursor = Cursors.Hand;
            check.MouseHover += Check_MouseHover;
            check.MouseLeave += Check_MouseLeave;
            check.Click += Click;

            textLabel.Left = check.Left + check.Width + 11;
            textLabel.Top = check.Top;
            textLabel.Width = 240;
            textLabel.Font = GlobalData.GetFont(Enums.TypeFont.Standart, 11);
            textLabel.BackColor = Color.White;
            textLabel.ForeColor = Color.Gray;
            textLabel.Cursor = Cursors.Hand;
            textLabel.Click += Click;
            textLabel.BorderStyle = BorderStyle.None;
            textLabel.Multiline = true;
            textLabel.ReadOnly = true;
            textLabel.Text = textSubTask;
            if (textLabel.Text.Length >= 22)
            {
                if (textLabel.Text.Length / 22.0 > (textLabel.Text.Length / 22))
                {
                    textLabel.Height = 18 * ((textLabel.Text.Length / 22) * ((textLabel.Text.Length / 22) * 2));
                }
            }
            else
            {
                textLabel.Height = 18;
            }

            panel.Height = textLabel.Height;
            panel.Controls.Add(check);
            panel.Controls.Add(textLabel);
            flowPanel.Controls.Add(panel);
        }

        public int GetHeight() 
        {
            return panel.Height;
        }

        private void Check_MouseLeave(object sender, EventArgs e)
        {
            if (taskBlock.GetStatus() == Enums.StatusTask.Empty)
            {
                if (check.AccessibleName != "done")
                {
                    check.Image = Properties.Resources.check_small_off;
                }
            }
        }

        private void Check_MouseHover(object sender, EventArgs e)
        {
            if (taskBlock.GetStatus() == Enums.StatusTask.Empty)
            {
                if (check.AccessibleName != "done")
                {
                    check.Image = Properties.Resources.check_small_on;
                }
            }
        }

        private void Click(object sender, EventArgs e)
        {
            if (taskBlock.GetStatus() == Enums.StatusTask.Empty)
            {
                if (check.AccessibleName == "undone")
                {
                    check.AccessibleName = "done";
                    check.Image = Properties.Resources.check_small_done;

                    ServiceData.commandText = @"UPDATE subtask SET status = 1 WHERE id_subtask = @id_subtask";
                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                    ServiceData.command.Parameters.AddWithValue("@id_subtask", this.id_record);
                    ServiceData.command.ExecuteNonQuery();

                    taskBlock.AddSuccessSubtask();
                }
                else
                {
                    check.AccessibleName = "undone";
                    check.Image = Properties.Resources.check_small_off;
                    taskBlock.DeleteSuccessSubtasks();
                }
            }
        }
    }
}
