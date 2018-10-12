using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.Reports
{
   public  class clsEvenOutReport
    {
       public string CompanyId { get; set; }
       public string BranchId { get; set; }
       public string SpreadFromDate { get; set; }
       public string SpreadToDate { get; set; }
       public string DebitNoteNo { get; set; }
       public string DebitNoteNoTo { get; set; }
       public string DebitNoteDate { get; set; }
       public string DebitNoteDateTo { get; set; }
       public string BillingCurrency { get; set; }
       public string Group { get; set; }
       public string SubGroup { get; set; }
       public string BNC { get; set; }
       public string SourceCode { get; set; }
       public string ClientCode { get; set; }
       public string ClientName { get; set; }
    }

   public class clsALLECNESummaryReport
   {
       public string ClaimType { get; set; }
       public int IssueYearFrom { get; set; }
       public int IssueYearTo { get; set; }    
       public string Filestatus { get; set; }
   }

   public class clsALLECNEReport
   {
       public string CompanyId { get; set; }
       public string BranchId { get; set; }
       public string Clientname { get; set; }
       public string CovernoteNo { get; set; }
       public string ClaimType { get; set; }
       public string DateofAccidentFrom { get; set; }
       public string DateofAccidentTo { get; set; }
       public string UnderwriterName { get; set; }
       public string Filestatus { get; set; }
       public string Status { get; set; }
       public string Group { get; set; }
       public string SubGroup { get; set; }
       public string BusnessNCode { get; set; }
       public string SourceCode { get; set; }
       public string Class { get; set; }
       public string POIDateFrom { get; set; }
       public string POIDateTo { get; set; }
       public string ClaimIssueDateFrom { get; set; }
       public string ClaimIssueDateTo { get; set; }
       public string ExpiryPeriodFrom { get; set; }
       public string ExpiryPeriodTo { get; set; }
       public string PolicyNo { get; set; }
       public string InjuryDeath { get; set; }
       public string CauseofInjury { get; set; }
       public string Injurypart { get; set; }
       public string LossNature { get; set; }
       public string CauseOfLoss { get; set; }
       public string MVRegNo { get; set; }
       public string Thirdparty { get; set; }
   }

   public class clsNEReport
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
       public string DocumentStatus { get; set; }
       public string Class { get; set; }
       public string POIDateFrom { get; set; }
       public string POIDateTo { get; set; }
       public string ClaimIssueDateFrom { get; set; }
       public string ClaimIssueDateTo { get; set; }
       public string ExpiryPeriodFrom { get; set; }
       public string ExpiryPeriodTo { get; set; }
       public string ClaimLossDateFrom{ get; set; }
       public string ClaimLossDateTo { get; set; }
       public string CovernoteNo { get; set; }
       public string PolicyNo { get; set; }
       public string LossNature { get; set; }
       public string CauseOfLoss { get; set; }
       public string MVRegNo { get; set; }
       public string Thirdparty { get; set; }
   }

   public class clsBusinessReport
   {
       public string CompanyId { get; set; }
       public string BranchId { get; set; }
       public string ClientCode { get; set; }
       public string ClientName { get; set; }
       public string UnderwriterCode { get; set; }
       public string UnderwriterName { get; set; }
       public string AgentCode { get; set; }
       public string AgentName { get; set; }
       public string Group { get; set; }
       public string SubGroup { get; set; }
       public string BNC { get; set; }
       public string SourceCode { get; set; }
       public string MainClass { get; set; }
       public string POIFromDate { get; set; }
       public string POIToDate { get; set; }
       public string DNFromDate { get; set; }
       public string DNToDate { get; set; }
       public string UnderwriterShortName { get; set; }
       public int UserId { get; set; }
   }

   public class clsEnquiryReport
   {
       public string DNFromDate { get; set; }
       public string DNToDate { get; set; }
       public string POIFromDate { get; set; }
       public string POIToDate { get; set; }
       public string ClientName { get; set; }
       public string ClientCode { get; set; }
       public string AccountHandler { get; set; }
       public string MainClass { get; set; }
       public string SubClass { get; set; }
       public string UnderwriterName { get; set; }
       public string GlobalProgram { get; set; }
       public string BusinessType { get; set; }
       public string RenewalType { get; set; }
       public string RenewalStatus { get; set; }
       public string ClaimStatus { get; set; }
       public string Team { get; set; }
       public string AgentName { get; set; }
       //Extra fields of Production Report
       public string PlacementClosingNo { get; set; }
       //Extra fields of Premium Summary Report
       public string AgentId { get; set; }
       //Extra fields of Premium Status Report
       public string PolicyNo { get; set; }
       public string VehicleNo { get; set; }
       public string PremiumStatus { get; set; }
       public string DNCNNo { get; set; }
       //Extra fields of Master Client Report
       public string ReportType { get; set; }
       //Extra fields of Master Client Report
       public string QuotationNo { get; set; }
       public string EndorsementNo { get; set; }
       public string KeyAccountmanager { get; set; }
       public string Industrytype { get; set; }
       public string LogInNameTo { get; set; }
       public string LossFromDate { get; set; }
       public string LossToDate { get; set; }

       public string NotificationFromDate { get; set; }
       public string NotificationToDate { get; set; }
       public string MasterClientName { get; set; }
       public string MasterClientCode { get; set; }
       public string DivisionalGrouping { get; set; }
       public string ProfitCentre { get; set; }
       public string Branch { get; set; }
       //New Feilds for SIME
       public string ProfitCenter { get; set; }
       public string AccountingMonthFrom { get; set; }
       public string AccountingMonthTo { get; set; }
       public string ReportBy { get; set; }
       public string ProjectTitle { get; set; }

       public string BillingParty { get; set; }
       public string ClientSourceCode { get; set; }
       public string MasterClient { get; set; }

       public string CorporateGroup { get; set; }
       public int UserId { get; set; }
       public int TeamID { get; set; } //Redmine #33818
       public string CustomizedClient { get; set; } //Redmine #33818


   }
}

