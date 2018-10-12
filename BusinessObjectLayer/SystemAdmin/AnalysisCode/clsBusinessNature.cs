using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.AnalysisCode
{
    public class clsBusinessNature
    {
        public Int32 BusinessNatureID { get; set; }
        public string AnalysisCategory { get; set; }
        public string BalBF_NRP { get; set; }
        public string BusinessNatureCode { get; set; }
        public string BusinessNatureDescription { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
    }
}
