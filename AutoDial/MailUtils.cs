using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using NLog;

namespace AutoDial.MailUtils
{
    public class MailUtils {
        public static void Email(string to,
                            string body,
                            string subject,
                            string fromAddress,
                            string fromDisplay,
                            string credentialUser,
                            string credentialPassword,
                            params MailAttachment[] attachments)
        {
            string host = ConfigurationManager.AppSettings["SMTPHost"];
            string port = ConfigurationManager.AppSettings["SMTPort"];
            try
            {
                MailMessage mail = new MailMessage();
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(to));
                mail.From = new MailAddress(fromAddress, fromDisplay, Encoding.UTF8);
                mail.Subject = subject;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.Normal;
                foreach (MailAttachment ma in attachments)
                {
                    mail.Attachments.Add(ma.File);
                }
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential(credentialUser, credentialPassword);
                smtp.Host = host;
                smtp.Port = Int32.Parse(port);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder(1024);
                sb.Append("\nTo:" + to);
                sb.Append("\nbody:" + body);
                sb.Append("\nsubject:" + subject);
                sb.Append("\nfromAddress:" + fromAddress);
                sb.Append("\nfromDisplay:" + fromDisplay);
                sb.Append("\ncredentialUser:" + credentialUser);
                sb.Append("\ncredentialPasswordto:" + credentialPassword);
                sb.Append("\nHosting:" + host);

                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error("Exception: " + ex.ToString() + " mail: " + sb.ToString());
            }
        }
    
    }
   

    public class MailAttachment
    {
        private MemoryStream stream;
        private string filename;
        private string mediaType;

      
    public Stream Data { get { return stream; } }
   
    public string Filename { get { return filename; } }
    
    public string MediaType { get { return mediaType; } }
    
    public Attachment File{ get {return new Attachment(Data, Filename, MediaType); } }

   
   
    public MailAttachment(byte[] data, string filename)
        {
        this.stream = new MemoryStream(data);
        this.filename = filename;
        this.mediaType = MediaTypeNames.Application.Octet;
        }
   
    public MailAttachment(string data, string filename)
        {
        this.stream = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(data));
        this.filename = filename;
        this.mediaType = MediaTypeNames.Text.Html;
        }


    }
}
