using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.Reports
{
    public class clsLetter
    {
        public string CaseRefNo { get; set; }
        public string UWCode { get; set; }
        public string UWName { get; set; }
        public string UWContactName { get; set; }
        public string UWAddress { get; set; }
        public string UWContactInfo { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string AccountHandlerName { get; set; }

        public string UWCorrAddress1 { get; set; }
        public string UWCorrAddress2 { get; set; }
        public string UWCorrAddress3 { get; set; }

        public string ContactCountry { get; set; }
        public string ClientFirstName { get; set; }
        public string PolicyNo { get; set; }
        public string ClaimNo { get; set; }
        public string DoctorName { get; set; }
        public string MemberName { get; set; }
        public string AccountHandlerContact { get; set; }
        public List<string> lstOptions { get; set; }
        public List<EBInsurerInpatientClaims> lstInpatientClaims { get; set; }

        public string Reinsurer { get; set; }
        public string RefNo { get; set; }
        public string NWIClaimRef { get; set; }
        public string InvoiceNo { get; set; }
        public string DateOfLoss { get; set; }
        public string InsuredParties { get; set; }
        public string Share { get; set; }
        public string Currency { get; set; }
        public string Reserve { get; set; }

        public string ReinsurerCode { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingAddress3 { get; set; }
        public string TerritoryName { get; set; }

        public string YourClaimNo { get; set; }
        public string OurClaimNo { get; set; }
        public string OurPlacement { get; set; }
        public string ClaimAmount { get; set; }
        public string CedantClaimNo { get; set; }
        public string ClaimInvoiceNo { get; set; }
        public string CoverNoteNo { get; set; }
        public string CedantPolicyNo { get; set; }
        public string Cedant { get; set; }
        public string CedantCode { get; set; }
        public string Insured { get; set; }
        public string Project { get; set; }
        public string NatureOfLoss { get; set; }
        public string TotalReserve { get; set; }
        public string OutStandingReserve { get; set; }
        public string TotalPaidAmount { get; set; }
        public string OutStandingPaidAmount { get; set; }
        public string Remarks { get; set; }
        public string CedantRefNo { get; set; }
        public string Caption { get; set; }
        public string Type { get; set; }
        public string PeriodFrom { get; set; }
        public string PeriodTo { get; set; }
        public string SumInsuredWithLoading { get; set; }
        public string GrossPremium { get; set; }
        public string LessTotalDeduction { get; set; }
        public string GrossNetPremium { get; set; }
        public string DueDate { get; set; }
        public string InstNo { get; set; }
        public string PremiumDueFromCedant { get; set; }
        public string CaptionMsg { get; set; }
        public string CrNo { get; set; }
    }   

    public class EBInsurerInpatientClaims
    {
        public string UWCode { get; set; }
        public string ClaimNo { get; set; }
        public string ClientName { get; set; }
        public string PolicyNo { get; set; }
        public string MemberName { get; set; }
        public string CertificateNo { get; set; }
        public string IncurredDate { get; set; }
        public string IncurredAmt { get; set; }
    }

}
