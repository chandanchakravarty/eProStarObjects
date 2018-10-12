using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EBClaims
{
    public class EbTagDiagnosisDetails
    {
        public int TagId { get; set; }
        public int ClaimId { get; set; }
        public string ClaimNo { get; set; }
        public int DiagId { get; set; }
        public string MemberCode { get; set; }
        public string TagRef { get; set; }
        public string Action { get; set; }
        public string TagStatus { get; set; }
        public string TagNew { get; set; }
        public string TagDate { get; set; }
        public string UnTagDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
