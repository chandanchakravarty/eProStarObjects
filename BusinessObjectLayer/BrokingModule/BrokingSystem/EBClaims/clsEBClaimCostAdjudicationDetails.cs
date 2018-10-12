using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EBClaims
{
   public  class clsEBClaimCostAdjudicationDetails
    {
        public int CoAdId { set; get; }
        public int ClaimId { set; get; }
        public string ClaimNo { set; get; }
        public int BenefitGroupLineId { set; get; }
        public string BenefitGroupLineName { set; get; }
        public int BenefitLineID { set; get; }
        public string BenefitLineName { set; get; }
        public float PlanLimit { set; get; }
        public float Deductible { set; get; }
        public float IncurredAmount { set; get; }
        public float PaidAmount { set; get; }
        public float GST { set; get; }
        public float Nonpayableitems { set; get; }
        public float Balance { set; get; }
        public string Remarks { set; get; }
        public string CreatedBy { set; get; }
        public string Action { set; get; }

    }
}
