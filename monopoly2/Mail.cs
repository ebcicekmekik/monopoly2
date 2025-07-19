using System;
using System.Net;
using System.Net.Mail;

namespace monopoly2
{
    public class Mail
    {
        private readonly string smtpServer = "smtp.gmail.com";
        private readonly int smtpPort = 587;
        private readonly string senderEmail = "ebcaks@gmail.com";
        private readonly string senderPassword = "ijhd xhss cxuu wmde";

        public void Send(string to, string subject, string body)
        {
            using (var smtp = new SmtpClient(smtpServer, smtpPort))
            {
                smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtp.EnableSsl = true;
                var mail = new MailMessage(senderEmail, to, subject, body);
                smtp.Send(mail);
            }
        }
    }
} 