using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.CoverNote
{
    public class ClsCoverNoteEnquiry
    {
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
        public string Type { get; set; }
        public string Status { get; set; }
        public char IsRiSlip { get; set; }
        public string Purpose { get; set; }
        public string From { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public string InsFromDate1 { get; set; }
        public string InsFromDate2 { get; set; }
        public string InsToDate1 { get; set; }
        public string InsToDate2 { get; set; }

        public string Territory { get; set; }
        public string DocRefNo { get; set; }
        public string ReInsurerCode { get; set; }
        public string ReInsurerName { get; set; }
        public string ClaimNo { get; set; }
        public string PolicyNo { get; set; }
        public string ClaimINVNo { get; set; }
        public string ClaimINVNoDataMig { get; set; }
        public string SourceCNNumber { get; set; }
    }
}
