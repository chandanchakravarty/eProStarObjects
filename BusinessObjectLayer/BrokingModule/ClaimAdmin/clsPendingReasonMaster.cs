using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.ClaimAdmin
{
     public class clsPendingReasonMaster
     {
        public int PendingReasonId { get; set; }
        public string PendingReasonDesc { get; set; }
        public string EffectivefromDate { get; set; }
        public string Effectivetodate { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
     }
}
