using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.Claims
{
    public class RIClaimSearch
    {
        public string TranRefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public string CedantCode { get; set; }
        public string CedantName { get; set; }
        public string ReinsuredCode { get; set; }
        public string ReinsuredName { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string MainClass { get; set; }
        public string Handler { get; set; }
        public string CreatedBy { get; set; }
        public string CedantPolicyNo { get; set; }
        public string From { get; set; }
        public string ClaimNo { get; set; }
        public string CedantClaimNo  { get; set; }
        public string SubClass { get; set; }
        public string DateOfLoss { get; set; }
        public int MovementNo { get; set; } 
    }
}
