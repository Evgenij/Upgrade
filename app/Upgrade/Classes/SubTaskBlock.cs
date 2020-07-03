using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Classes
{
    class SubTaskBlock
    {
        private Panel panel;
        private PictureBox check;
        private TextBox textLabel;

        public SubTaskBlock(Control flowPanel, string textSubTask)
        {
            panel = new Panel();
            check = new PictureBox();
            textLabel = new TextBox();

            panel.Width = 265;
            panel.BackColor = Color.Transparent;
            panel.Cursor = Cursors.Hand;
            panel.Click += Check_Click;

            check.AccessibleName = "undone";
            check.Image = Properties.Resources.check_small_off;
            check.SizeMode = PictureBoxSizeMode.AutoSize;
            check.BackColor = Color.White;
            check.Cursor = Cursors.Hand;
            check.MouseHover += Check_MouseHover;
            check.MouseLeave += Check_MouseLeave;
            check.Click += Check_Click;

            textLabel.Left = check.Left + check.Width + 11;
            textLabel.Top = check.Top;
            textLabel.Width = 240;
            textLabel.Font = GlobalData.GetFont(GlobalData.TypeFont.Standart, 11);
            textLabel.BackColor = Color.White;
            textLabel.ForeColor = Color.Gray;
            textLabel.Cursor = Cursors.Hand;
            textLabel.Click += Check_Click;
            textLabel.BorderStyle = BorderStyle.None;
            textLabel.Multiline = true;
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
            if (check.AccessibleName != "done")
            {
                check.Image = Properties.Resources.check_small_off;
            }
        }

        private void Check_MouseHover(object sender, EventArgs e)
        {
            if (check.AccessibleName != "done")
            {
                check.Image = Properties.Resources.check_small_on;
            }
        }

        private void Check_Click(object sender, EventArgs e)
        {
            if (check.AccessibleName == "undone")
            {
                check.AccessibleName = "done";
                check.Image = Properties.Resources.check_small_done;
            }
            else 
            {
                check.AccessibleName = "undone";
                check.Image = Properties.Resources.check_small_off;
            }

            // TODO: code for update data 
        }
    }
}
