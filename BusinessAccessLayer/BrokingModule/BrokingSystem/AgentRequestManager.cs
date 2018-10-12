using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
namespace BusinessAccessLayer.BrokingModule.BrokingSystem
{
    public class AgentRequestManager
    {
        DataAccess dataAccess = null;
        clsAgentRequest objAgent = new clsAgentRequest();
        clsUnApprovedInfo objUnApproved = new clsUnApprovedInfo();
        clsContacts objContacts = new clsContacts();

        public DataSet LoadApprovedAgentDetail(int AgentId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { AgentId };
            return dataAccess.LoadDataSet(parameters, "P_pol_AgentMaster_Select", "AgentMasterList");
        }

        public DataSet LoadAgentDetail(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objUnApproved.RecId, objUnApproved.RecordFor, objUnApproved.AppStatus, objUnApproved.AppStatus1, objUnApproved.LoginUserId, objUnApproved.scrval };
            return dataAccess.LoadDataSet(parameters, "P_pol_Agent_UnApprovedInfo_Select", "UnApprovedAgentList");
        }
        public DataSet getUnApprAgentContactList(UnApprovedContacts objContacts)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objContacts.RecForId,
                                                  objContacts.ContactRecId,
                                                  objContacts.RecForType,
                                                  objContacts.IsPriorityContact,
                                                  objContacts.SearchContactType
            };
            return dataAccess.LoadDataSet(parameters, "P_Agent_Contacts_UnApprovedInfo_Select", "UnApprovedContactList");
        }
        public DataSet getUnApprAgentCommisionList(UnApprovedCommission objCommission)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objCommission.RecForId,                                                  
                                                  objCommission.RecForType,
                                                  objCommission.CommitionId
            };
            return dataAccess.LoadDataSet(parameters, "P_Introducer_UnApprovedCommitionInfo_Select", "UnApprovedCommissionList");
        }

        public DataSet getAgentAgreementList(UnApprovedAgreements objAgreements)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objAgreements.RecForId,
                                                  objAgreements.AgreementRecId
                                                  //objAgreements.RecForType
            };
            return dataAccess.LoadDataSet(parameters, "P_Agent_Agreement_UnApprovedInfo_Select", "UnApprovedAgreementList");
        }

        public DataSet getAgentAgreementListsearch(UnApprovedAgreements objAgreements)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objAgreements.RecForId,
                                                  objAgreements.AgreementNo
                                                  //objAgreements.RecForType
            };
            return dataAccess.LoadDataSet(parameters, "P_Agent_Agreement_UnApprovedInfo_Search", "UnApprovedAgreementList1");
        }
        public DataSet AgentAgreementListSearchExpired(UnApprovedAgreements objAgreements)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objAgreements.AgreementNo,
                                                  objAgreements.AgentCode,
                                                  objAgreements.ClientCode,
                                                  objAgreements.ExpiryDateFrom,
                                                  objAgreements.ExpiryDateTo,
                                            
            };
            return dataAccess.LoadDataSet(parameters, "P_Agent_Agreement_UnApprovedInfo_Expired_Srch", "UnApprovedAgreementExpiredList");
        }

        public DataSet SaveAgent(clsAgentRequest objAgent)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                                                objAgent.AgentId,
                                                objAgent.AgentCode,
                                                objAgent.AgentName,
                                                objAgent.PreviousCode,
                                                objAgent.IntroducerShortN,
                                                objAgent.AgentShortName,
                                                objAgent.ChAgentName,
                                                objAgent.CorrAddress1,
                                                objAgent.CorrAddress2,
                                                objAgent.CorrAddress3,
                                                objAgent.CorrAddress4,
                                                objAgent.ChCorrAddress1,
                                                objAgent.ChCorrAddress2,
                                                objAgent.ChCorrAddress3,
                                                objAgent.ChCorrAddress4,
                                                objAgent.Country,
                                                objAgent.Nationality,
                                                objAgent.PassportNo,
                                                objAgent.Gender,
                                                objAgent.BillingAddress1,
                                                objAgent.BillingAddress2,
                                                objAgent.BillingAddress3,
                                                objAgent.BillingAddress4,
                                                objAgent.ChBillingAddress1,
                                                objAgent.ChBillingAddress2,
                                                objAgent.ChBillingAddress3,
                                                objAgent.ChBillingAddress4,
                                                objAgent.BillingCountry,
                                                objAgent.ChBillingCountry,
                                                objAgent.Description,
                                                objAgent.RecordType,
                                                objAgent.CorporateGroup,
                                                objAgent.GSTRegistrationNo,
                                                objAgent.RecordTypeCategory,
                                                objAgent.SameCorrAddress,
                                                objAgent.SameChCorrAddress,
                                                objAgent.BusinessRegistrationNo,
                                                objAgent.CompanyRegNo,
                                                objAgent.CompanyRegDate,
                                                objAgent.GeneralLineCode,
                                                objAgent.GeneralLineNo,
                                                objAgent.FaxNoCode,
                                                objAgent.FaxNo,
                                                objAgent.CompanyEmail,
                                                objAgent.AccountType,
                                                objAgent.NormalBalance,
                                                objAgent.CreditLimit,
                                                objAgent.CreditTerms,
                                                objAgent.CreditTermsOption,
                                                objAgent.CreditTermsOptionValue,
                                                objAgent.PaymentEffectiveFrom,
                                                objAgent.PaymentEffectiveTo,
                                                objAgent.Jan,
                                                objAgent.Feb,
                                                objAgent.Mar,
                                                objAgent.Apr,
                                                objAgent.May,
                                                objAgent.Jul,
                                                objAgent.Jul,
                                                objAgent.Aug,
                                                objAgent.Sep,
                                                objAgent.Oct,
                                                objAgent.Nov,
                                                objAgent.Dec,
                                                objAgent.CreditControlAccountNo,
                                                objAgent.Remarks,
                                                objAgent.Level1ApprovedBy,
                                                objAgent.Level1ApprovedDate,
                                                objAgent.Level2ApprovedBy,
                                                objAgent.Level2ApprovedDate,
                                                objAgent.Level3ApprovedBy,
                                                objAgent.Level3ApprovedDate,
                                                objAgent.AdminApprovedBy,
                                                objAgent.AdminApprovedDate,
                                                objAgent.EffFromDate,
                                                objAgent.EffToDate,
                                               //objSOB.Status,
                                                objAgent.LoginUserId,
                                               //objClient.PageMethod
                                                objAgent.City,
                                                objAgent.Province,
                                                objAgent.PostalCode,
                                                objAgent.ChCity,
                                                objAgent.ChProvince,
                                                objAgent.ChPostalCode,
                                                objAgent.BillingCity,
                                                objAgent.BillingProvince,
                                                objAgent.BillingPostalCode,
                                                objAgent.ChBillingCity,
                                                objAgent.ChBillingProvince,
                                                objAgent.ChBillingPostalCode,
                                                objAgent.SubDistrict,
                                                objAgent.ChSubDistrict,
                                                objAgent.BillingSubDistrict,
                                                objAgent.ChBillingSubDistrict,
                                                objAgent.DocumentCompilanceName,                                               
                                                objAgent.BankName,
                                                objAgent.BankBranch,
                                                objAgent.BankAccount,
                                                 objAgent.OwnPercentage,
                                                objAgent.IntroducerPercentage,
                                                 objAgent.Region,
                                                objAgent.ICNoNew,
                                                objAgent.ICNoOld,
                                                objAgent.GSTCodeRate,                                                
                                                objAgent.GSTEffectiveDate,
                                                objAgent.IsSelfBilling,
                                                objAgent.CustomApprovalNo,
                                                objAgent.SuspensionFromDate,
                                                objAgent.SuspensionToDate,
                                                objAgent.SuspensionReason,
                                                objAgent.TerminationEffectiveDate,
                                                objAgent.TerminationReason,
                                                objAgent.IsNOTaDirectorOfThePrincipal,
                                                objAgent.IsNOTAnEmployeeOfThePrincipal,
                                                objAgent.IsNOTRelatedToAnyPrincipalOfficersOfThePrincipal,
                                                objAgent.IsNOTAnEmployeeOfBIB,
                                                objAgent.IsNOTRelatedToAnyEmployeeOfBIB,
                                                objAgent.BrokerageSharingForAllClasses,
                                                objAgent.CopyOfICOrForm9OrForm13IsReceived,
                                                objAgent.Branch,
                                                objAgent.ProfitCentre,
                                                objAgent.FundCode
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_pol_AgentApprovedInfo_InsertUpdate", "AgentMaster");
        }
        //public DataSet SaveAgentContact(clsContacts objContact)
        //{

        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[] {objContact.ContactId,
        //                                        objContact.Id,
        //                                        objContact.LastName,
        //                                        objContact.ChLastName,
        //                                        objContact.FirstName,
        //                                        objContact.ChFirstName,
        //                                        objContact.JobTitle,
        //                                        objContact.ChJobTitle,
        //                                       objContact.Department,
        //                                       objContact.ChDepartment,
        //                                       objContact.ContactCorrAddress1,
        //                                       objContact.ContactCorrAddress2,
        //                                       objContact.ContactCorrAddress3,
        //                                       objContact.ChContactCorrAddress1,
        //                                       objContact.ChContactCorrAddress2,
        //                                       objContact.ChContactCorrAddress3,
        //                                       objContact.ContactCountry,
        //                                       objContact.ChContactCountry,
        //                                       objContact.Team,
        //                                       //objContact.Dob,
        //                                       objAgent.GeneralLineCode,
        //                                       objContact.GeneralLineNo,
        //                                       objContact.Extension,
        //                                       objContact.Salutation,
        //                                       objContact.ChSalutation,
        //                                       objContact.MobileNoCode,
        //                                       objContact.MobileNo,
        //                                       objContact.FaxNoCode,
        //                                       objContact.FaxNo,
        //                                       objContact.Email,
        //                                       objAgent.EffFromDate,
        //                                       objAgent.EffToDate,
        //                                       objAgent.LoginUserId,
        //                                       objAgent.PageMethod
        //                                            };
        //    return dataAccess.LoadDataSet(parameters, "P_Contacts_ApprovedInfo_InsertUpdate", "AgentContacts");
        //}
        //public DataSet SaveApprovedContacts(clsContacts objContacts)
        //{

        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[] {objContacts.Id                                          

        //                                            };
        //    return dataAccess.LoadDataSet(parameters, "P_SaveApprovedContacts", "ApprovedContacts");
        //}
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

        }
        public DataSet GetCode(string recForType, string country, bool IsCheckApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { recForType, country ,IsCheckApproved};
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GetRunningCode", "ClientCode");
        }
        public DataSet SaveUnApprovedInfo(clsUnApprovedInfo objUnApproved, int companyid)
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
                                                companyid
                                                
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_UnApprovedInfo_InsertUpdate", "UnApprovedAgentInfo");
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
                                                objUnApprovContacts.IsPriorityContact
                                                ,objUnApprovContacts.IsContactSOA
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Contacts_UnApprovedInfo_InsertUpdate", "UnApprovedContactInfo");
        }
        public DataSet CheckForApprovalVisible(string RecId, string RecForId, string RecFortype)
        {
            //Method to Approval button visibility
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {RecId,RecForId,RecFortype};
            return dataAccess.LoadDataSet(parameters, "P_Agent_CheckForApprovalVisible", "pol_Contacts_UnApprovedInfo");
        }
        public DataSet SaveUnApprovedCommitionInfo(UnApprovedCommission objUnApprovCommission)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objUnApprovCommission.CommitionRecId,
                                                //objUnApprovContacts.ClientRecId,
                                                objUnApprovCommission.IntroducerSharePer,
                                                objUnApprovCommission.EffectiveFrom,
                                                objUnApprovCommission.EffectiveTo,
                                                objUnApprovCommission.RecForType,
                                                objUnApprovCommission.RecordFor,
                                                objUnApprovCommission.RecForId,                                               
                                                objUnApprovCommission.AppliedBy,                                               
                                                objUnApprovCommission.LoginUserId ,
                                                objUnApprovCommission.PageMethod,
                                                objUnApprovCommission.CommitionId,
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Commission_UnApprovedInfo_InsertUpdate", "UnApprovedCommitionInfo");
        }

        public DataSet SaveUnApprovedAgreementInfo(UnApprovedAgreements objUnApprovAgreements)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objUnApprovAgreements.AgreementRecId,
                                                //objUnApprovContacts.ClientRecId,
                                                objUnApprovAgreements.RecForType,
                                                objUnApprovAgreements.RecordFor,
                                                objUnApprovAgreements.RecForId,
                                                objUnApprovAgreements.RecForModule,
                                                objUnApprovAgreements.AppliedBy,
                                                objUnApprovAgreements.AppStatus,
                                                objUnApprovAgreements.LoginUserId,
                                                objUnApprovAgreements.RecData                                                
                                                
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Agreement_UnApprovedInfo_InsertUpdate", "UnApprovedContactInfo");
        }

        public DataSet SaveAgentApprovedContacts(int AgentId)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { AgentId };

            return dataAccess.LoadDataSet(parameters, "P_pol_Agent_ApprovedContacts_Save", "ApprovedContacts");
        }
        public DataSet GetPaymentForAgentDetails(string AgentName, string MonthFrom, string MonthTo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { AgentName, MonthFrom, MonthTo };
            return dataAccess.LoadDataSet(parameters, "P_pol_PaymentForAgent_Select", "AgentMasterList");
        }
        public DataSet LoadPaymentForAgent(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objUnApproved.RecId, objUnApproved.RecForType, objUnApproved.AppStatus, objUnApproved.AppStatus1, objUnApproved.LoginUserId, null };
            return dataAccess.LoadDataSet(parameters, "P_pol_PaymentForAgentDetails_Select", "UnApprovedAgentList");
        }
    }
}