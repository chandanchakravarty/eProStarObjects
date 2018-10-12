using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Claims
{
    //Created By Kumar Rituraj On 29th April 2015 for lawton
   public class ClsECClaimFeeSettlement
    {
        public string CaseRefNo { get; set; }
        public string ClaimRefNo { get; set; }
        public string RefNo { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentType { get; set; }
        public decimal AdjusterFee { get; set; }
        public decimal SurveyorFee { get; set; }
        public decimal LegalFee { get; set; }
        public string Remarks { get; set; }
        public string ChequeNo { get; set; }
        public string BankName { get; set; }
        public string UserID { get; set; }
        
        
    }
}
