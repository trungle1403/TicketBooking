using QLNX.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace QLNX.Concrete
{
    public class EmailHelper : IEmailHelper
    {
        public object MessageBox { get; private set; }

        public void Send(string email, string subject, string body, List<string> cc)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("trungleit99@gmail.com");

                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                if(cc!=null && cc.Count() > 0)
                {
                    foreach(var c in cc)
                    {
                        mail.CC.Add(c);
                    }
                }

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("trungleit99@gmail.com", "tdkxcbntxymmckkm");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}