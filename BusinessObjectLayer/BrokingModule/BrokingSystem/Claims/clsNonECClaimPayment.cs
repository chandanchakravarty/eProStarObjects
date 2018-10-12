using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Claims
{
    public class clsNonECClaimPayment
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
    }
}
