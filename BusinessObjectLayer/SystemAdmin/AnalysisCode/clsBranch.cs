using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.AnalysisCode
{
    public class clsBranch
    {
        public Int32 BranchId { get; set; }
        public string AnalysisCategory { get; set; }
        public string BalBF_NRP { get; set; }
        public string CompanyName { get; set; }
        public Int32 CompanyId { get; set; }
        public string Country { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string FaxNoPrefx { get; set; }
        public string FaxNo { get; set; }
        public string TelephoneNoPrefx { get; set; }
        public string TelephoneNo { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string IncludeHeadOffice { get; set; }
    }
}
