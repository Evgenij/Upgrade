using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Upgrade.Classes;

namespace Upgrade.Forms
{
    class TaskBlock
    {
        private Panel panel;
        private PictureBox box_top;
        private PictureBox box_center;
        private PictureBox box_bottom;
        private PictureBox line;
        private PictureBox more;
        private PictureBox check;
        private Label date;
        private Label day;
        private Label direct;
        private Label target;
        private TextBox text;

        public TaskBlock(FlowLayoutPanel flowPanel) 
        {
            panel = new Panel();
            box_top = new PictureBox();
            box_center = new PictureBox();
            box_bottom = new PictureBox();
            line = new PictureBox();
            more = new PictureBox();
            check = new PictureBox();
            date = new Label();
            day = new Label();
            direct = new Label();
            target = new Label();
            text = new TextBox();

            date.Left = 24;
            date.Top = 22;
            date.Width = 80;
            date.Font = GlobalData.GetFont(GlobalData.TypeFont.Standart, 12);
            date.ForeColor = Design.mainColor;
            date.Text = "18.05.2020";

            day.Left = 110;
            day.Top = 22;
            day.Width = 120;
            day.Font = GlobalData.GetFont(GlobalData.TypeFont.Standart, 12);
            day.ForeColor = Color.Gray;
            day.Text = "Воскресенье";

            direct.Left = 66;
            direct.Top = 49;
            direct.Font = GlobalData.GetFont(GlobalData.TypeFont.Standart, 11);
            direct.ForeColor = Design.mainColor;
            direct.Text = "Направление";
            direct.Width = 9 * direct.Text.Length - 7;

            target.Left = direct.Left + direct.Width;
            target.Top = 49;
            target.Width = 120;
            target.Font = GlobalData.GetFont(GlobalData.TypeFont.Standart, 11);
            target.ForeColor = Color.Gray;
            target.Text = "- Цель";

            text.Left = 65;
            text.Top = 69;
            text.Width = 255;
            text.Font = GlobalData.GetFont(GlobalData.TypeFont.Medium, 14);
            text.ForeColor = Color.Black;
            text.BorderStyle = BorderStyle.None;
            text.Multiline = true;
            text.Text += "Thfgjfgcbngblfhvktnhvkxthjvgxjhrtvbmxgtbjfnfcmbcfgb";
            if (text.Text.Length >= 28)
            {
                text.Height = 45;
            }

            box_top.Image = Properties.Resources.task_box_top;
            box_top.SizeMode = PictureBoxSizeMode.AutoSize;
            box_top.Top = 0;

            box_center.Image = Properties.Resources.task_box_center;
            box_center.SizeMode = PictureBoxSizeMode.StretchImage;
            box_center.Width = 430;
            if (text.Text.Length >= 28)
            {
                box_center.Height = 70;
            }
            else
            {
                box_center.Height = 48;
            }
            box_center.Top = box_top.Height;

            box_bottom.Image = Properties.Resources.task_box_bottom;
            box_bottom.SizeMode = PictureBoxSizeMode.AutoSize;
            box_bottom.Top = box_top.Height + box_center.Height;

            line.Image = Properties.Resources.task_line;
            line.Left = 165;
            line.Top = 35;
            line.Width = 220;
            line.Height = 1;

            more.Image = Properties.Resources.more_off;
            more.SizeMode = PictureBoxSizeMode.CenterImage;
            more.Height = 20;
            more.Width = 10;
            more.Left = 398;
            more.Top = 25;
            more.Cursor = Cursors.Hand;
            more.MouseHover += More_MouseHover;
            more.MouseLeave += More_MouseLeave;

            check.Image = Properties.Resources.check_off;
            check.SizeMode = PictureBoxSizeMode.AutoSize;
            check.Left = 28;
            check.Top = 51;
            check.Cursor = Cursors.Hand;
            check.MouseHover += Check_MouseHover;
            check.MouseLeave += Check_MouseLeave;
            check.Click += Check_Click;

            panel.Width = 430;
            panel.Height = box_top.Height + box_center.Height + box_bottom.Height;

            panel.Controls.Add(date);
            panel.Controls.Add(day);
            panel.Controls.Add(direct);
            panel.Controls.Add(target);
            panel.Controls.Add(text);
            panel.Controls.Add(line);
            panel.Controls.Add(more);
            panel.Controls.Add(check);
            panel.Controls.Add(box_top);
            panel.Controls.Add(box_center);
            panel.Controls.Add(box_bottom);
            flowPanel.Controls.Add(panel);
        }

        private void Check_MouseLeave(object sender, EventArgs e)
        {
            check.Image = Properties.Resources.check_off;
        }

        private void Check_MouseHover(object sender, EventArgs e)
        {
            check.Image = Properties.Resources.check_on;
        }

        private void Check_Click(object sender, EventArgs e)
        {
            Design.HidePanel(panel);
            GlobalData.LightenColor(Color.FromArgb(100,40,60));
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
