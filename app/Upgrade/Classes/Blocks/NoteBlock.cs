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
    class NoteBlock : Block
    {
        private PictureBox buttonDelete;

        public NoteBlock(FlowLayoutPanel flowPanel, int id_note, string textNote) 
        {
            this.id_record = id_note;
            this.flowPanel = flowPanel;

            buttonDelete = new PictureBox();
            buttonDelete.Image = Properties.Resources.delete_off;
            buttonDelete.SizeMode = PictureBoxSizeMode.AutoSize;
            buttonDelete.Left = 260;
            buttonDelete.Top = 22;
            buttonDelete.BackColor = Color.White;
            buttonDelete.Cursor = Cursors.Hand;
            buttonDelete.MouseHover += ButtonDelete_MouseHover;
            buttonDelete.MouseLeave += ButtonDelete_MouseLeave;
            buttonDelete.Click += ButtonDelete_Click;
            panel.Controls.Add(buttonDelete);

            textLabel.Left = 20;
            textLabel.Top = 20;
            textLabel.Width = 225;
            textLabel.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 16);
            textLabel.BackColor = Color.White;
            textLabel.ForeColor = Color.Black;
            textLabel.BorderStyle = BorderStyle.None;
            textLabel.ReadOnly = true;
            textLabel.Multiline = true;
            textLabel.Text = textNote;
            if (textLabel.Text.Length >= 26)
            {
                textLabel.Height = 42 * (textLabel.Text.Length / 26);
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
            box_center.Height = textLabel.Height + 5;

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

            Design.heightContentNotes += panel.Height;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            //Design.heightContentNotes = 0;

            if (MessageBox.Show("Вы действительно хотите удалить заметку?\n\n\"" + textLabel.Text + "\"",
                                "Сообщение", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceData.commandText = @"DELETE FROM note WHERE id_note = @id_note";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.Parameters.AddWithValue("@id_note", this.id_record);
                ServiceData.command.ExecuteNonQuery();

                Design.HidePanel(panel, flowPanel, Enums.TypeBlock.Note);
            }

            //MessageBox.Show(Design.heightContentNotes.ToString());
        }

        private void ButtonDelete_MouseLeave(object sender, EventArgs e)
        {
            buttonDelete.Image = Properties.Resources.delete_off;
        }

        private void ButtonDelete_MouseHover(object sender, EventArgs e)
        {
            buttonDelete.Image = Properties.Resources.delete_on;
        }
    }
}
