using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Claims
{
    public class clsECClaim
    {

        public string KeyAccountmanager { get; set; }
        public string Industrytype { get; set; }
        public string PageMode { get; set; }
        public string CaseRefNo { get; set; }
        public string ClaimRefNo { get; set; }
        public string ClaimNo { get; set; }
        public string IssueDate { get; set; }
        public string IsVoid { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string UWClaimNo { get; set; }
        public string MainClassCode { get; set; }
        public string MainClassName { get; set; }
        public string SubClassCode { get; set; }
        public string SubClassName { get; set; }
        public string PolicyNo { get; set; }
        public string CoverNoteNo { get; set; }
        public string POIFromDate { get; set; }
        public string POIToDate { get; set; }
        public string Location { get; set; }
        public string NotifyBy { get; set; }
        public string NotifyDate { get; set; }
        public string Team { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DirectLine1 { get; set; }
        public string DirectLine2 { get; set; }
        public string MobileNo1 { get; set; }
        public string MobileNo2 { get; set; }
        public string FaxNo1 { get; set; }
        public string FaxNo2 { get; set; }
        public string Email { get; set; }
        public string ClaimsHandlerCode { get; set; }
        public string ClaimsHandlerName { get; set; }
        public string SurveyorCode { get; set; }
        public string SurveyorName { get; set; }
        public string SurveyorName2 { get; set; }
        public string AccountHandlerCode { get; set; }
        public string AccountHandlerName { get; set; }
        public string LossAdjusterCode { get; set; }
        public string LossAdjusterName { get; set; }
        public string LossAdjusterName2 { get; set; }
        public string HealthCareCode { get; set; }
        public string HealthCareName { get; set; }
        public string SolicitorCode { get; set; }
        public string SolicitorName { get; set; }
        public string SolicitorName2 { get; set; }
        public string InvestigatorCode { get; set; }
        public string InvestigatorName { get; set; }
        public string UserID { get; set; }
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public string FileStatus { get; set; }
        public string NotifyByName { get; set; }
        //For Enquiry
        public string IssueFromDate { get; set; }
        public string IssueToDate { get; set; }
        public string ClaimStatus { get; set; }
        public string InjuredName { get; set; }
        public string AccidentDate { get; set; }
        public string MotorRegNo { get; set; }
        public string ThirdPartyDetails { get; set; }
        public string ReportDate { get; set; }
        public string LossNature { get; set; }
        public string CauseOfLoss { get; set; }
        public string ChequeRefNo { get; set; }
        //added by kavita--7th july--//
        public string Disability_Grade { get; set; }
        //--------------//
        //added by Sachin--9th july--//
        public string UnderwriterCode { get; set; }
        public string UnderwriterName { get; set; }
        //--------------//
        //added by Kumar Rituraj--11th May 2015--//
        public string ReceiptInvoiceNo { get; set; }

        //--------------//

        //added on 19th October for Recovery Claim//
        public string VesselId { get; set; }
        public string VesselName { get; set; }

        public string DateofIncident { get; set; }
        public double RecoveryAmount { get; set; }
        public string RelatedClaimNo { get; set; }
        public string Remark { get; set; }
        public string RecoveryNo { get; set; }

        //--------added on 16th nov----
        public string CedantCode { get; set; }
        public string CedantName { get; set; }
        public string CedantClaimNo { get; set; }
        public string CedantPolicyNo { get; set; }

        //for Claim Billing

        public string Currency { get; set; }
        public double Amount { get; set; }
        public string Casualty { get; set; }

        //For claim summary
        public string IsDataFromHist { get; set; }
        public string pintBrokerId { get; set; }
        public string ConColumName { get; set; }
        public string ConColumValues { get; set; }
        public string sortBy { get; set; }
        public string sortType { get; set; }
        public string ReportType { get; set; }
        public string ReportColumns { get; set; }
        public string DateofLoss { get; set; }
        public string NotifyFromDate { get; set; }
        public string NotifyToDate { get; set; }
        public string VehicleNo { get; set; }
        public string CusM_ID { get; set; }
        public string InsurerID { get; set; }
        public string ClaimDiary { get; set; }

        //For WICA General Information Tab on 27-03-2017
        public string ClientClaimNo { get; set; }
        public string NotificationNo { get; set; }
        public string SubmissionDate { get; set; }
        public string Department { get; set; }
        public string SubsidiaryClientCode { get; set; }

        public string ClaimantName { get; set; }
        public string NatureofInjury { get; set; }
        public string ClaimInfoStatus { get; set; }
        public string NatureofLoss { get; set; }

        public string CalledFor { get; set; }

    }

    public class WICAClaimCalculations
    {
        public int CalculationId { get; set; }
        public string ClaimRefNo { get; set; }
        public int ClaimId { get; set; }
        public string ClaimantName { get; set; }
        public string DateReceivedFromClient { get; set; }
        public string WorkingDays { get; set; }
        public string DateSentToInsurer { get; set; }
        public decimal Denominator { get; set; }
        public string Currency { get; set; }
        public decimal MonthlyWages { get; set; }
        public decimal DailyWage { get; set; }
        public decimal PW { get; set; }
        public bool ManualOverwrite { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public List<ClaimMCRecords> RecordsList { get; set; }
        public List<ClaimMedicalExpense> ExpenseList { get; set; }
        public List<ClaimPaymentIncapability> IncapabilityList { get; set; }
    }

    public class ClaimMCRecords
    {
        public int MCRecordId { get; set; }
        public string ClaimRefNo { get; set; }
        public int ClaimId { get; set; }
        public string ReceiptNo { get; set; }
        public string MCFrom { get; set; }
        public string MCTo { get; set; }
        public string MCType { get; set; }
        public decimal EntitledDays { get; set; }
        public decimal FWDays { get; set; }
        public decimal PWDays { get; set; }
        public decimal PayableDays { get; set; }
        public decimal FullWage { get; set; }
        public decimal PartialWage { get; set; }
        public decimal TotalWagePayable { get; set; }
        public string ChequeNo { get; set; }
        public string SubmDate { get; set; }
        public string RecFromIns { get; set; }
        public decimal TotalOPDays { get; set; }
        public decimal TotalHLDays { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }

    public class ClaimMedicalExpense
    {
        public int MedicalExpenseId { get; set; }
        public string ClaimRefNo { get; set; }
        public int ClaimId { get; set; }
        public string VisitDate { get; set; }
        public string ReceiptNo { get; set; }
        public string SubmNo { get; set; }
        public string TypeofHospitalNClinic { get; set; }
        public decimal BillAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RejectedAmount { get; set; }
        public string ChequeNo { get; set; }
        public string SubmDate { get; set; }
        public string RecFromIns { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }

    public class ClaimPaymentIncapability
    {
        public int PaymentIncapabilityId { get; set; }
        public string ClaimRefNo { get; set; }
        public int ClaimId { get; set; }
        public decimal Percentage { get; set; }
        public string PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public string ChequeNo { get; set; }
        public string MOMAssessmentDate { get; set; }
        public string ReceivedFromInsurer { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }

    public class ClaimPayment
    {
        public string Remarks { get; set; }
        public List<ClaimPaymentSummary> PaymentSummaryList { get; set; }
        public List<ClaimPaymentDetails> PaymentDetailList { get; set; }
    }

    public class ClaimPaymentSummary
    {
        public int PaymentSummaryId { get; set; }
        public string ClaimRefNo { get; set; }
        public int ClaimId { get; set; }
        public string CompCode { get; set; }
        public decimal PaidAmt { get; set; }
        public decimal UnpaidAmt { get; set; }
        public decimal RejectedAmt { get; set; }
        public decimal OutstandingReserve { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        
    }

    public class ClaimPaymentDetails
    {
        public int PaymentDetailId { get; set; }
        public string ClaimRefNo { get; set; }
        public int ClaimId { get; set; }
        public string TransactionNo { get; set; }
        public string TransactionType { get; set; }
        public string ClaimType { get; set; }
        public string Currency { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal PaymentAmountOC { get; set; }
        public decimal PaymentAmountLC { get; set; }
        public string BankName { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeIssueDate { get; set; }
        public string ChequeSenttoClaimantDate { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
}
