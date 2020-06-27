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
        public static bool SendMail(string mail_to, string subject, string subtitle, string text_message)
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
                mail.Body = "<div style=\"" +
                                    "width:85%; " +
                                    "height:350px; " +
                                    "margin:30px; " +
                                    "background-color: #F8FCFF;" +
                                    "border:1px solid #E8E8E8; " +
                                    "border-radius: 30px; " +
                                    "box-shadow: 0px 25px 30px #E5E5E5;" +
                                    "padding-top: 45px;" +
                                    "padding-left: 60px;\">" +
                                "<div style = \"" +
                                    "font-size:40px; " +
                                    "font-weight:600;" +
                                    "padding-bottom:40px;\">" +
                                    "Upgrade" +
                                "</div>" +
                                "<div style = \"font-size:18px; font-weight:600;\">" +
                                    subject +
                                "</div>" +
                                "<div style = \"font-size:14px; font-weight:100; padding-top:15px;\">" +
                                    subtitle +
                                "</div>" +
                                "<div style = \"" +
                                    "display: inline-block;" +
                                    "font-size:35px; " +
                                    "font-weight:600; " +
                                    "margin-top:40px; " +
                                    "margin-bottom:40px;" +
                                    "padding:10px; " +
                                    "padding-left: 35px;" +
                                    "padding-right: 35px;" +
                                    "border: 1px solid #E8E8E8; " +
                                    "border-radius: 20px; " +
                                    "text-align: center;\">" +
                                     text_message +
                                "</div>" +
                                "<div style=\"" +
                                    "width:100%; " +
                                    "text-align: left;" +
                                    "color: gray;\"> " +
                                "*отвечать на данное сообщение не нужно*" +
                                "</div>" +
                            "</div>" +
                            "<div style=\"" +
                                    "margin-left: 30px; " +
                                    "margin-right: 30px; " +
                                    "width:85%; " +
                                    "text-align: center;" +
                                    "color: #BDBDBD;\"> " +
                                "developed by Evgenij Ermolenko" +
                            "</div>"; // message
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
