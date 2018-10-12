using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits
{
    public class clsEBMemberPayment
    {
        public string CaseRefNo	{ get; set; }
        public string MemberCode	{ get; set; }
        public string PaymentModeCode	{ get; set; }
        public string PaymentModeDesc	{ get; set; }
        public string BankAccountName	{ get; set; }
        public string BankName	{ get; set; }
        public string BankCode	{ get; set; }
        public string BranchName	{ get; set; }
        public string BranchCode	{ get; set; }
        public string BankDetails	{ get; set; }
        public string BankAccountNo	{ get; set; }
        public string EffectiveDate	{ get; set; }
        public string UserID { get; set; }	
    }
}
