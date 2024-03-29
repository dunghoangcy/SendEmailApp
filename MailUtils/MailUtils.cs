using System.Net;
using System.Net.Mail;

namespace SendEmailApp.MailUtils
{
    public class MailUtils
    {
        public static async Task<string> SendEmail(string _from , string _to , string _subject , string _body){
            MailMessage message = new MailMessage(_from, _to , _subject, _body);
            message.BodyEncoding =System.Text.Encoding.UTF8;
            message.SubjectEncoding =System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);
            using var smtp = new SmtpClient("localhost");
            try{
                await smtp.SendMailAsync(message);
                return "success";
            }catch(Exception e){
                System.Console.WriteLine(e.Message);
                return "failed";

            }
        }
        public static async Task<string> SendMailGG(string _from , string _to , string _subject , string _body,string _gmail , string _password){
            MailMessage message = new MailMessage(_from, _to , _subject, _body);
            message.BodyEncoding =System.Text.Encoding.UTF8;
            message.SubjectEncoding =System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);
            using var smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(_gmail , "vmzpqpatblmzdyme");
            try{
                await smtp.SendMailAsync(message);
                return "success";
            }catch(Exception e){
                System.Console.WriteLine(e.Message);
                return "failed";

            }
        }
        
    }
}