using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrade
{
    class ServiceData
    {
        static public SQLiteConnection connect;
        static public SQLiteCommand command;
        static public SQLiteDataReader reader;

        static public string commandText;

        public enum Tables 
        { 
            user,
            user_dir,
            task,
            target,
            subtask,
            schedule,
            password,
            note, 
            direction
        }

        public enum DataType
        {
            NULL,
            INTEGER,
            TEXT,
            BLOB
        }
    }
}
