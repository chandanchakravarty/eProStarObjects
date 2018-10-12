using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.Reports
{
    public class clsPolicySlip
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
    }

    public class clsPrintCNCombinedData
    {
        public string PrintCompLogo { get; set; }
        public string PrintFor { get; set; }
        public List<clsPolicySlip> lstSlipFields { get; set; }
        public string calledFrom { get; set; }
        public string LegislationNote { get; set; }
    }

}
