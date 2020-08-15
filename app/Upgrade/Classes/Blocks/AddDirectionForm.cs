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

        public AddDirectionForm()
        {
            InitializeComponent();
            this.Load += MainWorkingForm_Load;
        }

        private void MainWorkingForm_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, this.Width, this.Height, 55, 55);
            SetWindowRgn(this.Handle, hRgn, true);

            addDirection.ForeColor = Design.mainColor;
            addDirection.Active1 = Design.mainColorOpacity;
            addDirection.Active2 = Design.mainColorOpacity;
            addDirection.StrokeColor = Design.mainColor;
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
                color_mark.Active1 = Color.FromArgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                color_mark.Active2 = Color.FromArgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                color_mark.Inactive1 = Color.FromArgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                color_mark.Inactive2 = Color.FromArgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                color_mark.StrokeColor = Color.FromArgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
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
    }
}
