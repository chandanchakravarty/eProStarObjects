using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.ClaimAdmin
{
   public class clsCauseOfInjuryMaster
    {

        public int CauseOfInjuryId { get; set; }
        public string CauseOfInjury { get; set; }
        public string CauseOfInjuryFor { get; set; }
        public string EffectivefromDate { get; set; }
        public string Effectivetodate { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }

    }
}
