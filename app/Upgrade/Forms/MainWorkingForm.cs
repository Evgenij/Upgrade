using ComponentFactory.Krypton.Toolkit;
using Nevron.Nov.Graphics;
using Nevron.Nov.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Upgrade.Classes.Blocks;
using Upgrade.Classes.Components;
using Upgrade.Forms;

namespace Upgrade.Classes
{
    public partial class MainWorkingForm : Form
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

        System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
        private UIComboBox[] uiComboBox = new UIComboBox[3];
        private Filter filter;
        private PieChart pieChart;
        private StatisticChart statisticChart;
        System.Windows.Forms.Timer timerTime;

        // переменные для реализации изменения цветового оформления приложения
        bool isDraggingRed = false, isDraggingGreen = false, isDraggingBlue = false;
        int currentXRed, currentXGreen, currentXBlue, valueRed = 0, valueGreen = 0, valueBlue = 0;

        private static List<int> idFailedTasks = new List<int>(), 
            countTaskDone = new List<int>(), 
            countTaskFailed = new List<int>();
        private int countTask = 0, countTaskInWork = 0;
        private string[] daysMonth;

        private int countTaskLastPeriod = 0, countTaskDoneLastPeriod = 0;

        public MainWorkingForm()
        {
            InitializeComponent();
            this.Load += MainWorkingForm_Load;
            this.BackColor = Design.backColor;
            hide_border_tabs.BackColor = Design.backColor;
        }

        private void TimerTime_Tick(object sender, EventArgs e) 
        {
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;

            string hours_minutes = "", seconds = "";

            if (h < 10)
            {
                hours_minutes += "0" + h;
            }
            else
            {
                hours_minutes += h;
            }

            hours_minutes += ":";

            if (m < 10)
            {
                hours_minutes += "0" + m;
            }
            else
            {
                hours_minutes += m;
            }

            hours_minutes += ":";

            if (s < 10)
            {
                seconds += "0" + s;
            }
            else
            {
                seconds += s;
            }
            if (s == 30)
            {
                InstallFailedTask();
            }

            label_time.Text = hours_minutes;
            label_seconds.Text = seconds;
        }

        private void MainWorkingForm_Load(object sender, EventArgs e)
        {
            IntPtr hRgn = CreateRoundRectRgn(-1, -1, 1366, 768, 78, 78);
            SetWindowRgn(this.Handle, hRgn, true);

            WindowManager.SetFlowPanels(
                flowTasks, flowNotes, 
                flowDirect, flowTarget, 
                flowTaskTarget, flowAcheivement, 
                flowSchedule, flowDataService);

            // создание компонентов главного пункта меню
            SetTabProfile();

            // создание компонентов пункта меню с направлениями и целями
            SetTabDirection_Target();

            // создание компонентов пункта меню с достижениями и статистикой
            SetTabAchiev_Stat();

            // создание компонентов пункта меню с расписаниями и паролями
            SetTabSched_Services();

            // создание компонентов пункта меню с настройками
            SetTabSettings();

            timerTime = new System.Windows.Forms.Timer();
            timerTime.Interval = 1000;
            timerTime.Tick += TimerTime_Tick;
            timerTime.Start();

            // установка и запуск таймера в новом потоке 
            TimerCallback funcCallback = new TimerCallback(Callback);
            System.Threading.Timer timer = new System.Threading.Timer(funcCallback, 0, 0, 60000);  // 1 минута
        }

        private async void SetTabProfile() 
        {
            string[] labelsPeriod = { "Прошлая неделя",
                                      "Вчера",
                                      "Сегодня",
                                      "Завтра",
                                      "Текущая неделя"};

            string[] labelsStatus = { "Все задачи",
                                      "Выполненные",
                                      "Невыполненные"};

            GlobalComponents.notFoundTask = not_found_task;
            GlobalComponents.notFoundNote = not_found_note;

            uiComboBox[1] = new UIComboBox(tab_profile, panel_period, "status", labelsStatus, null, null, panel_filter);
            uiComboBox[0] = new UIComboBox(tab_profile, panel_status_task, "period", labelsPeriod, label_today, uiComboBox[1].GetPanel(), panel_filter);

            await WindowManager.SetPanelsMainWindow();
            GlobalComponents.labelPeriod = sublabel_week_stat;
            WeeklyStatistic.SetStatistic(tab_profile, panel_week_stat, performLastWeek, performCurrentWeek, faceIndicator);

            Design.SetMarkCurrentDay(day_mark);
            filter = new Filter(tab_profile, panel_filter);

            if (flowTasks.Height < Design.heightContentTasks)
            {
                taskScrollTipTop.Visible = true;
                taskScrollTipBottom.Visible = true;
            }
            else
            {
                taskScrollTipTop.Visible = false;
                taskScrollTipBottom.Visible = false;
            }

            if (flowNotes.Height < Design.heightContentNotes)
            {
                noteScrollTipTop.Visible = true;
                noteScrollTipBottom.Visible = true;
            }
            else
            {
                noteScrollTipTop.Visible = false;
                noteScrollTipBottom.Visible = false;
            }
        }

        private async void SetTabDirection_Target()
        {
            GlobalComponents.labelDirect = label_name_direct;
            GlobalComponents.labelTarget = label_name_target;
            GlobalComponents.notFoundTarget = not_found_target;
            GlobalComponents.notFoundTaskTarget = not_found_task_target;
            GlobalComponents.status_mark = status_mark;
            GlobalComponents.targetScrollTipTop = targetScrollTipTop;
            GlobalComponents.targetScrollTipBottom = targetScrollTipBottom;
            GlobalComponents.task_targetScrollTipTop = task_targetScrollTipTop;
            GlobalComponents.task_targetScrollTipBottom = task_targetScrollTipBottom;

            await WindowManager.SetDirectBlock();

            if (flowDirect.Height < Design.heightContentDirection)
            {
                directScrollTipTop.Visible = true;
                directScrollTipBottom.Visible = true;
            }
            else
            {
                directScrollTipTop.Visible = false;
                directScrollTipBottom.Visible = false;
            }


            if (flowTarget.Height < Design.heightContentTarget)
            {
                targetScrollTipTop.Visible = true;
                targetScrollTipBottom.Visible = true;
            }
            else
            {
                targetScrollTipTop.Visible = false;
                targetScrollTipBottom.Visible = false;
            }
        }

        private async void SetTabAchiev_Stat()
        {
            List<string> category = new List<string>();

            ServiceData.commandText = @"SELECT name FROM category";
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
            ServiceData.command.ExecuteNonQuery();

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                while (ServiceData.reader.Read())
                {
                    category.Add(ServiceData.reader.GetString(0));
                }
            }

            uiComboBox[2] = new UIComboBox(tab_stat, panelCategory, "category", category.ToArray(), null, null, null);

            await WindowManager.SetAchievBlock(uiComboBox[2].GetValue());

            setCurrentCountTask(Enums.PeriodStatistic.today);

