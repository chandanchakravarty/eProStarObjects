using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Claims
{
    public class clsECClaimPayment
    {
        public string CaseRefNo { get; set; }
        public string ClaimRefNo { get; set; }
        public string RefNo { get; set; }
        public string PaymentDate { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaymentType { get; set; }
        public decimal RecoverAmount { get; set; }
        public decimal ReserveAmount { get; set; }
        public decimal OSReserveAmount { get; set; }
        public string Remarks { get; set; }
        public string UserID { get; set; }
        //Added By Kumar Rituraj On 29th April 2015 for lawton
        public string ChequeNo { get; set; }
        public string BankName { get; set; }

        //21St Sep, 2016--------------------------
        public decimal TotalIncurredClaim { get; set; }
        public string PaymentCurrency { get; set; }
        public decimal AmountOutstanding { get; set; }
    }
}
