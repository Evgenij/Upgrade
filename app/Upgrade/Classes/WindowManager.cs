using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using Upgrade.Forms;
using System.Security.Cryptography;
using Upgrade.Classes.Blocks;

namespace Upgrade.Classes
{
    class WindowManager
    {
        private static List<TaskBlock> taskBlock = new List<TaskBlock>();
        private static PictureBox[] boxStatus = new PictureBox[2];
        private static List<NoteBlock> noteBlock = new List<NoteBlock>();
        private static List<DirectionBlock> directionBlock = new List<DirectionBlock>();
        private static List<AchievBlock> achievBlock = new List<AchievBlock>();
        private static List<ScheduleBlock> scheduleBlock = new List<ScheduleBlock>();
        private static List<DataServiceBlock> dataServiceBlock = new List<DataServiceBlock>();

        public enum TypeBlock
        {
            Tasks,
            Notes
        }
        public static Enums.Period period;
        public static Enums.StatusTask status;
        public static int id_direct, id_target;

        public static FlowLayoutPanel flowPanelTasks;
        public static FlowLayoutPanel flowPanelNotes;
        public static FlowLayoutPanel flowPanelDirect;
        public static FlowLayoutPanel flowPanelTarget;
        public static FlowLayoutPanel flowPanelTaskTarget;
        public static FlowLayoutPanel flowPanelAchiev;
        public static FlowLayoutPanel flowPanelSchedule;
        public static FlowLayoutPanel flowPanelServices;

        public static async Task SetPanelsMainWindow()
        {
            await SetTaskBlock();
            await SetNoteBlock();
        }

        public static void SetFlowPanels(FlowLayoutPanel flowTask, 
                                         FlowLayoutPanel flowNotes, 
                                         FlowLayoutPanel flowDirect, 
                                         FlowLayoutPanel flowTarget,
                                         FlowLayoutPanel flowTaskTarget,
                                         FlowLayoutPanel flowAchiev,
                                         FlowLayoutPanel flowSchedule,
                                         FlowLayoutPanel flowDataService)
        {
            flowPanelTasks = flowTask;
            flowPanelNotes = flowNotes;
            flowPanelDirect = flowDirect;
            flowPanelTarget = flowTarget;
            flowPanelTaskTarget = flowTaskTarget;
            flowPanelAchiev = flowAchiev;
            flowPanelSchedule = flowSchedule;
            flowPanelServices = flowDataService;
        }

