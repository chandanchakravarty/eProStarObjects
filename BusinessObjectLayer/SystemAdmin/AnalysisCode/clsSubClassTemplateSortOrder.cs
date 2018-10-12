using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.AnalysisCode
{
    public class clsSubClassTemplateSortOrder
    {
        public int SubClassTemplateID { get; set; }
        public int TemplateId { get; set; }
        public string FieldName { get; set; }
        public int IncDispOrder { get; set; }
        public int ToBePrintedOrder { get; set; }
        public int DebitNoteOrder { get; set; }
        public int CreditNoteOrder { get; set; }

    }
    public class clsSubClassShortOrderList
    {

        public List<clsSubClassTemplateSortOrder> ShortOrderList { get; set; }
    }
}
