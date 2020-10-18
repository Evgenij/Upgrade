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
            addDirection.Active1 = Design.mainColorOpacity;
            addDirection.Active2 = Design.mainColorOpacity;
            addDirection.StrokeColor = Design.mainColor;

            ServiceData.commandText = "SELECT id_categ, name FROM category";
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                while (ServiceData.reader.Read())
                {
                    categories.Add(new GlobalData.DataContainer(ServiceData.reader.GetInt32(0), ServiceData.reader.GetString(1)));
                }
            }
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
            textBox.Clear();

            color_mark.Active1 = Color.Gainsboro;
            color_mark.Active2 = Color.Gainsboro;
            color_mark.Inactive1 = Color.Gainsboro;
            color_mark.Inactive2 = Color.Gainsboro;
            color_mark.StrokeColor = Color.Gainsboro;
        }

        private async void addDirection_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Length != 0)
            {
                try
                {
                    int id_direct = 0;

                    ServiceData.commandText = string.Format("INSERT INTO direction VALUES (NULL, {0}, {1}, 0, 0, 0, '{2}')", 
                        index_categ, textBox.Text, ColorTranslator.ToHtml(color_mark.Active1));
                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
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

                    ServiceData.commandText = string.Format("INSERT INTO user_dir VALUES ({0},{1})", User.user_id, id_direct);
                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                    ServiceData.command.ExecuteNonQuery();

                    MessageBox.Show(
                        "Направление создано!",
                        "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    Design.RefreshPanel(WindowManager.flowPanelDirect);
                    await WindowManager.SetDirectBlock();
                    GlobalData.scroller_direct.Refresh(Design.heightContentDirection);
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
    }
}
