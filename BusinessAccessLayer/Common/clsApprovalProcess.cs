using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Data.SqlClient;

namespace BusinessAccessLayer.Common
{
   public abstract class clsApprovalProcess
    {
        public clsApprovalProcess()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public ProcessMaster ProcessMasterInfo
        {
            get;
            set;
        }

        #region Const defination for different processes
        
        //1 level Approval
        public const int CLIENT_APPROVAL_PROCESS = 1;
        public const int CLIENT_APPROVED_PROCESS = 2;
        public const int CLIENT_REJECT_PROCESS = 3;
        // 2 level Approval
        public const int CLIENT_1ST_APPROVED_PROCESS = 4;
        public const int CLIENT_1ST_REJECT_PROCESS = 5;
        public const int CLIENT_2ND_APPROVED_PROCESS = 6;
        public const int CLIENT_2ND_REJECT_PROCESS = 7;
        #endregion

        #region Const declaration for process status
        public const string PROCESS_STATUS_PENDING = "PENDING";
        public const string PROCESS_STATUS_COMPLETE = "COMPLETE";
        public const string PROCESS_STATUS_REJECT = "REJECT";
        #endregion

        #region Const decclaration for Client status
        public const string CLIENT_STATUS_PENDING = "NPEND";
        public const string CLIENT_STATUS_APPROVED = "APPRV";
        public const string CLIENT_STATUS_REJECTED = "L1REJ";
        public const string CLIENT_STATUS_1ST_APPROVED = "L2PEN";
        public const string CLIENT_STATUS_1ST_REJECT = "L1REJ";
        public const string CLIENT_STATUS_2ND_APPROVED = "APPRV";
        public const string CLIENT_STATUS_2ND_REJECTED = "L2REJ";
        
        #endregion
        #region Const decclaration for Receipt status
        public const string RECEIPT_STATUS_PENDING = "PAPRV";
        public const string RECEIPT_STATUS_APPROVED = "APPRVD";
        public const string RECEIPT_STATUS_REJECTED = "L1REJ";
        public const string RECEIPT_STATUS_1ST_APPROVED = "L1APPRVD";
        public const string RECEIPT_STATUS_1ST_REJECT = "L1REJ";
        public const string RECEIPT_STATUS_2ND_APPROVED = "APPRVD";
        public const string RECEIPT_STATUS_2ND_REJECTED = "L2REJ";

        #endregion

        #region struct declaration for Process Types

        public struct ProcessType
        {
            public const string CLIENT_APPROVAL     = "ClApproval";
            public const string INSURER_APPROVAL    = "InsApproval";
            public const string INTRUDUCER_APPROVAL = "IndApproval";
            public const string PROSPECT_APPROVAL   = "ProsApproval";
            public const string REINSURER_APPROVAL  = "ReinApproval";
            public const string CEDANT_APPROVAL     = "CedApproval";
            public const string DEBITNOTE_APPROVAL  = "DebtNApproval";
            public const string CREDITNOTE_APPROVAL = "CrdtNApproval";
            public const string RECIEPT_APPROVAL    = "RecptApproval";
            public const string PAYMENT_APPROVAL    = "PaymtApproval";
            public const string JOURNAL_APPROVAL    = "JournApproval";
        }
        #endregion

        #region enum declaration for Entity Types

        public enum EntityType
        {
            [Description("Client")]     CLIENT      = 1,
            [Description("Insurer")]    INSURER     = 2,
            [Description("Introducer")] INTRODUCER  = 3,
            [Description("Prospect")]   PROSPECT    = 4,
            [Description("Reinsurer")]  REINSURER   = 5,
            [Description("Cedant")]     CEDANT      = 6,
            [Description("DebitNote")]  DEBITNOTE   = 7,
            [Description("CreditNote")] CREDITNOTE  = 8,
            [Description("Receipt")]    RECEIPT     = 9,
            [Description("Payment")]    PAYMENT     = 10,
            [Description("Journal")]    JOURNAL     = 11
        }
        #endregion

        public System.Text.StringBuilder TransactionDescription = new System.Text.StringBuilder();
        public System.Text.StringBuilder TransactionChangeXML = new System.Text.StringBuilder();
        //public DataWrapper objWrapper;
        public DataAccessLayer.DatabaseInteraction objWrapper;

