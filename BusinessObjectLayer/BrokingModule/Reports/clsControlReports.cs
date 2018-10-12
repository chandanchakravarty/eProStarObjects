using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.Reports
{
    public class clsControlReports
    {
        public string UnderwriterCode { get; set; }
        public string CountryCode { get; set; }
        public string AgentCode { get; set; }

        public bool IsSourceCode { get; set; }
        public bool IsBranchCode { get; set; }
        public bool IsClassCode { get; set; }
        public bool IsNRP { get; set; }
        public bool IsBusinessNatureCode { get; set; }

        public string GroupCode { get; set; }
        public string SubGroupCode { get; set; }

        public bool IsClaimHandler { get; set; }
        public bool IsAccountHandler { get; set; }
        public bool IsHealthCare { get; set; }
        public bool IsSurveyor { get; set; }
        public bool IsLossAdjuster { get; set; }
        public bool IsSolicitor { get; set; }
        public bool IsNatureofInjury { get; set; }
        public bool IsCauseofInjury { get; set; }
        public bool IsPartofBodyInjured { get; set; }
        public bool IsLossNature { get; set; }
        public bool IsCauseofLoss { get; set; }

        public string ClientCode { get; set; }
        public int GroupId { get; set; }
        public int SubGroupId { get; set; }
        public int BNCID { get; set; }
        public string Lapsed { get; set; }
        public string SendNote { get; set; }
        public int SourceCodeId { get; set; }
        public string IsCorprate { get; set; }
        public string ISVIP { get; set; }
        public int TeamId { get; set; }
        public string PolClientCode { get; set; }
        public string RecordType { get; set; }



        public string PreviousClientCode { get; set; }
        public string CoRelatedClient { get; set; }
        public string VIPType { get; set; }

        public string Type { get; set; }
        public string BusinessType { get; set; }
        public string CorporateGroup { get; set; }

        public string ClientSource { get; set; }
        public int IndustryType { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public string KeyAccountManager { get; set; }
        public string Intrducer1Code { get; set; }
        public string Intrducer2Code { get; set; }
    }

    public class clsCNRegister
    {
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string Group { get; set; }
        public string SubGroup { get; set; }
        public string BusnessNCode { get; set; }
        public string SourceCode { get; set; }
        public string Status { get; set; }
        public string DebitNoteIssue { get; set; }
        public string DocumentStatus { get; set; }
        public string Class { get; set; }
        public string POIDateFrom { get; set; }
        public string POIDateTo { get; set; }
        public string CoverNoteDateFrom { get; set; }
        public string CoverNoteDateTo { get; set; }
        public string ExpiryPeriodFrom { get; set; }
        public string ExpiryPeriodTo { get; set; }
        public string ClaimLossDateFrom { get; set; }
        public string ClaimLossDateTo { get; set; }
        public string CovernoteNo { get; set; }
        public string PolicyNo { get; set; }
        public string LossNature { get; set; }
        public string CauseOfLoss { get; set; }
        public string MVRegNo { get; set; }
        public string ClassName { get; set; }
        public string CoverNoteFrom { get; set; }
        public string CoverNoteTo { get; set; }
        public string BusinessType { get; set; }
        //Fields for Premium Analysis Report
        public string UNCode { get; set; }
        public string DNDateFrom { get; set; }
        public string DNDateTo { get; set; }
        //Fields for Succession Report
        public string PotentialClientCode { get; set; }
        public string QuotationDateFrom { get; set; }
        public string QuotationDateTo { get; set; }
        public string QuotationNo { get; set; }
    }
}
