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

        public AddTargetForm()
        {
            InitializeComponent();
            this.Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, this.Width, this.Height, 55, 55);
            SetWindowRgn(this.Handle, hRgn, true);

            addTarget.ForeColor = Design.mainColor;
            addTarget.Active1 = Design.mainColorOpacity;
            addTarget.Active2 = Design.mainColorOpacity;
            addTarget.StrokeColor = Design.mainColor;

            //ServiceData.commandText = "SELECT id_categ, name FROM category";
            //ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            //ServiceData.reader = ServiceData.command.ExecuteReader();
            //if (ServiceData.reader.HasRows)
            //{
            //    while (ServiceData.reader.Read())
            //    {
            //        categories.Add(new Category(ServiceData.reader.GetInt32(0), ServiceData.reader.GetString(1)));
            //    }
            //}
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

        private void addTarget_Click(object sender, EventArgs e)
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
                        "Цель создана!",
                        "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    Design.RefreshPanel(WindowManager.flowPanelDirect);
                    await WindowManager.SetDirectBlock();
                    GlobalData.scroller_direct.Refresh(Design.heightContentDirection);
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
    }
}
