using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EBClaims
{
    public class clsEBClaimComplete
    {
        public string CaseRefNo { get; set; }
        public string MemberCode { get; set; }
        public string ClaimRefNo { get; set; }
        public string ClaimStatusCode { get; set; }
        public string ClaimStatusDescription { get; set; }
        public string IsReceiptReturned { get; set; }
        public string PendingDate { get; set; }
        public string PendingReason { get; set; }
        public string RejectDate { get; set; }
        public string RejectReason { get; set; }
        public string ApprovedDate { get; set; }
        public string Remarks { get; set; }
        public string UserID { get; set; }
        public string OrgRecToCLDate { get; set; }
        //Added For #26958
        public int ClaimDetailId { get; set; }
        public string ReceivedClientDate { get; set; }
        public string ReceivedInsurerDate { get; set; }
    }
}
