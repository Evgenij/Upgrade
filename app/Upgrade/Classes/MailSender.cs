using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Upgrade.Classes;

namespace Upgrade.Forms
{
    class MailSender
    {
        public static bool SendMail(string mail_to, string subject, string reg_code)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("evgenij.ermolenko@list.ru", "evg123JEKA007");

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("evgenij.ermolenko@list.ru", "Upgrade");
                mail.To.Add(new MailAddress(mail_to));

                mail.Subject = subject;
                mail.Body = reg_code; // message
                mail.IsBodyHtml = true;

                smtp.Send(mail);
                smtp.Dispose();
                mail.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
