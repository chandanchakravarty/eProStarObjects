using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
   public class clsVAT_SBT_WHT
    {
       public int ID { get; set; }
       public int Type { get; set; }
       public string  Description { get; set; }
       public double  Rate { get; set; }
       public string EffFromDate { get; set; }
       public string EffFromDate1 { get; set; }
       public string EffToDate { get; set; }
       public string EffToDate1 { get; set; }
       public string LoginUserId { get; set; }
       public string PageMethod { get; set; }
       public string Text_Type { get; set; }
       public string VSWType { get; set; }
    }
}
