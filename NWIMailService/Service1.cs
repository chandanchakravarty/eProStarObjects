using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration;
using BusinessAccessLayer.BrokingModule.BrokingSystem.EmployeeBenefits;
using BusinessAccessLayer.BrokingModule.BrokingSystem.Quotation;
using System.Timers;

namespace NWIMailService
{
    public partial class MailService : ServiceBase
    {
        QuotationManager objQuotationBI = new QuotationManager();
        //System.Threading.Timer timer;
        Timer TimerMail = new Timer();

        public MailService()
        {
            InitializeComponent();
            if (!System.Diagnostics.EventLog.SourceExists("DoNWIMailService"))
                System.Diagnostics.EventLog.CreateEventSource("DoNWIMailService",
                                                                      "NWIMailService");

            eventLog1.Source = "DoNWIMailService";
            eventLog1.Log = "NWIMailService";
            
        }
        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("NWI Mail Service Started.");
            string startTimeString = ConfigurationSettings.AppSettings["MailServiceStartTime"].ToString(); 
            DateTime startTime;
            int millisecondsToStart = 0;

            if (DateTime.Now >= DateTime.ParseExact(startTimeString, "HHmm", null))
            {

                startTime = DateTime.ParseExact(startTimeString, "HHmm", null).AddDays(1);
                millisecondsToStart = (int)startTime.Subtract(DateTime.Now).TotalMilliseconds;

            }
            else
            {
                startTime = DateTime.ParseExact(startTimeString, "HHmm", null);
                millisecondsToStart = (int)startTime.Subtract(DateTime.Now).TotalMilliseconds;
            
            }

            TimerMail.Interval = millisecondsToStart;
            TimerMail.Start();
            TimerMail.Elapsed += new ElapsedEventHandler(TimerMail_Elapsed);
            //timer = new System.Threading.Timer(OnElapsedTime, null, millisecondsToStart, Convert.ToInt32(ConfigurationManager.AppSettings["intervalTime"]));
            
        }

        void TimerMail_Elapsed(object sender, ElapsedEventArgs e)
        {
            SendMailToAcountHandler();
           
        }
             
        


        public void SendMailToAcountHandler()
        {
            try
            {
                string strFrom = "", strTo = "", strSubject = " Report EB member section.", strBody = "", strFromName = "";

                //DataSet ds = new DataSet();
                //ds = objQuotationBI.GetAccountHandlers(0);
                DataView dv = new DataView(objQuotationBI.GetAccountHandlersForMailSend().Tables[0], "", "", DataViewRowState.CurrentRows);
                dv.RowFilter = "UserType_AH='AH'" + " and EffectiveEndDate Is NULL";
                if (dv != null)
                {
                    if (dv.Count > 0)
                    {
                        for (int i = 0; i < dv.Count; i++)
                        {
                            int UserId = Convert.ToInt32(dv[i]["UserId"]);
                            strFrom = strTo = dv[i]["Email"].ToString();
                            strFromName = dv[i]["FirstName"].ToString();
                            DataSet dsMail = new DataSet();
                            dsMail = objQuotationBI.GetMailToAccountHandler(UserId);
                            if (dsMail != null)
                            {
                                //Body for html format---
                                StringBuilder sb = new StringBuilder();
                                sb.Append("<html><body>");
                                sb.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\">");
                                sb.Append("<tr><td>Greetings!</td></tr>");
                                sb.Append("<tr><td>&nbsp&nbsp</td></tr>");
                                sb.Append("<tr><td>&nbsp&nbsp</td></tr>");
                                sb.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"1\">");
                                sb.Append("<tr><td> S.No </td><td> Cover Note No. </td><td> Member Code </td><td> Member Name </td><td> Fields With No Data </td></tr>");
                                int sno = 0;
                                if (dsMail.Tables["MailToAccountHandler"].Rows.Count > 0)
                                {
                                    for (int j = 0; j < dsMail.Tables["MailToAccountHandler"].Rows.Count; j++)
                                    {
                                        string strMemberCode, strMemberName, strCoverNoteNo, strFieldsName;
                                        strMemberCode = dsMail.Tables["MailToAccountHandler"].Rows[j]["MemberCode"].ToString();
                                        strMemberName = dsMail.Tables["MailToAccountHandler"].Rows[j]["MemberName"].ToString();
                                        strCoverNoteNo = dsMail.Tables["MailToAccountHandler"].Rows[j]["CoverNoteNo"].ToString();
                                        strFieldsName = dsMail.Tables["MailToAccountHandler"].Rows[j]["FieldsName"].ToString();
                                        sno = j + 1;
                                        sb.Append("<tr><td>" + sno + "</td>");
                                        sb.Append("<td>" + strCoverNoteNo + "</td>");
                                        sb.Append("<td>" + strMemberCode + "</td>");
                                        sb.Append("<td>" + strMemberName + "</td>");
                                        sb.Append("<td>" + strFieldsName + "</td>");



                                    }
                                }
                                sb.Append("</tr></table>");

                                sb.Append("<tr><td>&nbsp&nbsp</td></tr>");
                                sb.Append("<tr><td>Have a nice day.</td></tr>");
                                //sb.Append("<tr><td>You are requested to approve the client.</td></tr>");
                                sb.Append("<tr><td>Thanks and regards.</td></tr>");
                                sb.Append("<tr><td> " + strFromName + "&nbsp&nbsp</td></tr>");
                                sb.Append("<tr><td>" + DateTime.Now.ToString("dd/MM/yyyy") + "</td></tr>");
                                sb.Append("</table>");
                                sb.Append("</body></html>");
                                strBody = sb.ToString();


                                bool result = Utility.UIHelper.SentMail(strFrom, strTo, strSubject, strBody);
                                if (result)
                                {
                                    objQuotationBI.UpdateMailToAccountHandler(UserId);
                                    eventLog1.WriteEntry("NWI Mail Service Sent Mail.");
                                }
                            }
                            //return result;
                        }
                    }
                }

                
            }
            catch (Exception ex) { eventLog1.WriteEntry(ex.Message.ToString()); }
        }


        protected override void OnStop()
        {
            eventLog1.WriteEntry("NWI Mail Service Stopped.");
        }
    }
}
