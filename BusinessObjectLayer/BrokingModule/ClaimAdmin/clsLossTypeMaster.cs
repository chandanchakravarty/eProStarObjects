using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.ClaimAdmin
{
    public class clsLossTypeMaster
    {
        public int LossTypeId { get; set; }
        public string LossTypeFor { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string LossTypeName { get; set; }
        public string EffectivefromDate { get; set; }
        public string EffectivefromDate1 { get; set; }
        public string Effectivetodate { get; set; }
        public string Effectivetodate1 { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
    }
    public class clsLocationPanelMaster
    {
        public int LocationPanelID { get; set; }
        public string LocationPanel { get; set; }
        public string EffFrom { get; set; }
        public string EffFrom1 { get; set; }
        public string EffTo { get; set; }
        public string EffTo1 { get; set; }
        public string CreatedBy { get; set; }
    }
}
