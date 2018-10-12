using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
    public class clsClientSource
    {
        public int ClientSourceId { get; set; }
        public string ClientSourceCode { get; set; }
        public string ClientSourceDesc { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffectiveFromDate1 { get; set; }
        public string EffectiveToDate { get; set; }
        public string EffectiveToDate1 { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
    }
}
