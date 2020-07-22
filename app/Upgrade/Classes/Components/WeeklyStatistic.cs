using OpenTK;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Upgrade.Forms;

namespace Upgrade.Classes
{
    class WeeklyStatistic
    {
        private static int[] countFailded = new int[7];
        private static int[] countDone = new int[7];
        private static AltoControls.AltoButton[] failded = new AltoControls.AltoButton[7];
        private static AltoControls.AltoButton[] done = new AltoControls.AltoButton[7];
        private static TextBox[] labelFailed = new TextBox[7];
        private static TextBox[] labelDone = new TextBox[7];
        private static string[] daysLastWeek;
        private static string[] daysCurrentWeek;

        private static TabPage tabPage;
        private static PictureBox mainBox;
        private static TextBox textBoxPerformLastWeek;
        private static TextBox textBoxPerformCurrentWeek;
        private static PictureBox face;
        private static Label labelPeriod;

        public static void SetStatistic(TabPage tab, 
                               PictureBox box, 
                               TextBox performLastWeek, 
                               TextBox performCurrentWeek, 
                               PictureBox faceIndicator,
                               Label periodWeek) 
        {
            tabPage = tab;
            mainBox = box;
            textBoxPerformLastWeek = performLastWeek;
            textBoxPerformCurrentWeek = performCurrentWeek;
            face = faceIndicator;
            labelPeriod = periodWeek;

            int paddingIndicator = 0;
            int paddingLabel = 0;
            daysLastWeek = GetDaysLastWeek();
            daysCurrentWeek = GetDaysCurrentWeek();

            for (int i = 0; i < failded.Length; i++)
            {
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON target.id_target = task.id_target " +
                    "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                    "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                    "INNER JOIN user ON user.id_user = user_dir.id_user " +
                    "WHERE user_dir.id_user = {0} AND task.date = '{1}.{2}.{3}' AND task.status = 0",
                    User.user_id,
                    daysCurrentWeek[i],
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    ServiceData.reader.Read();
                    countFailded[i] = ServiceData.reader.GetInt32(0);
                }
            }

            for (int i = 0; i < done.Length; i++)
            {
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON target.id_target = task.id_target " +
                    "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                    "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                    "INNER JOIN user ON user.id_user = user_dir.id_user " +
                    "WHERE user_dir.id_user = {0} AND task.date = '{1}.{2}.{3}' AND task.status = 1",
                    User.user_id,
                    daysCurrentWeek[i],
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    ServiceData.reader.Read();
                    countDone[i] = ServiceData.reader.GetInt32(0);
                }
            }

            for (int i = 0; i < labelFailed.Length; i++) 
            {
                labelFailed[i] = new TextBox();
                labelFailed[i].Left = (box.Left + 53) + paddingLabel;
                labelFailed[i].Top = box.Top + 64;
                labelFailed[i].Width = 20;
                labelFailed[i].Height = 20;
                labelFailed[i].Font = GlobalData.GetFont(Enums.TypeFont.Medium, 11);
                labelFailed[i].BackColor = System.Drawing.Color.White;
                labelFailed[i].ForeColor = System.Drawing.Color.DarkGray;
                labelFailed[i].BorderStyle = BorderStyle.None;
                labelFailed[i].ReadOnly = true;
                labelFailed[i].TextAlign = HorizontalAlignment.Center;
                labelFailed[i].Text = countFailded[i].ToString();

                tab.Controls.Add(labelFailed[i]);
                labelFailed[i].BringToFront();
                paddingLabel += 37;
            }

