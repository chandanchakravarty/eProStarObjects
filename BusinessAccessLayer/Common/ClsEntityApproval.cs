using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessAccessLayer.BrokingModule.BrokingSystem;
using BusinessAccessLayer.AccountModule.Accounts;
using BusinessObjectLayer.AccountModule;
using System.Data.SqlClient;

namespace BusinessAccessLayer.Common
{
    public class EntityApproval 
    {
        private string _entityType = "";
        private string _processCode = "";
        private clsApprovalProcess mEntity;
        ProcessMaster objProcessInfo;
        public EntityApproval()
        {

        }
        public EntityApproval(ProcessMaster objProcessM, string ID)
        {
            objProcessInfo = objProcessM;
            _entityType = objProcessM.EntityTypeID;
           _processCode = ID;
           setEntity();
        }
       
        public DataSet Process(object objEntity)
        {
            //setEntity();
            mEntity.ProcessMasterInfo = objProcessInfo;
            if(_processCode.ToUpper().Contains("REJECT"))
                return mEntity.Reject(objEntity);
            else
                return mEntity.Approve(objEntity);
        }
        public List<BusinessAccessLayer.Common.ProcessMaster> GetEntityProcess(string EntityID, string EntityVersionID, clsApprovalProcess.EntityType EntityTypeID, string EntityStatus, string CallerModule,int UserId)
        {
            return mEntity.GetEntityEligibleProcess(EntityID, EntityVersionID, EntityTypeID, EntityStatus, CallerModule,UserId);
        }
        #region GetApprovalActivities
        public string GetApprovalActivities(string EntityID)
        {
            try
            {
                DataSet ds = new DataSet();
                // DataAccessLayer.DatabaseInteraction objDataWrapper = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
                DataAccessLayer.DatabaseInteraction objDataWrapper = new DataAccessLayer.DatabaseInteraction(CommandType.Text);
                // objDataWrapper.AddParameter("@EntityID", EntityID);
                string[] tbls = { "ApprovalActivities" };
                ds = objDataWrapper.GetDataset("select IsActive from TM_ApprovalActivities where ActivityID='" + EntityID + "'", tbls);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["IsActive"].ToString();
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
        #region SetEntityStatus
        public string SetEntityStatus(string EntityId, string EntityTypeID, string EntityStatus)
          {
            //try
            //{
            //    DataSet ds = new DataSet();
            //    DataAccessLayer.DatabaseInteraction objWrapper = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
            //    //DataAccessLayer.DatabaseInteraction objDataWrapper = new DataAccessLayer.DatabaseInteraction(CommandType.Text);
            //    // objDataWrapper.AddParameter("@EntityID", EntityID);
            //    string[] tbls = { "EntityStatus" };
            //    ds = objDataWrapper.GetDataset("select IsActive from TM_ApprovalActivities where ActivityID='" + EntityID + "'", tbls);

            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        return ds.Tables[0].Rows[0]["IsActive"].ToString();
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //catch (Exception objExp)
            //{
            //    throw (objExp);
            //}
              string EntityStatusDesc = "", NewStatus=""; 
              string strStoredProc = "Proc_SetEntityStatus";
            try
            {

                DataSet ds = new DataSet();
                DataAccessLayer.DatabaseInteraction objWrapper = new DataAccessLayer.DatabaseInteraction(CommandType.StoredProcedure);
              
                objWrapper.ClearParameteres();
                objWrapper.AddParameter("@EntityId", EntityId);
                objWrapper.AddParameter("@EntityTypeId", EntityTypeID);
                objWrapper.AddParameter("@EntityVerID", "1");

                SqlParameter Param = (SqlParameter)objWrapper.AddParameter("@EntityStatusDesc", null, SqlDbType.VarChar, ParameterDirection.Output, 30);
                SqlParameter prmNewEntityStatus = (SqlParameter)objWrapper.AddParameter("@NewEntityStatus", null, SqlDbType.VarChar, ParameterDirection.Output, 30);
                objWrapper.AddParameter("@ProcessId", null);

                objWrapper.AddParameter("@EntityStatus", EntityStatus);
                string[] tbls = { "EntityTable" };
                ds = objWrapper.GetDataset(strStoredProc, tbls);
                EntityStatusDesc = Param.Value.ToString();
                NewStatus = prmNewEntityStatus.Value.ToString();
                objWrapper.ClearParameteres();
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return null;
        }
        #endregion

        #region Private Utility and Methods
        private void setEntity()
        {
            switch (_entityType.ToUpper())
            {
                case "CLIENT":
                    {
                        mEntity = new ClsClientApproval();
                        break;
                    }
                case "UNDERWRITER":
                case "INSURER":
                    {
                        mEntity = new ClsInsurerApproval();
                        break;
                    }
                case "INTRODUCER":
                    {
                        mEntity = new ClsIntroducerApproval();
                        break;
                    }
                case "REINSURER":
                    {
                        mEntity = new ClsReinsurerApproval();
                        break;
                    }
                case "DEBITNOTE":
                    {
                        mEntity = new ClsDebitNoteApproval();
                        break;
                    }
                case "CREDITNOTE":
                    {
                        mEntity = new ClsCreditNoteApproval();
                        break;
                    }
                case "PAYMENT":
                    {
                        mEntity = new ClsPaymentApproval();
                        break;
                    }
                case "RECEIPT":
                    {
                        mEntity = new ClsRecieptApproval();
                        break;
                    }
                case "JOURNAL":
                    {
                        mEntity = new ClsJournalApproval();
                        break;
                    }
                default:
                    {
                        throw (new Exception("Entity Type is not implemented. Please check the passed on entity type is correct."));
                    }
            }
        }
        #endregion
    
    
    }

    class ClsClientApproval : clsApprovalProcess
    {
        public ClsClientApproval() { }
        public override DataSet Approve(object objEntity)
        {
            clsUnApprovedInfo objXmlEntity = (clsUnApprovedInfo)(objEntity);
            
            EntityProcesses objProcess = base.getProcessObject(objXmlEntity.LoginUserId, EntityType.CLIENT, objXmlEntity.AppStatus, objXmlEntity.RecForId.ToString(),"1");

            //{
            //    EntityCurrentStatus = "",
            //    EntityNewVersionID ="",
            //    EntityPreviousStatus = "",
            //    EntityVersionID ="",
            //    ProcessID =1,
            //    ProcessRowId =-1,
            //    Reason ="",
            //    Remarks ="",
            //    SentTO = ""

            //};
            try
            {
                base.BeginTransaction();
                if (base.StartProcess(objProcess))
                {
                    DataSet dsClient = ApproveClient(objEntity);
                    base.CommitProcess(objProcess);
                    base.CommitTransaction();
                    return dsClient;
                }
                else
                {
                    // base.RollbackProcess(objProcess, EntityType.RECEIPT.ToString());
                    throw (new Exception("Client Can not be approved. Error: Process is not eligible on this entity status."));
                }
            }
            catch (Exception ex)
            {
                base.RollbackProcess(objProcess, EntityType.CLIENT.ToString());
                throw (new Exception("Client Can not be approved. Error: " + ex.Message));
            }
        }
        public override DataSet Reject(object objEntity)
        {
            return RejectClient(objEntity);
        }
        private DataSet ApproveClient(object objEntity)
        {
            string strMessage = "";
            clsUnApprovedInfo objXMLEntity = (clsUnApprovedInfo)(objEntity);
            // implement the logic here
            clsClientMaster objClient = new clsClientMaster();
            clsClientManager objClientBI = new clsClientManager();
            DataSet dsApprove = new DataSet();
            clsXmlUnApprovedInfo xmlInfo = new clsXmlUnApprovedInfo();
            xmlInfo = (clsXmlUnApprovedInfo)BusinessObjectLayer.Common.SerializeDeserialize.DeserializeAnObject(objXMLEntity.RecData, xmlInfo.GetType());
            DataMapper.Map(xmlInfo, objClient, false, "RecData");
            if (ProcessMasterInfo.EntityStatus == CLIENT_STATUS_APPROVED)
            {

                objClient.RecId = 0;
                objClient.ClientId = objXMLEntity.RecForId;
                objClient.ClientForModule = objXMLEntity.RecForModule;
                objClient.ClientCode = objXMLEntity.Code;

                dsApprove = objClientBI.SaveClient(objClient);

                strMessage = Convert.ToString(dsApprove.Tables[0].Rows[0][0]);
                #region Save Contacts
                
                ClientContacts objContacts = new ClientContacts();
                objContacts.ClientId = objXMLEntity.RecForId;
                objContacts.ClientForModule = objXMLEntity.RecForModule;
                DataSet dsContacts = objClientBI.SaveApprovedContacts(objContacts);

                if (dsContacts.Tables[0].Rows[0][0].ToString().ToLower().IndexOf("success") > 0)
                {
                    strMessage = strMessage + "<br>" + Convert.ToString(dsContacts.Tables[0].Rows[0][0]);
                }
                #endregion
            }
            //else
            //    dsApprove = objClientBI.SaveUnApprovedInfo(objClient);
            objClientBI = null;
            xmlInfo = null;
            return dsApprove;
        }
       
        private DataSet RejectClient(object objEntity)
        {
            clsXmlUnApprovedInfo objXmlEntity = (clsXmlUnApprovedInfo)(objEntity);
            DataSet dsApprove = new DataSet();
            return dsApprove;
        }
    }

    class ClsInsurerApproval : clsApprovalProcess
    {
    }
    class ClsIntroducerApproval : clsApprovalProcess
    {
    }
    class ClsReinsurerApproval : clsApprovalProcess
    {
    }
    class ClsIntroducerAgreementApproval : clsApprovalProcess
    {
    }
    class ClsDebitNoteApproval : clsApprovalProcess
    {
    }
    class ClsCreditNoteApproval : clsApprovalProcess
    {
    }
    class ClsPaymentApproval : clsApprovalProcess
    {

        public ClsPaymentApproval() { }
        public override DataSet Approve(object objEntityp)
        {
            clsPayment objEntity = (clsPayment)(objEntityp);

            EntityProcesses objProcess = base.getProcessObject(objEntity.UserId.ToString(), EntityType.PAYMENT, objEntity.Status, objEntity.PaymentNo, "1");
            try
            {
                base.BeginTransaction();
                if (base.StartProcess(objProcess))
                {
                    DataSet ds = ApproveReceipt(objEntity);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0] != null && ds.Tables[0].Rows[0]["Result"] != null)
                    {
                         
                        objProcess.EntityCurrentStatus = objEntity.Status;
                        objProcess.EntityID = ds .Tables[0].Rows[0]["Result"].ToString();
                    }
                    base.CommitProcess(objProcess);
                    base.CommitTransaction();
                    return ds ;
                }
                else
                {
                   // base.RollbackProcess(objProcess, EntityType.RECEIPT.ToString());
                    throw (new Exception("Receipt Can not be approved. Error: Process is not eligible on this entity status."));
                }
            }
            catch (Exception ex)
            {
                base.RollbackProcess(objProcess, EntityType.RECEIPT.ToString());
                throw (new Exception("Receipt Can not be approved. Error: " + ex.Message));
            }
        }
        public override DataSet Reject(object objEntityp)
        {
            clsPayment objEntity = (clsPayment)(objEntityp);
            return Reject(objEntity);
        }
        private DataSet ApproveReceipt(clsPayment objEntity)
        {
            // implement the logic here
            clsACCommon objAccountBAL = new clsACCommon();
            DataSet dsApprove = new DataSet();
            if (ProcessMasterInfo.EntityStatus == RECEIPT_STATUS_APPROVED)
            {
                if (objEntity.PaymentNo != "")
                {
                    DataTable dt = objAccountBAL.AddUpdatePayment(objEntity, objEntity.AuditLogHeader, true, true);
                    dsApprove.Tables.Add(dt);
                }
            }
            //else
            //    dsApprove = objClientBI.SaveUnApprovedInfo(objClient);
            objAccountBAL = null;
            return dsApprove;
        }

        private DataSet Reject(clsPayment objEntity)
        {
            DataSet dsApprove = new DataSet();
           // clsPayment objEntity = (clsPayment)(objEntityp);

            EntityProcesses objProcess = base.getProcessObject(objEntity.UserId.ToString(), EntityType.PAYMENT, objEntity.Status, objEntity.PaymentNo, "1");
            try
            {
                base.BeginTransaction();
                if (base.StartProcess(objProcess))
                {
                    //DataSet ds = ApproveReceipt(objEntity);
                    //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0] != null && ds.Tables[0].Rows[0]["Result"] != null)
                    //{

                    //    objProcess.EntityCurrentStatus = objEntity.Status;
                    //    objProcess.EntityID = ds.Tables[0].Rows[0]["Result"].ToString();
                    //}
                    base.CommitProcess(objProcess);
                    base.CommitTransaction();
                    return dsApprove;
                }
                else
                {
                    // base.RollbackProcess(objProcess, EntityType.RECEIPT.ToString());
                    throw (new Exception("Receipt Can not be approved. Error: Process is not eligible on this entity status."));
                }
            }
            catch (Exception ex)
            {
                base.RollbackProcess(objProcess, EntityType.RECEIPT.ToString());
                throw (new Exception("Receipt Can not be approved. Error: " + ex.Message));
            }
            return dsApprove;
        }
    }
    class ClsRecieptApproval : clsApprovalProcess
    {
        public ClsRecieptApproval() { }
        public override DataSet Approve(object objEntity)
        {
            clsReciept objReceiptEntity = (clsReciept)(objEntity);

            EntityProcesses objProcess = base.getProcessObject(objReceiptEntity.UserId.ToString(), EntityType.RECEIPT, objReceiptEntity.Status, objReceiptEntity.ReceiptNo, "1");
            try
            {
                base.BeginTransaction();
                if (base.StartProcess(objProcess))
                {
                    DataSet dsReciept = ApproveReceipt(objReceiptEntity);
                    if (dsReciept != null && dsReciept.Tables.Count > 0 && dsReciept.Tables[0] != null && dsReciept.Tables[0].Rows.Count > 0 && dsReciept.Tables[0].Rows[0] != null && dsReciept.Tables[0].Rows[0]["Result"] != null)
                    {
                         
                        objProcess.EntityCurrentStatus = objReceiptEntity.Status;
                        objProcess.EntityID = dsReciept.Tables[0].Rows[0]["Result"].ToString();
                    }
                    base.CommitProcess(objProcess);
                    base.CommitTransaction();
                    return dsReciept;
                }
                else
                {
                   // base.RollbackProcess(objProcess, EntityType.RECEIPT.ToString());
                    throw (new Exception("Receipt Can not be approved. Error: Process is not eligible on this entity status."));
                }
            }
            catch (Exception ex)
            {
                base.RollbackProcess(objProcess, EntityType.RECEIPT.ToString());
                throw (new Exception("Receipt Can not be approved. Error: " + ex.Message));
            }
        }
        public override DataSet Reject(object objEntity)
        {
            clsReciept objReceiptEntity = (clsReciept)(objEntity);
            return RejectReceipt(objReceiptEntity);
        }
        private DataSet ApproveReceipt(clsReciept objEntity)
        {
            // implement the logic here
            clsACCommon objAccountBAL = new clsACCommon();
            DataSet dsApprove = new DataSet();
            if (ProcessMasterInfo.EntityStatus == RECEIPT_STATUS_APPROVED)
            {
                if (objEntity.ReceiptNo != "")
                {
                    DataTable dt = objAccountBAL.AddUpdateReceipt(objEntity, objEntity.AuditLogHeader, true, true,null);
                    dsApprove.Tables.Add(dt);
                }
            }
            //else
            //    dsApprove = objClientBI.SaveUnApprovedInfo(objClient);
            objAccountBAL = null;
            return dsApprove;
        }

