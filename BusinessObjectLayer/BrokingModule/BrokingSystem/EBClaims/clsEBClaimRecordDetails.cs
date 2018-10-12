using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EBClaims
{
    public class clsEBClaimRecordDetails
    {
        public string CaseRefNo { get; set; }
        public string MemberCode { get; set; }
        public string ClaimRefNo { get; set; }
        public string MemberRegRefNo { get; set; }
        public string ClientDate { get; set; }
        public string InsurerDate { get; set; }
        public string ConsulationDate { get; set; }
        public string ConsulationToDate { get; set; }
        public string SubmissionDate { get; set; }
        public string ReSubmissionDate { get; set; }
        public string ToClientDate { get; set; }
        public string ReSubmissionToInsurerDate { get; set; }

        public string ProviderName { get; set; }
        public string DoctorName { get; set; }
        public string UserID { get; set; }

        public string DiagnosisRefNo { get; set; }
        public string DiagnosisCode { get; set; }
        public string DiagnosisDesc { get; set; }

        public string ProcedureRefNo { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureDesc { get; set; }
    }
}
