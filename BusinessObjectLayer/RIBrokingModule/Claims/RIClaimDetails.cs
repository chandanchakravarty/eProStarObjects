using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.Claims
{
    public class RIClaimDetails
    {
        public string ClaimNo { get; set; }
        public string TranRefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public string Description { get; set; }
        public string LocationDescription { get; set; }
        public string LocationID { get; set; }
        public string Location { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }

        public string Movement { get; set; }
        public string CauseCode { get; set; }
        public string Cause { get; set; }
        public string Currency { get; set; }
        public decimal ClaimAmount { get; set; }
        public decimal DeductibleExcess { get; set; }
        public decimal Expenses { get; set; }
        public decimal Recovery { get; set; }
        public decimal ClaimPaid { get; set; }
        public decimal ClaimReserve { get; set; }
        public decimal IncurredClaim { get; set; }
        public string CashCall { get; set; }
        public string Remarks { get; set; }
        public string Comments { get; set; }
        public string TransRefNo { get; set; }

        public string RelClaimNo { get; set; }
        public string LossDetails { get; set; }
        public string DTOfAccident { get; set; }
        public string Occupation { get; set; }
        public decimal MonthlyEarn { get; set; }
        public string CurrencyCode { get; set; }
        public int ServeyorID { get; set; }
        public int LossAdjustID { get; set; }
        public int LawyerID { get; set; }
        public int TPAID { get; set; }
        public int InvestigatorID { get; set; }
        public int InjuryDeathID { get; set; }
        public decimal PermanentDisability { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public decimal CedantLossAmt { get; set; }
        public decimal DeductAmt { get; set; }
        public decimal ExpensesAmt { get; set; }
        public decimal OurClaimResvAmt { get; set; }
        public decimal OurDeductAmt { get; set; }
        public string ClaimDesc { get; set; }
        public decimal OurExpensesAmt { get; set; }
        public decimal OurRecoveryAmt { get; set; }
        public decimal OurClaimPaidAmt { get; set; }
        public decimal IncurredClaimAmt { get; set; }

        public decimal Share { get; set; }
        public decimal ShareClaimResvAmt { get; set; }
        public decimal ShareDeductAmt { get; set; }
        public decimal ShareExpensesAmt { get; set; }
        public decimal ShareRecoveryAmt { get; set; }
        public decimal ShareClaimPaidAmt { get; set; }
        public decimal ShareIncurredClaimAmt { get; set; }
        public string ReInsuCode { get; set; }
        public string ReInsuName { get; set; }
        public string ClaimentName { get; set; }
        public string RefNo { get; set; }
        public string clmDetailsDesc { get; set; }

        public string CedantLossCurr { get; set; }
        public string DeductCurr { get; set; }
        public string ExpensesCurr { get; set; }
        public string OClaimResCurr { get; set; }
        public string ODeductCurr { get; set; }
        public string OExpenCurr { get; set; }
        public string ORecovCurr { get; set; }
        public string OClaimPaidCurr { get; set; }
        public int ClaimShareID { get; set; }


    }
}
