using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Classes.Blocks
{
    class DataServiceBlock : Block
    {
        private Label[] labelsInput = new Label[3];
        private PictureBox[] copyButtons = new PictureBox[3];
        private TextBox[] inputs = new TextBox[3];
        private PictureBox more, serviceIcon;

        // компоненты для создания панели действий
        private Panel panelAction;
        private PictureBox boxChange;
        private PictureBox boxDelete;

        string currentLogin;
        string currentPassword;
        string currentEmail;

        public DataServiceBlock(FlowLayoutPanel flowPanel, int id_service, string login, string password, string em_phone)
        {
            id_record = id_service;
            this.flowPanel = flowPanel;

            serviceIcon = new PictureBox();
            more = new PictureBox();
            panelAction = new Panel();
            boxChange = new PictureBox();
            boxDelete = new PictureBox();

            int marginLabel = 0;
            for (int i = 0; i < labelsInput.Length; i++)
            {
                labelsInput[i] = new Label();
                labelsInput[i].Font = GlobalData.GetFont(Enums.TypeFont.Regular, 12);
                labelsInput[i].ForeColor = Color.Gray;
                labelsInput[i].BackColor = Color.White;
                labelsInput[i].Top = marginLabel + 25;
                labelsInput[i].Left = 105;
                if (i == 0)
                {
                    labelsInput[i].Text = "логин";
                }
                else if (i == 1)
                {
                    labelsInput[i].Text = "пароль";
                }
                else if (i == 2)
                {
                    labelsInput[i].Text = "email / телефон";
                }

                labelsInput[i].SendToBack();
                marginLabel += 45;
            }

            for (int i = 0; i < copyButtons.Length; i++)
            {
                copyButtons[i] = new PictureBox();
                copyButtons[i].AccessibleName = i.ToString();
                copyButtons[i].Image = Properties.Resources.copyButton;
                copyButtons[i].SizeMode = PictureBoxSizeMode.AutoSize;
                copyButtons[i].BackColor = Color.White;
                copyButtons[i].Cursor = Cursors.Hand;
                copyButtons[i].BackColor = Color.Transparent;
                copyButtons[i].Top = labelsInput[i].Top + 5;
                copyButtons[i].Left = labelsInput[i].Left - 10 - copyButtons[i].Width;
                copyButtons[i].Click += DataServiceBlock_Click;
            }

            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = new TextBox();
                inputs[i].BackColor = Color.White;
                inputs[i].Top = labelsInput[i].Top + labelsInput[i].Height - 6;
                inputs[i].Left = labelsInput[i].Left + 3;
                inputs[i].Width = 190;
                inputs[i].Font = GlobalData.GetFont(Enums.TypeFont.Regular, 14);
                inputs[i].BackColor = Color.White;
                inputs[i].ForeColor = Color.Black;
                inputs[i].BorderStyle = BorderStyle.None;
                inputs[i].ReadOnly = true;
                if (i == 0)
                {
                    inputs[i].Text = login;
                }
                else if (i == 1)
                {
                    inputs[i].Text = password;
                }
                else if (i == 2)
                {
                    inputs[i].Text = em_phone;
                }

                inputs[i].BringToFront();
                inputs[i].MouseEnter += DataServiceBlock_Enter;
                inputs[i].MouseLeave += DataServiceBlock_Leave;
            }

            more.AccessibleName = "more";
            more.Image = Properties.Resources.more_off;
            more.SizeMode = PictureBoxSizeMode.CenterImage;
            more.Height = 20;
            more.Width = 12;
            more.Left = 310;
            more.Top = 22;  
            more.BackColor = Color.White;
            more.Cursor = Cursors.Hand;
            more.MouseHover += More_MouseHover;
            more.MouseLeave += More_MouseLeave;
            more.Click += More_Click;

            // панель действий
            panelAction.Visible = false;
            panelAction.Top = 47;
            panelAction.Width = 110; 
            panelAction.Left = (more.Left + more.Width + 5) - panelAction.Width;
            panelAction.BackColor = Color.White;

            boxChange.Image = Properties.Resources.block_change_off;
            boxChange.SizeMode = PictureBoxSizeMode.AutoSize;
            boxChange.Left = 5;
            boxChange.Top = 0;
            boxChange.BackColor = Color.White;
            boxChange.Cursor = Cursors.Hand;
            boxChange.MouseHover += BoxChange_MouseHover;
            boxChange.MouseLeave += BoxChange_MouseLeave;
            boxChange.Click += BoxChange_Click;
            panelAction.Controls.Add(boxChange);

            boxDelete.Image = Properties.Resources.block_delete_off;
            boxDelete.SizeMode = PictureBoxSizeMode.AutoSize;
            boxDelete.Left = 5;
            boxDelete.Top = 31;
            boxDelete.BackColor = Color.White;
            boxDelete.Cursor = Cursors.Hand;
            boxDelete.MouseHover += BoxDelete_MouseHover;
            boxDelete.MouseLeave += BoxDelete_MouseLeave;
            boxDelete.Click += BoxDelete_Click;
            panelAction.Controls.Add(boxDelete);

            panelAction.Height = boxDelete.Height + boxDelete.Top;
            //

            serviceIcon.Load(@"service_icon\serviceIcon" + id_service.ToString() + ".png");
            serviceIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            serviceIcon.Height = 32;
            serviceIcon.Width = 32;
            serviceIcon.Left = 25;
            serviceIcon.Top = 25;
            serviceIcon.BackColor = Color.White;

            box_top.Image = Properties.Resources.service_box_top;
            box_top.SizeMode = PictureBoxSizeMode.AutoSize;
            box_top.Top = 0;
            box_top.BackColor = Color.Transparent;

            box_center.Image = Properties.Resources.service_box_center;
            box_center.SizeMode = PictureBoxSizeMode.StretchImage;
            box_center.BackColor = Color.Transparent;
            box_center.Width = 340;
            box_center.Height = 130;
            box_center.Top = box_top.Height;

            box_bottom.Image = Properties.Resources.service_box_bottom;
            box_bottom.SizeMode = PictureBoxSizeMode.AutoSize;
            box_bottom.BackColor = Color.Transparent;

            panel.Width = box_center.Width;

            box_bottom.Top = box_top.Height + box_center.Height;
            panel.Height = box_top.Height + box_center.Height + box_bottom.Height + 4;

            panel.Controls.Add(box_top);
            panel.Controls.Add(box_center);
            panel.Controls.Add(box_bottom);
            for (int i = 0; i < labelsInput.Length; i++)
            {
                panel.Controls.Add(labelsInput[i]);
            }
            for (int i = 0; i < inputs.Length; i++)
            {
                panel.Controls.Add(inputs[i]);
                inputs[i].BringToFront();
            }
            for (int i = 0; i < copyButtons.Length; i++)
            {
                panel.Controls.Add(copyButtons[i]);
            }

            panel.Controls.Add(serviceIcon);
            panel.Controls.Add(more);
            panel.Controls.Add(panelAction);

            box_top.SendToBack();
            box_center.SendToBack();
            box_bottom.SendToBack();
            panelAction.BringToFront();

            flowPanel.Controls.Add(panel);

            Design.heightContentDataService += panel.Height;
        }

        private void DataServiceBlock_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(inputs[Convert.ToInt32(((PictureBox)sender).AccessibleName)].Text);
        }

        private void DataServiceBlock_Enter(object sender, EventArgs e)
        {
            currentLogin = inputs[0].Text;
            currentPassword = inputs[1].Text;
            currentEmail = inputs[2].Text;
        }

        private void DataServiceBlock_Leave(object sender, EventArgs e)
        {
            if (currentLogin != inputs[0].Text || currentPassword != inputs[1].Text || currentEmail != inputs[2].Text) 
            {
                //MessageBox.Show("Changed!");

                ServiceData.commandText = @"UPDATE data_service 
                    SET login = @login, password = @password, em_ph = @email 
                    WHERE id_service = @id_service";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.Parameters.AddWithValue("@id_service", this.id_record);
                ServiceData.command.Parameters.AddWithValue("@login", inputs[0].Text);
                ServiceData.command.Parameters.AddWithValue("@password", inputs[1].Text);
                ServiceData.command.Parameters.AddWithValue("@email", inputs[2].Text);
                ServiceData.command.ExecuteNonQuery();

                for (int i = 0; i < inputs.Length; i++)
                {
                    inputs[i].ReadOnly = true;
                    inputs[i].BorderStyle = BorderStyle.None;
                }
            }
        }

        private void BoxChange_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i].ReadOnly = false;
                inputs[i].BorderStyle = BorderStyle.FixedSingle;
            }

            more.AccessibleName = "more";
            more.Image = Properties.Resources.more_off;
            panelAction.Visible = false;
        }

        private void BoxDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данные сервиса?",
                                "Сообщение", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServiceData.commandText = @"DELETE FROM data_service WHERE id_service = @id_service";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.Parameters.AddWithValue("@id_service", this.id_record);
                ServiceData.command.ExecuteNonQuery();

                Design.HidePanel(panel, flowPanel, Enums.TypeBlock.DataService);
            }
            else
            {
                more.AccessibleName = "more";
                more.Image = Properties.Resources.more_off;
                panelAction.Visible = false;
            }
        }

        private void BoxDelete_MouseLeave(object sender, EventArgs e)
        {
            boxDelete.Left = 5;
            boxDelete.Image = Properties.Resources.block_delete_off;
        }

        private void BoxDelete_MouseHover(object sender, EventArgs e)
        {
            boxDelete.Left = 0;
            boxDelete.Image = Properties.Resources.block_delete_on;
        }

        private void BoxChange_MouseLeave(object sender, EventArgs e)
        {
            boxChange.Left = 5;
            boxChange.Image = Properties.Resources.block_change_off;
        }

        private void BoxChange_MouseHover(object sender, EventArgs e)
        {
            boxChange.Left = 0;
            boxChange.Image = Properties.Resources.block_change_on;
        }

        private void More_Click(object sender, EventArgs e)
        {
            if (more.AccessibleName == "more")
            {
                more.AccessibleName = "close";
                more.Image = Properties.Resources.close_off;
                panelAction.Visible = true;
            }
            else
            {
                more.AccessibleName = "more";
                more.Image = Properties.Resources.more_off;
                panelAction.Visible = false;
            }
        }

        private void More_MouseLeave(object sender, EventArgs e)
        {
            if (more.AccessibleName == "close")
            {
                more.Image = Properties.Resources.close_off;
            }
            else
            {
                more.Image = Properties.Resources.more_off;
            }
        }

        private void More_MouseHover(object sender, EventArgs e)
        {
            if (more.AccessibleName == "close")
            {
                more.Image = Properties.Resources.close_on;
            }
            else
            {
                more.Image = Properties.Resources.more_on;
            }
        }
    }
}
