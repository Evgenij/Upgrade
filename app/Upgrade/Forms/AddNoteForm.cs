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
    public partial class AddNoteForm : Form
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

        public AddNoteForm()
        {
            InitializeComponent();
            this.Load += MainWorkingForm_Load;
        }

        private void MainWorkingForm_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, this.Width, this.Height, 55, 55);
            SetWindowRgn(this.Handle, hRgn, true);

            addNote.ForeColor = Design.mainColor;
            addNote.Active1 = Design.mainColorOpacity;
            addNote.Active2 = Design.mainColorOpacity;
            addNote.StrokeColor = Design.mainColor;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNoteForm_Shown(object sender, EventArgs e)
        {
            textArea.Clear();
        }

        private async void addNote_Click(object sender, EventArgs e)
        {
            if (textArea.Text.Length != 0)
            {
                try
                {
                    ServiceData.commandText = string.Format("INSERT INTO note ('id_note', 'id_user', 'text') VALUES (NULL, {0}, '{1}')", User.user_id, textArea.Text);
                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                    ServiceData.command.ExecuteNonQuery();

                    MessageBox.Show(
                        "Заметка создана!",
                        "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    Design.RefreshPanel(WindowManager.flowPanelNotes);
                    await WindowManager.SetNoteBlock();
                    GlobalData.scroller_note.Refresh(Design.heightContentNotes);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(
                        "Не удалось создать заметку...\n\nОшибка: " + ex.Message,
                        "Ошибка создания заметки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(
                    "Вы не ввели текст заметки...",
                    "Ошибка создания заметки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
