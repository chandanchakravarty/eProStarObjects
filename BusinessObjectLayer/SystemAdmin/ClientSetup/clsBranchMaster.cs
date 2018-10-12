using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
    public class clsBranchMaster
    {
        public int BranchID { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string EffectivefromDate1 { get; set; }
        public string EffectivefromDate2 { get; set; }
        public string Effectivetodate1 { get; set; }
        public string Effectivetodate2 { get; set; }
        public string EffFrom { get; set; }
        public string EffFrom1 { get; set; }
        public string EffTo { get; set; }
        public string EffTo1 { get; set; }
        public string CreatedBy { get; set; }

        public string User { get; set; }
    }
}
