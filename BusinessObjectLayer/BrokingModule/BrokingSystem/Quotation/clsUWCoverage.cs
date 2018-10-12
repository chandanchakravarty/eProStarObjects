using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation
{
    public class clsUWCoverage
    {
        public Int64 PolUWCovId { get; set; }
        public Int64 PolUWId { get; set; }
        public  int UnderwriterId { get; set; }
        public Int64 PolicyId { get; set; }
        public int PolicyVerId { get; set; }
        public string User { get; set; }
        public string  FieldLanguage {get;set;}
        public string isActive { get; set; }
        public int SubClassId { get; set; }
        public string RiskDetailsSubClassType { get; set; }
        public string RefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public int ClassId { get; set; }
    }
    public class clsPolicyUWCovDetails
    {
        public int PolicyUWCovDetailId { get; set; }
        public Int64 PolicyId { get; set; }
        public int PolicyVerId { get; set; }
        public Int64 PolUWCovId { get; set; }
        public int SubClassTemplateId { get; set; }
        public int? TemplateId { get; set; }
        public string FieldLabel { get; set; }
        public string ChFieldLabel { get; set; }
        public string FieldLabelValue { get; set; }
        public string CurrencyCode { get; set; }
        public int IncDispOrder { get; set; }
        public string IsIncluded { get; set; }
        public string IsMandatory { get; set; }
        public string ToBePrinted { get; set; }
        public int ToBePrintedOrder { get; set; }
        public string DebitNoteField { get; set; }
        public int DebitNoteOrder { get; set; }
        public string CreditNoteField { get; set; }
        public int CreditNoteOrder { get; set; }
        public int IsSelected { get; set; }
        public int HeaderId { get; set; }

        public string RefNo { get; set; }
        public string CoverNoteNo { get; set; }
     
    }
    public class PolicyUWCovList
    {

        public List<clsPolicyUWCovDetails> PolicyUWCov { get; set; }
    }
}
