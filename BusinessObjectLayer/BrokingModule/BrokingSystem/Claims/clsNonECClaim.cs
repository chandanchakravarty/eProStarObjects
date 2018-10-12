using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Claims
{
    public class clsNonECClaim
    {
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
        public string AccountHandlerCode { get; set; }
        public string AccountHandlerName { get; set; }
        public string LossAdjusterCode { get; set; }
        public string LossAdjusterName { get; set; }
        public string HealthCareCode { get; set; }
        public string HealthCareName { get; set; }
        public string SolicitorCode { get; set; }
        public string SolicitorName { get; set; }
        public string InvestigatorCode { get; set; }
        public string InvestigatorName { get; set; }
        public string UserID { get; set; }
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public string FileStatus { get; set; }
        //For Enquiry
        public string IssueFromDate { get; set; }
        public string IssueToDate { get; set; }
        public string ClaimStatus { get; set; }  

    }
}
