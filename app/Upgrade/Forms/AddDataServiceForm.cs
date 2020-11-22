using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Upgrade.Classes;
using Upgrade.Classes.Components;

namespace Upgrade.Forms
{
    public partial class AddDataServiceForm : Form
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

        List<Service> services = new List<Service>();

        public AddDataServiceForm()
        {
            InitializeComponent();
        }

        private void AddDataService_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, this.Width, this.Height, 55, 55);
            SetWindowRgn(this.Handle, hRgn, true);

            SetIconsServices();

            //for (int i = 0; i < services.Length; i++) 
            //{
            //    services[i] = new Service(flowPanel, i + 1);
            //}

            
            addServiceDataButton.ForeColor = Design.mainColor;
            addServiceDataButton.Inactive1 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addServiceDataButton.Inactive2 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addServiceDataButton.Active1 = Color.FromArgb(100,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addServiceDataButton.Active2 = Color.FromArgb(100,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addServiceDataButton.StrokeColor = Color.FromArgb(20,
                                                 Design.mainColor.R,
                                                 Design.mainColor.G,
                                                 Design.mainColor.B);
            addServiceDataButton.MouseDown += button_MouseDown;
            addServiceDataButton.MouseUp += button_MouseUp;
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            ((AltoControls.AltoButton)sender).ForeColor = Design.mainColor;
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            ((AltoControls.AltoButton)sender).ForeColor = Color.White;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "введите логин" ||
                ((TextBox)sender).Text == "введите пароль" ||
                ((TextBox)sender).Text == "введите тел. или email")
            {
                ((TextBox)sender).Text = null;
                ((TextBox)sender).Font = GlobalData.GetFont(Enums.TypeFont.Regular, 16);
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).ForeColor = Color.DarkGray;
                ((TextBox)sender).Font = GlobalData.GetFont(Enums.TypeFont.Regular, 16);
                if (((TextBox)sender).Name == "login")
                {
                    ((TextBox)sender).Text = "введите логин";
                }
                else if (((TextBox)sender).Name == "password")
                {
                    ((TextBox)sender).Text = "введите пароль";
                }
                else if (((TextBox)sender).Name == "em_phone")
                {
                    ((TextBox)sender).Text = "введите тел. или email";
                }
            }
        }

        private async void addTaskButton_Click(object sender, EventArgs e)
        {
            int countChoice = 0;
            foreach (Service item in services)
            {
                if (item.GetStatus() == true)
                {
                    countChoice++;
                }
            }

            if (countChoice == 1)
            {
                if (login.Text != "введите логин" && password.Text != "введите пароль")
                {
                    try
                    {
                        int id_service = 0;
                        foreach (Service item in services)
                        {
                            if (item.GetStatus() == true)
                            {
                                id_service = item.GetId();
                                break;
                            }
                        }

                        ServiceData.commandText = @"INSERT INTO data_service ('id_service', 'id_user', 'login', 'password', 'em_ph') 
                            VALUES (@id_service, @id_user, @login, @password, @em_phone)";
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                        ServiceData.command.Parameters.AddWithValue("@id_service", id_service);
                        ServiceData.command.Parameters.AddWithValue("@id_user", User.userId);
                        ServiceData.command.Parameters.AddWithValue("@login", login.Text);
                        ServiceData.command.Parameters.AddWithValue("@password", password.Text);
                        ServiceData.command.Parameters.AddWithValue("@em_phone", em_phone.Text);
                        ServiceData.command.ExecuteNonQuery();

                        // --------------

                        MessageBox.Show(
                            "Данные сервиса созданы!",
                            "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Design.RefreshPanel(WindowManager.flowPanelServices);
                        await WindowManager.SetDataServiceBlock();

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Не удалось создать данные сервиса...\n-\nОшибка: " + ex.Message,
                            "Ошибка создания данных сервиса", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Вы не ввели данные сервиса (логин или пароль)",
                        "Ошибка создания данных сервиса", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show(
                    "Вы выбрали больше одной иконки для сервиса...",
                    "Ошибка создания данных сервиса", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog.FileName;

            string newPath = AppDomain.CurrentDomain.BaseDirectory + @"service_icon\serviceIcon"+ (services.Count+1).ToString() + ".png";
            FileInfo fileInf = new FileInfo(filename);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
            }

            SetIconsServices();
        }

        private void SetIconsServices() 
        {
            services.Clear();
            flowPanel.Controls.Clear();
            string[] allfiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"service_icon\");
            foreach (string filename in allfiles)
            {
                if (filename.Contains("Icon"))
                {
                    services.Add(new Service(flowPanel, services.Count + 1));
                }
            }
        }

        private void labelIcon_MouseHover(object sender, EventArgs e)
        {
            labelIcon.ForeColor = Design.mainColor;
        }

        private void labelIcon_MouseLeave(object sender, EventArgs e)
        {
            labelIcon.ForeColor = Color.Gray;
        }
    }
}
