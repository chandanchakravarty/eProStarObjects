using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Claims
{
    public class clsNonECClaimDetails
    {
        public string CaseRefNo { get; set; }
        public string ClaimRefNo { get; set; }
        public string ClaimNo { get; set; }
        public string CoverNoteNo { get; set; }
        public string UnderwriterCode { get; set; }
        public string UnderwriterName { get; set; }
        public decimal UWShare { get; set; }
        public string ReportDate { get; set; }
        public string LossDate { get; set; }        
        public string Currency { get; set; }
        public string LossNatureCode { get; set; }
        public string LossNature { get; set; }
        public decimal ClaimAmount { get; set; }
        public string CauseOfLossCode { get; set; }
        public string CauseOfLoss { get; set; }
        public decimal TotalPaid { get; set; }
        public string MotorRegNo { get; set; }
        public decimal AdjusterFee { get; set; }
        public string ThirdPartyDetails { get; set; }
        public decimal Current_OSReserveAmount { get; set; }
        public string LossDetails { get; set; }
        public decimal Total_Incurred { get; set; }
        public string Claim_Status { get; set; }
        public string Claim_StatusDate { get; set; }
        public string PaymentStatus { get; set; }
        public string Alet_AccountHandler { get; set; }
        public string PaymentName { get; set; }
        public string PaymentModeCode { get; set; }
        public string PaymentModeDesc { get; set; }
        public string PaymentRef { get; set; }
        public string ReferenceNo { get; set; }
        public string UserID { get; set; }	

    }
}
