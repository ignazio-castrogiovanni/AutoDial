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
            // client.Host = "smtp.gmail.com";
            // client.Port = 587;
            string host = "smtp.gmail.com"; //ConfigurationManager.AppSettings["SMTPHost"];
            int nPort = 587; //ConfigurationManager.AppSettings["SMTPort"];
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
                //foreach (MailAttachment ma in attachments)
                //{
                //    mail.Attachments.Add(ma.File);
                //}
                SmtpClient smtp = new SmtpClient();
                
                smtp.Host = host;
                //smtp.Port = Int32.Parse(port);
                smtp.Port = nPort;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(credentialUser, credentialPassword);
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

        public static string sendit(string ReceiverMail, string subject, string body, string filename = null)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("akton29@gmail.com");
            msg.To.Add(ReceiverMail);
            msg.Subject = "Auto Dial Log - " + subject;
            msg.Body = DateTime.Now.ToString() + '\n' + body;

            if (filename != null)
            {
                Attachment attachment = new Attachment(filename, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = attachment.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(filename);
                disposition.ModificationDate = File.GetLastWriteTime(filename);
                disposition.ReadDate = File.GetLastAccessTime(filename);
                disposition.FileName = Path.GetFileName(filename);
                disposition.Size = new FileInfo(filename).Length;
                disposition.DispositionType = DispositionTypeNames.Attachment;
                msg.Attachments.Add(attachment);
            }

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("autodial.log@gmail.com", "270McNair");
            client.Timeout = 20000;



            try
            {
                client.Send(msg);
                return "Mail has been successfully sent!";
            }
            catch (Exception ex)
            {
                return "Fail Has error" + ex.Message;
            }
            finally
            {
                msg.Dispose();
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
