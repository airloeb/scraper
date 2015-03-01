using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
//using EASendMail;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace Scraper.Data
{
    public class Email
    {
        public static void Send(string title, string newPrice, string oldPrice, string url)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("airloeb@gmail.com");
            mail.To.Add("airloeb@aol.com");
            mail.Subject = "Test Mail";
            mail.Body = String.Format("Hi Chaviva, the {0} went down in price to ${1} from ${2}. You can see this product at {3}",title,newPrice,oldPrice,url);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("airloeb@gmail.com", "yisroel0");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}
