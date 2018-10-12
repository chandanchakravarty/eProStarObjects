using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    public class clsDebitNoteWOCoverNoteUnderWriter
    {
        public string CaseRefNo { get; set; }
        public string DebiteNoteNo { get; set; }
        public string RefNo { get; set; }
        public string IsLeader { get; set; }
        public string UnderWriterCode { get; set; }
        public string UnderWriterName { get; set; }
        public string Currency { get; set; }
        public decimal Premium { get; set; }
        public decimal Discount { get; set; }
        public decimal Fees { get; set; }
        public decimal Brokerage { get; set; }
        public decimal SpecialDiscount { get; set; }
        public decimal Surcharge { get; set; }
        public decimal NetAmount { get; set; }
        public decimal UwShare { get; set; }
        public decimal TotalDue { get; set; }
        public string UserID { get; set; }        
        public string IsFromHistory { get; set; }
        public string IsCoinsurance { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal BrokerageRate { get; set; }
        public decimal FeesRate { get; set; }
        public string LocationId { get; set; }
        public string  LocationDesc { get; set; }

        public decimal StampDuty { get; set; }
        public decimal Tax { get; set; }
        public decimal CommissionPer { get; set; }
        public decimal CommissionAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal WHTAmt { get; set; }
        public decimal LeaderFeePer { get; set; } 
        public decimal LeaderFee { get; set; } 

        public decimal PolicyCharge { get; set; }
        public decimal InsurerGSTPer { get; set; }
        public string InsurerGSTId { get; set; }
        public decimal InsurerGSTAmount { get; set; }
        public decimal BrokerGST { get; set; }
        public string BrokerGSTId { get; set; }
        public decimal BrokerGSTAmount { get; set; }
        public decimal VATSBT { get; set; }
        public decimal InsuTaxPer { get; set; }
        public decimal InsuTaxAmount { get; set; }
        public decimal WHTPer { get; set; }
        public decimal BrokerageFee { get; set; }
    }
}
