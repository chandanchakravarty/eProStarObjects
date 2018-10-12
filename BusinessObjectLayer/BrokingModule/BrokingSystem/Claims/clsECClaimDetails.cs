using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Claims
{
    public class clsECClaimDetails
    {
        public string   CaseRefNo	{ get; set; }
        public string   ClaimRefNo	{ get; set; }
        public string   ClaimNo	    { get; set; }
        public string   CoverNoteNo	{ get; set; }
        public string   UnderwriterCode	{ get; set; }
        public string   UnderwriterName	{ get; set; }
        public decimal  UWShare	    { get; set; }
        public string   ReportDate	{ get; set; }
        public string   InjuredName	{ get; set; }
        public string   LossDetails	{ get; set; }
        public string   DateOfBirth	{ get; set; }
        public string   AccidentDate	{ get; set; }
        public int      Age	                { get; set; }
        public decimal  MonthlyEarning	    { get; set; }
        public string   OccupationCode	    { get; set; }
        public string   OccupationDesc      { get; set; }
        public string   Currency	        { get; set; }
        public decimal  TotalPaid	        { get; set; }
        public decimal  AdjusterFee	        { get; set; }
        public decimal  RecoveryAmount	    { get; set; }
        public decimal  Current_OSReserveAmount	{ get; set; }
        public decimal  Total_Incurred	    { get; set; }
        public string   Injury_Death_Code	{ get; set; }
        public string   Injury_Death_Desc	{ get; set; }
        public string   Nature_Injury_Code	{ get; set; }
        public string   Nature_Injury_Desc	{ get; set; }
        public string   Cause_Injury_Code	{ get; set; }
        public string   Cause_Injury_Desc	{ get; set; }
        public string   Body_Injury_Code	{ get; set; }
        public string   Body_Injury_Desc	{ get; set; }
        public decimal  Permanent_Disability	{ get; set; }
        public string   Claim_Status	    { get; set; }
        public string   Claim_StatusDate	{ get; set; }
        public string   PaymentStatus	    { get; set; }
        public string   Alet_AccountHandler	{ get; set; }
        public string   ECC_Count_Case	    { get; set; }
        public string   CommonLawClaim      { get; set; }
        public string   PaymentName	        { get; set; }
        public string   PaymentModeCode	    { get; set; }
        public string   PaymentModeDesc	    { get; set; }
        public string   PaymentRef	        { get; set; }
        public string   ReferenceNo         { get; set; }
        public string   UserID              { get; set; }
        public int Disability_Grade { get; set; }

        //added by Kumar Rituraj--11th May 2015--//
        public string BoxNo { get; set; }
        public string DetailedStatus { get; set; }
        public string LossType { get; set; }
        public string LossNature { get; set; }
        public string ClaimantName { get; set; }
        public string RefNo { get; set; }
        public int LossTypeID { get; set; }
        public int LossNatureID { get; set; }

        //added on 17th nov for LCH(Marine CLaim)
        public string TimeBar { get; set; }
        public string Mortgagee { get; set; }
        public Double SumInsured { get; set; }
        public Double Deductible { get; set; }
        public string DeductibleCollected { get; set; }
      
        //--------------//

        //added on 7th Jul for LawtonAsia (TFS ID - 7531)
        public Double DeductibleAmount { get; set; }
        public string DeductibleType { get; set; }
        //added on 7th july2016 for Accalim
        public string AccidentLocationValue { get; set; }
        public string AccidentLocationText { get; set; }

        //21St Sep, 2016--------------------------
        public string LocationRemarks { get; set; }
        public string VehicleNo { get; set; }
        public string VehicleName { get; set; }
        public decimal ReserveAmount { get; set; }
        public string DateOfDischarge { get; set; }
        public string DateUpdated { get; set; }
        public decimal OutstandingAmount { get; set; }
        public string TypeofHospital { get; set; }
        public decimal Expenses { get; set; }
        public string GMMActivation { get; set; }
        public string ReferralLetter { get; set; }
        public int SubClassId { get; set; }

        public string AddmissionDate { get; set; }
 	    public string HospitalClinicName { get; set; }
        public string PeriodofInsuranceFrom  { get; set; }
        public string PeriodofInsuranceTo { get; set; }
        public string NotificationFromDate { get; set; }
        public string NotificationToDate { get; set; }
        public string InsurerClaimNo { get; set; }
        public string ClientName { get; set; }
        public string Class { get; set; }
        public string Insurer { get; set; }
        public string Ageing { get; set; }
        public string TotalIncured { get; set; }
        public string PolicyNo { get; set; }
        public string PolicyType { get; set; }
        public string ReportType { get; set; }
        public string ClientCode { get; set; }

        public string ClaimantsNRIC { get; set; }
        public string RejectedReason { get; set; }
        public string WithdrawReason { get; set; }
        public string VoidReason { get; set; }
        public string NatureOfInjuryCode { get; set; }
        public string NatureOfLossCode { get; set; }
        public string LocalityOfInjuryCode { get; set; }
        public string NationalityCode { get; set; }
        public string ClaimStatusCode { get; set; }
        public string DateOfReturnToWork { get; set; }
        public string CloseDate { get; set; }
        public string ArchiveDate { get; set; }
        public string ReturnDocDate { get; set; }
        public string RejectedDate { get; set; }
        public string WithdrawDate { get; set; }
        public string VoidDate { get; set; }
        //public string ClaimantsName { get; set; }
    }
}
