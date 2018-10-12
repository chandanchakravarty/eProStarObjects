using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsGroupAccess
    {
        public string GrpAccessCd { get; set; }
        public string GrpName { get; set; }
        public string GrpDescription { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffFrom2 { get; set; }
        public string EffectiveEndDate { get; set; }
        public string EffectiveEndDate2 { get; set; }
        public string Status { get; set; }
        public string User { get; set; }
        public string PageMethod { get; set; }
        public string IsActive { get; set; }
    }
    public class clsGroupAccessRights
    {
        public int GroupAccessId { get; set; }
        public string GroupAccessCode { get; set; }
        public string MenuCode { get; set; }
        public int ReadAccess { get; set; }
        public int EditAccess { get; set; }
        public int DeleteAccess { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffectiveEndDate { get; set; }
        public string Status { get; set; }
        public string User { get; set; }
        public string PageMethod { get; set; }
        public string IsActive { get; set; }
    }
}
