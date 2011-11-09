using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Web.Mail;
using MailMessage = System.Net.Mail.MailMessage;

namespace Agathas.Storefront.Infrastructure.Email
{
    public class SMTPService : IEmailService
    {        
        public void SendMail(string from, string to, string subject, string body)
        {                        
            MailMessage message = new MailMessage();
            
            message.From = new MailAddress(from);
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.Body = body;
                        
            SmtpClient smtp = new SmtpClient();            

            smtp.Send(message);
        }     
    }
}
