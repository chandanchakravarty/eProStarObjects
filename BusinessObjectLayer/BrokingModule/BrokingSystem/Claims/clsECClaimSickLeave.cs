using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Claims
{
    public class clsECClaimSickLeave
    {
        public string CaseRefNo { get; set; }
        public string ClaimRefNo { get; set; }
        public string RefNo { get; set; }
        public string LeaveFromDate { get; set; }
        public string LeaveToDate { get; set; }
        public int TotalDay { get; set; }
        public string UserID { get; set; }
    }
}
