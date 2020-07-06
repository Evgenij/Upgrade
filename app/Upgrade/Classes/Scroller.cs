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
        private const int margin = 6;

        private int value, multiplier;
        private int currentY;
        private bool isDragging = false; 

        private FlowLayoutPanel panel;
        private PictureBox background, scroller;
        private PictureBox top_tip_back, bottom_tip_back;
        private PictureBox top_tip_scroll, bottom_tip_scroll;

        public Scroller(TabPage tabPage, FlowLayoutPanel flowPanel) 
        {
            panel = flowPanel;

            if (panel.VerticalScroll.Maximum > 100)
            {
                background = new PictureBox();
                scroller = new PictureBox();
                top_tip_back = new PictureBox();
                bottom_tip_back = new PictureBox();
                top_tip_scroll = new PictureBox();
                bottom_tip_scroll = new PictureBox();

                // -----------------
                top_tip_back.Image = Properties.Resources.tip_back_scroll;
                top_tip_back.SizeMode = PictureBoxSizeMode.AutoSize;
                top_tip_back.Location = new System.Drawing.Point(flowPanel.Left + flowPanel.Width + margin, flowPanel.Top);
                // ---
                bottom_tip_back.Image = Properties.Resources.tip_back_scroll;
                bottom_tip_back.SizeMode = PictureBoxSizeMode.AutoSize;
                bottom_tip_back.Location = new System.Drawing.Point(flowPanel.Left + flowPanel.Width + margin, flowPanel.Height + flowPanel.Top - bottom_tip_back.Height);

                background.Image = Properties.Resources.back_scroll;
                background.SizeMode = PictureBoxSizeMode.StretchImage;
                background.BackColor = Color.FromArgb(234, 234, 234);
                background.Location = new System.Drawing.Point(flowPanel.Left + flowPanel.Width + margin, flowPanel.Top + top_tip_back.Height / 2);
                background.Width = 7;
                background.Height = flowPanel.Height - bottom_tip_back.Height;
                // -----------------


                // -----------------
                top_tip_scroll.Image = Properties.Resources.tip_scroll;
                top_tip_scroll.SizeMode = PictureBoxSizeMode.AutoSize;
                top_tip_scroll.Location = new System.Drawing.Point(flowPanel.Left + flowPanel.Width + margin, flowPanel.Top);

                scroller.Image = Properties.Resources.scroller;
                scroller.SizeMode = PictureBoxSizeMode.StretchImage;
                scroller.BackColor = Color.FromArgb(189, 189, 189);
                scroller.Location = new System.Drawing.Point(flowPanel.Left + flowPanel.Width + margin, flowPanel.Top + top_tip_scroll.Height / 2);
                scroller.Width = 7;

                Refresh();
                
                scroller.Cursor = Cursors.Hand;
                scroller.MouseUp += Scroller_MouseUp;
                scroller.MouseDown += Scroller_MouseDown;
                scroller.MouseMove += Scroller_MouseMove;

                bottom_tip_scroll.Image = Properties.Resources.tip_scroll;
                bottom_tip_scroll.SizeMode = PictureBoxSizeMode.AutoSize;
                bottom_tip_scroll.Location = new System.Drawing.Point(scroller.Left, scroller.Top + scroller.Height - bottom_tip_scroll.Height / 2);
                // -----------------

                tabPage.Controls.Add(scroller);
                tabPage.Controls.Add(top_tip_back);
                tabPage.Controls.Add(bottom_tip_back);
                tabPage.Controls.Add(top_tip_scroll);
                tabPage.Controls.Add(bottom_tip_scroll);
                tabPage.Controls.Add(background);

                background.BringToFront();
                top_tip_scroll.BringToFront();
                bottom_tip_scroll.BringToFront();
                scroller.BringToFront();
            }
        }

        public void Refresh() 
        {
            panel.VerticalScroll.Value = 0;
            value = 0;
            
            scroller.Height = panel.Height - top_tip_scroll.Height;
            // вычисление множителя и длины скроллера
            if (panel.VerticalScroll.Maximum <= scroller.Height)
            {
                multiplier = 1;
                scroller.Height = scroller.Height - (panel.VerticalScroll.Maximum - scroller.Height);
            }
            else
            {
                multiplier = 2;
                scroller.Height = scroller.Height - ((panel.VerticalScroll.Maximum - scroller.Height) / 2);
            }

            // установка верхнего положения скроллера
            top_tip_scroll.Location = new System.Drawing.Point(panel.Left + panel.Width + margin, panel.Top);
            scroller.Location = new System.Drawing.Point(panel.Left + panel.Width + margin, panel.Top + top_tip_scroll.Height / 2);
            bottom_tip_scroll.Location = new System.Drawing.Point(scroller.Left, scroller.Top + scroller.Height - bottom_tip_scroll.Height / 2);
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
