using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Upgrade.Classes;

namespace Upgrade.Forms
{
    public partial class AddTargetForm : Form
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

        private List<GlobalData.DataContainer> directions = new List<GlobalData.DataContainer>();
        private int index_direct = 0;

        public AddTargetForm()
        {
            InitializeComponent();
            this.Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, this.Width, this.Height, 55, 55);
            SetWindowRgn(this.Handle, hRgn, true);
            directions.Clear();

            addTarget.ForeColor = Design.mainColor;
            addTarget.Inactive1 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTarget.Inactive2 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTarget.Active1 = Color.FromArgb(100,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTarget.Active2 = Color.FromArgb(100,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTarget.StrokeColor = Color.FromArgb(20,
                                                 Design.mainColor.R,
                                                 Design.mainColor.G,
                                                 Design.mainColor.B);
            addTarget.MouseDown += button_MouseDown;
            addTarget.MouseUp += button_MouseUp;

            ServiceData.commandText = string.Format("SELECT direction.id_direct, direction.name FROM direction " +
                "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                "INNER JOIN user ON user_dir.id_user = user.id_user " +
                "WHERE user.id_user = {0}", User.userId);
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                while (ServiceData.reader.Read())
                {
                    directions.Add(new GlobalData.DataContainer(ServiceData.reader.GetInt32(0), ServiceData.reader.GetString(1)));
                }
                direction.Text = directions.First().GetName();
                //index_direct = directions.First().GetId();
            }
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

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.next_on;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.next_off;
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.prev_on;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.prev_off;
        }

        private async void addTarget_Click(object sender, EventArgs e)
        {
            if (nameTarget.Text.Length != 0)
            {
                try
                {
                    if (GlobalData.changeTarget == false)
                    {
                        // создаем цель
                        ServiceData.commandText = @"INSERT INTO target VALUES (NULL, @idDirect, @name)";
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                        ServiceData.command.Parameters.AddWithValue("@idDirect", directions.ElementAt(index_direct).GetId());
                        ServiceData.command.Parameters.AddWithValue("@name", nameTarget.Text);
                        ServiceData.command.ExecuteNonQuery();

                        MessageBox.Show(
                            "Цель создана!",
                            "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        ServiceData.commandText = "UPDATE target SET " +
                            "name = @name, " +
                            "id_direct = @idDirect " +
                            "WHERE id_target = @idTarget";
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                        ServiceData.command.Parameters.AddWithValue("@name", nameTarget.Text);
                        ServiceData.command.Parameters.AddWithValue("@idDirect", directions.ElementAt(index_direct).GetId());
                        ServiceData.command.Parameters.AddWithValue("@idTarget", WindowManager.idTarget);
                        ServiceData.command.ExecuteNonQuery();

                        MessageBox.Show(
                            "Цель изменена!",
                            "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GlobalData.changeTarget = false;
                    }

                    this.Close();
                    Design.RefreshPanel(WindowManager.flowPanelTarget);
                    await WindowManager.SetTargetBlock();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Не удалось создать цель...\n-\nОшибка: " + ex.Message,
                        "Ошибка создания цели", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(
                    "Вы не ввели название цели...",
                    "Ошибка создания цели", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (index_direct < (directions.Count - 1) && index_direct >= 0)
            {
                index_direct++;
                direction.Text = directions.ElementAt(index_direct).GetName();
            }
        }

        private void prev_Click(object sender, EventArgs e)
        {
            if (index_direct >= 1)
            {
                index_direct--;
                direction.Text = directions.ElementAt(index_direct).GetName();
            }
        }

        private void AddTargetForm_Shown(object sender, EventArgs e)
        {
            if (GlobalData.changeTarget == true)
            {
                nameTarget.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 16);
                nameTarget.ForeColor = Color.Black;

                addTarget.Text = "изменить данные";
                addTarget.Width = 160;
                addTarget.Left = 270;

                ServiceData.commandText = "SELECT name FROM target WHERE id_target = @idTarget";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.Parameters.AddWithValue("@idTarget", WindowManager.idTarget);

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    ServiceData.reader.Read();
                    nameTarget.Text = ServiceData.reader.GetString(0);
                }
            }
            else
            {
                addTarget.Text = "создать";
                addTarget.Width = 100;
                addTarget.Left = 325;

                nameTarget.Text = "введите название цели";
            }
        }

        private void nameTarget_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).ForeColor = Color.DarkGray;
                ((TextBox)sender).Font = GlobalData.GetFont(Enums.TypeFont.Regular, 16);
                if (((TextBox)sender).Name == "nameTarget")
                {
                    ((TextBox)sender).Text = "введите название цели";
                }
            }
        }

        private void nameTarget_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "введите название цели")
            {
                ((TextBox)sender).Text = null;
                ((TextBox)sender).Font = GlobalData.GetFont(Enums.TypeFont.Regular, 16);
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }
    }
}