        #region Database Transaction function
        public void BeginTransaction()
        {
            if (objWrapper == null)
                //objWrapper = new DataWrapper(ClsCommon.ConnStr, CommandType.StoredProcedure, DataWrapper.MaintainTransaction.YES, DataWrapper.SetAutoCommit.OFF);
                objWrapper = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure, DataAccessLayer.DatabaseInteraction.MaintainTransaction.YES, DataAccessLayer.DatabaseInteraction.SetAutoCommit.OFF);

        }

        public void CommitTransaction()
        {
            objWrapper.CommitTransaction(DataAccessLayer.DatabaseInteraction.CloseConnection.YES);
        }

        public void RollbackTransaction()
        {
            objWrapper.RollbackTransaction(DataAccessLayer.DatabaseInteraction.CloseConnection.YES);
        }
        #endregion

        #region Common Process virtual function

        protected virtual bool OnSetEntityStatus()
        {
            return true;
        }

        protected virtual bool OnCheckProcessEligibility()
        {
            return false;
        }

        protected virtual bool OnWriteTransactionLog()
        {
            return true;
        }
        public virtual DataSet Approve(object objEntity)
        {
            DataSet dsApprove = new DataSet();
            return dsApprove;
        }
        public virtual DataSet Reject(object objEntity)
        {
            DataSet dsApprove = new DataSet();
            return dsApprove;
        }

        #region getProcess Object
        protected virtual EntityProcesses getProcessObject(string loginUserId, EntityType entityType, string EntityStatus,string EntityId,string EntityVersionId)
        {
            // prepare and return default Object
            return new EntityProcesses()
            {
                EntityID = EntityId,
                EntityTypeID = GetEnumString(entityType),
                EntityCurrentStatus = EntityStatus,
                EntityNewVersionID = EntityVersionId,
                EntityPreviousStatus = EntityStatus,
                EntityVersionID = EntityVersionId,
                IsActive = "Y",
                ProcessEffectiveDate = DateTime.Now,
                ProcessStatus = PROCESS_STATUS_PENDING,
                CreatedBy = loginUserId,
                CreatedDate = DateTime.Now.ToShortDateString(),
                RequestedBy = loginUserId,
                RequestedDate = DateTime.Now.ToShortDateString(),
                
                ProcessID = ProcessMasterInfo.ProcessId,
                //ProcessRowId = -1,
                Reason = "",
                Remarks = "",
                SentTO = "",
                
            };
        }
        #endregion
        /// <summary>
        /// Starts the specified process, passed in model object
        /// </summary>
        /// <param name="objProcessInfo">Process info into model</param>
        /// <returns>True if sucessfull else false</returns>
        public virtual bool StartProcess(EntityProcesses objProcessInfo)
        {

            try
            {
                //Checking the Entity Process Elegibility.
                int returnResult = 0;
                if (OnCheckProcessEligibility())
                {
                    //returnResult = CheckProcessEligibility(objProcessInfo.EntityID, objProcessInfo.EntityVersionID, objProcessInfo.EntityTypeID, objProcessInfo.PROCESS_ID);

                    if (returnResult != 1)
                        return false;	//Entity not valid for the specified process
                }
                EntityProcesses objRunningProcess = GetRunningProcess(objProcessInfo.EntityID, objProcessInfo.EntityTypeID, objProcessInfo.EntityVersionID);
                if (objRunningProcess != null)
                {
                    objProcessInfo.ProcessRowId = objRunningProcess.ProcessRowId;
                    objProcessInfo.ProcessID = objRunningProcess.ProcessID;
                    objProcessInfo.Reason = objRunningProcess.Reason;
                    objProcessInfo.Remarks = objRunningProcess.Remarks;
                    objProcessInfo.SentTO = objRunningProcess.SentTO;
                    objProcessInfo.FollowupIds = objRunningProcess.FollowupIds;
                }
                else
                {
                    //At start process status should be pending
                    objProcessInfo.ProcessStatus = PROCESS_STATUS_PENDING;
                    //Adding the record into Entity process table (TM_ENTITY_PROCESS)
                    AddProcessInformation(objProcessInfo);
                    //TransactionDescription.Append("\n" + FetchGeneralMessage("1124", ";")); //Process has been added in process log.;");
                }
                #region DIARY/Followup ENTRY
                
                #endregion




                if (OnSetEntityStatus() == true)
                {
                    //Sets the Entity Status on which the process has been launched.
                    string EntityStatusDesc, NewEntityStatus;
                    //SetEntityStatus( objProcessInfo.PROCESS_ID, out EntityStatusDesc, out NewEntityStatus);
                    //TransactionDescription.Append("\n" + FetchGeneralMessage("1339", ";") + "" + EntityStatusDesc + ".;");
                }

                //Transaction log entry will be done.
                if (OnWriteTransactionLog())
                {
                    //WriteTransactionLog(
                    //    , GetTransactionLogDesc(objProcessInfo.PROCESS_ID), objProcessInfo.CREATED_BY, TransactionDescription.ToString());
                }
                return true;
            }
            catch (Exception objExp)
            {
                //throw (new Exception(FetchGeneralMessage("1338", ";") + "\n" + objExp.Message));
                throw (new Exception("Error while starting Process." + "\n" + objExp.Message));
            }
        }

