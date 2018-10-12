using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.BrokingAdmin
{
    public class clsExportPremiumInvSetup
    {
        public int ExportId { get; set; }
        public string Action { get; set; }
        public int RangFrom { get; set; }
        public int RangTo { get; set; }
        public string DebitRangFrom { get; set; }
        public string DebitRangTo { get; set; }
        public string fromDate { get; set; }
        public string todate { get; set; }
        public string SystemMessage  { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
        public string ForModule { get; set; }
        public string LockedByUser { get; set; }
        public string UnLockedByUser { get; set; }
        public string BatchRefNo { get; set; }
        public string CsvFileName { get; set; }
        public string DebitNoteStatus { get; set; }
    }
}
