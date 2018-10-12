using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsMasTransfAuthority
    {
       
        public int MassTransfAuthId { get; set; }
        public string HistFor { get; set; }
        public int CurrentUserId { get; set; }
        public int ReassignUserId { get; set; }
        public string EffectivefromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string Effectivetodate { get; set; }
        public string UserId { get; set; }
        public string reassignuserName { get; set; }
        public string isActive { get; set; } 
                 
        
    }
    public class clsUsers
    {
        public int MassTransfAuthId { get; set; }
        public int UserId { get; set; }
        public int isSelected { get; set; }
    }
    public class UsersList
    {
        public List<clsUsers> UserList { get; set; }
    
    }
}
