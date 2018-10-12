using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.Invoice
{
    public class RIInvoiceSearch
    {
        public string TranRefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public string RISlipNo { get; set; }
        public string CedantCode { get; set; }
        public string CedantName { get; set; }
        public string ReinsuredCode { get; set; }
        public string ReinsuredName { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string MainClass { get; set; }
        public string Handler { get; set; }
        public string CreatedBy { get; set; }
        public string Project { get; set; }
        public string CedantPolicyNo { get; set; }
        public string From { get; set; }
        public string InvoiceNo { get; set; }
        public string Status { get; set; }
        public string DebitNoteFrom { get; set; }
        public string DebitNoteTo { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
