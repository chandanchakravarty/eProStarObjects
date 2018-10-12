using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsBroadcastMaster
    {
        public string BroadcastCode { get; set; }
        public string BroadcastTitle { get; set; }
        public string BroadcastEffectiveFromDate { get; set; }
        public string BroadcastEffectiveFromDate2 { get; set; }
        public string BroadcastEffectiveToDate { get; set; }
        public string BroadcastEffectiveToDate2 { get; set; }
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public Int32 BroadCastManagerID { get; set; }

        public string BroadCastRecurringFrequency { get; set; }
        public string BroadCastRecurringDays { get; set; }
        public string BroadCastDescription { get; set; }
        public string BroadCastContent { get; set; }
        public bool BroadCastIsDepartmentSelected { get; set; }
        public string BroadCastSelectedDepartment { get; set; }
        public bool BroadCastIsUserSelected { get; set; }
        public string BroadCastSelectedUser { get; set; }

        
      }
}
