using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits
{
    public class clsEBMemberDetails
    {
        public string PageMode		    { get; set; }
		public string CaseRefNo		    { get; set; }
		public string MemberCode	    { get; set; }
		public string ClientCode	    { get; set; }
		public string ClientName	    { get; set; }
		public string MemberStatusCode	{ get; set; }
		public string MemberStatusDesc	{ get; set; }
		public string Prev_MemberCode	{ get; set; }
		public string MemberName		{ get; set; }
		public string CardMemberName	{ get; set; }
		public string PassportNo		{ get; set; }
		public string DateofBirth		{ get; set; }
		public string Gender			{ get; set; }
		public string MaritalStatus		{ get; set; }
        public string NationalityCode   { get; set; }
		public string Nationality		{ get; set; }
		public string StaffID			{ get; set; }
        public string LocationCode      { get; set; }
		public string Location			{ get; set; }
        public string OccupationCode    { get; set; }
		public string OccupationDesc	{ get; set; }
		public string BeneficiaryCode	{ get; set; }
        public string BeneficiaryDesc   { get; set; }
		public string Position			{ get; set; }
		public string DateOfEmployment	{ get; set; }
		public string VIPPrivilegeCode	{ get; set; }
		public string VIPPrivilegeDesc	{ get; set; }
		public string Remarks			{ get; set; }
		public string EffectiveDate		{ get; set; }
		public string TerminationDate	{ get; set; }
		public string ReJoinDate		{ get; set; }
        public string UserID            { get; set; }
        public decimal Salary            { get; set; }
        public string CertificateNo     { get; set; }

        //added by kavita kaushik for deptType IH or EB//
        public string DeptType { get; set; }
        //end

        //For Enquiry
        public string PolicyNo { get; set; }
        public string DependantCode { get; set; }
        public string DependantName { get; set; }
        public string MemberType { get; set; }
        // For Suspension
        public string IsSuspend { get; set; }
        public string IsReinstate { get; set; }
        public string IsTerminated { get; set; }
        public string ReinstateDate { get; set; }
        public string ReinstateReason { get; set; }
        public string TerminateReason { get; set; }
        public string UpdatedBY { get; set; }
        public string CalledFrom { get; set; }

        public string SuspFromDate { get; set; }
        public string SuspToDate { get; set; }
        public string TerminateDate { get; set; }

        public string CovernoteNo { get; set; }
        public string POIFromDate { get; set; }
        public string POIToDate { get; set; }
        public string Plan { get; set; }
        public string PlanType { get; set; }
       
        public string DateToUW { get; set; }
        public string CardDispatch { get; set; }
        public string AdjustmentReportDispatch { get; set; }
        public string HDFToUW { get; set; }
        public string HDFToClient { get; set; }
        public string AdjustmentReportNo { get; set; }
        public decimal AdjustmentPremuim { get; set; }
        public int ReportId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string SubClassName { get; set; }
        public string UWName { get; set; }
        public string DateToClient { get; set; }

        public string UNType { get; set; }
        public string UNStatus { get; set; }

        public string PIHNo { get; set; }
        public string SchemeType { get; set; }
    }

    public class clsEBMemberSuspension
    {
        public string CaseRefNo { get; set; }
        public string MemberCode { get; set; }
        public string SuspFromDate { get; set; }
        public string SuspReason { get; set; }
        public string SuspToDate { get; set; }
        public string CancelSuspDate { get; set; }
        public string CancelSuspReason { get; set; }
        public string UpdatedBY { get; set; }
        public string CalledFrom { get; set; }
    }
    public class clsEBPlan
    {
        public string PlanName { get; set; }
        public string BenefitGroupLine { get; set; }
        public string BenefitLine { get; set; }
       
    }
}
