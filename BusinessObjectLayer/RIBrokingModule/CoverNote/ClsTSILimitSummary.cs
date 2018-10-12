using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.CoverNote
{
    public class ClsTSILimitSummary
    {
        public string TranRefNo { get; set; }
        public int MainClass { get; set; }
        public int SubClassCode { get; set; }
        public string Category { get; set; }
        public string Currency { get; set; }
        public decimal SumInsured { get; set; }
        public decimal DeclaredValue { get; set; }
        public decimal LoadingDiscount { get; set; }
        public decimal Premium { get; set; }
        public string UserId { get; set; }

        public decimal EQSumInsured { get; set; }
        public decimal EQPercentage { get; set; }
        public decimal SRCCSumInsured { get; set; }
        public decimal SRCCPercentage { get; set; }
        public decimal TerrorismSumInsured { get; set; }
        public decimal TerrorismPercentage { get; set; }
        public decimal TyphoonSumInsured { get; set; }
        public decimal TyphoonPercentage { get; set; }

        public string ID { get; set; }
        public string Description { get; set; }

        public decimal SumInsuredUpdated { get; set; }
        public decimal SumInsuredEndt { get; set; }
        public decimal SumInsuredLast { get; set; }

        public string ReInsurerSharePercent { get; set; }
        public decimal ReInsurerShareAmt { get; set; }

        // Added by praveen verma on 11 Apr 2017 For RI Broking.
        public decimal ExRate{ get; set; }
        public decimal SumInsuredLC{ get; set; }
        public decimal OriginalPremiumOC{ get; set; }
        public decimal CedantShare{ get; set; }
        public decimal CedantSumInsuredAmtOC { get; set; }
        public decimal CedantSumInsuredAmtLC { get; set; }
        public decimal PlacementPer{ get; set; }
        public decimal PlacementSumInsuredOC { get; set; }
        public decimal PlacementSumInsuredLC{ get; set; }
        public decimal PlacementPreiumOC{ get; set; }
        public decimal PlacementPreiumLC{ get; set; }

        public string XMLData { get; set; }
        public string IsInstallment { get; set; }
        public string NoOfInstallment { get; set; }
        public string CurrencyType { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string basis { get; set; }
        public string OriginalCurr { get; set; }
        public string LocalCurr { get; set; }
        public decimal AmountOC { get; set; }
        public decimal AmountLC { get; set; }
        public decimal Introducer_Fee { get; set; }
        public string IsClosingSlip { get; set; }
    }
}   