        private DataSet RejectReceipt(clsReciept objEntity)
        {
            DataSet dsApprove = new DataSet();
            clsReciept objReceiptEntity = (clsReciept)(objEntity);

            EntityProcesses objProcess = base.getProcessObject(objReceiptEntity.UserId.ToString(), EntityType.RECEIPT, objReceiptEntity.Status, objReceiptEntity.ReceiptNo, "1");
            try
            {
                base.BeginTransaction();
                if (base.StartProcess(objProcess))
                {
                    //DataSet dsReciept = ApproveReceipt(objReceiptEntity);
                    //if (dsReciept != null && dsReciept.Tables.Count > 0 && dsReciept.Tables[0] != null && dsReciept.Tables[0].Rows.Count > 0 && dsReciept.Tables[0].Rows[0] != null && dsReciept.Tables[0].Rows[0]["Result"] != null)
                    //{

                    //    objProcess.EntityCurrentStatus = objReceiptEntity.Status;
                    //    objProcess.EntityID = dsReciept.Tables[0].Rows[0]["Result"].ToString();
                    //}
                    base.CommitProcess(objProcess);
                    base.CommitTransaction();
                    return dsApprove;
                }
                else
                {
                    // base.RollbackProcess(objProcess, EntityType.RECEIPT.ToString());
                    throw (new Exception("Receipt Can not be approved. Error: Process is not eligible on this entity status."));
                }
            }
            catch (Exception ex)
            {
                base.RollbackProcess(objProcess, EntityType.RECEIPT.ToString());
                throw (new Exception("Receipt Can not be approved. Error: " + ex.Message));
            }
            return dsApprove;
        }
        
    }
    class ClsJournalApproval : clsApprovalProcess
    {
        public ClsJournalApproval() { }
        public override DataSet Approve(object objEntityp)
        {
            clsDirectInsurerPayment objEntity = (clsDirectInsurerPayment)(objEntityp);

            EntityProcesses objProcess = base.getProcessObject(objEntity.UserId.ToString(), EntityType.JOURNAL, objEntity.Status, objEntity.JournalNo, "1");
            try
            {
                base.BeginTransaction();
                if (base.StartProcess(objProcess))
                {
                    DataSet ds = ApproveReceipt(objEntity);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0] != null && ds.Tables[0].Rows[0]["Result"] != null)
                    {
                         
                        objProcess.EntityCurrentStatus = objEntity.Status;
                        objProcess.EntityID = ds .Tables[0].Rows[0]["Result"].ToString();
                    }
                    base.CommitProcess(objProcess);
                    base.CommitTransaction();
                    return ds ;
                }
                else
                {
                   // base.RollbackProcess(objProcess, EntityType.RECEIPT.ToString());
                    throw (new Exception("Receipt Can not be approved. Error: Process is not eligible on this entity status."));
                }
            }
            catch (Exception ex)
            {
                base.RollbackProcess(objProcess, EntityType.RECEIPT.ToString());
                throw (new Exception("Receipt Can not be approved. Error: " + ex.Message));
            }
        }
        public override DataSet Reject(object objEntityp)
        {
            clsDirectInsurerPayment objEntity = (clsDirectInsurerPayment)(objEntityp);
            return Reject(objEntity);
        }
        private DataSet ApproveReceipt(clsDirectInsurerPayment objEntity)
        {
            // implement the logic here
            clsACCommon objAccountBAL = new clsACCommon();
            DataSet dsApprove = new DataSet();
            if (ProcessMasterInfo.EntityStatus == RECEIPT_STATUS_APPROVED)
            {
                if (objEntity.JournalNo!= "")
                {
                    DataTable dt = objAccountBAL.funSaveJournalDetails(objEntity, objEntity.AuditLogHeader, true, true);
                    dsApprove.Tables.Add(dt);
                }
            }
            //else
            //    dsApprove = objClientBI.SaveUnApprovedInfo(objClient);
            objAccountBAL = null;
            return dsApprove;
        }

