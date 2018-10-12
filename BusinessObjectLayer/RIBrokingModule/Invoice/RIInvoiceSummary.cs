using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.Invoice
{
    public class RIInvoiceSummary
    {
        public string TranRefNo { get; set; }
        public string UserId { get; set; }
        public string Remarks { get; set; }
    }


    public class RIInvoiceCedantSummary
    {
        public string TranRefNo { get; set; }
        public string CedantCode { get; set; }
        public string CedantName { get; set; }
      
        public int ClassID { get; set; }
        public string Currency { get; set; }
        public decimal TotalPremium { get; set; }
        public double  VATper { get; set; }
        public decimal VATAmount { get; set; }
        public double DirectCommPer { get; set; }
        public decimal DirectCommAmount { get; set; }
        public decimal  TotalPaybleAmount { get; set; }
        public string UserId { get; set; }
        public string SubClassName { get; set; }
        public int SubClassCode { get; set; }
     
    }


    public class RIInvoiceRISummary
    {
        public string TranRefNo { get; set; }
        public string RICode { get; set; }
        public string RIName { get; set; }
        public string RIType { get; set; }
        public int  ClassID { get; set; }
        public string Currency { get; set; }
        public double RISharePer { get; set; }
        public decimal RIPremium { get; set; }
        public double VATPer { get; set; }
        public decimal VATAmount { get; set; }
        public double WHTPer { get; set; }
        public decimal WHTAmount { get; set; }


        public double DirectCommPer { get; set; }
        public decimal DirectCommAmount { get; set; }
        public double RICommPer { get; set; }
        public decimal RICommAmount { get; set; }
        public decimal VATAmountNew { get; set; }
        public decimal WHTAmountNew { get; set; }

        public decimal NetPayable { get; set; }
        public string UserId { get; set; }   
        public string SubClassName { get; set; }
        public int SubClassCode { get; set; }

    }

}
