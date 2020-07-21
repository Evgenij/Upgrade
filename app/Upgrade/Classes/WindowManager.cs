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

namespace Upgrade.Classes
{
    class WindowManager
    {
        private static List<TaskBlock> taskBlock = new List<TaskBlock>();
        private static List<NoteBlock> noteBlock = new List<NoteBlock>();
        private static PictureBox[] boxStatus = new PictureBox[2];

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

        public static async Task CreatePanelMainWindow(TypeBlock typeBlock)
        {
            if (typeBlock == TypeBlock.Tasks)
            {
                await SetTaskBlock();
            }
            else if (typeBlock == TypeBlock.Notes)
            {
                await SetNoteBlock();
            }
        }

        public static void SetFlowPanelTask(FlowLayoutPanel flow)
        {
            flowPanelTasks = flow;
        }
        public static void SetFlowPanelNote(FlowLayoutPanel flow)
        {
            flowPanelNotes = flow;
        }

        public static async Task SetTaskBlock()
        {
            Design.heightContentTasks = 0;

            string[] sql_command = new string[6]; 
            string[] date = new string[7];

            sql_command[0] = "SELECT " +
                "task.id_task, task.date, task.time, task.time_finish, direction.name, target.name, task.text, task.descr, task.failed, task.status FROM task " +
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
            }


            if (period == Enums.Period.Today || period == Enums.Period.Tomorrow || period == Enums.Period.Yesterday)
            {
                if (status == Enums.StatusTask.Empty)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        //MessageBox.Show(sql_command[0] + sql_command[i]);
                        ServiceData.commandText = string.Format(sql_command[0] + sql_command[i] + sql_command[4] + sql_command[5] + 
                                                                "AND task.date = '{1}.{2}.{3}' ORDER BY task.time",
                                                                User.user_id,
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
                                Design.heightContentTasks += boxStatus[0].Height;
                            }
                            else if (i == 3)
                            {
                                boxStatus[1] = new PictureBox();
                                boxStatus[1].SizeMode = PictureBoxSizeMode.CenterImage;
                                boxStatus[1].Width = 430;
                                boxStatus[1].Height = 35;
                                boxStatus[1].Image = Properties.Resources.fail_tasks;
                                flowPanelTasks.Controls.Add(boxStatus[1]);
                                Design.heightContentTasks += boxStatus[1].Height;
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
                                    ServiceData.reader.GetValue(7).ToString(),
                                    Convert.ToInt32(ServiceData.reader.GetValue(8)),
                                    Convert.ToInt32(ServiceData.reader.GetValue(9))));
                            }
                        }
                    }
                }
                else if (status == Enums.StatusTask.Done)
                {
                    ServiceData.commandText = string.Format(sql_command[0] + sql_command[2] + sql_command[4] + sql_command[5] + 
                                                            "AND task.date = '{1}.{2}.{3}' ORDER BY task.time",
                                                            User.user_id,
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
                        Design.heightContentTasks += boxStatus[0].Height;

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
                                ServiceData.reader.GetValue(7).ToString(),
                                Convert.ToInt32(ServiceData.reader.GetValue(8)),
                                Convert.ToInt32(ServiceData.reader.GetValue(9))));
                        }
                    }
                }
                else if (status == Enums.StatusTask.Failed)
                {
                    ServiceData.commandText = string.Format(sql_command[0] + sql_command[3] + sql_command[4] + sql_command[5] + 
                                                            "AND task.date = '{1}.{2}.{3}' ORDER BY task.time",
                                                            User.user_id,
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
                        Design.heightContentTasks += boxStatus[0].Height;

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
                                ServiceData.reader.GetValue(7).ToString(),
                                Convert.ToInt32(ServiceData.reader.GetValue(8)),
                                Convert.ToInt32(ServiceData.reader.GetValue(9))));
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
                                                                User.user_id,
                                                                date.First(), date.Last(),
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
                                Design.heightContentTasks += boxStatus[0].Height;
                            }
                            else if (i == 3)
                            {
                                boxStatus[1] = new PictureBox();
                                boxStatus[1].SizeMode = PictureBoxSizeMode.CenterImage;
                                boxStatus[1].Width = 430;
                                boxStatus[1].Height = 35;
                                boxStatus[1].Image = Properties.Resources.fail_tasks;
                                flowPanelTasks.Controls.Add(boxStatus[1]);
                                Design.heightContentTasks += boxStatus[1].Height;
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
                                    ServiceData.reader.GetValue(7).ToString(),
                                    Convert.ToInt32(ServiceData.reader.GetValue(8)),
                                    Convert.ToInt32(ServiceData.reader.GetValue(9))));
                            }
                        }
                    }
                }
                else if (status == Enums.StatusTask.Done)
                {
                    ServiceData.commandText = string.Format(sql_command[0] + sql_command[2] + sql_command[4] + sql_command[5] +
                                                            "AND task.date BETWEEN '{1}.{3}.{4}' AND '{2}.{3}.{4}' ORDER BY task.date",
                                                            User.user_id,
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
                        Design.heightContentTasks += boxStatus[0].Height;

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
                                ServiceData.reader.GetValue(7).ToString(),
                                Convert.ToInt32(ServiceData.reader.GetValue(8)),
                                Convert.ToInt32(ServiceData.reader.GetValue(9))));
                        }
                    }
                }
                else if (status == Enums.StatusTask.Failed)
                {
                    ServiceData.commandText = string.Format(sql_command[0] + sql_command[3] + sql_command[4] + sql_command[5] +
                                                            "AND task.date BETWEEN '{1}.{3}.{4}' AND '{2}.{3}.{4}' ORDER BY task.date",
                                                            User.user_id,
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
                        Design.heightContentTasks += boxStatus[0].Height;

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
                                ServiceData.reader.GetValue(7).ToString(),
                                Convert.ToInt32(ServiceData.reader.GetValue(8)),
                                Convert.ToInt32(ServiceData.reader.GetValue(9))));
                        }
                    }
                }
            }
        }

        public static async Task SetNoteBlock()
        {
            Design.heightContentNotes = 0;

            ServiceData.commandText = @"SELECT id_note, text FROM note WHERE id_user = @user_id";
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
            ServiceData.command.Parameters.AddWithValue("@user_id", User.user_id);

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
    }
}
