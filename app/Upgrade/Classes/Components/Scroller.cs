using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Classes
{
    class Scroller
    {
        private int value, multiplier;
        private int currentY;
        private bool isDragging = false;

        private readonly FlowLayoutPanel panel;
        private readonly PictureBox background;
        private readonly PictureBox scroller;
        private readonly PictureBox top_tip_back;
        private readonly PictureBox bottom_tip_back;
        private readonly PictureBox top_tip_scroll;
        private readonly PictureBox bottom_tip_scroll;

        public Scroller(TabPage tabPage, FlowLayoutPanel flowPanel, int heightContent)
        {
            panel = flowPanel;
            background = new PictureBox();
            scroller = new PictureBox();
            top_tip_back = new PictureBox();
            bottom_tip_back = new PictureBox();
            top_tip_scroll = new PictureBox();
            bottom_tip_scroll = new PictureBox();

            // -----------------
            top_tip_back.Image = Properties.Resources.tip_back_scroll;
            top_tip_back.SizeMode = PictureBoxSizeMode.AutoSize;
            top_tip_back.Location = new System.Drawing.Point(flowPanel.Left + flowPanel.Width, flowPanel.Top);
            // ---
            bottom_tip_back.Image = Properties.Resources.tip_back_scroll;
            bottom_tip_back.SizeMode = PictureBoxSizeMode.AutoSize;
            bottom_tip_back.Location = new System.Drawing.Point(flowPanel.Left + flowPanel.Width, flowPanel.Height + flowPanel.Top - bottom_tip_back.Height);

            background.Image = Properties.Resources.back_scroll;
            background.SizeMode = PictureBoxSizeMode.StretchImage;
            background.BackColor = Color.FromArgb(234, 234, 234);
            background.Location = new System.Drawing.Point(flowPanel.Left + flowPanel.Width, flowPanel.Top + top_tip_back.Height / 2);
            background.Width = 7;
            background.Height = flowPanel.Height - bottom_tip_back.Height;
            // -----------------


            // -----------------
            top_tip_scroll.Image = Properties.Resources.tip_scroll;
            top_tip_scroll.SizeMode = PictureBoxSizeMode.AutoSize;
            top_tip_scroll.Location = new System.Drawing.Point(flowPanel.Left + flowPanel.Width, flowPanel.Top);

            scroller.Image = Properties.Resources.scroller;
            scroller.SizeMode = PictureBoxSizeMode.StretchImage;
            scroller.BackColor = Color.FromArgb(189, 189, 189);
            scroller.Location = new System.Drawing.Point(flowPanel.Left + flowPanel.Width, flowPanel.Top + top_tip_scroll.Height / 2);
            scroller.Width = 7;

            Refresh(heightContent);

            scroller.Cursor = Cursors.Hand;
            scroller.MouseUp += Scroller_MouseUp;
            scroller.MouseDown += Scroller_MouseDown;
            scroller.MouseMove += Scroller_MouseMove;

            bottom_tip_scroll.Image = Properties.Resources.tip_scroll;
            bottom_tip_scroll.SizeMode = PictureBoxSizeMode.AutoSize;
            bottom_tip_scroll.Location = new System.Drawing.Point(scroller.Left, scroller.Top + scroller.Height - bottom_tip_scroll.Height / 2);

            tabPage.Controls.Add(top_tip_back);
            tabPage.Controls.Add(bottom_tip_back);
            tabPage.Controls.Add(background);
            tabPage.Controls.Add(top_tip_scroll);
            tabPage.Controls.Add(bottom_tip_scroll);
            tabPage.Controls.Add(scroller);

            bottom_tip_back.SendToBack();
            top_tip_back.SendToBack();
            top_tip_scroll.BringToFront();
            bottom_tip_scroll.BringToFront();
            scroller.BringToFront();
        }

        public void Refresh(int heightContent)
        {
            panel.VerticalScroll.Value = 0;
            value = 0;

            if (heightContent >= panel.Height)
            {
                //MessageBox.Show((panel.VerticalScroll.Maximum / panel.Height).ToString());
                scroller.Height = panel.Height - top_tip_scroll.Height;

                // вычисление множителя и длины скроллера
                //if (panel.VerticalScroll.Maximum <= panel.Height)
                //{
                //    multiplier = 1;
                //    scroller.Height = scroller.Height - (panel.VerticalScroll.Maximum - scroller.Height);
                //}
                //else if (panel.VerticalScroll.Maximum > panel.Height)
                //{
                //    multiplier = 2;
                //    scroller.Height = scroller.Height - ((panel.VerticalScroll.Maximum - scroller.Height) / 2);
                //}
                if ((heightContent / panel.Height) == 1)
                {
                    multiplier = 1;
                    scroller.Height = scroller.Height - (heightContent - panel.Height + (top_tip_scroll.Height * 2 + 10 * multiplier));
                }
                else if ((panel.VerticalScroll.Maximum / panel.Height) >= 2)
                {
                    multiplier = (panel.VerticalScroll.Maximum / panel.Height) + 1;
                    scroller.Height = scroller.Height - ((panel.VerticalScroll.Maximum - panel.Height - 5 * multiplier) / multiplier);
                }

                // установка верхнего положения скроллера
                top_tip_scroll.Location = new System.Drawing.Point(panel.Left + panel.Width, panel.Top);
                scroller.Location = new System.Drawing.Point(panel.Left + panel.Width, panel.Top + top_tip_scroll.Height / 2);
                bottom_tip_scroll.Location = new System.Drawing.Point(scroller.Left, scroller.Top + scroller.Height - bottom_tip_scroll.Height / 2);

                Show();
            }
            else 
            {
                Hide();
            }
        }

        private void Hide()
        {
            background.Visible = false;
            scroller.Visible = false;
            top_tip_back.Visible = false;
            bottom_tip_back.Visible = false;
            top_tip_scroll.Visible = false;
            bottom_tip_scroll.Visible = false;
        }
        private void Show()
        {
            background.Visible = true;
            scroller.Visible = true;
            top_tip_back.Visible = true;
            bottom_tip_back.Visible = true;
            top_tip_scroll.Visible = true;
            bottom_tip_scroll.Visible = true;
        }

        private void Scroller_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                if ((top_tip_scroll.Top >= panel.Top) && ((bottom_tip_scroll.Top + bottom_tip_scroll.Height) <= bottom_tip_back.Top + bottom_tip_back.Height))
                {
                    value = top_tip_scroll.Top - panel.Top;
                    top_tip_scroll.Top = top_tip_scroll.Top + (e.Y - currentY);
                    bottom_tip_scroll.Top = bottom_tip_scroll.Top + (e.Y - currentY);
                    scroller.Top = scroller.Top + (e.Y - currentY);
                    panel.VerticalScroll.Value = value * multiplier;
                }
                else if (top_tip_scroll.Top < panel.Top)
                {
                    top_tip_scroll.Top = panel.Top;
                    scroller.Top = top_tip_scroll.Top + top_tip_scroll.Height / 2;
                    bottom_tip_scroll.Top = scroller.Top + scroller.Height - bottom_tip_scroll.Height / 2;
                    isDragging = false;
                }
                else if (bottom_tip_scroll.Top + bottom_tip_scroll.Height > bottom_tip_back.Top + bottom_tip_back.Height)
                {
                    bottom_tip_scroll.Top = bottom_tip_back.Top;
                    scroller.Top = bottom_tip_scroll.Top + bottom_tip_scroll.Height / 2 - scroller.Height;
                    top_tip_scroll.Top = scroller.Top - top_tip_scroll.Height / 2;
                    isDragging = false;
                }
            }
        }

        private void Scroller_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            currentY = e.Y;
        }

        private void Scroller_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}
