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
        private static Timer timer;
        private static Point p;

        private static Panel panel;
        private static int start;
        private static int finish;

        static public void MovePanel(Panel movesPanel, int s, int f) 
        {
            timer = new Timer();
            timer.Enabled = false;
            timer.Interval = 1;
            timer.Tick += Timer_Tick;

            panel = movesPanel;
            start = s;
            finish = f;

            timer.Start();
        }
        
        private static void Timer_Tick(object sender, EventArgs e)
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
    }
}
