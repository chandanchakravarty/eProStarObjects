using System;


namespace BusinessObjectLayer.RIBrokingModule.BrokingAdmin
{
    public class clsConditionTemplateMapping
    {
        public int ConditionId { get; set; }
        public int ConditionTemplateID { get; set; }
        public string IsSelected { get; set; }
        public int ClassId { get; set; }
        public int SubClassId { get; set; }

    }
}
