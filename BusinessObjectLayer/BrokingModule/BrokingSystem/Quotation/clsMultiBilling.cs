using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation
{
    public class clsMultiBilling
    {

        public Int64 PolicyId { get; set; }
        public int PolicyVerId { get; set; }
        public Int64 UwriterId { get; set; }
        public int ClientId { get; set; }
        public string User { get; set; }
        public string Remarks { get; set; }
        public string IsActive { get; set; }
        public string PageMode { get; set; }
    }

    public class clsClientInstalment
    {
        public Int64 ClientInstId { get; set; }
        public int ClientId { get; set; }
        public string Currency { get; set; }
        public int InstNo { get; set; }
        public decimal InstPercentage { get; set; }
        public decimal ClientSharePrecentage { get; set; }
        public decimal InstPremiumAmt { get; set; }
        public decimal ClientDisctRate { get; set; }
        public decimal InstClientDisctAmt { get; set; }
        public decimal SurchargeRate { get; set; }
        public decimal InstSurchargeAmt { get; set; }
        public decimal SPDisctRate { get; set; }
        public decimal InstSPDisctAmt { get; set; }
        public decimal HandlingFeeRate { get; set; }
        public decimal InstHandlingFeeAmt { get; set; }
        public decimal InstDueAmt { get; set; }

        public decimal Inst { get; set; }
        public string DebitNoteDate { get; set; }
        public string PeriodFrom { get; set; }
        public string PeriodTo { get; set; }

        public decimal StampDutyRate { get; set; }
        public decimal StampDuty { get; set; }
        public decimal VATSBTRate { get; set; }
        public decimal VATSBTAMT { get; set; }
        public decimal AmtClient { get; set; }
        public decimal WHTRate { get; set; }
        public decimal WHTAmount { get; set; }

        public decimal PolicyCharge { get; set; }
        public decimal InsurerGST { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal ServiceFeeGST { get; set; }

     //Added for redmine 19711

        public decimal NCDAmount { get; set; }
        public decimal LoadingByInsurerAmt { get; set; }
        public decimal DiscountByInsurerAmt { get; set; }
        public decimal OtherCharges { get; set; }

        //Enhancement #25159
        public string Remarks { get; set; }

    }
    public class clsUWriterInstalment
    {
        public Int64 UWriterInstId { get; set; }
        public int UwId { get; set; }
        public string Currency { get; set; }
        public int InstNo { get; set; }
        public decimal InstPercentage { get; set; }
        public decimal InstPremiumAmt { get; set; }
        public decimal UwSharePercentage { get; set; }
        public decimal InstClientDisctAmt { get; set; }
        public decimal BrokeragePercentage { get; set; }
        public decimal InstBrokerageAmt { get; set; }
        public decimal InstSurchargeAmt { get; set; }
        public decimal LeaderFeePercentage { get; set; }
        public decimal InstLeaderFeeAmt { get; set; }
        public decimal InstDueAmt { get; set; }
        public string DebitNoteDate { get; set; }
        public string PeriodFrom { get; set; }
        public string PeriodTo { get; set; }

        public decimal InsTaxPer { get; set; }
        public decimal InsTax { get; set; }
        public decimal WHT1Per { get; set; }
        public decimal WHT1Amt { get; set; }
        public decimal CommTax { get; set; }
        public decimal CommTaxAmt { get; set; }
        public decimal WHT2Per { get; set; }
        public decimal WHT2Amt { get; set; }

        public decimal PolicyCharge { get; set; }
        public decimal InsurerGST { get; set; }
        public decimal StampDuty { get; set; }
        public decimal BrokerageFee { get; set; }

        //Added for redmine 28253

        public decimal NCDAmount { get; set; }
        public decimal LoadingByInsurerAmt { get; set; }
        public decimal DiscountByInsurerAmt { get; set; }

        // Added RedmineID #25924
        public decimal BrokerGST { get; set; }
        public string BrokerGSTId { get; set; }
        public decimal BrokerGSTAmount { get; set; }
    }
    public class clsMultipleBillingDetail
    {

        public Int64 ClientId { get; set; }
        public string Currency { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal SharePerc { get; set; }
        public decimal PremiumAllocation { get; set; }
        public decimal discountRate { get; set; }
        public decimal discountAmt { get; set; }
        public decimal surChargeRate { get; set; }
        public decimal surChargeAmt { get; set; }
        public decimal SpdiscountRate { get; set; }
        public decimal SpdiscountAmt { get; set; }
        public decimal HandlingFeeRate { get; set; }
        public decimal HandlingFeeAmt { get; set; }
        public decimal CurrecnyCode { get; set; }
        public decimal DueFromClient { get; set; }

        public decimal StampDuty { get; set; }
        public decimal StampDutyAmt { get; set; }
        public decimal VATSBT { get; set; }
        public decimal VATSBTAmount { get; set; }
        public decimal TotalAmtClient { get; set; }
        public decimal WHT { get; set; }
        public decimal WHTAmt { get; set; }

        public decimal PolicyCharge { get; set; }
        public decimal InsurerGST { get; set; }
        public decimal ServiceFee { get; set; }
        public decimal ServiceFeeGST { get; set; }
        public decimal InsurerGSTPer { get; set; }
        public string InsurerGSTPerId { get; set; }
        public decimal ServiceFeeGSTPer { get; set; }
        public string ServiceFeeGSTPerId { get; set; }
        //Enhancement #25159
        public string Remarks { get; set; }


        //Added for redmine 12165

        public decimal NCDAmount { get; set; }
        public decimal LoadingByInsurerAmt { get; set; }
        public decimal DiscountByInsurerAmt { get; set; }
        public decimal OtherCharges { get; set; }



    }

    public class clsIntroducerInstalment
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int AgentId { get; set; }
        public string User { get; set; }
        public string id { get; set; }
        public string Currency { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal Totalbrokerage { get; set; }
        public decimal IntroducerShare { get; set; }
        public decimal TotalDue { get; set; }
        public decimal AgGSTPer { get; set; }
        public decimal AgGSTAmt { get; set; }
        public int InstNo { get; set; }
        public decimal InstPercentage { get; set; }
        public string DebitNoteDate { get; set; }
        public string PeriodFrom { get; set; }
        public string PeriodTo { get; set; }
    }

    public class clsMultiBillingList
    {
        public List<clsClientInstalment> ClientInstmt { get; set; }
        public List<clsUWriterInstalment> UWriterInstmt { get; set; }
        public List<clsMultipleBillingDetail> MultiBillingDetail { get; set; }
        public List<clsIntroducerInstalment> IntroducerInstalment { get; set; }
    }
}