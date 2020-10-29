using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Upgrade.Classes;

namespace Upgrade.Forms
{
    class UIComboBox
    {
        private int index;
        private int heightBox;

        private Timer timer;
        private Panel secondPanel;
        private Panel filterPanel;
        private Panel panelMain;
        private Label textLabel;
        private Label labelPeriod;
        private PictureBox box;
        private PictureBox arrow;
        private FlowLayoutPanel flowPanel;
        private Label[] items;
        private Enums.TypeAction typeAction;

        public UIComboBox(Control tabPage, 
                          Panel panel, 
                          string AccessimbleName, 
                          string[] labels, 
                          Label label = null,
                          Panel addPanel = null, 
                          Panel panelFilter = null)
        {
            panel.AccessibleName = AccessimbleName;

            textLabel = new Label();
            labelPeriod = label;
            panelMain = panel;
            secondPanel = addPanel;
            filterPanel = panelFilter;
            box = new PictureBox();
            arrow = new PictureBox();
            flowPanel = new FlowLayoutPanel();
            items = new Label[labels.Length];
            timer = new Timer();

            textLabel.Left = 0;
            textLabel.Top = 0; 
            textLabel.Width = 180;
            textLabel.Font = GlobalData.GetFont(Enums.TypeFont.Regular, 22);
            textLabel.BackColor = Design.backColor;
            textLabel.ForeColor = System.Drawing.Color.DarkGray;
            textLabel.Cursor = Cursors.Hand;
            textLabel.Click += TextLabel_Click;
            if (panelMain.AccessibleName == "period")
            {
                index = 2;
                textLabel.Text = labels[index];
                WindowManager.period = Enums.Period.Today;
            }
            else
            {
                index = 0;
                textLabel.Text = labels[index];
                WindowManager.status = Enums.StatusTask.Empty;
            }

            flowPanel.Left = 18;
            flowPanel.Top = 18;
            flowPanel.Width = 165;
            flowPanel.Height = 0;
            flowPanel.BackColor = Color.Transparent;

            for (int i = 0; i < labels.Length; i++)
            {
                items[i] = new Label();
                items[i].AccessibleName = i.ToString();
                items[i].Font = GlobalData.GetFont(Enums.TypeFont.Regular, 18);
                items[i].BackColor = Color.White;
                items[i].ForeColor = System.Drawing.Color.DarkGray;
                items[i].Width = 160;
                items[i].Height = 25;
                items[i].Cursor = Cursors.Hand;
                items[i].MouseHover += UIComboBox_MouseHover;
                items[i].MouseLeave += UIComboBox_MouseLeave;
                items[i].Click += UIComboBox_Click;
                items[i].Text = labels[i];

                flowPanel.Height += items[i].Height;
                flowPanel.Controls.Add(items[i]);
            }

            heightBox = flowPanel.Height + 35;

            box.AccessibleName = "hide";
            box.Left = panel.Left - 20;
            box.Top = panel.Top + panel.Height + 10;
            box.Image = Properties.Resources.comboBox_panel;
            box.SizeMode = PictureBoxSizeMode.StretchImage;
            box.Width = 195;
            box.Height = 0;
            box.Controls.Add(flowPanel);

            arrow.Image = Properties.Resources.arrow_down;
            arrow.SizeMode = PictureBoxSizeMode.AutoSize;
            arrow.BackColor = Color.Transparent;
            arrow.Left = panel.Width - arrow.Width;
            arrow.Top = textLabel.Top + 13;
            panelMain.Controls.Add(arrow);
            arrow.BringToFront();

            panel.Controls.Add(textLabel);
            tabPage.Controls.Add(box);
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
                if (box.Height != heightBox)
                {
                    box.Height += 5;
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
                    box.Height -= 5;
                }
                else
                {
                    timer.Stop();
                }
            }
        }

        public Panel GetPanel()
        {
            return panelMain;
        }

        public string GetValue() 
        {
            return textLabel.Text;
        }

        private async void UIComboBox_Click(object sender, EventArgs e)
        {
            index = Convert.ToInt32(((Label)sender).AccessibleName);
            textLabel.Text = ((Label)sender).Text;

            panelMain.Width = textLabel.Text.Length * 14;
            if (index == 0)
            {
                panelMain.Width -= 15;
                if (labelPeriod != null)
                {
                    labelPeriod.Text = "прошлую неделю";
                }

                if (panelMain.AccessibleName == "period")
                {
                    WindowManager.period = Enums.Period.LastWeek;
                }
                else if (panelMain.AccessibleName == "status") 
                {
                    WindowManager.status = Enums.StatusTask.Empty;
                }
            }
            else if (index == 1) 
            {
                panelMain.Width += 5;
                if (labelPeriod != null)
                {
                    labelPeriod.Text = "вчера";
                }

                if (panelMain.AccessibleName == "period")
                {
                    WindowManager.period = Enums.Period.Yesterday;
                }
                else if (panelMain.AccessibleName == "status")
                {
                    WindowManager.status = Enums.StatusTask.Done;
                }
            }
            else if (index == 2)
            {
                if (labelPeriod != null)
                {
                    labelPeriod.Text = "сегодня";
                }

                if (panelMain.AccessibleName == "period")
                {
                    WindowManager.period = Enums.Period.Today;
                }
                else if (panelMain.AccessibleName == "status")
                {
                    WindowManager.status = Enums.StatusTask.Failed;
                }
            }
            else if (index == 3)
            {
                if (labelPeriod != null)
                {
                    labelPeriod.Text = "завтра";
                }

                if (panelMain.AccessibleName == "period")
                {
                    WindowManager.period = Enums.Period.Tomorrow;
                }
            }
            else if (index == 4)
            {
                panelMain.Width -= 20;
                if (labelPeriod != null)
                {
                    labelPeriod.Text = "текущую неделю";
                }

                if (panelMain.AccessibleName == "period")
                {
                    WindowManager.period = Enums.Period.CurrentWeek;
                }
            }

            Design.RefreshPanel(WindowManager.flowPanelTasks);
            await WindowManager.SetTaskBlock();
            GlobalData.scroller_task.Refresh(Design.heightContentTasks);

            arrow.Left = panelMain.Width - arrow.Width;
            if (secondPanel != null)
            {
                secondPanel.Left = panelMain.Left + panelMain.Width + 10;
                filterPanel.Left = secondPanel.Left + secondPanel.Width + 10;
            }
            else 
            {
                if (filterPanel != null)
                {
                    filterPanel.Left = panelMain.Left + panelMain.Width + 10;
                }
            }
            

            typeAction = Enums.TypeAction.hide;
            box.AccessibleName = "hide";
            timer.Start();
            arrow.Image = Properties.Resources.arrow_down;
        }

        private void UIComboBox_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.DarkGray;
        }

        private void UIComboBox_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Black;
        }

        private void TextLabel_Click(object sender, EventArgs e)
        {
            timer.Start();
            box.Left = panelMain.Left - 20;
            if (box.AccessibleName == "hide")
            {
                typeAction = Enums.TypeAction.show;
                box.AccessibleName = "show";
                //box.Visible = true;
                arrow.Image = Properties.Resources.arrow_up;
            }
            else 
            {
                typeAction = Enums.TypeAction.hide;
                box.AccessibleName = "hide";
                //box.Visible = false;
                arrow.Image = Properties.Resources.arrow_down;
            }
        }
    }
}
