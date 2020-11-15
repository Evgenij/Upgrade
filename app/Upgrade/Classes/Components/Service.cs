using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Classes.Components
{
    class Service
    {
        private PictureBox icon;
        private PictureBox checkBox;

        int id;
        bool status = false;

        public Service(FlowLayoutPanel flowPanel, int id) 
        {
            this.id = id; 
            icon = new PictureBox();
            checkBox = new PictureBox();

            icon.Load(@"service_icon\serviceIcon" + id.ToString() + ".png");
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.Width = 37;
            icon.Height = 37;
            icon.BackColor = Color.Transparent;
            icon.Click += Icon_Click;
            icon.Cursor = Cursors.Hand;

            checkBox.Load(@"service_icon\serviceCheckBox.png");
            checkBox.SizeMode = PictureBoxSizeMode.StretchImage;
            checkBox.BackColor = Color.Transparent;
            checkBox.Width = 15;
            checkBox.Height = 15;
            checkBox.Top = 22;
            checkBox.Left = 22;
            checkBox.Visible = false;


            icon.Controls.Add(checkBox);
            flowPanel.Controls.Add(icon);
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            if (status == false)
            {
                status = true;
                checkBox.Visible = true;
            }
            else 
            {
                status = false;
                checkBox.Visible = false;
            }
        }

        public bool GetStatus() 
        {
            return status;
        }

        public int GetId() 
        {
            return id;
        }
    }
}
