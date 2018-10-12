using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsEmailGroupMaster
    {
        public int EmailGroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDesc { get; set; }
        public string DefEmailGroup { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public string PageMethod { get; set; }
        public string IsActive { get; set; }

        public string UserId { get; set; }
        public char IsChecked { get; set; }
    }
}
