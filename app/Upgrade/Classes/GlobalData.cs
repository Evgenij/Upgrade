using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Classes
{
    class GlobalData
    {
        static public MainWorkingForm mainWorkingForm = new MainWorkingForm();
        static public Reg_AuthForm reg_authForm = new Reg_AuthForm();

        static public Font GetFont(Enums.TypeFont typeFont, int size) 
        {
            string font;
            if (typeFont == Enums.TypeFont.ExtraThin)
            {
                font = "PF DinDisplay Pro ExtraThin";
            }
            else if (typeFont == Enums.TypeFont.Light) 
            {
                font = "PF DinDisplay Pro Light";
            }
            else if (typeFont == Enums.TypeFont.Standart)
            {
                font = "PF DinDisplay Pro";
            }
            else
            {
                font = "PF DinDisplay Pro Medium";
            }

            return new Font(font, size);
        }

        
        static public string RegistrationCode;

        static public string GererateCode() 
        {
            Random random = new Random();
            string code = random.Next(0, 10).ToString() +
                          random.Next(0, 10).ToString() +
                          random.Next(0, 10).ToString() +
                          random.Next(0, 10).ToString();
            return code;
        }

        static public System.Drawing.Color LightenColor(System.Drawing.Color color) 
        {
            int[] array = { color.R, color.G, color.B };

            var valueMax = array.Where(val => val == array.Max()).ToArray();
            var valueAverage = array.Where(val => val < array.Max() && val > array.Min()).ToArray();

            for (int i = 0; i < array.Length; i++) 
            {
                if (array[i] == valueMax[0])
                {
                    array[i] = valueMax[0] + 100;
                }
                else if (array[i] == valueAverage[0]) 
                {
                    array[i] = valueAverage[0] + 70;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 255)
                {
                    array[i] = 255;
                }
            }

            return System.Drawing.Color.FromArgb(array[0], array[1], array[2]);
        }
    }
}
