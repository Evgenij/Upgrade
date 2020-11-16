using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Classes.Components
{
    class UITrackBar : UIComponent
    {
        private Panel panelBox;
        private PictureBox trackLine;
        private PictureBox trackButton;
        private Control labelValue;
        Enums.TypeTime typeTime;

        private int hour, minute;

        public UITrackBar(Form form, int x, int y, Control label, Enums.TypeTime type) 
        {
            labelValue = label;
            typeTime = type;
            trackLine = new PictureBox();
            trackButton = new PictureBox();
            panelBox = new Panel();

            trackLine.Image = Properties.Resources.track_line;
            trackLine.SizeMode = PictureBoxSizeMode.AutoSize;
            if (typeTime == Enums.TypeTime.minute) 
            {
                trackLine.SizeMode = PictureBoxSizeMode.CenterImage;
                trackLine.Width = 125;
            }
            trackLine.BackColor = Color.Transparent;
            trackLine.Top = 8;
            trackLine.SendToBack();

            trackButton.Image = Properties.Resources.track_button;
            trackButton.SizeMode = PictureBoxSizeMode.AutoSize;
            trackButton.Top = 1;
            trackButton.Left = 0;
            trackButton.BackColor = Color.Transparent;
            trackButton.Cursor = Cursors.Hand;
            trackButton.MouseUp += TrackButton_MouseUp;
            trackButton.MouseDown += TrackButton_MouseDown;
            trackButton.MouseMove += TrackButton_MouseMove;
            trackButton.BringToFront();

            panelBox.Width = trackLine.Width;
            panelBox.Height = 19;

            panelBox.Top = y;
            panelBox.Left = x;
            panelBox.BackColor = Color.White;
            panelBox.Controls.Add(trackButton);
            panelBox.Controls.Add(trackLine);
            form.Controls.Add(panelBox);
            panelBox.BringToFront();
        }

        private void TrackButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                if (trackButton.Left >= 0 && trackButton.Left+trackButton.Width <= trackLine.Width)
                {
                    trackButton.Left = trackButton.Left + (e.X - currentX);
                    if (typeTime == Enums.TypeTime.hour)
                    {
                        if (trackButton.Left % 6 == 0)
                        {
                            hour = trackButton.Left / 6;
                            if (hour.ToString().Length != 2)
                            {
                                labelValue.Text = "0" + hour.ToString();
                            }
                            else
                            {
                                labelValue.Text = hour.ToString();
                            }
                        }
                    }
                    else if (typeTime == Enums.TypeTime.minute) 
                    {
                        if (trackButton.Left % 2 == 0)
                        {
                            minute = trackButton.Left / 2;
                            if (minute < 60)
                            {
                                if (minute.ToString().Length != 2)
                                {
                                    labelValue.Text = "0" + minute.ToString();
                                }
                                else
                                {
                                    labelValue.Text = minute.ToString();
                                }
                            }
                        }
                    }
                }
                else if (trackButton.Left < 0) 
                {
                    trackButton.Left = 0;
                    isDragging = false;
                }
                else if (trackButton.Left + trackButton.Width > trackLine.Width)
                {
                    trackButton.Left = trackLine.Width - trackButton.Width;
                    isDragging = false;
                }
            }
        }

        private void TrackButton_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            currentX = e.X;
        }

        private void TrackButton_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}