            paddingLabel = 0;
            for (int i = 0; i < labelDone.Length; i++)
            {
                labelDone[i] = new TextBox();
                labelDone[i].Left = (box.Left + 53) + paddingLabel;
                labelDone[i].Top = box.Top + 219;
                labelDone[i].Width = 20;
                labelDone[i].Height = 20;
                labelDone[i].Font = GlobalData.GetFont(Enums.TypeFont.Medium, 11);
                labelDone[i].BackColor = System.Drawing.Color.White;
                labelDone[i].ForeColor = System.Drawing.Color.DarkGray;
                labelDone[i].BorderStyle = BorderStyle.None;
                labelDone[i].ReadOnly = true;
                labelDone[i].TextAlign = HorizontalAlignment.Center;
                labelDone[i].Text = countDone[i].ToString();

                tab.Controls.Add(labelDone[i]);
                labelDone[i].BringToFront();
                paddingLabel += 37;
            }

            for (int i = 0; i < failded.Length; i++) 
            {
                int stepHeight;
                int totalIssues = countFailded[i] + countDone[i];
                if (totalIssues != 0)
                {
                    stepHeight = 130 / totalIssues;
                }
                else 
                {
                    stepHeight = 130;
                }

                failded[i] = new AltoControls.AltoButton();
                failded[i].Top = box.Top + 85;
                failded[i].Left = (box.Left + 60) + paddingIndicator;
                failded[i].Inactive1 = System.Drawing.Color.LightGray;
                failded[i].Inactive2 = System.Drawing.Color.LightGray;
                failded[i].Active1 = System.Drawing.Color.FromArgb(System.Drawing.Color.LightGray.R - 10, System.Drawing.Color.LightGray.G - 10, System.Drawing.Color.LightGray.B - 10);
                failded[i].Active2 = System.Drawing.Color.FromArgb(System.Drawing.Color.LightGray.R - 10, System.Drawing.Color.LightGray.G - 10, System.Drawing.Color.LightGray.B - 10);
                failded[i].Stroke = true;
                failded[i].StrokeColor = System.Drawing.Color.LightGray;
                failded[i].Radius = 2;
                failded[i].Width = 6;
                failded[i].Cursor = Cursors.Hand;
                if (countFailded[i] != 0)
                {
                    failded[i].Height = countFailded[i] * stepHeight;
                }
                else 
                {
                    failded[i].Height = 0;
                }

                tab.Controls.Add(failded[i]);
                failded[i].BringToFront();

                done[i] = new AltoControls.AltoButton();
                done[i].Top = failded[i].Top + failded[i].Height;
                done[i].Left = failded[i].Left;
                done[i].Inactive1 = Design.mainColor;
                done[i].Inactive2 = Design.mainColor;
                done[i].Active1 = System.Drawing.Color.FromArgb(Design.mainColor.R - 10, Design.mainColor.G - 10, Design.mainColor.B - 10);
                done[i].Active2 = System.Drawing.Color.FromArgb(Design.mainColor.R - 10, Design.mainColor.G - 10, Design.mainColor.B - 10);
                done[i].Stroke = true;
                done[i].StrokeColor = Design.mainColor;
                done[i].Radius = 2;
                done[i].Width = 6;
                done[i].Cursor = Cursors.Hand;
                if (countDone[i] == 0)
                {
                    failded[i].Height = 130;
                }
                done[i].Height = 130 - failded[i].Height;
                

                tab.Controls.Add(done[i]);
                done[i].BringToFront();

                paddingIndicator += 37;
            }

