using System;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
   public class clsBM_TemplateMapping
    {
        public string frmFor { get; set; }
        public int HeaderId { get; set; }
        public int TemplateId { get; set; }
        public string IsSelected { get; set; }
        public int ClassId { get; set; }
        public int SubClassId { get; set; }
        public int OrderNo {get; set;}
        public string UserId { get; set; }

    }
}
