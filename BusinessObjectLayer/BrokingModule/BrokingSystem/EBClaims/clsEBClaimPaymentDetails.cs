using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EBClaims
{
   public  class clsEBClaimPaymentDetails
    {
        public int PaymentId { set; get; }
        public int ClaimId { set; get; }
        public string ClaimNo { set; get; }
        public int PaymentRowId { set; get; }
        public int ProductTypeId { set; get; }
        public string ProductType { set; get; }
        public string PaymentTo { set; get; }
        public string PaymentMethod { set; get; }
        public string Cheque_GIRODetails { set; get; }
        public string DateReceived { set; get; }
        public string DateSent { set; get; }
        public double CashAmount { set; get; }
        public double MedisaveAmount { set; get; }
        public double HospitalAmount { set; get; }
        public double ShieldPlanAmount { set; get; }
        public double TotalReimbursementAmount { set; get; }
        public double CashAllowance { set; get; }
        public string Remarks { set; get; }
        public string Action { set; get; }
        public string Others { set; get; }
        public string CreatedBy { set; get; }
        public string CreatedDate { set; get; }
        public string LastUpdatedBy { set; get; }
        public string LastUpdatedDate { set; get; }

    }
}
