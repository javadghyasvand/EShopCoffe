using System;
using System.Net.Mail;

namespace MyShop
{
    public class SendEmail
    {
        public static void Send(string To,string Subject,string Body)
        {
            // var msg = new MailMessage();
            //     msg.To.Add(To);
            //     msg.Subject=Subject;
            //     msg.Body=Body;
            //     var smtp = new SmtpClient();
            //     smtp.EnableSsl = true;
            //     smtp.Send(msg);


            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("javadghyasvand68@gmail.com", "فروشگاه");
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            
            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);
            
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("javadghyasvand68@gmail.com", "esvukurwnwfpbojo");
            SmtpServer.EnableSsl = true;
            
            SmtpServer.Send(mail);

        }
    }
}