//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data;
//using System.Data.Common;
//using System.Data.SqlClient;
//using System.Configuration;
////using Microsoft.Practices.EnterpriseLibrary.Data;
//using Microsoft.Practices.EnterpriseLibrary.Common;

//namespace NWIMailService
//{
//    public class clsMailDataAccess
//    {
        
//        //DataAccess dataAccessDS = null;
//        protected Database dataBase = null;
//        protected DataSet dataSet = null;
//        DbConnection con = null;
//        public clsMailDataAccess()
//        {
//            dataBase = DatabaseFactory.CreateDatabase("eProfessional_N");
//        }
//        public void f_SendMail()
//        {
            
//            startMailing();
            
//        }
        
//        public void startMailing()
//        {

//            SendMailToAcountHandler();

//        }
//        public DataSet GetAccountHandlers(int userId)
//        {
//            object[] parameters = new object[] { userId };
//            //dataAccessDS = new DataAccess();
//            return LoadDataSet(parameters, "P_Pol_Policy_GetAccountHandlers", "Pol_PolicyAccHandlers");

//        }
        
//        public DataSet LoadDataSet(object[] parameters, string procName, string dataTableName)
//        {
//            dataSet = new DataSet();
//           // SqlConnection lobjConnection = new SqlConnection(mstrConStr);
//            dataBase.LoadDataSet(dataBase.GetStoredProcCommand(procName, parameters), dataSet, dataTableName);
//            return dataSet;
//        }
//        public DataSet GetMailToAccountHandler(int userId)
//        {
//            object[] parameters = new object[] { userId };
            
//            return LoadDataSet(parameters, "P_MailToAccountHandler", "MailToAccountHandler");
//        }

//        public bool SendMailToAcountHandler()
//        {

//            string strFrom = "", strTo = "", strSubject = " Report EB member section.", strBody = "";

//            //DataSet ds = new DataSet();
//            //ds = objQuotationBI.GetAccountHandlers(0);
//            DataView dv = new DataView(GetAccountHandlers(0).Tables[0], "", "", DataViewRowState.CurrentRows);
//            dv.RowFilter = "UserType_AH='AH'" + " and EffectiveEndDate Is NULL";
        
//            for (int i = 0; i < dv.Table.Rows.Count; i++)
//            {
//                int UserId = Convert.ToInt32(dv[i]["UserId"]);
//                strTo = strFrom = dv[i]["Email"].ToString();
//                DataSet dsMail = new DataSet();
//                dsMail = GetMailToAccountHandler(UserId);

//                //Body for html format---
//                StringBuilder sb = new StringBuilder();
//                sb.Append("<html><body>");
//                sb.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\">");
//                sb.Append("<tr><td>Greetings!</td></tr>");
//                sb.Append("<tr><td>&nbsp&nbsp</td></tr>");
//                sb.Append("<tr><td>&nbsp&nbsp</td></tr>");
//                sb.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"1\">");
//                sb.Append("<tr><td> S.No </td><td> Cover Note No. </td><td> Member Code </td><td> Member Name </td><td> Fields With No Data </td></tr>");

//                for (int j = 0; j < dsMail.Tables["MailToAccountHandler"].Rows.Count; j++)
//                {
//                    string strMemberCode, strMemberName, strCoverNoteNo, strFieldsName;
//                    strMemberCode = dsMail.Tables["MailToAccountHandler"].Rows[j]["MemberCode"].ToString();
//                    strMemberName = dsMail.Tables["MailToAccountHandler"].Rows[j]["MemberName"].ToString();
//                    strCoverNoteNo = dsMail.Tables["MailToAccountHandler"].Rows[j]["CoverNoteNo"].ToString();
//                    strFieldsName = dsMail.Tables["MailToAccountHandler"].Rows[j]["FieldsName"].ToString();

//                    sb.Append("<tr><td>" + strCoverNoteNo +"</td>");
//                    sb.Append("<td>" + strMemberCode +"</td>");
//                    sb.Append("<td>" + strMemberName + "</td>");
//                    sb.Append("<td>" + strFieldsName + "</td>");
//                    sb.Append("</tr></table>");


//                }
                
//                sb.Append("<tr><td>&nbsp&nbsp</td></tr>");
//                sb.Append("<tr><td>Have a nice day.</td></tr>");
//                //sb.Append("<tr><td>You are requested to approve the client.</td></tr>");
//                sb.Append("<tr><td>Thanks and regards.</td></tr>");
//                sb.Append("<tr><td>&nbsp&nbsp</td></tr>");
//                sb.Append("<tr><td>" + DateTime.Now.ToString("dd/MM/yyyy") + "</td></tr>");
//                sb.Append("</table>");
//                sb.Append("</body></html>");
//                strBody = sb.ToString();


//                bool result = SentMail(strFrom, strTo, strSubject, strBody);
//                return result;

//            }


//            return true;
//        }

//        public static bool SentMail(string strFrom, string strTo, string strSubject, string strBody)
//        {
//            try
//            {
//                System.Net.Mail.MailMessage objmailMessage = new System.Net.Mail.MailMessage();

//                string[] arr = strTo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

//                foreach (string i in arr)
//                {

//                    System.Net.Mail.MailAddress obj = new System.Net.Mail.MailAddress(i);
//                    objmailMessage.To.Add(obj);

//                }
//                System.Net.Mail.MailAddress strfrom = new System.Net.Mail.MailAddress(strFrom);
//                objmailMessage.From = strfrom;
//                objmailMessage.Subject = strSubject;
//                objmailMessage.IsBodyHtml = true;
//                objmailMessage.Body = strBody;
//                objmailMessage.Priority = System.Net.Mail.MailPriority.High;
//                // objmailMessage.DeliveryNotificationOptions |=  System.Net.Mail.DeliveryNotificationOptions.OnSuccess | System.Net.Mail.DeliveryNotificationOptions.OnFailure;
//                objmailMessage.DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnFailure;
//                System.Net.NetworkCredential objCredential = new System.Net.NetworkCredential();
//                System.Net.Mail.SmtpClient objSmtpClient = new System.Net.Mail.SmtpClient();
//                //objSmtpClient.Credentials
//                objSmtpClient.EnableSsl = false;
//                objSmtpClient.Send(objmailMessage);
//                return true;
//            }
//            catch
//            {
//                return false;
//            }

//        }

    

//    }
//}
