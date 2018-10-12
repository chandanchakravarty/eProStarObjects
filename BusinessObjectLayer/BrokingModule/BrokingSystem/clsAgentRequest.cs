using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    public class clsAgentRequest
    {
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankAccount { get; set; }
        public decimal OwnPercentage { get; set; }
        public decimal IntroducerPercentage { get; set; }
        public int DocumentCompilanceId { get; set; }
        public string DocumentCompilanceName { get; set; }

        public int RecId { get; set; }
        public int AgentId { get; set; }
        public string Typecode { get; set; }
        public string AgentName { get; set; }
        public string AgentShortName { get; set; }
        public string ChAgentName { get; set; }
        public string AgentForModule { get; set; }
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
        public string ChBillingCountry { get; set; }
        public string Description { get; set; }
        public string GeneralLineCode { get; set; }
        public string GeneralLineNo { get; set; }
        public string RecordType { get; set; }
        public string RecordTypeCategory { get; set; }
        public string FaxNoCode { get; set; }
        public string FaxNo { get; set; }

        public string PreviousCode { get; set; }
        public string Nationality { get; set; }
        public string PassportNo { get; set; }
        public string ICNoNew { get; set; }
        public string ICNoOld { get; set; }
        public string Gender { get; set; }
        public decimal CreditLimit { get; set; }
        public string CreditTerms { get; set; }
        public string CreditTermsOption { get; set; }
        public int CreditTermsOptionValue { get; set; }

        public bool Jan { get; set; }
        public bool Feb { get; set; }
        public bool Mar { get; set; }
        public bool Apr { get; set; }
        public bool May { get; set; }
        public bool Jun { get; set; }
        public bool Jul { get; set; }
        public bool Aug { get; set; }
        public bool Sep { get; set; }
        public bool Oct { get; set; }
        public bool Nov { get; set; }
        public bool Dec { get; set; }


        public string PaymentEffectiveFrom { get; set; }
        public string PaymentEffectiveTo { get; set; }
       
        public string CompanyRegNo { get; set; }
        public string CompanyRegDate { get; set; }
        public string BusinessRegistrationNo { get; set; }
        public string IntroducerShortN { get; set; }

        public string Branch { get; set; }
        public string Region { get; set; }
        public string CorporateGroup { get; set; }

        public string GSTTAXTYPE { get; set; }
        public string GSTCodeRate { get; set; }

        public string  DateofReg { get; set; }
        public string GSTRegistrationNo { get; set; }
        public string GSTEffectiveDate { get; set; }

        public string IsSelfBilling { get; set; }
        public string CustomApprovalNo { get; set; }

        public string SuspensionFromDate { get; set; }
        public string SuspensionToDate	 { get; set; }
        public string SuspensionReason { get; set; }
        public string TerminationEffectiveDate { get; set; }
        public string TerminationReason { get; set; }
        public string GeneralLineCodeC { get; set; }
        public string GeneralLineNoC { get; set; }

        public bool IsNOTaDirectorOfThePrincipal {get;set;}
        public bool IsNOTAnEmployeeOfThePrincipal { get; set; }
        public bool IsNOTRelatedToAnyPrincipalOfficersOfThePrincipal { get; set; }
        public bool IsNOTAnEmployeeOfBIB { get; set; }
        public bool IsNOTRelatedToAnyEmployeeOfBIB { get; set; }
        public bool BrokerageSharingForAllClasses { get; set; }
        public bool CopyOfICOrForm9OrForm13IsReceived { get; set; }
       
        public string FaxNoCodeC { get; set; }
        public string FaxNoC { get; set; }
        public string CompanyEmail { get; set; }
        
        public string AccountType { get; set; }
        public string NormalBalance { get; set; }
        public string CreditControlAccountNo { get; set; }
        
        public string Remarks { get; set; }
        public string AgentCode { get; set; }
     
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
        public string EffToDate { get; set; }
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

        public string SubDistrict { get; set; }
        public string ChSubDistrict { get; set; }
        public string BillingSubDistrict { get; set; }
        public string ChBillingSubDistrict { get; set; }

        public int ProfitCentre { get; set; }
        public string FundCode { get; set; }
    }

    public class AgentContacts
    {
        public int ContactId { get; set; }
        public int AgentId { get; set; }
        public string AgentForModule { get; set; }
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
        public string ContactCorrAddress4 { get; set; }        
        public string ChContactCorrAddress1 { get; set; }
        public string ChContactCorrAddress2 { get; set; }
        public string ChContactCorrAddress3 { get; set; }
        public string ChContactCorrAddress4 { get; set; }        
        public string ContactCountry { get; set; }
        public string ChContactCountry { get; set; }
        public string Team { get; set; }
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
        public string EffectiveTodate { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }

        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string ChCity { get; set; }
        public string ChProvince { get; set; }
        public string ChPostalCode { get; set; }
        public string SubDistrict { get; set; }
        public string ChSubDistrict { get; set; }
        public bool IsMainContact { get; set; }
        public string Designation { get; set; }
        public string ContactType { get; set; }
        public string DesignationText { get; set; }
        public string Remarks { get; set; }
        public string IsContactSOA { get; set; }

        /**/
        public bool SameChCorrAddress { get; set; }
        public bool SameCorrAddress { get; set; }
        /**/
        
    }

    public class AgentAgreements
    {
        public int AgreementId { get; set; }
        public int AgentId { get; set; }
        public string Share { get; set; }
        public string AgreementNo { get; set; }
        public string EffectiveDate { get; set; }
        public string ExpiryDate { get; set; }
        public string DateAgreementStamped { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }

        
    }
}