        private DataSet Reject(clsDirectInsurerPayment objEntity)
        {
            DataSet dsApprove = new DataSet();
            //clsDirectInsurerPayment objEntity = (clsDirectInsurerPayment)(objEntityp);

            EntityProcesses objProcess = base.getProcessObject(objEntity.UserId.ToString(), EntityType.JOURNAL, objEntity.Status, objEntity.JournalNo, "1");
            try
            {
                base.BeginTransaction();
                if (base.StartProcess(objProcess))
                {
                    //DataSet ds = ApproveReceipt(objEntity);
                    //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0] != null && ds.Tables[0].Rows[0]["Result"] != null)
                    //{

                    //    objProcess.EntityCurrentStatus = objEntity.Status;
                    //    objProcess.EntityID = ds.Tables[0].Rows[0]["Result"].ToString();
                    //}
                    base.CommitProcess(objProcess);
                    base.CommitTransaction();
                    return dsApprove;
                }
                else
                {
                    // base.RollbackProcess(objProcess, EntityType.RECEIPT.ToString());
                    throw (new Exception("Receipt Can not be approved. Error: Process is not eligible on this entity status."));
                }
            }
            catch (Exception ex)
            {
                base.RollbackProcess(objProcess, EntityType.RECEIPT.ToString());
                throw (new Exception("Receipt Can not be approved. Error: " + ex.Message));
            }
            return dsApprove;
        }
    }

}
