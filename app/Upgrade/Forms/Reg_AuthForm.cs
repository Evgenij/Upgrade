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
using Upgrade.Forms;

namespace Upgrade
{
    public partial class Reg_AuthForm : Form
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

        public Reg_AuthForm()
        {
            InitializeComponent();
            this.Load += RegistrationForm_Load;
            this.FormClosed += RegistrationForm_FormClosed;

            this.BackColor = color;

            login_reg.BackColor = color;
            pass_reg.BackColor = color;
            email_reg.BackColor = color;

            panel_reg.BringToFront();
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBService.CloseConnectionWithDB();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(-1, -1, 370, 565, 80, 80);
            SetWindowRgn(this.Handle, hRgn, true);

            if (Properties.Settings.Default.remember_me == true)
            {
                remember.AccessibleName = "on";
                remember.Image = Properties.Resources.rem_1;
                login_auth.Text = Properties.Settings.Default.login;
                pass_auth.Text = Properties.Settings.Default.password;
            }
            else 
            {
                remember.AccessibleName = "off";
                remember.Image = Properties.Resources.rem_0;
            }

            // стилизация кнопки авторизации
            authorization.StrokeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            authorization.ForeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            authorization.Active1 = Color.FromArgb(10,
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            authorization.Active2 = Color.FromArgb(10,
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            // стилизация кнопки регистрации
            registration.StrokeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            registration.ForeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            registration.Active1 = Color.FromArgb(10,
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            registration.Active2 = Color.FromArgb(10,
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            // стилизация элементов формы
            panel_chart.BackColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            panel_back.BackColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            panel_exit.BackColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            label_auth_login.ForeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            label_auth_password.ForeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            label_for_reg.ForeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            label_reg_login.ForeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            label_reg_password.ForeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));

            label_reg_email.ForeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));
        }

        private void back_Click(object sender, EventArgs e)
        {
            Design.MovePanel(panel_reg, 0, 370);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DBService.ReadRecords();
        }

        private void RegistrationForm_Shown(object sender, EventArgs e)
        {
            DBService.ConnectToDB(@"database\2.db");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Design.MovePanel(panel_reg, 370, 0);
        }

        private void remember_Click(object sender, EventArgs e)
        {
            if (remember.AccessibleName == "off")
            {
                remember.AccessibleName = "on";
                remember.Image = Properties.Resources.rem_1;
                Properties.Settings.Default.remember_me = true;
            }
            else
            {
                remember.AccessibleName = "off";
                remember.Image = Properties.Resources.rem_0;
                Properties.Settings.Default.remember_me = false;
            }
            Properties.Settings.Default.Save();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (remember.AccessibleName == "off")
            {
                remember.AccessibleName = "on";
                remember.Image = Properties.Resources.rem_1;
                Properties.Settings.Default.remember_me = true;
            }
            else
            {
                remember.AccessibleName = "off";
                remember.Image = Properties.Resources.rem_0;
                Properties.Settings.Default.remember_me = false;
            }
            Properties.Settings.Default.Save();
        }

        private void authorization_Click(object sender, EventArgs e)
        {
            if (DBService.Authorization(login_auth.Text, pass_auth.Text)) 
            {
                if (Properties.Settings.Default.remember_me == true)
                {
                    Properties.Settings.Default.login = login_auth.Text;
                    Properties.Settings.Default.password = pass_auth.Text;
                    Properties.Settings.Default.Save();
                }
                this.Hide();
            }
        }

        private void registration_Click(object sender, EventArgs e)
        {
            if (DBService.Registration(login_reg.Text, pass_reg.Text, email_reg.Text)) 
            {
                this.Hide();
            }
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.DimGray;
        }

        private void label_remember_me_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));
        }

        private void label_remember_me_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.DimGray;
        }

        private void label_empty_email_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));
        }

        private void label_empty_email_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.DimGray;
        }
    }
}
