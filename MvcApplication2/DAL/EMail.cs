using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net.Mail;

namespace MvcApplication2.DAL
{
    public class EMail
    {

        private string FromAddress;
        private string strToAddress;
        private string strSmtpClient;
        private string UserID;
        private string Password;
        private string ReplyTo;
        private string SMTPPort;
        private Boolean bEnableSSL;

        private void InitMail()
        {
            FromAddress = System.Configuration.ConfigurationManager.AppSettings.Get("FromAddress");
            strToAddress = System.Configuration.ConfigurationManager.AppSettings.Get("ToAddress");
            //strSmtpClient = System.Configuration.ConfigurationManager.AppSettings.Get("SmtpClient");
            strSmtpClient = "smtp.gmail.com";
            UserID = System.Configuration.ConfigurationManager.AppSettings.Get("UserID");
            Password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
            ReplyTo = System.Configuration.ConfigurationManager.AppSettings.Get("ReplyTo");
            SMTPPort = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPPort");
            if (System.Configuration.ConfigurationManager.AppSettings.Get("EnableSSL").ToUpper() == "YES")
            {
                bEnableSSL = true;
            }
            else
            {
                bEnableSSL = false;
            }
        }

        public void SendMail(string messageId, string toAddress, string[] param)
        {
            XmlDocument xdoc = new XmlDocument();
            string mailFormatxml = HttpContext.Current.Server.MapPath("\\") + "Mailformat.xml";
            string subject = "";
            string body = "";
            XmlNode mailNode = default(XmlNode);
            int n = 0;

            if ((System.IO.File.Exists(mailFormatxml)))
            {
                xdoc.Load(mailFormatxml);
                mailNode = xdoc.SelectSingleNode("MailFormats/MailFormat[@Id='" + messageId + "']");
                subject = mailNode.SelectSingleNode("Subject").InnerText;
                body = mailNode.SelectSingleNode("Body").InnerText;
                if ((param == null))
                {
                    throw new Exception("Mail format file not found.");
                }
                else
                {
                    for (n = 0; n <= param.Length - 1; n++)
                    {
                        body = body.Replace(n.ToString() + "?", param[n]);
                        subject = subject.Replace(n.ToString() + "?", param[n]);
                    }
                }

                InitMail();
             
                dynamic MailMessage = new MailMessage();
                MailMessage.From = new MailAddress(FromAddress);
                if (!String.IsNullOrEmpty(toAddress))
                {
                    MailMessage.To.Add(toAddress);
                }
                else
                {
                    MailMessage.To.Add(strToAddress);
                }

               
                MailMessage.Subject = subject;
                MailMessage.IsBodyHtml = true;
                MailMessage.Body = body;
             
                MailMessage.ReplyTo = new MailAddress(FromAddress);

                SmtpClient SmtpClient = new SmtpClient();
                SmtpClient.Host = strSmtpClient;
                SmtpClient.EnableSsl = bEnableSSL;
                SmtpClient.Port = Convert.ToInt32(SMTPPort);
                SmtpClient.Credentials = new System.Net.NetworkCredential(UserID, Password);
                try
                {
                    SmtpClient.Send(MailMessage);
                }
                catch (SmtpFailedRecipientsException ex)
                {
                    for (int i = 0; i <= ex.InnerExceptions.Length; i++)
                    {
                        SmtpStatusCode status = ex.InnerExceptions[i].StatusCode;
                        if ((status == SmtpStatusCode.MailboxBusy) | (status == SmtpStatusCode.MailboxUnavailable))
                        {
                            System.Threading.Thread.Sleep(5000);
                            SmtpClient.Send(MailMessage);
                        }
                    }
                }
            }
        }
    }
}