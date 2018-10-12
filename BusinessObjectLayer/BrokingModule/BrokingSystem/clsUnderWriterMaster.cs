using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    public class clsUnderWriterMaster
    {
        public string SearchContactType { get; set; }
        public int RecForId { get; set; }
        public string RecForType { get; set; }
        public int RecId { get; set; }
        public int UnderWriterId { get; set; }
        public string UnderwriterCode { get; set; }
        public string UnderwriterName { get; set; }
       // public string PreviousCode { get; set; }
        public string GstNumber { get; set; }
        public string UnderwriterShortName { get; set; }
        public string ChUnderwriterName { get; set; }
        public string UnderwriterForModule { get; set; }
        public string CorrAddress1 { get; set; }
        public string CorrAddress2 { get; set; }
        public string CorrAddress3 { get; set; }
        public string CorrAddress4 { get; set; }
        public string ChCorrAddress1 { get; set; }
        public string ChCorrAddress2 { get; set; }
        public string ChCorrAddress3 { get; set; }
        public string ChCorrAddress4 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }

        public string ChCity { get; set; }
        public string ChProvince { get; set; }
        public string ChPostalCode { get; set; }

        public string SubDistrict { get; set; }
        public string ChSubDistrict { get; set; }
        public string BillingSubDistrict { get; set; }
        public string ChBillingSubDistrict { get; set; }
        public int BranchId { get; set; }
        public int RegionId { get; set; }
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
        public string BillingCity { get; set; }
        public string BillingProvince { get; set; }
        public string BillingPostalCode { get; set; }

        public string ChBillingCity { get; set; }
        public string ChBillingProvince { get; set; }
        public string ChBillingPostalCode { get; set; }
        public int CorporateGroupId { get; set; }
        public int  InsurerTypeId { get; set; }
        public string IType { get; set; }
        public int ITypeId { get; set; }
        public string BillingCountry { get; set; }
        public string ChBillingCountry { get; set; }
        public string Description { get; set; }
        public string GeneralLineCode { get; set; }
        public string GeneralLineNo { get; set; }
        public string RecordType { get; set; }
        public string FaxNoCode { get; set; }
        public string FaxNo { get; set; }
        public string CompanyRegistrationNo { get; set; }
        public string BusinessRegistrationNo { get; set; }
        public string RegistrationDate { get; set; }
        public string CompanyEmail { get; set; }
        public string AccountType { get; set; }
        public string NormalBalance { get; set; }
        public string CreditControlAccountNo { get; set; }
        public string Remarks { get; set; }
        public string UnderWriterRemarks { get; set; }
        //public string Salutation { get; set; }
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
        //public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public string Premium_Settlement { get; set; }
        public string GlCode { get; set; }
        public string BankCode { get; set; }

        public string CorporateGroup { get; set; }
        public string InsurerType { get; set; }
        public string BNDisplay { get; set; }
        public string GSTRegistrationNumber { get; set; }
        public string Branch { get; set; }
        public string Region { get; set; }
        public bool CAB { get; set; }
        public string GSTTaxType { get; set; }
        public string GSTCodeDescription { get; set; }
        public string SuspensionFromDate { get; set; }
        public string SuspensionToDate { get; set; }
        public string SuspensionReason { get; set; }
        public string TerminationReason { get; set; }
        public string TerminationEffectiveDate { get; set; }
        public string State { get; set; }
        public string PreviousCode { get; set; }

        public int ProfitCentre { get; set; }
        public string FundCode { get; set; }

        //17838 - Howden
        public string SecurityGrading { get; set; }
        public string GSTApplicable { get; set; }
        public string VATApplicable { get; set; }
        public string WHTApplicable { get; set; }
        public string Offshore { get; set; }
        public string SecurityType { get; set; }

    }
    public class UnderwriterContacts
    {
        public int ContactId { get; set; }
        public int UnderwriterId { get; set; }
        public string UnderwriterForModule { get; set; }
        public bool IsContactSOA { get; set; }
        public string IsPriorityContact { get; set; }
        public string LastName { get; set; }
        public string ChLastName { get; set; }
        public string FirstName { get; set; }
        public string ChFirstName { get; set; }
        public string JobTitle { get; set; }
        public string ChJobTitle { get; set; }
        public string Department { get; set; }
        public string ContacttypeText { get; set; }
        //public string DesignationText { get; set; }
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
        public string CountryName { get; set; }
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
        public string DesignationText { get; set; }
        public string Contacttype { get; set; }
        public string ContactTypeName { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Remarks { get; set; }
        public string ChCity { get; set; }
        public string ChProvince { get; set; }
        public string ChPostalCode { get; set; }

        public string SubDistrict { get; set; }
        public string ChSubDistrict { get; set; }
        public bool MainContact { get; set; }
        public string Designation { get; set; }
        public string ContactType { get; set; }
        public string Remark { get; set; }
        public bool IsMainContact { get; set; }
        public string BusinessPartnerType { get; set; }
      
        public bool SameCorrAddress { get; set; }
        public bool SameChCorrAddress { get; set; }
    }


    public class UnderwriterBankDetails
    {
        public int BankId { get; set; }
        public int UnderwriterId { get; set; }
        public string UnderwriterForModule { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string AccountNumber { get; set; }
        public string CurrencyType { get; set; }
        public string AccountType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }

}

