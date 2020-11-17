using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Forms
{
    class User
    {
        public static int userId;
        public static string userLogin;
        public static string userPassword;
        public static string userEmail;
        public static int userPerform;
        public static string pathPhoto;

        public static void SetPhoto(string path) 
        {
            if (path == "")
            {
                pathPhoto = AppDomain.CurrentDomain.BaseDirectory + @"user_photo\default_user_photo.png";
            }
            else 
            {
                pathPhoto = path;
            }
        }

        public static string CalculatePerform() 
        {
            int countDoneTask = 0, countTask = 0;

            ServiceData.commandText = string.Format("SELECT count(task.id_task) FROM task " +
                "INNER JOIN target ON task.id_target = target.id_target " +
                "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                "INNER JOIN user ON user_dir.id_user = user.id_user " +
                "WHERE user.id_user = {0}", userId);

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                ServiceData.reader.Read();
                countTask = ServiceData.reader.GetInt32(0);
            }

            ServiceData.commandText = string.Format("SELECT count(task.id_task) FROM task " +
                "INNER JOIN target ON task.id_target = target.id_target " +
                "INNER JOIN direction ON target.id_direct = direction.id_direct " +
                "INNER JOIN user_dir ON direction.id_direct = user_dir.id_direct " +
                "INNER JOIN user ON user_dir.id_user = user.id_user " +
                "WHERE user.id_user = {0} AND task.status = 1", userId);

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                ServiceData.reader.Read();
                countDoneTask = ServiceData.reader.GetInt32(0);
            }

            if (countTask != 0)
            {
                return ((countDoneTask * 100) / countTask).ToString() + "%";
            }
            else 
            {
                return "0%";
            }
        }
    }
}
