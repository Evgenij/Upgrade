using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Upgrade.Classes;
using Upgrade.Forms;

namespace Upgrade
{
    class DBService
    {
        static public void ConnectToDB(string databaseName)
        {
            if (File.Exists(databaseName))
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

        static public string GetMD5Hash(string text)
        {
            using (var hashAlg = MD5.Create()) // Создаем экземпляр класса реализующего алгоритм MD5
            {
                byte[] hash = hashAlg.ComputeHash(Encoding.UTF8.GetBytes(text)); // Хешируем байты строки text
                var builder = new StringBuilder(hash.Length * 2); // Создаем экземпляр StringBuilder. Этот класс предназначен для эффективного конструирования строк
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("X2")); // Добавляем к строке очередной байт в виде строки в 16-й системе счисления
                }
                return builder.ToString(); // Возвращаем значение хеша
            }
        }

        static public bool Registration(string login,
                                 string password,
                                 string email)
        {
            ServiceData.commandText = @"SELECT * FROM user WHERE login = @login AND password = @password";
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
            ServiceData.command.Parameters.AddWithValue("@login", login);
            ServiceData.command.Parameters.AddWithValue("@password", GetMD5Hash(password));

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (!ServiceData.reader.HasRows)
            {
                // регистрация 
                if (GlobalData.RegistrationCode == null)
                {
                    GlobalData.RegistrationCode = GlobalData.GererateCode();
                }

                if (email != "")
                {
                    if (MailSender.SendMail(email, 
                                            "Подтверждение регистрации", 
                                            "Это ваш регистрационный код, который необходим для " +
                                            "подтверждения вашей электронной почты и восстановления данных аккаунта", 
                                            GlobalData.RegistrationCode))
                    {
                        string[] values = { "NULL", "NULL", login, GetMD5Hash(password), email, GlobalData.RegistrationCode, "0", "0" };
                            ServiceData.DataType[] datas = {
                            ServiceData.DataType.NULL,
                            ServiceData.DataType.NULL,
                            ServiceData.DataType.TEXT,
                            ServiceData.DataType.TEXT,
                            ServiceData.DataType.TEXT,
                            ServiceData.DataType.TEXT,
                            ServiceData.DataType.INTEGER,
                            ServiceData.DataType.INTEGER
                        };

                        InsertDataToTable(ServiceData.Tables.user, values, datas);

                        return true;
                    }
                    else
                    {
                        MessageBox.Show(
                            "Не удалось зарегистрироваться...\n\nПроверьте правильность указанной электронной почты",
                            "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
                else 
                {
                    string[] values = { "NULL", "NULL", login, GetMD5Hash(password), "отсутствует", GlobalData.RegistrationCode, "0", "0" };
                    ServiceData.DataType[] datas = {
                            ServiceData.DataType.NULL,
                            ServiceData.DataType.NULL,
                            ServiceData.DataType.TEXT,
                            ServiceData.DataType.TEXT,
                            ServiceData.DataType.TEXT,
                            ServiceData.DataType.TEXT,
                            ServiceData.DataType.INTEGER,
                            ServiceData.DataType.INTEGER
                        };

                    InsertDataToTable(ServiceData.Tables.user, values, datas);

                    return true;
                }
            }
            else
            {
                // Данные уже есть 
                return false;
            }
        }

        static public bool Authorization(string login,
                                 string password) 
        {
            ServiceData.commandText = @"SELECT * FROM user WHERE login = @login AND password = @password";
            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
            ServiceData.command.Parameters.AddWithValue("@login", login);
            ServiceData.command.Parameters.AddWithValue("@password", GetMD5Hash(password));

            ServiceData.reader = ServiceData.command.ExecuteReader();
            if (ServiceData.reader.HasRows)
            {
                ServiceData.reader.ReadAsync();
                User.userId = ServiceData.reader.GetInt32(ServiceData.reader.GetOrdinal("id_user"));
                User.userLogin = ServiceData.reader.GetString(ServiceData.reader.GetOrdinal("login"));
                User.userPassword = ServiceData.reader.GetString(ServiceData.reader.GetOrdinal("password"));
                User.userEmail = ServiceData.reader.GetString(ServiceData.reader.GetOrdinal("email"));
                User.SetPhoto(ServiceData.reader.GetValue(ServiceData.reader.GetOrdinal("photo")).ToString());
                User.userPerform = ServiceData.reader.GetInt32(ServiceData.reader.GetOrdinal("perform"));
                GlobalData.mainWorkingForm.Show();
                return true;
            }
            else 
            {
                MessageBox.Show(
                    "Не удалось авторизоваться...\n\nПроверьте правильность введенных данных или восстановите пароль.",
                    "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static private void InsertDataToTable(ServiceData.Tables table, 
                                              string[] values, 
                                              ServiceData.DataType[] dataType) 
        {
            ServiceData.commandText = @"INSERT INTO ["+ table +"] VALUES (";

            // формирование строки запроса с параметрами вместо значений
            for (int i = 0; i < values.Length; i++) 
            {
                if (i == values.Length - 1)
                {
                    ServiceData.commandText += "@value" + (i + 1).ToString();
                }
                else
                {
                    ServiceData.commandText += "@value" + (i + 1).ToString() + ", ";
                }
            }
            ServiceData.commandText += ")";

            ServiceData.command = new SQLiteCommand(ServiceData.commandText, ServiceData.connect);
            //MessageBox.Show(ServiceData.command.CommandText);

            // присваивание параметрам конкретных значений в зависимости от их типа данных
            for (int i = 0; i < dataType.Length; i++)
            {
                //MessageBox.Show("@value" + (i + 1).ToString() + ":" + values[i]);

                if (dataType[i] == ServiceData.DataType.NULL)
                {
                    ServiceData.command.Parameters.AddWithValue("@value" + (i + 1).ToString(), Convert.DBNull);
                }
                else if (dataType[i] == ServiceData.DataType.INTEGER)
                {
                    ServiceData.command.Parameters.AddWithValue("@value" + (i + 1).ToString(), Convert.ToInt32(values[i]));
                }
                else
                {
                    ServiceData.command.Parameters.AddWithValue("@value" + (i + 1).ToString(), values[i]);
                }
            }

            ServiceData.command.ExecuteNonQuery();
        }
        
    }
}
