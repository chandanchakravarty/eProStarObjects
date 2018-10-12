using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
  public class clsWorldRegionMaster
    {

        public int WorldRegId { get; set; }
        public string worldRegName { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string PageMethod { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
    }
}
