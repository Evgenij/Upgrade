using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Upgrade.Forms;

namespace Upgrade.Classes
{
    class Filter
    {
        private Panel panelMain;
        private PictureBox pictureButton;
        private PictureBox box;
        private Label[] labels = new Label[2];
        private List<Direction> directions = new List<Direction>();
        private List<Target> targets = new List<Target>();
        private Enums.TypeAction typeAction;
        private PictureBox buttonPrevDir, buttonNextDir;
        private PictureBox buttonPrevTarget, buttonNextTarget;

        struct Direction 
        {
            int id_direction;
            string name;

            public Direction(int id, string name) 
            {
                this.id_direction = id;
                this.name = name;
            }

            public string GetName() 
            {
                return name;
            }
        }

        struct Target
        {
            int id_direction;
            string name;

            public Target(int id, string name)
            {
                this.id_direction = id;
                this.name = name;
            }

            public string GetName()
            {
                return name;
            }
        }

        public Filter(TabPage tabPage, Panel panel) 
        {
            pictureButton = new PictureBox();
            box = new PictureBox();

            panelMain = panel;

            pictureButton.Image = Properties.Resources.filter_off;
            pictureButton.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureButton.Height = 22;
            pictureButton.Width = 22;
            pictureButton.Left = 0;
            pictureButton.Top = 0;
            pictureButton.Cursor = Cursors.Hand;
            pictureButton.MouseHover += PictureButton_MouseHover;
            pictureButton.MouseLeave += PictureButton_MouseLeave;
            pictureButton.Click += PictureButton_Click;

            box.Visible = false;
            box.AccessibleName = "hide";
            box.Left = panel.Left - 20;
            box.Top = panel.Top + panel.Height + 10;
            box.Image = Properties.Resources.panel_filter;
            box.SizeMode = PictureBoxSizeMode.Normal;
            box.Width = 300;
            box.Height = 220;

            for (int i = 0; i < labels.Length; i++) 
            {
                labels[i] = new Label();
                labels[i].Width = 195;
                labels[i].Font = GlobalData.GetFont(Enums.TypeFont.Standart, 14);
                labels[i].BackColor = Color.Transparent;
                labels[i].ForeColor = Color.Gray;
                labels[i].Left = 33;
                labels[i].Top = (64 * i) + 49;
            }

            ServiceData.commandText = string.Format("SELECT direction.id_direct, direction.name FROM direction " +
                "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                "INNER JOIN user ON user.id_user = user_dir.id_user " +
                "WHERE user.id_user = {0}",User.user_id);

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                directions.Add(new Direction(-1, "пусто"));
                while (ServiceData.reader.Read())
                {
                    directions.Add(new Direction(ServiceData.reader.GetInt32(0), ServiceData.reader.GetString(1)));    
                }
            }
            targets.Add(new Target(-1, "нет цели"));


            //ServiceData.commandText = string.Format("SELECT target.id_target, target.name FROM target " +
            //    "INNER JOIN direction ON direction.id_direct = target.id_direct " +
            //    "WHERE direction.id_direct = {0}", User.user_id);

            //ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            //ServiceData.reader = ServiceData.command.ExecuteReader();
            //if (ServiceData.reader.HasRows)
            //{
            //    while (ServiceData.reader.Read())
            //    {
            //        targets.Add(new Target(ServiceData.reader.GetInt32(0), ServiceData.reader.GetString(1)));
            //    }
            //}

            labels[0].Text = directions.ElementAt(0).GetName();

            box.Controls.Add(labels[0]);
            box.Controls.Add(labels[1]);
            tabPage.Controls.Add(box);
            panel.Controls.Add(pictureButton);

            box.BringToFront();
            this.typeAction = Enums.TypeAction.hide;
        }

        private void PictureButton_Click(object sender, EventArgs e)
        {
            box.Left = panelMain.Left - 20;
            if (box.AccessibleName == "hide")
            {
                typeAction = Enums.TypeAction.show;
                box.AccessibleName = "show";
                box.Visible = true;
            }
            else
            {
                typeAction = Enums.TypeAction.hide;
                box.AccessibleName = "hide";
                box.Visible = false;
            }
        }

        private void PictureButton_MouseLeave(object sender, EventArgs e)
        {
            pictureButton.Image = Properties.Resources.filter_off;
        }

        private void PictureButton_MouseHover(object sender, EventArgs e)
        {
            pictureButton.Image = Properties.Resources.filter_on;
        }
    }
}
