using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Classes
{
    class Design
    {
        public enum Direction
        {
            Horizontal,
            Vertical
        }

        private static Timer timer;
        private static Point p;
        static public Color backColor = Color.FromArgb(248, 252, 255);
        static public Color mainColor;
        static public Color mainColorOpacity;

        private static Control panel;
        private static FlowLayoutPanel flowParent;
        private static int start;
        private static int finish;

        private static Direction direction;

        static public void MovePanel(Control movesPanel, Direction dir, int s, int f) 
        {
            timer = new Timer();
            timer.Enabled = false;
            timer.Interval = 1;
            timer.Tick += Timer_TickMove;

            panel = movesPanel;

            direction = dir;
            start = s;
            finish = f;

            timer.Start();
        }

        static public void HidePanel(Control hidingPanel, FlowLayoutPanel flowPanel)
        {
            timer = new Timer();
            timer.Enabled = false;
            timer.Interval = 10;
            timer.Tick += Timer_Tick;

            panel = hidingPanel;
            flowParent = flowPanel;

            timer.Start();
        }

        private static void ClearFlowPanel() 
        {
            //while (flowParent.Controls.Count > 0) flowParent.Controls.RemoveAt(0);

            flowParent.SuspendLayout();
            if (flowParent.Controls.Count > 0)
            {
                for (int i = (flowParent.Controls.Count - 1); i >= 0; i--)
                {
                    Control c = flowParent.Controls[i];
                    c.Dispose();
                }
                GC.Collect();
            }
            flowParent.ResumeLayout();
        }

        private static async void Timer_Tick(object sender, EventArgs e)
        {
            if (panel.Width != 0)
            {
                panel.Width -= 10;
            }
            else 
            {
                panel.Dispose();
                timer.Stop();
                timer.Dispose();
                ClearFlowPanel();

                await WindowManager.CreateMainWindow(flowParent, WindowManager.TypeBlock.Tasks);
            }
        }

        private static void Timer_TickMove(object sender, EventArgs e)
        {
            if (direction == Direction.Horizontal)
            {
                if (start > finish)
                {
                    if (panel.Location.X != finish)
                    {
                        p = new Point(panel.Location.X - 10, panel.Location.Y);
                        panel.Location = p;
                    }
                    else
                    {
                        timer.Stop();
                        timer.Dispose();
                    }
                }
                else
                {
                    if (panel.Location.X != finish)
                    {
                        p = new Point(panel.Location.X + 10, panel.Location.Y);
                        panel.Location = p;
                    }
                    else
                    {
                        timer.Stop();
                        timer.Dispose();
                    }
                }
            }
            else 
            {
                if (start > finish)
                {
                    if (panel.Location.Y != finish)
                    {
                        p = new Point(panel.Location.X, panel.Location.Y - 5);
                        panel.Location = p;
                    }
                    else
                    {
                        timer.Stop();
                        timer.Dispose();
                    }
                }
                else
                {
                    if (panel.Location.Y != finish)
                    {
                        p = new Point(panel.Location.X, panel.Location.Y + 5);
                        panel.Location = p;
                    }
                    else
                    {
                        timer.Stop();
                        timer.Dispose();
                    }
                }
            }
        }
    }
}
