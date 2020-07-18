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
            string[] date = new string[7];

            if (period == Enums.Period.LastWeek)
            {
                date = WeeklyStatistic.GetDaysLastWeek();
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

            if (status == Enums.StatusTask.Empty)
            {
                if (period == Enums.Period.Today || period == Enums.Period.Tomorrow || period == Enums.Period.Yesterday)
                {
                    // вывод невыполненных задач
                    {
                        ServiceData.commandText = string.Format("SELECT " +
                            "task.id_task, task.date, task.time, task.time_finish, direction.name, target.name, task.text, task.descr, task.failed, task.status FROM task " +
                            "INNER JOIN target ON task.id_target = target.id_target " +
                            "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                            "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                            "INNER JOIN user ON user_dir.id_user = user.id_user " +
                            "WHERE user.id_user = {0} AND task.status = 0 AND task.failed = 0 AND task.date = '{1}.{2}.{3}' " +
                            "ORDER BY task.time", User.user_id, date.First(), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"));
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                        ServiceData.reader = ServiceData.command.ExecuteReader();
                        if (ServiceData.reader.HasRows)
                        {
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

                    // вывод выполненных задач
                    {
                        ServiceData.commandText = string.Format("SELECT " +
                            "task.id_task, task.date, task.time,task.time_finish, direction.name, target.name, task.text, task.descr, task.failed, task.status FROM task " +
                            "INNER JOIN target ON task.id_target = target.id_target " +
                            "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                            "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                            "INNER JOIN user ON user_dir.id_user = user.id_user " +
                            "WHERE user.id_user = {0} AND task.status = 1 AND task.failed = 0 AND task.date = '{1}.{2}.{3}' " +
                            "ORDER BY task.time", User.user_id, date.First(), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"));
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

                    // вывод проваленных задач
                    {
                        ServiceData.commandText = string.Format("SELECT " +
                            "task.id_task, task.date, task.time, task.time_finish, direction.name, target.name, task.text, task.descr, task.failed, task.status FROM task " +
                            "INNER JOIN target ON task.id_target = target.id_target " +
                            "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                            "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                            "INNER JOIN user ON user_dir.id_user = user.id_user " +
                            "WHERE user.id_user = {0} AND task.failed = 1  AND task.date = '{1}.{2}.{3}' " +
                            "ORDER BY task.time", User.user_id, date.First(), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"));
                        ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                        ServiceData.reader = ServiceData.command.ExecuteReader();
                        if (ServiceData.reader.HasRows)
                        {
                            boxStatus[1] = new PictureBox();
                            boxStatus[1].SizeMode = PictureBoxSizeMode.CenterImage;
                            boxStatus[1].Width = 430;
                            boxStatus[1].Height = 35;
                            boxStatus[1].Image = Properties.Resources.fail_tasks;
                            flowPanelTasks.Controls.Add(boxStatus[1]);
                            Design.heightContentTasks += boxStatus[1].Height;

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
                    // для недель
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
