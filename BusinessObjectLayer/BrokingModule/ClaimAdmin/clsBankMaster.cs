using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.ClaimAdmin
{
    public class clsBankMaster
    {
        public int BankId { get; set; }
        public string  BankCode { get; set; }
        public string  BankName { get; set; }
        public string EffectivefromDate { get; set; }
        public string Effectivetodate { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
    }
}