        public static async Task SetTaskBlock()
        {
            string[] sql_command = new string[6]; 
            string[] date = new string[7];

            sql_command[0] = "SELECT " +
                "task.id_task, task.date, task.time, task.time_finish, direction.name, direction.color_mark, " +
                "target.name, task.text, task.descr, task.failed, task.status FROM task " +
                "INNER JOIN target ON task.id_target = target.id_target " +
                "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                "INNER JOIN user ON user_dir.id_user = user.id_user " +
                "WHERE user.id_user = {0} ";

            // все задачи
            sql_command[1] = "AND task.status = 0 AND task.failed = 0 ";
            // выполненные задачи
            sql_command[2] = "AND task.status = 1 AND task.failed = 0 ";
            // проваленные задачи
            sql_command[3] = "AND task.failed = 1 ";

            if (id_direct != 0)
            {
                sql_command[4] = string.Format("AND direction.id_direct = {0} ", id_direct);
            }
            else 
            {
                sql_command[4] = "";
            }
            if (id_target != 0) 
            {
                sql_command[5] = string.Format("AND target.id_target = {0} ", id_target);
            }
            else
            {
                sql_command[5] = "";
            }


            if (period == Enums.Period.LastWeek)
            {
                for (int i = 0; i < date.Length; i++)
                {
                    date[i] = WeeklyStatistic.GetDaysLastWeek().ElementAt(6-i);
                }
                //for (int i = 0; i < date.Length; i++) 
                //{
                //    MessageBox.Show(date[i]);
                //}
            }
            else if (period == Enums.Period.Yesterday)
            {
                date[0] = DateTime.Now.AddDays(-1).ToString("dd");
            }
            else if (period == Enums.Period.Today)
            {
                date[0] = DateTime.Now.ToString("dd");
            }
            else if (period == Enums.Period.Tomorrow)
            {
                date[0] = DateTime.Now.AddDays(1).ToString("dd");
            }
            else if (period == Enums.Period.CurrentWeek)
            {
                date = WeeklyStatistic.GetDaysCurrentWeek();
                //for (int i = 0; i < date.Length; i++)
                //{
                //    MessageBox.Show(date[i]);
                //}
            }


            if (period == Enums.Period.Today || period == Enums.Period.Tomorrow || period == Enums.Period.Yesterday)
            {
                if (status == Enums.StatusTask.Empty)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        ServiceData.commandText = string.Format(sql_command[0] + sql_command[i] + sql_command[4] + sql_command[5] + 
                                                                "AND task.date = '{1}.{2}.{3}' ORDER BY task.time",
                                                                User.userId,
                                                                date.First(),
                                                                DateTime.Now.ToString("MM"),
                                                                DateTime.Now.ToString("yyyy"));

                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                        ServiceData.reader = ServiceData.command.ExecuteReader();
                        if (ServiceData.reader.HasRows)
                        {
                            if (i == 2)
                            {
                                boxStatus[0] = new PictureBox();
                                boxStatus[0].SizeMode = PictureBoxSizeMode.CenterImage;
                                boxStatus[0].Width = 430;
                                boxStatus[0].Height = 35;
                                boxStatus[0].Image = Properties.Resources.done_tasks;
                                flowPanelTasks.Controls.Add(boxStatus[0]);
                            }
                            else if (i == 3)
                            {
                                boxStatus[1] = new PictureBox();
                                boxStatus[1].SizeMode = PictureBoxSizeMode.CenterImage;
                                boxStatus[1].Width = 430;
                                boxStatus[1].Height = 35;
                                boxStatus[1].Image = Properties.Resources.fail_tasks;
                                flowPanelTasks.Controls.Add(boxStatus[1]);
                            }

                            while (await ServiceData.reader.ReadAsync())
                            {
                                taskBlock.Add(new TaskBlock(
                                    flowPanelTasks,
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
                    }
                }
                else if (status == Enums.StatusTask.Done)
                {
                    ServiceData.commandText = string.Format(sql_command[0] + sql_command[2] + sql_command[4] + sql_command[5] + 
                                                            "AND task.date = '{1}.{2}.{3}' ORDER BY task.time",
                                                            User.userId,
                                                            date.First(),
                                                            DateTime.Now.ToString("MM"),
                                                            DateTime.Now.ToString("yyyy"));

                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                    ServiceData.reader = ServiceData.command.ExecuteReader();
                    if (ServiceData.reader.HasRows)
                    {
                        boxStatus[0] = new PictureBox();
                        boxStatus[0].SizeMode = PictureBoxSizeMode.CenterImage;
                        boxStatus[0].Width = 430;
                        boxStatus[0].Height = 35;
                        boxStatus[0].Image = Properties.Resources.done_tasks;
                        flowPanelTasks.Controls.Add(boxStatus[0]);

                        while (await ServiceData.reader.ReadAsync())
                        {
                            taskBlock.Add(new TaskBlock(
                                flowPanelTasks,
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
                }
                else if (status == Enums.StatusTask.Failed)
                {
                    ServiceData.commandText = string.Format(sql_command[0] + sql_command[3] + sql_command[4] + sql_command[5] + 
                                                            "AND task.date = '{1}.{2}.{3}' ORDER BY task.time",
                                                            User.userId,
                                                            date.First(),
                                                            DateTime.Now.ToString("MM"),
                                                            DateTime.Now.ToString("yyyy"));

                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                    ServiceData.reader = ServiceData.command.ExecuteReader();
                    if (ServiceData.reader.HasRows)
                    {
                        boxStatus[0] = new PictureBox();
                        boxStatus[0].SizeMode = PictureBoxSizeMode.CenterImage;
                        boxStatus[0].Width = 430;
                        boxStatus[0].Height = 35;
                        boxStatus[0].Image = Properties.Resources.fail_tasks;
                        flowPanelTasks.Controls.Add(boxStatus[0]);

                        while (await ServiceData.reader.ReadAsync())
                        {
                            taskBlock.Add(new TaskBlock(
                                flowPanelTasks,
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
                }
            }
            else
            {
                if (status == Enums.StatusTask.Empty)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        ServiceData.commandText = string.Format(sql_command[0] + sql_command[i] + sql_command[4] + sql_command[5] +
                                                                "AND task.date BETWEEN '{1}.{3}.{4}' AND '{2}.{3}.{4}' ORDER BY task.date",
                                                                User.userId,
                                                                date.First(),
                                                                date.Last(),
                                                                DateTime.Now.ToString("MM"),
                                                                DateTime.Now.ToString("yyyy"));

                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                        ServiceData.reader = ServiceData.command.ExecuteReader();
                        if (ServiceData.reader.HasRows)
                        {
                            if (i == 2)
                            {
                                boxStatus[0] = new PictureBox();
                                boxStatus[0].SizeMode = PictureBoxSizeMode.CenterImage;
                                boxStatus[0].Width = 430;
                                boxStatus[0].Height = 35;
                                boxStatus[0].Image = Properties.Resources.done_tasks;
                                flowPanelTasks.Controls.Add(boxStatus[0]);
                            }
                            else if (i == 3)
                            {
                                boxStatus[1] = new PictureBox();
                                boxStatus[1].SizeMode = PictureBoxSizeMode.CenterImage;
                                boxStatus[1].Width = 430;
                                boxStatus[1].Height = 35;
                                boxStatus[1].Image = Properties.Resources.fail_tasks;
                                flowPanelTasks.Controls.Add(boxStatus[1]);
                            }

                            while (await ServiceData.reader.ReadAsync())
                            {
                                taskBlock.Add(new TaskBlock(
                                    flowPanelTasks,
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
                    }
                }
                else if (status == Enums.StatusTask.Done)
                {
                    ServiceData.commandText = string.Format(sql_command[0] + sql_command[2] + sql_command[4] + sql_command[5] +
                                                            "AND task.date BETWEEN '{1}.{3}.{4}' AND '{2}.{3}.{4}' ORDER BY task.date",
                                                            User.userId,
                                                            date.First(), date.Last(),
                                                            DateTime.Now.ToString("MM"),
                                                            DateTime.Now.ToString("yyyy"));
                    
                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                    ServiceData.reader = ServiceData.command.ExecuteReader();
                    if (ServiceData.reader.HasRows)
                    {
                        boxStatus[0] = new PictureBox();
                        boxStatus[0].SizeMode = PictureBoxSizeMode.CenterImage;
                        boxStatus[0].Width = 430;
                        boxStatus[0].Height = 35;
                        boxStatus[0].Image = Properties.Resources.done_tasks;
                        flowPanelTasks.Controls.Add(boxStatus[0]);

                        while (await ServiceData.reader.ReadAsync())
                        {
                            taskBlock.Add(new TaskBlock(
                                flowPanelTasks,
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
                }
                else if (status == Enums.StatusTask.Failed)
                {
                    ServiceData.commandText = string.Format(sql_command[0] + sql_command[3] + sql_command[4] + sql_command[5] +
                                                            "AND task.date BETWEEN '{1}.{3}.{4}' AND '{2}.{3}.{4}' ORDER BY task.date",
                                                            User.userId,
                                                            date.First(), date.Last(),
                                                            DateTime.Now.ToString("MM"),
                                                            DateTime.Now.ToString("yyyy"));

                    ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                    ServiceData.reader = ServiceData.command.ExecuteReader();
                    if (ServiceData.reader.HasRows)
                    {
                        boxStatus[0] = new PictureBox();
                        boxStatus[0].SizeMode = PictureBoxSizeMode.CenterImage;
                        boxStatus[0].Width = 430;
                        boxStatus[0].Height = 35;
                        boxStatus[0].Image = Properties.Resources.fail_tasks;
                        flowPanelTasks.Controls.Add(boxStatus[0]);

                        while (await ServiceData.reader.ReadAsync())
                        {
                            taskBlock.Add(new TaskBlock(
                                flowPanelTasks,
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
                }
            }
        }

        public static async Task SetNoteBlock()
        {
            ServiceData.commandText = @"SELECT id_note, text FROM note WHERE id_user = @user_id";
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
            ServiceData.command.Parameters.AddWithValue("@user_id", User.userId);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                while (await ServiceData.reader.ReadAsync())
                {
                    noteBlock.Add(new NoteBlock(
                        flowPanelNotes,
                        Convert.ToInt32(ServiceData.reader.GetValue(0)),
                        ServiceData.reader.GetString(1)));
                }
            }
        }

        public static async Task SetDirectBlock()
        {
            ServiceData.commandText = string.Format("SELECT direction.id_direct, direction.name, direction.color_mark FROM direction " +
                "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                "INNER JOIN user ON user_dir.id_user = user.id_user " +
                "WHERE user.id_user = {0}", User.userId);

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                while (await ServiceData.reader.ReadAsync())
                {
                    directionBlock.Add(new DirectionBlock(flowPanelDirect,
                        ServiceData.reader.GetInt32(0), 
                        ServiceData.reader.GetString(1), 
                        ServiceData.reader.GetString(2)));
                }
            }
        }

        public static async Task SetTargetBlock()
        {
            ServiceData.commandText = string.Format("SELECT target.id_target, target.name FROM target " +
                "INNER JOIN direction ON direction.id_direct = target.id_direct " +
                "INNER JOIN user_dir ON user_dir.id_direct = direction.id_direct " +
                "INNER JOIN user ON user.id_user = user_dir.id_user " +
                "WHERE user.id_user = {0}", User.userId);

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                List<TargetBlock> targets = new List<TargetBlock>();
                while (await ServiceData.reader.ReadAsync())
                {
                    targets.Add(new TargetBlock(flowPanelTarget, ServiceData.reader.GetInt32(0), ServiceData.reader.GetString(1)));
                }
            }
        }

        public static async Task SetAchievBlock(string nameCateg)
        {
            ServiceData.commandText = @"SELECT achievement.id_achiev, achievement.name, " +
                "achievement.descr, achievement.current_score, achievement.final_score, achievement.status FROM achievement " +
                "INNER JOIN achiev_categ ON achiev_categ.id_achiev = achievement.id_achiev " +
                "INNER JOIN category ON category.id_categ = achiev_categ.id_categ " +
                "WHERE category.name = @nameCateg ORDER BY achievement.status";
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
            ServiceData.command.Parameters.AddWithValue("@nameCateg", nameCateg);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                while (await ServiceData.reader.ReadAsync())
                {
                    achievBlock.Add(new AchievBlock(
                        flowPanelAchiev, 
                        ServiceData.reader.GetInt32(0),
                        ServiceData.reader.GetString(1), 
                        ServiceData.reader.GetString(2),
                        ServiceData.reader.GetInt32(3),
                        ServiceData.reader.GetInt32(4),
                        ServiceData.reader.GetInt32(5)));
                }
            }
        }

        public static async Task SetSheduleBlock()
        {
            ServiceData.commandText = @"SELECT 
                schedule.id_sched,
                schedule.name, 
                direction.name, 
                direction.color_mark, 
                target.name,
                task.text, 
                task.descr, 
                task.time,
                task.time_finish FROM schedule 
                INNER JOIN sched_task ON sched_task.id_sched = schedule.id_sched
                INNER JOIN day ON day.id_day = sched_task.id_day
                INNER JOIN task ON task.id_task = sched_task.id_task
                INNER JOIN target ON task.id_target = target.id_target 
                INNER JOIN direction ON target.id_direct = direction.id_direct 
                INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct 
                INNER JOIN user ON user_dir.id_user = user.id_user 
                WHERE user.id_user = @user
                GROUP BY schedule.id_sched";

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
            ServiceData.command.Parameters.AddWithValue("@user", User.userId);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                while (await ServiceData.reader.ReadAsync())
                {
                    scheduleBlock.Add(new ScheduleBlock(flowPanelSchedule, 
                        ServiceData.reader.GetInt32(0), 
                        ServiceData.reader.GetString(1),
                        ServiceData.reader.GetString(2),
                        ServiceData.reader.GetString(3),
                        ServiceData.reader.GetString(4),
                        ServiceData.reader.GetString(5),
                        ServiceData.reader.GetValue(6).ToString(),
                        ServiceData.reader.GetString(7),
                        ServiceData.reader.GetString(8)));
                }
            }
        }

        public static async Task SetDataServiceBlock()
        {
            ServiceData.commandText = @"SELECT 
                data_service.id_service,                
                data_service.login, 
                data_service.password, 
                data_service.em_ph 
                FROM data_service 
                INNER JOIN user ON user.id_user = data_service.id_user
                WHERE user.id_user = @user";

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
            ServiceData.command.Parameters.AddWithValue("@user", User.userId);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                while (await ServiceData.reader.ReadAsync())
                {
                    dataServiceBlock.Add(new DataServiceBlock(
                        flowPanelServices,
                        ServiceData.reader.GetInt32(0),
                        ServiceData.reader.GetString(1),
                        ServiceData.reader.GetString(2),
                        ServiceData.reader.GetString(3)));
                }
            }
        }
    }
}
