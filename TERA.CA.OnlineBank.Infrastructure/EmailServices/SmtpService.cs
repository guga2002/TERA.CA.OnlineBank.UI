using System.Net.Mail;
using System.Net;
using TERA.CA.OnlineBank.Infrastructure.Interface;

namespace TERA.CA.OnlineBank.Infrastructure.EmailServices
{
    public class SmtpService:Ismtp
    {
        private readonly string senderEmail;

        private readonly string senderPassword;

        public SmtpService()
        {
            senderPassword = "jdsq pnab vemt bxjl";
            senderEmail = "hitheretera@gmail.com";
        }

        public void SendMesaage(string to,string subject, string body)
        {

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true,
            };
            var message = new MailMessage(new MailAddress(senderEmail), new MailAddress(to))
            {
                Subject = subject,
                Body = body,
                Priority = MailPriority.High
            };
            smtpClient.Send(message);
        }

    }
}
