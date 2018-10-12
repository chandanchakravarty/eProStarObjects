using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    public class clsClientMaster
    {
        public int introducer1Id { get; set; }
        public int introducer2Id { get; set; }
        public int ClientSource1 { get; set; }
        public int ClientSource2 { get; set; }
        public int CompanyTypeId { get; set; }
        public int RiskProfileId { get; set; }
        public int KeyManagerId { get; set; }
        public int IndustryTypeId { get; set; }

        public int RecId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ChClientName { get; set; }
        public string ClientForModule { get; set; }
        public string CorrAddress1 { get; set; }
        public string CorrAddress2 { get; set; }
        public string CorrAddress3 { get; set; }
        public string ChCorrAddress1 { get; set; }
        public string ChCorrAddress2 { get; set; }
        public string ChCorrAddress3 { get; set; }
        public string Country { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingAddress3 { get; set; }
        public string ChBillingAddress1 { get; set; }
        public string ChBillingAddress2 { get; set; }
        public string ChBillingAddress3 { get; set; }
        public string BillingCountry { get; set; }
        public string ChBillingCountry { get; set; }
        public string Description { get; set; }
        public string GeneralLineCode { get; set; }
        public string GeneralLineNo { get; set; }
        public string RecordType { get; set; }
        //public bool RecordTypeCategory { get; set; }
        public bool Category_V { get; set; }
        //public bool Category_L { get; set; }
        public string ClientStatus { get; set; }
        public string FaxNoCode { get; set; }
        public string FaxNo { get; set; }
        public string CompanyRegistrationNo { get; set; }
        public string BusinessRegistrationNo { get; set; }
        public string CompanyEmail { get; set; }
        public int SourceOfBusiness { get; set; }
        public int MasterSourceCode { get; set; }
        public int BusinessNatureCode { get; set; }
        public int SubsidiarySourceCode1 { get; set; }
        public int SubsidiarySourceCode2 { get; set; }
        public int SourceCode { get; set; }
        public string AccountType { get; set; }
        public string NormalBalance { get; set; }
        public string DebtorControlAccountNo { get; set; }
        public int GroupName { get; set; }
        public int GroupNameForAnalysis { get; set; }
        public int SubGroup { get; set; }
        public int SubGroupForAnalysis { get; set; }
        public string Remarks { get; set; }
        public string ClientCode { get; set; }
        public string ClientType { get; set; }
        //public string Salutation { get; set; }
        public string Nationality { get; set; }
        public string MaritalSatus { get; set; }
        //public string DOB { get; set; }
        public string DayOfBirth { get; set; }
        public string MonthOfBirth { get; set; }
        public string YearOfBirth { get; set; }
        public string PassportNumber { get; set; }
        public string Occupation { get; set; }
        public string SendNotification { get; set; }
        public string Gender { get; set; }
        public bool SameCorrAddress { get; set; }
        public bool SameChCorrAddress { get; set; }
        public string Level1ApprovedBy { get; set; }
        public string Level1ApprovedDate { get; set; }
        public string Level2ApprovedBy { get; set; }
        public string Level2ApprovedDate { get; set; }
        public string Level3ApprovedBy { get; set; }
        public string Level3ApprovedDate { get; set; }
        public string AdminApprovedBy { get; set; }
        public string AdminApprovedDate { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        //public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }

        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string ChCity { get; set; }
        public string ChProvince { get; set; }
        public string ChPostalCode { get; set; }
        public string BillingCity { get; set; }
        public string BillingProvince { get; set; }
        public string BillingPostalCode { get; set; }

        public string ChBillingCity { get; set; }
        public string ChBillingProvince { get; set; }
        public string ChBillingPostalCode { get; set; }

        public string VIPType { get; set; }
        public string SubDistrict { get; set; }
        public string ChSubDistrict { get; set; }
        public string BillingSubDistrict { get; set; }
        public string ChBillingSubDistrict { get; set; }
        //Added By Ravi

        public string ClientShortName { get; set; }
        public string CorrAddress4 { get; set; }
        public string ChCorrAddress4 { get; set; }
        public string BillingAddress4 { get; set; }
        public string ChBillingAddress4 { get; set; }


        public string GstRgNumber { get; set; }
        public Int32 Branch { get; set; }
        public Int32 Region { get; set; }
        public string ClientIncorporatedDate { get; set; }


        public string ICNoNew1 { get; set; }
        public string ICNoNew2 { get; set; }
        public string ICNoNew3 { get; set; }
        public string ICNoOld { get; set; }
        public string CorelatedClient { get; set; }
        public string CoRelatedCode { get; set; }
        public Int32 ClientSource { get; set; }
        public Int32 ClientSegment { get; set; }
        public Int32 IndustryPIAM { get; set; }
        public Int32 ClientBanding { get; set; }
        public Int32 CorporateGroup { get; set; }

        public Int32 ServicingTeam { get; set; }
        public Int32 ServicingUserName { get; set; }
        public string ServicingEffectiveDate { get; set; }

        public Int32 MarketingTeam { get; set; }
        public Int32 MarketingUserName { get; set; }
        public string MarketingEffectiveFromdate { get; set; }

        public string IntroducerName { get; set; }
        public string IntroducerCode { get; set; }
        public string IntroducerEffectiveDate { get; set; }

        public string SuspensionFromDate { get; set; }
        public string SuspensionToDate { get; set; }
        public Int32 SuspensionReason { get; set; }
        public string TerminationEffectiveDate { get; set; }
        public Int32 TerminationReason { get; set; }

        public Int32 AMLACustomerType { get; set; }
        public string AMLACompanyRegNo { get; set; }
        public string AMLAICNoOld { get; set; }
        public string AMLAICNoNew1 { get; set; }
        public string AMLAICNoNew2 { get; set; }
        public string AMLAICNoNew3 { get; set; }
        public string AMLAPassportNo { get; set; }
        public string AMLAIsIncident { get; set; }
        public string AMLADateCheck { get; set; }
        public string AMLAAuditedBy { get; set; }

        //End By Ravi
        public string PreviousCode { get; set; }

        public int ProfitCentre { get; set; }
        public string FundCode { get; set; }
        public string MasterClientCode { get; set; }
    }
    public class ClientContacts
    {
        public int ContactId { get; set; }
        public int ClientId { get; set; }
        public string ClientForModule { get; set; }
        public string IsPriorityContact { get; set; }
        public string LastName { get; set; }
        public string ChLastName { get; set; }
        public string FirstName { get; set; }
        public string ChFirstName { get; set; }
        public string JobTitle { get; set; }
        public string ChJobTitle { get; set; }
        public string Department { get; set; }
        public string ChDepartment { get; set; }
        public string ContactCorrAddress1 { get; set; }
        public string ContactCorrAddress2 { get; set; }
        public string ContactCorrAddress3 { get; set; }
        public string ChContactCorrAddress1 { get; set; }
        public string ChContactCorrAddress2 { get; set; }
        public string ChContactCorrAddress3 { get; set; }
        public string ContactCountry { get; set; }
        public string ChContactCountry { get; set; }
        public string Team { get; set; }
        //public string Dob { get; set; }
        public string DayOfBirth { get; set; }
        public string MonthOfBirth { get; set; }
        public string YearOfBirth { get; set; }
        public string GeneralLineCode { get; set; }
        public string GeneralLineNo { get; set; }
        public string Extension { get; set; }
        public string DirectLineCode { get; set; }
        public string DirectLineNo { get; set; }
        public string Salutation { get; set; }
        public string ChSalutation { get; set; }
        public string MobileNoCode { get; set; }
        public string MobileNo { get; set; }
        public string FaxNoCode { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffectiveFromDate1 { get; set; }
        public string EffectiveTodate { get; set; }
        public string EffectiveTodate1 { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }

        public string SubDistrict { get; set; }
        public string ChSubDistrict { get; set; }

        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string ChCity { get; set; }
        public string ChProvince { get; set; }
        public string ChPostalCode { get; set; }
        public string Remarks { get; set; }
        public bool IsContactSOA { get; set; }      // added for #23157
        #region Added By neetu

        public string BusinessPartnerType { get; set; }
        public bool IsMainContact { get; set; }
        public string Designation { get; set; }
        public string DesignationText { get; set; }
        public string ChDesignation { get; set; }

        public string Contacttype { get; set; }
        public string ContacttypeText { get; set; }
        public Int32 ChContacttype { get; set; }
        public string State { get; set; }
        public string ChState { get; set; }
        public string ContactCorrAddress4 { get; set; }
        public string ChContactCorrAddress4 { get; set; }


        public bool SameCorrAddress { get; set; }
        public bool SameChCorrAddress { get; set; }
        #endregion


    }

    public class DDLReturn
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
    }

    public class WICACheckListDocuments
    {
        public string CaseRefNo { get; set; }
        public string ClaimRefNo { get; set; }
        public string MasterDesc { get; set; }
        public string MasterCode { get; set; }
        public bool DocRequired { get; set; }
        public string DocReceivedDate { get; set; }
        public string CreatedBy { get; set; }
    }

}
