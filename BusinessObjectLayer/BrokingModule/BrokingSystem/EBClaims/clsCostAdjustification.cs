using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EBClaims
{
   public class clsCostAdjustification
    {
        public string CaseRefNo { get; set; }
        public string MemberCode { get; set; }
        public string ClaimRefNo { get; set; }
        public string RefNo { get; set; }
        public string BenefitSchedule { get; set; }
        public string BenefitType { get; set; }
        public string ClaimDate { get; set; }
        public decimal ClaimAmount { get; set; }
        public string PaidDate { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal ExcessAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public string Claim_Date { get; set; }
        public decimal Claim_Amount { get; set; }

        public string PaymentType { get; set; }
        public string PayeeName { get; set; }
        public string ChequeNo { get; set; }
        public string  ChequeDate { get; set; }
        public string BankCode { get; set; }
        public string BankBranch { get; set; }
        public string Bankname { get; set; }
        public string SwiftCode { get; set; }

        public string AccNo { get; set; }
        public string Currency { get; set; }
        public decimal Deductible { get; set; }
        public string CoPayment { get; set; }
        public string BeneficiaryName1 { get; set; }
        public string BeneficiaryName2 { get; set; }
        public string BeneficiaryName3 { get; set; }
        public string Remark { get; set; }
        public int IsActive { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public string ClaimCurrency { get; set; }
        public string PaidCurrency { get; set; }
        
    }
}
