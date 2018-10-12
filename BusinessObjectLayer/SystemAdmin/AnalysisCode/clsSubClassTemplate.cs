using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.AnalysisCode
{
   public class clsSubClassTemplate
    {
        public int SubClassTemplateID { get; set; }
        public int ClassID { get; set; }
        public int SubClassID { get; set; }
        public string SubClassTemplateName { get; set; }
        public string FieldLanguage { get; set; }
        public string UserId { get; set; }
        public string IsActive { get; set; }

    }
    public class clsSubClassTemplateDetail
    {
        public int ClassTemplateID { get; set; }
        public int TemplateId { get; set; }
        public string FieldLabel { get; set; }
        public string ChFieldLabel { get; set; }
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

    }
    public class SubClassTemplateDetailList
    {
        public List<clsSubClassTemplateDetail> TemplateList { get; set; }
    }
}
