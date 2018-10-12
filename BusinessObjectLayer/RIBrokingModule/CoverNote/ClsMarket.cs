using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.CoverNote
{
    public class ClsMarket
    {
        public string TranRefNo { get; set; }
        public int SubClassCode { get; set; }
        public string ID { get; set; }
        public string Prefix { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string ReinsurerName { get; set; }
        public string LineSlip { get; set; }
        public decimal Share { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalDeduction { get; set; }
        public string RefNo { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }
        public decimal AmountLast { get; set; }
        public decimal AmountEndt { get; set; }

        public decimal PremiumRate { get; set; }
        public decimal Premium { get; set; }
        public decimal DirectCommRate { get; set; }
        public decimal DirectComm { get; set; }
        public decimal RICommRate { get; set; }
        public decimal RIComm { get; set; }
        public string ForeignLocal { get; set; }
        public string Leader { get; set; }
        public decimal Brokerage { get; set; }
        public decimal NetDue { get; set; }
        public string BrokerCode { get; set; }
        public string ReinsurerCode { get; set; }
        public string Security { get; set; }
        public string IsLeader { get; set; }
        public string EffectiveDate { get; set; }
        public decimal SharePerc { get; set; }
        public string IsBroker { get; set; }
        public string IsClosingSlip { get; set; }
    }
}
