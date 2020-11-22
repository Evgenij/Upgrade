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

        private void addTarget_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Length != 0)
            {
                try
                {
                    // создаем цель
                    ServiceData.commandText = string.Format("INSERT INTO target VALUES (NULL, {0}, {1}, 0, 0, 0)",
                        directions.ElementAt(index_direct).GetId(), textBox.Text);
                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                    ServiceData.command.ExecuteNonQuery();


                    MessageBox.Show(
                        "Цель создана!",
                        "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    //Design.RefreshPanel(WindowManager.flowPanelTarget);
                    //await WindowManager.SetTargetBlock();
                    //GlobalData.scroller_target.Refresh(Design.heightContentTarget);
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
    }
}
