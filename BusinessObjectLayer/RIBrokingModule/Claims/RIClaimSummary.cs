using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.Claims
{
    public class RIClaimSummary
    {
        public string ClaimNo { get; set; }
        public string TranRefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public string MainClass { get; set; }
        public string  SubClassCode{ get; set; }
        public string CedantClaimNo { get; set; }
        public string PolicyNo { get; set; }
        public string  OtherReference{ get; set; }
        public string  CedantCode{ get; set; }
        public string  CedantName{ get; set; }
        public string  CedantRefNo{ get; set; }
        public string  Description{ get; set; }
        public string  NWIClaimRef{ get; set; }
        public string  Project{ get; set; }
        public string  ReinsuredCode{ get; set; }
        public string  ReinsuredName{ get; set; }
        public string  ClientRefNo{ get; set; }
        public string  Currency{ get; set; }
        public string  MainExpiry{ get; set; }
        public string  PeriodFrom{ get; set; }
        public string  PeriodTo{ get; set; }
        public string  Insured{ get; set; }
        public string  ClientName{ get; set; }
        public string  Jurisdiction{ get; set; }
        public string  DateOfLoss{ get; set; }
        public string  NatureOfLoss{ get; set; }
        public string  Remarks{ get; set; }
        public string  Comments{ get; set; }
        public string UserId { get; set; }
        public string PageMode { get; set; }

        public string NotifyDt { get; set; }
        public string DairyDT { get; set; }
        public string DairyDesc { get; set; }
                
    }
}
