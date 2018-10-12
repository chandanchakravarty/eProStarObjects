using System;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsDocumentComMaster
    {
        public int DocumentComId { get; set; }
        public string DocumentCom { get; set; }
        public string PaperDescription { get; set; }
        public string EffectiveDateFrom { get; set; }
        public string EffectiveDateTo { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
    }
}
