using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Upgrade.Classes.Blocks
{
    class AchievBlock : Block
    {
        private TextBox labelCurrentScore, textBoxDescr;
        private Label currentLabel, labelFinalScore;
        private PictureBox icon, statusBox;
        private AltoControls.AltoButton[] statusLine = new AltoControls.AltoButton[2];


        public AchievBlock(FlowLayoutPanel flowPanel, 
                           int idAchiev, 
                           string nameAchiev,
                           string descr,
                           int currentScore,
                           int finalScore,
                           int statusAchiev) 
        {
            this.flowPanel = flowPanel;

            textBoxDescr = new TextBox();
            icon = new PictureBox();
            statusBox = new PictureBox();
            currentLabel = new Label();
            labelCurrentScore = new TextBox();
            labelFinalScore = new Label();

            icon.Width = 50;
            icon.Height = 50;
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.Load(@"achiev_icons\" + idAchiev.ToString() + ".png");
            icon.BackColor = Color.White;
            icon.Top = 25;
            icon.Left = 25;

            statusBox.SizeMode = PictureBoxSizeMode.AutoSize;
            if (statusAchiev == 0)
            {
                statusBox.Image = Properties.Resources.check_off;
            }
            else 
            {
                statusBox.Image = Properties.Resources.check_done;
            }
            statusBox.BackColor = Color.White;
            statusBox.Top = 25;

            textLabel.Left = icon.Width + icon.Left + 10;
            textLabel.Top = 45;
            textLabel.Width = 135;
            textLabel.Font = GlobalData.GetFont(Enums.TypeFont.Bold, 18);
            textLabel.Text = nameAchiev;
            textLabel.Multiline = true;
            textLabel.BackColor = Color.White;
            if (textLabel.Text.Length >= 14)
            {
                textLabel.Height = 44 * (textLabel.Text.Length / 14);
                textLabel.Top -= 15;
            }
            else
            {
                textLabel.Height = 21;
            }

            textBoxDescr.Left = 25;
            if (icon.Top + icon.Height > textLabel.Top + textLabel.Height)
            {
                textBoxDescr.Top = icon.Top + icon.Height + 20;
            }
            else 
            {
                textBoxDescr.Top = textLabel.Top + textLabel.Height + 20;
            }
            
            textBoxDescr.Width = 230;
            textBoxDescr.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 16);
            textBoxDescr.Text = descr;
            textBoxDescr.Multiline = true;
            textBoxDescr.BackColor = Color.White;
            textBoxDescr.ForeColor = Color.DarkGray;
            textBoxDescr.BorderStyle = BorderStyle.None;
            textBoxDescr.ReadOnly = true;
            textBoxDescr.Multiline = true;
            textBoxDescr.WordWrap = true;
            if (textBoxDescr.Text.Length >= 29)
            {
                textBoxDescr.Height = 42 * (textBoxDescr.Text.Length / 29);
            }
            else
            {
                textBoxDescr.Height = 21;
            }

            currentLabel.Top = textBoxDescr.Top + textBoxDescr.Height + 20;
            currentLabel.Left = icon.Left;
            currentLabel.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 14);
            currentLabel.ForeColor = Color.DarkGray;
            currentLabel.BackColor = Color.White;
            currentLabel.Width = 200;
            currentLabel.Text = "Текущий прогресс";

            statusLine[0] = new AltoControls.AltoButton();
            statusLine[0].Top = currentLabel.Top + currentLabel.Height;
            statusLine[0].Left = currentLabel.Left;
            statusLine[0].Inactive1 = System.Drawing.Color.FromArgb(Design.mainColor.R - 10, Design.mainColor.G - 10, Design.mainColor.B - 10);
            statusLine[0].Inactive2 = System.Drawing.Color.FromArgb(Design.mainColor.R - 10, Design.mainColor.G - 10, Design.mainColor.B - 10);
            statusLine[0].Active1 = System.Drawing.Color.FromArgb(Design.mainColor.R - 10, Design.mainColor.G - 10, Design.mainColor.B - 10);
            statusLine[0].Active2 = System.Drawing.Color.FromArgb(Design.mainColor.R - 10, Design.mainColor.G - 10, Design.mainColor.B - 10);
            statusLine[0].Stroke = true;
            statusLine[0].StrokeColor = System.Drawing.Color.FromArgb(Design.mainColor.R - 10, Design.mainColor.G - 10, Design.mainColor.B - 10);
            statusLine[0].Radius = 3;
            statusLine[0].Height = 7;
            statusLine[0].Width = (165 / finalScore) * currentScore;

            statusLine[1] = new AltoControls.AltoButton();
            statusLine[1].Top = currentLabel.Top + currentLabel.Height;
            statusLine[1].Left = statusLine[0].Left + statusLine[0].Width;
            statusLine[1].Inactive1 = System.Drawing.Color.LightGray;
            statusLine[1].Inactive2 = System.Drawing.Color.LightGray;
            statusLine[1].Active1 = System.Drawing.Color.LightGray;
            statusLine[1].Active2 = System.Drawing.Color.LightGray;
            statusLine[1].Stroke = true;
            statusLine[1].StrokeColor = System.Drawing.Color.LightGray;
            statusLine[1].Radius = 3;
            statusLine[1].Height = 7;
            statusLine[1].Width = 165 - statusLine[0].Width;

            labelCurrentScore.Left = 50;
            labelCurrentScore.Font = GlobalData.GetFont(Enums.TypeFont.Bold, 26);
            labelCurrentScore.ForeColor = Design.mainColor;
            labelCurrentScore.BackColor = Color.White;
            labelCurrentScore.TextAlign = HorizontalAlignment.Right;
            labelCurrentScore.BorderStyle = BorderStyle.None;
            labelCurrentScore.ReadOnly = true;
            labelCurrentScore.Text = currentScore.ToString();
            labelCurrentScore.Width = labelCurrentScore.Text.Length * 13;

            labelFinalScore.Font = GlobalData.GetFont(Enums.TypeFont.Bold, 14);
            labelFinalScore.ForeColor = Color.LightGray;
            labelFinalScore.BackColor = Color.White;
            labelFinalScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            labelFinalScore.Text = "/" + finalScore.ToString();
            labelFinalScore.Width = 35;

            box_top.Image = Properties.Resources.achiev_box_top;
            box_top.SizeMode = PictureBoxSizeMode.AutoSize;
            box_top.Top = 0;
            box_top.BackColor = Color.Transparent;

            box_center.Image = Properties.Resources.achiev_box_center;
            box_center.SizeMode = PictureBoxSizeMode.StretchImage;
            box_center.BackColor = Color.Transparent;
            box_center.Top = box_top.Height;
            box_center.Width = 280;
            box_center.Height = (currentLabel.Height + currentLabel.Top) - box_top.Height + 5;

            box_bottom.Image = Properties.Resources.achiev_box_bottom;
            box_bottom.SizeMode = PictureBoxSizeMode.AutoSize;
            box_bottom.BackColor = Color.Transparent;
            box_bottom.Top = box_top.Height + box_center.Height;

            labelFinalScore.Top = box_bottom.Top - 15;
            labelCurrentScore.Top = box_bottom.Top - 23;

            panel.Width = box_center.Width;
            panel.Height = box_top.Height + box_center.Height + box_bottom.Height + 4;
            statusBox.Left = panel.Width - statusBox.Width - 25;
            labelFinalScore.Left = panel.Width - labelFinalScore.Width - 20;
            labelCurrentScore.Left = labelFinalScore.Left - labelCurrentScore.Width;

            panel.Controls.Add(box_top);
            panel.Controls.Add(box_center);
            panel.Controls.Add(box_bottom);
            panel.Controls.Add(icon);
            panel.Controls.Add(statusBox);
            panel.Controls.Add(textLabel);
            panel.Controls.Add(textBoxDescr);
            panel.Controls.Add(currentLabel);
            panel.Controls.Add(statusLine[0]);
            panel.Controls.Add(statusLine[1]);
            panel.Controls.Add(labelCurrentScore);
            panel.Controls.Add(labelFinalScore);

            box_top.SendToBack();
            box_center.SendToBack();
            box_bottom.SendToBack();
            labelCurrentScore.BringToFront();


            flowPanel.Controls.Add(panel);
        }
    }
}
