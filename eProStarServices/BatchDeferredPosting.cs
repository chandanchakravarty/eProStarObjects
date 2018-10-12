using System;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
//using LumenWorks.Framework.IO.Csv;
using System.Web.Mail;
using System.Threading;
using System.Collections;
using BusinessObjectLayer.Common;
using BusinessAccessLayer.Common;
using BusinessAccessLayer.AccountModule.Accounts;
using Utility;
using System.Collections.Generic;

namespace eProStarServices
{
    public class BatchDeferredPosting
    {
        private DataSet dataSet = new DataSet();
        private DataSet DeferredDS = new DataSet();

        clsACCommon objCLSACCommon = new clsACCommon(); 
        JobSchedule objJobSchedule = new JobSchedule();
        //JobScheduleManager objJobScheduleManager = new JobScheduleManager();

        protected string mstrConStr = "";

        private string mClientCode = "";
        private ConfigurationSettingReader _ConfigReader = null;

        public BatchDeferredPosting(ConfigurationSettingReader ConfigReader)
        {
            _ConfigReader = ConfigReader;
            mClientCode = _ConfigReader.ClientCode;
        }

        public void beginProcess()
        {
            if (mClientCode == "HOWDEN")
            {
                try
                {
                    EventLogs.Publish("Deferred Brokerage Posting Service Started", System.Diagnostics.EventLogEntryType.Information);
                    mstrConStr = _ConfigReader.ConnString;

                    GetSheduleTime();
                    ExecuteDeferredBrokeragePosting();

                    EventLogs.Publish("Deferred Brokerage Posting Service Completed", System.Diagnostics.EventLogEntryType.Information);
                }
                catch (Exception ex)
                {
                    //Dictionary<string, object> dict = new Dictionary<string, object>();
                    //dict.Add("Date & Time   :", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                    //dict.Add("Message       :", ex.Message);
                    //dict.Add("Stacktrace    :", ex.StackTrace);
                    //dict.Add("Exception     :", ex.ToString());
                    //LogEvent.WriteError(ex, "Error in Payment Batching - Check and Create", dict);
                    ServiceUtility.WriteLog(ex.ToString());
                }
            }
        }


