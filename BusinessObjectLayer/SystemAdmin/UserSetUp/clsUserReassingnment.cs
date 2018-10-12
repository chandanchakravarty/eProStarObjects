using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsUserReassingnment
    {
        public int ReassingnmentId { get; set; }
        public string HistFor { get; set; }
        public int CurrentUserId { get; set; }
        public int ReassignUserId { get; set; }
        public string UserList { get; set; }
        public string ReassignfromDate { get; set; }
        public string Reassigntodate { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }
        public string isActive { get; set; }
        public string PolVersionList { get; set; }
        public string HandlerType { get; set; }
    }
}
