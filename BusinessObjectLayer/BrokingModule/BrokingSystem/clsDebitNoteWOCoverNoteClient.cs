using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    public class clsDebitNoteWOCoverNoteClient
    {

        public string CaseRefNo { get; set; }
        public string DebitNoteNo { get; set; }
        public string RefNo { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string Currency { get; set; }
        public decimal Premium { get; set; }
        public decimal Discount { get; set; }
        public decimal Fees { get; set; }
        public decimal BrokerageRate { get; set; }
        public decimal Brokerage { get; set; }
        public decimal SpecialDiscount { get; set; }
        public decimal Surcharge { get; set; }
        public decimal TotalDue { get; set; }
        public string UserID { get; set; }
        public string IsFromHistory { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal ClientShare { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal TotalSurcharge { get; set; }
        public decimal SurchargeRate { get; set; }
        public decimal TotalSPDiscount { get; set; }
        public decimal SPDiscountRate { get; set; }
        public decimal FeesRate { get; set; }
        public string RiskLocationId { get; set; }
        public decimal StampDutyAmount { get; set; }
        public decimal StampDuty { get; set; }
        public decimal VATSBT { get; set; }
        public decimal Tax { get; set; }
        public decimal GroupDiscountPer { get; set; }
        public decimal GroupDiscount { get; set; }
        public decimal OtherDiscountPer { get; set; }
        public decimal OtherDiscount { get; set; }
        public decimal WHTPer { get; set; }
        public decimal WHTAmount { get; set; }

        public decimal PolicyCharge { get; set; }
        public decimal InsurerGSTPer { get; set; }
        public string InsurerGSTPerId { get; set; }
        public decimal InsurerGSTAmount { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal ServiceFeeGSTPer { get; set; }
        public string ServiceFeeGSTPerId { get; set; }
        public decimal ServiceFeeGSTAmount { get; set; }


        public decimal NCD { get; set; }
        public decimal NCDAmount { get; set; }
        public decimal LodingByInsurer { get; set; }
        public decimal LodingByInsurerAmount { get; set; }
        public decimal DiscountByInsurer { get; set; }
        public decimal DiscountByInsurerAmount { get; set; }
        public decimal NettPremium { get; set; }
        public decimal OtherCharges { get; set; }

        public int ServiceFeeType { get; set; }
        public int OtherChargesType { get; set; }
        //Enhancement #25159
        public string Remarks { get; set; }

    }
}
