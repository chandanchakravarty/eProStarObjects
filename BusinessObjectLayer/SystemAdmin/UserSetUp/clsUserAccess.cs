using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsUserAccess
    {
        public int UserAccessId { get; set; }
        public int UserId { get; set; }
        public string MenuCode { get; set; }
        public int ReadAccess { get; set; }
        public int EditAccess { get; set; }
        public int DeleteAccess { get; set; }
        public int isSelected { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
    }
    public class UserAccssList
    {

        public List<clsUserAccess> AccessList { get; set; }
    }
}
