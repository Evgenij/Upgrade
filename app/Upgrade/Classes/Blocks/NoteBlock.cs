using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Classes
{
    class NoteBlock : Block
    {
        private PictureBox buttonDelete;

        public NoteBlock(FlowLayoutPanel flowPanel, string textNote) 
        {
            buttonDelete = new PictureBox();
            buttonDelete.Image = Properties.Resources.block_delete_off;
            buttonDelete.SizeMode = PictureBoxSizeMode.AutoSize;
            buttonDelete.Left = 5;
            buttonDelete.Top = 31;
            buttonDelete.BackColor = Color.White;
            buttonDelete.Cursor = Cursors.Hand;
            //buttonDelete.MouseHover += BoxDelete_MouseHover;
            //buttonDelete.MouseLeave += BoxDelete_MouseLeave;
            //buttonDelete.Click += BoxDelete_Click;
            //buttonDelete.Controls.Add(boxDelete);

            textLabel.Left = 17;
            textLabel.Top = 20;
            textLabel.Width = 255;
            textLabel.Font = GlobalData.GetFont(GlobalData.TypeFont.Medium, 12);
            textLabel.BackColor = Color.White;
            textLabel.ForeColor = Color.Black;
            textLabel.BorderStyle = BorderStyle.None;
            textLabel.ReadOnly = true;
            textLabel.Multiline = true;
            textLabel.Text = textNote;
            if (textLabel.Text.Length >= 28)
            {
                textLabel.Height = 21 * (textLabel.Text.Length / 28);
            }
            else
            {
                textLabel.Height = 21;
            }

            box_top.Image = Properties.Resources.note_box_top;
            box_top.SizeMode = PictureBoxSizeMode.AutoSize;
            box_top.Top = 0;
            box_top.BackColor = Color.Transparent;

            box_center.Image = Properties.Resources.note_box_center;
            box_center.SizeMode = PictureBoxSizeMode.StretchImage;
            box_center.BackColor = Color.Transparent;
            box_center.Top = box_top.Height;
            box_center.Width = 295;
            box_center.Height = textLabel.Height + 10;

            box_bottom.Image = Properties.Resources.note_box_bottom;
            box_bottom.SizeMode = PictureBoxSizeMode.AutoSize;
            box_bottom.BackColor = Color.Transparent;
            box_bottom.Top = box_top.Height + box_center.Height - 1;

            panel.Width = 295;
            panel.Height = box_top.Height + box_center.Height + box_bottom.Height;

            panel.Controls.Add(textLabel);
            panel.Controls.Add(box_top);
            panel.Controls.Add(box_center);
            panel.Controls.Add(box_bottom);
            box_bottom.BringToFront();
            flowPanel.Controls.Add(panel);
        }
    }
}
