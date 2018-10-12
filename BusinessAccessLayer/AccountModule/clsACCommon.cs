using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Data;
using BusinessObjectLayer.AccountModule;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;
using System.Collections;
using System.Dynamic;
using BusinessObjectLayer.BrokingModule.Reports;
using BusinessAccessLayer.Common;
using BusinessAccessLayer.SystemAdmin.UserSetUp;
using Utility;
namespace BusinessAccessLayer.AccountModule.Accounts
{
   public class clsACCommon
    {DatabaseInteraction dbInteraction = null;

        #region CommonFunctions
        public DataTable GetDataTable(SqlDataReader dr)
        {
            DataTable dt = new DataTable();
            try
            {
                if (dr != null)
                    dt.Load(dr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
                //dbInteraction.CloseSqlConnection();
            }
            return dt;
        }

        public DataTable GetDataTable(DataSet ds)
        {
            DataTable dt = new DataTable();
            try
            {
                if (ds != null)
                {
                    if (ds.Tables.Count>0) 
                       dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        #endregion

        #region AgentCommReport.aspx
        public SqlDataReader GetSQLRecData()
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            return dbInteraction.getDataReader("SELECT convert(char(10),getDate(),103) as RecDate");
        }

        public SqlDataReader GetDropDownData()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            return dbInteraction.getDataReader("AC_GetInsurerList");
        }
/*
        public DataSet GetReportInsurerAgentComm1(clsAgentCommReport objclsAgentCommReport)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            Object[] parameters = new Object[] { objclsAgentCommReport.SearchString, objclsAgentCommReport.DebitNoteNo, objclsAgentCommReport.PolicyNo, objclsAgentCommReport.PolicyPeriodFrom, objclsAgentCommReport.PolicyPeriodTo, objclsAgentCommReport.SummaryDate, objclsAgentCommReport.SortBy, objclsAgentCommReport.SortType };

            return dbInteraction.LoadDataSet(parameters, "AC_reportInsurerAgentComm", "EB_AC_reportInsurerAgentComm");
        }
        public DataSet GetReportInsurerAgentComm(clsAgentCommReport objclsAgentCommReport)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

            dbInteraction.AddParameter("@SearchString", objclsAgentCommReport.SearchString);
            dbInteraction.AddParameter("@DebitNoteNo", objclsAgentCommReport.DebitNoteNo);
            dbInteraction.AddParameter("@PolicyNo", objclsAgentCommReport.PolicyNo);
            dbInteraction.AddParameter("@PolicyPeriodFrom", objclsAgentCommReport.PolicyPeriodFrom);
            dbInteraction.AddParameter("@PolicyPeriodTo", objclsAgentCommReport.PolicyPeriodTo);
            dbInteraction.AddParameter("@SummaryDate", objclsAgentCommReport.SummaryDate);
            dbInteraction.AddParameter("@SortBy", objclsAgentCommReport.SortBy);
            dbInteraction.AddParameter("@SortType", objclsAgentCommReport.SortType);

            string[] tbleName = { "EB_AC_reportInsurerAgentComm" };
            return dbInteraction.GetDataset("AC_reportInsurerAgentComm", tbleName);
        }
*/
        #endregion

        #region BankPayment
        public SqlDataReader GetDropDownData_CurrencyCodes()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return dbInteraction.getDataReader("AC_GetCurrencyCodes");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetDropDownData_BankCodes()
        {
            //dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            return GetBankCodes(); //dbInteraction.getDataReader("AC_GetBankCodes");
        }

        public SqlDataReader GetSQLRecData_BankPay(string strTranRefCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                dbInteraction.AddParameter("@PaymentNo", strTranRefCode);
                return dbInteraction.getDataReader("AC_GetPaymentData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string fstrFormatDecimal(decimal pdblValue)
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            return dbInteraction.fstrFormatDecimal(pdblValue, false);
        }

        public SqlDataReader GetSubmitEnableDataFromDB(string strTranRefCode, string strFrm)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.NO, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                dbInteraction.AddParameter("@PaymentNo", strTranRefCode);
                dbInteraction.AddParameter("@form", strFrm);
                return dbInteraction.getDataReader("AC_GetSubmitEnableOption");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //if (strFrm == "BankPayment.aspx" || strFrm == "Payment.aspx")
            //    return dbInteraction.getDataReaderNonClose("SELECT  isnull(IsPosted,'N') as IsPosted, isnull(IsSubmitted,'N') as IsSubmitted,clientName  FROM AC_PaymentM WHERE PaymentNo = '" + strTranRefCode.Trim() + "' ");
            //else if (strFrm == "JournalsNew.aspx")
            //    return dbInteraction.getDataReaderNonClose("SELECT  isnull(IsPosted,'N') as IsPosted, isnull(IsSubmitted,'N') as IsSubmitted,ClientName  FROM AC_JournalM WHERE JournalNo = '" + strTranRefCode.Trim() + "' ");
            //else
            //    return null;
        }

        public DataSet GetUnMatchedAmountFromDB(string strTranRefCode, string strFrm)
        {
           dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.NO, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                dbInteraction.AddParameter("@PaymentNo", strTranRefCode);
                dbInteraction.AddParameter("@PageFrom", strFrm.Split('.')[0]);

                string[] tbleName = { "AC_PaymentM" };
                return dbInteraction.GetDataset("AC_GetUnMatchedAmount", tbleName);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DataSet GetApprovalDataDashboard(string uid, string entityType)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.NO, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                dbInteraction.AddParameter("@uid", uid);
                dbInteraction.AddParameter("@EntityType", entityType);

                string[] tbleName = { "ApprovalDataDashboard" };
                return dbInteraction.GetDataset("Proc_GetApprovalDataDashboard", tbleName);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DataSet GetBankDataFromDB(string strTranRefCode, string strBankTranNo)
        {
            //dbInteraction = new DatabaseInteraction(CommandType.Text);
            //dbInteraction.AddParameter("@RefCode", strTranRefCode, SqlDbType.VarChar);
            //dbInteraction.AddParameter("@BankTranNo", strBankTranNo, SqlDbType.VarChar);
            //return dbInteraction.getDataReaderNonClose("SELECT BankCode, convert(char(10),ChequeDate,103) as ChDate, isnull(ChequeNo,'') ChNo, isNull(Amount,0) as Amount, CurrencyCode, ExchangeRate, isNull(LocalAmount,0) as LocalAmount FROM AC_PaymentB WHERE PaymentNo = '" + strTranRefCode.Trim() + "' AND TranNo = '" + strBankTranNo.Trim() + "'");

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.NO, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                dbInteraction.AddParameter("@PaymentNo", strTranRefCode);
                dbInteraction.AddParameter("@TranNo", strBankTranNo);

                string[] tbleName = { "AC_PaymentB" };
                return dbInteraction.GetDataset("AC_GetBankData", tbleName);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public SqlDataReader getNonTradeDataFromDB(string strTranRefCode, string strNonTradeTranNo, string frmName)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.NO, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@PaymentNo", strTranRefCode);
            dbInteraction.AddParameter("@TranNo", strNonTradeTranNo);
            try
            {
                return dbInteraction.getDataReader("AC_GetNonTradeData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //if (frmName == "BankPayment.aspx")
            //{
            //    return dbInteraction.getDataReaderNonClose("SELECT GLCode, isNull(DebitAmt,0) as DebitAmt, isNull(CreditAmt,0) as CreditAmt, isNull(DebitAmtP,0) as DebitAmtP, isNull(CreditAmtP,0) as CreditAmtP, DebitGSTAmt, CreditGSTAmt FROM AC_PaymentN WHERE PaymentNo = '" + strTranRefCode.Trim() + "' AND TranNo = '" + strNonTradeTranNo.Trim() + "'");
            //}

            //else if (frmName == "Payment.aspx")
            //{
            //    return dbInteraction.getDataReaderNonClose("SELECT GLCode, isNull(DebitAmt,0) as DebitAmt, isNull(CreditAmt,0) as CreditAmt, isNull(DebitAmtP,0) as DebitAmtP, isNull(CreditAmtP,0) as CreditAmtP," + " DebitGSTAmt, CreditGSTAmt,isnull(DebitWHTP,0) as DebitWHTP,isnull(CreditWHTP,0) as CreditWHTP,isnull(DebitAmtPFC,0) as DebitAmtPFC ," + " isnull(CreditAmtPFC,0) as CreditAmtPFC,isnull(ExchangeRate,0) as ExchangeRate," + " isnull(CurrencyCode,'') as CurrencyCode,isnull(GLTranDesc,'') as GLTranDesc,Isnull(DebitGSTType,'') as DebitGSTType,Isnull(CreditGSTType,'') as CreditGSTType," + " GSTType FROM AC_PaymentN WHERE PaymentNo = '" + strTranRefCode.Trim() + "' AND TranNo = '" + strNonTradeTranNo.Trim() + "'");
            //}
            //else
            //    return null;
        }

        public SqlDataReader getPettyCashDataFromDB(string strTranRefCode, string strPettyCashTranNo)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.NO, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@PaymentNo", strTranRefCode);
            dbInteraction.AddParameter("@TranNo", strPettyCashTranNo);
            try
            {
                return dbInteraction.getDataReader("AC_GetPettyCashData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return dbInteraction.getDataReader("SELECT PettyCashCode as PCCode, convert(char(10),PettyCashDate,103) as PCDate, Amount, CurrencyCode, ExchangeRate, LocalAmount FROM AC_PaymentP WHERE PaymentNo = @RefCode AND TranNo = @PettyCashTranNo");
        }

        public bool IsAutoNumbering()
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            return dbInteraction.IsAutoNumbering();
        }

        //public SqlDataReader GetManualTransactionRefCode(ArrayList argList)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@TranType", argList[0]);
        //    dbInteraction.AddParameter("@TranRefCode", argList[1]);
        //    dbInteraction.AddParameter("@UserId", argList[2]);
        //    return dbInteraction.getDataReader("AC_GenerateManualTranRefCode");
        //}

        //public SqlDataReader GetEditableModes(ArrayList argParams)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@TranType", argParams[0]);
        //    dbInteraction.AddParameter("@TranRefNo", argParams[1]);
        //    dbInteraction.AddParameter("@UserId", argParams[2]);
        //    return dbInteraction.getDataReader("AC_GetEditableModes");
        //}

        //public SqlDataReader GetExchangeRate(string strpCurrCode)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@pCurrCode", strpCurrCode);
        //    return dbInteraction.getDataReader("AC_GetExchRate");
        //}

        public string GetSysParamValue(string sKeyWord)
        {
            string strTempId = "";
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@KeyWord", sKeyWord);
                SqlDataReader dr = dbInteraction.getDataReader("P_Sys_Params_Select");
                if (dr.Read())
                {
                    strTempId = dr["IsActive"].ToString().Trim();
                }
                dr.Close();
                dbInteraction.CloseSqlConnection();
                return strTempId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        //public SqlDataReader GetTransactionRefCode(string strTranType, int strUserId)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@TranType", strTranType);
        //    dbInteraction.AddParameter("@UserId", strUserId);
        //    return dbInteraction.getDataReader("AC_GenerateTranRefCode");
        //}

        public SqlDataReader GetLocalAmount(string strTranRefCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                dbInteraction.AddParameter("@TranType", strTranRefCode);
                return dbInteraction.getDataReader("AC_GetGLDataForPayments");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public SqlDataReader GetBankData(string strTranRefCode)
        {
            //dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            //dbInteraction.AddParameter("@PaymentNo", strTranRefCode);
            return GetBankDataForPayments(strTranRefCode); //dbInteraction.getDataReader("AC_GetBankDataForPayments");
        }

        public int DeleteCheque(int TranNo, string paymentNo)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                dbInteraction.AddParameter("@TranNo", TranNo);
                dbInteraction.AddParameter("@paymentNo", paymentNo);
                int retval = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_DeleteCheque");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return retval;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
            //return dbInteraction.ExecuteNonQuery(CommandType.Text, "Delete from AC_PaymentB where TranNO= @TranNo And PaymentNo= @paymentNo");
        }

        public SqlDataReader GetClientInfo(string strPaymentType, string strPaymentFrom)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.NO, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                dbInteraction.AddParameter("@PaymentType", strPaymentType);
                dbInteraction.AddParameter("@PaymentFrom", strPaymentFrom);
                return dbInteraction.getDataReader("AC_GetClientDetail");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //if (strPaymentType == "N")
            //{
            //    //dbInteraction.AddParameter("@PaymentFrom", strPaymentFrom, SqlDbType.VarChar);
            //    return dbInteraction.getDataReaderNonClose("SELECT CusM_Id as ClientId, isNull(CusM_Name1,'') + ' ' + isNull(CusM_Name2,'') + ' ' + isNull(CusM_Name3,'') as ClientName, rtrim(isnull(CusM_Address1,'')) as ClientAdd1,rtrim(isnull(CusM_Address2,'')) as ClientAdd2,rtrim(isnull(CusM_Address3,'')) as ClientAdd3,rtrim(isnull(CusM_Address4,'')) as ClientAdd4	FROM AC_NonTradeCustomerM WHERE CusM_Id = '" + strPaymentFrom.Trim() + "'");
            //}
            //else if (strPaymentType == "C")
            //{
            //    //dbInteraction.AddParameter("@PaymentFrom", strPaymentFrom, SqlDbType.VarChar);
            //    return dbInteraction.getDataReaderNonClose("SELECT CusM_Id as ClientId, isNull(CusM_Name1,'') + ' ' + isNull(CusM_Name2,'') + ' ' + isNull(CusM_Name3,'') as ClientName, rtrim(isnull(CusM_Address1,'')) + ' ' + rtrim(isnull(CusM_Address2,'')) as ClientAdd1,rtrim(isnull(CusM_Address3,'')) as ClientAdd2,rtrim(isnull(CusM_Address4,'')) as ClientAdd3,rtrim(isnull(CusM_Country,'')) + '-' + rtrim(isnull(CusM_PostalCode,'')) as ClientAdd4 FROM TM_Customer_CusM WHERE CusM_Id = '" + strPaymentFrom.Trim() + "'");
            //}
            //else if (strPaymentType == "I")
            //{
            //    //dbInteraction.AddParameter("@PaymentFrom", strPaymentFrom, SqlDbType.VarChar);
            //    return dbInteraction.getDataReader("SELECT in_insurer_code as ClientId, in_name as ClientName, rtrim(isnull(in_address1,'')) as ClientAdd1,rtrim(isnull(in_address2,'')) as ClientAdd2,rtrim(isnull(in_country,'')) as ClientAdd3,rtrim(isnull(in_pincode,'')) as ClientAdd4 FROM INSURER INS WHERE in_insurer_code = '" + strPaymentFrom.Trim() + "'");
            //}
            //else
            //    return null;
        }

        //public void UpdateRecptCashFlow(string mstrTranRefCode, string pstrTranType)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@PaymentNo", mstrTranRefCode);
        //    dbInteraction.AddParameter("@CashFlowType", pstrTranType);
        //    dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdPaymentCashFlow");
        //}

        public string GetOperatingBank()
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            string sResult = dbInteraction.ExecuteScalar("select OperatingBank from AC_Company").ToString().Trim();
            return sResult;
        }

        public SqlDataReader funGnericGLAndMatchTotalsB(string pstrTranType, string mstrTranRefCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                dbInteraction.AddParameter("@TranType", pstrTranType);
                dbInteraction.AddParameter("@TranCode", mstrTranRefCode);
                return dbInteraction.getDataReader("AC_GetGnericGLAndMatchTotalsB");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void MatchAllInvoiceData(ArrayList argsParams)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@TranRefType", argsParams[0]);
        //    dbInteraction.AddParameter("@MatchTranType", argsParams[1]);
        //    dbInteraction.AddParameter("@MatchTranCode", argsParams[2]);
        //    dbInteraction.AddParameter("@StrRecptNo", argsParams[3]);
        //    dbInteraction.AddParameter("@IsMatchReset", argsParams[4]);
        //    dbInteraction.AddParameter("@UserId", argsParams[5]);
        //    dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_MatchAllGenericData");
        //}

        //public void ClearAllInvoiceData(ArrayList argsParams, string frmName)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@TranRefType", argsParams[0]);
        //    dbInteraction.AddParameter("@MatchTranType", argsParams[1]);
        //    dbInteraction.AddParameter("@MatchTranCode", argsParams[2]);
        //    dbInteraction.AddParameter("@StrRecptNo", argsParams[3]);
        //    dbInteraction.AddParameter("@IsMatchReset", argsParams[4]);
        //    dbInteraction.AddParameter("@UserId", argsParams[5]);

        //    if (frmName == "BankPayment.aspx")
        //        dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_ClearAllGenericDataB");
        //    else if (frmName == "Payment.aspx")
        //        dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_ClearAllGenericData");
        //}

        public void ClearAllInvoiceData(string strTranRefType, string strMatchTranType, string strMatchTranCode, string strReceiptNo, string strIsMatchReset, string strUserId)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranRefType", strTranRefType);
            dbInteraction.AddParameter("@MatchTranType", strMatchTranType);
            dbInteraction.AddParameter("@MatchTranCode", strMatchTranCode);
            dbInteraction.AddParameter("@StrRecptNo", strReceiptNo);
            dbInteraction.AddParameter("@IsMatchReset", strIsMatchReset);
            dbInteraction.AddParameter("@UserId", strUserId);
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

            try
            {
                dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_ClearAllGenericDataB");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
               
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public void AddUpdateInvoiceData(ArrayList argsParams)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@StrDataP", argsParams[0]);
            dbInteraction.AddParameter("@StrTranType", argsParams[1]);
            dbInteraction.AddParameter("@StrTranRefCode", argsParams[2]);
            dbInteraction.AddParameter("@StrUserIdP", argsParams[3]);
            dbInteraction.AddParameter("@OfficeBankAccount", argsParams[4]);  
            dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdateGenericInvoiceDataB");
        }

        public int AddUpdateInvoiceData(string strDataP, string strTranType, string strTranRefCode, string strUserIdP, string officeBankAccount)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@StrDataP", strDataP);
            dbInteraction.AddParameter("@StrTranType", strTranType);
            dbInteraction.AddParameter("@StrTranRefCode", strTranRefCode);
            dbInteraction.AddParameter("@StrUserIdP", strUserIdP);
            dbInteraction.AddParameter("@OfficeBankAccount", officeBankAccount);  
            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdateGenericInvoiceDataB");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }


        public int UPDATEAC_PaymentM(string strTranRefCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                dbInteraction.AddParameter("@IsSubmitted", "N");
                dbInteraction.AddParameter("@PaymentNo", strTranRefCode);
                //dbInteraction.ExecuteNonQuery(CommandType.Text, "UPDATE AC_PaymentM set IsSubmitted = 'N' where PaymentNo =  @RefCode");
                int retval = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdatePaymentM");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return retval;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public SqlDataReader funBatchPost(int strSearchType, string strSearchString, string frmName)
        {
            //dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                dbInteraction.AddParameter("@SearchType", strSearchType);

                if (frmName == "BankPayment.aspx" || frmName == "Payment.aspx" || frmName == "~P")
                {
                    dbInteraction.AddParameter("@SearchString", strSearchString + "~P");
                }
                else if (frmName == "JournalsNew.aspx" || frmName == "~J")
                {
                    dbInteraction.AddParameter("@SearchString", strSearchString + "~J");
                }
                else if (frmName == "NonTradeCreditNote.aspx" || frmName == "~C")
                {
                    dbInteraction.AddParameter("@SearchString", strSearchString + "~C");
                }
               
                SqlDataReader dr = dbInteraction.getDataReader("AC_UpdateBatchPost");
               // dr.Close();
               // dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dr;

                
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }


        //public void SaveBankPaymentDetails(clsBankPayment objclsBankPayment, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@PaymentNo", objclsBankPayment.PaymentNo);
        //    dbInteraction.AddParameter("@PaymentDate", objclsBankPayment.PaymentDate);
        //    dbInteraction.AddParameter("@PaymentTypeCode", objclsBankPayment.PaymentTypeCode);
        //    dbInteraction.AddParameter("@ClientCode", objclsBankPayment.ClientCode);
        //    dbInteraction.AddParameter("@ClientName", objclsBankPayment.ClientName);
        //    dbInteraction.AddParameter("@ClientAdd1", objclsBankPayment.ClientAdd1);
        //    dbInteraction.AddParameter("@ClientAdd2", objclsBankPayment.ClientAdd2);
        //    dbInteraction.AddParameter("@ClientAdd3", objclsBankPayment.ClientAdd3);
        //    dbInteraction.AddParameter("@ClientAdd4", objclsBankPayment.ClientAdd4);
        //    dbInteraction.AddParameter("@LocalAmount", objclsBankPayment.LocalAmount);
        //    dbInteraction.AddParameter("@StmtDesc", objclsBankPayment.StmtDesc);
        //    dbInteraction.AddParameter("@RecptDesc", objclsBankPayment.RecptDesc);
        //    dbInteraction.AddParameter("@UserId", objclsBankPayment.UserId);
        //    dbInteraction.AddParameter("@PaymentSource", objclsBankPayment.PaymentSource);
        //    dbInteraction.AddParameter("@AccMonth", objclsBankPayment.AccMonth);
        //    dbInteraction.executeNonQuery("AC_AddUpdatePayment", objAuditLog_HeaderMaster, IsAuditRequired);
        //}
        public string fstrGetSafeString(string pStringValue, int pStringLength)
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            return dbInteraction.fstrGetSafeString(pStringValue, pStringLength);
        }

        //public SqlDataReader AddUpdateBankTranForPayment(ArrayList argsParams)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@TranNo", argsParams[0]);
        //    dbInteraction.AddParameter("@PaymentNo", argsParams[1]);
        //    dbInteraction.AddParameter("@BankCode", argsParams[2]);
        //    dbInteraction.AddParameter("@ChequeNo", argsParams[3]);
        //    dbInteraction.AddParameter("@ChequeDate", argsParams[4]);
        //    dbInteraction.AddParameter("@Amount", argsParams[5]);
        //    dbInteraction.AddParameter("@CurrencyCode", argsParams[6]);
        //    dbInteraction.AddParameter("@ExchangeRate", argsParams[7]);
        //    dbInteraction.AddParameter("@LocalAmount", argsParams[8]);
        //    dbInteraction.AddParameter("@UserId", argsParams[9]);

        //    return dbInteraction.getDataReader("AC_AddUpdateBankTranForPayment");
        //}


        //public DataSet GetGenericMatchData(ArrayList argsParam)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

        //    dbInteraction.AddParameter("@TranType", argsParam[0]);
        //    dbInteraction.AddParameter("@IsMatched", argsParam[1]);
        //    dbInteraction.AddParameter("@MatchTranType", argsParam[2]);
        //    dbInteraction.AddParameter("@MatchTranCode", argsParam[3]);
        //    dbInteraction.AddParameter("@StrRecptNo", argsParam[4]);
        //    dbInteraction.AddParameter("@IsMatchReset", argsParam[5]);
        //    dbInteraction.AddParameter("@SearchCriteria", argsParam[6]);
        //    dbInteraction.AddParameter("@SoryOn", argsParam[7]);
        //    dbInteraction.AddParameter("@SoryBy", argsParam[8]);

        //    string[] tbleName = { "EB_AC_GetGenericMatchData" };
        //    return dbInteraction.GetDataset("AC_GetGenericMatchData", tbleName);
        //}

        //public void AddUpdatePettyCashTranForPayment(string strDataP, string strTranType, string strTranRefCode, string strUserIdP)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@StrDataP", strDataP);
        //    dbInteraction.AddParameter("@StrTranType", strTranType);
        //    dbInteraction.AddParameter("@StrTranRefCode", strTranRefCode);
        //    dbInteraction.AddParameter("@StrUserIdP", strUserIdP);
        //    dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdateGenericInvoiceDataB");
        //}

        //public void funDeleteBankPayment(string TranNo, string PaymentNo)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@TranNo", TranNo);
        //    dbInteraction.AddParameter("@PaymentNo", PaymentNo);
        //    dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_DeleteBankPayment");
        //}

        //public void funUpdateRecptStatus(string PaymentNo, string TranType)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@PaymentNo", PaymentNo);
        //    dbInteraction.AddParameter("@TranType", TranType);
        //    dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdPaymentStatus");
        //}

        //public void funUpdateUnMatchedAmount(string StrRefType, string StrRefCode)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@StrRefType", StrRefType);
        //    dbInteraction.AddParameter("@StrRefCode", StrRefCode);
        //    dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdateUnMatchedAmount");
        //}

        public DataTable funAddUpdateNonTradeForPayment(clsNonTradeForPayment objclsNonTradeForPayment, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", objclsNonTradeForPayment.TranNo);
            dbInteraction.AddParameter("@PaymentNo", objclsNonTradeForPayment.PaymentNo);
            dbInteraction.AddParameter("@GLCode", objclsNonTradeForPayment.GLCode);
            dbInteraction.AddParameter("@DBAmountP", objclsNonTradeForPayment.DBAmountP);

            dbInteraction.AddParameter("@DBGSTAmount", objclsNonTradeForPayment.DBGSTAmount);
            dbInteraction.AddParameter("@DBAmount", objclsNonTradeForPayment.DBAmount);
            dbInteraction.AddParameter("@CRAmountP", objclsNonTradeForPayment.CRAmountP);
            dbInteraction.AddParameter("@CRGSTAmount", objclsNonTradeForPayment.CRGSTAmount);

            dbInteraction.AddParameter("@CRAmount", objclsNonTradeForPayment.CRAmount);
            dbInteraction.AddParameter("@DebitAmtPFC", objclsNonTradeForPayment.DebitAmtPFC);
            dbInteraction.AddParameter("@CreditAmtPFC", objclsNonTradeForPayment.CreditAmtPFC);
            dbInteraction.AddParameter("@CurrencyCode", objclsNonTradeForPayment.CurrencyCode);

            dbInteraction.AddParameter("@ExchangeRate", objclsNonTradeForPayment.ExchangeRate);
            dbInteraction.AddParameter("@GlTranDesc", objclsNonTradeForPayment.GlTranDesc);
            dbInteraction.AddParameter("@DebitGSTType", objclsNonTradeForPayment.DebitGSTType);
            dbInteraction.AddParameter("@CreditGSTType", objclsNonTradeForPayment.CreditGSTType);

            dbInteraction.AddParameter("@UserId", objclsNonTradeForPayment.UserId);
            dbInteraction.AddParameter("@GSTType", objclsNonTradeForPayment.GSTType);

            dbInteraction.AddParameter("@DBWhtAmt", objclsNonTradeForPayment.DBWhtAmt);
            dbInteraction.AddParameter("@CRWhtAmt", objclsNonTradeForPayment.CRWhtAmt);
            dbInteraction.AddParameter("@DBWhtP", objclsNonTradeForPayment.DBWhtP);
            dbInteraction.AddParameter("@CRWhtP", objclsNonTradeForPayment.CRWhtP);
            dbInteraction.AddParameter("@ProfitCenter", objclsNonTradeForPayment.ProfitCenter);
            dbInteraction.AddParameter("@FundCode", objclsNonTradeForPayment.FundCode);

            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_AddUpdateNonTradeForPayment", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }


        //public void funDeleteNonTradeGlEntryB(string GLCode, string PaymentNo)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@GLCode", GLCode);
        //    dbInteraction.AddParameter("@PaymentNo", PaymentNo);
        //    dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_DeleteNonTradeGlEntryB");
        //}
        public int funDeleteNonTradeGlEntryB(string GLCode, string PaymentNo)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@GLCode", GLCode);
            dbInteraction.AddParameter("@PaymentNo", PaymentNo);
            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_DeleteNonTradeGlEntryB");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }
        //public void funDeleteNonTradePayment(string TranNo, string PaymentNo)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@TranNo", TranNo);
        //    dbInteraction.AddParameter("@PaymentNo", PaymentNo);
        //    dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_DeleteNonTradePayment");
        //}

        public DataSet GetGLDataForPayments(string PaymentNo, string SortOn, string SortBy)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

            dbInteraction.AddParameter("@PaymentNo", PaymentNo);
            dbInteraction.AddParameter("@SortOn", SortOn);
            dbInteraction.AddParameter("@SortBy", SortBy);

            string[] tbleName = { "EB_AC_GetGLDataForPayments" };
            return dbInteraction.GetDataset("AC_GetGLDataForPayments", tbleName);
        }

        public string getConnectionString()
        {
            return dbInteraction.mstrConnString;
        }


        #endregion

        #region JournalNew

        public SqlDataReader GetJournalDataFromDB(string strTranRefCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@JournalNo", strTranRefCode);
            return dbInteraction.getDataReader("AC_GetJournalData");
        }

        public SqlDataReader getNonTradeDataFromDB_JournalsNew(string strTranRefCode, string strNonTradeTranNo)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@JournalNo", strTranRefCode);
            dbInteraction.AddParameter("@TranNo", strNonTradeTranNo);
            return dbInteraction.getDataReader("AC_GetNonTradeDataFromDB");
            
            //return dbInteraction.getDataReaderNonClose("SELECT GLCode, isNull(DebitAmt,0) as DebitAmt, isNull(CreditAmt,0) as CreditAmt, isNull(DebitAmtP,0) as          DebitAmtP," + " isNull(CreditAmtP,0) as CreditAmtP, DebitGSTAmt,CreditGSTAmt, DebitWHTAmt, CreditWHTAmt,isnull(DebitWHTP,0) as DebitWHTP," + " isnull(CreditWHTP,0) as CreditWHTP, CreditGSTAmt,isnull(DebitAmtPFC,0) as DebitAmtPFC ,isnull(CreditAmtPFC,0) as CreditAmtPFC," + " isnull(ExchangeRate,0) as ExchangeRate,isnull(CurrencyCode,'') as CurrencyCode,isnull(GLTranDesc,'') as GLTranDesc," + " Isnull(DebitGSTType,'') as DebitGSTType,Isnull(CreditGSTType,'') as CreditGSTType,GSTType  FROM AC_JournalN WHERE JournalNo = '" + strTranRefCode.Trim() + "' AND TranNo = '" + strNonTradeTranNo.Trim() + "'");
        }


        //public SqlDataReader GetDropDownData_GetGstM()
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    return dbInteraction.getDataReader("AC_GetGstM");
        //}

        //public SqlDataReader GetDropDownData_GetWHTM()
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    return dbInteraction.getDataReader("AC_GetWHTM");
        //}


        public SqlDataReader GetGLData_JournalsNew(string strTranRefCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@JournalNo", strTranRefCode);
            return dbInteraction.getDataReader("AC_GetGLDataForJournals");
        }
        public SqlDataReader GetGLData_JournalsNewJDP(string strTranRefCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@JournalNo", strTranRefCode);
            return dbInteraction.getDataReader("AC_GetGLDataForJournalsJDP");
        }

        public int funUpdateRecptCashFlow(string mstrTranRefCode, string pstrTranType)
        {            
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@PaymentNo", mstrTranRefCode);
            dbInteraction.AddParameter("@CashFlowType", pstrTranType);
            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdJournalCashFlow");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public SqlDataReader GetReverse_Ref_No(string strReceiptNo, int intUserId)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
            dbInteraction.AddParameter("@UserId", intUserId);
            return dbInteraction.getDataReader("AC_Reverse_Ref_No");
        }

        //public void UPDATE_AC_JournalM(string strTranRefCode)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.Text);
        //    dbInteraction.AddParameter("@RefCode", strTranRefCode);
        //    dbInteraction.executeNonQuery("UPDATE AC_JournalM set IsSubmitted = 'N' where JournalNo =" + strTranRefCode + "");
        //}


        public object GetTaxRateFromGSTTM(string strgstCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);

            return dbInteraction.ExecuteScalar("SELECT coalesce(GSTValue,'0') as TaxRate FROM ac_gstm WHERE gstcode = " + strgstCode);
        }

        public object GetTaxRateFromWHTTM(string strWHTCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);

            return dbInteraction.ExecuteScalar("SELECT coalesce(GSTValue,0) as TaxRate FROM ac_whttm WHERE gstcode = " + strWHTCode);
        }

        public int funUpdateJournalStatus(string JournalNo, string TranType)
        {
           
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@JournalNo", JournalNo);
            dbInteraction.AddParameter("@TranType", TranType);
            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdJournalStatus");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }


        public int funDeleteNonTradeJournal(string TranNo, string JournalNo)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", TranNo);
            dbInteraction.AddParameter("@JournalNo", JournalNo);
            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_DeleteNonTradeJournal");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
           
        }

        public DataSet GetGLDataForJournals(string JournalNo, string SortOn, string SortBy)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

            dbInteraction.AddParameter("@JournalNo", JournalNo);
            dbInteraction.AddParameter("@SortOn", SortOn);
            dbInteraction.AddParameter("@SortBy", SortBy);

            string[] tbleName = { "EB_AC_GetGLDataForJournals" };
            return dbInteraction.GetDataset("AC_GetGLDataForJournals", tbleName);
        }

        public DataSet GetGLDataForJournalsJDP(string JournalNo, string SortOn, string SortBy)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

            dbInteraction.AddParameter("@JournalNo", JournalNo);
            dbInteraction.AddParameter("@SortOn", SortOn);
            dbInteraction.AddParameter("@SortBy", SortBy);

            string[] tbleName = { "EB_AC_GetGLDataForJournalsJDP" };
            return dbInteraction.GetDataset("AC_GetGLDataForJournalsJDP", tbleName);
        }


