using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utility;
using DataAccessLayer;
using System.Net.Mail;
using System.IO;
namespace BusinessAccessLayer.Common
{
    public class MailHelperManager
    {
        DataAccess dataAccess = new DataAccess();
        public DataSet InsertUpdateMailStatus(MailHelper objMail)
        {
            Object[] parametes = new Object[17] 
                                    { 
                                    
                                        objMail.id  ,                                  
                                        objMail.mailTo ,
                                        objMail.mailFrom ,
                                        objMail.mailCc ,
                                        objMail.mailSubject ,
                                        objMail.mailText ,
                                        objMail.isAttach ,
                                        objMail.attachmentPath ,
                                        objMail.mailStatus ,
                                        objMail.mailType ,
                                        objMail.sourceType ,
                                        objMail.sourceId ,
                                        objMail.createdBy ,
                                        objMail.sendDate ,
                                        objMail.createdDate ,
                                        objMail.modifyBy ,
                                        objMail.modifyDate 
                                        
                                    };

            return dataAccess.SaveData(parametes, "InsertUpdateMailStatus", "MailStatus");
        }
       
        public MailHelper Send(MailHelper objMail)
        {
            objMail.sendDate = DateTime.Now.ToString();
            try
            {
                System.Net.Mail.SmtpClient objSmtpClient = new System.Net.Mail.SmtpClient();
                System.Net.Mail.MailMessage objmailMessage = new System.Net.Mail.MailMessage();
                string[] arr = objMail.mailTo.Split(new char[] { ',',';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string i in arr)
                {
                    System.Net.Mail.MailAddress obj = new System.Net.Mail.MailAddress(i);
                    objmailMessage.To.Add(obj);
                }
                if (!string.IsNullOrEmpty(objMail.mailCc))
                {
                    arr = objMail.mailCc.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string i in arr)
                    {
                        System.Net.Mail.MailAddress obj = new System.Net.Mail.MailAddress(i);
                        objmailMessage.CC.Add(obj);
                    }
                }
                if (!string.IsNullOrEmpty(objMail.mailBcc))
                {
                    arr = objMail.mailBcc.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string i in arr)
                    {
                        System.Net.Mail.MailAddress obj = new System.Net.Mail.MailAddress(i);
                        objmailMessage.Bcc.Add(obj);
                    }
                 }
                if (objMail.attachment != null && !string.IsNullOrEmpty(objMail.attachmentName) && objMail.attachment.Length > 0)
                {
                    objmailMessage.Attachments.Add(new Attachment(objMail.attachment, objMail.attachmentName));
                }
                System.Net.Mail.MailAddress strfrom = null;
                if (string.IsNullOrEmpty(objMail.mailFrom))
                {
                    strfrom = new System.Net.Mail.MailAddress(((System.Net.NetworkCredential)(objSmtpClient.Credentials)).UserName);
                    objMail.mailFrom = strfrom.Address;
                }
                else
                {
                    strfrom = new System.Net.Mail.MailAddress(objMail.mailFrom);
                }
                objmailMessage.From = strfrom;
                objmailMessage.Subject = objMail.mailSubject;
                objmailMessage.IsBodyHtml = true;
                objmailMessage.Body = objMail.mailText;
                objmailMessage.Priority = System.Net.Mail.MailPriority.High;
                objmailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess | DeliveryNotificationOptions.OnFailure;
                //objmailMessage.Headers.Add("Disposition-Notification-To", "kumar.yogesh@ebix.com");
                objmailMessage.Headers.Add("Return-Receipt-To", strfrom.ToString());
                objSmtpClient.EnableSsl = false;
                objSmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                objSmtpClient.Send(objmailMessage);
                string loc = objSmtpClient.PickupDirectoryLocation;
                objMail.mailStatus = "Sent";
                DataSet ds= this.InsertUpdateMailStatus(objMail);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objMail.sentStatus = true;
                    objMail.id = ds.Tables[0].Rows[0][0].ToString();
                }
                return objMail;
            }
            catch (Exception ex)
            {
                LogEvent.WriteErrorLog(ex, "Email could not be sent to " + objMail.mailTo);
                objMail.mailStatus = "Fail";
                this.InsertUpdateMailStatus(objMail);
                objMail.sentStatus = false;
                return objMail;
            }

        }
    }

    public class MailHelper
    {
        public string id { set; get; }
        public string mailTo { set; get; }
        public string mailFrom { set; get; }
        public string mailCc { set; get; }
        public string mailBcc { set; get; }
        public string mailSubject { set; get; }
        public string mailText { set; get; }
        public bool isAttach { set; get; }
        public Stream attachment { set; get; }
        public string attachmentName { set; get; }
        public string attachmentPath { set; get; }
        public string mailStatus { set; get; }
        public string sendDate { set; get; }
        public string createdBy { set; get; }
        public string createdDate { set; get; }
        public string modifyBy { set; get; }
        public string modifyDate { set; get; }
        public string emailType { set; get; }
        public string mailType { set; get; }
        public string sourceType { set; get; }
        public string sourceId { set; get; }
        public bool sentStatus { set; get; }
        public MailHelper() { id = "0"; }
    }

}
