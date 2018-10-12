using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
    public  class clsProvinceMaster
    {
        public int ProvinceId { get; set; }
        public int TerrotoryId { get; set; }
        public string TerrName { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceNameChineese { get; set; }
        public string User { get; set; }
        public string isActive { get; set; }

    }
}

