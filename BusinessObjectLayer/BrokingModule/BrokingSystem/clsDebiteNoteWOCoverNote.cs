using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    public class clsDebiteNoteWOCoverNote
    {
        public string DbtNoteType { get; set; }
        public string PageMode { get; set; }
        public string CaseRefNo { get; set; }
        public string DebitNoteNo { get; set; }
        public string DebitNoteType { get; set; }
        //added on 7th Feb//
        public string RiskLocationType { get; set; }
        //

        public string DebitNoteTo { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ClientSubCode { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string EffectiveDate { get; set; }
        public string CoverNoteNo { get; set; }
        public string MainClassCode { get; set; }
        public string MainClassName { get; set; }
        public string SubClassCode { get; set; }
        public string SubClassName { get; set; }
        public string POIFromDate { get; set; }
        public string POIToDate { get; set; }
        public string SumInsuredCurrency { get; set; }
        public decimal SumInsuredAmount { get; set; }
        public string GrossPremCurrency { get; set; }
        public decimal GrossPremiumAmount { get; set; }
        public string AdditionalPremCurrency { get; set; }
        public decimal AdditionalPremiumAmount { get; set; }
        public string TotalPremCurrency { get; set; }
        public decimal TotalPremiumAmount { get; set; }
        public string Primary_AccountHandler { get; set; }
        public string Secondary_AccountHandler { get; set; }
        public string PolicyNo { get; set; }
        public string PreviouPolicyNo { get; set; }
        public string InsurerDebitNote { get; set; }
        public string BillingDate { get; set; }
        public string MultipleBilling { get; set; }
        public string Installment { get; set; }
        public string NoOfInst { get; set; }
        public string CoInsurance { get; set; }
        public string SubBroker { get; set; }
        public string Remarks { get; set; }
        public string UserID { get; set; }
        public string IsLatest { get; set; }
        public string EndtCtr { get; set; }
        public string EndtInsurerNo { get; set; }
        public string EndtEffectivetDate { get; set; }
        public string EndtRemarks { get; set; }
        public string DebitNoteStatus { get; set; }
        public string IsFromHistory { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentStatusDesc { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string UnderwriterName { get; set; }
        public string UnderwriterShortName { get; set; }

        public string spreadFrom { get; set; }
        public string spreadTo { get; set; }
        public string EB { get; set; }
        public bool isLock { get; set; }
        public bool isExportToFlex { get; set; }
        public bool ClientSettlementStatus { get; set; }
        public bool UWSettlementStatus { get; set; }
        public bool AGSettlementStatus { get; set; }
        public long PolicyID { get; set; }
        public int PolicyVerId { get; set; }
        public string PWNoOfDays { get; set; }
        public string PWDate { get; set; }
        public string DueDatePPW { get; set; }
        public int BranchId { get; set; }
        public int CompanyId { get; set; }

        public string ApprovalStatus { get; set; }
        public int UserApprovalId { get; set; }
        public int AppliedBy { get; set; }
        public int AppAuthority1 { get; set; }
        public int AppAuthority2 { get; set; }
        public int AppAuthority3 { get; set; }

        public string Assured { get; set; }
        public int TeamId { get; set; }
        public string Month { get; set; }
        public string debitNoteRiskLocations { get; set; }
        public string KeyAccountmanager { get; set; }
        public string Industrytype { get; set; }
        public string LocationId { get; set; }
        public string LocationDescription { get; set; }
        public int UserLoginId { get; set; }

        //New Fields Added
        public string HistoricalData { get; set; }
        public string InsurerTax { get; set; }
        public string DivisionalGrouping { get; set; }
        public string PreviousPlacement { get; set; }

        public string DebitCreditDueDate { get; set; }
        public string IsBillingleadInsurer { get; set; }
        public string LinkedIntroducer { get; set; }

        public int ServiceFeeType { get; set; }

        public int OtherChargeFeeType { get; set; }

        //added for #23256 
        public string PrintCompLogo { get; set; }

        //added fro RedmineId #23249
        public string RefCaseRefNo { get; set; }
        public string IsRenew { get; set; }

        //Added for #24376
        public string EntityId { get; set; }
        public string EntityType { get; set; }
        //Added for #27895
        public string FeeType { get; set; }
        //added for #23516
        public string BillingDueDate { get; set; }
        public string BillingDueFromDate { get; set; }
        public string BillingDueToDate { get; set; }
        public string InstaDueFromDate { get; set; }
        public string InstaDueToDate { get; set; }
        public int PeriodNo { get; set; }
        public decimal RecogPercentage { get; set; }
        public decimal RecogAmount { get; set; }

        //added fro RedmineId #30527        
        public string IsRenewalType { get; set; }

        public bool DateOverride { get; set; }
        public string FeeBillingDueDate { get; set; }

        public string CalledFrom { get; set; } //Redmine 36722
    }
}