        //public void funUpdateGenericInvoiceData(ArrayList argsParam)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@StrDataP", argsParam[0]);
        //    dbInteraction.AddParameter("@StrTranType", argsParam[1]);
        //    dbInteraction.AddParameter("@StrTranRefCode", argsParam[2]);
        //    dbInteraction.AddParameter("@StrUserIdP", argsParam[3]);
        //    dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdateGenericInvoiceData");
        //}


        //public SqlDataReader funGnericGLAndMatchTotals(string pstrTranType, string mstrTranRefCode)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@TranType", pstrTranType);
        //    dbInteraction.AddParameter("@TranCode", mstrTranRefCode);
        //    return dbInteraction.getDataReader("AC_GetGnericGLAndMatchTotals");
        //}

        //public SqlDataReader funSave_Reverse_Journal(string ReceiptNo, int UserId)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@ReceiptNo", ReceiptNo);
        //    dbInteraction.AddParameter("@UserId", UserId);
        //    return dbInteraction.getDataReader("AC_Save_Reverse_Journal");
        //}


        public DataSet funSave_Reverse_Journal(string strReceiptNo, int intUserid)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
            dbInteraction.AddParameter("@UserId", intUserid);

            try
            {
                string[] tableName = { "AC_JournalM" };
                DataSet ds = dbInteraction.GetDataset("AC_Save_Reverse_Journal", tableName);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public DataTable GetAccountMonth(string Type)
        {
            dynamic myObject = new ExpandoObject();
            myObject.Type = Type;
            return this.GetAccountMonth(myObject);
            //dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            //dbInteraction.AddParameter("@Type", Type);
            //string[] tbleName = { "EB_AC_getAccountmonth" };
            //return dbInteraction.GetDataset("Ac_getAccountmonth", tbleName);
        }


        public DataTable funSaveJournalDetails(clsDirectInsurerPayment objDirectInsurerPayment, AuditLog_HeaderMaster objAuditLogHeader, bool isAuditRequired, bool var)
        {
            DataTable dt;
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@JournalNo", objDirectInsurerPayment.JournalNo);
            dbInteraction.AddParameter("@JournalDate", objDirectInsurerPayment.JournalDate);
            dbInteraction.AddParameter("@JournalTypeCode", objDirectInsurerPayment.JournalTypeCode);
            dbInteraction.AddParameter("@ClientCode", objDirectInsurerPayment.ClientCode);
            dbInteraction.AddParameter("@ClientName", objDirectInsurerPayment.ClientName);
            dbInteraction.AddParameter("@ClientAdd1", objDirectInsurerPayment.ClientAdd1);
            dbInteraction.AddParameter("@ClientAdd2", objDirectInsurerPayment.ClientAdd2);
            dbInteraction.AddParameter("@ClientAdd3", objDirectInsurerPayment.ClientAdd3);
            dbInteraction.AddParameter("@ClientAdd4", objDirectInsurerPayment.ClientAdd4);
            dbInteraction.AddParameter("@LocalAmount", objDirectInsurerPayment.LocalAmount);
            dbInteraction.AddParameter("@StmtDesc", objDirectInsurerPayment.StmtDesc);
            dbInteraction.AddParameter("@JournalDesc", objDirectInsurerPayment.JournalDesc);
            dbInteraction.AddParameter("@UserId", objDirectInsurerPayment.UserId);
            dbInteraction.AddParameter("@JournalSource", objDirectInsurerPayment.JournalSource);
            dbInteraction.AddParameter("@JournalInsurerDate", objDirectInsurerPayment.JournalInsurerDate);
            dbInteraction.AddParameter("@InsurerAmount", objDirectInsurerPayment.InsurerAmount);
            dbInteraction.AddParameter("@InsurerCurrency", objDirectInsurerPayment.InsurerCurrency);
            dbInteraction.AddParameter("@InsurerBankName", objDirectInsurerPayment.InsurerBankName);
            dbInteraction.AddParameter("@InsurerTypeCode", objDirectInsurerPayment.InsurerTypeCode);
            dbInteraction.AddParameter("@InsurerCode", objDirectInsurerPayment.InsurerCode);
            dbInteraction.AddParameter("@InsurerName", objDirectInsurerPayment.InsurerName);
            dbInteraction.AddParameter("@IsPayment", objDirectInsurerPayment.IsPayment);
            dbInteraction.AddParameter("@AccMonth", objDirectInsurerPayment.AccMonth);

            if (var == true)
            {
                dt = dbInteraction.getDataReader("AC_AddUpdateJournalfinal", objAuditLogHeader, isAuditRequired);
                //dynamic mparams = new ExpandoObject();
                //mparams.PaymentNo = objPayment.PaymentNo;
                //mparams.TranType = "Payment";
                //objAccountBAL.UpdPaymentStatus(mparams, objAuditLog_HeaderMaster, true);
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["Result"].ToString().Contains("JVR"))
                {
                    objDirectInsurerPayment.JournalNo = dt.Rows[0]["Result"].ToString();
                    funUpdateJournalStatus(objDirectInsurerPayment.JournalNo, "Y");
                }
            }
            else
            {
                dt = dbInteraction.getDataReader("AC_AddUpdateJournal", objAuditLogHeader, isAuditRequired);
            }
            return dt ;
        }     

        public SqlDataReader funUpdateNonTradeJournals(dynamic mObject)
       {
           dynamic objAddUpdateNonTradeForJournal = (ExpandoObject)(mObject);

           dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
           dbInteraction.AddParameter("@TranNo", objAddUpdateNonTradeForJournal.TranNo);
           dbInteraction.AddParameter("@JournalNo", objAddUpdateNonTradeForJournal.JournalNo);
           dbInteraction.AddParameter("@GLCode", objAddUpdateNonTradeForJournal.GLCode);
           dbInteraction.AddParameter("@DBAmountP", objAddUpdateNonTradeForJournal.DBAmountP);
           dbInteraction.AddParameter("@DBGSTAmount", objAddUpdateNonTradeForJournal.DBGSTAmount);
           dbInteraction.AddParameter("@DBAmount", objAddUpdateNonTradeForJournal.DBAmount);
           dbInteraction.AddParameter("@CRAmountP", objAddUpdateNonTradeForJournal.CRAmountP);
           dbInteraction.AddParameter("@CRGSTAmount", objAddUpdateNonTradeForJournal.CRGSTAmount);
           dbInteraction.AddParameter("@CRAmount", objAddUpdateNonTradeForJournal.CRAmount);
           dbInteraction.AddParameter("@DebitAmtPFC", objAddUpdateNonTradeForJournal.DebitAmtPFC);
           dbInteraction.AddParameter("@CreditAmtPFC", objAddUpdateNonTradeForJournal.CreditAmtPFC);
           dbInteraction.AddParameter("@CurrencyCode", objAddUpdateNonTradeForJournal.CurrencyCode);
           dbInteraction.AddParameter("@ExchangeRate", objAddUpdateNonTradeForJournal.ExchangeRate);
           dbInteraction.AddParameter("@GlTranDesc", objAddUpdateNonTradeForJournal.GlTranDesc);

           dbInteraction.AddParameter("@DebitGSTType", objAddUpdateNonTradeForJournal.DebitGSTType);

           dbInteraction.AddParameter("@CreditGSTType", objAddUpdateNonTradeForJournal.CreditGSTType);

           dbInteraction.AddParameter("@UserId", objAddUpdateNonTradeForJournal.UserId);

           dbInteraction.AddParameter("@GSTType", objAddUpdateNonTradeForJournal.GSTType);

           dbInteraction.AddParameter("@DBWhtAmt", objAddUpdateNonTradeForJournal.DBWhtAmt);

           dbInteraction.AddParameter("@CRWhtAmt", objAddUpdateNonTradeForJournal.CRWhtAmt);

           dbInteraction.AddParameter("@DBWhtP", objAddUpdateNonTradeForJournal.DBWhtP);
           dbInteraction.AddParameter("@CRWhtP", objAddUpdateNonTradeForJournal.CRWhtP);
           dbInteraction.AddParameter("@ProfitCenter", objAddUpdateNonTradeForJournal.ProfitCenter);
           dbInteraction.AddParameter("@FundCode", objAddUpdateNonTradeForJournal.FundCode);

           return dbInteraction.getDataReader("AC_AddUpdateNonTradeForJournal");

       }
        //public DataSet GetGLDataForPayments(string PaymentNo, string SortOn, string SortBy)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

        //    dbInteraction.AddParameter("@PaymentNo", PaymentNo);
        //    dbInteraction.AddParameter("@SortOn", SortOn);
        //    dbInteraction.AddParameter("@SortBy", SortBy);

        //    string[] tbleName = { "EB_AC_GetGLDataForPayments" };
        //    return dbInteraction.GetDataset("AC_GetGLDataForPayments", tbleName);
        //}
        #endregion

        #region Payment

        public object GetTaxRateFromWHTM(string strWHTMCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);

