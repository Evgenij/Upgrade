using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

            login_auth.BackColor = color;
            pass_auth.BackColor = color;
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
            MessageBox.Show(
                     "Ваш регистрационный код - " + (GlobalData.RegistrationCode = GlobalData.GererateCode()) + 
                     "\nОн необходим для восстановления доступа к аккаунту, если вы забудете пароль для входа.",
                     "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label_reg_email.Text = "регистрационный код";
            email_reg.Enabled = false;
            email_reg.Font = new Font("PF DinDisplay Pro Medium", 12);
            email_reg.ForeColor = Color.Black;
            email_reg.Text = GlobalData.RegistrationCode;
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
            if (label_reg_email.Text == "электронная почта")
            {
                if (DBService.Registration(login_reg.Text, pass_reg.Text, email_reg.Text))
                {
                    panel_reg.Visible = false;
                    panel_reg_code.BringToFront();
                    panel_reg_code.Visible = true;
                }
            }
            else 
            {
                if (DBService.Registration(login_reg.Text, pass_reg.Text, ""))
                {
                    MessageBox.Show("Зарегались, трали-вали");
                }
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
            ((Label)sender).ForeColor = Color.Gray;
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
            ((Label)sender).ForeColor = Color.Gray;
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
            ((Label)sender).ForeColor = Color.Gray;
        }

        private void eye_Click(object sender, EventArgs e)
        {
            if (eye.AccessibleName == "off")
            {
                eye.AccessibleName = "on";
                eye.Image = Properties.Resources.eye_on;
                pass_auth.Top += 1;
                pass_auth.ForeColor = Color.Gray;
                pass_auth.PasswordChar = '●';
            }
            else
            {
                eye.AccessibleName = "off";
                eye.Image = Properties.Resources.eye_off;
                pass_auth.Top -= 1;
                if (pass_auth.Text == "введите пароль")
                {
                    pass_auth.ForeColor = Color.Gray;
                }
                else
                {
                    pass_auth.ForeColor = Color.Black;
                }

                pass_auth.PasswordChar = '\0';
            }
        }

        private new void Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "введите ваш псевдоним" ||
                ((TextBox)sender).Text == "введите пароль" ||
                ((TextBox)sender).Text == "введите email" ||
                ((TextBox)sender).Text == "ваш код")
            {
                ((TextBox)sender).Text = null;
                ((TextBox)sender).Font = new Font("PF DinDisplay Pro Medium", 12);
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        private new void Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).PasswordChar = '\0';
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Font = new Font("PF DinDisplay Pro", 12);
                if (((TextBox)sender).Name == "login_auth" || ((TextBox)sender).Name == "login_reg")
                {
                    ((TextBox)sender).Text = "введите ваш псевдоним";
                }
                else if (((TextBox)sender).Name == "pass_auth" || ((TextBox)sender).Name == "pass_reg")
                {
                    ((TextBox)sender).Text = "введите пароль";
                }
                else if (((TextBox)sender).Name == "reg_code") 
                {
                    ((TextBox)sender).Text = "ваш код";
                }
                else
                {
                    ((TextBox)sender).Text = "введите email";
                }
            }
        }

        private void chart_Click(object sender, EventArgs e)
        {
            if (MailSender.SendMail("iermolienko.00@mail.ru", "Подтверждение регистрации",
                "<h2>Код подтверждения</h2> " +
                "<span>34538</span>"))
            {
                MessageBox.Show("success!");
            }
            else
            {
                MessageBox.Show("error...");
            }
        }

        private void label_reg_later_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.FromArgb(
                Convert.ToInt32(Properties.Settings.Default.color[0]),
                Convert.ToInt32(Properties.Settings.Default.color[1]),
                Convert.ToInt32(Properties.Settings.Default.color[2]));
        }

        private void label_reg_later_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Gray;
        }

        private void label_reg_later_Click(object sender, EventArgs e)
        {
            //
        }

        private void accept_code_reg_Click(object sender, EventArgs e)
        {
            ServiceData.commandText = @"SELECT * FROM user WHERE login = @login AND password = @password AND reg_code = @code";
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
            ServiceData.command.Parameters.AddWithValue("@login", login_reg.Text);
            ServiceData.command.Parameters.AddWithValue("@password", pass_reg.Text);
            ServiceData.command.Parameters.AddWithValue("@code", reg_code.Text);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                MessageBox.Show("Всьо чьотка!");
            }
            else 
            {
                MessageBox.Show("Шота ты ни тот код ввёл, праверь ищьо раз");
            }
        }
    }
}
