using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text.Json;
using System.IO;
using System.Net;

namespace Project_B_Team_3
{
    class SendEmail
    {
        public static void SendVerifyEmail(string uuid, string mail)
        {
            var emailVerifyBody = System.IO.File.ReadAllText(@"data\htmlBodyVerify.txt");
            var stmpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("NielsProjectFilm@gmail.com", "PDYR%O8An1dp0Rw*"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("butlerdesmond.miles@gmail.com"),
                Subject = "Please verify your email",
                IsBodyHtml = true
            };

            mailMessage.To.Add(mail);
            stmpClient.Send(mailMessage);
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
