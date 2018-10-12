using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.AccountMaster
{
    public class clsCurrency
    {
        public Int32 CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyDescription { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }

        
    }
}