            return dbInteraction.ExecuteScalar("SELECT coalesce(GSTValue,0) as TaxRate FROM ac_WHTM WHERE gstcode = " + strWHTMCode);
        }
        // Begin Redmine#31849
        public DataSet GetPaymentType()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.NO, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                string[] tbleName = { "AC_PaymentTypeCodes" };
                return dbInteraction.GetDataset("AC_GetPayementType", tbleName);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DataSet GetOperatingBankCodes(string strPaymentType, string BankAccCategory)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            return dbInteraction.GetDataset("AC_GetOperatingBankCodes '" + strPaymentType + "','" + BankAccCategory + "'");
        }
        // End Redmine#31849

       /* public void SavePaymentDetails(clsPayment objclsPayment, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@PaymentNo", objclsPayment.PaymentNo);
            dbInteraction.AddParameter("@PaymentDate", objclsPayment.PaymentDate);
            dbInteraction.AddParameter("@PaymentTypeCode", objclsPayment.PaymentTypeCode);
            dbInteraction.AddParameter("@ClientCode", objclsPayment.ClientCode);
            dbInteraction.AddParameter("@ClientName", objclsPayment.ClientName);
            dbInteraction.AddParameter("@ClientAdd1", objclsPayment.ClientAdd1);
            dbInteraction.AddParameter("@ClientAdd2", objclsPayment.ClientAdd2);
            dbInteraction.AddParameter("@ClientAdd3", objclsPayment.ClientAdd3);
            dbInteraction.AddParameter("@ClientAdd4", objclsPayment.ClientAdd4);
            dbInteraction.AddParameter("@LocalAmount", objclsPayment.LocalAmount);
            dbInteraction.AddParameter("@StmtDesc", objclsPayment.StmtDesc);
            dbInteraction.AddParameter("@RecptDesc", objclsPayment.RecptDesc);
            dbInteraction.AddParameter("@UserId", objclsPayment.UserId);
            dbInteraction.AddParameter("@PaymentSource", objclsPayment.PaymentSource);
            dbInteraction.AddParameter("@AccMonth", objclsPayment.AccMonth);
            dbInteraction.executeNonQuery("AC_AddUpdatePayment", objAuditLog_HeaderMaster, IsAuditRequired);
        }
        */
        //public void funAddUpdatePettyCashTranForPayment(ArrayList argsParam)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@StrDataP", argsParam[0]);
        //    dbInteraction.AddParameter("@StrTranType", argsParam[1]);
        //    dbInteraction.AddParameter("@StrTranRefCode", argsParam[2]);
        //    dbInteraction.AddParameter("@StrUserIdP", argsParam[3]);
        //    dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdateGenericInvoiceData");
        //}

        //public SqlDataReader Save_Reverse_Payment(string strReceiptNo, int intUserId)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
        //    dbInteraction.AddParameter("@UserId", intUserId);
        //    return dbInteraction.getDataReader("AC_Save_Reverse_Payment");
        //}


        #endregion

        #region "CompanyDetails"
        public DataSet GetBankAccount(string Category)
        {
             
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

            dbInteraction.AddParameter("@BankAccCat", Category);
            
            string[] tbleName = { "AC_GetBankAccount" };
            return dbInteraction.GetDataset("AC_GetBankAccount", tbleName);
        }
        

        public SqlDataReader GetGLData(string valuepair, int compId, int UserId)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@lstrString", valuepair);
            dbInteraction.AddParameter("@pCompanyId", compId);
            dbInteraction.AddParameter("@UserId", UserId);
            return dbInteraction.getDataReader("AC_TempSplitExample");
        }
        public DataSet GetTimeStampGLCode()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.NO, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                string[] tbleName = { "AC_CompanyGLCodes" };
                return dbInteraction.GetDataset("AC_TimeStampForGLCode", tbleName);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public SqlDataReader GetCompanyDetails(int compId)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@pCompanyID", compId);
            return dbInteraction.getDataReader("AC_GetCompanyDetails");
        }
        public DataSet UpdateCompanyDetails(clsCompanyDetails objCompanyDetails)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                dbInteraction.AddParameter("@pCompanyCode", objCompanyDetails.CompanyCode);
                dbInteraction.AddParameter("@pCompanyName", objCompanyDetails.CompanyName);
                dbInteraction.AddParameter("@pCompanyAdd1", objCompanyDetails.CompanyAdd1);
                dbInteraction.AddParameter("@pCompanyAdd2", objCompanyDetails.CompanyAdd2);
                dbInteraction.AddParameter("@pCompanyAdd3", objCompanyDetails.CompanyAdd3);
                dbInteraction.AddParameter("@pCompanyAdd4", objCompanyDetails.CompanyAdd4);
                dbInteraction.AddParameter("@pEMail", objCompanyDetails.EMail);
                dbInteraction.AddParameter("@pCompanyGstCode", objCompanyDetails.CompanyGstCode);
                dbInteraction.AddParameter("@pMonthStart", objCompanyDetails.MonthStart);
                dbInteraction.AddParameter("@pYearStart", objCompanyDetails.YearStart);
                dbInteraction.AddParameter("@pCalMonthStart", objCompanyDetails.CalMonthStart);
                dbInteraction.AddParameter("@pCalYearStart", objCompanyDetails.CalYearStart);
                dbInteraction.AddParameter("@pCompanyUnmatchedAmountLimit", objCompanyDetails.CompanyUnmatchedAmountLimit);
                dbInteraction.AddParameter("@StmtAgDtType", objCompanyDetails.StmtAgDtType);
                dbInteraction.AddParameter("@OperatingBank", objCompanyDetails.OperatingBank);
                dbInteraction.AddParameter("@OfficeBank", objCompanyDetails.OfficeBank);
                dbInteraction.AddParameter("@BusinessRegNo", objCompanyDetails.BusinessRegNo);
                dbInteraction.AddParameter("@UserId", objCompanyDetails.UserId);
                dbInteraction.AddParameter("@LocalCurrencyCode", objCompanyDetails.LocalCurrency);
                dbInteraction.AddParameter("@IsAutoPosting", objCompanyDetails.IsAutoPosting);
                dbInteraction.AddParameter("@RIOperatingBank", objCompanyDetails.RIOperatingBank);
                dbInteraction.AddParameter("@RIOfficeBank", objCompanyDetails.RIOfficeBank);
                dbInteraction.AddParameter("@DefrRecogRule", objCompanyDetails.DeferredRevRule);
                dbInteraction.AddParameter("@GLCode", objCompanyDetails.GLCode);
                string[] tbleName = { "AC_Company" };
                DataSet ds = dbInteraction.GetDataset("AC_UpdCompanyDetails", tbleName);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        // below two method is added by praveen verma, for the company Details Page. on 7 Apr 2017.
        public SqlDataReader InsertGLData(string valuepair, int compId, int UserId,string type)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@lstrString", valuepair);
            dbInteraction.AddParameter("@pCompanyId", compId);
            dbInteraction.AddParameter("@UserId", UserId);
            dbInteraction.AddParameter("@Type", type);            
            return dbInteraction.getDataReader("AC_InsUpdGLCode");
        }

        public DataSet InsertGLDataRI(string valuepair, string type)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            //dbInteraction.AddParameter("@xmlstring", valuepair);
            //dbInteraction.AddParameter("@accountType", type);
            return dbInteraction.GetDataset("Ac_UpdateDrCrCompanyGLCode '" + valuepair + "', '" + type  + "'");
        } 

        public SqlDataReader GetGLCodeDescriptionM(string type)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@DisplayFlag", type);
            return dbInteraction.getDataReader("AC_GetGLCodeDescription");
        }
        // -------------------------------------------------------------------------------------------

        public SqlDataReader GetGLCodeDescription()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            return dbInteraction.getDataReader("AC_GetGLCodeDescription");
        }

        public SqlDataReader GetDropDownData(string strSQL)
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            return dbInteraction.getDataReader(strSQL);
        }
        #endregion

        #region "GSTCodeSetting"
        public DataSet GetTimeStampGST(string GSTTaxCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.NO, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                dbInteraction.AddParameter("@GSTTaxCode", GSTTaxCode);

                string[] tbleName = { "AC_GST" };
                return dbInteraction.GetDataset("AC_TimeStampForGST", tbleName);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateTaxSetting(clsGSTCodeSetting objGSTCodeSetting)
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            string lstrSQLInsertData = "AC_UpdateTaxSetting '" + objGSTCodeSetting.TranNo + "','" + objGSTCodeSetting.TaxObject + "','" + objGSTCodeSetting.RangeFrom + "','" + objGSTCodeSetting.RangeTo + "','" + objGSTCodeSetting.TaxRate + "'";
            dbInteraction.executeScalarQuery(lstrSQLInsertData);
        }
        public DataTable UpdateGSTCode(clsGSTCodeSetting objGSTCodeSetting, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                dbInteraction.AddParameter("@GST_Tax_Code", objGSTCodeSetting.GstTaxCode);
                dbInteraction.AddParameter("@GST_Tax_Code_N", objGSTCodeSetting.GstTaxCodeNew);
                dbInteraction.AddParameter("@GST_Tax_Description", objGSTCodeSetting.GSTDescription);
                dbInteraction.AddParameter("@GST_Type_Code", objGSTCodeSetting.GSTTypeCode);
                dbInteraction.AddParameter("@Updated_By", objGSTCodeSetting.Userid);
                dbInteraction.AddParameter("@Mode", objGSTCodeSetting.AddEditMode);
                dbInteraction.AddParameter("@TaxType", objGSTCodeSetting.TaxType);

                DataTable dt = dbInteraction.getDataReader("AC_UpdateGSTCode", objAuditLog_HeaderMaster, IsAuditRequired);                
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);                
                return dt;

            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }
        public DataSet GetGSTCode(clsGSTCodeSetting objGSTCodeSetting)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

            dbInteraction.AddParameter("@GST_Type_Code", objGSTCodeSetting.GSTTypeCode);
            dbInteraction.AddParameter("@GST_Tax_Code", objGSTCodeSetting.GstTaxCode);
            dbInteraction.AddParameter("@GST_Tax_Description", objGSTCodeSetting.GSTDescription);
            dbInteraction.AddParameter("@TaxType", objGSTCodeSetting.TaxType);
            
            string[] tbleName = { "AC_GST" };
            return dbInteraction.GetDataset("AC_GetGSTCode", tbleName);
        }
        public SqlDataReader GetGSTCode()
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                return dbInteraction.getDataReader("AC_GetGSTCode");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SqlDataReader GetGSTCodeData(clsGSTCodeSetting objGSTCodeSetting)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@GST_Type_Code", objGSTCodeSetting.GSTTypeCode);
                dbInteraction.AddParameter("@GST_Tax_Code", objGSTCodeSetting.GstTaxCode);
                dbInteraction.AddParameter("@GST_Tax_Description", objGSTCodeSetting.GSTDescription);
                dbInteraction.AddParameter("@TaxType", objGSTCodeSetting.TaxType);
                return dbInteraction.getDataReader("AC_GetGSTCode");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Currency
        public DataTable AddCurrencyDetails(clsCurrency objclsCurrency, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@pCurrencyCode", objclsCurrency.CurrencyCode);
            dbInteraction.AddParameter("@pCurrencyDispCode", objclsCurrency.CurrencyDispCode);
            dbInteraction.AddParameter("@pDescription", objclsCurrency.Description);
            dbInteraction.AddParameter("@pUserId", objclsCurrency.UserId);
            dbInteraction.AddParameter("@IsDefault", objclsCurrency.IsDefault);
            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_InsertCurrencyM", objAuditLog_HeaderMaster, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }
        public DataTable UpdateCurrencyDetails(clsCurrency objclsCurrency, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@CurrCode", objclsCurrency.CurrencyCode);
            dbInteraction.AddParameter("@CurrDispCode", objclsCurrency.CurrencyDispCode);
            dbInteraction.AddParameter("@Desc", objclsCurrency.Description);
            dbInteraction.AddParameter("@Userid", objclsCurrency.UserId);
            dbInteraction.AddParameter("@IsDefault", objclsCurrency.IsDefault);
            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_UpdCurrencyMaster", objAuditLog_HeaderMaster, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }


        #endregion

        #region GLClasses
        public DataTable AddUpdateGLClassesDetails(clsGLCLass objclsGLCLass, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@Mode", objclsGLCLass.Mode);
            dbInteraction.AddParameter("@GLClassCode", objclsGLCLass.GLClassCode);
            dbInteraction.AddParameter("@GLTypeCode", objclsGLCLass.GLTypeCode);
            dbInteraction.AddParameter("@GLAccountType", objclsGLCLass.GLAccountType);
            dbInteraction.AddParameter("@Description", objclsGLCLass.Description);
            dbInteraction.AddParameter("@UserId", objclsGLCLass.UserId);
            dbInteraction.AddParameter("@GLClassOrder", objclsGLCLass.GLClassOrder);
            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_UpdGLClassDataAddUpdate", objAuditLog_HeaderMaster, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public SqlDataReader getDataForGLClasses(string strGLClassCode)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@GLClassCode", strGLClassCode);
                return dbInteraction.getDataReader("AC_GetGLClassDataAddUpdate");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetGLClass()
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                return dbInteraction.getDataReader("AC_GetGLClass");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetGLClassForGLType(string strGLTypeCode)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@GLTypeCode", strGLTypeCode);
                return dbInteraction.getDataReader("AC_GetGLClassForGLType");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        #endregion

        #region GLType

        public SqlDataReader GetGLType()
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                return dbInteraction.getDataReader("AC_GetGLTypes");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable AddUpdateGLType(clsGLType objclsGLType, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@Mode", objclsGLType.Mode);
            dbInteraction.AddParameter("@GLTypeCode", objclsGLType.GLTypeCode);
            dbInteraction.AddParameter("@Description", objclsGLType.Description);
            dbInteraction.AddParameter("@UserId", objclsGLType.UserId);
            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_UpdGLTypeDataAddUpdate", objAuditLog_HeaderMaster, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public SqlDataReader getDataForGLType(string strGLTypeCode)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@GLTypeCode", strGLTypeCode);
                return dbInteraction.getDataReader("AC_GetGLTypeDataAddUpdate");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DirectPaymentByClient
        //public DataTable BankDataAddUpdate(clsBankDetail objBankDetail, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        //{
        //    try
        //    {
        //        objDatabaseInteraction = new DatabaseInteraction(CommandType.Text);
        //        string lstrSQLUpdData = "AC_UpdBankDataAddUpdate " + objBankDetail.PageMode + ",N'" + objBankDetail.TranRefCode + "',N'" + objBankDetail.SwiftCode + "',N'" + objBankDetail.BankName + "',N'" + objBankDetail.BankDispName + "',N'" + objBankDetail.BranchName + "',N'" + objBankDetail.BankAdd1 + "',N'" + objBankDetail.BankAdd2 + "',N'" + objBankDetail.BankAdd3 + "',N'" + objBankDetail.ContactPerson + "',N'" + objBankDetail.TelNo + "',N'" + objBankDetail.FaxNo + "',N'" + objBankDetail.EMail + "',N'" + objBankDetail.ACTypeCode + "',N'" + objBankDetail.ACNo + "',N'" + objBankDetail.CurrencyCode + "',N'" + objBankDetail.GLCode + "',N'" + objBankDetail.UserId + "'";
        //        DataTable ldrSQLChkUpdData = objDatabaseInteraction.getDataReader(lstrSQLUpdData, objAuditLogHeader, IsAuditRequired);
        //        return ldrSQLChkUpdData;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex.InnerException;
        //    }
        //}

        public DataTable SaveDirectInsurerPayment(clsDirectInsurerPayment objDirectInsurerPayment, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired, bool var)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

            DataTable dt;
                dbInteraction.AddParameter("@JournalNo", objDirectInsurerPayment.JournalNo);
                dbInteraction.AddParameter("@JournalDate", objDirectInsurerPayment.JournalDate);
                dbInteraction.AddParameter("@JournalTypeCode", objDirectInsurerPayment.JournalTypeCode);
                dbInteraction.AddParameter("@ClientCode", objDirectInsurerPayment.ClientCode);
                dbInteraction.AddParameter("@ClientName", objDirectInsurerPayment.ClientName);
                dbInteraction.AddParameter("@ClientAdd1", objDirectInsurerPayment.ClientAdd1);
                dbInteraction.AddParameter("@ClientAdd2", objDirectInsurerPayment.ClientAdd2);
                dbInteraction.AddParameter("@ClientAdd3", objDirectInsurerPayment.ClientAdd3);
                dbInteraction.AddParameter("@ClientAdd4", objDirectInsurerPayment.ClientAdd4);
                dbInteraction.AddParameter("@LocalAmount", objDirectInsurerPayment.LocalAmount);
                dbInteraction.AddParameter("@StmtDesc", objDirectInsurerPayment.StmtDesc);
                dbInteraction.AddParameter("@JournalDesc", objDirectInsurerPayment.JournalDesc);
                dbInteraction.AddParameter("@UserId", objDirectInsurerPayment.UserId);
                dbInteraction.AddParameter("@JournalSource", objDirectInsurerPayment.JournalSource);
                dbInteraction.AddParameter("@JournalInsurerDate", objDirectInsurerPayment.JournalInsurerDate);
                dbInteraction.AddParameter("@InsurerAmount", objDirectInsurerPayment.InsurerAmount);
                dbInteraction.AddParameter("@InsurerCurrency", objDirectInsurerPayment.InsurerCurrency);
                dbInteraction.AddParameter("@InsurerBankName", objDirectInsurerPayment.InsurerBankName);
                dbInteraction.AddParameter("@InsurerTypeCode", objDirectInsurerPayment.InsurerTypeCode);
                dbInteraction.AddParameter("@InsurerCode", objDirectInsurerPayment.InsurerCode);
                dbInteraction.AddParameter("@InsurerName", objDirectInsurerPayment.InsurerName);
                dbInteraction.AddParameter("@IsPayment", objDirectInsurerPayment.IsPayment);
                dbInteraction.AddParameter("@AccMonth", objDirectInsurerPayment.AccMonth);

            if (var == true)
            {
                dt = dbInteraction.getDataReader("AC_AddUpdateDPC", objAuditLogHeader, IsAuditRequired);
            }
            else
            {
                dt = dbInteraction.getDataReader("AC_AddUpdateJournal", objAuditLogHeader, IsAuditRequired);
            }
            return dt;
           // dbInteraction.executeNonQuery("AC_AddUpdateJournal", objAuditLogHeader, IsAuditRequired);
        }

        #endregion

        #region tax Setting
        public void AddNewTaxSetting(ArrayList argsLst)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@TaxObject", argsLst[0]);
            dbInteraction.AddParameter("@RangeFrom", argsLst[1]);
            dbInteraction.AddParameter("@MatchTranCode", argsLst[2]);
            dbInteraction.AddParameter("@RangeTo", argsLst[3]);
            dbInteraction.AddParameter("@TaxRate", argsLst[4]);
            dbInteraction.AddParameter("@TextType", argsLst[5]);
            dbInteraction.AddParameter("@Userid", argsLst[6]);
            dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_AddTaxSetting");
        }
        public DataTable UpdateGSTRate(Hashtable argsParam, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
                dbInteraction.AddParameter("@ID", argsParam["ID"]);
                dbInteraction.AddParameter("@GST_Tax_Code", argsParam["GST_Tax_Code"]);
                dbInteraction.AddParameter("@GST_Rate_Value", argsParam["GST_Rate_Value"]);
                dbInteraction.AddParameter("@GST_Rate_Effective_From", argsParam["GST_Rate_Effective_From"]);
                dbInteraction.AddParameter("@GST_Rate_Effective_To", argsParam["GST_Rate_Effective_To"]);
                dbInteraction.AddParameter("@Updated_by", argsParam["Updated_by"]);
                dbInteraction.AddParameter("@Mode", argsParam["Mode"]);
                dbInteraction.AddParameter("@TaxType", argsParam["TaxType"]);
                DataTable dt = dbInteraction.getDataReader("AC_UpdateGSTRate", objAuditLog_HeaderMaster, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public SqlDataReader GetGSTRate(Hashtable argsParam)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@GST_Type_Code", argsParam["GST_Type_Code"]);
                dbInteraction.AddParameter("@GST_Tax_Code", argsParam["GST_Tax_Code"]);
                dbInteraction.AddParameter("@GST_Tax_Description", argsParam["GST_Tax_Description"]);
                dbInteraction.AddParameter("@GST_Rate_Effective_From", argsParam["GST_Rate_Effective_From"]);
                dbInteraction.AddParameter("@GST_Rate_Effective_To", argsParam["GST_Rate_Effective_To"]);
                dbInteraction.AddParameter("@GST_Rate_Value", argsParam["GST_Rate_Value"]);

                return dbInteraction.getDataReader("AC_GetGSTRate");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetGSTRate(clsGSTCodeSetting objGSTRateSetting)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@GST_Type_Code", objGSTRateSetting.GSTTypeCode);
            dbInteraction.AddParameter("@GST_Tax_Code", objGSTRateSetting.GstTaxCode);
            dbInteraction.AddParameter("@GST_Tax_Description", objGSTRateSetting.GSTDescription);
            dbInteraction.AddParameter("@GST_Rate_Effective_From", objGSTRateSetting.RangeFrom);
            dbInteraction.AddParameter("@GST_Rate_Effective_To", objGSTRateSetting.RangeTo);
            dbInteraction.AddParameter("@GST_Rate_Value", objGSTRateSetting.GSTRateValue);
            dbInteraction.AddParameter("@TaxType", objGSTRateSetting.TaxType);

            string[] tbleName = { "AC_GSTRate" };
            return dbInteraction.GetDataset("AC_GetGSTRate", tbleName);
        }
        public SqlDataReader GetGSTType()
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);                
                return dbInteraction.getDataReader("Ac_GetGSTType");
            }
            catch (Exception ex)
            {
                throw ex;
            }     
        }

        public DataSet GetTimeStamp(string GSTRateId)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@Id", GSTRateId);
            return dbInteraction.GetDataset("sp_GetTimeStamp",null);
        }

        #endregion

        #region GLCategory


        public DataTable AddUpdateGLCategory(clsGLCategory objclsGLCategory, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@Mode", objclsGLCategory.Mode);
            dbInteraction.AddParameter("@GLCategoryCode", objclsGLCategory.GLCategoryCode);
            dbInteraction.AddParameter("@GLClassCode", objclsGLCategory.GLClassCode);
            dbInteraction.AddParameter("@Description", objclsGLCategory.Description);
            dbInteraction.AddParameter("@UserId", objclsGLCategory.UserId);
            dbInteraction.AddParameter("@GLparentId", objclsGLCategory.GLparentId);
            dbInteraction.AddParameter("@SubCategory", objclsGLCategory.SubCategory);
            try
            {
                DataTable dt= dbInteraction.getDataReader("AC_UpdGLCategoryDataAddUpdate", objAuditLog_HeaderMaster, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }



        }

        public SqlDataReader getDataForGLCategory(string strGLCategoryCode)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@GLCategoryCode", strGLCategoryCode);
                return dbInteraction.getDataReader("AC_GetGLCategoryDataAddUpdate");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public SqlDataReader GetGLSubCategory(string strGLParentid)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@GLParentId", strGLParentid);
                return dbInteraction.getDataReader("AC_GetGLSubCategory");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SqlDataReader GetGLCategoryForGLClass(string strGLClassCode)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@GLClassCode", strGLClassCode);
                return dbInteraction.getDataReader("AC_GetGLCategoryForGLClass");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        #endregion
        #region New Currency Transaction
        public DataTable GetCurrencies()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return this.GetDataTable(dbInteraction.getDataReader("AC_GetCurrencies"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable InsertCurrencyTransaction(Hashtable argsParam, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            //dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                dbInteraction.AddParameter("@pCurrencyCode", argsParam["CurrencyCode"]);
                dbInteraction.AddParameter("@pEffDate", argsParam["EffDate"]);
                dbInteraction.AddParameter("@pExchangeRate", argsParam["ExchangeRate"]);
                dbInteraction.AddParameter("@pUserId", argsParam["UserId"]);
                
                //DataTable dt = dbInteraction.getDataReader("AC_InsCurrencyTransaction");
                //dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                //return dt;
                return this.GetDataTable(dbInteraction.getDataReader("AC_InsCurrencyTransaction"));
             
            }
            catch (Exception ex)
            {
                //dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }


      

        #endregion

        #region Add Edit PWC
        public DataTable GetPWCRLTypes()
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                return this.GetDataTable(dbInteraction.getDataReader("AC_GetPWCRLTypes"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPWCClasses()
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                return this.GetDataTable(dbInteraction.getDataReader("AC_GetPWCClasses"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetPWCList(int mintId)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@mintId", mintId);
                return dbInteraction.getDataReader("AC_GetPWCList");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public DataTable AddUpdatePWC(Hashtable argsParam, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
                dbInteraction.AddParameter("@Id", argsParam["Id"]);
                dbInteraction.AddParameter("@ClassId", argsParam["ClassId"]);
                dbInteraction.AddParameter("@RLTypeId", argsParam["RLTypeId"]);
                dbInteraction.AddParameter("@Days", argsParam["Days"]);
                dbInteraction.AddParameter("@UserId", argsParam["UserId"]);
                DataTable dt = dbInteraction.getDataReader("AC_AddUpdatePWC", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public DataTable DeletePWCData(int mintId, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            //dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
                dbInteraction.AddParameter("@Id", mintId);
                DataTable dt = dbInteraction.getDataReader("AC_DeletePWCData", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }
        #endregion

        #region GL Accounts
        public DataTable UpdateGLACCData(dynamic mObject, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
           dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@Mode", mObject.Mode);
            dbInteraction.AddParameter("@GLCode", mObject.GLCode);
            dbInteraction.AddParameter("@Description", mObject.Description);
            dbInteraction.AddParameter("@GLTypeCode", mObject.GLTypeCode);
            dbInteraction.AddParameter("@GLClassCode", mObject.GLClassCode);
            dbInteraction.AddParameter("@GLCategoryCode", mObject.GLCategoryCode);
            dbInteraction.AddParameter("@UserId", mObject.UserId);
            dbInteraction.AddParameter("@IsPosting", mObject.IsPosting);
            dbInteraction.AddParameter("@GLBalanceType", mObject.GLBalanceType);
            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_UpdGLDataAddUpdate", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public SqlDataReader GetGLTypes()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return dbInteraction.getDataReader("AC_GetGLTypes");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        #endregion

        #region ClientRegistration

        public DataTable AddUpdateClientRegistration(clsNonTradeCustomer objclsNonTradeCustomer, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@PageMode", objclsNonTradeCustomer.PageMode);
            dbInteraction.AddParameter("@CusM_ID", objclsNonTradeCustomer.CusM_ID);
            dbInteraction.AddParameter("@CusM_Name1", objclsNonTradeCustomer.CusM_Name1);
            dbInteraction.AddParameter("@CusM_DispName", objclsNonTradeCustomer.CusM_DispName);
            dbInteraction.AddParameter("@CusM_Country", objclsNonTradeCustomer.CusM_Country);
            dbInteraction.AddParameter("@CusM_PostalCode", objclsNonTradeCustomer.CusM_PostalCode);
            dbInteraction.AddParameter("@CusM_ContactTelOffice", objclsNonTradeCustomer.CusM_ContactTelOffice);
            dbInteraction.AddParameter("@CusM_ContactTelHome", objclsNonTradeCustomer.CusM_ContactTelHome);
            dbInteraction.AddParameter("@CusM_ContactPager", objclsNonTradeCustomer.CusM_ContactPager);
            dbInteraction.AddParameter("@CusM_ContactHP ", objclsNonTradeCustomer.CusM_ContactHP);
            dbInteraction.AddParameter("@CusM_ContactPerson", objclsNonTradeCustomer.CusM_ContactPerson);
            dbInteraction.AddParameter("@CusM_Fax", objclsNonTradeCustomer.CusM_Fax);
            dbInteraction.AddParameter("@CusM_ContactEmail", objclsNonTradeCustomer.CusM_ContactEmail);
            dbInteraction.AddParameter("@CusM_Remarks", objclsNonTradeCustomer.CusM_Remarks);
            dbInteraction.AddParameter("@CusM_Address1", objclsNonTradeCustomer.CusM_Address1);
            dbInteraction.AddParameter("@CusM_Address2", objclsNonTradeCustomer.CusM_Address2);
            dbInteraction.AddParameter("@CusM_Address3 ", objclsNonTradeCustomer.CusM_Address3);
            dbInteraction.AddParameter("@CusM_Address4", objclsNonTradeCustomer.CusM_Address4);
            dbInteraction.AddParameter("@Credit_Limit", objclsNonTradeCustomer.Credit_Limit);
            dbInteraction.AddParameter("@GLCode", objclsNonTradeCustomer.GLCode);
            dbInteraction.AddParameter("@GSTRegistrationNo", objclsNonTradeCustomer.GSTRegistrationNo);
            dbInteraction.AddParameter("@SelfBilling", objclsNonTradeCustomer.SelfBilling);
            dbInteraction.AddParameter("@RMCDApprovalNo", objclsNonTradeCustomer.RMCDApprovalNo);
            dbInteraction.AddParameter("@EffectiveFromDate ", objclsNonTradeCustomer.EffectiveFromDate);
            dbInteraction.AddParameter("@EffectiveToDate", objclsNonTradeCustomer.EffectiveToDate);
            dbInteraction.AddParameter("@UserId", objclsNonTradeCustomer.UserId);
            dbInteraction.AddParameter("@ProfitCentre", objclsNonTradeCustomer.ProfitCentre);
            dbInteraction.AddParameter("@FundCode", objclsNonTradeCustomer.FundCode);
            dbInteraction.AddParameter("@Branch", objclsNonTradeCustomer.Branch);
            dbInteraction.AddParameter("@Region", objclsNonTradeCustomer.Region);
            dbInteraction.AddParameter("@CorporateGroup", objclsNonTradeCustomer.CorporateGroup);
            dbInteraction.AddParameter("@PreviousCode", objclsNonTradeCustomer.PreviousCode);
            dbInteraction.AddParameter("@IsActive", objclsNonTradeCustomer.IsActive);
            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_AddUpdateClientRegistration", objAuditLog_HeaderMaster, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public SqlDataReader GenrateCaseRefNo(string strRefNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@pstrRefer", strRefNo);
                return dbInteraction.getDataReader("sp_gen_case_ref_no");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DeleteNonTradeClientDetails(string strCusM_Id)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@CusM_Id", strCusM_Id);
            try
            {
                string[] tablename={"AC_NonTradeClientDetails"};
                DataSet ds = dbInteraction.GetDataset("AC_DelNonTradeClientDetails", tablename);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public SqlDataReader GetNonTradeCustomerForId(string strCusM_ID)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@CusM_ID", strCusM_ID);
                return dbInteraction.getDataReader("AC_GetNonTradeCustomerForId");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region BatchPost
        //public DataTable UpdateBatchPost(int intTranType, string strTransList)
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);

        //    dbInteraction.AddParameter("@SearchType", intTranType);
        //    dbInteraction.AddParameter("@SearchString", strTransList);
        //    try
        //    {
        //        SqlDataReader dr = dbInteraction.getDataReader("AC_UpdateBatchPost");
        //        DataTable dt = new DataTable();
        //        dt.Load(dr);
        //        dr.Close();
        //        dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {              
        //       dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
        //        throw ex;
        //    }
        //}
        public DataSet GetGenericSearchDataForBatchPost(clsBatchPost objBatchPost)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                dbInteraction.AddParameter("@AccountType", objBatchPost.TranType);
                dbInteraction.AddParameter("@TranRefNo", objBatchPost.TranRefNo);
                dbInteraction.AddParameter("@TranRefType", objBatchPost.AccountType);
                dbInteraction.AddParameter("@TranRefName", objBatchPost.ClientName);
                dbInteraction.AddParameter("@FromDate", objBatchPost.FromDate);
                dbInteraction.AddParameter("@ToDate", objBatchPost.ToDate);

                string[] tbleName = { "AC_Users" };
                return dbInteraction.GetDataset("AC_GetGenericSearchDataForBatchPost", tbleName);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DataSet GetGenericSearchDataForBatchUnPost(clsBatchPost objBatchPost)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                dbInteraction.AddParameter("@AccountType", objBatchPost.TranType);
                dbInteraction.AddParameter("@TranRefNo", objBatchPost.TranRefNo);
                dbInteraction.AddParameter("@TranRefType", objBatchPost.AccountType);
                dbInteraction.AddParameter("@TranRefName", objBatchPost.ClientName);
                dbInteraction.AddParameter("@FromDate", objBatchPost.FromDate);
                dbInteraction.AddParameter("@ToDate", objBatchPost.ToDate);
                dbInteraction.AddParameter("@isPosted", objBatchPost.PostedStatus);
                dbInteraction.AddParameter("@SortBy", objBatchPost.SortBy);
                dbInteraction.AddParameter("@SortType", objBatchPost.SortType);

                string[] tbleName = { "AC_Users" };
                //return dbInteraction.GetDataset("AC_GetGenericSearchDataForBatchUnPost", tbleName);
                return dbInteraction.GetDataset("AC_GetGenericSearchDataForUnpost", tbleName);
                
            }
            catch (Exception ex)    
            {
                throw (ex);
            }
        }
        #endregion

        #region Account Closing
        public SqlDataReader GetAccountClosingDetails(Hashtable argsLst)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@counter", argsLst["counter"]);
                dbInteraction.AddParameter("@query", argsLst["query"]);
                dbInteraction.AddParameter("@Id", argsLst["Id"]);
                dbInteraction.AddParameter("@MonthYear", argsLst["MonthYear"]);

                return dbInteraction.getDataReader("Ac_getAccountClosingDetails");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAccountClosingDetailsCounter(clsAccountClosing objAccountClosing, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {           

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@Counter", objAccountClosing.counter);
            dbInteraction.AddParameter("@query", objAccountClosing.query);
            dbInteraction.AddParameter("@Id", objAccountClosing.Id);
            dbInteraction.AddParameter("@MonthYear", objAccountClosing.MonthYear);
            dbInteraction.AddParameter("@FromdateBroking", objAccountClosing.FromdateBroking);
            dbInteraction.AddParameter("@ToDateBroking", objAccountClosing.ToDateBroking);
            dbInteraction.AddParameter("@statusBroking", objAccountClosing.statusBroking);
            dbInteraction.AddParameter("@BrokingMode", objAccountClosing.BrokingMode);
            dbInteraction.AddParameter("@FromdateRIBroking", objAccountClosing.FromdateRIBroking);
            dbInteraction.AddParameter("@ToDateRIBroking", objAccountClosing.ToDateRIBroking);
            dbInteraction.AddParameter("@statusRIBroking", objAccountClosing.statusRIBroking);
            dbInteraction.AddParameter("@BrokingRIMode", objAccountClosing.BrokingRIMode);
            dbInteraction.AddParameter("@FromdateAccounts", objAccountClosing.FromdateAccounts);
            dbInteraction.AddParameter("@ToDateAccounts", objAccountClosing.ToDateAccounts);
            dbInteraction.AddParameter("@statusAccounts", objAccountClosing.statusAccounts);
            dbInteraction.AddParameter("@AccountMode", objAccountClosing.AccountMode);
            dbInteraction.AddParameter("@FromdateJournal", objAccountClosing.FromdateJournal);
            dbInteraction.AddParameter("@ToDateJournal", objAccountClosing.ToDateJournal);
            dbInteraction.AddParameter("@statusJournal", objAccountClosing.statusJournal);
            dbInteraction.AddParameter("@JournalMode", objAccountClosing.JournalMode);
            dbInteraction.AddParameter("@UserId", objAccountClosing.UserId);

            try
            {
                DataTable dt = dbInteraction.getDataReader("Ac_getAccountClosingDetails", objAuditLog_HeaderMaster, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public DataTable GetMonthClosing(clsMonthClosing objMonthClosing, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@pGLMonth", objMonthClosing.GLMonth);
            dbInteraction.AddParameter("@pGLYear", objMonthClosing.GLYear);
            dbInteraction.AddParameter("@BrokModule", objMonthClosing.BrokModule);
            dbInteraction.AddParameter("@RIBrokModule", objMonthClosing.RIBrokModule);
            dbInteraction.AddParameter("@AccModule", objMonthClosing.AccModule);
            dbInteraction.AddParameter("@JournalModule", objMonthClosing.JournalModule);
            dbInteraction.AddParameter("@UserId", objMonthClosing.userId);

            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_MonthClosing", objAuditLog_HeaderMaster, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }

            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }
        #endregion
        #region Template

        public SqlDataReader GetTemplateDataAddUpdate(string strTemplateCode)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@TemplateCode", strTemplateCode);
                return dbInteraction.getDataReader("AC_GetTemplateDataAddUpdate");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateTemplateDefaultData(string strTempid, int iUserid)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TempId", strTempid);
            dbInteraction.AddParameter("@UserId", iUserid);
            try
            {
                string[] tblname = { "Ac_template" };
                DataSet ds = dbInteraction.GetDataset("AC_UpdTemplateDefaultData",tblname);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public SqlDataReader GetTemplateData(string strTempid)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@TempId", strTempid);
                return dbInteraction.getDataReader("AC_GetTemplateData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable AddUpdateTemplateData(clsTemplate objclsTemplate, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@Mode", objclsTemplate.Mode);
            dbInteraction.AddParameter("@TempId", objclsTemplate.TempId);
            dbInteraction.AddParameter("@TemplateType", objclsTemplate.TemplateType);
            dbInteraction.AddParameter("@TemplateName", objclsTemplate.TemplateName);
            dbInteraction.AddParameter("@TempDesc", objclsTemplate.TempDesc);
            dbInteraction.AddParameter("@UserId", objclsTemplate.UserId);
            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_UpdTemplateDataAddUpdate", objAuditLog_HeaderMaster, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }
        public int DeleteFinRepTempT(string strRowId, out string err)
        {
            err = "";
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@RowId", strRowId);
            try
            {
                int iRecord = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_DeleteFinRepTempT");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iRecord;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                err = ex.Message;
                return -1;
            }

        }


        public DataSet UpdateTemplateRowAddUpdate(clsTemplate objclsTemplate)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@Mode", objclsTemplate.Mode);
            dbInteraction.AddParameter("@TempId", objclsTemplate.TempId);
            dbInteraction.AddParameter("@TempColType", objclsTemplate.TempColType);
            dbInteraction.AddParameter("@RowOrder", objclsTemplate.RowOrder);
            dbInteraction.AddParameter("@ColHeading", objclsTemplate.ColHeading);
            dbInteraction.AddParameter("@ColAttributes", objclsTemplate.ColAttributes);
            dbInteraction.AddParameter("@GLClassCode", objclsTemplate.GLClassCode);
            dbInteraction.AddParameter("@TotalSign", objclsTemplate.TotalSign);
            dbInteraction.AddParameter("@UserId", objclsTemplate.UserId);
            try
            {
                string[] tblname = { "Ac_template" };
                DataSet ds = dbInteraction.GetDataset("AC_UpdTemplateRowAddUpdate", tblname);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public SqlDataReader GetTemplateRowDataAddUpdate(string strRowid)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@RowId ", strRowid);
                return dbInteraction.getDataReader("AC_GetTemplateRowDataAddUpdate");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetTemplateIdByRowId(string strRowid)
        {
            string strTempId = "";
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@RowId ", strRowid);
                SqlDataReader dr = dbInteraction.getDataReader("AC_GetTemplateDataByRowid");
                if (dr.Read())
                {
                    strTempId = dr["TempId"].ToString().Trim();
                }
                dr.Close();
                dbInteraction.CloseSqlConnection();
                return strTempId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetGLCategoryForTemplate(string strTempid)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@TempId ", strTempid);
                return dbInteraction.getDataReader("AC_GetCategoryForTemplate");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetFinRepTempM()
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                return dbInteraction.getDataReader("AC_GetFinRepTempM");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
        #region AccountReopeningLCH


        public DataSet GetAccountClosingDetails()
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                return dbInteraction.RunSQLWithDataSet("Ac_getAccountClosingDetails");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int UpdateAccountClosing(clsAccountClosing objclsAccountClosing)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@counter", objclsAccountClosing.counter);
            dbInteraction.AddParameter("@query", objclsAccountClosing.query);
            dbInteraction.AddParameter("@Id", objclsAccountClosing.Id);
            dbInteraction.AddParameter("@MonthYear", objclsAccountClosing.MonthYear);
            dbInteraction.AddParameter("@FromdateBroking", objclsAccountClosing.FromdateBroking);
            dbInteraction.AddParameter("@ToDateBroking", objclsAccountClosing.ToDateBroking);
            dbInteraction.AddParameter("@statusBroking", objclsAccountClosing.statusBroking);
            dbInteraction.AddParameter("@BrokingMode", objclsAccountClosing.BrokingMode);
            dbInteraction.AddParameter("@FromdateRIBroking", objclsAccountClosing.FromdateRIBroking);
            dbInteraction.AddParameter("@ToDateRIBroking ", objclsAccountClosing.ToDateRIBroking);
            dbInteraction.AddParameter("@statusRIBroking", objclsAccountClosing.statusRIBroking);
            dbInteraction.AddParameter("@BrokingRIMode", objclsAccountClosing.BrokingRIMode);
            dbInteraction.AddParameter("@FromdateAccounts", objclsAccountClosing.FromdateAccounts);
            dbInteraction.AddParameter("@ToDateAccounts", objclsAccountClosing.ToDateAccounts);
            dbInteraction.AddParameter("@statusAccounts", objclsAccountClosing.statusAccounts);
            dbInteraction.AddParameter("@AccountMode", objclsAccountClosing.AccountMode);
            dbInteraction.AddParameter("@FromdateJournal ", objclsAccountClosing.FromdateJournal);
            dbInteraction.AddParameter("@ToDateJournal", objclsAccountClosing.ToDateJournal);
            dbInteraction.AddParameter("@statusJournal", objclsAccountClosing.statusJournal);
            dbInteraction.AddParameter("@JournalMode", objclsAccountClosing.JournalMode);
            dbInteraction.AddParameter("@UserId", objclsAccountClosing.UserId);

            try
            {
                int iResult=dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "Ac_getAccountClosingDetails");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public DataSet AccountReopeningLCH(clsAccountClosing objclsAccountClosing)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@pGLMonth", objclsAccountClosing.pGLMonth);
            dbInteraction.AddParameter("@pGLYear", objclsAccountClosing.pGLYear);
            dbInteraction.AddParameter("@pGLMonthN", objclsAccountClosing.pGLMonthN);
            dbInteraction.AddParameter("@BrokModule", objclsAccountClosing.BrokModule);
            dbInteraction.AddParameter("@RIBrokModule", objclsAccountClosing.RIBrokModule);
            dbInteraction.AddParameter("@AccModule", objclsAccountClosing.AccModule);
            dbInteraction.AddParameter("@JournalModule", objclsAccountClosing.JournalModule);
            dbInteraction.AddParameter("@UserId", objclsAccountClosing.UserId);

            try
            {
                string[] tablename = { "AC_AccountReopening" };
                DataSet ds = dbInteraction.GetDataset("AC_AccountReopeningLCH", tablename);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }


        #endregion

        #region MatchTrans
      
        public DataTable GetUnMatchedTransactions(Hashtable objtran)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@SearchFrom", objtran["SearchFrom"]);
                dbInteraction.AddParameter("@SearchType", objtran["SearchType"]);
                //  dbInteraction.AddParameter("@SearchString", objtran["SearchString"]);
                dbInteraction.AddParameter("@AccountType", objtran["AccountType"]);
                dbInteraction.AddParameter("@TranRefNo", objtran["TranRefNo"]);
                dbInteraction.AddParameter("@ClientName", objtran["ClientName"]);
                dbInteraction.AddParameter("@InvoiceNo", objtran["InvoiceNo"]);
                dbInteraction.AddParameter("@PolicyNo", objtran["PolicyNo"]);
                dbInteraction.AddParameter("@AmtFrom", objtran["AmtFrom"]);
                dbInteraction.AddParameter("@FromDate", objtran["FromDate"]);
                dbInteraction.AddParameter("@AmtTo", objtran["AmtTo"]);
                dbInteraction.AddParameter("@ToDate", objtran["ToDate"]);

                return this.GetDataTable(dbInteraction.getDataReader("AC_GetUnMatchedTransactions"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable UpdAdjMatchedData(dynamic mObject, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@SearchFrom", mObject.SearchFrom);
            dbInteraction.AddParameter("@SearchType", mObject.SearchType);
            dbInteraction.AddParameter("@SearchString", mObject.SearchString);
            dbInteraction.AddParameter("@SType", mObject.SType);
            dbInteraction.AddParameter("@UserId", mObject.UserId);

            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_UpdAdjMatchedData", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public SqlDataReader GetCustNameM(string CusM_Business1, string CusM_Business2)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@CusM_Business1", CusM_Business1);
            dbInteraction.AddParameter("@CusM_Business2", CusM_Business2);
            try
            {
                return dbInteraction.getDataReader("AC_GetCustNameM");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetInsurerName()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return dbInteraction.getDataReader("AC_GetInsurerName");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetNonTradeCusM()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return dbInteraction.getDataReader("AC_GetNonTradeCusM");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion



        #region NonTradeDebitNote

        public SqlDataReader GetNTDebitNoteData(string strDrCrNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@DrCrNo", strDrCrNo);
                return dbInteraction.getDataReader("AC_GetNTDebitNoteData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public SqlDataReader GetSubmitEnableDataForDebit(string strDrCrNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@DrCrNo", strDrCrNo);
                return dbInteraction.getDataReader("AC_GetSubmitEnableData_Debit");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetNTDebitNoteDataByTranNo(string strDrCrNo, int intTranNo)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@DrCrNo", strDrCrNo);
            dbInteraction.AddParameter("@TranNo", intTranNo);

            try
            {
                return dbInteraction.getDataReader("AC_GetNTDebitNoteDataByTranNo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetfunCheckForSubmitAlert(string TranType, string TranRefNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@TranType", TranType);
                dbInteraction.AddParameter("@TranRefNo", TranRefNo);
                return dbInteraction.getDataReader("AC_ChkGenericSubmit");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int UpdateDebitNoteStatus(string strTranRefCode, string strTranType)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@DrCrNo", strTranRefCode);
            dbInteraction.AddParameter("@TranType", strTranType);
            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdDebitNoteStatus");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public SqlDataReader GetGLDataForDebitNote(string strDebitNoteNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@DebitNoteNo", strDebitNoteNo);
                return dbInteraction.getDataReader("AC_GetGLDataForDebitNote");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet AddUpdateNonTradeForDebitNote(clsNonTradeCreditNote objclsNonTradeCreditNote)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", objclsNonTradeCreditNote.TranNo);
            dbInteraction.AddParameter("@DrCrNo", objclsNonTradeCreditNote.DrCrNo);
            dbInteraction.AddParameter("@GLCode", objclsNonTradeCreditNote.GLCode);
            dbInteraction.AddParameter("@DBAmountP", objclsNonTradeCreditNote.DBAmountP);
            dbInteraction.AddParameter("@DBGSTAmount", objclsNonTradeCreditNote.DBGSTAmount);
            dbInteraction.AddParameter("@DBAmount", objclsNonTradeCreditNote.DBAmount);
            dbInteraction.AddParameter("@CRAmountP", objclsNonTradeCreditNote.CRAmountP);
            dbInteraction.AddParameter("@CRGSTAmount", objclsNonTradeCreditNote.CRGSTAmount);
            dbInteraction.AddParameter("@CRAmount", objclsNonTradeCreditNote.CRAmount);
            dbInteraction.AddParameter("@UserId", objclsNonTradeCreditNote.UserId);
            dbInteraction.AddParameter("@DBGSTType", objclsNonTradeCreditNote.DBGSTType);
            dbInteraction.AddParameter("@CRGSTType", objclsNonTradeCreditNote.CRGSTType);
            dbInteraction.AddParameter("@GLDesc", objclsNonTradeCreditNote.GLDesc);
            dbInteraction.AddParameter("@DBWhtAmt", objclsNonTradeCreditNote.DBWhtAmt);
            dbInteraction.AddParameter("@CRWhtAmt", objclsNonTradeCreditNote.CRWhtAmt);
            dbInteraction.AddParameter("@DBWhtP", objclsNonTradeCreditNote.DBWhtP);
            dbInteraction.AddParameter("@CRWhtP", objclsNonTradeCreditNote.CRWhtP);

            try
            {
                string[] tablename = { "AC_DebitNote" };
                DataSet ds = dbInteraction.GetDataset("AC_AddUpdateNonTradeForDebitNote", tablename);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.NO);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }


        public SqlDataReader DeleteNonTradeDebit(string strTranNo, string strCreditNoteNo)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", strTranNo);
            dbInteraction.AddParameter("@DebitNoteNo", strCreditNoteNo);
            try
            {
                SqlDataReader dt = dbInteraction.getDataReader("AC_DeleteNonTradeDebitNote");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;

            }

        }



        public DataTable AddUpdateDebitNote(clsNonTradeCreditNote objclsNonTradeCreditNote, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired, bool var)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@DebitNoteNo", objclsNonTradeCreditNote.CreditNoteNo);
            dbInteraction.AddParameter("@DebitNoteDate", objclsNonTradeCreditNote.CreditNoteDate);
            dbInteraction.AddParameter("@CusM_Id", objclsNonTradeCreditNote.CusM_Id);
            dbInteraction.AddParameter("@CusM_Name", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.CusM_Name, 100));
            dbInteraction.AddParameter("@CusM_Add1", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.CusM_Add1, 50));
            dbInteraction.AddParameter("@CusM_Add2", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.CusM_Add2, 50));
            dbInteraction.AddParameter("@CusM_Add3", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.CusM_Add3, 50));
            dbInteraction.AddParameter("@CusM_Add4", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.CusM_Add4, 50));
            dbInteraction.AddParameter("@Amount", objclsNonTradeCreditNote.Amount);
            dbInteraction.AddParameter("@CurrencyCode", objclsNonTradeCreditNote.CurrencyCode);
            dbInteraction.AddParameter("@ExchRate", objclsNonTradeCreditNote.ExchRate);
            dbInteraction.AddParameter("@LocalAmount", objclsNonTradeCreditNote.LocalAmount);
            dbInteraction.AddParameter("@StmtDesc", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.StmtDesc, 100));
            dbInteraction.AddParameter("@DrCrDesc", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.DrCrDesc, 500));
            dbInteraction.AddParameter("@UserId", objclsNonTradeCreditNote.UserId);
            dbInteraction.AddParameter("@AccMonth", objclsNonTradeCreditNote.AccMonth);
            try
            {
                DataTable dt;
                if (var == true)
                {
                    dt = dbInteraction.getDataReader("AC_AddUpdateDebitNotefinal", objAuditLog_HeaderMaster, IsAuditRequired);
                }
                else
                {
                    dt = dbInteraction.getDataReader("AC_AddUpdateDebitNote", objAuditLog_HeaderMaster, IsAuditRequired);


                }
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;

            }
            finally
            {
                dbInteraction.CloseSqlConnection();
            }

        }

        public DataSet SaveReverseDebitNote(string strReceiptNo, int intUserid)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
            dbInteraction.AddParameter("@UserId", intUserid);

            try
            {
                string[] tablename = { "AC_Save_Reverse_DebitNote" };
                DataSet ds = dbInteraction.GetDataset("AC_Save_Reverse_DebitNote", tablename);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        #endregion

        #region NonTradeCreditNote

        public SqlDataReader GetNTCreditNoteData(string strDrCrNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@DrCrNo", strDrCrNo);
                return dbInteraction.getDataReader("AC_GetNTCreditNoteData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetSubmitEnableData(string strDrCrNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@DrCrNo", strDrCrNo);
                return dbInteraction.getDataReader("AC_GetSubmitEnableData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public SqlDataReader GenerateManualTranRefCode(string strTranType, string strTranRefCode, int intUserId)
        //{
        //    try
        //    {
        //        dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //        dbInteraction.AddParameter("@TranType", strTranType);
        //        dbInteraction.AddParameter("@TranRefCode", strTranRefCode);
        //        dbInteraction.AddParameter("@UserId", intUserId);
        //        return dbInteraction.getDataReader("AC_GenerateManualTranRefCode");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public SqlDataReader GetEditableModes(string strTranType, string strTranRefNo, int intUserId)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@TranType", strTranType);
                dbInteraction.AddParameter("@TranRefNo", strTranRefNo);
                dbInteraction.AddParameter("@UserId", intUserId);
                return dbInteraction.getDataReader("AC_GetEditableModes");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public SqlDataReader GenerateTranRefCode(string strTranType, int intUserId, string strDate)
        //{
        //    try
        //    {
        //        dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //        dbInteraction.AddParameter("@TranType", strTranType);
        //        dbInteraction.AddParameter("@UserId", intUserId);
        //        dbInteraction.AddParameter("@StrDate", strDate);
        //        return dbInteraction.getDataReader("AC_GenerateTranRefCode");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public SqlDataReader GenerateTranRefCode(dynamic mObject)
        //{
        //    try
        //    {
        //        dynamic myObject = (ExpandoObject)(mObject);

        //        dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //        dbInteraction.AddParameter("@TranType", myObject.TranType);
        //        dbInteraction.AddParameter("@UserId", myObject.UserId);
        //        dbInteraction.AddParameter("@StrDate", myObject.strDate);
        //        return dbInteraction.getDataReader("AC_GenerateTranRefCode");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public SqlDataReader GetGstM()
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                return dbInteraction.getDataReader("AC_GetGstM");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string AddUpdateGenericSubmit(string strTranRefType, string strTranRefNo, int intUserid)
        {
            string strTranRefNoOut = "";

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranRefType ", strTranRefType);
            dbInteraction.AddParameter("@TranRefNo ", strTranRefNo);
            dbInteraction.AddParameter("@UserId", intUserid);
            try
            {
                SqlDataReader dr = dbInteraction.getDataReader("AC_AddUpdate_GenericSubmit");
                if (dr.Read())
                {
                    strTranRefNoOut = dr["TranRefNo"].ToString().Trim();
                }
                dr.Close();
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return strTranRefNoOut;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public int UpdateCreditNoteStatus(string strTranRefCode, string strTranType)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@DrCrNo", strTranRefCode);
            dbInteraction.AddParameter("@TranType", strTranType);
            try
            {
                int iResult= dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdCreditNoteStatus");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public SqlDataReader GetGLDataForCreditNote(string strCreditNoteNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@CreditNoteNo", strCreditNoteNo);
                return dbInteraction.getDataReader("AC_GetGLDataForCreditNote");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DeleteNonTrade(string strTranNo, string strCreditNoteNo, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", strTranNo);
            dbInteraction.AddParameter("@CreditNoteNo", strCreditNoteNo);
            try
            {
                DataTable dt=dbInteraction.getDataReader("AC_DeleteNonTradeCreditNote", objAuditLog_HeaderMaster, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;

            }

        }

        public int  UpdCreditNoteStatus(string strTranRefCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranRefCode", strTranRefCode);
            try
            {
               int iResult= dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdateCreditNoteM");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }


        public DataSet SaveReverseCreditNote(string strReceiptNo, int intUserid)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
            dbInteraction.AddParameter("@UserId", intUserid);

            try
            {
                string[] tablename = { "AC_Reverse_CreditNote" };
                DataSet ds = dbInteraction.GetDataset("AC_Save_Reverse_CreditNote",tablename);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }


        public DataSet AddUpdateNonTradeForCreditNote(clsNonTradeCreditNote objclsNonTradeCreditNote)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", objclsNonTradeCreditNote.TranNo);
            dbInteraction.AddParameter("@DrCrNo", objclsNonTradeCreditNote.DrCrNo);
            dbInteraction.AddParameter("@GLCode", objclsNonTradeCreditNote.GLCode);
            dbInteraction.AddParameter("@DBAmountP", objclsNonTradeCreditNote.DBAmountP);
            dbInteraction.AddParameter("@DBGSTAmount", objclsNonTradeCreditNote.DBGSTAmount);
            dbInteraction.AddParameter("@DBAmount", objclsNonTradeCreditNote.DBAmount);
            dbInteraction.AddParameter("@CRAmountP", objclsNonTradeCreditNote.CRAmountP);
            dbInteraction.AddParameter("@CRGSTAmount", objclsNonTradeCreditNote.CRGSTAmount);
            dbInteraction.AddParameter("@CRAmount", objclsNonTradeCreditNote.CRAmount);
            dbInteraction.AddParameter("@UserId", objclsNonTradeCreditNote.UserId);
            dbInteraction.AddParameter("@DBGSTType", objclsNonTradeCreditNote.DBGSTType);
            dbInteraction.AddParameter("@CRGSTType", objclsNonTradeCreditNote.CRGSTType);
            dbInteraction.AddParameter("@GLDesc", objclsNonTradeCreditNote.GLDesc);
            dbInteraction.AddParameter("@DBWhtAmt", objclsNonTradeCreditNote.DBWhtAmt);
            dbInteraction.AddParameter("@CRWhtAmt", objclsNonTradeCreditNote.CRWhtAmt);
            dbInteraction.AddParameter("@DBWhtP", objclsNonTradeCreditNote.DBWhtP);
            dbInteraction.AddParameter("@CRWhtP", objclsNonTradeCreditNote.CRWhtP);

            try
            {
                string[] tablename = { "AC_CreditNote" };
                DataSet ds = dbInteraction.GetDataset("AC_AddUpdateNonTradeForCreditNote", tablename);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.NO);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public SqlDataReader GetNTCreditNoteDataByTranNo(string strDrCrNo, int intTranNo)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@DrCrNo", strDrCrNo);
            dbInteraction.AddParameter("@TranNo", intTranNo);

            try
            {
                return dbInteraction.getDataReader("AC_GetNTCreditNoteDataByTranNo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable AddUpdateCreditNote(clsNonTradeCreditNote objclsNonTradeCreditNote, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired,bool var)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@CreditNoteNo", objclsNonTradeCreditNote.CreditNoteNo);
            dbInteraction.AddParameter("@CreditNoteDate", objclsNonTradeCreditNote.CreditNoteDate);
            dbInteraction.AddParameter("@CusM_Id", objclsNonTradeCreditNote.CusM_Id);
            dbInteraction.AddParameter("@CusM_Name", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.CusM_Name, 100));
            dbInteraction.AddParameter("@CusM_Add1", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.CusM_Add1, 50));
            dbInteraction.AddParameter("@CusM_Add2", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.CusM_Add2, 50));
            dbInteraction.AddParameter("@CusM_Add3", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.CusM_Add3, 50));
            dbInteraction.AddParameter("@CusM_Add4", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.CusM_Add4, 50));
            dbInteraction.AddParameter("@Amount", objclsNonTradeCreditNote.Amount);
            dbInteraction.AddParameter("@CurrencyCode", objclsNonTradeCreditNote.CurrencyCode);
            dbInteraction.AddParameter("@ExchRate", objclsNonTradeCreditNote.ExchRate);
            dbInteraction.AddParameter("@LocalAmount", objclsNonTradeCreditNote.LocalAmount);
            dbInteraction.AddParameter("@StmtDesc", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.StmtDesc, 100));
            dbInteraction.AddParameter("@DrCrDesc", dbInteraction.fstrGetSafeString(objclsNonTradeCreditNote.DrCrDesc, 500));
            dbInteraction.AddParameter("@UserId", objclsNonTradeCreditNote.UserId);
            dbInteraction.AddParameter("@AccMonth", objclsNonTradeCreditNote.AccMonth);
            try
            {
                 DataTable dt;
                 if (var == true)
                 {
                     dt = dbInteraction.getDataReader("AC_AddUpdateCreditNotefinal", objAuditLog_HeaderMaster, IsAuditRequired);
                 }
                 else
                 {
                     dt = dbInteraction.getDataReader("AC_AddUpdateCreditNote", objAuditLog_HeaderMaster, IsAuditRequired);
              

                 }
               dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
               return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;

            }

        }

        public string GetGSTMByCode(string strGSTCode)
        {
            string strTaxRate = "";
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@GSTCode ", strGSTCode);

                SqlDataReader dr = dbInteraction.getDataReader("AC_GetGSTMByCode");
                if (dr.Read())
                {
                    strTaxRate = dr["TaxRate"].ToString().Trim();
                }
                dr.Close();
                dbInteraction.CloseSqlConnection();
                return strTaxRate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Reciept

        public SqlDataReader GetRecptData(string strReceiptNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
                return dbInteraction.getDataReader("AC_GetRecptData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetReceiptB(string strReceiptNo, string TranNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
                dbInteraction.AddParameter("@TranNo", TranNo);
                return dbInteraction.getDataReader("AC_GetReceiptB");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetReceiptN(string strReceiptNo, string TranNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
                dbInteraction.AddParameter("@TranNo", TranNo);
                return dbInteraction.getDataReader("AC_GetReceiptN");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetReceiptP(string strReceiptNo, string TranNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
                dbInteraction.AddParameter("@TranNo", TranNo);
                return dbInteraction.getDataReader("AC_GetReceiptP");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GenerateManualTranRefCode(string strTranType, string strTranRefCode, int UserId)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranType", strTranType);
            dbInteraction.AddParameter("@TranRefCode", strTranRefCode);
            dbInteraction.AddParameter("@UserId", UserId);
            try
            {
                string[] tbleName = { "AC_ReceiptM" };
                DataSet ds = dbInteraction.GetDataset("AC_GenerateManualTranRefCode", tbleName);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        //public SqlDataReader GetEditableModesForReciept(string strTranType, string strTranRefNo, int UserId)
        //{
        //    try
        //    {
        //        dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //        dbInteraction.AddParameter("@TranType", strTranType);
        //        dbInteraction.AddParameter("@TranRefNo", strTranRefNo);
        //        dbInteraction.AddParameter("@UserId", UserId);
        //        return dbInteraction.getDataReader("AC_GetEditableModes");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public SqlDataReader GetGLDataForReceipts(string strReceiptNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
                return dbInteraction.getDataReader("AC_GetGLDataForReceipts");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetBankDataForReceipts(string strReceiptNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
                return dbInteraction.getDataReader("AC_GetBankDataForReceipts");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetClientInfoForReciept(string strUserType, string strclientid)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@pUserType", strUserType);
                dbInteraction.AddParameter("@CusM_ID", strclientid);
                return dbInteraction.getDataReader("AC_GetClientInfoForReciept");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdReceiptCashFlow(string strReceiptNo, string strCashFlowType)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
            dbInteraction.AddParameter("@CashFlowType", strCashFlowType);
            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdReceiptCashFlow");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public string GetCompanyOperatingBank()
        {
            string strOperativeBank = "";
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

                SqlDataReader dr = dbInteraction.getDataReader("AC_GetOperativeBank");
                if (dr.Read())
                {
                    strOperativeBank = dr["OperatingBank"].ToString().Trim();
                }
                dr.Close();
                dbInteraction.CloseSqlConnection();
                return strOperativeBank;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetGstValue()
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                return dbInteraction.RunSQLWithDataSet("Ac_GetGstValue");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdReceiptStatus(string strReceiptNo, string strTranType)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
            dbInteraction.AddParameter("@TranType", strTranType);
            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdReceiptStatus");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        #region for updating bank payment status
        public int UpdBankReceiptStatus(string strReceiptNo, string strTranType)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@PaymentNo", strReceiptNo);
            dbInteraction.AddParameter("@TranType", strTranType);
            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdPaymentStatus");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }
        #endregion
        public DataSet SaveReverse(string strReceiptNo, int intUserid)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
            dbInteraction.AddParameter("@UserId", intUserid);

            try
            {
                string[] tableName = { "AC_ReceiptM" };
                DataSet ds = dbInteraction.GetDataset("AC_Save_Reverse", tableName);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public SqlDataReader GetSubsidiary(string strClientID, string strReceiptNo, string strIsPosted)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@ClientID", strClientID);
                if (strIsPosted == "Y")
                {
                    dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
                }
                return dbInteraction.getDataReader("Ac_GetSubsidiary");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public DataSet GetGLDataForReceipt(string strReceiptNo, string strSortOn = "AccountType", string strSortBy = "ASC")
        //{
        //    try
        //    {
        //        dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //        dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
        //        dbInteraction.AddParameter("@SortOn", strSortOn);
        //        dbInteraction.AddParameter("@SortBy", strSortBy);

        //        string[] tbleName = { "AC_ReceiptB" };
        //        return dbInteraction.GetDataset("AC_GetGLDataForReceipts", tbleName);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public DataTable GetGLDataForReceipt(string strReceiptNo, string strSortOn = "AccountType", string strSortBy = "ASC")
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
                dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
                dbInteraction.AddParameter("@SortOn", strSortOn);
                dbInteraction.AddParameter("@SortBy", strSortBy);

                string[] tbleName = { "AC_ReceiptB" };

                DataTable dt = GetDataTable(dbInteraction.getDataReader("AC_GetGLDataForReceipts"));
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        //public DataSet GetGenericMatchDataForReceipt(string strTranType, string strIsmatched, string strMatchTranType, string strMatchTranCode, string strReceiptNo, string strIsMatchReset, string strSearchCriteria, string strSortOn = "DM.DocumentNo", string strSortBy = "ASC")
        //{
        //    try
        //    {
        //        dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //        dbInteraction.AddParameter("@TranType", strTranType);
        //        dbInteraction.AddParameter("@IsMatched", strIsmatched);
        //        dbInteraction.AddParameter("@MatchTranType", strMatchTranType);
        //        dbInteraction.AddParameter("@MatchTranCode", strMatchTranCode);
        //        dbInteraction.AddParameter("@StrRecptNo", strReceiptNo);
        //        dbInteraction.AddParameter("@IsMatchReset", strIsMatchReset);
        //        dbInteraction.AddParameter("@SearchCriteria", strSearchCriteria);
        //        dbInteraction.AddParameter("@SoryOn", strSortOn);
        //        dbInteraction.AddParameter("@SoryBy", strSortBy);

        //        string[] tbleName = { "AC_GetGenericMatchData" };
        //        return dbInteraction.GetDataset("AC_GetGenericMatchData", tbleName);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public int DeleteNonTradeReceipt(string strTranNo, string strReceiptNo)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", strTranNo);
            dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);
            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_DeleteNonTradeReceipt");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }


        public int MatchAllGenericData(string strTranRefType, string strMatchTranType, string strMatchTranCode, string strReceiptNo, string strIsMatchReset, string strUserId)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranRefType", strTranRefType);
            dbInteraction.AddParameter("@MatchTranType", strMatchTranType);
            dbInteraction.AddParameter("@MatchTranCode", strMatchTranCode);
            dbInteraction.AddParameter("@StrRecptNo", strReceiptNo);
            dbInteraction.AddParameter("@IsMatchReset", strIsMatchReset);
            dbInteraction.AddParameter("@UserId", strUserId);

            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_MatchAllGenericData");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public int ClearAllGenericData(string strTranRefType, string strMatchTranType, string strMatchTranCode, string strReceiptNo, string strIsMatchReset, string strUserId)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranRefType", strTranRefType);
            dbInteraction.AddParameter("@MatchTranType", strMatchTranType);
            dbInteraction.AddParameter("@MatchTranCode", strMatchTranCode);
            dbInteraction.AddParameter("@StrRecptNo", strReceiptNo);
            dbInteraction.AddParameter("@IsMatchReset", strIsMatchReset);
            dbInteraction.AddParameter("@UserId", strUserId);

            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_ClearAllGenericData");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public int UpdateGenericInvoiceData(string strDataP, string strTranType, string strTranRefCode, string strUserIdP)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@StrDataP", strDataP);
            dbInteraction.AddParameter("@StrTranType", strTranType);
            dbInteraction.AddParameter("@StrTranRefCode", strTranRefCode);
            dbInteraction.AddParameter("@StrUserIdP", strUserIdP);

            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdateGenericInvoiceData");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public int UpdateGenericInvoiceDataJDP(string strDataP, string strTranType, string strTranRefCode, string strUserIdP)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@StrDataP", strDataP);
            dbInteraction.AddParameter("@StrTranType", strTranType);
            dbInteraction.AddParameter("@StrTranRefCode", strTranRefCode);
            dbInteraction.AddParameter("@StrUserIdP", strUserIdP);

            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdateGenericInvoiceDataJDP");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }
        public DataTable AddUpdateReceipt(clsReciept objclsReciept, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired, bool isfinal)
        {
            return AddUpdateReceipt(objclsReciept, objAuditLog_HeaderMaster, IsAuditRequired, isfinal, null);
        }
        public DataTable AddUpdateReceipt(clsReciept objclsReciept, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired,bool isfinal, DatabaseInteraction dbInteraction )
        {
            bool IsMyDb = true;
            if (dbInteraction == null)
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
                IsMyDb = true;
            }
            dbInteraction.ClearParameteres();
            dbInteraction.AddParameter("@ReceiptNo", objclsReciept.ReceiptNo);
            dbInteraction.AddParameter("@ReceiptDate", objclsReciept.ReceiptDate);
            dbInteraction.AddParameter("@ReceiptTypeCode", objclsReciept.ReceiptTypeCode);
            dbInteraction.AddParameter("@ClientCode", objclsReciept.ClientCode);
            dbInteraction.AddParameter("@ClientName", dbInteraction.fstrGetSafeString(objclsReciept.ClientName, 100));
            dbInteraction.AddParameter("@ClientAdd1", dbInteraction.fstrGetSafeString(objclsReciept.ClientAdd1, 50));
            dbInteraction.AddParameter("@ClientAdd2", dbInteraction.fstrGetSafeString(objclsReciept.ClientAdd2, 50));
            dbInteraction.AddParameter("@ClientAdd3", dbInteraction.fstrGetSafeString(objclsReciept.ClientAdd3, 50));
            dbInteraction.AddParameter("@ClientAdd4", dbInteraction.fstrGetSafeString(objclsReciept.ClientAdd4, 50));
            dbInteraction.AddParameter("@LocalAmount", objclsReciept.LocalAmount);
            dbInteraction.AddParameter("@StmtDesc", dbInteraction.fstrGetSafeString(objclsReciept.StmtDesc, 100));
            dbInteraction.AddParameter("@RecptDesc", dbInteraction.fstrGetSafeString(objclsReciept.RecptDesc, 500));
            dbInteraction.AddParameter("@UserId", objclsReciept.UserId);
            dbInteraction.AddParameter("@ReceiptSource", objclsReciept.ReceiptSource);
            dbInteraction.AddParameter("@Accdate", objclsReciept.Accdate);

            try
            {
                DataTable dt;
                if (isfinal ==true )
                {
                     dt = dbInteraction.getDataReader("AC_AddUpdateReceiptfinal", objAuditLog_HeaderMaster, IsAuditRequired);
                     clsACCommon objAccountBAL = new clsACCommon();
                     if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["Result"] != null)
                     {
                         objclsReciept.ReceiptNo = dt.Rows[0]["Result"].ToString(); 
                         objAccountBAL.UpdReceiptStatus(objclsReciept.ReceiptNo, "Y");
                     }
                }
                else
                {
                     dt = dbInteraction.getDataReader("AC_AddUpdateReceipt", objAuditLog_HeaderMaster, IsAuditRequired);

                }
                if (IsMyDb)
                    dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                dbInteraction.ClearParameteres();
                return dt;
            }
            catch (Exception ex)
            {
                if (IsMyDb)
                    dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                dbInteraction.ClearParameteres();
                throw ex;

            }

        }

        public DataSet AddUpdateBankTranForReceipt(clsReciept objclsReciept)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", objclsReciept.TranNo);
            dbInteraction.AddParameter("@ReceiptNo", objclsReciept.ReceiptNo);
            dbInteraction.AddParameter("@BankCode", objclsReciept.BankCode);
            dbInteraction.AddParameter("@ChequeNo", objclsReciept.ChequeNo);
            dbInteraction.AddParameter("@ChequeDate", objclsReciept.ChequeDate);
            dbInteraction.AddParameter("@Amount", objclsReciept.Amount);
            dbInteraction.AddParameter("@CurrencyCode", objclsReciept.CurrencyCode);
            dbInteraction.AddParameter("@ExchangeRate", objclsReciept.ExchangeRate);
            dbInteraction.AddParameter("@LocalAmount", objclsReciept.LocalAmount);
            dbInteraction.AddParameter("@UserId", objclsReciept.UserId);
            dbInteraction.AddParameter("@ClearDate", objclsReciept.ClearDate);


            try
            {
                string[] tbleName = { "AC_Receipt" };
                DataSet ds = dbInteraction.GetDataset("AC_AddUpdateBankTranForReceipt", tbleName);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }


        public int AddUpdatePettyCashTranForReceipt(clsReciept objclsReciept)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", objclsReciept.TranNo);
            dbInteraction.AddParameter("@ReceiptNo", objclsReciept.ReceiptNo);
            dbInteraction.AddParameter("@PCCode", objclsReciept.PCCode);
            dbInteraction.AddParameter("@PCDate", objclsReciept.PCDate);
            dbInteraction.AddParameter("@Amount", objclsReciept.Amount);
            dbInteraction.AddParameter("@CurrencyCode", objclsReciept.CurrencyCode);
            dbInteraction.AddParameter("@ExchangeRate", objclsReciept.ExchangeRate);
            dbInteraction.AddParameter("@LocalAmount", objclsReciept.LocalAmount);
            dbInteraction.AddParameter("@UserId", objclsReciept.UserId);

            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_AddUpdatePettyCashTranForReceipt");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }
        // For Bank Payment
        public int AddUpdatePettyCashTranForBankPayment(clsReciept objclsReciept)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", objclsReciept.TranNo);
            dbInteraction.AddParameter("@ReceiptNo", objclsReciept.ReceiptNo);
            dbInteraction.AddParameter("@PCCode", objclsReciept.PCCode);
            dbInteraction.AddParameter("@PCDate", objclsReciept.PCDate);
            dbInteraction.AddParameter("@Amount", objclsReciept.Amount);
            dbInteraction.AddParameter("@CurrencyCode", objclsReciept.CurrencyCode);
            dbInteraction.AddParameter("@ExchangeRate", objclsReciept.ExchangeRate);
            dbInteraction.AddParameter("@LocalAmount", objclsReciept.LocalAmount);
            dbInteraction.AddParameter("@UserId", objclsReciept.UserId);

            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_AddUpdatePettyCashTranForPayment");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public int DeleteBankReceipt(int strTranNo, string strReceiptNo)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", strTranNo);
            dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);

            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_DeleteBankReceipt");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }
        #region for delete BankPayment 
        public int DeleteBankPayment(int strTranNo, string strReceiptNo)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", strTranNo);
            dbInteraction.AddParameter("@ReceiptNo", strReceiptNo);

            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_DeleteBankPayment");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        #endregion
        public DataSet AddUpdateNonTradeForReceipt(clsReciept objclsReciept)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", objclsReciept.TranNo);
            dbInteraction.AddParameter("@ReceiptNo", objclsReciept.ReceiptNo);
            dbInteraction.AddParameter("@GLCode", objclsReciept.GLCode);
            dbInteraction.AddParameter("@DBAmount", objclsReciept.DBAmount);
            dbInteraction.AddParameter("@CRAmount", objclsReciept.CRAmount);
            dbInteraction.AddParameter("@DBAmountP", objclsReciept.DBAmountP);
            dbInteraction.AddParameter("@DBGSTAmount", objclsReciept.DBGSTAmount);
            dbInteraction.AddParameter("@CRAmountP", objclsReciept.CRAmountP);
            dbInteraction.AddParameter("@CRGSTAmount", objclsReciept.CRGSTAmount);
            dbInteraction.AddParameter("@DebitAmtPFC", objclsReciept.DebitAmtPFC);
            dbInteraction.AddParameter("@CreditAmtPFC", objclsReciept.CreditAmtPFC);
            dbInteraction.AddParameter("@CurrencyCode", objclsReciept.CurrencyCode);
            dbInteraction.AddParameter("@ExchangeRate", objclsReciept.ExchangeRate);
            dbInteraction.AddParameter("@GlTranDesc", objclsReciept.GlTranDesc);
            dbInteraction.AddParameter("@DebitGSTType", objclsReciept.DebitGSTType);
            dbInteraction.AddParameter("@CreditGSTType", objclsReciept.CreditGSTType);
            dbInteraction.AddParameter("@DBGstCode", objclsReciept.DBGstCode);
            dbInteraction.AddParameter("@CRGstCode", objclsReciept.CRGstCode);
            dbInteraction.AddParameter("@UserId", objclsReciept.UserId);
            dbInteraction.AddParameter("@DBWhtAmt", objclsReciept.DBWhtAmt);
            dbInteraction.AddParameter("@CRWhtAmt", objclsReciept.CRWhtAmt);
            dbInteraction.AddParameter("@DBWhtP", objclsReciept.DBWhtP);
            dbInteraction.AddParameter("@CRWhtP", objclsReciept.CRWhtP);
            dbInteraction.AddParameter("@ProfitCenter", objclsReciept.ProfitCenter);
            dbInteraction.AddParameter("@FundCode", objclsReciept.FundCode);


            try
            {
                string[] tableName = { "AC_Receipt" };
                DataSet ds = dbInteraction.GetDataset("AC_AddUpdateNonTradeForReceipt", tableName);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return ds;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public string GetWHTMByCode(string strGSTCode)
        {
            string strTaxRate = "";
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@GSTCode ", strGSTCode);

                SqlDataReader dr = dbInteraction.getDataReader("AC_GetWHTMByCode");
                if (dr.Read())
                {
                    strTaxRate = dr["TaxRate"].ToString().Trim();
                }
                dr.Close();
                dbInteraction.CloseSqlConnection();
                return strTaxRate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int funUpdateUnMatchedAmountForReciept(string StrRefType, string StrRefCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@StrRefType", StrRefType);
            dbInteraction.AddParameter("@StrRefCode", StrRefCode);
            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_UpdateUnMatchedAmount");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }
        #endregion

        #region Payment
        public SqlDataReader GetSubmitEnableOption(string strTranRefCode)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@PaymentNo", strTranRefCode);

                return dbInteraction.getDataReader("AC_GetSubmitEnableOption");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetUnMatchedAmount(string strTranRefCode)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@PaymentNo", strTranRefCode);

                return dbInteraction.getDataReader("AC_GetUnMatchedAmount");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetBankData(string strTranRefCode, int mstrBankTranNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@PaymentNo", strTranRefCode);
                dbInteraction.AddParameter("@TranNo", mstrBankTranNo);

                return dbInteraction.getDataReader("AC_GetBankData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetNonTradeData(string mstrTranRefCode, int mstrNonTradeTranNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@PaymentNo", mstrTranRefCode);
                dbInteraction.AddParameter("@TranNo", mstrNonTradeTranNo);

                return dbInteraction.getDataReader("AC_GetNonTradeData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetPettyCashData(string mstrTranRefCode, int mstrNonTradeTranNo)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@PaymentNo", mstrTranRefCode);
                dbInteraction.AddParameter("@TranNo", mstrNonTradeTranNo);

                return dbInteraction.getDataReader("AC_GetPettyCashData");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public DataTable GenerateManualTranRefCode(dynamic mObject, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        //{
        //    dynamic myObject = (ExpandoObject)(mObject);

        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
        //    dbInteraction.AddParameter("@TranType", mObject.TranType);
        //    dbInteraction.AddParameter("@TranRefCode", mObject.TranRefCode);
        //    dbInteraction.AddParameter("@UserId", mObject.UserId);

        //    try
        //    {
        //        DataTable dt = dbInteraction.getDataReader("AC_GenerateManualTranRefCode", objAuditLog_HeaderMaster, IsAuditRequired);
        //        dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
        //        return dt;
        //    }

        //    catch (Exception ex)
        //    {
        //        dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
        //        throw ex;
        //    }
        //}

        //public SqlDataReader GetEditableModes(dynamic mObject)
        //{

        //    dynamic myObject = (ExpandoObject)(mObject);
        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    dbInteraction.AddParameter("@TranType", mObject.TranType);
        //    dbInteraction.AddParameter("@TranRefNo",  mObject.TranRefNo);
        //    dbInteraction.AddParameter("@UserId", mObject.UserId);

        //    try
        //    {             

        //        return dbInteraction.getDataReader("AC_GetEditableModes");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public SqlDataReader GetExchangeRate(string pstrCurrCode)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@pCurrCode", pstrCurrCode);

                return dbInteraction.getDataReader("AC_GetExchRate");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GenerateTranRefCode(dynamic mObject)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranType", mObject.TranType);
            dbInteraction.AddParameter("@UserId", mObject.UserId);
            try
            { dbInteraction.AddParameter("@StrDate", mObject.strDate); }
            catch { }
              
            try
            {
                SqlDataReader dr = dbInteraction.getDataReader("AC_GenerateTranRefCode");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                dr.Close();
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }


        public DataTable GenerateTranRefCodeTemp(dynamic mObject)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranType", mObject.TranType);
            dbInteraction.AddParameter("@UserId", mObject.UserId);
           

            try
            {
                SqlDataReader dr = dbInteraction.getDataReader("AC_GenerateTranRefCodeTemp");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                dr.Close();
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public DataTable GetGLDataForPayments(string mstrTranRefCode)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
                dbInteraction.AddParameter("@PaymentNo", mstrTranRefCode);

                DataTable dt =  GetDataTable(dbInteraction.getDataReader("AC_GetGLDataForPayments"));
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;

            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public SqlDataReader GetBankDataForPayments(string mstrTranRefCode)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@PaymentNo", mstrTranRefCode);

                return dbInteraction.getDataReader("AC_GetBankDataForPayments");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable UpdPaymentCashFlow(dynamic mObject, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@PaymentNo", mObject.PaymentNo);
            dbInteraction.AddParameter("@CashFlowType", mObject.CashFlowType);

            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_UpdPaymentCashFlow", objAuditLog_HeaderMaster, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }

            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public string GetCoOperatingBank()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                string sResult = dbInteraction.executeScalarQuery("AC_GetOperatingBank").ToString().Trim();
                return sResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetCurrencyCodes()
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return dbInteraction.getDataReader("AC_GetCurrencyCodes");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public SqlDataReader GetGstMP()
        //{

        //    dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
        //    try
        //    {
        //        return dbInteraction.getDataReader("AC_GetGstM");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public SqlDataReader GetWHTM()
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return dbInteraction.getDataReader("AC_GetWHTM");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetBankCodes()
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return dbInteraction.getDataReader("AC_GetBankCodes");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader ReverseRefNo(dynamic mObject)
        {
            dynamic myObject = (ExpandoObject)(mObject);
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@ReceiptNo",mObject.ReceiptNo);
                dbInteraction.AddParameter("@UserId", mObject.UserId);

                return dbInteraction.getDataReader("AC_Reverse_Ref_No");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetGnericGLAndMatchTotals(dynamic mObject)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@TranType", mObject.TranType);
            dbInteraction.AddParameter("@TranCode", mObject.TranCode);
            try
            {
                return dbInteraction.getDataReader("AC_GetGnericGLAndMatchTotals");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MatchAllGenericDataPayment(dynamic mObject, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            dynamic myObject = (ExpandoObject)(mObject);
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranRefType", mObject.TranRefType);
            dbInteraction.AddParameter("@MatchTranType", mObject.MatchTranType);
            dbInteraction.AddParameter("@MatchTranCode", mObject.MatchTranCode);
            dbInteraction.AddParameter("@StrRecptNo", mObject.StrRecptNo);
            dbInteraction.AddParameter("@IsMatchReset", mObject.IsMatchReset);
            dbInteraction.AddParameter("@UserId", mObject.UserId);

            try
            {
                dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_MatchAllGenericData");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }

        public void ClearAllGenericDataPayment(dynamic mObject, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranRefType", mObject.TranRefType);
            dbInteraction.AddParameter("@MatchTranType", mObject.MatchTranType);
            dbInteraction.AddParameter("@MatchTranCode", mObject.MatchTranCode);
            dbInteraction.AddParameter("@StrRecptNo", mObject.StrRecptNo);
            dbInteraction.AddParameter("@IsMatchReset", mObject.IsMatchReset);
            dbInteraction.AddParameter("@UserId", mObject.UserId);

            try
            {
                dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_ClearAllGenericData");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }
  
        public DataTable UpdateGenericInvoiceDataPayment(dynamic mObject, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
           dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@StrDataP", mObject.StrDataP);
            dbInteraction.AddParameter("@StrTranType", mObject.StrTranType);
            dbInteraction.AddParameter("@StrTranRefCode", mObject.StrTranRefCode);
            dbInteraction.AddParameter("@StrUserIdP", mObject.StrUserIdP);            
            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_UpdateGenericInvoiceData", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public DataTable UpdatePaymentM(dynamic mObject, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@IsSubmitted", mObject.IsSubmitted);
            dbInteraction.AddParameter("@PaymentNo", mObject.PaymentNo);
            
            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_UpdatePaymentM", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }
        
        public DataTable AddUpdatePayment(clsPayment objPayment, AuditLog_HeaderMaster objAuditLog_HeaderMaster, bool IsAuditRequired,bool var)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@PaymentNo", objPayment.PaymentNo);
            dbInteraction.AddParameter("@PaymentDate", objPayment.PaymentDate);
            dbInteraction.AddParameter("@PaymentTypeCode", objPayment.PaymentTypeCode);
            dbInteraction.AddParameter("@ClientCode", objPayment.ClientCode);
            dbInteraction.AddParameter("@ClientName", objPayment.ClientName);
            dbInteraction.AddParameter("@ClientAdd1", objPayment.ClientAdd1);
            dbInteraction.AddParameter("@ClientAdd2", objPayment.ClientAdd2);
            dbInteraction.AddParameter("@ClientAdd3", objPayment.ClientAdd3);
            dbInteraction.AddParameter("@ClientAdd4", objPayment.ClientAdd4);
            dbInteraction.AddParameter("@LocalAmount", objPayment.LocalAmount);
            dbInteraction.AddParameter("@StmtDesc", objPayment.StmtDesc);
            dbInteraction.AddParameter("@RecptDesc", objPayment.RecptDesc);
            dbInteraction.AddParameter("@UserId", objPayment.UserId);
            dbInteraction.AddParameter("@PaymentSource", objPayment.PaymentSource);
            dbInteraction.AddParameter("@AccMonth", objPayment.AccMonth);

            try
            {
                DataTable dt;
                if (var == true)
                {
                    dt = dbInteraction.getDataReader("AC_AddUpdatePaymentfinal", objAuditLog_HeaderMaster, IsAuditRequired);
                    if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["Result"] != null)
                    {
                        clsACCommon objAccountBAL = new clsACCommon();
                        objPayment.PaymentNo = dt.Rows[0]["Result"].ToString();
                        //objAccountBAL.UpdPaymentStatus(objPayment.PaymentNo, "Y");
                        dynamic mparams = new ExpandoObject();
                        mparams.PaymentNo = objPayment.PaymentNo;
                        mparams.TranType = "Payment";
                        objAccountBAL.UpdPaymentStatus(mparams, objAuditLog_HeaderMaster, true);
                    }
                }
                else
                {
                    dt = dbInteraction.getDataReader("AC_AddUpdatePayment", objAuditLog_HeaderMaster, IsAuditRequired);
                }
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }

            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public DataTable UpdateBatchPost(dynamic mObject, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@SearchType", mObject.SearchType);
            dbInteraction.AddParameter("@SearchString", mObject.SearchString);

            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_UpdateBatchPost", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public string GetCmbDBWHDTax(string gstCode)
        {
            string strTaxRate = "";
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@gstCode ", gstCode);
            try
            {
                SqlDataReader dr =  dbInteraction.getDataReader("AC_CmbDBWHDTax");
                if (dr.Read())
                {
                    strTaxRate = dr["TaxRate"].ToString().Trim();
                }
                dr.Close();
                dbInteraction.CloseSqlConnection();
                return strTaxRate;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetCmbCRWHDTax(string gstCode)
        {
            string strTaxRate = "";
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@gstCode ", gstCode);
            try
            {
                SqlDataReader dr = dbInteraction.getDataReader("AC_CmbDBWHDTax");
                if (dr.Read())
                {
                    strTaxRate = dr["TaxRate"].ToString().Trim();
                }
                dr.Close();
                dbInteraction.CloseSqlConnection();
                return strTaxRate;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetCmbCRWHTAmt(string gstCode)
        {
            string strTaxRate = "";
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@gstCode ", gstCode);
            try
            {
                SqlDataReader dr = dbInteraction.getDataReader("AC_CmbDBWHTAmt");
                if (dr.Read())
                {
                    strTaxRate = dr["TaxRate"].ToString().Trim();
                }
                dr.Close();
                dbInteraction.CloseSqlConnection();
                return strTaxRate;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetCmbDBWHTAmt(string gstCode)
        {
            string strTaxRate = "";
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@gstCode ", gstCode);
            try
            {
                SqlDataReader dr = dbInteraction.getDataReader("AC_CmbDBWHTAmt");
                if (dr.Read())
                {
                    strTaxRate = dr["TaxRate"].ToString().Trim();
                }
                dr.Close();
                dbInteraction.CloseSqlConnection();
                return strTaxRate;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable AddUpdateBankTranForPayment(dynamic mObject, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", mObject.TranNo);
            dbInteraction.AddParameter("@PaymentNo", mObject.PaymentNo);
            dbInteraction.AddParameter("@BankCode", mObject.BankCode);
            dbInteraction.AddParameter("@ChequeNo", mObject.ChequeNo);
            dbInteraction.AddParameter("@ChequeDate", mObject.ChequeDate);
            dbInteraction.AddParameter("@Amount", mObject.Amount);
            dbInteraction.AddParameter("@CurrencyCode", mObject.CurrencyCode);
            dbInteraction.AddParameter("@ExchangeRate", mObject.ExchangeRate);
            dbInteraction.AddParameter("@LocalAmount", mObject.LocalAmount);
            dbInteraction.AddParameter("@UserId", mObject.UserId);           

            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_AddUpdateBankTranForPayment", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }
        public SqlDataReader AddUpdateBankTranForPayment(dynamic mObject)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@TranNo", mObject.TranNo);
            dbInteraction.AddParameter("@PaymentNo", mObject.PaymentNo);
            dbInteraction.AddParameter("@BankCode", mObject.BankCode);
            dbInteraction.AddParameter("@ChequeNo", mObject.ChequeNo);
            dbInteraction.AddParameter("@ChequeDate", mObject.ChequeDate);
            dbInteraction.AddParameter("@Amount", mObject.Amount);
            dbInteraction.AddParameter("@CurrencyCode", mObject.CurrencyCode);
            dbInteraction.AddParameter("@ExchangeRate", mObject.ExchangeRate);
            dbInteraction.AddParameter("@LocalAmount", mObject.LocalAmount);
            dbInteraction.AddParameter("@UserId", mObject.UserId);  

            try
            {
                return dbInteraction.getDataReader("AC_AddUpdateBankTranForPayment");
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }


        public SqlDataReader GetClientInfoForPayment(dynamic mObject)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@PaymentType", mObject.PaymentType);
            dbInteraction.AddParameter("@PaymentFrom", mObject.PaymentFrom);

            try
            {
                SqlDataReader dr = dbInteraction.getDataReader("AC_GetClientDetail");
                return dr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DeleteBankPayment(dynamic mObject, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", mObject.TranNo);
            dbInteraction.AddParameter("@PaymentNo", mObject.PaymentNo);             

            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_DeleteBankPayment", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public DataTable UpdPaymentStatus(dynamic mObject, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@PaymentNo", mObject.PaymentNo);
            dbInteraction.AddParameter("@TranType", mObject.TranType);            

            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_UpdPaymentStatus", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public DataTable UpdateUnMatchedAmount(dynamic mObject, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@StrRefType", mObject.StrRefType);
            dbInteraction.AddParameter("@StrRefCode", mObject.StrRefCode);

            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_UpdateUnMatchedAmount", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public DataTable DeleteNonTradePayment(dynamic mObject, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@TranNo", mObject.TranNo);
            dbInteraction.AddParameter("@PaymentNo", mObject.PaymentNo);

            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_DeleteNonTradePayment", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }

        public DataTable SaveReversePayment(dynamic mObject, AuditLog_HeaderMaster objAuditLogHeader, bool IsAuditRequired)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@ReceiptNo", mObject.ReceiptNo);
            dbInteraction.AddParameter("@UserId", mObject.@UserId);

            try
            {
                DataTable dt = dbInteraction.getDataReader("AC_Save_Reverse_Payment", objAuditLogHeader, IsAuditRequired);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return dt;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }
        }
        public DataTable GetAccountMonth(dynamic mObject)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@Type", mObject.Type);
            
            try
            {
                DataTable dt = GetDataTable(dbInteraction.getDataReader("Ac_getAccountmonth"));
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public DataTable GetGenericMatchData(dynamic mObject)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@TranType", mObject.TranType);
            dbInteraction.AddParameter("@IsMatched", mObject.IsMatched);
            dbInteraction.AddParameter("@MatchTranType", mObject.MatchTranType);
            dbInteraction.AddParameter("@MatchTranCode", mObject.MatchTranCode);
            dbInteraction.AddParameter("@StrRecptNo", mObject.StrRecptNo);
            dbInteraction.AddParameter("@IsMatchReset", mObject.IsMatchReset);
            dbInteraction.AddParameter("@SearchCriteria", mObject.SearchCriteria);
            //dbInteraction.AddParameter("@SortOn", mObject.SortOn);
            dbInteraction.AddParameter("@SortBy", mObject.SortBy);
            try
            {

                DataTable dt = GetDataTable(dbInteraction.getDataReader("AC_GetGenericMatchData"));
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetGenericMatchDataJDP(dynamic mObject)
        {
            dynamic myObject = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@TranType", mObject.TranType);
            dbInteraction.AddParameter("@IsMatched", mObject.IsMatched);
            dbInteraction.AddParameter("@ClientCode", mObject.ClientCode);
            dbInteraction.AddParameter("@InsurerCode", mObject.InsurerCode);
            dbInteraction.AddParameter("@JurnalNo", mObject.JurnalNo);
            dbInteraction.AddParameter("@IsMatchReset", mObject.IsMatchReset);
            dbInteraction.AddParameter("@SearchCriteria", mObject.SearchCriteria);
            dbInteraction.AddParameter("@SoryOn", mObject.SortOn);
            dbInteraction.AddParameter("@SoryBy", mObject.SortBy);
            try
            {
                //DataSet dt = GetDataTable(dbInteraction.getDataReader("AC_GetGenericMatchDataJDP"));
                //return dt;
                string[] tbleName = { "AC_JournalM" };
                return dbInteraction.GetDataset("AC_GetGenericMatchDataJDP", tbleName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        #endregion

        #region matchingenquiry

        public SqlDataReader GetAccountNameList(string strType)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@Type", strType);
            try
            {
                return dbInteraction.getDataReader("AC_GetAccountNameList");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetGenericSearchMatchingSearch(string sqlQuery)
        {
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.Text);
                return dbInteraction.RunSQLWithDataSet(sqlQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion     

        ///// Added By Sheepu
        #region Report

        public SqlDataReader Getreportdate()
        {

            dbInteraction = new DataAccessLayer.DatabaseInteraction(CommandType.Text);
            try
            {
                return dbInteraction.getDataReader("SELECT convert(char(10),getDate(),103) as RecDate");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public DataSet getinsurerdata(string sqlQuery)
        {
            dbInteraction = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
            try
            {


                return dbInteraction.GetDataset("AC_reportInsurerAgentComm  " + sqlQuery + " ");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public DataSet Getdata(string sqlQuery)
        {
            dbInteraction = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return dbInteraction.GetDataset(sqlQuery);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public SqlDataReader Getdataread(string sqlQuery)
        {
            dbInteraction = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return dbInteraction.getDataReader(sqlQuery);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public SqlDataReader GetdatareadBank(string sqlQuery)
        {
            dbInteraction = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return dbInteraction.getDataReader(sqlQuery);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public SqlDataReader GetdatareadforclosingLCH()
        {
            dbInteraction = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return dbInteraction.getDataReader("AC_GetLastClosedYear");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public SqlDataReader GetYearEndClosingReopening(string value)
        {
            dbInteraction = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@pYear", value);
            try
            {
                return dbInteraction.getDataReader("Ac_YearEndClosingReopening");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public SqlDataReader GetYearEndClosing(string value)
        {
            dbInteraction = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@pYear", value);
            try
            {
                return dbInteraction.getDataReader("Ac_YearEndClosing");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public SqlDataReader GetYearEndClosingStatus(string year,string status,int userid)
        {
            dbInteraction = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@year", year);
            dbInteraction.AddParameter("@status", status);
            dbInteraction.AddParameter("@userId", userid);
            try
            {
                return dbInteraction.getDataReader("Ac_YearEndClosingStatus");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetKeyvalue()
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            string sResult = dbInteraction.executeScalarQuery("select KeyValue from Sys_Params where KeyWord='GSTType'").ToString().Trim();
            return sResult;
        }
        public string GetCRGSTAmtRate(string ID)
        {
            string strTaxRate = "";
            try
            {
                dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
                dbInteraction.AddParameter("@ID ", ID);

                SqlDataReader dr = dbInteraction.getDataReader("AC_GetCRGSTRate");
                if (dr.Read())
                {
                    strTaxRate = dr["TaxRate"].ToString().Trim();
                }
                dr.Close();
                dbInteraction.CloseSqlConnection();
                return strTaxRate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SqlDataReader GetDropDownData_DBGSTAmt(string GST_Type_Code)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@GST_Type_Code ", GST_Type_Code);
            try
            {
                return dbInteraction.getDataReader("AC_GetGSTCodeDisplay");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddCommition(decimal FCAmount, string TranCode, Boolean IsCrEntry)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@FCAmount", FCAmount);
            dbInteraction.AddParameter("@TranCode", TranCode);
            dbInteraction.AddParameter("@IsCrEntry", IsCrEntry);
           

            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_AddDirectPaymentEntryForCommition");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }
        public DataSet GetGenericSearchDataForEnquiry(ArrayList argsParams,string Sortby,string SortOn)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

            dbInteraction.AddParameter("@AccountType", argsParams[0]);
            dbInteraction.AddParameter("@TranRefNo", argsParams[1]);
            dbInteraction.AddParameter("@TranRefType", argsParams[2]);
            dbInteraction.AddParameter("@TranRefName", argsParams[3]);
            dbInteraction.AddParameter("@FromDate", argsParams[4]);
            dbInteraction.AddParameter("@ToDate", argsParams[5]);
            dbInteraction.AddParameter("@isSubmitted", argsParams[6]);
            dbInteraction.AddParameter("@ChqNo", argsParams[7]);
            dbInteraction.AddParameter("@ChqDate", argsParams[8]);         
            dbInteraction.AddParameter("@SortBy", Sortby);
            dbInteraction.AddParameter("@SortType", SortOn);
            try
            {
                //DataSet dt = GetDataTable(dbInteraction.getDataReader("AC_GetGenericSearchDataForEnquiry"));
                //return dt;
                //return dbInteraction.GetDataset(dbInteraction.getDataReader("AC_GetGenericSearchDataForEnquiry"));

                string[] tbleName = { "AC_ReceiptM" };
                return dbInteraction.GetDataset("AC_GetGenericSearchDataForEnquiry", tbleName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetGenericSearchDataForMatchingEnquiry(string mstrGridSql)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

          
            try
            {
                //DataSet dt = GetDataTable(dbInteraction.getDataReader("AC_GetGenericSearchDataForEnquiry"));
                //return dt;
                //return dbInteraction.GetDataset(dbInteraction.getDataReader("AC_GetGenericSearchDataForEnquiry"));

                
                return dbInteraction.GetDataset("Ac_GetGenericSearchMatchingSearch" + mstrGridSql.Trim());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SqlDataReader GetDateforMatchingEnquiy()
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            return dbInteraction.getDataReader("SELECT convert(NVARCHAR(40),getdate(),113)");
        }

        public DataSet GetGenericSearchDataForBatchPrintSQLREPORT(string mstrGridSql)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);


            try
            {
                //DataSet dt = GetDataTable(dbInteraction.getDataReader("AC_GetGenericSearchDataForEnquiry"));
                //return dt;
                //return dbInteraction.GetDataset(dbInteraction.getDataReader("AC_GetGenericSearchDataForEnquiry"));


                return dbInteraction.GetDataset("AC_GetGenericSearchDataForBatchPrintSQLREPORT" + mstrGridSql.Trim());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public SqlDataReader GetAccountDetailsforBatchprint(int pBrokerId, string pUserType)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@pBrokerId", pBrokerId);
            dbInteraction.AddParameter("@pUserType", pUserType);
            try
            {
                return dbInteraction.getDataReader("AC_GetClientInfoforDropDown");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetGenericSearchDataForTranList(string mstrGridSql)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);


            try
            {
                //DataSet dt = GetDataTable(dbInteraction.getDataReader("AC_GetGenericSearchDataForEnquiry"));
                //return dt;
                //return dbInteraction.GetDataset(dbInteraction.getDataReader("AC_GetGenericSearchDataForEnquiry"));


                return dbInteraction.GetDataset("AC_GetGenericSearchDataForTranList" + mstrGridSql.Trim());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetStatementOfAccountTelerikRpt(string lstrQuery)
        {
            //dynamic objAccountTelerikRpt = (ExpandoObject)(mObject);

            //dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            //dbInteraction.AddParameter("@CompanyId", objAccountTelerikRpt.CompanyId);
            //dbInteraction.AddParameter("@Month", objAccountTelerikRpt.Month);
            //dbInteraction.AddParameter("@Year", objAccountTelerikRpt.Year);
            //dbInteraction.AddParameter("@AccountType", objAccountTelerikRpt.AccountType);
            //dbInteraction.AddParameter("@AccountCode", objAccountTelerikRpt.AccountCode);
            //dbInteraction.AddParameter("@CurrencyCode", objAccountTelerikRpt.CurrencyCode);
            //dbInteraction.AddParameter("@AccountCodeFrom", objAccountTelerikRpt.AccountCodeFrom);
            //dbInteraction.AddParameter("@AccountCodeTo", objAccountTelerikRpt.AccountCodeTo);
            //dbInteraction.AddParameter("@ClientSource", objAccountTelerikRpt.ClientSource);

            try
            {
                //DataSet dt = GetDataTable(dbInteraction.getDataReader("AC_GetGenericSearchDataForEnquiry"));
                //return dt;
                //return dbInteraction.GetDataset(dbInteraction.getDataReader("AC_GetGenericSearchDataForEnquiry"));

                //string[] tbleName = { "vwStatementofAccountD" };
                //return dbInteraction.GetDataset("EXEC AC_SQLREPORT_GetStatementOfAccount_TelerikRpt " + lstrQuery);
                //return dbInteraction.GetDataset("EXEC AC_GetStatementOfAccount_TelerikRpt_BIB " + lstrQuery);
                return dbInteraction.GetDataset("EXEC AC_SQLREPORT_GetStatementOfAccountH " + lstrQuery);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetLookupTypes(string Module)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

            dbInteraction.AddParameter("@Module", Module);
            try
            {
                return dbInteraction.getDataReader("AC_GetLookupTypes");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SqlDataReader GetClientSourceforStatementofAccount()
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            return dbInteraction.getDataReader("select distinct CSNAME as Client_Source FROM Tm_customer_Cusm B inner join ClientSource C on B.cusm_clientSource = C.csid order by csname");
        }
        public SqlDataReader GetInsurerdata(string Code)
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            return dbInteraction.getDataReader("select in_name from insurer where in_insurer_code='"+Code+"'");
        }

        public SqlDataReader GetAgentInfoforDropDown(int pBrokerId, string pUserType)
        {

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@pBrokerId", pBrokerId);
            dbInteraction.AddParameter("@pUserType", pUserType);
            try
            {
                return dbInteraction.getDataReader("AC_GetAgentInfoforDropDown");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetAccountservicer()
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            return dbInteraction.getDataReader("select distinct accountservicer from ac_premiumdetailsm where isnull(accountservicer,'') != '' and accountservicer != '-1' order by accountservicer");
        }
        public SqlDataReader GetInsurerList(string InsurerType)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@InsurerType", InsurerType);
            return dbInteraction.getDataReader("AC_GetInsurerList");
        }

        public SqlDataReader GetAgentlist()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

            return dbInteraction.getDataReader("AC_GetAgent");
        }
        public SqlDataReader GetInsurerType()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);

            return dbInteraction.getDataReader("AC_GetInsureTypes");
        }
        public SqlDataReader GetCustomerName()
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            return dbInteraction.getDataReader("SELECT CusM_Id as  CusId, isNull(CusM_Name1,'') as CusName  FROM TM_Customer_CusM  WHERE (CusM_Business = 'Customer' or CusM_Business = 'Client')");
        }

        public int UPDATE_AC_JournalM(string strTranRefCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);
            dbInteraction.AddParameter("@strTranRefCode", strTranRefCode);           
            try
            {
                int iResult = dbInteraction.ExecuteNonQuery(CommandType.StoredProcedure, "AC_updatejournal");
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                return iResult;
            }
            catch (Exception ex)
            {
                dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
                throw ex;
            }

        }


        public DataTable UpdateBatchPost(int intTranType, string strTransList)
        {
            //Note:  Below code is commented because store procedure is maintaining the transaction.

            //dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.YES, DatabaseInteraction.SetAutoCommit.OFF);

            //dbInteraction.AddParameter("@SearchType", intTranType);
            //dbInteraction.AddParameter("@SearchString", strTransList);
            //try
            //{
            //    SqlDataReader dr = dbInteraction.getDataReader("AC_UpdateBatchPost");
            //    DataTable dt = new DataTable();
            //    dt.Load(dr);
            //    dr.Close();
            //    dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
            //    return dt;
            //}
            //catch (Exception ex)
            //{
            //    dbInteraction.RollbackTransaction(DatabaseInteraction.CloseConnection.YES);
            //    throw ex;
            //}

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@SearchType", intTranType);
            dbInteraction.AddParameter("@SearchString", strTransList);
            SqlDataReader dr = dbInteraction.getDataReader("AC_UpdateBatchPost");
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            return dt;


        }

        public DataTable UpdateBatchPostDirectInsurer(string intTranType, string strTransList)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@SearchType", intTranType);
            dbInteraction.AddParameter("@SearchString", strTransList);
            SqlDataReader dr = dbInteraction.getDataReader("AC_UpdateBatchPost");
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
        }



        public SqlDataReader GetInsurerTaxref(string Month, string Year, string InsurerCode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@Month", Month);
            dbInteraction.AddParameter("@Year", Year);
            dbInteraction.AddParameter("@InsurerCode", InsurerCode);
            return dbInteraction.getDataReader("AC_GetInsurerTaxRefNos");
        }


        public SqlDataReader GetPremiumdetails(string clientcode, string FromFullcorrect, string FromTocorrect)
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            if (clientcode == "")
            {
                return dbInteraction.getDataReader("select count(*) as countval from ac_premiumdetailsm prem, tm_customer_cusm tm where prem.isposted='Y' and prem.Clientcode=tm.cusm_id and convert(datetime,convert(NVARCHAR(10),PostDate,103),103) between convert(datetime,convert(NVARCHAR(10),'" + FromFullcorrect + "',103),103)  and   convert(datetime,convert(NVARCHAR(10),'" + FromTocorrect + "',103),103) ");
            }
            else
            {
                return dbInteraction.getDataReader("select count(*) as countval  from ac_premiumdetailsm prem, tm_customer_cusm tm where prem.isposted='Y' and prem.Clientcode=tm.cusm_id and prem.clientcode='" + clientcode + "' and convert(datetime,convert(NVARCHAR(10),PostDate,103),103) between convert(datetime,convert(NVARCHAR(10),'" + FromFullcorrect + "',103),103)  and   convert(datetime,convert(NVARCHAR(10),'" + FromTocorrect + "',103),103) ");

            }
        }

        public SqlDataReader GetRepProductInsurer(string InsurerCode, string InsurerType, string FromFullcorrect, string FromTocorrect)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@insurercode", InsurerCode);
            dbInteraction.AddParameter("@InsurerType ", InsurerType);
            dbInteraction.AddParameter("@fromdate", FromFullcorrect);
            dbInteraction.AddParameter("@todate", FromTocorrect);

            return dbInteraction.getDataReader("AC_RepProductInsurer");
        }


        public SqlDataReader GetDataFromDBBrokerage()
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);

            return dbInteraction.getDataReader("select in_insurer_code,in_name from insurer");
            
        }

        public DataSet GetRepAgeingAnalysisReportExcel(dynamic mObject)
        {
            dynamic objAccountReportExcel = (ExpandoObject)(mObject);

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@AccountType", objAccountReportExcel.AccountType);
            dbInteraction.AddParameter("@AccountCode", objAccountReportExcel.AccountCode);
            dbInteraction.AddParameter("@Month", objAccountReportExcel.Month);
            dbInteraction.AddParameter("@Year", objAccountReportExcel.Year);
            dbInteraction.AddParameter("@CurrencyCode", objAccountReportExcel.CurrencyCode);
            dbInteraction.AddParameter("@CompanyId", objAccountReportExcel.CompanyId);
           

            try
            {
                return dbInteraction.GetDataset("AC_RepAgeingAnalysisReport_Excel");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SqlDataReader GetRepCompanyProductivity(string type,string code,string fromdate,string todate,string includesub)
        {
            

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@type", type);
            dbInteraction.AddParameter("@code", code);
            dbInteraction.AddParameter("@fromdate", fromdate);
            dbInteraction.AddParameter("@todate", todate);
            dbInteraction.AddParameter("@includesub", includesub);
            try
            {
                return dbInteraction.getDataReader("AC_RepCompanyProductivity");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SqlDataReader GetMonthYear()
        {
            dbInteraction = new DatabaseInteraction(CommandType.Text);
            return dbInteraction.getDataReader("SELECT month(getdate()) as mon,year(getdate()) as yr");
        }

        public SqlDataReader GetRepLoantoPremium(string fromdate, string todate)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@FromDate", fromdate);
            dbInteraction.AddParameter("@ToDate", todate);           
            try
            {              
                return dbInteraction.getDataReader("Ac_RepLoantoPremium");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SqlDataReader GetRepInsurerInformation(string insurercode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@insurercode", insurercode);
            
            try
            {
                return dbInteraction.getDataReader("AC_RepInsurerInformation");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SqlDataReader GetRepClientInformation(string clientCode,string type)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@clientcode", clientCode);
            dbInteraction.AddParameter("@type", type);

            try
            {
                return dbInteraction.getDataReader("AC_RepClientInformation");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SqlDataReader GetRepIntroducerInformation(string introducercode)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@introducercode", introducercode);
          

            try
            {
                return dbInteraction.getDataReader("AC_RepIntroducerInformation");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SqlDataReader GetRepPremiumPolicyReport(string type,string clientcode,string fromdate,string todate,string debitnote,string policyno,string status)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@type", type);
            dbInteraction.AddParameter("@clientcode", clientcode);
            dbInteraction.AddParameter("@fromdate", fromdate);
            dbInteraction.AddParameter("@todate", todate);
            dbInteraction.AddParameter("@debitnote", debitnote);
            dbInteraction.AddParameter("@policyno", policyno);
            dbInteraction.AddParameter("@status", status);
            try
            {
                return dbInteraction.getDataReader("AC_RepPremiumPolicyReport");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetRepClientReceipt(string Insurercode, string cmbpaid, string fromdate, string todate)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@Insurercode", Insurercode);
            dbInteraction.AddParameter("@cmbpaid", cmbpaid);
            dbInteraction.AddParameter("@fromdate", fromdate);
            dbInteraction.AddParameter("@todate", todate);            
            try
            {
                return dbInteraction.getDataReader("AC_RepClientReceipt");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetReceiptListing(string searchstring, string Month, string Year, string TranForm, string TranTo, string CurrencyCode, string isposted, string RepType)
        {
           

            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@searchString",searchstring );
            dbInteraction.AddParameter("@Month", Month);
            dbInteraction.AddParameter("@Year",  Year);
            dbInteraction.AddParameter("@TranFrom",TranForm);
            dbInteraction.AddParameter("@TranTo", TranTo);
            dbInteraction.AddParameter("@CurrencyCode", CurrencyCode);
            dbInteraction.AddParameter("@isposted", isposted);
            dbInteraction.AddParameter("@RepType", RepType);
            try
            {
                return dbInteraction.GetDataset("AC_SQLREPORT_ReceiptListing_LCH");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public SqlDataReader GetMonthYear()
        //{
        //    dbInteraction = new DatabaseInteraction(CommandType.Text);
        //    return dbInteraction.getDataReader("SELECT month(getdate()) as mon,year(getdate()) as yr");
        //}

        public DataSet GetDefferedPostingSchedule(string ScheduleName)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.NO, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {
                dbInteraction.AddParameter("@ScheduleName", ScheduleName);

                string[] tbleName = { "ServiceSchedule" };
                return dbInteraction.GetDataset("proc_AC_GetDefferedPostingSchedule", tbleName);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DataSet AddUpdateDefferedPostingSchedule(string ScheduleName, char ScheduleFrequency, int ScheduleDay, int ScheduleTime, string EffectiveFrom, string EffectiveTo, string @Action) //, string ServiceType
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure, DatabaseInteraction.MaintainTransaction.NO, DatabaseInteraction.SetAutoCommit.OFF);
            try
            {

                dbInteraction.AddParameter("@ScheduleName", ScheduleName);
                dbInteraction.AddParameter("@ScheduleFrequency", ScheduleFrequency);
                dbInteraction.AddParameter("@ScheduleDay", ScheduleDay);
                dbInteraction.AddParameter("@ScheduleTime", ScheduleTime);
                dbInteraction.AddParameter("@EffectiveFrom", EffectiveFrom);
                dbInteraction.AddParameter("@EffectiveTo", EffectiveTo);
                dbInteraction.AddParameter("@Action", @Action);
                //dbInteraction.AddParameter("@ServiceType", ServiceType);

                string[] tbleName = { "proc_AC_DefferedPostingSchedule" };
                return dbInteraction.GetDataset("proc_AC_DefferedPostingSchedule", tbleName);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public DataSet GetJournalListing(string QueryFilter, string Fdate, string Tdate, string TranFrom, string TranTo, string isposted)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@QueryFilter", QueryFilter);
            dbInteraction.AddParameter("@Fdate", Fdate);
            dbInteraction.AddParameter("@Tdate", Tdate);
            dbInteraction.AddParameter("@TranFrom", TranFrom);
            dbInteraction.AddParameter("@TranTo", TranTo);
            dbInteraction.AddParameter("@isposted", isposted);            
            try
            {
                return dbInteraction.GetDataset("AC_SQLREPORT_JournalListing_LCH");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // Account receivable Audit Log


        public DataSet GetGenericSearchDataForAuditLog(ArrayList argsParams, string Sortby, string SortOn)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@AccountType", argsParams[0]);
            dbInteraction.AddParameter("@TranRefNo", argsParams[1]);
            dbInteraction.AddParameter("@TranRefType", argsParams[2]);
            dbInteraction.AddParameter("@TranRefName", argsParams[3]);
            dbInteraction.AddParameter("@isSubmitted", argsParams[4]);
            dbInteraction.AddParameter("@SortBy", Sortby);
            dbInteraction.AddParameter("@SortType", SortOn);           
            try
            {
                //return dbInteraction.GetDataset("AC_GetGenericSearchDataForAuditLOG");
                string[] tbleName = { "AC_JournalM" };
                return dbInteraction.GetDataset("AC_GetGenericSearchDataForAuditLOG", tbleName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetGenericSearchDataForPayableAuditLog(ArrayList argsParams, string Sortby, string SortOn)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@AccountType", argsParams[0]);
            dbInteraction.AddParameter("@TranRefNo", argsParams[1]);
            dbInteraction.AddParameter("@TranRefType", argsParams[2]);
            dbInteraction.AddParameter("@TranRefName", argsParams[3]);
            dbInteraction.AddParameter("@isSubmitted", argsParams[4]);
            dbInteraction.AddParameter("@SortBy", Sortby);
            dbInteraction.AddParameter("@SortType", SortOn);
            try
            {
                //return dbInteraction.GetDataset("AC_GetGenericSearchDataForAuditLOG");
                string[] tbleName = { "AC_PaymentM" };
                return dbInteraction.GetDataset("AC_GetGenericSearchDataForPayableAuditLOG", tbleName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetClaimTimeBarReport(clsClaimTimeReport objReportParams)
        {
            DataAccess dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { 
                objReportParams.LossFromDate, 
                objReportParams.LossToDate, 
                objReportParams.ClientName,
                objReportParams.ClientCode,               
                objReportParams.MainClass, 
                objReportParams.ClaimStatus
            };
            try
            {
                return dataAccess.LoadDataSet(parameters, "P_RptClaimTimeBar", "RptClaimTimeBar");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

//Added by Apurva
        public DataSet DivisionalGroupingListing(clsDivisionalGropuing clsDivGrouping)
        {
            DataAccess dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
                clsDivGrouping.BillingFrom, 
                clsDivGrouping.BillingTo, 
                clsDivGrouping.POIFrom,
                clsDivGrouping.POITo,               
                clsDivGrouping.ClosingSlipNo, 
                clsDivGrouping.InsuredName,
                clsDivGrouping.ClientCode,
                clsDivGrouping.IntroducerCode,
                clsDivGrouping.AccountServicer,
                clsDivGrouping.DivisionalGrouping,
                clsDivGrouping.Insurer,
                clsDivGrouping.PolicySource,
                clsDivGrouping.ClientSource
                ,clsDivGrouping.AccountingMonthFrom
                ,clsDivGrouping.AccountingMonthTo
                ,clsDivGrouping.ReportBy,
                clsDivGrouping.UserId
            };
            try
            {
                return dataAccess.LoadDataSet(parameters, "P_DivisionGrouping_SearchListing", "DivisionalGroupingListing");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet MasterClientEnquiry(clsMasterClientEnquiry objMasterClientReport)
        {
            DataAccess dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
                objMasterClientReport.ReportType,
                objMasterClientReport.BillingFrom, 
                objMasterClientReport.BillingTo,           
                objMasterClientReport.InsuredName,
                objMasterClientReport.ClientCode,
                objMasterClientReport.AccountServicer,
                objMasterClientReport.PolicyNo,
                objMasterClientReport.Class,
              

            };
            try
            {
                return dataAccess.LoadDataSet(parameters, "P_MasterClientEnquiry_Search", "MasterClientEnquiry");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet MasterClientEnquiryListing(string ClientCode )
        {
            DataAccess dataAccess = new DataAccess();
            Object[] parameters = new Object[] { ClientCode };
            try
            {
                return dataAccess.LoadDataSet(parameters, "P_MasterClientEnquiry_Listing", "MasterClientEnquiryListing");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
                
        public DataTable GetTimeStampDetails(string id, string idFieldName, string tableName)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@Id", id);
            dbInteraction.AddParameter("@IdFieldName", idFieldName);
            dbInteraction.AddParameter("@TableName", tableName);
            try
            {
                SqlDataReader dr = dbInteraction.getDataReader("P_GetTimeStampDetail");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                dr.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetApprovalInfo(string EntityID, string EntityType)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@EntityID", EntityID);
            dbInteraction.AddParameter("@EntityType", EntityType);
            try
            {
                SqlDataReader dr = dbInteraction.getDataReader("Proc_GetApprovalInfo");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                dr.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetReceiptInfo(string EntityID)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@ReceiptNo", EntityID);
           try
            {
                SqlDataReader dr = dbInteraction.getDataReader("AC_GetRecptData");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                dr.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetPaymentInfo(string EntityID)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@PaymentNo", EntityID);
            try
            {
                SqlDataReader dr = dbInteraction.getDataReader("AC_GetPaymentData");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                dr.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetJournalInfo(string EntityID)
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            dbInteraction.AddParameter("@JournalNo", EntityID);
            try
            {
                SqlDataReader dr = dbInteraction.getDataReader("AC_GetJournalData");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dbInteraction.CommitTransaction(DatabaseInteraction.CloseConnection.YES);
                dr.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ProcessOfAccountApproval(AuditLog_HeaderMaster objAuditLogHeader,string entityID, string EntityTypeID, string EntityStatus, string intCurrentUserid, string CallerModule = "", string EntityVersionID = "1")
        {
            try
            {
                // Button btn = (Button)sender;
                 string id = "";// btn.ID;
                // string entityID = btn.Attributes["EntityId"];
                // string EntityTypeID = btn.Attributes["EntityTypeID"];
                ProcessMaster objProcessM = new ProcessMaster()
                {
                    EntityStatus = EntityStatus,
                    EntityTypeID = EntityTypeID.ToString().ToUpper()
                };
                EntityApproval objEntityProcess = new EntityApproval(objProcessM, "");
                string canApprovalActivities = objEntityProcess.GetApprovalActivities(EntityTypeID);
                clsApprovalProcess.EntityType EntityTy = (clsApprovalProcess.EntityType)Enum.Parse(typeof(clsApprovalProcess.EntityType), EntityTypeID.ToUpper());
                string CallerBy = CallerModule;
                CallerModule = "";
                List<BusinessAccessLayer.Common.ProcessMaster> lstProcessM = objEntityProcess.GetEntityProcess(entityID, EntityVersionID, EntityTy, EntityStatus, CallerModule, Convert.ToInt32(intCurrentUserid));
                ProcessMaster objProcessM1 = null;
                switch (CallerBy)
                        {
                      case "Approv":
                          objProcessM1 = new ProcessMaster()
                          {
                              ProcessId = lstProcessM[0].ProcessId,
                              EntityStatus = lstProcessM[0].EntityStatus,
                              EntityTypeID = lstProcessM[0].EntityTypeID
                          };
                          id = lstProcessM[0].ProcessCode;
                          break;
                      case "Reject":
                          objProcessM1 = new ProcessMaster()
                          {
                              ProcessId = lstProcessM[1].ProcessId,
                              EntityStatus = lstProcessM[1].EntityStatus,
                              EntityTypeID = lstProcessM[1].EntityTypeID
                          };
                          id = lstProcessM[1].ProcessCode;
                          break;
                        }
                 

                
                // Session["EntityStatus"] = btn.Attributes["EntityStatus"];
                DataTable Edata=null;
                
                switch(EntityTypeID.ToUpper())
                {
                    case "RECEIPT":
                        clsReciept objclsReciept = new clsReciept();
                        Edata= GetReceiptInfo(entityID);
                        if(Edata!=null && Edata.Rows.Count>0)
                        {
                            objclsReciept.ReceiptNo =entityID;
                            objclsReciept.ReceiptDate = Convert.ToString(Edata.Rows[0]["RecDate"]);
                            string lstrReceiptDateDD = "", lstrReceiptDateMM = "", lstrReceiptDateYY = "", lstrRecDate="";
                            if (!string.IsNullOrEmpty(objclsReciept.ReceiptDate))
                            {
                                if (objclsReciept.ReceiptDate.Split('/').Length >= 2)
                                {
                                   lstrReceiptDateDD= objclsReciept.ReceiptDate.Split('/')[0];
                                   lstrReceiptDateMM = objclsReciept.ReceiptDate.Split('/')[1];
                                   lstrReceiptDateYY = objclsReciept.ReceiptDate.Split('/')[2];
                                }
                            }
                            if (lstrReceiptDateDD != "" && lstrReceiptDateMM != "" && lstrReceiptDateYY != "") lstrRecDate = lstrReceiptDateMM + "/" + lstrReceiptDateDD + "/" + lstrReceiptDateYY;
                            else lstrRecDate = "";
                            objclsReciept.ReceiptDate = lstrRecDate;
                            objclsReciept.ReceiptTypeCode =Convert.ToString(Edata.Rows[0]["ReceiptTypeCode"]);
                            objclsReciept.ClientCode =Convert.ToString(Edata.Rows[0]["ClientCode"]); 
                            objclsReciept.ClientName =Convert.ToString(Edata.Rows[0]["ClientName"]);
                            objclsReciept.ClientAdd1 =Convert.ToString(Edata.Rows[0]["ClientAdd1"]); 
                            objclsReciept.ClientAdd2 =Convert.ToString(Edata.Rows[0]["ClientAdd2"]); 
                            objclsReciept.ClientAdd3 =Convert.ToString(Edata.Rows[0]["ClientAdd3"]); 
                            objclsReciept.ClientAdd4 =Convert.ToString(Edata.Rows[0]["ClientAdd4"]); 
                            objclsReciept.LocalAmount =Convert.ToDecimal(Edata.Rows[0]["LocalAmount"]);
                            objclsReciept.StmtDesc =Convert.ToString(Edata.Rows[0]["StmtDesc"]);
                            objclsReciept.RecptDesc =Convert.ToString(Edata.Rows[0]["RecptDesc"]);
                            objclsReciept.UserId =Convert.ToInt32(intCurrentUserid);
                            objclsReciept.ReceiptSource = Convert.ToString(Edata.Rows[0]["ReceiptSource"]);
                            objclsReciept.Accdate =Convert.ToString(Edata.Rows[0]["AccMonth"]);
                            objclsReciept.Status = objProcessM1.EntityStatus; //Convert.ToString(Edata.Rows[0]["ReceiptStatus"]);
                            objclsReciept.AuditLogHeader = objAuditLogHeader;
                            EntityApproval objEntityApprove = new EntityApproval(objProcessM1, id);
                            DataSet dsResult = objEntityApprove.Process(objclsReciept);
                            EntityApproval enApp = new EntityApproval();
                            enApp.SetEntityStatus(objclsReciept.ReceiptNo, "Receipt", objProcessM1.EntityStatus);
                        }
                        break;
                        case "PAYMENT":
                        Edata = GetPaymentInfo(entityID);
                        if (Edata != null && Edata.Rows.Count > 0)
                        {
                            clsPayment objPayment = new clsPayment();
                            objPayment.PaymentNo = entityID;
                            objPayment.PaymentDate = Convert.ToString(Edata.Rows[0]["RecDate"]);
                            string lstrReceiptDateDD = "", lstrReceiptDateMM = "", lstrReceiptDateYY = "", lstrRecDate = "";
                            if (!string.IsNullOrEmpty(objPayment.PaymentDate))
                            {
                                if (objPayment.PaymentDate.Split('/').Length >= 2)
                                {
                                    lstrReceiptDateDD = objPayment.PaymentDate.Split('/')[0];
                                    lstrReceiptDateMM = objPayment.PaymentDate.Split('/')[1];
                                    lstrReceiptDateYY = objPayment.PaymentDate.Split('/')[2];
                                }
                            }
                            if (lstrReceiptDateDD != "" && lstrReceiptDateMM != "" && lstrReceiptDateYY != "") lstrRecDate = lstrReceiptDateMM + "/" + lstrReceiptDateDD + "/" + lstrReceiptDateYY;
                            else lstrRecDate = "";
                            objPayment.PaymentDate = lstrRecDate;
                            objPayment.PaymentTypeCode = Convert.ToString(Edata.Rows[0]["PaymentTypeCode"]);
                            objPayment.ClientCode = Convert.ToString(Edata.Rows[0]["ClientCode"]);
                            objPayment.ClientName = Convert.ToString(Edata.Rows[0]["ClientName"]);
                            objPayment.ClientAdd1 = Convert.ToString(Edata.Rows[0]["ClientAdd1"]);
                            objPayment.ClientAdd2 = Convert.ToString(Edata.Rows[0]["ClientAdd2"]);
                            objPayment.ClientAdd3 = Convert.ToString(Edata.Rows[0]["ClientAdd3"]);
                            objPayment.ClientAdd4 = Convert.ToString(Edata.Rows[0]["ClientAdd4"]);
                            objPayment.LocalAmount = Convert.ToDecimal(Edata.Rows[0]["LocalAmount"]);
                            objPayment.StmtDesc = Convert.ToString(Edata.Rows[0]["StmtDesc"]);
                            objPayment.RecptDesc = Convert.ToString(Edata.Rows[0]["RecptDesc"]);
                            objPayment.UserId = Convert.ToInt32(intCurrentUserid);
                            objPayment.PaymentSource = Convert.ToString(Edata.Rows[0]["PaymentSource"]);
                            objPayment.AccMonth = Convert.ToString(Edata.Rows[0]["AccMonth"]);
                            objPayment.Status = objProcessM1.EntityStatus; //Convert.ToString(Edata.Rows[0]["ReceiptStatus"]);
                            objPayment.AuditLogHeader = objAuditLogHeader;
                            EntityApproval objEntityApprove = new EntityApproval(objProcessM1, id);
                            DataSet dsResult = objEntityApprove.Process(objPayment);
                            EntityApproval enApp = new EntityApproval();
                            enApp.SetEntityStatus(objPayment.PaymentNo, "Payment", objProcessM1.EntityStatus);
                            dynamic mparams = new ExpandoObject();
                            mparams.PaymentNo = objPayment.PaymentNo;
                            mparams.TranType = "Y";
                            this.UpdPaymentStatus(mparams, objAuditLogHeader, false);
                        }
                        break;
                        case "JOURNAL":
                        Edata = GetJournalInfo(entityID);
                        if (Edata != null && Edata.Rows.Count > 0)
                        {
                            clsDirectInsurerPayment objJournalsNew = new clsDirectInsurerPayment();
                            objJournalsNew.JournalNo = entityID;
                            objJournalsNew.JournalDate = Convert.ToString(Edata.Rows[0]["RecDate"]);
                            string lstrReceiptDateDD = "", lstrReceiptDateMM = "", lstrReceiptDateYY = "", lstrRecDate = "";
                            if (!string.IsNullOrEmpty(objJournalsNew.JournalDate))
                            {
                                if (objJournalsNew.JournalDate.Split('/').Length >= 2)
                                {
                                    lstrReceiptDateDD = objJournalsNew.JournalDate.Split('/')[0];
                                    lstrReceiptDateMM = objJournalsNew.JournalDate.Split('/')[1];
                                    lstrReceiptDateYY = objJournalsNew.JournalDate.Split('/')[2];
                                }
                            }
                            if (lstrReceiptDateDD != "" && lstrReceiptDateMM != "" && lstrReceiptDateYY != "") lstrRecDate = lstrReceiptDateMM + "/" + lstrReceiptDateDD + "/" + lstrReceiptDateYY;
                            else lstrRecDate = "";
                            objJournalsNew.JournalDate = lstrRecDate;
                            objJournalsNew.JournalTypeCode = Convert.ToString(Edata.Rows[0]["JournalTypeCode"]);
                            objJournalsNew.ClientCode = Convert.ToString(Edata.Rows[0]["ClientCode"]);
                            objJournalsNew.ClientName = Convert.ToString(Edata.Rows[0]["ClientName"]);
                            objJournalsNew.ClientAdd1 = Convert.ToString(Edata.Rows[0]["ClientAdd1"]);
                            objJournalsNew.ClientAdd2 = Convert.ToString(Edata.Rows[0]["ClientAdd2"]);
                            objJournalsNew.ClientAdd3 = Convert.ToString(Edata.Rows[0]["ClientAdd3"]);
                            objJournalsNew.ClientAdd4 = Convert.ToString(Edata.Rows[0]["ClientAdd4"]);
                            objJournalsNew.LocalAmount = Convert.ToDecimal(Edata.Rows[0]["LocalAmount"]);
                            objJournalsNew.StmtDesc = Convert.ToString(Edata.Rows[0]["StmtDesc"]);
                            objJournalsNew.JournalDesc = Convert.ToString(Edata.Rows[0]["JournalDesc"]);
                            objJournalsNew.UserId = Convert.ToInt32(intCurrentUserid);
                            objJournalsNew.JournalSource = Convert.ToString(Edata.Rows[0]["JournalSource"]);
                            objJournalsNew.AccMonth = Convert.ToString(Edata.Rows[0]["AccMonth"]);
                            objJournalsNew.Status = objProcessM1.EntityStatus; //Convert.ToString(Edata.Rows[0]["ReceiptStatus"]);
                            objJournalsNew.AuditLogHeader = objAuditLogHeader;
                            objJournalsNew.JournalInsurerDate = null;
                            objJournalsNew.InsurerAmount = 0;
                            objJournalsNew.InsurerCurrency = null;
                            objJournalsNew.InsurerBankName = null;
                            objJournalsNew.InsurerTypeCode = null;
                            objJournalsNew.InsurerCode = null;
                            objJournalsNew.InsurerName = null;
                            objJournalsNew.IsPayment = null;
                            EntityApproval objEntityApprove = new EntityApproval(objProcessM1, id);
                            DataSet dsResult = objEntityApprove.Process(objJournalsNew);
                            EntityApproval enApp = new EntityApproval();
                            if (dsResult != null && dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count>0)
                            {
                                objJournalsNew.JournalNo = dsResult.Tables[0].Rows[0][0].ToString();
                            }
                            enApp.SetEntityStatus(objJournalsNew.JournalNo, "Journal", objProcessM1.EntityStatus);
                            this.funUpdateJournalStatus(objJournalsNew.JournalNo, "Y");
                        }
                        break;

                }

              string status = objProcessM1.EntityStatus;
              clsACCommon objAccountBAL = new clsACCommon();
              string mailreq = "", mailapp = "", sub = "", entity = "";
              //int intCurrentUserid = int.Parse(Session["UserId"].ToString());
              DataTable dt = null;
              DataSet ds1 = null;
              clsUserMasterManager objActivityApprovalAuthorityMgr = new clsUserMasterManager();
              switch (EntityTypeID.ToUpper())
              {
                  case "RECEIPT":
                      entity = "Receipt";
                      dt = objAccountBAL.GetApprovalInfo(entityID, "Receipt");
                      if (dt != null && dt.Rows.Count > 0)
                      {
                          string requserid = dt.Rows[0]["userid"].ToString();
                          ds1 = objActivityApprovalAuthorityMgr.LoadActivityApprovalList(requserid);
                          if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                          {
                              try
                              {
                                  DataRow[] drr = ds1.Tables[0].Select("ActivityID='Receipt'");
                                  if (drr.Length > 0)
                                  {
                                      mailreq = drr[0]["Emailrequester"].ToString();
                                      mailapp = drr[0]["EmailAuthorityLevelI"].ToString();
                                  }
                              }
                              catch { }
                          }
                      }
                      break;
                  case "PAYMENT":
                      entity = "Payment";
                      dt = objAccountBAL.GetApprovalInfo(entityID, "Payment");
                      if (dt != null && dt.Rows.Count > 0)
                      {
                          string requserid = dt.Rows[0]["userid"].ToString();
                          ds1 = objActivityApprovalAuthorityMgr.LoadActivityApprovalList(requserid);
                          if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                          {
                              try
                              {
                                  DataRow[] drr = ds1.Tables[0].Select("ActivityID='Payment'");
                                  if (drr.Length > 0)
                                  {
                                      mailreq = drr[0]["Emailrequester"].ToString();
                                      mailapp = drr[0]["EmailAuthorityLevelI"].ToString();
                                  }
                              }
                              catch { }
                          }
                      }
                       break;
                  case "JOURNAL":
                      entity = "Journal";
                      dt = objAccountBAL.GetApprovalInfo(entityID, "Journal");
                      if (dt != null && dt.Rows.Count > 0)
                      {
                          string requserid = dt.Rows[0]["userid"].ToString();
                          ds1 = objActivityApprovalAuthorityMgr.LoadActivityApprovalList(requserid);
                          if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                          {
                              try
                              {
                                  DataRow[] drr = ds1.Tables[0].Select("ActivityID='Journal'");
                                  if (drr.Length > 0)
                                  {
                                      mailreq = drr[0]["Emailrequester"].ToString();
                                      mailapp = drr[0]["EmailAuthorityLevelI"].ToString();
                                  }
                              }
                              catch { }
                          }
                      }
                      break;
              }
              switch (status)
                {
                    case "L1REJ":
                        sub = entity + " Reject.";
                        if (!string.IsNullOrEmpty(mailreq) && !string.IsNullOrEmpty(mailapp))
                        {
                            try
                            {
                                bool mail = UIHelper.SentMail(mailapp, mailreq, sub, "Hi, your " + entity + " :" + entityID + " have rejected .<br> Thanks,<br>System.");
                            }
                            catch { }
                        }

                        break;
                    case "APPRVD":
                        sub = entity + " Approved.";
                        if (!string.IsNullOrEmpty(mailreq) && !string.IsNullOrEmpty(mailapp))
                        {
                            try
                            {
                                bool mail = UIHelper.SentMail(mailapp, mailreq, sub, "Hi, your " + entity + " :" + entityID + " have approved .<br> Thanks,<br>System.");
                            }
                            catch { }
                        }

                        break;
                    case "PAPRV":
                        sub = entity + " Approval Request.";
                        if (!string.IsNullOrEmpty(mailreq) && !string.IsNullOrEmpty(mailapp))
                        {
                            try
                            {
                                bool mail = UIHelper.SentMail(mailreq, mailapp, sub, "Hi, Please Approve the " + entity + " :" + entityID + "<br> Thanks,<br>System.");
                            }
                            catch { }
                        }
                        break;
                    default:

                        break;

                }
          }
            catch (Exception ex)
            {
               //lblMessage.Text = ex.Message;
            }
        }

        public SqlDataReader GetProfitCentre()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return dbInteraction.getDataReader("AC_GetProfitCentre");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader GetFundCode()
        {
            dbInteraction = new DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                return dbInteraction.getDataReader("AC_GetFundCode");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet DeferredBrokerageEnq(string documentNo,string AsAt)
        {
            DataAccess dataAccess = new DataAccess();
            Object[] parameters = new Object[] { documentNo , AsAt};
            try
            {
                return dataAccess.LoadDataSet(parameters, "AC_DeferredRevenueEnquiry", "DeferredRevenueEnquiry");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet PushDeferredBrokToGLTran(string strJobNumber, string SchID)
        {
            DataAccess dataAccess = new DataAccess();
            Object[] parameters = new Object[] { SchID, strJobNumber };
            return dataAccess.LoadDataSetWithTimeout(parameters, "PushDeferredBrokToGLTran", "PushDeferredBrok");
        }
    }
}