        protected void GetSheduleTime()
        {
            //string strAdhocDate = "", strAdhocHr = "", strAdhocMin = "";
            string strFrequency = "", strWeekDay = "", strHr = "", strMin = "", strMontlyDate = "", strFrequencyAdhocDate = "";
            //string strOtherDate = "", strOtherHr = "", strOtherMin = "";
            string[] strNow = System.DateTime.Now.TimeOfDay.ToString().Split(':');
            string strCurrentDate = System.DateTime.Now.ToString("dd/MM/yyyy");
            string _dayNumberOfMonth = System.DateTime.Now.Day.ToString();
            string strCurrentDay = System.DateTime.Now.DayOfWeek.ToString().Substring(0, 3).ToUpper();
            
            try
            {
                dataSet = GetDataSet("proc_AC_GetDefferedPostingSchedule'" + "" + "'");

                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dataSet.Tables[0].Select())
                    {
                        strFrequency = dr["ScheduleFrequency"].ToString();
                        if (strFrequency.Equals("D"))
                        {
                            strHr = dr["ScheduleTime"].ToString().PadLeft(4, '0').Substring(0, 2);
                            strMin = dr["ScheduleTime"].ToString().PadLeft(4, '0').Substring(2, 2);

                            if (strNow[0].Equals(strHr) && strNow[1].Equals(strMin))
                            {
                                CreateJobQueue(dr["ScheduleId"].ToString());
                                //CreateBatch(dr["SchID"].ToString(), dr["PayeeType"].ToString());
                            }
                        }
                        else if (strFrequency.Equals("W"))
                        {
                            int _dayOfWeek = Convert.ToInt32(dr["ScheduleDay"]);
                            strWeekDay = Enum.GetName(typeof(DayName), _dayOfWeek).Substring(0, 3).ToUpper();
                            //strWeekDay = dr["ScheduleDay"].ToString();
                            strHr = dr["ScheduleTime"].ToString().PadLeft(4, '0').Substring(0, 2);
                            strMin = dr["ScheduleTime"].ToString().PadLeft(4, '0').Substring(2, 2);

                            if (strWeekDay.Equals(strCurrentDay.ToUpper()) && strNow[0].Equals(strHr) && strNow[1].Equals(strMin))
                            {
                                CreateJobQueue(dr["ScheduleId"].ToString());
                                //CreateBatch(dr["SchID"].ToString(), dr["PayeeType"].ToString());
                            }
                        }
                        else if (strFrequency.Equals("M"))
                        {
                            //strMontlyDate = dr["FrequencyDate"].ToString();
                            //strMontlyDate = dr["FrequencyMonthlyDate"].ToString();
                            strMontlyDate = dr["ScheduleDay"].ToString();
                            strHr = dr["ScheduleTime"].ToString().PadLeft(4, '0').Substring(0, 2);
                            strMin = dr["ScheduleTime"].ToString().PadLeft(4, '0').Substring(2, 2);

                            if (_dayNumberOfMonth.Equals(strMontlyDate) && strNow[0].Equals(strHr) && strNow[1].Equals(strMin))
                            {
                                CreateJobQueue(dr["ScheduleId"].ToString());
                            }
                        }
                        //else if (strFrequency.Equals("A"))
                        //{
                        //    strFrequencyAdhocDate = dr["FrequencyAdhocDate"].ToString();
                        //    strHr = dr["Time"].ToString().Substring(0, 2);
                        //    strMin = dr["Time"].ToString().Substring(2, 2);

                        //    if (strCurrentDate.Equals(strFrequencyAdhocDate) && strNow[0].Equals(strHr) && strNow[1].Equals(strMin))
                        //    {
                        //        CreateJobQueue(dr["SchID"].ToString());                            
                        //    }
                        //}

                        //if (dr["SchAdhocDate"].ToString() != "")
                        //{
                        //    strAdhocDate = dr["SchAdhocDate"].ToString();
                        //    strAdhocHr = dr["SchAdhocTime"].ToString().Substring(0, 2);
                        //    strAdhocMin = dr["SchAdhocTime"].ToString().Substring(2, 2);

                        //    if (strCurrentDate.Equals(strAdhocDate) && strNow[0].Equals(strAdhocHr) && strNow[1].Equals(strAdhocMin))
                        //    {
                        //        CreateJobQueue(dr["SchID"].ToString());
                        //        //CreateBatch(dr["SchID"].ToString(), dr["PayeeType"].ToString());
                        //    }
                        //}

                        //if (dr["SchDateOtherDaily"].ToString() != "")
                        //{
                        //    strOtherDate = dr["SchDateOtherDaily"].ToString();
                        //    strOtherHr = dr["SchDateOtherTime"].ToString().Substring(0, 2);
                        //    strOtherMin = dr["SchDateOtherTime"].ToString().Substring(2, 2);

                        //    if (strCurrentDate.Equals(strOtherDate) && strNow[0].Equals(strOtherHr) && strNow[1].Equals(strOtherMin))
                        //    {
                        //        CreateJobQueue(dr["SchID"].ToString());
                        //        //CreateBatch(dr["SchID"].ToString(), dr["PayeeType"].ToString());
                        //    }
                        //}
                    }
                }

            }
            catch (Exception ex)
            {
                ServiceUtility.WriteLog(ex.ToString());
            }

