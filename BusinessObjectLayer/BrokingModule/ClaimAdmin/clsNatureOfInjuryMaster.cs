using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.ClaimAdmin
{
    public class clsNatureOfInjuryMaster
    {
        public int NatureOfInjuryId { get; set; }
        public string NatureOfInjury { get; set; }
        public string NatureOfInjuryFor { get; set; }
        public string EffectivefromDate { get; set; }
        public string Effectivetodate { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
    }
}
