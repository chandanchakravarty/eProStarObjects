using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.Reports
{
    public class clsProductionReport
    {
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public string CreatedDateFrom { get; set; }
        public string CreatedDateTo { get; set; }
        public string ModifyDateFrom { get; set; }
        public string ModifyDateTo { get; set; }
        public string DocumentDateFrom { get; set; }
        public string DocumentDateTo { get; set; }
        public string DocumentType { get; set; }

        public string Company { get; set; }
        public string MainClass { get; set; }
        public string SubClassCode { get; set; }
        public int CompanyId { get; set; }
    }

}
