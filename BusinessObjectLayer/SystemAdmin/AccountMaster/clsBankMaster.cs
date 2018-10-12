using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.AccountMaster
{
    public class clsBankMaster
    {
        public Int32 BankId { get; set; }
        public int CompanyId { get; set; }
        public int CurrencyId { get; set; }
        public string CorresName { get; set; }
        public string CorresAddress { get; set; }
        public string CorresSwiftCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string SwiftCode { get; set; }
        public string InFavourOf { get; set; }
        public string AccountNo { get; set; }
        public string ByOrderOf { get; set; }
        public string Message { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffectiveToDate { get; set; }
        public string User { get; set; }
    }
}