            periodWeek.Text = "c " + daysCurrentWeek.First() + "." + DateTime.Now.ToString("MM") + "." + DateTime.Now.ToString("yyyy") +
                              " по " + daysCurrentWeek.Last() + "." + DateTime.Now.ToString("MM") + "." + DateTime.Now.ToString("yyyy");
            performLastWeek.Text = Math.Ceiling(CalculatePerformLastWeek()).ToString() + "%";
            performCurrentWeek.Text = Math.Ceiling(CalculatePerformCurrentWeek()).ToString() + "%";
            if (CalculatePerformCurrentWeek() >= 0 && CalculatePerformCurrentWeek() < 40)
            {
                faceIndicator.Image = Properties.Resources.faceIndicatorBad;
            }
            else if (CalculatePerformCurrentWeek() >= 40 && CalculatePerformCurrentWeek() < 65)
            {
                faceIndicator.Image = Properties.Resources.faceIndicatorMiddle;
            }
            else 
            {
                faceIndicator.Image = Properties.Resources.faceIndicatorHappy;
            }
        }

        public static void Refresh() 
        {
            SetStatistic(tabPage, mainBox, textBoxPerformLastWeek, textBoxPerformCurrentWeek, face, labelPeriod);
        }

        private static double CalculatePerformLastWeek() 
        {
            double perform = 0.0;

            for (int i = 0; i < failded.Length; i++)
            {
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON target.id_target = task.id_target " +
                    "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                    "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                    "INNER JOIN user ON user.id_user = user_dir.id_user " +
                    "WHERE user_dir.id_user = {0} AND task.date = '{1}.{2}.{3}' AND task.status = 0", 
                    User.user_id, 
                    daysLastWeek[i], 
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    ServiceData.reader.Read();
                    countFailded[i] = ServiceData.reader.GetInt32(0);
                }
            }

            for (int i = 0; i < done.Length; i++)
            {
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON target.id_target = task.id_target " +
                    "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                    "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                    "INNER JOIN user ON user.id_user = user_dir.id_user " +
                    "WHERE user_dir.id_user = {0} AND task.date = '{1}.{2}.{3}' AND task.status = 1", 
                    User.user_id, 
                    daysLastWeek[i], 
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    ServiceData.reader.Read();
                    countDone[i] = ServiceData.reader.GetInt32(0);
                }
            }

            int[] daysPerform = new int[7];

            for (int i = 0; i < countFailded.Length; i++)
            {
                if (countFailded[i] != 0 || countDone[i] != 0)
                {
                    perform += daysPerform[i] = (countDone[i] * 100) / (countFailded[i] + countDone[i]);
                }
            }

            return perform / 7;
        }

        private static double CalculatePerformCurrentWeek()
        {
            double perform = 0.0;

            for (int i = 0; i < failded.Length; i++)
            {
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON target.id_target = task.id_target " +
                    "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                    "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                    "INNER JOIN user ON user.id_user = user_dir.id_user " +
                    "WHERE user_dir.id_user = {0} AND task.date = '{1}.{2}.{3}' AND task.status = 0",
                    User.user_id,
                    daysCurrentWeek[i],
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    ServiceData.reader.Read();
                    countFailded[i] = ServiceData.reader.GetInt32(0);
                }
            }

            for (int i = 0; i < done.Length; i++)
            {
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON target.id_target = task.id_target " +
                    "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                    "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                    "INNER JOIN user ON user.id_user = user_dir.id_user " +
                    "WHERE user_dir.id_user = {0} AND task.date = '{1}.{2}.{3}' AND task.status = 1",
                    User.user_id,
                    daysCurrentWeek[i],
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    ServiceData.reader.Read();
                    countDone[i] = ServiceData.reader.GetInt32(0);
                }
            }

            int[] daysPerform = new int[7];

            for (int i = 0; i < countFailded.Length; i++)
            {
                if (countFailded[i] != 0 || countDone[i] != 0)
                {
                    perform += daysPerform[i] = (countDone[i] * 100) / (countFailded[i] + countDone[i]);
                }
            }

            return perform / 7;
        }

        public static string[] GetDaysLastWeek()
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            List<string> days = new List<string>();

            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(-1);
            }

            if (date.DayOfWeek == DayOfWeek.Monday)
            {
                date = date.AddDays(-1);
            }

            for (int i = 0; i < 7; i++)
            {
                days.Add(date.AddDays(-i).ToString("dd"));
            }

            return days.ToArray();
        }

        public static string[] GetDaysCurrentWeek()
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            List<string> days = new List<string>();

            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(-1);
            }

            for (int i = 0; i < 7; i++)
            {
                days.Add(date.AddDays(i).ToString("dd"));
            }

            return days.ToArray();
        }
    }
}
