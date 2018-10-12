using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsCompanyList
    {
        public string GrpAccessCd { get; set; }
        public int CompanyId { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
        public int isSelected { get; set; }
        public string Pagemode { get; set; }
    }
    public class clsCompanyGrpList
    {
        public List<clsCompanyList> CompanyList { get; set; }
    }
}
