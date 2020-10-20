using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Upgrade.Classes;
using Upgrade.Classes.Components;

namespace Upgrade.Forms
{
    public partial class AddTaskForm : Form
    {
        [DllImport("Gdi32.dll")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect,
                                                      int nTopRect,
                                                      int nRightRect,
                                                      int nBottomRect,
                                                      int nWidthEllipse,
                                                      int nHeightEllipse);
        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        UITrackBar[] uiTrackBars = new UITrackBar[4];

        public AddTaskForm()
        {
            InitializeComponent();
            this.Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, this.Width, this.Height, 55, 55);
            SetWindowRgn(this.Handle, hRgn, true);

            addTaskButton.ForeColor = Design.mainColor;
            addTaskButton.Active1 = Design.mainColorOpacity;
            addTaskButton.Active2 = Design.mainColorOpacity;
            addTaskButton.StrokeColor = Design.mainColor;

            uiTrackBars[0] = new UITrackBar(this, 391, 389, taskStartHour, Enums.TypeTime.hour);
            uiTrackBars[1] = new UITrackBar(this, 391, 417, taskStartMinute, Enums.TypeTime.minute);
            uiTrackBars[2] = new UITrackBar(this, 618, 389, taskEndHour, Enums.TypeTime.hour);
            uiTrackBars[3] = new UITrackBar(this, 618, 417, taskEndMinute, Enums.TypeTime.minute);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
