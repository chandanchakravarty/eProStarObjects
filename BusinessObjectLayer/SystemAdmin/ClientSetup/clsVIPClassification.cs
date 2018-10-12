using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
  public class clsVIPClassification
    {
        public int VipID { get; set; }
        public string VipType { get; set; }
        public string VipDescription { get; set; }
        public string EffFromDate { get; set; }
        public string EffFronDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
    }

  public class clsJurisdiction
  {
      public int JurisID { get; set; }
      public string Juris { get; set; }
    
      public string EffFromDate { get; set; }
      public string EffFronDate1 { get; set; }
      public string EffToDate { get; set; }
      public string EffToDate1 { get; set; }
      public string LoginUserId { get; set; }
      public string PageMethod { get; set; }
  }

}
