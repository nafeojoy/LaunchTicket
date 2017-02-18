using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.DAL
{
    public class Mailer
    {
        private LaunchDBContext db = new LaunchDBContext();
        public static bool SendEmail(string toAddress, string emailSubject, string emailBody)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(toAddress);
                mail.Subject = emailSubject;
                mail.IsBodyHtml = true;
                mail.Body = emailBody;
                mail.From = new MailAddress("nafeo.joy@gmail.com");
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("nafeo.joy", "gu1T@RDD");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }


}