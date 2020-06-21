using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade
{
    class DBService
    {
        static public void ConnectToDB(string databaseName)
        {
            if (File.Exists(databaseName)/*File.Exists(@"database\db_upgrade.db")*/)
            {
                ServiceData.connect = new SQLiteConnection(@"Data Source="+ databaseName + "; Version=3;");
                ServiceData.connect.Open(); // открытие соединения
            }
            else 
            {
                if (MessageBox.Show(
                    "Не удалось подключиться к базе данных.\nФайл базы данных отсутствует.\nДля подключения будет создан новый файл базы данных.",
                    "Ошибка подключения к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) 
                {
                    //File.Create(@"database\db_upgrade.db");
                    CreateDB(databaseName);
                }
            }
        }

        static public void CloseConnectionWithDB() 
        {
            ServiceData.connect.Close(); // закрытие соединения
        }

        static private void CreateDB(string databaseName)
        {
            SQLiteConnection.CreateFile(databaseName);
            ConnectToDB(databaseName);

            ServiceData.commandText = File.ReadAllText(@"database\create_db.sql");

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
            ServiceData.command.ExecuteNonQuery();
        }

        static public void ReadRecords()
        {
            // строка запроса, который надо будет выполнить

            ServiceData.commandText = "SELECT * FROM user";
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);

            ServiceData.reader = ServiceData.command.ExecuteReader();
            while (ServiceData.reader.Read()) // считываем и вносим в лист все параметры
            {
                MessageBox.Show(ServiceData.reader.GetString(2));
            }

        }
    }
}
