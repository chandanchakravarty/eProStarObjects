using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.Reports
{
    public class clsPolicySlip
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string PrintOrder { get; set; }
        //public string PrintFor { get; set; }
    }

    public class clsPrintSlipData
    {
        public string PrintCompLogo { get; set; }
        public string PrintFor { get; set; }
        public List<clsPolicySlip> lstSlipFields { get; set; }
        public string calledFrom { get; set; }
    }
}
