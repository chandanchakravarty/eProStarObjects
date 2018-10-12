using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem
{
    public class clsUnderwriterManager
    {
        clsUnderWriterMaster objUnderwriter = new clsUnderWriterMaster();
        DataAccess dataAccess = null;
        UnderwriterContacts objContacts = new UnderwriterContacts();
        clsUnApprovedInfo objUnApproved = new clsUnApprovedInfo();
        #region Added By Neetu Sinha
        public DataSet getAppliedByList(int recid)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { recid };
            return dataAccess.LoadDataSet(parameters, "P_GetAppliedBy", "UnderwriterList");
        }
        #endregion

        public DataSet getUnApprovedUWList(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objUnApproved.RecId,objUnApproved.RecForModule, objUnApproved.ApprovingAuthority1, objUnApproved.AppStatus, objUnApproved.RecForType };
            return dataAccess.LoadDataSet(parameters, "P_Underwriter_UnApprovedInfo_Select", "UnderwriterList");
        }
        public DataSet getUnderwriterList(clsUnderWriterMaster objUnderwriter)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objUnderwriter.UnderWriterId, objUnderwriter.UnderwriterForModule };
            return dataAccess.LoadDataSet(parameters, "P_pol_UnderwriterMaster_Select", "UnderwriterMasterList");
        }

        public DataSet getApprovedUnderwriterList(clsUnderWriterMaster objUnderwriter,string process,string scrvl)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objUnderwriter.UnderWriterId, objUnderwriter.UnderwriterForModule, objUnderwriter.LoginUserId, null, process, scrvl };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_Underwriter_ApprovedInfo_Select", "UnderwriterMasterList");
        }



        public DataSet getApprovedUnderwriterListNew(clsUnderWriterMaster objUnderwriter, string process, string scrvl)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objUnderwriter.UnderWriterId, objUnderwriter.UnderwriterForModule, objUnderwriter.LoginUserId, null, process, scrvl };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_Underwriter_ApprovedInfo_New_Select", "UnderwriterMasterList");
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
        public DataSet getUnApprovUWContacts(UnApprovedContacts objContacts)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objContacts.RecForId, objContacts.ContactRecId, objContacts.RecForType,objContacts.RecForModule,objContacts.IsPriorityContact };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_Underwriter_Contacts_UnApprovedInfo_Select", "UnApprovedContactList");
        }

        //17838
        public DataSet getBankDetails(UnderwriterBankDetails objbankdtls)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objbankdtls.UnderwriterId , objbankdtls.UnderwriterForModule  };
            return dataAccess.LoadDataSet(parameters, "P_Underwriter_BankDetails_Select", "UnderwriterBankList");
        }


        public DataSet GetUnderwriterSearchNameWise(UnApprovedContacts objContacts)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] {  objContacts.SearchContactType, objContacts.RecForId, objContacts.ContactRecId, objContacts.RecForType,objContacts.RecForModule,objContacts.IsPriorityContact  };
            return dataAccess.LoadDataSet(parameters, "P_Underwriter_Contacts_SearchNamewise", "UnApprovedContactList");
            
            
            //P_Underwriter_Contacts_SearchNamewise
        }


        public DataSet GetunderwriterStatus(clsUnApprovedInfo objUnApproved)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objUnApproved.RecForId,objUnApproved.RecId,
                                            
                                                    };

            return dataAccess.LoadDataSet(parameters, "P_GetUnderwriterStatus", "Status");
         
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

        //17838
        public DataSet SaveUnderwriterBankDetails(UnderwriterBankDetails objUNBankDtls)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objUNBankDtls.BankId,
                                                objUNBankDtls.UnderwriterId,                                          
                                                objUNBankDtls.UnderwriterForModule,
                                                objUNBankDtls.BankName,
                                                objUNBankDtls.SwiftCode,
                                                objUNBankDtls.AccountNumber,
                                                objUNBankDtls.CurrencyType,
                                                objUNBankDtls.AccountType,
                                                objUNBankDtls.CreatedBy,
                                                objUNBankDtls.LastUpdatedBy
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Underwriter_BankDetails_InsertUpdate", "BankDetails");
        }

        public DataSet getSavedBankDetails(UnderwriterBankDetails objUNBankDtls)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objUNBankDtls.BankId, objUNBankDtls.UnderwriterId, objUNBankDtls.UnderwriterForModule };
            return dataAccess.LoadDataSet(parameters, "P_Get_Underwriter_BankDetails", "SavedBankDetails");
        }


        public DataSet deleteSelectedBankDetails(UnderwriterBankDetails objUNBankDtls)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new object[3] { objUNBankDtls.BankId, objUNBankDtls.UnderwriterId, objUNBankDtls.UnderwriterForModule };
            return dataAccess.LoadDataSet(parameters, "P_Delete_Selected_BankDetails", "BankDetailsDelete");
        }
        

        public DataSet SaveUnderwriter(clsUnderWriterMaster objUnderwriter)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {//objUnderwriter.RecId,
                                                objUnderwriter.UnderWriterId,
                                                objUnderwriter.UnderwriterCode,
                                                objUnderwriter.UnderwriterName,
                                                objUnderwriter.UnderwriterShortName,
                                                objUnderwriter.PreviousCode,
                                                objUnderwriter.CorporateGroup,
                                                objUnderwriter.Branch,
                                                objUnderwriter.Region,
                                                objUnderwriter.IType,
                                                objUnderwriter.InsurerTypeId,
                                                objUnderwriter.GSTRegistrationNumber,
                                                objUnderwriter.ChUnderwriterName,
                                                objUnderwriter.UnderwriterForModule,
                                                objUnderwriter.CorrAddress1,
                                                objUnderwriter.CorrAddress2,
                                                objUnderwriter.CorrAddress3,
                                                objUnderwriter.ChCorrAddress1,
                                               objUnderwriter.ChCorrAddress2,
                                               objUnderwriter.ChCorrAddress3,
                                               objUnderwriter.Country,
                                               objUnderwriter.BillingAddress1,
                                               objUnderwriter.BillingAddress2,
                                               objUnderwriter.BillingAddress3,
                                               objUnderwriter.ChBillingAddress1,
                                               objUnderwriter.ChBillingAddress2,
                                               objUnderwriter.ChBillingAddress3,
                                               objUnderwriter.BillingCountry,
                                               objUnderwriter.Description,
                                               objUnderwriter.RecordType,
                                               objUnderwriter.SameCorrAddress,
                                               objUnderwriter.SameChCorrAddress,
                                               objUnderwriter.CompanyRegistrationNo,
                                               objUnderwriter.BusinessRegistrationNo,
                                               objUnderwriter.RegistrationDate,
                                               objUnderwriter.GeneralLineCode,
                                               objUnderwriter.GeneralLineNo,
                                               objUnderwriter.FaxNoCode,
                                               objUnderwriter.FaxNo,
                                               objUnderwriter.CompanyEmail,
                                               objUnderwriter.AccountType,
                                               objUnderwriter.NormalBalance,
                                               objUnderwriter.CreditControlAccountNo,
                                               objUnderwriter.Remarks,
                                               objUnderwriter.Level1ApprovedBy,
                                               objUnderwriter.Level1ApprovedDate,
                                               objUnderwriter.Level2ApprovedBy,
                                               objUnderwriter.Level2ApprovedDate,
                                               objUnderwriter.Level3ApprovedBy,
                                               objUnderwriter.Level3ApprovedDate,
                                               objUnderwriter.AdminApprovedBy,
                                               objUnderwriter.AdminApprovedDate,
                                               objUnderwriter.EffFromDate,
                                               objUnderwriter.EffToDate,
                                               //objSOB.Status,
                                                objUnderwriter.LoginUserId,
                                                objUnderwriter.Premium_Settlement ,
                                                objUnderwriter.City,
                                                objUnderwriter.Province,
                                                objUnderwriter.PostalCode,
                                                objUnderwriter.ChCity,
                                                objUnderwriter.ChProvince,
                                                objUnderwriter.ChPostalCode,
                                                objUnderwriter.BillingCity,
                                                objUnderwriter.BillingProvince,
                                                objUnderwriter.BillingPostalCode,
                                                objUnderwriter.ChBillingCity,
                                                objUnderwriter.ChBillingProvince,
                                                objUnderwriter.ChBillingPostalCode,
                                                objUnderwriter.GlCode,
                                                objUnderwriter.BankCode,
                                                objUnderwriter.SubDistrict,
                                                objUnderwriter.ChSubDistrict,
                                                objUnderwriter.BillingSubDistrict,
                                                objUnderwriter.ChBillingSubDistrict,
                                                objUnderwriter.ProfitCentre,
                                                objUnderwriter.FundCode,
                                               //objClient.PageMethod
                                                objUnderwriter.SecurityGrading,
                                                objUnderwriter.GSTApplicable,
                                                objUnderwriter.WHTApplicable,
                                                objUnderwriter.VATApplicable,
                                                objUnderwriter.Offshore
                                                    };
            //return dataAccess.LoadDataSet(parameters, "P_pol_ClientMaster_InsertUpdate", "ClientMaster");
                return dataAccess.LoadDataSet(parameters, "P_UnderwriterApprovedInfo_InsertUpdate", "UnderwriterMaster");
        }
        public DataSet SaveApprovedContacts(UnderwriterContacts objContacts)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objContacts.UnderwriterId,                                          
                                                objContacts.UnderwriterForModule
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Underwriter_ApprovedContacts_Save", "ApprovedContacts");
        }
        public DataSet GetCode(string recForType, string country ,bool IschecekApproved)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { recForType, country ,IschecekApproved};
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GetRunningCode", "ClientCode");
        }
        public DataSet GetApprovalDetails(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objUnApproved.RecId, objUnApproved.AppStatus };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GetApprovalDetails", "ApprovalDetails");
        }

        #region Added by Gopal
        public DataSet getGLDetailList(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objUnApproved.GLCode, objUnApproved.GLCodeDesc };
            return dataAccess.LoadDataSet(parameters, "P_GLDetail_Select", "GLDetailList");
        }

        public DataSet getBankDetailList(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] {objUnApproved.BankCode, objUnApproved.BankName};
            return dataAccess.LoadDataSet(parameters, "P_BankDetail_Select", "BankDetailList");
        }
        public DataSet getBankDetailList(string BankCode, string BankName)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { BankCode, BankName };
            return dataAccess.LoadDataSet(parameters, "P_BankDetail_Select", "BankDetailList");
        }

        #endregion


        public int IsSavedInsRecord(int RecforId, int RecId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { RecforId, RecId };
            return dataAccess.ExecuteScalar("CheckIsInsRecExists", parameters);
        }
    }
}
