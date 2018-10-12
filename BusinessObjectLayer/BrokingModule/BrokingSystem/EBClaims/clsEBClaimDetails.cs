using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EBClaims
{
[Serializable]
    public class clsEBClaimDetails
    {
        public long ClaimId { get; set; }
        public string CaseRefNo	    { get; set; }
        public string MemberCode	{ get; set; }
        public string ClaimRefNo	{ get; set; }
        public string MemberRegRefNo { get; set; }
        public string ClaimNo	    { get; set; }
        public string ClaimTypeCode	{ get; set; }
        public string ClaimTypeDesc	{ get; set; }
        public string IssueDate	    { get; set; }
        public string CoverNoteNo	{ get; set; }
        public string SubClassID	{ get; set; }
        public string SubClass	    { get; set; }
        public string PolicyNo	    { get; set; }
        public string POIFromDate	{ get; set; }
        public string POIToDate	    { get; set; }
        public string NotifyByCode	{ get; set; }
        public string NotifyBy	    { get; set; }
        public string NotifyDate	{ get; set; }
        public string LocationCode	{ get; set; }
        public string Location	    { get; set; }
        public string ClientCode	{ get; set; }
        public string ClientName	{ get; set; }
        public string ClientTeam	{ get; set; }    
        public string ClientFirstName	{ get; set; }
        public string ClientLastName	{ get; set; }
        public string ClientEmail	{ get; set; }
        public string ClientDirectLine1	{ get; set; }
        public string ClientDirectLine2	{ get; set; }
        public string ClientMobile1	{ get; set; }
        public string ClientMobile2	{ get; set; }
        public string ClientFax1	{ get; set; }
        public string ClientFax2	{ get; set; }
        public string UwriterCode	{ get; set; }
        public string UwriterName	{ get; set; }
        public string UwClaimNo	    { get; set; }
        public string UwriterTeam	{ get; set; }
        public string UwriterFirstName	{ get; set; }
        public string UwriterLastName	{ get; set; }
        public string UwriterEmail	    { get; set; }
        public string UwriterDirectLine1	{ get; set; }
        public string UwriterDirectLine2	{ get; set; }
        public string UwriterMobile1	{ get; set; }
        public string UwriterMobile2	{ get; set; }
        public string UwriterFax1	{ get; set; }
        public string UwriterFax2	{ get; set; }
        public string ClaimHandlerCode	{ get; set; }
        public string ClaimHandlerDescription	{ get; set; }
        public string SurveyorCode	{ get; set; }
        public string SurveyorDescription	{ get; set; }
        public string AccountHandlerCode	{ get; set; }
        public string AccountHandlerDescription	{ get; set; }
        public string LossAdjusterCode	{ get; set; }
        public string LossAdjusterDescription	{ get; set; }
        public string HealthCareCode	{ get; set; }
        public string HealthCareDescription	{ get; set; }
        public string SolicitorCode	{ get; set; }
        public string SolicitorDescription	{ get; set; }
        public string InvestigatorCode	{ get; set; }
        public string InvestigatoreDescription	{ get; set; }
        public string UserID { get; set; }
        public string ClaimStatus { get; set; }
        public string PlanName { get; set; }    
        //For Enquiry
        public string MemberName { get; set; }
        public string PassportNo { get; set; }
        public string RefNo { get; set; }
        public string AdmissionDate { get; set; }
        public int Benefitlimit { get; set; }
        public string MemberType{ get; set; }
        public string CertificateNo { get; set; }
        public string IssueFromDate { get; set; }
        public string IssueToDate { get; set; }
        public string CorporatePolicyNo { get; set; }
        public string ConsultationFromDate { get; set; }
        public string ConsultationToDate { get; set; }
        public string IncurredAdmDate { get; set; }
        public string InsurerClaimNo { get; set; }
        public string LOGIssued { get; set; }
        public string LOGRefNo { get; set; }
        public string DischargeDate { get; set; }
        public string FirstDocReceived { get; set; }
        public string ServiceProvider { get; set; }
        public string FinalDocReceived { get; set; }
        public string Others { get; set; }
        public string SubmissiontoInsurer { get; set; }
        public string ServiceProviderType { get; set; }
        public string AdmissionType { get; set; }
        public string HospitalName { get; set; }
        public string HospitalType { get; set; }
        public string DiseaseType { get; set; }
        public string MCDays { get; set; }
        public string RejectedDate { get; set; }
        public string RejectedReason { get; set; }
        public string RejectedReturnDocDate { get; set; }
        public string WithdrawDate { get; set; }
        public string WithdrawReason { get; set; }
        public string WithdrawReturnDocDate { get; set; }
        public string VoidDate { get; set; }
        public string VoidReason { get; set; }
        public DataTable DiagnosisDescriptions { get; set; }
        public int PreHospitalizationDays { get; set; }
        public int PostHospitalizationDays { get; set; }
        public int PerDisabilitydays { get; set; }
        public string DependantName { get; set; }
        public string TagRef { get; set; }
        public decimal AmountIncurred { get; set; }
    }
}
