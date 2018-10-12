using System;


namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsIllnessMaster
    {
     
        public int ClassId { get; set; }
        public int SubClassId { get; set; }
        public int IllnessId { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public string IllnessDescription { get; set; }
        public string EffectiveDateFrom { get; set; }
        public string EffectiveDateTo { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
    }
}
