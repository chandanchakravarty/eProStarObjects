using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.ClaimAdmin
{
    public class clsPartOfBodyMaster
    {
        public int PartOfBodyId { get; set; }
        public string PartOfBodyFor { get; set; }
        public string PartOfBody { get; set; }
        public string EffectivefromDate { get; set; }
        public string Effectivetodate { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
    }
}
