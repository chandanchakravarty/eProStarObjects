using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    public class clsDebitNoteWOCoverNoteInstalment
    {
        public string   CaseRefNo { get; set; }        
		public string   RefNo		{ get; set; }        
		public int      InstNo	{ get; set; }        
		public decimal  InstPercentage	{ get; set; }        
		public string   Currency		{ get; set; }        
		public string   DebitNoteDate	{ get; set; }        
		public string   PeriodFrom	{ get; set; }        
		public string   PeriodTo		{ get; set; }        
		public decimal  Premium		{ get; set; }
        public decimal  Discount { get; set; }
        public decimal  Fees { get; set; }
        public decimal  Brokerage { get; set; }
        public decimal  SpecialDiscount { get; set; }
        public decimal  Surcharge { get; set; }
        public decimal  TotalDue { get; set; }
        public decimal  ClientShare { get; set; }
        public decimal  DiscountRate { get; set; }
        public decimal  SurchargeRate { get; set; }
        public decimal  SPDiscountRate { get; set; }
        public decimal  FeesRate { get; set; }

        public decimal NetAmount { get; set; }
        public decimal BrokerageRate { get; set; }
        public decimal UWShare { get; set; }

        public decimal AgentShare { get; set; }

        public string DebitNoteNo { get; set; }
        public string IsFromHistory { get; set; }
        public string User { get; set; }

         public decimal  PolicyCharge { get; set; }
         public decimal  InsurerGST  { get; set; }
         public decimal InsurerGSTPer { get; set; }
         public string InsurerGSTPerId { get; set; }
         public decimal  ServiceFee  { get; set; }
         public decimal  ServiceFeeGST { get; set; }
         public decimal ServiceFeeGSTPer { get; set; }
         public string ServiceFeeGSTPerId { get; set; }
         public decimal  StampDuty  { get; set; }
         public decimal BrokerGSTAmount { get; set; }
         public decimal BrokerGSTper { get; set; }
         public string BrokerGSTperId { get; set; }

         public decimal WHTrate { get; set; }
         public decimal WHTAmount { get; set; }
         public decimal TaxRate { get; set; }
         public decimal TaxAmount { get; set; }
         public decimal CommissionRate { get; set; }
         public decimal CommissionAmount { get; set; }
         public decimal InsurerTaxRate { get; set; }
         public decimal InsurerTaxAmount { get; set; }
         public decimal StampDutyRate { get; set; }
         public string DebitNoteDueDate { get; set; }  
    }                                  
}