            //dataSet = objCLSACCommon.GetDefferedPostingSchedule("");
            
        }
        public enum DayName
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 3,
            Wednesday = 4,
            Thursday = 5,
            Friday = 6,
            Saturday = 7,
        }
        protected void CreateJobQueue(string ShID)
        {
            objJobSchedule = new BusinessObjectLayer.Common.JobSchedule();
            objJobSchedule.JobType = "DB";
            objJobSchedule.QueueStartDate = objJobSchedule.ScheduledStartDateTime = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            objJobSchedule.ProcessRefNo = ShID;
            //objJobScheduleManager.CreateJobQueue(objJobSchedule);
            dataSet = GetDataSet("P_IT_CreateJobQueue'" + "DB" + "','" + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "','" + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "','" + ShID + "'");            
        }

        public void ExecuteDeferredBrokeragePosting()
        {
            //AC_P_CheckQueueToPerformDefPosting
            //dataSet = objJobScheduleManager.CheckQueueToPerformDeferredPosting();
            dataSet = GetDataSet("AC_P_CheckQueueToPerformDefPosting");
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {   
                try
                {                    
                    PostDeferred(dataSet.Tables[0].Rows[0]["JobNumber"].ToString(), dataSet.Tables[0].Rows[0]["ScheduleId"].ToString());
                }
                catch (Exception ex)
                {
                    ServiceUtility.WriteLog(ex.ToString());
                }
                
            }

        }
        public void PostDeferred(string strJobNumber, string ShID)
        {
            //Dictionary<string, object> dict = new Dictionary<string, object>();
            //dict.Add("Date & Time   :", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            //dict.Add("Message       :", "Deferred Posting with schedule id : " + ShID + " & Job number : " + strJobNumber);
            //LogEvent.WriteError(null, "Started - Processing Deferred Posting", dict);

            //objAdmin.SchID = ShID.ToString();
            //objAdmin.PayeeType = payeeType.ToString();
            //DeferredDS = objCLSACCommon.PushDeferredBrokToGLTran(strJobNumber, ShID);
            try
            {
                DeferredDS = GetDataSet("PushDeferredBrokToGLTran'" + ShID + "','" + strJobNumber + "','" + "" + "','" + "" + "' ");//(strJobNumber, ShID);
                if (DeferredDS != null && DeferredDS.Tables.Count > 0 && DeferredDS.Tables[0].Rows.Count > 0)
                {
                    string result = DeferredDS.Tables[0].Rows[0]["ResultDesc"].ToString();
                    ServiceUtility.WriteLog(result);
                }
            }
            catch (Exception ex)
            {
                ServiceUtility.WriteLog(ex.ToString());
            }

            //dict = new Dictionary<string, object>();
            //dict.Add("Date & Time   :", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            //dict.Add("Message       :", "Processing Batching with schedule id : " + ShID + " & Job number : " + strJobNumber);
            //LogEvent.WriteError(null, "End - Processing Payment Batching", dict);
        }

        public DataSet GetDataSet(string pstrSqlQuery)
        {
            DataSet oDataSet = new DataSet();
            SqlConnection lobjConnection = new SqlConnection(mstrConStr);
            lobjConnection.Open();
            SqlTransaction myTran = lobjConnection.BeginTransaction("APP_DB_Tran_DS");
            SqlCommand myCommand = new SqlCommand(pstrSqlQuery, lobjConnection);
            myCommand.Transaction = myTran;
            myCommand.CommandTimeout = 0;
            try
            {
                SqlDataAdapter oDataAdapter = new SqlDataAdapter(myCommand);
                oDataAdapter.Fill(oDataSet, "Resultset");
                myCommand.Transaction.Commit();
                oDataAdapter.Dispose();
                oDataAdapter = null;
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
                ServiceUtility.WriteLog(ex.ToString());
                myCommand.Transaction.Rollback();
            }
            finally
            {
                myTran.Dispose();
                myCommand.Dispose();
                if (lobjConnection != null && lobjConnection.State == ConnectionState.Open)
                {
                    lobjConnection.Close();
                }
            }
            return oDataSet;
        }
        protected void WriteLog(string strLogMsg)
        {
            EventLogs.Publish(strLogMsg, System.Diagnostics.EventLogEntryType.Information);
        }

        //protected void WriteLog(string strLogMsg)
        //{
        //    if (blLogEnabled)
        //        swLog.WriteLine(strLogMsg);
        //}

        //private void BatchEmailNotifiCation(bool blResubmit)
        //{
        //    bool blSendEmail = chkBool("Select count(batchID) from UW_batchUploadSummary Where not Status in (4,5,6,7) and batchID=" + strBatchId);

        //    if ((blSendEmail) && (!blResubmit))
        //    {
        //        try
        //        {
        //            string mstrSmtpSvr = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString().Trim();
        //            string mstrMailTo = ConExecScalar("exec P_Batch_SendmailTo '" + strBatchId + "'").ToString();
        //            string mstrMailFrom = System.Configuration.ConfigurationSettings.AppSettings["MailFrom"].ToString().Trim();
        //            string mstrMsg = ConExecScalar("Exec P_Batch_EmailNotification " + strBatchId).ToString();
        //            DataSet dsValue = Cession();

        //            MailMessage mail = new MailMessage();
        //            mail.To = mstrMailTo;
        //            mail.From = mstrMailFrom;
        //            mail.Subject = dsValue.Tables[0].Rows[0]["BordereauxNo"].ToString() + " (UW " + dsValue.Tables[0].Rows[0]["UwYear"].ToString() + ") - Notification summary for bordereaux submission";
        //            mail.BodyFormat = MailFormat.Html;
        //            mail.Body = mstrMsg;

        //            SmtpMail.SmtpServer = mstrSmtpSvr;  //your real server goes here
        //            SmtpMail.Send(mail);
        //        }
        //        catch
        //        {
        //            WriteLog("InValid Email");
        //        }
        //    }
        //}
        //private void BatchErrorNotification(string mstrMsg)
        //{
        //    try
        //    {
        //        string mstrSmtpSvr = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"].ToString().Trim();
        //        string mstrMailTo = System.Configuration.ConfigurationSettings.AppSettings["MailTo"].ToString().Trim();
        //        string mstrMailFrom = System.Configuration.ConfigurationSettings.AppSettings["ErrorMailFrom"].ToString().Trim();

        //        MailMessage mail = new MailMessage();
        //        mail.To = mstrMailTo;
        //        mail.From = mstrMailFrom;
        //        mail.Subject = "Error Batch Upload";
        //        mail.BodyFormat = MailFormat.Html;
        //        mail.Body = "Batch Id : " + strBatchId + " <BR> Message : " + mstrMsg;

        //        SmtpMail.SmtpServer = mstrSmtpSvr;  //your real server goes here
        //        SmtpMail.Send(mail);
        //    }
        //    catch
        //    {
        //        WriteLog("InValid Email");
        //    }
        //}
        //private DataSet Cession()
        //{
        //    SqlConnection scCon = null;
        //    DataSet oDataSet = new DataSet();
        //    try
        //    {
        //        scCon = new SqlConnection(mstrConStr);
        //        scCon.Open();
        //        string strSQL = "";

        //        strSQL = "select CessionMonth,CessionYear,BordereauxNo,UwYear from UW_BatchUploadSummary Where BatchId=" + strBatchId;//

        //        SqlCommand scCmd = new SqlCommand(strSQL, scCon);
        //        SqlDataAdapter oDataAdapter = new SqlDataAdapter(scCmd);
        //        oDataAdapter.Fill(oDataSet, "Resultset");
        //        oDataAdapter.Dispose();
        //        oDataAdapter = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        scCon.Close();
        //    }
        //    return oDataSet; ;
        //}

        //private void ConExec(string strCommand)
        //{
        //    SqlConnection scCon = null;
        //    try
        //    {
        //        scCon = new SqlConnection(mstrConStr);
        //        scCon.Open();
        //        SqlCommand scCmd = new SqlCommand(strCommand, scCon);
        //        scCmd.CommandTimeout = 60000;
        //        scCmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        scCon.Close();
        //    }
        //}
        //private object ConExecScalar(string strCommand)
        //{
        //    SqlConnection scCon = null;
        //    object oTemp = null;
        //    try
        //    {
        //        scCon = new SqlConnection(mstrConStr);
        //        scCon.Open();
        //        SqlCommand scCmd = new SqlCommand(strCommand, scCon);
        //        oTemp = scCmd.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        scCon.Close();
        //    }
        //    return oTemp;
        //}
        //private bool chkBool(string strSQL)
        //{
        //    SqlConnection scCon = null;
        //    bool blToReturn = true;
        //    try
        //    {
        //        scCon = new SqlConnection(mstrConStr);
        //        scCon.Open();


        //        SqlCommand scCmd = new SqlCommand(strSQL, scCon);
        //        int intRecCnt = int.Parse(scCmd.ExecuteScalar().ToString());
        //        blToReturn = (intRecCnt < 1) ? false : true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        scCon.Close();
        //    }
        //    return blToReturn;
        //}

        //private string chkFormat(string strSQL)
        //{
        //    SqlConnection scCon = null;
        //    string valToReturn = "1";
        //    try
        //    {
        //        scCon = new SqlConnection(mstrConStr);
        //        scCon.Open();

        //        SqlCommand scCmd = new SqlCommand(strSQL, scCon);
        //        int intRecCnt = 0;
        //        if (scCmd.ExecuteScalar().ToString() != null)
        //            intRecCnt = int.Parse(scCmd.ExecuteScalar().ToString());
        //        valToReturn = intRecCnt.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        scCon.Close();
        //    }
        //    return valToReturn;
        //}

        //private int chkComplete(string strSQL)
        //{
        //    SqlConnection scCon = null;
        //    int blToReturn = 1;
        //    try
        //    {
        //        scCon = new SqlConnection(mstrConStr);
        //        scCon.Open();


        //        SqlCommand scCmd = new SqlCommand(strSQL, scCon);
        //        int intRecCnt = int.Parse(scCmd.ExecuteScalar().ToString());
        //        blToReturn = intRecCnt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        scCon.Close();
        //    }
        //    return blToReturn;
        //}

        private void readConfigSettings()
        {
            /*try
            {
                mstrConStr = System.Configuration.ConfigurationSettings.AppSettings["DBConnectionString"];
                mstrSourceFilePath = System.Configuration.ConfigurationSettings.AppSettings["CSVSourceFilePath"];
                mstringLookUpInterval = System.Configuration.ConfigurationSettings.AppSettings["LookUpInterval"];
                string strLogEnabled = System.Configuration.ConfigurationSettings.AppSettings["LOGEnabled"];
                MailActivation = System.Configuration.ConfigurationSettings.AppSettings["MailActive"];
                blLogEnabled = (strLogEnabled.ToUpper().Equals("YES")) ? true : false;
            }
            catch (Exception ex)
            {
                PublishToEventLog("Unable to locate configuration strings in the .confg file! " + ex.ToString(), EventLogEntryType.Error);
            }*/
        }
        //public void PublishToEventLog(string strMessage, EventLogEntryType messageType)
        //{
        //    if (EventLog.SourceExists("SIPLPaymentBatch"))
        //    {
        //        try
        //        {
        //            EventLog.WriteEntry("SIPLPaymentBatch", strMessage, System.Diagnostics.EventLogEntryType.Error);
        //        }
        //        catch { }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            EventLog.CreateEventSource("SIPLPaymentBatch", "SIPLPaymentBatchErrors");
        //            EventLog.WriteEntry("SIPLPaymentBatch", strMessage, EventLogEntryType.Error, 222, 1);
        //        }
        //        catch { }
        //    }
        //}

        #region "Validate Field"
        //private string ValidateField(string strFieldName, string strErrorText, DataRow row, Constants.ValidationTypes validationType)
        //{
        //    string strReturnVale = "";
        //    if (!RegExValidate.Process(validationType, row[strFieldName].ToString()))
        //    {
        //        strReturnVale = strErrorText;
        //        row[strFieldName] = row[strFieldName] + "-err-" + strErrorText.ToString();
        //    }
        //    return strReturnVale;
        //}
        #endregion

        #region "Construct New Data Table"
        //private void ConstructNewDataTable(DataTable dtOldDataTable, DataTable dtNewDataTable)
        //{
        //    DataRow dtRow = null;
        //    DataView dtView = null;
        //    dtView = dtOldDataTable.DefaultView;
        //    dtView.Sort = "RowNo";
        //    foreach (DataRow drCurrRow in dtView.Table.Rows)
        //    {
        //        dtRow = dtNewDataTable.NewRow();

        //        dtRow["PolicyNo"] = drCurrRow["PolicyNo"].ToString().Trim();
        //        dtRow["CoCode"] = drCurrRow["CoCode"].ToString().Trim();
        //        dtRow["MCode"] = drCurrRow["MCode"].ToString().Trim();
        //        dtRow["EmpNo"] = drCurrRow["EmpNo"].ToString().Trim();
        //        dtRow["MemIDNo"] = drCurrRow["MemIDNo"].ToString().Trim();
        //        dtRow["MemberFullName"] = drCurrRow["MemberFullName"].ToString().Trim();
        //        dtRow["NameForCard"] = drCurrRow["NameForCard"].ToString().Trim();
        //        dtRow["Address1"] = drCurrRow["Address1"].ToString().Trim();
        //        dtRow["Address2"] = drCurrRow["Address2"].ToString().Trim();
        //        dtRow["Address3"] = drCurrRow["Address3"].ToString().Trim();
        //        dtRow["PostalCode"] = drCurrRow["PostalCode"].ToString().Trim();
        //        dtRow["ResidentialAddress1"] = drCurrRow["ResidentialAddress1"].ToString().Trim();
        //        dtRow["ResidentialAddress2"] = drCurrRow["ResidentialAddress2"].ToString().Trim();
        //        dtRow["ResidentialAddress3"] = drCurrRow["ResidentialAddress3"].ToString().Trim();
        //        dtRow["ResidentialPostalCode"] = drCurrRow["ResidentialPostalCode"].ToString().Trim();
        //        dtRow["EffectiveDateofCov"] = drCurrRow["EffectiveDateofCov"].ToString().Trim();
        //        dtRow["JoinDate"] = drCurrRow["JoinDate"].ToString().Trim();
        //        dtRow["OfficeTelNo"] = drCurrRow["OfficeTelNo"].ToString().Trim();
        //        dtRow["HomePhone"] = drCurrRow["HomePhone"].ToString().Trim();
        //        dtRow["MobileNo"] = drCurrRow["MobileNo"].ToString().Trim();
        //        dtRow["Fax"] = drCurrRow["Fax"].ToString().Trim();
        //        dtRow["Email"] = drCurrRow["Email"].ToString().Trim();
        //        dtRow["Nationality"] = drCurrRow["Nationality"].ToString().Trim();
        //        dtRow["DOB"] = drCurrRow["DOB"].ToString().Trim();
        //        dtRow["Gender"] = drCurrRow["Gender"].ToString().Trim();
        //        dtRow["MaritalStatus"] = drCurrRow["MaritalStatus"].ToString().Trim();
        //        dtRow["ChronicCertified"] = drCurrRow["ChronicCertified"].ToString().Trim();
        //        dtRow["Relationship"] = drCurrRow["Relationship"].ToString().Trim();
        //        dtRow["RelIDNo"] = drCurrRow["RelIDNo"].ToString().Trim();
        //        dtRow["DesigCode"] = drCurrRow["DesigCode"].ToString().Trim();
        //        dtRow["DesigDesc"] = drCurrRow["DesigDesc"].ToString().Trim();
        //        dtRow["OccupationClass"] = drCurrRow["OccupationClass"].ToString().Trim();
        //        dtRow["SumInsured"] = drCurrRow["SumInsured"].ToString().Trim();
        //        dtRow["DivisionCode"] = drCurrRow["DivisionCode"].ToString().Trim();
        //        dtRow["DivisionEffectiveDate"] = drCurrRow["DivisionEffectiveDate"].ToString().Trim();
        //        dtRow["DepartmentCode"] = drCurrRow["DepartmentCode"].ToString().Trim();
        //        dtRow["DepartmentEffectiveDate"] = drCurrRow["DepartmentEffectiveDate"].ToString().Trim();
        //        dtRow["CostCenterCode"] = drCurrRow["CostCenterCode"].ToString().Trim();
        //        dtRow["CostCenterEffectiveDate"] = drCurrRow["CostCenterEffectiveDate"].ToString().Trim();
        //        dtRow["StCat"] = drCurrRow["StCat"].ToString().Trim();
        //        dtRow["ScEffDate"] = drCurrRow["ScEffDate"].ToString().Trim();
        //        dtRow["PrevPlanCode"] = drCurrRow["PrevPlanCode"].ToString().Trim();
        //        dtRow["NewPlanCode"] = drCurrRow["NewPlanCode"].ToString().Trim();
        //        dtRow["NewPlanCodeEffDate"] = drCurrRow["NewPlanCodeEffDate"].ToString().Trim();
        //        dtRow["NameAsPerBankAs"] = drCurrRow["NameAsPerBankAs"].ToString().Trim();
        //        dtRow["BankName"] = drCurrRow["BankName"].ToString().Trim();
        //        dtRow["BranchCode"] = drCurrRow["BranchCode"].ToString().Trim();
        //        dtRow["BankACNo"] = drCurrRow["BankACNo"].ToString().Trim();
        //        dtRow["EndDateofCov"] = drCurrRow["EndDateofCov"].ToString().Trim();
        //        dtRow["ParseResult"] = drCurrRow["ParseResult"].ToString().Trim();
        //        dtRow["IsSubsidiary"] = drCurrRow["IsSubsidiary"].ToString().Trim();
        //        dtRow["RowNo"] = drCurrRow["RowNo"].ToString().Trim();

        //        dtNewDataTable.Rows.Add(dtRow);
        //    }
        //}
        #endregion
    }
}
