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
        private static Timer timer;
        private static Point p;
        public static Color backColor = Color.FromArgb(248, 252, 255);
        public static Color mainColor;
        public static Color mainColorOpacity;

        public static int heightContentTasks = 0;
        public static int heightContentNotes = 0;
        public static int heightContentDirection = 0;
        public static int heightContentTarget = 0;
        public static int heightContentTaskTarget = 0;

        private static Control panel;
        private static FlowLayoutPanel flowParent;
        private static int start;
        private static int finish;

        private static Enums.Direction direction;

        static public void MovePanel(Control movesPanel, Enums.Direction dir, int s, int f) 
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

        static public void RefreshPanel(FlowLayoutPanel flowPanel)
        {
            flowParent = flowPanel;
            ClearFlowPanel();
        }

        private static void ClearFlowPanel() 
        {
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

        public static void SetMarkCurrentDay(AltoControls.AltoButton mark) 
        {
            if(DateTime.Now.DayOfWeek == DayOfWeek.Monday) 
            {
                mark.Left = 690;
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
            {
                mark.Left = 728;
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                mark.Left = 765;
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            {
                mark.Left = 801;
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                mark.Left = 838;
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                mark.Left = 875;
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                mark.Left = 913;
            }
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

                await WindowManager.SetPanelsMainWindow();
                WeeklyStatistic.Refresh();
            }
        }

        private static void Timer_TickMove(object sender, EventArgs e)
        {
            if (direction == Enums.Direction.Horizontal)
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