        /// <summary>
        /// Commits the process specified in model object
        /// </summary>
        /// <param name="objProcessInfo">Process information</param>
        /// <returns>True if sucessfull else false</returns>
        //Overloaded virtual function
        public virtual bool CommitProcess(EntityProcesses objProcessInfo)
        {
            return CommitProcess(objProcessInfo, "");
        }

        public virtual bool CommitProcess(EntityProcesses objProcessInfo, string strCalledFrom)
        {
            try
            {
                int returnResult = 0;

                if (OnCheckProcessEligibility())
                {
                    //returnResult = CheckProcessEligibility();

                    if (returnResult != 1)
                    {
                        //TransactionDescription.Append("\n " + ClsCommon.FetchGeneralMessage("1376", "") + ";");//Process eligibility is false.;");
                        return false;	//Entity not valid for the specified process
                    }
                    else
                    {
                        //TransactionDescription.Append("\n" + ClsCommon.FetchGeneralMessage("1377", "") + ";");// Process eligibility is true.;");
                    }

                }

                int iResult = 0, iResult1 = 0;
                //iResult = SetDiaryEntryStatus(objProcessInfo, "N");
                //if (strCalledFrom == "NEWVERSION")
                //    iResult1 = SetDiaryEntryStatus(objProcessInfo, "N", strCalledFrom);
                //    TransactionDescription.Append(Cms.BusinessLayer.BlCommon.ClsCommon.FetchGeneralMessage("1378", ""));//Diary entry status has been marked completed.;");


                if (OnSetEntityStatus())
                {
                    //Updating the status of Entity on which process has been launched.
                    string EntityStatusDesc, NewEntityStatus="";
                    SetEntityStatus(objProcessInfo.EntityID, objProcessInfo.EntityTypeID,objProcessInfo.EntityVersionID, objProcessInfo.ProcessID, objProcessInfo.EntityCurrentStatus, out EntityStatusDesc, out NewEntityStatus);
                    //TransactionDescription.Append("\n " + ClsCommon.FetchGeneralMessage("1339", "") + EntityStatusDesc + ".;");
                    if (NewEntityStatus != "")
                        objProcessInfo.EntityCurrentStatus = NewEntityStatus;
                }
                objProcessInfo.ProcessStatus = "COMPLETE";
                objProcessInfo.RequestedDate = DateTime.Now.ToLongDateString();
                //Update the Process table Information
                DataTable result = UpdateProcessInformation(objProcessInfo);

                //Sets the Process Status on which the process has been launched.
                //SetProcessStatus(, objProcessInfo.ROW_ID, PROCESS_STATUS_COMPLETE);
                //TransactionDescription.Append(ClsCommon.FetchGeneralMessage("1379", ""));//Process Status has been updated.;");

                if (OnWriteTransactionLog())
                {
                    //Updating the transaction log
                  //  WriteTransactionLog(,
                   //     GetTransactionLogDesc(objProcessInfo.PROCESS_ID), objProcessInfo.COMPLETED_BY, TransactionDescription.ToString());
                }

                return true;
            }
            catch (Exception objExp)
            {
                throw (new Exception("Error occured while committing process \n" + objExp.Message));
            }
        }


