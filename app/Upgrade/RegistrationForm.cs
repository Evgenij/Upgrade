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

namespace Upgrade
{
    public partial class RegistrationForm : Form
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

        Color color = Color.FromArgb(248, 252, 255);

        public RegistrationForm()
        {
            InitializeComponent();
            this.Load += RegistrationForm_Load;
            this.FormClosed += RegistrationForm_FormClosed;

            this.BackColor = color;

            login.BackColor = color;
            password.BackColor = color;
            email.BackColor = color;
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBService.CloseConnectionWithDB();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(-1, -1, 370, 565, 80, 80);
            SetWindowRgn(this.Handle, hRgn, true);
        }

        private void back_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chart_Click(object sender, EventArgs e)
        {
            DBService.ConnectToDB(@"database\2.db");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DBService.ReadRecords();
        }
    }
}
