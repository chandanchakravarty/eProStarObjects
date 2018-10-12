using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem
{
    public class clsReinsurerManager
    {
        clsReinsurerMaster objReinsurer = new clsReinsurerMaster();
        DataAccess dataAccess = null;
        ReinsurerContacts objContacts = new ReinsurerContacts();
        clsUnApprovedInfo objUnApproved = new clsUnApprovedInfo();
        UnApprovedContacts objUnApprovContacts = new UnApprovedContacts();

        public DataSet getUnApprovReinsurerList(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objUnApproved.RecId, objUnApproved.RecForModule, objUnApproved.ApprovingAuthority1, objUnApproved.AppStatus, objUnApproved.RecordFor };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_Reinsurer_UnApprovedInfo_Select", "ReinsurerList");
        }
        public DataSet getUnApprovReinsurerContacts(UnApprovedContacts objContacts)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objContacts.RecForId, objContacts.ContactRecId, objContacts.RecForType, objContacts.RecForModule,objContacts.IsPriorityContact };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_UnApprovedContacts_Select", "UnApprovedContactList");
        }
        public DataSet getReinsurerList(clsReinsurerMaster objReinsurer)
        {
             
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objReinsurer.ReinsurerId,objReinsurer.ReinsurerForModule};
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_pol_ReinsurerMaster_Select", "ReinsurerList");
        }
        public DataSet SaveUnApprovedContactInfo(UnApprovedContacts objUnApprovContacts)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objUnApprovContacts.ContactRecId,
                                                //objUnApprovContacts.ClientRecId,
                                                objUnApprovContacts.RecForType,
                                                objUnApprovContacts.RecordFor,
                                                objUnApprovContacts.RecForId,
                                                objUnApprovContacts.RecForModule,
                                                objUnApprovContacts.AppliedBy,
                                                objUnApprovContacts.AppStatus,
                                                objUnApprovContacts.LoginUserId,
                                                objUnApprovContacts.RecData,
                                                objUnApprovContacts.PageMethod,
                                                objUnApprovContacts.IsPriorityContact,
                                                objUnApprovContacts.IsContactSOA
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Contacts_UnApprovedInfo_InsertUpdate", "UnApprovedContactInfo");
        }
        public DataSet GetCode(string recForType, string country, int IsApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { recForType, country, IsApproved };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GetRunningCode", "ClientCode");
        }
        public DataSet SaveUnApprovedInfo(clsUnApprovedInfo objUnApproved,string company)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objUnApproved.RecId,
                                                objUnApproved.RecForType,
                                                objUnApproved.RecordFor,
                                                objUnApproved.RecForId,
                                                objUnApproved.RecForModule,
                                                objUnApproved.AppliedBy,
                                                objUnApproved.AppStatus,
                                                objUnApproved.LoginUserId,
                                                objUnApproved.RecData,
                                                objUnApproved.PageMethod,
                                                objUnApproved.Code,
                                                company
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_UnApprovedInfo_InsertUpdate", "UnApprovedClientInfo");
        }
        public DataSet ChangeStatus(clsUnApprovedInfo objUnApproved)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objUnApproved.RecForType,
                                                objUnApproved.RecForId,                                      
                                                objUnApproved.AppStatus,
                                                objUnApproved.RecordFor,
                                                objUnApproved.RecId,
                                                objUnApproved.LoginUserId,
                                                null
                                                    };

            return dataAccess.LoadDataSet(parameters, "P_ChangeRequestStatus", "Status");
            //return dataAccess.ExecuteNonQuery("P_ChangeRequestStatus", parameters);
            //return dataAccess.LoadDataSet(parameters, "P_ConfirmRequest", "ConfirmRequest");
        }
        public DataSet SaveReinsurer(clsReinsurerMaster objReinsurer)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {//objReinsurer.RecId,
                                                objReinsurer.ReinsurerId,
                                                objReinsurer.ReinsurerCode,
                                                objReinsurer.ReinsurerName,
                                                objReinsurer.ChReinsurerName,
                                                objReinsurer.ReinsurerForModule,
                                                objReinsurer.CorrAddress1,
                                                objReinsurer.CorrAddress2,
                                                objReinsurer.CorrAddress3,
                                                objReinsurer.ChCorrAddress1,
                                               objReinsurer.ChCorrAddress2,
                                               objReinsurer.ChCorrAddress3,
                                               objReinsurer.Country,
                                               objReinsurer.BillingAddress1,
                                               objReinsurer.BillingAddress2,
                                               objReinsurer.BillingAddress3,
                                               objReinsurer.ChBillingAddress1,
                                               objReinsurer.ChBillingAddress2,
                                               objReinsurer.ChBillingAddress3,
                                               objReinsurer.BillingCountry,
                                               objReinsurer.Description,
                                               objReinsurer.RecordType,
                                               objReinsurer.SameCorrAddress,
                                               objReinsurer.SameChCorrAddress,
                                               objReinsurer.BusinessRegistrationNo,
                                               objReinsurer.GeneralLineCode,
                                               objReinsurer.GeneralLineNo,
                                               objReinsurer.FaxNoCode,
                                               objReinsurer.FaxNo,
                                               objReinsurer.CompanyEmail,
                                               objReinsurer.AccountType,
                                               objReinsurer.NormalBalance,
                                               objReinsurer.CreditControlAccountNo,
                                               objReinsurer.ClaimAccountType,
                                               objReinsurer.ClaimNormalBalance,
                                               objReinsurer.ClaimDebitControlAccountNo,
                                               objReinsurer.Remarks,
                                               objReinsurer.Level1ApprovedBy,
                                               objReinsurer.Level1ApprovedDate,
                                               objReinsurer.Level2ApprovedBy,
                                               objReinsurer.Level2ApprovedDate,
                                               objReinsurer.Level3ApprovedBy,
                                               objReinsurer.Level3ApprovedDate,
                                               objReinsurer.AdminApprovedBy,
                                               objReinsurer.AdminApprovedDate,
                                               objReinsurer.EffFromDate,
                                               objReinsurer.EffToDate,
                                               //objSOB.Status,
                                               objReinsurer.LoginUserId,
                                               //objClient.PageMethod
                                               objReinsurer.City,
                                               objReinsurer.Province,
                                               objReinsurer.PostalCode,
                                               objReinsurer.ChCity,
                                               objReinsurer.ChProvince,
                                               objReinsurer.ChPostalCode,
                                               objReinsurer.BillingCity,
                                               objReinsurer.BillingProvince,
                                               objReinsurer.BillingPostalCode,
                                               objReinsurer.ChBillingCity,
                                               objReinsurer.ChBillingProvince,
                                               objReinsurer.ChBillingPostalCode,
                                               objReinsurer.IType,
                                               objReinsurer.InsurerType
                                                    };
            //return dataAccess.LoadDataSet(parameters, "P_pol_ClientMaster_InsertUpdate", "ClientMaster");
            return dataAccess.LoadDataSet(parameters, "P_ReinsurerApprovedInfo_InsertUpdate", "ReinsuerMaster");
        }
        public DataSet SaveApprovedContacts(UnApprovedContacts objUnApprovContacts)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objUnApprovContacts.RecForId,
                                                objUnApprovContacts.RecordFor                        
                                                
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_ApprovedContacts_Save", "ApprovedContacts");
        }
        public DataSet GetApprovalDetails(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objUnApproved.RecId, objUnApproved.AppStatus };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GetApprovalDetails", "ApprovalDetails");
        }
        public DataSet GetApprovedInfoDetails(clsUnApprovedInfo objUnApproved,string strProcess, string strscrval)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objUnApproved.RecId, objUnApproved.RecForModule,objUnApproved.LoginUserId,objUnApproved.AppStatus,strProcess,strscrval };
            return dataAccess.LoadDataSet(parameters, "P_Reinsurer_ApprovedInfo_Select", "ApprovalDetails");
        }
        
    }
}
