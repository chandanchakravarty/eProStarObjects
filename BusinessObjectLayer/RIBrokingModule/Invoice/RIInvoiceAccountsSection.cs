using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.Invoice
{
    public class RIInvoiceAccountsSection
    {
        public string TranRefNo { get; set; }
        public string UserId { get; set; }
        public string Lock { get; set; }
        public string Export { get; set; }
        public string SpreadPeriodFrom { get; set; }
        public string SpreadPeriodTo { get; set; }
    }
}