        /// <summary>
        /// Rollback the process specified in model object
        /// </summary>
        /// <param name="objProcessInfo">Process information</param>
        /// <returns>True if sucessfull else false</returns>
        public virtual bool RollbackProcess(EntityProcesses objProcessInfo, string strCalledFor)
        {
            try
            {
                //Checking the Entity Process Elegibility.
                int returnResult = 0;

                if (OnCheckProcessEligibility())
                {
                    //returnResult = CheckProcessEligibility(, objProcessInfo.PROCESS_ID);

                    if (returnResult != 1)
                    {
                       // TransactionDescription.Append("\n" + ClsCommon.FetchGeneralMessage("1376", "") + ";");//Process eligibility is false.
                        return false;	//Entity not valid for the specified process
                    }
                    else
                    {
                        //TransactionDescription.Append("\n " + ClsCommon.FetchGeneralMessage("1377", "") + ";");//Process eligibility is true.
                    }
                }

                //int iResult = 0;
                //iResult = SetDiaryEntryStatus(objProcessInfo, "N");
                //if (strCalledFor == "NEWVERSION")
                //    iResult = SetDiaryEntryStatus(objProcessInfo, "N", strCalledFor);
                ////TransactionDescription.Append("\n Update the Diary Entry Status.;");
                //if (iResult > 0)
                //    TransactionDescription.Append("\n" + ClsCommon.FetchGeneralMessage("1919", "") + ";");//Diary entry status has been updated.

                //if (OnSetEntitytatus() == true)
                //{
                //    //Updating the status of Entuty on which process has been launched.
                //    string EntityStatusDesc, NewEntityStatus;
                //    SetEntityStatus(, objProcessInfo.PROCESS_ID, out EntityStatusDesc, out NewEntityStatus);
                //    TransactionDescription.Append("\n  " + ClsCommon.FetchGeneralMessage("1488", "") + EntityStatusDesc + ".;");//Entity Status has been updated to
                //}

                ////Update the Process table Information
                DataTable result = UpdateProcessInformation(objProcessInfo);

                //Sets the Entity Status on which the process has been launched.
                //SetProcessStatus(, objProcessInfo.ROW_ID, PROCESS_STATUS_ROLLBACK);
                //TransactionDescription.Append("\n " + ClsCommon.FetchGeneralMessage("1918", "") + ";");//("\n Process Status has been updated.;");

                if (OnWriteTransactionLog())
                {
                    //Updating the transaction log
                    //WriteTransactionLog(,
                    //    GetTransactionLogDesc(objProcessInfo.PROCESS_ID), objProcessInfo.COMPLETED_BY, TransactionDescription.ToString());
                }

                return true;
            }
            catch (Exception objExp)
            {
                throw (new Exception("Error occured while rollbacking process \n" + objExp.Message));
            }

        }
        #endregion
      
        #region "Process table related function

