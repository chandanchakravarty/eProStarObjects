using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.AnalysisCode
{
    public class SA_Class
    {
        public Int32 ClassId { get; set; }
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        public string BusinessType { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate2 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate2 { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public bool CStatus { get; set; }
        public string PageMethod { get; set; }
        public string CoverageToInclude { get; set; }
        public string PrmWarranty { get; set; }
        public string GST { get; set; }
        public string DepartmentORTeam { get; set; }
        public string ClassType { get; set; }
        public string IsPackagePolicy { get; set; }
        public Int32 SubClassId { get; set; }
        public string ClaimFilter{ get; set; }
    }
    public class clsSubClassList
    {
        public List<SA_Class> SubClassList { get; set; }
    }
}
