using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Upgrade.Classes
{
    class GlobalData
    {
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
    }
}
