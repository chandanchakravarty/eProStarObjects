using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EBClaims
{
    public class clsEBClaimLimit
    {
        public string CaseRefNo { get; set; }
        public string MemberCode { get; set; }
        public string ClaimRefNo { get; set; }
        public string BenefitScheduleRefNo { get; set; }        
        public decimal EntitleAmount { get; set; }
        public decimal IncurredAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal ClaimBalanceAmount { get; set; }
        public decimal ClaimAmount { get; set; }
        public string UserID { get; set; }

       
    }
}
