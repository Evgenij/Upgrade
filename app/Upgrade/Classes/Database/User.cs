using System;
using System.Collections.Generic;
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
    }
}
