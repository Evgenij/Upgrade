using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Forms
{
    class User
    {
        public static int user_id;
        public static string user_login;
        public static int user_achieves;
        public static int user_perform;
        public static PictureBox user_photo;

        public static void SetPhoto(string valuePhoto) 
        {
            user_photo = new PictureBox();
            if (valuePhoto == "")
            {
                user_photo.Image = Properties.Resources.default_user_photo;
            }
            else 
            {
                //user_photo.Image = ;
            }
        }
    }
}
