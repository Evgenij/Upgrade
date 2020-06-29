﻿using OpenTK;
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
        public enum TypeFont 
        {
            ExtraThin,
            Light,
            Standart,
            Medium
        }

        static public Font GetFont(TypeFont typeFont, int size) 
        {
            string font;
            if (typeFont == TypeFont.ExtraThin)
            {
                font = "PF DinDisplay Pro ExtraThin";
            }
            else if (typeFont == TypeFont.Light) 
            {
                font = "PF DinDisplay Pro Light";
            }
            else if (typeFont == TypeFont.Standart)
            {
                font = "PF DinDisplay Pro";
            }
            else
            {
                font = "PF DinDisplay Pro Medium";
            }

            return new Font(font, size);
        }

        static public MainWorkingForm mainWorkingForm = new MainWorkingForm();
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
            int[] array = { color.R, color.G, color.B};
            array = array.Where(val => val + 100 == array.Max()).ToArray();
            int second_max = array.Max();

            MessageBox.Show(System.Drawing.Color.FromArgb(r, g, b).ToString());

            return System.Drawing.Color.FromArgb(r,g,b);
        }
    }
}
