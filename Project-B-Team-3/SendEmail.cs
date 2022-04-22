using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text.Json;
using System.IO;
using System.Net;

namespace ProjectB
{
    class SendEmail
    {
        public static void SendVerifyEmail(string mail)
        {            
            var emailVerifyBody = System.IO.File.ReadAllText(@"Data\htmlBodyRegister.txt");
            var stmpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("NielsProjectFilm@gmail.com", "PDYR%O8An1dp0Rw*"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("NielsProjectFilm@gmail.com"),
                Subject = "Verify account!",
                Body = emailVerifyBody,
                IsBodyHtml = true
            };

            mailMessage.To.Add(mail);
            stmpClient.Send(mailMessage);
        }
    }
}