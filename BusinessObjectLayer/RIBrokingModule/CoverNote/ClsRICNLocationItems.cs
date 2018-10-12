using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.CoverNote
{
    public class ClsRICNLocationItems
    {
        public string Mode { get; set; }
        public string TranRefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public int MainClass { get; set; }
        public int SubClassCode { get; set; }
        public string LocatioId { get; set; }
        public string UserId { get; set; }
        public string LocationItem { get; set; }
        public string Description { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public decimal TSI { get; set; }
        public string Currency { get; set; }
        public decimal TSIOrgCurrency { get; set; }
    }
}
