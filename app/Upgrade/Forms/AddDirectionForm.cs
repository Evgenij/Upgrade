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
using Upgrade.Forms;

namespace Upgrade.Classes.Blocks
{
    public partial class AddDirectionForm : Form
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

        private List<GlobalData.DataContainer> categories = new List<GlobalData.DataContainer>();
        private int index_categ = 0;

        public AddDirectionForm()
        {
            InitializeComponent();
            this.Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, this.Width, this.Height, 55, 55);
            SetWindowRgn(this.Handle, hRgn, true);

            addDirection.ForeColor = Design.mainColor;
            addDirection.Inactive1 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDirection.Inactive2 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDirection.Active1 = Color.FromArgb(100,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDirection.Active2 = Color.FromArgb(100,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDirection.StrokeColor = Color.FromArgb(20,
                                                 Design.mainColor.R,
                                                 Design.mainColor.G,
                                                 Design.mainColor.B);
            addDirection.MouseDown += button_MouseDown;
            addDirection.MouseUp += button_MouseUp;

            ServiceData.commandText = "SELECT id_categ, name FROM category";
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                while (ServiceData.reader.Read())
                {
                    categories.Add(new GlobalData.DataContainer(ServiceData.reader.GetInt32(0), ServiceData.reader.GetString(1)));
                }

                //index_categ = categories.First().GetId();
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

        private void color_mark_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color_mark.Active1 = colorDialog.Color;
                color_mark.Active2 = colorDialog.Color;
                color_mark.Inactive1 = colorDialog.Color;
                color_mark.Inactive2 = colorDialog.Color;
                color_mark.StrokeColor = colorDialog.Color;
            }
            else 
            {
                color_mark.Active1 = Color.Gainsboro;
                color_mark.Active2 = Color.Gainsboro;
                color_mark.Inactive1 = Color.Gainsboro;
                color_mark.Inactive2 = Color.Gainsboro;
                color_mark.StrokeColor = Color.Gainsboro;
            }
        }

        private void AddDirectionForm_Shown(object sender, EventArgs e)
        {
            if (GlobalData.changeDirection == true)
            {
                nameDirection.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 16);
                nameDirection.ForeColor = Color.Black;

                addDirection.Text = "изменить данные";
                addDirection.Width = 160;
                addDirection.Left = 271;

                ServiceData.commandText = "SELECT name, color_mark FROM direction WHERE id_direct = @idDirect";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.Parameters.AddWithValue("@idDirect", WindowManager.idDirect);

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    ServiceData.reader.Read();
                    nameDirection.Text = ServiceData.reader.GetString(0);
                    color_mark.Inactive1 = System.Drawing.ColorTranslator.FromHtml(ServiceData.reader.GetString(1));
                    color_mark.Inactive2 = System.Drawing.ColorTranslator.FromHtml(ServiceData.reader.GetString(1));
                    color_mark.Active1 = System.Drawing.ColorTranslator.FromHtml(ServiceData.reader.GetString(1));
                    color_mark.Active2 = System.Drawing.ColorTranslator.FromHtml(ServiceData.reader.GetString(1));
                    color_mark.StrokeColor = System.Drawing.ColorTranslator.FromHtml(ServiceData.reader.GetString(1));
                }
            }
            else 
            {
                addDirection.Text = "создать";
                addDirection.Width = 100;
                addDirection.Left = 327;

                nameDirection.Text = "введите название направления";

                color_mark.Active1 = Color.Gainsboro;
                color_mark.Active2 = Color.Gainsboro;
                color_mark.Inactive1 = Color.Gainsboro;
                color_mark.Inactive2 = Color.Gainsboro;
                color_mark.StrokeColor = Color.Gainsboro;
            }
        }

        private async void addDirection_Click(object sender, EventArgs e)
        {
            if (nameDirection.Text.Length != 0)
            {
                try
                {
                    int id_direct = 0;

                    if (GlobalData.changeDirection == false)
                    {
                        ServiceData.commandText = "INSERT INTO direction ('id_categ', 'name', 'color_mark') " +
                            "VALUES(@idCateg, @name, @colorMark)";
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                        ServiceData.command.Parameters.AddWithValue("@idCateg", categories.ElementAt(index_categ).GetId());
                        ServiceData.command.Parameters.AddWithValue("@name", nameDirection.Text);
                        ServiceData.command.Parameters.AddWithValue("@colorMark", ColorTranslator.ToHtml(color_mark.Active1));
                        ServiceData.command.ExecuteNonQuery();

                        ServiceData.commandText = "SELECT id_direct FROM direction";
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                        ServiceData.reader = ServiceData.command.ExecuteReader();
                        if (ServiceData.reader.HasRows)
                        {
                            while (ServiceData.reader.Read())
                            {
                                id_direct = ServiceData.reader.GetInt32(0);
                            }
                        }

                        ServiceData.commandText = string.Format("INSERT INTO user_dir VALUES ({0},{1})", User.userId, id_direct);
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                        ServiceData.command.ExecuteNonQuery();

                        MessageBox.Show(
                            "Направление создано!",
                            "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        ServiceData.commandText = "UPDATE direction " +
                            "SET id_categ = @idCateg, " +
                            "name = @name, " +
                            "color_mark = @colorMark " +
                            "WHERE id_direct = 1 "; 
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                        ServiceData.command.Parameters.AddWithValue("@idCateg", categories.ElementAt(index_categ).GetId());
                        ServiceData.command.Parameters.AddWithValue("@name", nameDirection.Text);
                        ServiceData.command.Parameters.AddWithValue("@colorMark", ColorTranslator.ToHtml(color_mark.Active1));
                        ServiceData.command.ExecuteNonQuery();

                        MessageBox.Show(
                            "Направление изменено!",
                            "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GlobalData.changeDirection = false;
                    }

                    
                    this.Close();
                    Design.RefreshPanel(WindowManager.flowPanelDirect);
                    await WindowManager.SetDirectBlock();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Не удалось создать направление...\n-\nОшибка: " + ex.Message,
                        "Ошибка создания направления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show(
                    "Вы не ввели название направления...",
                    "Ошибка создания направления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (index_categ < (categories.Count - 1) && index_categ >= 0)
            {
                index_categ++;
                categeory.Text = categories.ElementAt(index_categ).GetName();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (index_categ >= 1)
            {
                index_categ--;
                categeory.Text = categories.ElementAt(index_categ).GetName();
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "введите название направления")
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
                if (((TextBox)sender).Name == "nameDirection")
                {
                    ((TextBox)sender).Text = "введите название направления";
                }
            }
        }
    }
}
