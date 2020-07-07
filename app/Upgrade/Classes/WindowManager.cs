using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Upgrade.Classes
{
    class WindowManager
    {
        private static List<TaskBlock> taskBlock = new List<TaskBlock>();
        private static PictureBox[] boxStatus = new PictureBox[2];

        public enum TypeBlock 
        {
            Tasks
        }

        public static void CreateMainWindow(FlowLayoutPanel flowTasks, TypeBlock typeBlock) 
        {
            if (typeBlock == TypeBlock.Tasks)
            {
                SetTaskBlock(flowTasks);
            }
        }

        public static void SetTaskBlock(FlowLayoutPanel flowTasks) 
        {
            // вывод невыполненных задач
            {
                ServiceData.commandText = @"SELECT 
                task.id_task, task.date, task.time, task.time_finish, direction.name, target.name, task.text, task.descr, task.failed, task.status FROM task 
                INNER JOIN target ON task.id_target = target.id_target 
                INNER JOIN direction ON target.id_direct = direction.id_direct 
                INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct
                INNER JOIN user ON user_dir.id_user = user.id_user 
                WHERE user.id_user = 1 AND task.status = 0 AND task.failed = 0
                ORDER BY task.time";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        taskBlock.Add(new TaskBlock(
                            flowTasks,
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
                boxStatus[0] = new PictureBox();
                boxStatus[0].SizeMode = PictureBoxSizeMode.CenterImage;
                boxStatus[0].Width = 430;
                boxStatus[0].Height = 35;
                boxStatus[0].Image = Properties.Resources.done_tasks;
                flowTasks.Controls.Add(boxStatus[0]);

                ServiceData.commandText = @"SELECT 
                task.id_task, task.date, task.time,task.time_finish, direction.name, target.name, task.text, task.descr, task.failed, task.status FROM task 
                INNER JOIN target ON task.id_target = target.id_target 
                INNER JOIN direction ON target.id_direct = direction.id_direct 
                INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct
                INNER JOIN user ON user_dir.id_user = user.id_user 
                WHERE user.id_user = 1 AND task.status = 1 AND task.failed = 0
                ORDER BY task.time";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        taskBlock.Add(new TaskBlock(
                            flowTasks,
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
                boxStatus[1] = new PictureBox();
                boxStatus[1].SizeMode = PictureBoxSizeMode.CenterImage;
                boxStatus[1].Width = 430;
                boxStatus[1].Height = 35;
                boxStatus[1].Image = Properties.Resources.fail_tasks;
                flowTasks.Controls.Add(boxStatus[1]);

                ServiceData.commandText = @"SELECT 
                task.id_task, task.date, task.time, task.time_finish, direction.name, target.name, task.text, task.descr, task.failed, task.status FROM task 
                INNER JOIN target ON task.id_target = target.id_target 
                INNER JOIN direction ON target.id_direct = direction.id_direct 
                INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct
                INNER JOIN user ON user_dir.id_user = user.id_user 
                WHERE user.id_user = 1 AND task.failed = 1
                ORDER BY task.time";
                ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

                ServiceData.reader = ServiceData.command.ExecuteReader();
                if (ServiceData.reader.HasRows)
                {
                    while (ServiceData.reader.Read())
                    {
                        taskBlock.Add(new TaskBlock(
                            flowTasks,
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
}
