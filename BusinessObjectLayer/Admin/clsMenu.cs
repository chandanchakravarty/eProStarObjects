using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Admin
{
    public class clsMenu
    {
        public string MenuCode { get; set; }
        public string TabId { get; set; }
        public string ParentMenuCode { get; set; }
        public string DisplayTitle { get; set; }
        public string IsMenuItem { get; set; }
        public string LinkAddress { get; set; }
        public string IsHeader { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        //public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
    }
}
