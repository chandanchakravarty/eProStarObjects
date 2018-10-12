using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
    public class clsCityMaster
    {
        public int CityId { get; set; }
        public int TerritoryId { get; set; }
        public int ProvinceId { get; set; }
        public string AreaCode { get; set; }
        public string CityName { get; set; }
        public string CityNameChinese { get; set; }
        public string ProvinceName { get; set; }
        public string TerrName { get; set; }
        public string User { get; set; }
        public string isActive { get; set; }


    }
}
