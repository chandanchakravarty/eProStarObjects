using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsUserAccessAssignmentMaster
    {
        public string TxnView { get; set; }
        public string ViewTxn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public string UserLoginId { get; set; }
        public int TeamId { get; set; }
        public string Team { get; set; }
        public int UserLevelId { get; set; }
        public string LoggedIn_UserName { get; set; }

    }
}
