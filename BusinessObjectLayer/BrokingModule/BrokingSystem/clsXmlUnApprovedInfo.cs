using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    public class clsXmlUnApprovedInfo
    {
        
        //Added By Neetu
  
        public int ClientProfileId { get; set; }
        public string ClientProfileName { get; set; }
        public int JurisdicationId { get; set; }
        public string JurisdicationName { get; set; }
        public int CorporateGroupId { get; set; }
       // public string CorporateGroupName { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public string Compliance { get; set; }
        public string BusinessDescripation { get; set; }
        public string IntroduceEffectiveDate1 { get; set; }
        public string IntroduceEffectiveDate2 { get; set; }
        public string ClientMasterName { get; set; }
        public string ClientMasterCode { get; set; }
       // public int RiskProfileId { get; set; }
       // public string RiskProfileName { get; set; }
        //Added By Ravi Maurya
        public string ClientShortName { get; set; }
        
        
        

        public string GstRgNumber { get; set; }
        public Int32 ClientSegment { get; set; }
        public Int32 ClientSource { get; set; }
        public Int32 Branch { get; set; }
        public Int32 Region { get; set; }
        public Int32 ClientBanding { get; set; }
        public string ClientIncorporatedDate { get; set; }
        public Int32 CorporateGroup { get; set; }
        public string ICNoNew1 { get; set; }
        public string ICNoNew2 { get; set; }
        public string ICNoNew3 { get; set; }
        public string ICNoOld { get; set; }
        
        
        public string ClientSourceName { get; set; }
        public Int32 ClientSource2 { get; set; }
        public string ClientSource2Name { get; set; }
        
        public Int32 IndustryPIAM { get; set; }
        public string IndustryTypePIAM { get; set; }
        
        
        public string CorporateGroupName { get; set; }

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
        public Int32 TerminationReason { get; set; }
        public string TerminationEffectiveDate { get; set; }
        public string CorelatedClient { get; set; }
        public int State1 { get; set; }
        public int State2 { get; set; }

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
        public int Introducer1Id { get; set; }
        public int Introducer2Id { get; set; }
        public int ClientSource1Id { get; set; }
        public int ClientSource2Id { get; set; }
        public int AccountManagerId { get; set; }

        
        public int CompanyRelatedId { get; set; }
        public int IndustryTypeId { get; set; }
        public int RiskProfileId { get; set; }
        public string HomePhoneno { get; set; }
        public string Introducer1Name { get; set; }
        public string Introducer1Code { get; set; }
        public string Introducer2Name { get; set; }
        public string Introducer2Code { get; set; }
        public string ClientSource1Name { get; set; }
       // public string ClientSource2Name { get; set; }
        public string AccountManagerName { get; set; }
        public string CompanyRelatedName { get; set; }
        public string IndustryTypeName { get; set; }
        public string RiskProfileName { get; set; }
        public string PreviousCode { get; set; }
        public string ClientName { get; set; }
        public string ChClientName { get; set; }
        public string CorrAddress1 { get; set; }
        public string CorrAddress2 { get; set; }
        public string CorrAddress3 { get; set; }
        public string CorrAddress4 { get; set; }
        public string ChCorrAddress1 { get; set; }
        public string ChCorrAddress2 { get; set; }
        public string ChCorrAddress3 { get; set; }
        public string ChCorrAddress4 { get; set; }
        public string Country { get; set; }
        public string ChCountry { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingAddress3 { get; set; }
        public string BillingAddress4 { get; set; }
        public string ChBillingAddress1 { get; set; }
        public string ChBillingAddress2 { get; set; }
        public string ChBillingAddress3 { get; set; }
        public string ChBillingAddress4 { get; set; }
        public string BillingCountry { get; set; }
        public Int32 BillingState { get; set; }
        public string ChBillingCountry { get; set; }
        public string Description { get; set; }
        public string GeneralLineCode { get; set; }
        public string GeneralLineNo { get; set; }
        public string RecordType { get; set; }
        public string RecordTypeCategory { get; set; }
        public string Category_V { get; set; }
        //public string Category_L { get; set; }
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
        public string AdminApprovedBy { get; set; }
        public string AdminApprovedDate { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        //public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }

        public string SubDistrict { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }

        public string ChSubDistrict { get; set; }
        public string ChCity { get; set; }
        public string ChProvince { get; set; }
        public string ChPostalCode { get; set; }

        public string BillingSubDistrict { get; set; }
        public string BillingCity { get; set; }
        public string BillingProvince { get; set; }
        public string BillingPostalCode { get; set; }

        public string ChBillingSubDistrict { get; set; }
        public string ChBillingCity { get; set; }
        public string ChBillingProvince { get; set; }
        public string ChBillingPostalCode { get; set; }

        public string MasterSubsidiary { get; set; }
        public string BusinessType { get; set; }
        public string MasterClientCode { get; set; }
        public string MasterClientName { get; set; }
        public int MasterClientId { get; set; }
        public string VIPType { get; set; }

        public string DepartmentID { get; set; }
        public string EmailGroupID { get; set; }
        public string EmailGroup { get; set; }
        public string OwnEmail { get; set; }
        public string OwnDepartment { get; set; }
        //Itrack 477 By Rituraj on 20/04/2016
        public string CoRelatedName { get; set; }
        public string CorelatedCode { get; set; }
        public string CoRelatedID { get; set; }
        public string CoRelatedCode { get; set; }
        public string MobileNo { get; set; }
        public string MobileNoCode { get; set; }
        public string HomePhoneNo { get; set; }
        public string HomePhoneNoCode { get; set; }

        public int profitcentre { get; set; }
        public string fundcode { get; set; }
    }
}
