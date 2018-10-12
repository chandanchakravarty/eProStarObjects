using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.Claims
{
    public class RIClaimDetailsCollection
    {
        public string ClaimNo { get; set; }
        public string ID { get; set; }
        public string MovementNo { get; set; }
        public string IsChanged { get; set; }
        public string IsAdded { get; set; }
        public string CodePrefix { get; set; }
        public string Code { get; set; }
        public string  RIApplication{ get; set; }
        public string Reinsurer { get; set; }
        public decimal  Share{ get; set; }
        public string  RefNo{ get; set; }
        public decimal  PaidAmount{ get; set; }
        public decimal  Reserve{ get; set; }
        public string  InvoiceNo{ get; set; }
        public string  Status{ get; set; }
        public string  SettlementCurrency{ get; set; }
        public string  ReceiptNo{ get; set; }
        public string  DOS{ get; set; }
        public decimal  SettlementAmount{ get; set; }
        public string UserId { get; set; }

    }
}
