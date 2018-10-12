using System;


namespace BusinessObjectLayer.RIBrokingModule.BrokingAdmin
{
    public class clsConditionTemplate
    {
        public int ConditionTemplateID { get; set; }
        public string ConditionTemplateName { get; set; }
        public int ClassID { get; set; }
        public int SubClassID { get; set; }
        public string EffectiveDateFrom { get; set; }
        public string EffectiveDateTo { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public int CopyTemplateID { get; set; }

    }
}
