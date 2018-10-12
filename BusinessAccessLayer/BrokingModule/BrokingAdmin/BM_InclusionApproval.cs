using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
   public class BM_InclusionApproval
    {
        DataAccess dataAccessDS = null;

        public DataSet GetTemplateOnSelect(clsBM_InclusionApproval objclsBM_InclusionApproval)
        {
            object[] parameters = new object[] { objclsBM_InclusionApproval.frmfor, 
                                                 objclsBM_InclusionApproval.HeaderId,
                                                 objclsBM_InclusionApproval.ClassId,
                                                 objclsBM_InclusionApproval.SubClassId,
                                                 objclsBM_InclusionApproval.TemplateId,
                                                 objclsBM_InclusionApproval.TemplateName};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_InclusionApproval_Select", "GetTemplateOnSelect");
        }


        public DataSet Load_GetType(string frmFor, int ClassID, int SubClassID, int TemplateId, string TemplateName)
        {
            object[] parameters = new object[] { frmFor, ClassID, SubClassID, TemplateId, TemplateName };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_InclusionApproval_Template_Select", "Load_GetType");
        }
       

        //public DataSet Load_GetType(clsBM_InclusionApproval objclsBM_InclusionApproval)
        //{
        //    object[] parameters = new object[] { objclsBM_InclusionApproval.frmfor, objclsBM_InclusionApproval.ClassId, objclsBM_InclusionApproval.SubClassId, objclsBM_InclusionApproval.TemplateId, objclsBM_InclusionApproval.TemplateName };
        //    dataAccessDS = new DataAccess();
        //    return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_InclusionApproval_Select", "Load_GetType");
        //}

        public DataSet Load_GetAllApproval(clsBM_InclusionApproval objclsBM_InclusionApproval)
        {
            object[] parameters = new object[] { 
                                                    objclsBM_InclusionApproval.frmfor, 
                                                    objclsBM_InclusionApproval.ClassId, 
                                                    objclsBM_InclusionApproval.SubClassId,
                                                    objclsBM_InclusionApproval.TemplateId,
                                                    //objclsBM_InclusionApproval.MainClass,
                                                    //objclsBM_InclusionApproval.SubClass,
                                                    //objclsBM_InclusionApproval.TemplateName, 
                                                    objclsBM_InclusionApproval.Header, 
                                                    objclsBM_InclusionApproval.HeaderDescription, 
                                                    objclsBM_InclusionApproval.HeaderFullDescription,
                                                    //objclsBM_InclusionApproval.CreatedDate,
                                                    objclsBM_InclusionApproval.EffFromDate,
                                                    objclsBM_InclusionApproval.EffDateTo,
                                                    objclsBM_InclusionApproval.CreatedBy 
                                                   
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_InclusionApproval_SelectAll", "Load_GetAllApproval");
        }
        public DataSet Load_GetAllApproval_SelectUserAutomatically(string name)
        {
            object[] parameters = new object[] { 
                                                    name
                                                   
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_InclusionApproval_SelectUserAutomatically", "Load_GetAllApproval");
        }
        public DataSet SaveBM_HeaderDetail(clsBM_InclusionApproval objclsBM_InclusionApproval)
        {
            object[] parameters = new object[] { objclsBM_InclusionApproval.frmfor,
                                                 objclsBM_InclusionApproval.ClassId,
                                                 objclsBM_InclusionApproval.SubClassId,
                                                 objclsBM_InclusionApproval.HeaderId,
                                                 objclsBM_InclusionApproval.TemplateId,
                                                 objclsBM_InclusionApproval.Header,
                                                 objclsBM_InclusionApproval.HeaderCH,
                                                 objclsBM_InclusionApproval.HeaderDescription,
                                                 objclsBM_InclusionApproval.HeaderFullDescription,
                                                 objclsBM_InclusionApproval.TariffReferenceCode,
                                                 objclsBM_InclusionApproval.ConditionType,
                                                 objclsBM_InclusionApproval.ToPrint,
                                                 objclsBM_InclusionApproval.EffFromDate ,
                                                 objclsBM_InclusionApproval.EffDateTo ,
                                                 objclsBM_InclusionApproval.User,
                                                 objclsBM_InclusionApproval.Status,
                                                 objclsBM_InclusionApproval.GroupHeader
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_HeaderMaster_InclusionUpdate", "TM_BM_HeaderMaster_InclusionUpdate");

        }

        public DataSet SaveBM_ApprovalStatus(clsBM_InclusionApproval_Rejection_Status objclsBM_Approval_Rejection_Status)
        {
            object[] parameters = new object[] { 
                                                 objclsBM_Approval_Rejection_Status.HeaderId,
                                                 objclsBM_Approval_Rejection_Status.TemplateId,
                                                 objclsBM_Approval_Rejection_Status.user,
                                                 objclsBM_Approval_Rejection_Status.ApprovalStatus,
                                                 objclsBM_Approval_Rejection_Status.RejectReason
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_InclusionApproval_Approve_Reject", "InclusionApproval_Approve_Reject");

        }
    }
}
