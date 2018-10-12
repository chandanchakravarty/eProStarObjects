using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
 public  class clsSubDistrictMaster
    {
     public int SubDistrictId { get; set; }
        public int DistrictId { get; set; }
        public int TerritoryId { get; set; }
        public int ProvinceId { get; set; }
        public string AreaCode { get; set; }
        public string SubDistrictName { get; set; }
        public string SubDistrictNameChinese { get; set; }
        public string DistrictName { get; set; }
        public string ProvinceName { get; set; }
        public string TerrName { get; set; }
        public string User { get; set; }
        public string isActive { get; set; }

    }
}
