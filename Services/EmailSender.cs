using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NotDefterim.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string gonderici = "info@elifgizemuzgur.com";

            MailMessage mail = new MailMessage(gonderici, email, subject, htmlMessage);
            mail.IsBodyHtml = true;

            using (SmtpClient smtp = new SmtpClient("mail.elifgizemuzgur.com", 587))
            {
                smtp.Credentials = new NetworkCredential("info@elifgizemuzgur.com", "");
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
