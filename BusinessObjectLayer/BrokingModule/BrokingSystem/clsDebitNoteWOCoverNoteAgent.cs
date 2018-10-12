using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    public class clsDebitNoteWOCoverNoteAgent
    {
        public string CaseRefNo { get; set; }
        public string DebitNoteNo { get; set; }
        public string RefNo { get; set; }        
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string Currency { get; set; }
        public decimal Premium { get; set; }        
        public decimal Brokerage { get; set; }
        public decimal AgentShare { get; set; }        
        public decimal TotalDue { get; set; }
        public string UserID { get; set; }
        public string IsFromHistory { get; set; }
        public string IsSubBroker { get; set; }
        public string LocatinDesc { get; set; }
        public string LocatinId { get; set; }
    }
}
