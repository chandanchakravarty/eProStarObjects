using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    public class clsReinsurerMaster
    {
        public int RecId { get; set; }
        public int ReinsurerId { get; set; }
        public string ReinsurerCode { get; set; }
        public string ReinsurerName { get; set; }
        public string ChReinsurerName { get; set; }
        public string ReinsurerForModule { get; set; }
        public string CorrAddress1 { get; set; }
        public string CorrAddress2 { get; set; }
        public string CorrAddress3 { get; set; }
        public string ChCorrAddress1 { get; set; }
        public string ChCorrAddress2 { get; set; }
        public string ChCorrAddress3 { get; set; }
        public string InsurerType { get; set; }
       // public int InsurerTypeId { get; set; }
        public string IType { get; set; }
        public string Country { get; set; }
        public string ChCountry { get; set; }
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
        public string FaxNoCode { get; set; }
        public string FaxNo { get; set; }
        public string BusinessRegistrationNo { get; set; }
        public string CompanyEmail { get; set; }
        public string AccountType { get; set; }
        public string NormalBalance { get; set; }
        public string CreditControlAccountNo { get; set; }
        public string ClaimAccountType { get; set; }
        public string ClaimNormalBalance { get; set; }
        public string ClaimDebitControlAccountNo { get; set; }
        public string Remarks { get; set; }
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

        public string ForeignLocal{ get; set; }
    }
    public class ReinsurerContacts
    {
        public int ContactId { get; set; }
        public int ReinsurerId { get; set; }
        public int ReinsurerForModule { get; set; }
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

    }
}

