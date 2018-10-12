using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.BrokingAdmin
{
    public class clsRI_ProvinceMaster
    {
        public int ProvinceId { get; set; }
        public int TerrotoryId { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceNameChineese { get; set; }
        public string User { get; set; }
        public string isActive { get; set; }
    }
}
