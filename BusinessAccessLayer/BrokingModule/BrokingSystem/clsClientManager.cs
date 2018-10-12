using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Claims;
using BusinessObjectLayer.SystemAdmin.ClientSetup;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem
{
    public class clsClientManager
    {
        DataAccess dataAccess = null;
        clsClientMaster objClient = new clsClientMaster();
        clsUnApprovedInfo objUnApproved = new clsUnApprovedInfo();
        ClientContacts objContacts = new ClientContacts();
        //
        public DataSet getAgentHistoryList(int recid)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { recid };

            return dataAccess.LoadDataSet(parameters, "P_pol_IntroducerMasterHistory_Select", "ClientMasterList");
        }

        //
        public DataSet getClientHistoryList(int recid)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { recid };

            return dataAccess.LoadDataSet(parameters, "P_pol_ClientMasterHistory_Select", "ClientMasterList");
        }



        //
        public DataSet getUndewriterHistoryList(int recid)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { recid };

            return dataAccess.LoadDataSet(parameters, "P_pol_UnderwiterMasterHistory_Select", "ClientMasterList");
        }

        public DataSet getClientSourceList()
        {
            dataAccess = new DataAccess();
            // Object[] parameters = new Object[] { objClientsource.ClientSourceName };
            return dataAccess.LoadDataSet("P_GetClientSource", "ClientSourceTable");

        }


        public DataSet getCorporateCNComp(string coverNote, string policyNum, int MainClassId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { coverNote, policyNum, MainClassId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "p_pol_CorporateCN_completed", "p_pol_CorporateCN_completed");
        }



        
        public DataSet getClientList(clsClientMaster objClient)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objClient.ClientId, objClient.ClientForModule };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_pol_ClientMaster_Select", "ClientMasterList");
        }
        public DataSet getSubsidaryClientList(clsClientMaster objClient)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objClient.ClientCode};
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_Pol_MasterClientReport_Subsidary", "ClientMasterList");
        }
        public DataSet getClientListSrch(int RecId, string strForModule, string strClientType, string strFlag, string strWhereClause, int iStartElt, string strIsTotal)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[7] { RecId, strForModule, strClientType, strFlag, strWhereClause, iStartElt, strIsTotal };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_UnApprovedInfo_Search_1", "ClientMasterList");
        }

        //





        public DataSet getClientListSrch_Change(int RecId, string strForModule, string strClientType, string strFlag, string strWhereClause, int iStartElt, string strIsTotal)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[7] { RecId, strForModule, strClientType, strFlag, strWhereClause, iStartElt, strIsTotal };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_UnApprovedInfo_Search_1_Change", "ClientMasterList");
        }


        public DataSet getApprovedInfo(int RecId, string UserId, string strForModule, string process, string forScreen, string strFlag, string strWhereClause, string strIsTotal)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[9] { RecId, UserId, strForModule, process, forScreen, strFlag, strWhereClause, 0, strIsTotal };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_ClientApprovedInfo_Search", "ClientMasterList");
        }
        public DataSet getUnApprovClientName(clsClientMaster objClient)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objClient.ClientId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "[P_UnApprovedInfo_ClientNameSelect]", "pol_UnApprovedInfo");
        }
        public DataSet getContactList(ClientContacts objContacts)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objContacts.ClientId, objContacts.ClientForModule, objContacts.ContactId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_pol_ClientContactDetails_Select", "ContactsList");
        }
        public DataSet getUnApprovClientCopydetails(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objUnApproved.Code, objUnApproved.RecForModule, null };

            return dataAccess.LoadDataSet(parameters, "P_ClientInfo_SelectByCode", "UnApprovedClientList");
        }
        public DataSet getUnApprovClientList(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objUnApproved.RecId, objUnApproved.RecForModule, null, null, null, null };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_UnApprovedInfo_Select", "UnApprovedClientList");
        }
        public DataSet getClientStatusList(int recid)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { recid };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "p_GetClientStatus", "UnApprovedClientList");
        }

        public DataSet getUnApprovPotentialClientList(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objUnApproved.RecId, objUnApproved.RecForModule, objUnApproved.ClientType, objUnApproved.ClientShortName, objUnApproved.ClientSourceCode, objUnApproved.CorporateGroupType };

            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_UnApprovedInfo_Select", "UnApprovedClientList");
        }
        //
        public DataSet getUnApprovConvertPotentialClientList(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objUnApproved.RecId, objUnApproved.RecForModule, objUnApproved.ClientType };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_UnApprovedInfo_Select_potentail", "UnApprovedClientList");
        }




        // For make search faster in client pop-up
        public DataSet getClientList(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objUnApproved.RecId, objUnApproved.RecForModule, null };

            return dataAccess.LoadDataSet(parameters, "P_UnApprovedInfo_ClientSelect", "UnApprovedClientList");
        }

        //For faster client search in closing slip and quotation (#25922)
        public DataSet getUnapprovedClientName(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objUnApproved.RecId, objUnApproved.RecForModule, null };

            return dataAccess.LoadDataSet(parameters, "P_UnApprovedInfo_ClientSelect_ClientName", "UnApprovedClientList");
        }

        public DataSet getUnapprovedClientNameWithProspectClient(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objUnApproved.RecId, objUnApproved.RecForModule, null };

            return dataAccess.LoadDataSet(parameters, "P_UnApprovedInfo_ClientSelect_ClientNameWithProspectClient", "UnApprovedClientList");
        }

        public DataSet GetMasterClient(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objUnApproved.RecId, objUnApproved.RecForModule, null };

            return dataAccess.LoadDataSet(parameters, "P_GetMasterClient", "GetMasterClient");
        }

        public DataSet getUnApprovContactList(UnApprovedContacts objContacts)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objContacts.RecForId, objContacts.ContactRecId, objContacts.RecForType, objContacts.RecForModule, objContacts.IsPriorityContact, objContacts.SearchContactType };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_Contacts_UnApprovedInfo_Select", "UnApprovedContactList");
        }


        //
        public DataSet SaveClientHiostory(clsClientMaster objClient)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objClient.ClientId, objClient.ClientName, objClient.ClientCode, objClient.ClientShortName, objClient.RecId };
            return dataAccess.LoadDataSet(parameters, "P_pol_ClientMasterHistory_InsertUpdate", "ClientHistory");

        }

        //
        public DataSet SaveUnderwriterHiostory(clsUnderWriterMaster objU)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objU.UnderWriterId, objU.UnderwriterName, objU.UnderwriterCode, objU.UnderwriterShortName, objU.RecId };
            return dataAccess.LoadDataSet(parameters, "P_pol_UnderwriterMasterHistory_InsertUpdate", "ClientHistory");

        }
        //
        public DataSet SaveAgentHiostory(clsAgentRequest objAgent)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objAgent.AgentId, objAgent.AgentName, objAgent.AgentCode, objAgent.AgentShortName, objAgent.RecId };
            return dataAccess.LoadDataSet(parameters, "P_pol_IntroducerMasterHistory_InsertUpdate", "ClientHistory");

        }
        public DataSet SaveClient(clsClientMaster objClient)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {//objClient.RecId,

                                               objClient.introducer1Id,
                                           objClient.introducer2Id ,
            objClient.ClientSource1 ,
            objClient.ClientSource2 ,
            objClient.CompanyTypeId ,
            objClient.RiskProfileId ,
            objClient.KeyManagerId,

           // objClient.IndustryTypeId,
           objClient.IndustryPIAM,
                                                objClient.ClientId,
                                                objClient.ClientForModule,
                                                objClient.ClientCode,
                                                objClient.ClientName,
                                                objClient.ChClientName,
                                                objClient.CorrAddress1,
                                                objClient.CorrAddress2,
                                                objClient.CorrAddress3,
                                                objClient.ChCorrAddress1,
                                               objClient.ChCorrAddress2,
                                               objClient.ChCorrAddress3,
                                               objClient.Country,
                                               objClient.BillingAddress1,
                                               objClient.BillingAddress2,
                                               objClient.BillingAddress3,
                                               objClient.ChBillingAddress1,
                                               objClient.ChBillingAddress2,
                                               objClient.ChBillingAddress3,
                                               objClient.BillingCountry,
                                               objClient.Description,
                                               objClient.RecordType,
                                               //objClient.RecordTypeCategory,
                                               objClient.ClientType,
                                               objClient.Category_V,
                                               objClient.ClientStatus,
                                               //objClient.Category_L,
                                               objClient.SameCorrAddress,
                                               objClient.SameChCorrAddress,
                                               objClient.CompanyRegistrationNo,
                                               objClient.BusinessRegistrationNo,
                                               objClient.GeneralLineCode,
                                               objClient.GeneralLineNo,
                                               objClient.FaxNoCode,
                                               objClient.FaxNo,
                                               objClient.CompanyEmail,
                                               objClient.SourceOfBusiness,
                                               objClient.MasterSourceCode,
                                               objClient.BusinessNatureCode,
                                               objClient.SubsidiarySourceCode1,
                                               objClient.SubsidiarySourceCode2,
                                               objClient.SourceCode,
                                               objClient.AccountType,
                                               objClient.NormalBalance,
                                               objClient.DebtorControlAccountNo,
                                               objClient.GroupName,
                                               objClient.GroupNameForAnalysis,
                                               objClient.SubGroup,
                                               objClient.SubGroupForAnalysis,
                                               objClient.Remarks,
                                               objClient.Nationality,
                                               objClient.MaritalSatus,
                                               //objClient.DOB,
                                               objClient.DayOfBirth,
                                               objClient.MonthOfBirth,
                                               objClient.YearOfBirth,
                                               objClient.PassportNumber,
                                               objClient.Occupation,
                                               objClient.SendNotification,
                                               objClient.Gender,
                                               objClient.Level1ApprovedBy,
                                               objClient.Level1ApprovedDate,
                                               objClient.Level2ApprovedBy,
                                               objClient.Level2ApprovedDate,
                                               objClient.Level3ApprovedBy,
                                               objClient.Level3ApprovedDate,
                                               objClient.AdminApprovedBy,
                                               objClient.AdminApprovedDate,
                                               objClient.EffFromDate,
                                               objClient.EffToDate,
                                               //objSOB.Status,
                                               objClient.LoginUserId,
                                               objClient.City,
                                               objClient.Province,
                                               objClient.PostalCode,
                                               objClient.ChCity,
                                               objClient.ChProvince,
                                               objClient.ChPostalCode,
                                               objClient.BillingCity,
                                               objClient.BillingProvince,
                                               objClient.BillingPostalCode,
                                               objClient.ChBillingCity,
                                               objClient.ChBillingProvince,
                                               objClient.ChBillingPostalCode,
                                               objClient.SubDistrict,
                                               objClient.ChSubDistrict,
                                               objClient.BillingSubDistrict,
                                               objClient.ChBillingSubDistrict,
                                               //objClient.PageMethod

                                               //Added By Ravi

                                                objClient.ClientShortName,
                                                objClient.CorrAddress4      ,
                                                objClient.ChCorrAddress4    ,
                                                objClient.BillingAddress4   ,
                                                objClient.ChBillingAddress4 ,

                                                objClient.GstRgNumber           ,
                                                objClient.Branch                ,
                                                objClient.Region                ,
                                                objClient.ClientIncorporatedDate,

                                                objClient.ICNoNew1       ,
                                                objClient.ICNoNew2       ,
                                                objClient.ICNoNew3       ,
                                                objClient.ICNoOld        ,
                                                objClient.CorelatedClient,

                                                objClient.ClientSource   ,
                                                objClient.ClientSegment  ,
                                                objClient.IndustryPIAM   ,
                                                objClient.ClientBanding  ,
                                                objClient.CorporateGroup ,

                                                objClient.ServicingTeam          ,
                                                objClient.ServicingUserName      ,
                                                objClient.ServicingEffectiveDate ,

                                                objClient.MarketingTeam              ,
                                                objClient.MarketingUserName          ,
                                                objClient.MarketingEffectiveFromdate ,

                                                objClient.IntroducerName         ,
                                                objClient.IntroducerCode         ,
                                                objClient.IntroducerEffectiveDate,

                                                objClient.SuspensionFromDate        ,
                                                objClient.SuspensionToDate          ,
                                                objClient.SuspensionReason          ,
                                                objClient.TerminationEffectiveDate  ,
                                                objClient.TerminationReason         ,

                                                objClient.AMLACustomerType ,
                                                objClient.AMLACompanyRegNo ,
                                                objClient.AMLAICNoOld      ,
                                                objClient.AMLAICNoNew1     ,
                                                objClient.AMLAICNoNew2     ,
                                                objClient.AMLAICNoNew3     ,
                                                objClient.AMLAPassportNo   ,
                                                objClient.AMLAIsIncident   ,
                                                objClient.AMLADateCheck    ,
                                                objClient.AMLAAuditedBy,    
                                               //End By Ravi
                                              
                                               objClient.ProfitCentre,
                                               objClient.FundCode,
                                               objClient.MasterClientCode
                                                    };
            //return dataAccess.LoadDataSet(parameters, "P_pol_ClientMaster_InsertUpdate", "ClientMaster");
            return dataAccess.LoadDataSet(parameters, "P_ClientApprovedInfo_InsertUpdate", "ClientMaster");
        }
        //public DataSet SaveClientContact(ClientContacts objContact)
        //{

        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[] {objContact.ContactId,
        //                                        objContact.ClientId,
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
        //                                       objContact.Dob,
        //                                       objClient.GeneralLineCode,
        //                                       objContact.GeneralLineNo,
        //                                       objContact.Extension,
        //                                       objContact.Salutation,
        //                                       objContact.ChSalutation,
        //                                       objContact.MobileNoCode,
        //                                       objContact.MobileNo,
        //                                       objContact.FaxNoCode,
        //                                       objContact.FaxNo,
        //                                       objContact.Email,
        //                                       objClient.EffFromDate,
        //                                       objClient.EffToDate,
        //                                       //objSOB.Status,
        //                                       objClient.LoginUserId,
        //                                       objClient.PageMethod
        //                                            };
        //    return dataAccess.LoadDataSet(parameters, "P_Contacts_ApprovedInfo_InsertUpdate", "ClientContacts");
        //}
        public DataSet SaveApprovedContacts(ClientContacts objContacts)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objContacts.ClientId,
                                                objContacts.ClientForModule                          
                                                
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_SaveApprovedContacts", "ApprovedContacts");
        }

        // For Underwriter


        public DataSet SaveApprovedUnderwriterContacts(ClientContacts objContacts)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objContacts.ClientId,
                                                objContacts.ClientForModule                          
                                                
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_SaveApprovedUnderwriterContacts", "ApprovedContacts");
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
                                                objUnApproved.Code
                                             
                                             
                                                    };

            return dataAccess.LoadDataSet(parameters, "P_ChangeRequestStatus", "Status");
            //return dataAccess.ExecuteNonQuery("P_ChangeRequestStatus", parameters);
            //return dataAccess.LoadDataSet(parameters, "P_ConfirmRequest", "ConfirmRequest");
        }
        //public SqlDataReader getGroup(clsGroupMaster objGroup)
        //{
        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[1] { objGroup.SCId };
        //    //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
        //    //return dataAccess.LoadDataSet(parameters, "P_GetSourceCodeBySOB", "MasterSourceCodeBySOB");
        //    return dataAccess.GetDataReader(parameters, "P_GetGroupById");
        //}
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

        public DataSet GetCountryCode(int CountryId)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {CountryId
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_TM_GetCountryCode", "UnApprovedClientInfo");
        }

        public DataSet SavePotentialClientInfo(clsUnApprovedInfo objUnApproved)
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
                                                 objUnApproved.Code
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_PotentialClient_InsertUpdate", "UnApprovedClientInfo");
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

        public DataSet GetCode(string recForType, string country, bool IsCheckedunapprove)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { recForType, country,IsCheckedunapprove };
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
        public Boolean CheckClientNameExists(clsUnApprovedInfo objUnApproved)
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
                                                 objUnApproved.Code
                                                 
                                                    };
            return Convert.ToBoolean(dataAccess.GetScalarValue(parameters, "P_CheckClientNameExists"));
        }
        public DataSet GetCompanyDetailsForApprLvl(int compId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { compId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_TM_CompanyMaster_Select", "CompDetails");
        }

        // Added By Gopal For Gl Code Pop Up
        public DataSet getGlCodeList(clsUnApprovedInfo objUnApproved)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objUnApproved.RecId, objUnApproved.RecForModule, null };

            return dataAccess.LoadDataSet(parameters, "P_UnApprovedInfo_ClientSelect", "UnApprovedClientList");
        }

        public DataSet GetSubsidiaryClientListByClientCode(string ClientCode)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { ClientCode };
            return dataAccess.LoadDataSet(parameters, "P_SubsidiaryClientList", "SubsidiaryClientList");
        }

        public DataSet GetWICAClaimInfoDropDownValues()
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { };
            return dataAccess.LoadDataSet(parameters, "P_WICAClaimInfoDropDownValues", "WICAClaimInfoDropDownValues");
        }

        public DataSet GetWICACheckListDropDownValues()
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { };
            return dataAccess.LoadDataSet(parameters, "P_WICACheckListDropDownValues", "WICACheckListDropDownValues");
        }

        public DataSet InsertUpdateWICAClaimPendingDocuments(WICACheckListDocuments obj)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[7] { obj.CaseRefNo, obj.ClaimRefNo, obj.MasterDesc, obj.MasterCode, obj.DocRequired, obj.DocReceivedDate, obj.CreatedBy };
            return dataAccess.LoadDataSet(parameters, "P_InsertUpdateWICAClaimPendingDocuments", "InsertUpdateWICAClaimPendingDocuments");
        }

        public DataSet WICASelectClaimPendingDocuments(string CaseRefNo, string ClaimRefNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { CaseRefNo, ClaimRefNo };
            return dataAccess.LoadDataSet(parameters, "P_WICA_SelectClaimPendingDocuments", "WICASelectClaimPendingDocuments");
        }

        public DataSet GetClaimAdminSummaryValues(string MasterFor, string MasterName)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { MasterFor, MasterName };
            return dataAccess.LoadDataSet(parameters, "P_GetClaimAdminSummaryValues", "ClaimAdminSummaryValues");
        }

        public DataSet GetFollowupReasonMasterValues(string ForMaster)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { ForMaster };
            return dataAccess.LoadDataSet(parameters, "P_GetFollowupReasonMasterValues", "FollowupReasonMasterValues");
        }

        public DataSet GetClaimAgentAdminSummaryValues(string CAgentFor, string CAgentType)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { CAgentType, CAgentFor };
            return dataAccess.LoadDataSet(parameters, "P_GetClaimAgentAdminSummaryValues", "ClaimAgentAdminSummaryValues");
        }

        public DataSet WICAClaimCalculationsInsertUpdate(WICAClaimCalculations objClaimCalc)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                objClaimCalc.CalculationId
                ,objClaimCalc.ClaimRefNo
                ,objClaimCalc.ClaimId
                ,objClaimCalc.ClaimantName
                ,objClaimCalc.DateReceivedFromClient
                ,objClaimCalc.WorkingDays
                ,objClaimCalc.DateSentToInsurer
                ,objClaimCalc.Denominator
                ,objClaimCalc.Currency
                ,objClaimCalc.MonthlyWages
                ,objClaimCalc.DailyWage
                ,objClaimCalc.ManualOverwrite
                ,objClaimCalc.IsActive
                ,objClaimCalc.CreatedBy
            };
            return dataAccess.LoadDataSet(parameters, "P_WICA_ClaimCalculations_InsertUpdate", "WICAClaimCalculationsInsertUpdate");
        }

        public DataSet WICAClaimPaymentSelect(string ClaimRefNo, string ClaimId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new object[2] { ClaimRefNo, ClaimId };
            return dataAccess.LoadDataSet(parameters, "P_WICA_ClaimPayment_Select", "ClaimPaymentSelect");
        }

        public DataSet WICAClaimPaymentDelete(string ClaimRefNo, int ClaimId, int PaymentDetailId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new object[3] { PaymentDetailId, ClaimRefNo, ClaimId };
            return dataAccess.LoadDataSet(parameters, "P_WICA_ClaimPaymentDetails_Delete", "ClaimPaymentDelete");
        }

        public DataSet WICAClaimCalculationSelect(string ClaimRefNo, int ClaimId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new object[2] { ClaimRefNo, ClaimId };
            return dataAccess.LoadDataSet(parameters, "P_WICA_ClaimCalculations_Select", "ClaimCalculationSelect");
        }

        public DataSet WICAClaimCalculationMCRecordDelete(string ClaimRefNo, int ClaimId, int MCRecordId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new object[3] { ClaimRefNo, ClaimId, MCRecordId };
            return dataAccess.LoadDataSet(parameters, "P_WICA_ClaimCalculationsMCRecord_Delete", "ClaimCalculationsMCRecordDelete");
        }

        public DataSet WICAClaimCalculationMedicalExpenseDelete(string ClaimRefNo, int ClaimId, int MedicalExpenseId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new object[3] { ClaimRefNo, ClaimId, MedicalExpenseId };
            return dataAccess.LoadDataSet(parameters, "P_WICA_ClaimCalculationsMedicalExpense_Delete", "ClaimCalculationsMedicalExpenseDelete");
        }

        public DataSet WICAClaimCalculationPaymentIncapabilityDelete(string ClaimRefNo, int ClaimId, int PaymentIncapabilityId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new object[3] { ClaimRefNo, ClaimId, PaymentIncapabilityId };
            return dataAccess.LoadDataSet(parameters, "P_WICA_ClaimCalculationsPaymentIncapability_Delete", "ClaimCalculationsPaymentIncapabilityDelete");
        }

        public DataSet GetWICAClaimPendingDocuments(string ClaimNo, int ClaimId, string ClaimType)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new object[3] { ClaimNo, ClaimId, ClaimType };
            return dataAccess.LoadDataSet(parameters, "P_ClaimPendingDocumentsSelect", "ClaimPendingDocumentsSelect");
        }

        public DataSet ReminderSetupInsertUpdate(ReminderSetup obj)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new object[9] { obj.ReminderSetUpId, obj.Class, obj.ReminderType, obj.ClaimType, obj.LogClaim, obj.ReminderDays, obj.EffectiveFromDate, obj.EffectiveToDate, obj.CreatedBy };
            return dataAccess.LoadDataSet(parameters, "P_ReminderSetup_InsertUpdate", "ReminderSetup_InsertUpdate");
        }

        public DataSet ReminderSetupSelect(ReminderSetup obj)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new object[6] { obj.Class, obj.ReminderType, obj.EffectiveFromDate, obj.EffectiveFromDate2, obj.EffectiveToDate, obj.EffectiveToDate2 };
            return dataAccess.LoadDataSet(parameters, "P_ReminderSetup_Select", "ReminderSetup_Select");
        }
    }
}
