using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Forms
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
        static public Color mainColor =  Color.FromArgb(Convert.ToInt32(Properties.Settings.Default.color[0]),
                                                        Convert.ToInt32(Properties.Settings.Default.color[1]),
                                                        Convert.ToInt32(Properties.Settings.Default.color[2]));
        static public Color mainColorOpacity = Color.FromArgb(
                                                        10,
                                                        Convert.ToInt32(Properties.Settings.Default.color[0]),
                                                        Convert.ToInt32(Properties.Settings.Default.color[1]),
                                                        Convert.ToInt32(Properties.Settings.Default.color[2]));

        private static Control panel;
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

        static public void HidePanel(Control movesPanel)
        {
            timer = new Timer();
            timer.Enabled = false;
            timer.Interval = 10;
            timer.Tick += Timer_Tick;

            panel = movesPanel;

            timer.Start();
        }

        private static void Timer_Tick(object sender, EventArgs e)
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
