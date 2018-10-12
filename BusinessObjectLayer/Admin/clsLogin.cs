using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Admin
{
    public class clsLogin
    {
        public int UserId { get; set; }
        public string UserLoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserSessionId { get; set; }
        public string IPAddress { get; set; }
    }
}
