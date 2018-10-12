using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
    public class clsRegionMaster
    {
        public int RegionID { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string EffFrom { get; set; }
        public string EffFrom1 { get; set; }
        public string EffTo { get; set; }
        public string EffTo1 { get; set; }
        public string CreatedBy { get; set; }
    }
}
