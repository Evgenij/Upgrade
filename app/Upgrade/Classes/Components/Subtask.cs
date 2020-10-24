using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Classes.Components
{
    class Subtask
    {
        private string text;

        private Panel panel;
        private PictureBox picture;
        private TextBox textBox;
        private Label labelAction;

        public Subtask(FlowLayoutPanel flowPanel) 
        {
            panel = new Panel();
            picture = new PictureBox();
            textBox = new TextBox();
            labelAction = new Label();

            picture.Image = Properties.Resources.check_small_off;
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
            picture.BackColor = Color.Transparent;
            picture.Top = 2;
            picture.BringToFront();

            textBox.Left = 25;
            textBox.Width = 180;
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = Color.White;
            textBox.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 16);
            textBox.ForeColor = Color.DarkGray;
            textBox.Text = "Подзадача...";
            textBox.Enter += TextBox_Enter;
            textBox.Leave += TextBox_Leave;
            textBox.TextChanged += TextBox_TextChanged; ;

            labelAction.Top = 2;
            labelAction.Width = 12;
            labelAction.Height = 20;
            labelAction.Left = textBox.Left + textBox.Width + 5;
            labelAction.Cursor = Cursors.Hand;
            labelAction.ForeColor = Color.DarkGray;
            labelAction.Text = "x";
            labelAction.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 14);
            labelAction.MouseHover += LabelAction_MouseHover;
            labelAction.MouseLeave += LabelAction_MouseLeave;
            labelAction.Click += LabelAction_Click;

            panel.Height = 23;
            panel.Width = 225;
            panel.Controls.Add(picture);
            panel.Controls.Add(textBox);
            panel.Controls.Add(labelAction);
            flowPanel.Controls.Add(panel);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            text = textBox.Text;
        }

        private void LabelAction_Click(object sender, EventArgs e)
        {
            text = "delete";
            panel.Dispose();
        }

        private void LabelAction_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.DarkGray;
        }

        private void LabelAction_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Red;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if(((TextBox)sender).Text == "")
            {
                ((TextBox)sender).ForeColor = Color.DarkGray;
                ((TextBox)sender).Font = GlobalData.GetFont(Enums.TypeFont.Regular, 16);
                ((TextBox)sender).Text = "Подзадача...";
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "Подзадача...")
            {
                ((TextBox)sender).Text = null;
                ((TextBox)sender).Font = GlobalData.GetFont(Enums.TypeFont.Regular, 16);
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        public string GetText() 
        {
            return text;
        }
    }
}
