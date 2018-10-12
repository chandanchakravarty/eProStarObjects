using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EBClaims
{
    public class clsEBClaimBenefitScheduleDetails
    {
        public string CaseRefNo { get; set; }
        public string MemberCode { get; set; }
        public string ClaimRefNo { get; set; }        
        public string BenefitScheduleRefNo{ get; set; }
        public string BenefitScheduleCode{ get; set; }
        public string BenefitScheduleDescription{ get; set; }
        public decimal EntitleAmount{ get; set; }
        public decimal IncurredAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal ClaimBalanceAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal ClaimAmount { get; set; }
        public string UserID { get; set; }

        public decimal TotalEntitleAmount { get; set; }
        public decimal TotalIncurredAmount { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal TotalClaimBalanceAmount { get; set; }
        public decimal TotalBalanceAmount { get; set; }
        public decimal TotalClaimAmount { get; set; }
        public string PaidDate { get; set; }
        public decimal ShortfallAmount { get; set; }
    }
}
