using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    public class clsDebiteNoteWOCoverNoteDetails
    {
        public string CaseRefNo { get; set; }
        public string DebitNoteDate { get; set; }
        public int NoOfClients { get; set; }
        public int NoOfUnderWriters { get; set; }
        public int NoOfAgents { get; set; }
        public int NoOfInstallment { get; set; }
        public string Currency { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal AdditionalPremium { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalFees { get; set; }
        public decimal TotalBrokerage { get; set; }
        public decimal TotalSpecialDiscount { get; set; }
        public decimal TotalSurcharge { get; set; }
        public decimal TotalDue { get; set; }
        public string UserID { get; set; }
        public string UWriter_Currency { get; set; }
        public decimal UWriter_TotalPremium { get; set; }
        public decimal UWriter_TotalDiscount { get; set; }
        public decimal UWriter_TotalFees { get; set; }
        public decimal UWriter_TotalBrokerage { get; set; }
        public decimal UWriter_TotalSpecialDiscount { get; set; }
        public decimal UWriter_TotalSurcharge { get; set; }
        public decimal UWriter_NetAmount { get; set; }
        public decimal UWriter_UWShare { get; set; }
        public decimal UWriter_TotalDue { get; set; }
        public string Agent_Currency { get; set; }
        public decimal AgentBroker_TotalPremium { get; set; }
        public decimal AgentBroker_TotalBrokerage { get; set; }
        public decimal AgentBroker_Share { get; set; }
        public decimal AgentBroker_TotalDue { get; set; }
        public string IsFromHistory { get; set; }
        public decimal ClientTotalPremium { get; set; }
        public decimal ClientDiscountRate { get; set; }
        public decimal ClientDiscountAmount { get; set; }
        public decimal ClientSurchargeRate { get; set; }
        public decimal ClientSurchargeAmount { get; set; }
        public decimal ClientSPDiscountRate { get; set; }
        public decimal ClientSPDiscountAmount { get; set; }
        public decimal ClientFeesRate { get; set; }
        public decimal ClientFeesAmount { get; set; }
        public string PaymentModeCode { get; set; }
        public string PaymentMode { get; set; }
        public string InsurerNameCode { get; set; }
        public string InsurerName { get; set; }
        public decimal ClientShare { get; set; }
        public string OtherPayableTo { get; set; }
        public string BankId { get; set; }
        public int BankCurrency { get; set; }
        public bool IsPrintLegNote { get; set; }

        public decimal StampDuty { get; set; }
        public decimal Tax { get; set; }
        public decimal GroupDiscount { get; set; }
        public decimal OtherDiscount { get; set; }
        public decimal WHTAmount { get; set; }

        public decimal UWriter_StampDuty { get; set; }
        public decimal UWriter_Tax { get; set; }
        public decimal UWriter_CommissionAmt { get; set; }
        public decimal UWriter_TaxAmt { get; set; }
        public decimal UWriter_WHTAmt { get; set; }
        public decimal UWriter_TotalLeaderFee { get; set; }


      
        public decimal TotalNettPremium { get; set; }
       
        public bool IsManualOverwrite { get; set; }

        //added on 17th March//
        public string ClientContactName { get; set; }
        public string PremiumWarrantyCode { get; set; }
        public string PremiumWarrantyDesc { get; set; }
     
        //end
    }
}
