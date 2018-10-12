using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsLegislationNoteMaster
    {
        public int LegislationNoteID { get; set; }
        public string LegislationNote { get; set; }
        public string LegislationNoteType { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public string IsSelected { get; set; }
        public int OrderNo { get; set; }

    }
}
