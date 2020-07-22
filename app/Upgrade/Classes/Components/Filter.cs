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
        private PictureBox[] buttonsPrev = new PictureBox[2];
        private PictureBox[] buttonsNext = new PictureBox[2];
        private static AltoControls.AltoButton button;
        private int indexDir = 0, indexTar = 0;
        private Timer timer;

        struct Direction 
        {
            int id_direction;
            string name;

            public Direction(int id, string name) 
            {
                this.id_direction = id;
                this.name = name;
            }

            public int GetId()
            {
                return id_direction;
            }

            public string GetName() 
            {
                return name;
            }
        }

        struct Target
        {
            int id_target;
            string name;

            public Target(int id, string name)
            {
                this.id_target = id;
                this.name = name;
            }

            public int GetId()
            {
                return id_target;
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
            button = new AltoControls.AltoButton();
            timer = new Timer();

            panelMain = panel;

            pictureButton.AccessibleName = "empty";
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

            box.Visible = true;
            box.AccessibleName = "hide";
            box.Left = panel.Left - 20;
            box.Top = panel.Top + panel.Height + 10;
            box.Image = Properties.Resources.panel_filter;
            box.SizeMode = PictureBoxSizeMode.Normal;
            box.Width = 300;
            box.Height = 0;

            for (int i = 0; i < labels.Length; i++) 
            {
                labels[i] = new Label();
                labels[i].Width = 195;
                labels[i].Font = GlobalData.GetFont(Enums.TypeFont.Standart, 12);
                labels[i].BackColor = Color.Transparent;
                labels[i].ForeColor = Color.DimGray;
                labels[i].Left = 35;
                labels[i].Top = (64 * i) + 49;
            }

            for (int i = 0; i < buttonsPrev.Length; i++)
            {
                buttonsPrev[i] = new PictureBox();
                buttonsPrev[i].AccessibleName = "index_" + (i+1).ToString();
                buttonsPrev[i].Image = Properties.Resources.prev_off;
                buttonsPrev[i].SizeMode = PictureBoxSizeMode.AutoSize;
                buttonsPrev[i].BackColor = Color.Transparent;
                buttonsPrev[i].Left = labels[i].Left + labels[i].Width + 17;
                buttonsPrev[i].Top = labels[i].Top + (2 * i) - 2;
                buttonsPrev[i].Cursor = Cursors.Hand;
                buttonsPrev[i].MouseHover += ButtonPrev_MouseHover;
                buttonsPrev[i].MouseLeave += ButtonPrev_MouseLeave;
                buttonsPrev[i].Click += ButtonPrev_Click;
            }

            for (int i = 0; i < buttonsNext.Length; i++)
            {
                buttonsNext[i] = new PictureBox();
                buttonsNext[i].AccessibleName = "index_" + (i + 1).ToString();
                buttonsNext[i].Image = Properties.Resources.next_off;
                buttonsNext[i].SizeMode = PictureBoxSizeMode.AutoSize;
                buttonsNext[i].BackColor = Color.Transparent;
                buttonsNext[i].Left = buttonsPrev[i].Left + buttonsPrev[i].Width;
                buttonsNext[i].Top = buttonsPrev[i].Top;
                buttonsNext[i].Cursor = Cursors.Hand;
                buttonsNext[i].MouseHover += ButtonNext_MouseHover;
                buttonsNext[i].MouseLeave += ButtonNext_MouseLeave;
                buttonsNext[i].Click += ButtonNext_Click;
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

            button.Top = box.Top + 57;
            button.Left = 163;
            button.Inactive1 = System.Drawing.Color.Transparent;
            button.Inactive2 = System.Drawing.Color.Transparent;
            button.Active1 = Design.mainColorOpacity;
            button.Active2 = Design.mainColorOpacity;
            button.Stroke = true;
            button.StrokeColor = Design.mainColor;
            button.ForeColor = Design.mainColor;
            button.Font = GlobalData.GetFont(Enums.TypeFont.Standart, 11);
            button.Text = "применить";
            button.Radius = 17;
            button.Width = 115;
            button.Height = 35;
            button.Cursor = Cursors.Hand;
            button.Click += Button_Click;

            labels[0].Text = directions.ElementAt(0).GetName();
            labels[1].Text = targets.ElementAt(0).GetName();

            box.Controls.Add(labels[0]);
            box.Controls.Add(labels[1]);
            box.Controls.Add(buttonsPrev[0]);
            box.Controls.Add(buttonsPrev[1]);
            box.Controls.Add(buttonsNext[0]);
            box.Controls.Add(buttonsNext[1]);
            box.Controls.Add(button);
            tabPage.Controls.Add(box);
            panel.Controls.Add(pictureButton);

            box.BringToFront();

            timer.Interval = 1;
            timer.Enabled = false;
            timer.Tick += Timer_Tick;
            typeAction = Enums.TypeAction.hide;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (typeAction == Enums.TypeAction.show)
            {
                if (box.Height != 220)
                {
                    box.Height += 10;
                }
                else
                {
                    timer.Stop();
                }
            }
            else if (typeAction == Enums.TypeAction.hide)
            {
                if (box.Height != 0)
                {
                    box.Height -= 10;
                }
                else
                {
                    timer.Stop();
                }
            }
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            if (indexDir != 0)
            {
                pictureButton.AccessibleName = "added";
                pictureButton.Image = Properties.Resources.filter_added;
                WindowManager.id_direct = directions.ElementAt(indexDir).GetId();
                WindowManager.id_target = targets.ElementAt(indexTar).GetId();
            }
            else 
            {
                pictureButton.AccessibleName = "empty";
                pictureButton.Image = Properties.Resources.filter_off;
                WindowManager.id_direct = 0;
                WindowManager.id_target = 0;
            }

            Design.RefreshPanel(WindowManager.flowPanelTasks);
            await WindowManager.SetTaskBlock();
            GlobalData.scroller_task.Refresh(Design.heightContentTasks);
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).AccessibleName == "index_1")
            {
                if (indexDir < (directions.Count - 1) && indexDir >= 0)
                {
                    indexDir++;
                    labels[0].Text = directions.ElementAt(indexDir).GetName();

                    ServiceData.commandText = string.Format("SELECT target.id_target, target.name FROM target " +
                        "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                        "WHERE direction.id_direct = {0}", directions.ElementAt(indexDir).GetId());

                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                    ServiceData.reader = ServiceData.command.ExecuteReader();
                    if (ServiceData.reader.HasRows)
                    {
                        targets.RemoveAt(0);
                        while (ServiceData.reader.Read())
                        {
                            targets.Add(new Target(ServiceData.reader.GetInt32(0), ServiceData.reader.GetString(1)));
                        }
                        WindowManager.id_target = targets.ElementAt(indexTar).GetId();
                    }
                    else
                    {
                        targets.Clear();
                        targets.Add(new Target(-1, "нет цели"));
                        indexTar = 0;
                    }
                    labels[1].Text = targets.ElementAt(0).GetName();
                }
            }
            else if (((PictureBox)sender).AccessibleName == "index_2")
            {
                if (indexTar < (targets.Count - 1) && indexTar >= 0)
                {
                    indexTar++;
                    labels[1].Text = targets.ElementAt(indexTar).GetName();
                }
            }
        }

        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).AccessibleName == "index_1")
            {
                if (indexDir >= 1)
                {
                    indexDir--;
                    labels[0].Text = directions.ElementAt(indexDir).GetName();

                    ServiceData.commandText = string.Format("SELECT target.id_target, target.name FROM target " +
                        "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                        "WHERE direction.id_direct = {0}", directions.ElementAt(indexDir).GetId());

                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                    ServiceData.reader = ServiceData.command.ExecuteReader();
                    if (ServiceData.reader.HasRows)
                    {
                        targets.RemoveAt(0);
                        while (ServiceData.reader.Read())
                        {
                            targets.Add(new Target(ServiceData.reader.GetInt32(0), ServiceData.reader.GetString(1)));
                        }
                    }
                    else
                    {
                        targets.Clear();
                        targets.Add(new Target(-1, "нет цели"));
                        indexTar = 0;
                    }
                    labels[1].Text = targets.ElementAt(0).GetName();
                }
            }
            else if (((PictureBox)sender).AccessibleName == "index_2")
            {
                if (indexTar >= 1)
                {
                    indexTar--;
                    labels[1].Text = targets.ElementAt(indexTar).GetName();
                }
            }
        }

        private void ButtonNext_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.next_off;
        }

        private void ButtonNext_MouseHover(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.next_on;
        }

        private void ButtonPrev_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.prev_off;
        }

        private void ButtonPrev_MouseHover(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.prev_on;
        }

        private void PictureButton_Click(object sender, EventArgs e)
        {
            timer.Start();
            box.Left = panelMain.Left - 20;
            if (box.AccessibleName == "hide")
            {
                typeAction = Enums.TypeAction.show;
                box.AccessibleName = "show";
            }
            else
            {
                typeAction = Enums.TypeAction.hide;
                box.AccessibleName = "hide";
            }
        }

        private void PictureButton_MouseLeave(object sender, EventArgs e)
        {
            if (pictureButton.AccessibleName != "added")
            {
                pictureButton.Image = Properties.Resources.filter_off;
            }
        }

        private void PictureButton_MouseHover(object sender, EventArgs e)
        {
            if (pictureButton.AccessibleName != "added")
            {
                pictureButton.Image = Properties.Resources.filter_on;
            }
        }
    }
}
