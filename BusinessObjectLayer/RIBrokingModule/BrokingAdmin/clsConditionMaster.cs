using System;


namespace BusinessObjectLayer.RIBrokingModule.BrokingAdmin
{
    public class clsConditionMaster
    {
        public int ClassID { get; set; }
        public int SubClassID { get; set; }
        public int ConditionId { get; set; }
        public string ConditionHeader { get; set; }
        public string ConditionHeaderCH { get; set; }
        public string ConditionDescription { get; set; }
        public string EffectiveDateFrom { get; set; }
        public string EffectiveDateTo { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
    }
}