            datePeriod.Text = DateTime.Now.ToString("dd.MM.yyyy");
            pieChart = new PieChart(bgMainStat, 25, 80, countTaskInWork, countTaskDone.ToArray().Sum(), countTaskFailed.ToArray().Sum());
            statisticChart = new StatisticChart(bgMainStat, 20, 40, countTaskDone, countTaskFailed);
            statisticChart.Hide();

            if (flowAcheivement.Height < Design.heightContentAchiev)
            {
                achievScrollTipTop.Visible = true;
                achievScrollTipBottom.Visible = true;
            }
            else
            {
                achievScrollTipTop.Visible = false;
                achievScrollTipBottom.Visible = false;
            }
        }

        private async void SetTabSched_Services() 
        {
            await WindowManager.SetSheduleBlock();
            await WindowManager.SetDataServiceBlock();


            if (flowSchedule.Height < Design.heightContentShedule)
            {
                scheduleScrollTipTop.Visible = true;
                scheduleScrollTipBottom.Visible = true;
            }
            else 
            {
                scheduleScrollTipTop.Visible = false;
                scheduleScrollTipBottom.Visible = false;
            }

            if (flowDataService.Height < Design.heightContentDataService)
            {
                servicesScrollTipTop.Visible = true;
                servicesScrollTipBottom.Visible = true;
            }
            else
            {
                servicesScrollTipTop.Visible = false;
                servicesScrollTipBottom.Visible = false;
            }
        }

        private void SetTabSettings() 
        {
            userLogin.Text = User.userLogin;
            userPassword.Text = User.userPassword;
            userEmail.Text = User.userEmail;

            red.Text = INIManager.Read("Design", "Red");
            green.Text = INIManager.Read("Design", "Green");
            Blue.Text = INIManager.Read("Design", "Blue");

            buttonRed.Left = buttonRed.Left + Convert.ToInt32(red.Text);
            buttonGreen.Left = buttonGreen.Left + Convert.ToInt32(green.Text);
            buttonBlue.Left = buttonBlue.Left + Convert.ToInt32(Blue.Text);
        }

        private void changePeriod(Label currentLabel, Enums.PeriodStatistic period)
        {
            todayStat.ForeColor = Color.Gray;
            weekStat.ForeColor = Color.Gray;
            monthStat.ForeColor = Color.Gray;

            currentLabel.ForeColor = Design.mainColor;

            if (period == Enums.PeriodStatistic.today)
            {
                labelPeriod.Visible = true;
                datePeriod.Visible = true;
                datePeriod.ForeColor = Design.mainColor;
                pieChart.Show();
                statisticChart.Hide();
                labelGeneralPeriod.Text = "сегодня";
                setCurrentCountTask(Enums.PeriodStatistic.today);
            }
            else if (period == Enums.PeriodStatistic.week)
            {
                labelPeriod.Visible = false;
                datePeriod.Visible = false;
                pieChart.Hide();
                statisticChart.Show();
                labelGeneralPeriod.Text = "неделю";
                setCurrentCountTask(Enums.PeriodStatistic.week);
                statisticChart.SetChart(countTaskDone, countTaskFailed);
            }
            else if (period == Enums.PeriodStatistic.month)
            {
                labelPeriod.Visible = false;
                datePeriod.Visible = false;
                pieChart.Hide();
                statisticChart.Show();
                labelGeneralPeriod.Text = "месяц";
                setCurrentCountTask(Enums.PeriodStatistic.month);
                statisticChart.SetChart(countTaskDone, countTaskFailed, true, daysMonth);
            }
        }

        private void setCurrentCountTask(Enums.PeriodStatistic period)
        {
            countTaskDone.Clear();
            countTaskFailed.Clear();

            if (period == Enums.PeriodStatistic.today)
            {
                // вывод кол-ва всех задач на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date = '{1}'", User.userId, DateTime.Now.ToString("dd.MM.yyyy"));

                //MessageBox.Show(ServiceData.commandText);

                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTask = ServiceData.reader.GetInt32(0);
                    }
                }

                // вывод кол-ва всех задач "в процессе" на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date = '{1}' AND task.status = 0 AND task.failed = 0", User.userId, DateTime.Now.ToString("dd.MM.yyyy"));
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTaskInWork = ServiceData.reader.GetInt32(0);
                    }
                }

                // вывод кол-ва всех выполненых задач на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date = '{1}' AND task.status = 1", User.userId, DateTime.Now.ToString("dd.MM.yyyy"));
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTaskDone.Add(ServiceData.reader.GetInt32(0));
                    }
                }

                // вывод кол-ва всех проваленных задач на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date = '{1}' AND task.failed = 1 AND task.status = 0", User.userId, DateTime.Now.ToString("dd.MM.yyyy"));
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTaskFailed.Add(ServiceData.reader.GetInt32(0));
                    }
                }

                // -------------------------------------

                // вывод кол-ва всех задач на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date = '{1}.{2}.{3}'",
                    User.userId,
                    DateTime.Now.AddDays(-1).ToString("dd"),
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                //MessageBox.Show(ServiceData.commandText);

                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTaskLastPeriod = ServiceData.reader.GetInt32(0);
                    }
                }

                // вывод кол-ва всех выполненых задач на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date = '{1}.{2}.{3}' AND task.status = 1",
                    User.userId,
                    DateTime.Now.AddDays(-1).ToString("dd"),
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTaskDoneLastPeriod = ServiceData.reader.GetInt32(0);
                    }
                }

                //---------------------------

                labelCurrentPerform.Text = "Эффективность за сегодня";
                if (countTask != 0)
                {
                    labelPerformCurrentPeriod.Text = ((countTaskDone.First() * 100) / countTask).ToString() + "%";
                }
                else 
                {
                    labelPerformCurrentPeriod.Text = "0";
                }
                if (countTaskLastPeriod != 0)
                {
                    labelPerformLastPeriod.Text = "Эффективность за вчера " + ((countTaskDoneLastPeriod * 100) / countTaskLastPeriod).ToString() + "%";
                }
                else 
                {
                    labelPerformLastPeriod.Text = "Эффективность за вчера 0 %";
                }
                labelCountTask.Text = countTask.ToString();
                labelTaskInWork.Text = countTaskInWork.ToString();
                labelTaskDone.Text = countTaskDone.First().ToString();
                labelTaskFailed.Text = countTaskFailed.First().ToString();
            }
            else if (period == Enums.PeriodStatistic.week)
            {
                string[] daysLastWeek = WeeklyStatistic.GetDaysLastWeek();
                string[] daysCurrentWeek = WeeklyStatistic.GetDaysCurrentWeek();

                // вывод кол-ва всех задач на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date BETWEEN '{1}.{3}.{4}' AND '{2}.{3}.{4}' ",
                    User.userId,
                    daysCurrentWeek.First(),
                    daysCurrentWeek.Last(),
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                //MessageBox.Show(ServiceData.commandText);

                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTask = ServiceData.reader.GetInt32(0);
                    }
                }

                // вывод кол-ва всех задач "в процессе" на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date BETWEEN '{1}.{3}.{4}' AND '{2}.{3}.{4}' AND task.status = 0 AND task.failed = 0",
                    User.userId,
                    daysCurrentWeek.First(),
                    daysCurrentWeek.Last(),
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTaskInWork = ServiceData.reader.GetInt32(0);
                    }
                }

                for (int i = 0; i < daysCurrentWeek.Length; i++)
                {
                    // вывод кол-ва всех выполненых задач на сегодня
                    ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date = '{1}.{2}.{3}' AND task.status = 1",
                    User.userId,
                    daysCurrentWeek[i],
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                    ServiceData.command.ExecuteNonQuery();

                    ServiceData.reader = ServiceData.command.ExecuteReader();
                    if (ServiceData.reader.HasRows)
                    {
                        while (ServiceData.reader.Read())
                        {
                            countTaskDone.Add(ServiceData.reader.GetInt32(0));
                        }
                    }
                }

                for (int i = 0; i < daysCurrentWeek.Length; i++)
                {
                    // вывод кол-ва всех проваленных задач на сегодня
                    ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date = '{1}.{2}.{3}' AND task.failed = 1 AND task.status = 0",
                    User.userId,
                    daysCurrentWeek[i],
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                    ServiceData.command.ExecuteNonQuery();

                    ServiceData.reader = ServiceData.command.ExecuteReader();
                    if (ServiceData.reader.HasRows)
                    {
                        while (ServiceData.reader.Read())
                        {
                            countTaskFailed.Add(ServiceData.reader.GetInt32(0));
                        }
                    }
                }

                //---------------------

                // вывод кол-ва всех задач на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date BETWEEN '{1}.{3}.{4}' AND '{2}.{3}.{4}'",
                    User.userId,
                    daysLastWeek.First(),
                    daysLastWeek.Last(),
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                //MessageBox.Show(ServiceData.commandText);

                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTaskLastPeriod = ServiceData.reader.GetInt32(0);
                    }
                }

                // вывод кол-ва всех выполненых задач на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date BETWEEN '{1}.{3}.{4}' AND '{2}.{3}.{4}' AND task.status = 1",
                    User.userId,
                    daysLastWeek.First(),
                    daysLastWeek.Last(),
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTaskDoneLastPeriod = ServiceData.reader.GetInt32(0);
                    }
                }

                //-------------------------

                labelCurrentPerform.Text = "Эффективность за неделю";
                labelPerformCurrentPeriod.Text = WeeklyStatistic.CalculatePerformCurrentWeek().ToString() + "%";
                labelPerformLastPeriod.Text = "Эффективность за прошлую неделю " + WeeklyStatistic.CalculatePerformLastWeek().ToString() + "%";

                labelCountTask.Text = countTask.ToString();
                labelTaskInWork.Text = countTaskInWork.ToString();
                labelTaskDone.Text = countTaskDone.ToArray().Sum().ToString();
                labelTaskFailed.Text = countTaskFailed.ToArray().Sum().ToString();
            }
            else if (period == Enums.PeriodStatistic.month) 
            {
                string[] daysLastMonth = WeeklyStatistic.GetDaysLastMonth();
                string[] daysCurrentMonth = WeeklyStatistic.GetDaysCurrentMonth();
                daysMonth = daysCurrentMonth;

                // вывод кол-ва всех задач на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date BETWEEN '{1}.{3}.{4}' AND '{2}.{3}.{4}' ",
                    User.userId,
                    daysCurrentMonth.First(),
                    daysCurrentMonth.Last(),
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                //MessageBox.Show(ServiceData.commandText);

                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTask = ServiceData.reader.GetInt32(0);
                    }
                }

                // вывод кол-ва всех задач "в процессе" на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date BETWEEN '{1}.{3}.{4}' AND '{2}.{3}.{4}' AND task.status = 0 AND task.failed = 0",
                    User.userId,
                    daysCurrentMonth.First(),
                    daysCurrentMonth.Last(),
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTaskInWork = ServiceData.reader.GetInt32(0);
                    }
                }

                for (int i = 0; i < daysCurrentMonth.Length; i++)
                {
                    // вывод кол-ва всех выполненых задач на сегодня
                    ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date = '{1}.{2}.{3}' AND task.status = 1",
                    User.userId,
                    daysCurrentMonth[i],
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                    ServiceData.command.ExecuteNonQuery();

                    ServiceData.reader = ServiceData.command.ExecuteReader();
                    if (ServiceData.reader.HasRows)
                    {
                        while (ServiceData.reader.Read())
                        {
                            countTaskDone.Add(ServiceData.reader.GetInt32(0));
                        }
                    }
                }

                for (int i = 0; i < daysCurrentMonth.Length; i++)
                {
                    // вывод кол-ва всех проваленных задач на сегодня
                    ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date = '{1}.{2}.{3}' AND task.failed = 1 AND task.status = 0",
                    User.userId,
                    daysCurrentMonth[i],
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                    ServiceData.command.ExecuteNonQuery();

                    ServiceData.reader = ServiceData.command.ExecuteReader();
                    if (ServiceData.reader.HasRows)
                    {
                        while (ServiceData.reader.Read())
                        {
                            countTaskFailed.Add(ServiceData.reader.GetInt32(0));
                        }
                    }
                }

                //-------------------------

                // вывод кол-ва всех задач на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date BETWEEN '{1}.{3}.{4}' AND '{2}.{3}.{4}'",
                    User.userId,
                    daysLastMonth.First(),
                    daysLastMonth.Last(),
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                //MessageBox.Show(ServiceData.commandText);

                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTaskLastPeriod = ServiceData.reader.GetInt32(0);
                    }
                }

                // вывод кол-ва всех выполненых задач на сегодня
                ServiceData.commandText = string.Format("SELECT count(id_task) FROM task " +
                    "INNER JOIN target ON task.id_target = target.id_target " +
                    "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                    "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                    "INNER JOIN user ON user_dir.id_user = user.id_user " +
                    "WHERE user.id_user = {0} AND task.date BETWEEN '{1}.{3}.{4}' AND '{2}.{3}.{4}' AND task.status = 1",
                    User.userId,
                    daysLastMonth.First(),
                    daysLastMonth.Last(),
                    DateTime.Now.ToString("MM"),
                    DateTime.Now.ToString("yyyy"));

                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.ExecuteNonQuery();

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        countTaskDoneLastPeriod = ServiceData.reader.GetInt32(0);
                    }
                }

                //-------------------------

                labelCurrentPerform.Text = "Эффективность за месяц";
                if (countTask != 0)
                {
                    labelPerformCurrentPeriod.Text = ((countTaskDone.ToArray().Sum() * 100) / countTask).ToString() + "%";
                }
                else 
                {
                    labelPerformCurrentPeriod.Text = "0%";
                }
                if (countTaskLastPeriod != 0)
                {
                    labelPerformLastPeriod.Text = "Эффективность за прошлый месяц " + ((countTaskDoneLastPeriod * 100) / countTaskLastPeriod).ToString() + "%";
                }
                else 
                {
                    labelPerformLastPeriod.Text = "Эффективность за прошлый месяц 0%";
                }

                labelCountTask.Text = countTask.ToString();
                labelTaskInWork.Text = countTaskInWork.ToString();
                labelTaskDone.Text = countTaskDone.ToArray().Sum().ToString();
                labelTaskFailed.Text = countTaskFailed.ToArray().Sum().ToString();
            } 

            labelPerformCurrentPeriod.Left = labelCurrentPerform.Left + labelCurrentPerform.Width;
        }

        private void profile_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 100);
            tabs.SelectedTab = tab_profile;
            active_item.Image = Properties.Resources.profile;
        }

        private void targets_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 160);
            tabs.SelectedTab = tab_targets;
            active_item.Image = Properties.Resources.tardets;
        }

        private void stat_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 220);
            tabs.SelectedTab = tab_stat;
            active_item.Image = Properties.Resources.stat;
        }

        private void schedule_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 280);
            tabs.SelectedTab = tab_sched;
            active_item.Image = Properties.Resources.schedule;
        }

        private void settings_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 340);
            tabs.SelectedTab = tab_sett;
            active_item.Image = Properties.Resources.settings;
        }

        private void exit_from_profile_MouseHover(object sender, EventArgs e)
        {
            exit_from_profile.ForeColor = Design.mainColor;
        }

        private void exit_from_profile_MouseLeave(object sender, EventArgs e)
        {
            exit_from_profile.ForeColor = Color.DimGray;
        }

        private void label_my_passwords_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 280);
            tabs.SelectedTab = tab_sched;
            active_item.Image = Properties.Resources.schedule;
        }

        private void addTask_Click(object sender, EventArgs e)
        {
            if (GlobalData.addTaskForm == null)
            {
                GlobalData.addTaskForm = new AddTaskForm();
                GlobalData.addTaskForm.ShowDialog();
            }
            else
            {
                GlobalData.addTaskForm.ShowDialog();
            }
        }

        private void exit_from_profile_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из аккаунта?",
                               "Сообщение",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                INIManager.WriteString("Settings", "remember_me", "off");
                GlobalData.reg_authForm.Show();
            }
        }

        private void MainWorkingForm_Shown(object sender, EventArgs e)
        {
            panel_menu.BackColor = Design.mainColor;

            tab_profile.BackColor = Design.backColor;
            tab_targets.BackColor = Design.backColor;
            tab_stat.BackColor = Design.backColor;
            tab_sched.BackColor = Design.backColor;
            tab_sett.BackColor = Design.backColor;

            label_today.ForeColor = Design.mainColor;
            sublabel_note.ForeColor = Design.mainColor;
            sublabel_week_stat.ForeColor = Design.mainColor;
            sublabel_direct.ForeColor = Design.mainColor;
            label_name_direct.ForeColor = Design.mainColor;
            label_name_target.ForeColor = Design.mainColor;

            exit_from_profile.BackColor = Color.FromArgb(234, 235, 240);

            day_mark.Inactive1 = Design.mainColor;
            day_mark.Inactive2 = Design.mainColor;
            day_mark.Active1 = Design.mainColor;
            day_mark.Active2 = Design.mainColor;
            day_mark.StrokeColor = Design.mainColor;

            status_mark.Inactive1 = Design.mainColor;
            status_mark.Inactive2 = Design.mainColor;
            status_mark.Active1 = Design.mainColor;
            status_mark.Active2 = Design.mainColor;
            status_mark.StrokeColor = Design.mainColor;

            todayStat.ForeColor = Design.mainColor;
            labelGeneralPeriod.ForeColor = Design.mainColor;
            labelPerformCurrentPeriod.ForeColor = Design.mainColor;
            performCurrentWeek.ForeColor = Design.mainColor;

            not_found_note.BringToFront();
            not_found_target.BringToFront();
            not_found_task.BringToFront();
            not_found_task_target.BringToFront();

            sublabelSchedule.ForeColor = Design.mainColor;
            sublabelPasswords.ForeColor = Design.mainColor;

            calendar.BringToFront();
            calendar.StateCheckedNormal.Day.Back.Color1 = Color.FromArgb(
                                                                    Design.mainColorOpacity.A + 40,
                                                                    Design.mainColorOpacity.R,
                                                                    Design.mainColorOpacity.G,
                                                                    Design.mainColorOpacity.B);
            calendar.StateCheckedNormal.Day.Back.Color2 = Color.FromArgb(
                                                                    Design.mainColorOpacity.A + 40,
                                                                    Design.mainColorOpacity.R,
                                                                    Design.mainColorOpacity.G,
                                                                    Design.mainColorOpacity.B);
            calendar.StateCheckedNormal.Day.Border.Color1 = Color.FromArgb(
                                                                    Design.mainColorOpacity.R - 5,
                                                                    Design.mainColorOpacity.G - 5,
                                                                    Design.mainColorOpacity.B - 5);
            calendar.StateCheckedNormal.Day.Border.Color2 = Color.FromArgb(
                                                                    Design.mainColorOpacity.R - 5,
                                                                    Design.mainColorOpacity.G - 5,
                                                                    Design.mainColorOpacity.B - 5);

            calendar.StateCheckedTracking.Day.Border.Width = 1;
            calendar.StateCheckedTracking.Day.Back.Color1 = Color.FromArgb(
                                                                    Design.mainColorOpacity.A + 40,
                                                                    Design.mainColorOpacity.R,
                                                                    Design.mainColorOpacity.G,
                                                                    Design.mainColorOpacity.B);
            calendar.StateCheckedTracking.Day.Back.Color2 = Color.FromArgb(
                                                                    Design.mainColorOpacity.A + 40,
                                                                    Design.mainColorOpacity.R,
                                                                    Design.mainColorOpacity.G,
                                                                    Design.mainColorOpacity.B);
            calendar.StateCheckedTracking.Day.Border.Color1 = Color.FromArgb(
                                                                    Design.mainColorOpacity.R - 5,
                                                                    Design.mainColorOpacity.G - 5,
                                                                    Design.mainColorOpacity.B - 5);
            calendar.StateCheckedTracking.Day.Border.Color2 = Color.FromArgb(
                                                                    Design.mainColorOpacity.R - 5,
                                                                    Design.mainColorOpacity.G - 5,
                                                                    Design.mainColorOpacity.B - 5);

            SetStyleButtons();

            path.AddEllipse(0, 0, 110, 110);
            Region rgn = new Region(path);
            user_photo.Region = rgn;
            userPhotoSettings.Region = rgn;

            user_login.Text = User.userLogin;
            perform.Text = User.userPerform + "%";

            ServiceData.commandText = string.Format("SELECT count(*) FROM achievement " +
                "INNER JOIN achiev_categ ON achiev_categ.id_achiev = achievement.id_achiev " +
                "INNER JOIN category ON category.id_categ = achiev_categ.id_categ " +
                "INNER JOIN direction ON direction.id_categ = category.id_categ " +
                "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                "INNER JOIN user ON user.id_user = user_dir.id_user " +
                "WHERE user.id_user = {0} and achievement.status = 1", User.userId);
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
            ServiceData.reader = ServiceData.command.ExecuteReader();
            ServiceData.reader.Read();
            achieves.Text = ServiceData.reader.GetInt32(0).ToString();

            perform.Text = User.CalculatePerform();

            user_photo.Load(User.pathPhoto);
            userPhotoSettings.Load(User.pathPhoto);

            block_for_focus.Focus();
        }

        private void SetStyleButtons() 
        {
            addTask.ForeColor = Design.mainColor;
            addTask.Inactive1 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTask.Inactive2 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTask.Active1 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTask.Active2 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTask.StrokeColor = Color.FromArgb(20,
                                                 Design.mainColor.R,
                                                 Design.mainColor.G,
                                                 Design.mainColor.B);
            addTask.MouseDown += button_MouseDown;
            addTask.MouseUp += button_MouseUp;

            addNote.ForeColor = Design.mainColor;
            addNote.Inactive1 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addNote.Inactive2 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addNote.Active1 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addNote.Active2 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addNote.StrokeColor = Color.FromArgb(20,
                                                 Design.mainColor.R,
                                                 Design.mainColor.G,
                                                 Design.mainColor.B);
            addNote.MouseDown += button_MouseDown;
            addNote.MouseUp += button_MouseUp;

            addDirect.ForeColor = Design.mainColor;
            addDirect.Inactive1 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDirect.Inactive2 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDirect.Active1 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDirect.Active2 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDirect.StrokeColor = Color.FromArgb(20,
                                                 Design.mainColor.R,
                                                 Design.mainColor.G,
                                                 Design.mainColor.B);
            addDirect.MouseDown += button_MouseDown;
            addDirect.MouseUp += button_MouseUp;

            addTarget.ForeColor = Design.mainColor;
            addTarget.Inactive1 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTarget.Inactive2 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTarget.Active1 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTarget.Active2 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addTarget.StrokeColor = Color.FromArgb(20,
                                                 Design.mainColor.R,
                                                 Design.mainColor.G,
                                                 Design.mainColor.B);
            addTarget.MouseDown += button_MouseDown;
            addTarget.MouseUp += button_MouseUp;

            addDataService.ForeColor = Design.mainColor;
            addDataService.Inactive1 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDataService.Inactive2 = Color.FromArgb(50,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDataService.Active1 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDataService.Active2 = Color.FromArgb(80,
                                               Design.mainColor.R,
                                               Design.mainColor.G,
                                               Design.mainColor.B);
            addDataService.StrokeColor = Color.FromArgb(20,
                                                 Design.mainColor.R,
                                                 Design.mainColor.G,
                                                 Design.mainColor.B);
            addDataService.MouseDown += button_MouseDown;
            addDataService.MouseUp += button_MouseUp;

            exampleText.ForeColor = Design.mainColor;
            exampleLogo.BackColor = Design.mainColor;
            exampleColorBlock.Inactive1 = Design.mainColor;
            exampleColorBlock.Inactive2 = Design.mainColor;
            exampleColorBlock.Active1 = Design.mainColor;
            exampleColorBlock.Active2 = Design.mainColor;
            exampleColorBlock.StrokeColor = Design.mainColor;
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            ((AltoControls.AltoButton)sender).ForeColor = Design.mainColor;
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            ((AltoControls.AltoButton)sender).ForeColor = Color.White;
        }

        public static void Callback(object obj)
        {
            ServiceData.commandText = string.Format("SELECT task.id_task FROM task " +
                "INNER JOIN target ON target.id_target = task.id_target " +
                "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                "WHERE user_dir.id_user = {0} AND task.status = 0 AND task.failed = 0 AND task.date = '{1}.{2}.{3}' AND task.time_finish < '{4}:{5}'", 
                    User.userId, 
                    DateTime.Now.ToString("dd"), 
                    DateTime.Now.ToString("MM"), 
                    DateTime.Now.ToString("yyyy"),
                    DateTime.Now.ToString("HH"),
                    DateTime.Now.ToString("mm"));

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                while (ServiceData.reader.Read())
                {
                    idFailedTasks.Add(ServiceData.reader.GetInt32(0));
                }
            }
        }

        private static async void InstallFailedTask() 
        {
            if (idFailedTasks.Count != 0)
            {
                for (int i = 0; i < idFailedTasks.Count; i++)
                {
                    ServiceData.commandText = string.Format("SELECT task.id_task, direction.name, target.name, task.text FROM task " +
                       "INNER JOIN target ON target.id_target = task.id_target " +
                       "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                       "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                       "WHERE task.id_task = {0}", idFailedTasks[i]);

                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                    ServiceData.reader = ServiceData.command.ExecuteReader();
                    if (ServiceData.reader.HasRows)
                    {
                        ServiceData.reader.Read();
                        string commandText;
                        SQLiteCommand command;

                        if (MessageBox.Show("Вышло время выполнения задачи:\n\n" +
                                            "Направление: " + ServiceData.reader.GetString(1) + "\n" +
                                            "Цель: " + ServiceData.reader.GetString(2) + "\n" +
                                            "Задача: " + ServiceData.reader.GetString(3) + "\n\n" +
                                            "Вы выполнили эту задачу?", "Сообщение",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            commandText = @"UPDATE task SET failed = 0, status = 1 WHERE id_task = @id_task";
                        }
                        else
                        {
                            commandText = @"UPDATE task SET failed = 1, status = 0 WHERE id_task = @id_task";
                        }

                        command = new SQLiteCommand(commandText, ServiceData.connect);
                        command.Parameters.AddWithValue("@id_task", idFailedTasks[i]);
                        command.ExecuteNonQuery();
                    }
                }

                Design.RefreshPanel(WindowManager.flowPanelTasks);
                await WindowManager.SetTaskBlock();
                WeeklyStatistic.Refresh();

                idFailedTasks.Clear();
            }
        }

        private void status_task_none_Click(object sender, EventArgs e)
        {
            GlobalComponents.status_mark.Left = 900;
            Design.RefreshPanel(WindowManager.flowPanelTaskTarget);
            Design.heightContentTaskTarget = 0;

            ServiceData.commandText = string.Format("SELECT " +
                "task.id_task, task.date, task.time, task.time_finish, direction.name, direction.color_mark, " +
                "target.name, task.text, task.descr, task.failed, task.status FROM task " +
                "INNER JOIN target ON task.id_target = target.id_target " +
                "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                "INNER JOIN user ON user_dir.id_user = user.id_user " +
                "WHERE target.id_target = {0} AND task.status = 0 AND task.failed = 0 AND user.id_user = {1} ORDER BY task.date", 
                GlobalData.id_target, User.userId);

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                GlobalComponents.notFoundTaskTarget.Visible = false;
                List<TaskBlock> tasks = new List<TaskBlock>();

                while (ServiceData.reader.Read())
                {
                    tasks.Add(new TaskBlock(
                        WindowManager.flowPanelTaskTarget,
                        Convert.ToInt32(ServiceData.reader.GetValue(0)),
                        ServiceData.reader.GetString(1),
                        ServiceData.reader.GetString(2),
                        ServiceData.reader.GetString(3),
                        ServiceData.reader.GetString(4),
                        ServiceData.reader.GetString(5),
                        ServiceData.reader.GetString(6),
                        ServiceData.reader.GetString(7),
                        ServiceData.reader.GetValue(8).ToString(),
                        Convert.ToInt32(ServiceData.reader.GetValue(9)),
                        Convert.ToInt32(ServiceData.reader.GetValue(10))));
                }
            }
            else
            {
                GlobalComponents.notFoundTaskTarget.Visible = true;
            }

            if (WindowManager.flowPanelTaskTarget.Height < Design.heightContentTaskTarget)
            {
                GlobalComponents.task_targetScrollTipTop.Visible = true;
                GlobalComponents.task_targetScrollTipBottom.Visible = true;
            }
            else
            {
                GlobalComponents.task_targetScrollTipTop.Visible = false;
                GlobalComponents.task_targetScrollTipBottom.Visible = false;
            }
        }

        private void status_task_done_Click(object sender, EventArgs e)
        {
            GlobalComponents.status_mark.Left = 923;
            Design.RefreshPanel(WindowManager.flowPanelTaskTarget);
            Design.heightContentTaskTarget = 0;

            ServiceData.commandText = string.Format("SELECT " +
                "task.id_task, task.date, task.time, task.time_finish, direction.name,  direction.color_mark, " +
                "target.name, task.text, task.descr, task.failed, task.status FROM task " +
                "INNER JOIN target ON task.id_target = target.id_target " +
                "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                "INNER JOIN user ON user_dir.id_user = user.id_user " +
                "WHERE target.id_target = {0} AND task.status = 1 AND task.failed = 0 AND user.id_user = {1} ORDER BY task.date", 
                GlobalData.id_target, User.userId);

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                GlobalComponents.notFoundTaskTarget.Visible = false;
                List<TaskBlock> tasks = new List<TaskBlock>();
                PictureBox boxStatus = new PictureBox();

                boxStatus = new PictureBox();
                boxStatus.SizeMode = PictureBoxSizeMode.CenterImage;
                boxStatus.Width = 430;
                boxStatus.Height = 35;
                boxStatus.Image = Properties.Resources.done_tasks;
                WindowManager.flowPanelTaskTarget.Controls.Add(boxStatus);
                Design.heightContentTaskTarget += boxStatus.Height;

                while (ServiceData.reader.Read())
                {
                    tasks.Add(new TaskBlock(
                        WindowManager.flowPanelTaskTarget,
                        Convert.ToInt32(ServiceData.reader.GetValue(0)),
                        ServiceData.reader.GetString(1),
                        ServiceData.reader.GetString(2),
                        ServiceData.reader.GetString(3),
                        ServiceData.reader.GetString(4),
                        ServiceData.reader.GetString(5),
                        ServiceData.reader.GetString(6),
                        ServiceData.reader.GetString(7),
                        ServiceData.reader.GetValue(8).ToString(),
                        Convert.ToInt32(ServiceData.reader.GetValue(9)),
                        Convert.ToInt32(ServiceData.reader.GetValue(10))));
                }
            }
            else
            {
                GlobalComponents.notFoundTaskTarget.Visible = true;
            }

            if (WindowManager.flowPanelTaskTarget.Height < Design.heightContentTaskTarget)
            {
                GlobalComponents.task_targetScrollTipTop.Visible = true;
                GlobalComponents.task_targetScrollTipBottom.Visible = true;
            }
            else
            {
                GlobalComponents.task_targetScrollTipTop.Visible = false;
                GlobalComponents.task_targetScrollTipBottom.Visible = false;
            }
        }

        private void status_task_fail_Click(object sender, EventArgs e)
        {
            GlobalComponents.status_mark.Left = 947;
            Design.RefreshPanel(WindowManager.flowPanelTaskTarget);
            Design.heightContentTaskTarget = 0;

            ServiceData.commandText = string.Format("SELECT " +
                "task.id_task, task.date, task.time, task.time_finish, direction.name,  direction.color_mark, " +
                "target.name, task.text, task.descr, task.failed, task.status FROM task " +
                "INNER JOIN target ON task.id_target = target.id_target " +
                "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                "INNER JOIN user ON user_dir.id_user = user.id_user " +
                "WHERE target.id_target = {0} AND task.status = 0 AND task.failed = 1 AND user.id_user = {1} ORDER BY task.date", 
                GlobalData.id_target, User.userId);

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                GlobalComponents.notFoundTaskTarget.Visible = false;
                List<TaskBlock> tasks = new List<TaskBlock>();
                PictureBox boxStatus = new PictureBox();

                boxStatus = new PictureBox();
                boxStatus.SizeMode = PictureBoxSizeMode.CenterImage;
                boxStatus.Width = 430;
                boxStatus.Height = 35;
                boxStatus.Image = Properties.Resources.fail_tasks;
                WindowManager.flowPanelTaskTarget.Controls.Add(boxStatus);
                Design.heightContentTaskTarget += boxStatus.Height;

                while (ServiceData.reader.Read())
                {
                    tasks.Add(new TaskBlock(
                        WindowManager.flowPanelTaskTarget,
                        Convert.ToInt32(ServiceData.reader.GetValue(0)),
                        ServiceData.reader.GetString(1),
                        ServiceData.reader.GetString(2),
                        ServiceData.reader.GetString(3),
                        ServiceData.reader.GetString(4),
                        ServiceData.reader.GetString(5),
                        ServiceData.reader.GetString(6),
                        ServiceData.reader.GetString(7),
                        ServiceData.reader.GetValue(8).ToString(),
                        Convert.ToInt32(ServiceData.reader.GetValue(9)),
                        Convert.ToInt32(ServiceData.reader.GetValue(10))));
                }
            }
            else
            {
                GlobalComponents.notFoundTaskTarget.Visible = true;
            }

            if (WindowManager.flowPanelTaskTarget.Height < Design.heightContentTaskTarget)
            {
                GlobalComponents.task_targetScrollTipTop.Visible = true;
                GlobalComponents.task_targetScrollTipBottom.Visible = true;
            }
            else
            {
                GlobalComponents.task_targetScrollTipTop.Visible = false;
                GlobalComponents.task_targetScrollTipBottom.Visible = false;
            }
        }

        private void addNote_Click(object sender, EventArgs e)
        {
            if (GlobalData.addNoteForm == null)
            {
                GlobalData.addNoteForm = new AddNoteForm();
                GlobalData.addNoteForm.ShowDialog();
            }
            else 
            {
                GlobalData.addNoteForm.ShowDialog();
            }
        }

        private void addDirect_Click(object sender, EventArgs e)
        {
            if (GlobalData.addDirectionForm == null)
            {
                GlobalData.addDirectionForm = new AddDirectionForm();
                GlobalData.addDirectionForm.ShowDialog();
            }
            else
            {
                GlobalData.addDirectionForm.ShowDialog();
            }
        }

        private void addDataService_Click(object sender, EventArgs e)
        {
            if (GlobalData.addDataService == null)
            {
                GlobalData.addDataService = new AddDataService();
                GlobalData.addDataService.ShowDialog();
            }
            else
            {
                GlobalData.addDataService.ShowDialog();
            }
        }

        private void labelChangeUserPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл

            user_photo.Image.Dispose();
            string newPath = AppDomain.CurrentDomain.BaseDirectory + @"user_photo\userPhoto" + 
                User.userId.ToString() + 
                DateTime.Now.Minute.ToString() + 
                DateTime.Now.Second.ToString() + ".png";

            FileInfo fileInf = new FileInfo(openFileDialog.FileName);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                User.SetPhoto(newPath);

                ServiceData.commandText = @"UPDATE user SET photo = @pathPhoto WHERE id_user = @id_user";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.Parameters.AddWithValue("@pathPhoto", newPath);
                ServiceData.command.Parameters.AddWithValue("@id_user", User.userId);
                ServiceData.command.ExecuteNonQuery();

                userPhotoSettings.Load(User.pathPhoto);
                user_photo.Load(User.pathPhoto);
            }
        }

        private void labelChangeUserPhoto_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.DimGray;
        }

        private void labelChangeUserPhoto_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Design.mainColor;
        }

        private void buttonChangeLogin_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).AccessibleName == "change")
            {
                userLogin.ReadOnly = false;
                userLogin.ForeColor = Color.Black;
                ((PictureBox)sender).Image = Properties.Resources.okey;
                ((PictureBox)sender).AccessibleName = "okey";
            }
            else 
            {
                userLogin.ReadOnly = true;
                userLogin.ForeColor = Color.Gray;

                ServiceData.commandText = @"UPDATE user SET login = @login WHERE id_user = @id_user";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.Parameters.AddWithValue("@login", userLogin.Text);
                ServiceData.command.Parameters.AddWithValue("@id_user", User.userId);
                ServiceData.command.ExecuteNonQuery();

                MessageBox.Show(
                    "Логин изменен!",
                    "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ((PictureBox)sender).Image = Properties.Resources.changeData;
                ((PictureBox)sender).AccessibleName = "change";
            }
        }

        private void userLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                userLogin.ReadOnly = true;
                userLogin.ForeColor = Color.Gray;

                ServiceData.commandText = @"UPDATE user SET login = @login WHERE id_user = @id_user";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.Parameters.AddWithValue("@login", userLogin.Text);
                ServiceData.command.Parameters.AddWithValue("@id_user", User.userId);
                ServiceData.command.ExecuteNonQuery();

                MessageBox.Show(
                    "Логин изменен!",
                    "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonGreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraggingGreen)
            {
                if (buttonGreen.Left >= lineGreen.Left && buttonGreen.Left + buttonGreen.Width <= lineGreen.Left + lineGreen.Width)
                {
                    buttonGreen.Left = buttonGreen.Left + (e.X - currentXGreen);
                }
                else if (buttonGreen.Left < lineGreen.Left)
                {
                    buttonGreen.Left = lineGreen.Left;
                    isDraggingGreen = false;
                }
                else if (buttonGreen.Left + buttonGreen.Width > lineGreen.Left + lineGreen.Width)
                {
                    buttonGreen.Left = lineGreen.Left + lineGreen.Width - buttonGreen.Width;
                    isDraggingGreen = false;
                }

                valueGreen = buttonGreen.Left - lineGreen.Left;
                if (valueGreen >= 10 && valueGreen <= 255)
                {
                    green.Text = valueGreen.ToString();
                }
            }
        }

        private void buttonGreen_MouseDown(object sender, MouseEventArgs e)
        {
            isDraggingGreen = true;
            currentXGreen = e.X;
        }

        private void buttonGreen_MouseUp(object sender, MouseEventArgs e)
        {
            isDraggingGreen = false;

            INIManager.WriteInt("Design", "Green", valueGreen);
            exampleLogo.BackColor = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                                  Convert.ToInt32(INIManager.Read("Design", "Green")),
                                                  Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleText.ForeColor = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                                  Convert.ToInt32(INIManager.Read("Design", "Green")),
                                                  Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.Inactive1 = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.Inactive2 = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.Active1 = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.Active2 = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.StrokeColor = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
        }

        private void buttonBlue_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraggingBlue)
            {
                if (buttonBlue.Left >= lineBlue.Left && buttonBlue.Left + buttonBlue.Width <= lineBlue.Left + lineBlue.Width)
                {
                    buttonBlue.Left = buttonBlue.Left + (e.X - currentXBlue);
                }
                else if (buttonBlue.Left < lineBlue.Left)
                {
                    buttonBlue.Left = lineBlue.Left;
                    isDraggingBlue = false;
                }
                else if (buttonBlue.Left + buttonBlue.Width > lineBlue.Left + lineBlue.Width)
                {
                    buttonBlue.Left = lineBlue.Left + lineBlue.Width - buttonBlue.Width;
                    isDraggingBlue = false;
                }

                valueBlue = buttonBlue.Left - lineBlue.Left;
                if (valueBlue >= 10 && valueBlue <= 255)
                {
                    Blue.Text = valueBlue.ToString();
                }
            }
        }

        private void buttonBlue_MouseDown(object sender, MouseEventArgs e)
        {
            isDraggingBlue = true;
            currentXBlue = e.X;
        }

        private void buttonBlue_MouseUp(object sender, MouseEventArgs e)
        {
            isDraggingBlue = false;

            INIManager.WriteInt("Design", "Blue", valueBlue);
            exampleLogo.BackColor = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                                  Convert.ToInt32(INIManager.Read("Design", "Green")),
                                                  Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleText.ForeColor = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                                  Convert.ToInt32(INIManager.Read("Design", "Green")),
                                                  Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.Inactive1 = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.Inactive2 = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.Active1 = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.Active2 = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.StrokeColor = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
        }

        private void rebootSystem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void rebootSystem_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Design.mainColor;
        }

        private void rebootSystem_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.DarkGray;
        }

        private void flowTasks_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowTasks.Height < Design.heightContentTasks)
            {
                taskScrollTipTop.Visible = true;
                taskScrollTipBottom.Visible = true;
            }
            else
            {
                taskScrollTipTop.Visible = false;
                taskScrollTipBottom.Visible = false;
            }
        }

        private void flowNotes_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (flowNotes.Height < Design.heightContentNotes)
            {
                noteScrollTipTop.Visible = true;
                noteScrollTipBottom.Visible = true;
            }
            else
            {
                noteScrollTipTop.Visible = false;
                noteScrollTipBottom.Visible = false;
            }
        }

        private void flowNotes_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowNotes.Height < Design.heightContentNotes)
            {
                noteScrollTipTop.Visible = true;
                noteScrollTipBottom.Visible = true;
            }
            else
            {
                noteScrollTipTop.Visible = false;
                noteScrollTipBottom.Visible = false;
            }
        }

        private void flowTarget_ControlAdded(object sender, ControlEventArgs e)
        {
            not_found_target.Visible = false;
            if (flowTarget.Height < Design.heightContentTarget)
            {   
                targetScrollTipTop.Visible = true;
                targetScrollTipBottom.Visible = true;
            }
            else
            {
                targetScrollTipTop.Visible = false;
                targetScrollTipBottom.Visible = false;
            }
        }

        private void achieves_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 220);
            tabs.SelectedTab = tab_stat;
            active_item.Image = Properties.Resources.stat;
        }

        private void perform_Click(object sender, EventArgs e)
        {
            Design.MovePanel(active_item, Enums.Direction.Vertical, active_item.Top, 220);
            tabs.SelectedTab = tab_stat;
            active_item.Image = Properties.Resources.stat;
        }

        private void closeApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Зыкрыть приложение?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void hideApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        string oldPass;
        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).AccessibleName == "change")
            {
                userPassword.ReadOnly = false;
                userPassword.ForeColor = Color.Black;
                oldPass = userPassword.Text;
                userPassword.Text = "";
                ((PictureBox)sender).Image = Properties.Resources.okey;
                ((PictureBox)sender).AccessibleName = "okey";
            }
            else 
            {
                if (userPassword.Text != "")
                {
                    if (oldPass != DBService.GetMD5Hash(userPassword.Text))
                    {
                        userPassword.ReadOnly = true;
                        userPassword.ForeColor = Color.Gray;

                        ServiceData.commandText = @"UPDATE user SET password = @password WHERE id_user = @id_user";
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                        ServiceData.command.Parameters.AddWithValue("@password", DBService.GetMD5Hash(userPassword.Text));
                        ServiceData.command.Parameters.AddWithValue("@id_user", User.userId);
                        ServiceData.command.ExecuteNonQuery();

                        MessageBox.Show(
                            "Пароль изменен!",
                            "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        userPassword.Text = DBService.GetMD5Hash(userPassword.Text);
                        ((PictureBox)sender).Image = Properties.Resources.changeData;
                        ((PictureBox)sender).AccessibleName = "change";
                    }
                    else
                    {
                        userPassword.ReadOnly = true;
                        userPassword.ForeColor = Color.Gray;
                        userPassword.Text = oldPass;

                        ((PictureBox)sender).Image = Properties.Resources.changeData;
                        ((PictureBox)sender).AccessibleName = "change";
                    }
                }
                else
                {
                    userPassword.ReadOnly = true;
                    userPassword.ForeColor = Color.Gray;
                    userPassword.Text = oldPass;

                    ((PictureBox)sender).Image = Properties.Resources.changeData;
                    ((PictureBox)sender).AccessibleName = "change";
                }
            }
        }

        private void buttonRed_MouseUp(object sender, MouseEventArgs e)
        {
            isDraggingRed = false;

            INIManager.WriteInt("Design", "Red", valueRed);
            exampleLogo.BackColor = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                                  Convert.ToInt32(INIManager.Read("Design", "Green")),
                                                  Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleText.ForeColor = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                                  Convert.ToInt32(INIManager.Read("Design", "Green")),
                                                  Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.Inactive1 = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.Inactive2 = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.Active1 = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.Active2 = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
            exampleColorBlock.StrokeColor = Color.FromArgb(Convert.ToInt32(INIManager.Read("Design", "Red")),
                                          Convert.ToInt32(INIManager.Read("Design", "Green")),
                                          Convert.ToInt32(INIManager.Read("Design", "Blue")));
        }

        private void buttonRed_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraggingRed)
            {
                if (buttonRed.Left >= lineRed.Left && buttonRed.Left + buttonRed.Width <= lineRed.Left + lineRed.Width)
                {
                    buttonRed.Left = buttonRed.Left + (e.X - currentXRed);
                }
                else if (buttonRed.Left < lineRed.Left)
                {
                    buttonRed.Left = lineRed.Left;
                    isDraggingRed = false;
                }
                else if (buttonRed.Left + buttonRed.Width > lineRed.Left + lineRed.Width)
                {
                    buttonRed.Left = lineRed.Left + lineRed.Width - buttonRed.Width;
                    isDraggingRed = false;
                }

                valueRed = buttonRed.Left - lineRed.Left;
                if (valueRed >= 10 && valueRed <= 255)
                {
                    red.Text = valueRed.ToString();
                }
            }
        }

        private void buttonRed_MouseDown(object sender, MouseEventArgs e)
        {
            isDraggingRed = true;
            currentXRed = e.X;
        }

        private void userPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                if (userPassword.Text != "")
                {
                    if (oldPass != DBService.GetMD5Hash(userPassword.Text))
                    {
                        userPassword.ReadOnly = true;
                        userPassword.ForeColor = Color.Gray;

                        ServiceData.commandText = @"UPDATE user SET password = @password WHERE id_user = @id_user";
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                        ServiceData.command.Parameters.AddWithValue("@password", DBService.GetMD5Hash(userPassword.Text));
                        ServiceData.command.Parameters.AddWithValue("@id_user", User.userId);
                        ServiceData.command.ExecuteNonQuery();

                        MessageBox.Show(
                            "Пароль изменен!",
                            "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        userPassword.Text = DBService.GetMD5Hash(userPassword.Text);
                    }
                }
                else 
                {
                    userPassword.ReadOnly = true;
                    userPassword.ForeColor = Color.Gray;
                    userPassword.Text = oldPass;
                }
            }
        }

        private void buttonChangeEmail_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).AccessibleName == "change")
            {
                userEmail.ReadOnly = false;
                userEmail.ForeColor = Color.Black;
                ((PictureBox)sender).Image = Properties.Resources.okey;
                ((PictureBox)sender).AccessibleName = "okey";
            }
            else
            {
                userEmail.ReadOnly = true;
                userEmail.ForeColor = Color.Gray;

                ServiceData.commandText = @"UPDATE user SET email = @email WHERE id_user = @id_user";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
                ServiceData.command.Parameters.AddWithValue("@email", userEmail.Text);
                ServiceData.command.Parameters.AddWithValue("@id_user", User.userId);
                ServiceData.command.ExecuteNonQuery();

                MessageBox.Show(
                    "Email изменен!",
                    "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ((PictureBox)sender).Image = Properties.Resources.changeData;
                ((PictureBox)sender).AccessibleName = "change";
            }
        }

        private void addTarget_Click(object sender, EventArgs e)
        {
            if (GlobalData.addTargetForm == null)
            {
                GlobalData.addTargetForm = new AddTargetForm();
                GlobalData.addTargetForm.ShowDialog();
            }
            else
            {
                GlobalData.addTargetForm.ShowDialog();
            }
        }

        private void todayStat_Click(object sender, EventArgs e)
        {
            changePeriod((Label)sender, Enums.PeriodStatistic.today);
        }

        private void labelWeek_Click(object sender, EventArgs e)
        {
            changePeriod((Label)sender, Enums.PeriodStatistic.week);
        }

        private void labelMonth_Click(object sender, EventArgs e)
        {
            changePeriod((Label)sender, Enums.PeriodStatistic.month);
        }
    }
}
