using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessObjectLayer.RIBrokingModule.RIBrokingSystem;

namespace BusinessAccessLayer.RIBrokingModule.RIBrokingSystem
{
    public class clsCedantManager
    {
        clsCedantMaster objCedant = new clsCedantMaster();
        DataAccess dataAccess = null;
        CedantContacts objContacts = new CedantContacts();
        clsUnApprovedInfo objUnApproved = new clsUnApprovedInfo();

        public DataSet getCedantList(clsCedantMaster objCedant)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objCedant.CedantId, objCedant.CedantForModule };
            return dataAccess.LoadDataSet(parameters, "P_pol_CedantMaster_Select", "CedantMasterList");
        }
      
        public DataSet getUnApprovCedantList(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            //Object[] parameters = new Object[2] { objUnApproved.RecId, objUnApproved.RecForModule};
            Object[] parameters = new Object[5] { objUnApproved.RecId, objUnApproved.ApprovingAuthority1, objUnApproved.RecForModule, objUnApproved.AppStatus, objUnApproved.RecordFor };
            return dataAccess.LoadDataSet(parameters, "P_Cedant_UnApprovedInfo_Select", "CedantList");
        }
        public DataSet getApprovCedantList(clsUnApprovedInfo objUnApproved,string process,string scrval)
        {
            dataAccess = new DataAccess();
            //Object[] parameters = new Object[2] { objUnApproved.RecId, objUnApproved.RecForModule};
            Object[] parameters = new Object[6] { objUnApproved.RecId, objUnApproved.CedantForModule, objUnApproved.LoginUserId, objUnApproved.AppStatus, process,scrval};
            return dataAccess.LoadDataSet(parameters, "P_Cedant_ApprovedInfo_Select", "CedantList");
        }
        public DataSet getUnApprovCedantContacts(UnApprovedContacts objContacts)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objContacts.RecForId, objContacts.ContactRecId, objContacts.RecForType, objContacts.RecForModule, objContacts.IsPriorityContact };
            return dataAccess.LoadDataSet(parameters, "P_UnApprovedContacts_Select", "UnApprovedContactList");
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
        public DataSet GetCode(string recForType, string country ,int IsApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { recForType, country, IsApproved };
            return dataAccess.LoadDataSet(parameters, "P_GetRunningCode", "CedantCode");
        }
        public DataSet SaveUnApprovedInfo(clsUnApprovedInfo objUnApproved, string company)
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
        
        public DataSet SaveCedant(clsCedantMaster objCedant)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                                                objCedant.CedantId,
                                                objCedant.CedantCode,
                                                objCedant.CedantName,
                                                objCedant.ChCedantName,
                                                objCedant.CedantForModule,
                                                objCedant.CorrAddress1,
                                                objCedant.CorrAddress2,
                                                objCedant.CorrAddress3,
                                                objCedant.ChCorrAddress1,
                                               objCedant.ChCorrAddress2,
                                               objCedant.ChCorrAddress3,
                                               objCedant.Country,
                                               objCedant.BillingAddress1,
                                               objCedant.BillingAddress2,
                                               objCedant.BillingAddress3,
                                               objCedant.ChBillingAddress1,
                                               objCedant.ChBillingAddress2,
                                               objCedant.ChBillingAddress3,
                                               objCedant.BillingCountry,
                                               objCedant.Description,
                                               objCedant.RecordType,
                                               objCedant.SameCorrAddress,
                                               objCedant.SameChCorrAddress,
                                               objCedant.BusinessRegistrationNo,
                                               objCedant.GeneralLineCode,
                                               objCedant.GeneralLineNo,
                                               objCedant.FaxNoCode,
                                               objCedant.FaxNo,
                                               objCedant.CompanyEmail,
                                               objCedant.AccountType,
                                               objCedant.NormalBalance,
                                               objCedant.CreditControlAccountNo,
                                               objCedant.ClaimAccountType,
                                               objCedant.ClaimNormalBalance,
                                               objCedant.ClaimDebitControlAccountNo,
                                               objCedant.Remarks,
                                               objCedant.Level1ApprovedBy,
                                               objCedant.Level1ApprovedDate,
                                               objCedant.Level2ApprovedBy,
                                               objCedant.Level2ApprovedDate,
                                               objCedant.Level3ApprovedBy,
                                               objCedant.Level3ApprovedDate,
                                               objCedant.AdminApprovedBy,
                                               objCedant.AdminApprovedDate,
                                               objCedant.EffFromDate,
                                               objCedant.EffToDate,
                                               objCedant.LoginUserId,
                                               objCedant.City,
                                               objCedant.Province,
                                               objCedant.PostalCode,
                                               objCedant.ChCity,
                                               objCedant.ChProvince,
                                               objCedant.ChPostalCode,
                                               objCedant.BillingCity,
                                               objCedant.BillingProvince,
                                               objCedant.BillingPostalCode,
                                               objCedant.ChBillingCity,
                                               objCedant.ChBillingProvince,
                                               objCedant.ChBillingPostalCode
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_CedantApprovedInfo_InsertUpdate", "CedantMaster");
        }

        public DataSet SaveApprovedContacts(UnApprovedContacts objUnApprovContacts)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objUnApprovContacts.RecForId,
                                                objUnApprovContacts.RecordFor                        
                                                
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_CedantApprovedContacts_Save", "ApprovedContacts");
        }
        public DataSet GetApprovalDetails(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objUnApproved.RecId, objUnApproved.AppStatus };
            return dataAccess.LoadDataSet(parameters, "P_GetApprovalDetails", "ApprovalDetails");
        }
    }
}
