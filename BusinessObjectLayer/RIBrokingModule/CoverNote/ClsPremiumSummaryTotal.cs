using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.CoverNote
{
    public class ClsPremiumSummaryTotal
    {
        public string TranRefNo { get; set; }
        public string UserId { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal Amount { get; set; }
        public string DepositFollowUpDate { get; set; }
        public int Installments { get; set; }
        public decimal DirectBrokerage { get; set; }
        public decimal LongTermAggreement { get; set; }
        public decimal PremiumReserve { get; set; }
        public decimal RICommission { get; set; }
        public decimal ProfitCommision { get; set; }
        public decimal TotalRICommision { get; set; }
        public decimal TotalEarning { get; set; }
        public decimal IRMBrokerage { get; set; }
        public decimal IRMBrokerageOption { get; set; }
        public string ReferalCode1 { get; set; }
        public string ReferalName1 { get; set; }
        public decimal ReferalPercentage1 { get; set; }
        public string ReferalType1 { get; set; }
        public decimal ReferalAmount1 { get; set; }
        public string ReferalCode2 { get; set; }
        public string ReferalName2 { get; set; }
        public decimal ReferalPercentage2 { get; set; }
        public string ReferalType2 { get; set; }
        public decimal ReferalAmount2 { get; set; }
        public decimal depositPremium { get; set; }

        public int InstallmentNo { get; set; }
        public decimal InstallmentPercentage { get; set; }
        public string InstallmentDueDate { get; set; }

        public decimal ENTotalEarning { get; set; }
        public decimal ENIRMBrokerage { get; set; }
        public decimal TotalEarningEnAmt { get; set; }
        public decimal BrokerageEnAmt { get; set; }

    }
}
