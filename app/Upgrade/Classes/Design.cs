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

        private static Control panel;
        private static int start;
        private static int finish;

        private static Direction direction;

        static public void MovePanel(Control movesPanel, Direction dir, int s, int f) 
        {
            timer = new Timer();
            timer.Enabled = false;
            timer.Interval = 1;
            timer.Tick += Timer_Tick;

            panel = movesPanel;
            direction = dir;
            start = s;
            finish = f;

            timer.Start();
        }

        private static void Timer_Tick(object sender, EventArgs e)
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
                    }
                }
            }
        }
    }
}
