using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsLedgerSubClass
    {
        public int CompanyId { get; set; }
        public int LedgerClassId { get; set; }
        public int SubClassId { get; set; }
        public string UserId { get; set; }
        public string IsActive { get; set; }
        public int isSelected { get; set; }
    } 
    public class clsClassList
    {
        public List<clsLedgerSubClass> SubClassList{ get; set; }
    
    }
    public class clsParentList
    {

        public List<clsClassList> ClassList { get; set; }
    }
}
