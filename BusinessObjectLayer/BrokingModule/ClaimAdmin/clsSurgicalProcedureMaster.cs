using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.ClaimAdmin
{
    public class clsSurgicalProcedureMaster
    {
        public int SurgicalProcedureId { get; set; }
        public string SurgicalProcedureCode { get; set; } // Added by anshul #itrack 106 Enhancement
        public string SurgicalProcedureDesc { get; set; }
        public string EffectivefromDate { get; set; }
        public string Effectivetodate { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
    }
}
