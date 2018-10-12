using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.Reports
{
    public class clsEBLetter
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
        public string ProviderName { get; set; }
        public string MemberName { get; set; }
        public string AccountHandlerContact { get; set; }

        public string ConsulationDate { get; set; }
        public string ConsulationToDate { get; set; }
        public string ClaimHandlerDescription { get; set; }
        public string SecondaryHandlerDescription { get; set; }

        public string LoginCompanyName { get; set; }
        public string LoginBranchName { get; set; }
        public List<string> lstOptions { get; set; }
        public List<EBInsurerInpatientClaims> lstInpatientClaims { get; set; }
        public string ClientName1 { get; set; }
        public string ShortfallAmount { get; set; }
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
        public string ConsulationDate { get; set; }
        public string ConsulationToDate { get; set; }
        public string ClientName1 { get; set; }
        public string IncurredAmount { get; set; }
    }
}
