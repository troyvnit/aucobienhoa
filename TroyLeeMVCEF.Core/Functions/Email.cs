using System;

namespace TroyLeeMVCEF.Core.Functions
{
    using System.Net.Mail;

    public class Email
    {
        private MailMessage m;
        private string fromAddress;
        private string hostAddress;
        private string username;
        private string password;

        public Email(string fromAddress, string hostAddress, string toAddress, string username, string password, string subject, string body)
        {
            this.fromAddress = fromAddress;
            this.hostAddress = hostAddress;
            this.username = username;
            this.password = password;

            m = new MailMessage();
            this.from = fromAddress;
            this.to = toAddress;
            this.subject = subject;
            this.body = body;
            m.IsBodyHtml = true;
        }

        public bool isHTML
        {
            set
            {
                m.IsBodyHtml = value;
            }
        }

        public string to
        {
            set
            {
                m.To.Add(value);
            }
        }

        public string from
        {
            set
            {
                m.Sender = m.From = new MailAddress(value);
            }
        }
        public string subject
        {
            set
            {
                m.Subject = value;
            }
        }

        public string body
        {
            get
            {
                return body;
            }
            set
            {
                m.Body = value;

            }
        }

        public bool send()
        {
            try
            {
                SmtpClient sc = new SmtpClient();
                sc.Host = hostAddress;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential(username, password);
                sc.EnableSsl = true;
                sc.Send(m);
                return true;
            }
            catch (Exception e)
            {
                //Log error somehow
                return false;
            }
        }
    }
}
