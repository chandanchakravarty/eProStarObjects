using System;

namespace BusinessObjectLayer.RIBrokingModule.RIClaimAdmin
{
    public class clsRemarkMaster
    {
        public int RemarkId { get; set; }
        public string RemarkDescription { get; set; }
        public string EffectiveDateFrom { get; set; }
        public string EffectiveDateTo { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }

    }
}