        #region Add(Insert) functions
        /// <summary>
        /// Saves the information passed in model object to database.
        /// </summary>
        /// <param name="objProcessInfo">Model class object.</param>
        /// <returns>No of records effected.</returns>
        public DataTable AddProcessInformation(EntityProcesses objProcesses)
        {
            string strStoredProc = "Proc_InsertTM_EntityProcesses";
            DateTime RecordDate = DateTime.Now;
            DataTable returnResult;
            //DataAccessLayer.DatabaseInteraction objWrapper = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
            try
            {

                objWrapper.ClearParameteres();
                objWrapper.AddParameter("@EntityID", objProcesses.EntityID);
                objWrapper.AddParameter("@EntityTypeID", objProcesses.EntityTypeID);
                objWrapper.AddParameter("@EntityVersionID", objProcesses.EntityVersionID);
                objWrapper.AddParameter("@EntityNewVersionID", objProcesses.EntityNewVersionID);
                objWrapper.AddParameter("@EntityPreviousStatus", objProcesses.EntityPreviousStatus);
                objWrapper.AddParameter("@EntityCurrentStatus", objProcesses.EntityCurrentStatus);
                objWrapper.AddParameter("@ProcessID", objProcesses.ProcessID);
                objWrapper.AddParameter("@ProcessType", "");
                objWrapper.AddParameter("@ProcessStatus", objProcesses.ProcessStatus);
                objWrapper.AddParameter("@ProcessEffectiveDate", objProcesses.ProcessEffectiveDate);
                objWrapper.AddParameter("@SentTo", objProcesses.SentTO);
                objWrapper.AddParameter("@Remarks", objProcesses.Remarks);
                objWrapper.AddParameter("@Reason", objProcesses.Reason);
                objWrapper.AddParameter("@FollowUpId", objProcesses.FollowupIds);
                objWrapper.AddParameter("@CreatedBy", objProcesses.CreatedBy);
                string[] tbls = {"ProcessTable"};
                returnResult = objWrapper.GetDataset(strStoredProc, tbls).Tables[0];

                if (returnResult.Rows[0]["ProcessRowId"] != null)
                    objProcesses.ProcessRowId = int.Parse(returnResult.Rows[0]["ProcessRowId"].ToString());

                objWrapper.ClearParameteres();
                return returnResult;

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        #endregion

        #region Update method
        /// <summary>
        /// Update method that recieves Model object to save.
        /// </summary>
        /// <param name="objProcessInfo">Model object having new information(form control's value)</param>
        /// <returns>No. of rows updated (1 or 0)</returns>
        public DataTable UpdateProcessInformation(EntityProcesses objProcesses)
        {
            string strStoredProc = "Proc_UpdateTM_ENTITY_PROCESSES";
            DataTable returnResult;
            DateTime RecordDate = DateTime.Now;
            
           // DataAccessLayer.DatabaseInteraction objWrapper = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
            try
            {

                objWrapper.ClearParameteres();
                objWrapper.AddParameter("@ProcessRowId", objProcesses.ProcessRowId);
                objWrapper.AddParameter("@EntityID", objProcesses.EntityID);
                objWrapper.AddParameter("@EntityTypeID", objProcesses.EntityTypeID);
                objWrapper.AddParameter("@EntityVersionID", objProcesses.EntityVersionID);
                objWrapper.AddParameter("@EntityNewVersionID", objProcesses.EntityNewVersionID);
                objWrapper.AddParameter("@EntityPreviousStatus", objProcesses.EntityPreviousStatus);
                objWrapper.AddParameter("@EntityCurrentStatus", objProcesses.EntityCurrentStatus);
                objWrapper.AddParameter("@ProcessID", objProcesses.ProcessID);
                objWrapper.AddParameter("@ProcessType", "");
                objWrapper.AddParameter("@ProcessStatus", objProcesses.ProcessStatus);
                objWrapper.AddParameter("@ProcessEffectiveDate", objProcesses.ProcessEffectiveDate);
                objWrapper.AddParameter("@SentTo", objProcesses.SentTO);
                objWrapper.AddParameter("@Remarks", objProcesses.Remarks);
                objWrapper.AddParameter("@Reason", objProcesses.Reason);
                objWrapper.AddParameter("@FollowUpId", objProcesses.FollowupIds);
                objWrapper.AddParameter("@RequestedBy", objProcesses.RequestedBy);
                string[] tbls = { "ProcessTable" };
                returnResult = objWrapper.GetDataset(strStoredProc, tbls).Tables[0];
                objWrapper.ClearParameteres();
                return returnResult;

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        #endregion
        

        #region GetRunningProcess
        public EntityProcesses GetRunningProcess(string EntityID, string EntityTypeID, string EntityVersionID)
        {
            try
            {
                DataSet ds = new DataSet();
                DataAccessLayer.DatabaseInteraction objDataWrapper = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
                objDataWrapper.AddParameter("@EntityID", EntityID);
                objDataWrapper.AddParameter("@EntityVersionID", EntityVersionID);
                objDataWrapper.AddParameter("@EntityTypeID", EntityTypeID);
                string[] tbls = { "ProcessTable" };
                ds = objDataWrapper.GetDataset("Proc_GetRunningProcess", tbls);
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return new EntityProcesses
                    {
                        ProcessRowId    = Int32.Parse(ds.Tables[0].Rows[0]["ProcessRowid"].ToString())  ,
                        ProcessID       = Int32.Parse(ds.Tables[0].Rows[0]["ProcessID"].ToString()),
                        EntityID        = ds.Tables[0].Rows[0]["EntityID"].ToString(),   
                        EntityTypeID    = ds.Tables[0].Rows[0]["EntityTypeID"].ToString(),  
                        EntityVersionID = ds.Tables[0].Rows[0]["EntityVersionID"].ToString(),
                        EntityNewVersionID      = ds.Tables[0].Rows[0]["EntityNewVersionID"].ToString(),
                        EntityPreviousStatus    = ds.Tables[0].Rows[0]["EntityPreviousStatus"].ToString(),
                        EntityCurrentStatus     = ds.Tables[0].Rows[0]["EntityCurrentStatus"].ToString(),
                        ProcessStatus = ds.Tables[0].Rows[0]["ProcessStatus"].ToString(),
                        ProcessEffectiveDate = DateTime.Parse(ds.Tables[0].Rows[0]["ProcessEffectiveDate"].ToString()),
                        SentTO  = ds.Tables[0].Rows[0]["SentTo"].ToString(),
                        Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString(),
                        Reason  = ds.Tables[0].Rows[0]["Reason"].ToString(),
                        FollowupIds = ds.Tables[0].Rows[0]["FollowUpId"].ToString(),
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception objExp)
            {
                throw (objExp);
            }
        }
        #endregion

        
        #region Set the Status of the Process table record.
        /// <summary>
        /// It will set the status of the process table record.
        /// </summary>
        /// <param name="ProcessID"></param>
        /// <returns></returns>
        public void SetProcessStatus(string EntityId, string EntityTypeId, string EntityVersionID, int RowID, string StatusDesc)
        {
            string strStoredProc = "Proc_SetEntityProcessStatus";
            int returnResult = 0;

            try
            {
                objWrapper.ClearParameteres();
                objWrapper.AddParameter("@EntityId", EntityId);
                objWrapper.AddParameter("@EntityTypeId", EntityTypeId);
                objWrapper.AddParameter("@EntityVersionID", EntityVersionID);
                objWrapper.AddParameter("@ROW_ID", RowID);
                objWrapper.AddParameter("@PROCESS_STATUS", StatusDesc);

                returnResult = objWrapper.executeNonQuery(strStoredProc);
                objWrapper.ClearParameteres();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
        #endregion

        #region Check Eligibilty of Launching the Process
        /// <summary>
        /// It will checks the Eligibility for launching the process.
        /// </summary>
      
        /// <returns></returns>
        public int CheckProcessEligibility(string EntityId, string EntityTypeId, String EntityVersionID, int ProcessID)
        {
            string strStoredProc = "Proc_CheckProcessEligibility";
            int returnResult = 1;
            return returnResult;
            //try
            //{
            //    objWrapper.ClearParameteres();
            //    objWrapper.AddParameter("@EntityID", EntityId);
            //    objWrapper.AddParameter("@EntityTypeId", EntityTypeId);
            //    objWrapper.AddParameter("@EntityVersionID", EntityVersionID);
            //    objWrapper.AddParameter("@PROCESS_ID", ProcessID);

            //    SqlParameter objSqlParameter = (SqlParameter)objWrapper.AddParameter("@RETVAL", SqlDbType.Int, ParameterDirection.Output);

            //    returnResult = objWrapper.ExecuteNonQuery(strStoredProc);

            //    if (objSqlParameter.Value != System.DBNull.Value)
            //    {
            //        returnResult = Convert.ToInt32(objSqlParameter.Value);
            //    }
            //    objWrapper.ClearParameteres();
            //    return returnResult;
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
        }

        public List<ProcessMaster> GetEntityEligibleProcess(string EntityID, string EntityVersionID, EntityType EntityTypeID, string EntityStatus, string CallerModule,int UserId)
        {
            string strStoredProc = "Proc_GetEntityEligibleProcess";
            DataSet returnDS = null;
           DataAccessLayer.DatabaseInteraction objDataWrapper = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
            try
            {
                objDataWrapper.ClearParameteres();
                objDataWrapper.AddParameter("@EntityID", EntityID);
                objDataWrapper.AddParameter("@EntityVersionID", EntityVersionID);
                objDataWrapper.AddParameter("@EntityTypeID", GetEnumString(EntityTypeID));
                objDataWrapper.AddParameter("@EntityStatus", EntityStatus);
                objDataWrapper.AddParameter("@CallerModule", CallerModule);
                objDataWrapper.AddParameter("@LoginUserId", UserId);
                string [] arrTables = {"EntityProcesses"};

                returnDS = objDataWrapper.GetDataset(strStoredProc, arrTables);
                objDataWrapper.ClearParameteres();
                List<ProcessMaster> lstProcessM = (from p in returnDS.Tables[0].AsEnumerable()
                                                   select new ProcessMaster()
                                                   {
                                                                         ProcessId          = int.Parse(p["ProcessId"].ToString()),
                                                                         ProcessCode        = p["ProcessCode"].ToString(),
                                                                         ProcessDesc        = p["ProcessDesc"].ToString(),
                                                                         ProcessShortName   = p["ProcessShortName"].ToString(),
                                                                         EntityTypeID       = p["EntityTypeID"].ToString(),
                                                                         ApplicableModule   = p["ApplicableFolder"].ToString(),
                                                                         IsActive           = p["IsActive"].ToString(),
                                                                         EntityStatus       = p["EntityStatus"].ToString(),
                                                                         ApplicableToStatus = p["ApplicableToStatus"].ToString(),
                                                                         ApprovalLevel      = int.Parse(p["ApprovalLevel"].ToString())
                                                                        }

                                                ).ToList();

                objDataWrapper = null;
                return lstProcessM;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Setting Status of the Active Entity

        protected void SetEntityStatus(string EntityId, string EntityTypeID, string EntityVersionID, int ProcessID, string EntityStatus, out string EntityStatusDesc, out string NewStatus)
        {
            EntityStatusDesc = ""; NewStatus = "";
            string strStoredProc = "Proc_SetEntityStatus";
            try
            {
                objWrapper.ClearParameteres();
                objWrapper.AddParameter("@EntityId", EntityId);
                objWrapper.AddParameter("@EntityTypeId", EntityTypeID);
                objWrapper.AddParameter("@EntityVerID", EntityVersionID);

                SqlParameter Param = (SqlParameter)objWrapper.AddParameter("@EntityStatusDesc", null, SqlDbType.VarChar, ParameterDirection.Output, 30);
                SqlParameter prmNewEntityStatus = (SqlParameter)objWrapper.AddParameter("@NewEntityStatus", null, SqlDbType.VarChar, ParameterDirection.Output, 30);

                if (ProcessID == 0)
                    objWrapper.AddParameter("@ProcessId", null);
                else
                    objWrapper.AddParameter("@ProcessId", ProcessID);

                objWrapper.AddParameter("@EntityStatus", EntityStatus);
                string[] tbls = { "EntityTable" };
                DataSet ds = objWrapper.GetDataset(strStoredProc, tbls);
                EntityStatusDesc = Param.Value.ToString();
                NewStatus = prmNewEntityStatus.Value.ToString();
                objWrapper.ClearParameteres();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

//        #region Write Transaction Log
//        public void WriteTransactionLog(string EntityId, String EntityTypeId, string EntityVersionID, string TransactionDescription, int RecordedBy, string ProcessDesc, string TransactionChange, int TranTypeId)
//        {
//            ClsTransactionInfo objTransactionInfo = new ClsTransactionInfo();

//            objTransactionInfo.CUSTOM_INFO = ProcessDesc;
//            if (TranTypeId != 0)
//                objTransactionInfo.TRANS_TYPE_ID = TranTypeId;
//            else
//                objTransactionInfo.TRANS_TYPE_ID = 3;
        //            objTransactionInfo.EntityId = EntityId;
        //            objTransactionInfo.EntityTypeId = EntityTypeId;
        //            objTransactionInfo.EntityVersionID = EntityVersionID;
//                objTransactionInfo.RECORDED_BY = RecordedBy;
//            objTransactionInfo.TRANS_DESC = TransactionDescription;
//            objTransactionInfo.CHANGE_XML = TransactionChange;
//            objWrapper.ExecuteNonQuery(objTransactionInfo);
//            objWrapper.ClearParameteres();
//        }
//        #endregion


//        #region Update Diary Entry Status
//        /// <summary>
//        /// It will update the Status of the Diary Entry.
//        /// </summary>
//        /// <param name="ListID"></param>
//        /// <param name="ListOpen"></param>
//        /// <returns></returns>
//        public int SetDiaryEntryStatus(ClsProcessInfo objProcessInfo, string ListOpen)
//        {
//            return SetDiaryEntryStatus(objProcessInfo, ListOpen, "");
//        }
//        public int SetDiaryEntryStatus(ClsProcessInfo objProcessInfo, string ListOpen, string strCalledFor)
//        {
//            ClsDiary objDiary = new ClsDiary();
//            int returnResult = 0;
//            string strCalledFrom;
//            strCalledFrom = "";
//            try
//            {
//                //returnResult = objDiary.CompleteDiaryEntry(objWrapper, ListID, ListOpen);
//                strCalledFrom = objProcessInfo.PROCESS_ID.ToString();
//                if (strCalledFor == "NEWVERSION")
//                    returnResult = objDiary.CompleteDiaryEntry(objWrapper, objProcessInfo.EntityId, objProcessInfo.EntityTypeId, objProcessInfo.EntityVersionId, objProcessInfo.ROW_ID, ListOpen, strCalledFrom);
//                else
//                    returnResult = objDiary.CompleteDiaryEntry(objWrapper, objProcessInfo.EntityId, objProcessInfo.EntityTypeId, objProcessInfo.EntityVersionId, objProcessInfo.ROW_ID, ListOpen, strCalledFrom);

//                objWrapper.ClearParameteres();
//                return returnResult;
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }
//        #endregion



//        /// <summary>
//        /// This function is used to make diary entry if ineligible coverage is found
//        /// </summary>
//        public void AddDiaryEntry(int EntityId, int EntityTypeId, int EntVerId, int FromUserID)
//        {
//            TodolistInfo objTodo = new TodolistInfo();


//            objTodo.EntityId = EntityId;
//            objTodo.EntityTypeId = EntityTypeId;
//            objTodo.EntVerId = EntVerId;
//            objTodo.LISTTYPEID = (int)ClsDiary.enumDiaryType.REVIEWING__REQUEST;
//            objTodo.RECDATE = System.DateTime.Now;
//            objTodo.MODULE_ID = (int)ClsDiary.enumModuleMaster.APPLICATION;
//            objTodo.LISTOPEN = "Y";

//            objTodo.FROMUSERID = FromUserID;
//            objTodo.LOB_ID = LobID;

//            objTodo.FOLLOWUPDATE = System.DateTime.Now;
//            objTodo.SUBJECTLINE = ClsCommon.FetchGeneralMessage("1920", "");

//            ClsDiary objDiary = new ClsDiary();
//            ArrayList alresult = new ArrayList();
//            try
//            {
//                alresult = objDiary.DiaryEntryfromSetup(objTodo);
//            }
//            catch (Exception ex)
//            {
//                throw ex;

//            }
//            finally
//            {
//                if (objDiary != null)
//                    objDiary.Dispose();
//            }
//        }

//        #region Common functions


        //public enum FOLLOWUP
        //{
        //    DAY_FOLLOWUP_1 = 1,
        //    DAY_FOLLOWUP_6 = 6,
        //    DAY_FOLLOWUP_7 = 7
        //}


        //#endregion


        public static string GetEnumString(Enum e)
        {
            string description = "";
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    string name = values.GetValue(val).ToString();
                    if (name == e.ToString())
                    {
                        //var memInfo = type.GetMember(type.GetEnumName(val));
                        //var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                        //if (descriptionAttributes.Length > 0)
                        //{
                        //    description = ((DescriptionAttribute)descriptionAttributes[0]).Description;
                        //}
                        description = name;
                        break;
                    }
                }
            }

            return description;
        }
        

    }


    public class EntityProcesses 
    {
        public EntityProcesses()
        {
        }
        #region Process object properties
        public int ProcessRowId
        {
            get;
            set;
        }
        public string EntityID
        {
            get;
            set;
        }
        public string EntityVersionID
        {
            get;
            set;
        }
        public string EntityNewVersionID
        {
            get;
            set;
        }
        public string EntityTypeID
        {
            get;
            set;
        }
        public string EntityPreviousStatus
        {
            get;
            set;
        }
        public string EntityCurrentStatus
        {
            get;
            set;
        }
        public int ProcessID
        {
            get;
            set;
        }
        public string ProcessStatus
        {
            get;
            set;
        }
        public DateTime ProcessEffectiveDate
        {
            get;
            set;
        }
        public string SentTO
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }
        public string Reason
        {
            get;
            set;
        }
        public string FollowupIds
        {
            get;
            set;
        }
        public string IsActive
        {
            get;
            set;
        }
        public string CreatedBy
        {
            get;
            set;
        }
        public string CreatedDate
        {
            get;
            set;
        }
        public string RequestedBy
        {
            get;
            set;
        }
        public string RequestedDate
        {
            get;
            set;
        }

        #endregion
    }

    public class ProcessMaster
    {
        public ProcessMaster()
        {
        }
        #region Process object properties
        public int ProcessId
        {
            get;
            set;
        }
        public string ProcessCode
        {
            get;
            set;
        }
        public string ProcessDesc
        {
            get;
            set;
        }
        public string ProcessShortName
        {
            get;
            set;
        }
        public string EntityTypeID
        {
            get;
            set;
        }
        public int ApprovalLevel
        {
            get;
            set;
        }
        public string ApplicableToStatus
        {
            get;
            set;
        }
        public string ApplicableModule
        {
            get;
            set;
        }
        public string EntityStatus
        {
            get;
            set;
        }
        public string IsActive
        {
            get;
            set;
        }
        #endregion
    }
}
