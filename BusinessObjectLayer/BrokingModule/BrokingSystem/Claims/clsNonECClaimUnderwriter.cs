using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Claims
{
    public class clsNonECClaimUnderwriter
    {
        public string CaseRefNo { get; set; }
        public string ClaimRefNo { get; set; }
        public string ClaimNo { get; set; }
        public string RefNo { get; set; }
        public string UnderWriterCode { get; set; }
        public string UnderWriterName { get; set; }
        public decimal UWShare { get; set; }
        public string UWLastName { get; set; }
        public string UWFirstName { get; set; }
        public string UWTelCC { get; set; }
        public string UWTel { get; set; }
        public string UWFaxCC { get; set; }
        public string UWFax { get; set; }
        public string UWEmail { get; set; }
        public string UserID { get; set; }
    }
}
