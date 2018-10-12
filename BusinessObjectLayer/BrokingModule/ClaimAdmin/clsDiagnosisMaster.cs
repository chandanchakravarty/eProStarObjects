using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.ClaimAdmin
{
    public class clsDiagnosisMaster
    {
        public int DiagnosisId { get; set; }
        public string DiagnosisCode { get; set; }  //-- Added by anshul #itrack 106 Enhancement
        public string DiagnosisDesc { get; set; }
        public string EffectivefromDate { get; set; }
        public string Effectivetodate { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
    
    }
}
