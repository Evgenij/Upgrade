using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Upgrade.Classes.Blocks;
using Upgrade.Forms;

namespace Upgrade.Classes
{
    class GlobalData
    {
        static public string RegistrationCode;
        static public int id_target;

        // forms
        static public MainWorkingForm mainWorkingForm = new MainWorkingForm();
        static public Reg_AuthForm reg_authForm = new Reg_AuthForm();
        static public AddNoteForm addNoteForm;
        static public AddDirectionForm addDirectionForm;
        static public AddTargetForm addTargetForm;
        static public AddTaskForm addTaskForm;
        static public AddDataService addDataService;

        public struct DataContainer
        {
            int id_target;
            string name;

            public DataContainer(int id, string name)
            {
                this.id_target = id;
                this.name = name;
            }

            public int GetId()
            {
                return id_target;
            }

            public string GetName()
            {
                return name;
            }
        }

        public struct DayOfWeek
        {
            bool status;
            int id_day;

            public void ChangeStatus(PictureBox picture, Enums.DayOfWeek day)
            {
                if (status == false)
                {
                    status = true;
                    if (day == Enums.DayOfWeek.Понедельник)
                    {
                        picture.Image = Properties.Resources.box_monday_on;
                        id_day = 1;
                    }
                    else if (day == Enums.DayOfWeek.Вторник) 
                    {
                        picture.Image = Properties.Resources.box_tuesday_on;
                        id_day = 2;
                    }
                    else if (day == Enums.DayOfWeek.Среда)
                    {
                        picture.Image = Properties.Resources.box_wednesday_on;
                        id_day = 3;
                    }
                    else if (day == Enums.DayOfWeek.Четверг)
                    {
                        picture.Image = Properties.Resources.box_thursday_on;
                        id_day = 4;
                    }
                    else if (day == Enums.DayOfWeek.Пятница)
                    {
                        picture.Image = Properties.Resources.box_friday_on;
                        id_day = 5;
                    }
                    else if (day == Enums.DayOfWeek.Суббота)
                    {
                        picture.Image = Properties.Resources.box_saturday_on;
                        id_day = 6;
                    }
                    else if (day == Enums.DayOfWeek.Воскресенье)
                    {
                        picture.Image = Properties.Resources.box_sunday_on;
                        id_day = 7;
                    }
                }
                else
                {
                    status = false;
                    id_day = 0;

                    if (day == Enums.DayOfWeek.Понедельник)
                    {
                        picture.Image = Properties.Resources.box_monday_off;
                    }
                    else if (day == Enums.DayOfWeek.Вторник)
                    {
                        picture.Image = Properties.Resources.box_tuesday_off;
                    }
                    else if (day == Enums.DayOfWeek.Среда)
                    {
                        picture.Image = Properties.Resources.box_wednesday_off;
                    }
                    else if (day == Enums.DayOfWeek.Четверг)
                    {
                        picture.Image = Properties.Resources.box_thursday_off;
                    }
                    else if (day == Enums.DayOfWeek.Пятница)
                    {
                        picture.Image = Properties.Resources.box_friday_off;
                    }
                    else if (day == Enums.DayOfWeek.Суббота)
                    {
                        picture.Image = Properties.Resources.box_saturday_off;
                    }
                    else if (day == Enums.DayOfWeek.Воскресенье)
                    {
                        picture.Image = Properties.Resources.box_sunday_off;
                    }
                }
            }

            public bool GetStatus() 
            {
                return status;
            }

            public void SetIdDay(int id)
            {
                id_day = id;
            }

            public int GetIdDay() 
            {
                return id_day;
            }
        }

        static public Font GetFont(Enums.TypeFont typeFont, int size) 
        {
            Font font;

            if (typeFont == Enums.TypeFont.Regular)
            {
                font = new Font("Calibri", size, FontStyle.Regular, GraphicsUnit.Pixel);
            }
            else
            {
                font = new Font("Calibri", size, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            return font;
        }

        static public string GererateCode() 
        {
            Random random = new Random();
            string code = random.Next(0, 10).ToString() +
                          random.Next(0, 10).ToString() +
                          random.Next(0, 10).ToString() +
                          random.Next(0, 10).ToString();
            return code;
        }

        //static public System.Drawing.Color LightenColor(System.Drawing.Color color) 
        //{
        //    int[] array = { color.R, color.G, color.B };

        //    var valueMax = array.Where(val => val == array.Max()).ToArray();
        //    var valueAverage = array.Where(val => val < array.Max() && val > array.Min()).ToArray();

        //    for (int i = 0; i < array.Length; i++) 
        //    {
        //        if (array[i] == valueMax[0])
        //        {
        //            array[i] = valueMax[0] + 100;
        //        }
        //        else if (array[i] == valueAverage[0]) 
        //        {
        //            array[i] = valueAverage[0] + 70;
        //        }
        //    }

        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (array[i] > 255)
        //        {
        //            array[i] = 255;
        //        }
        //    }

        //    return System.Drawing.Color.FromArgb(array[0], array[1], array[2]);
        //}
    }
}
