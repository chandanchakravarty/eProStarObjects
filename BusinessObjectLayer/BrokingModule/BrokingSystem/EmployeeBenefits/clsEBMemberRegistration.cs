using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits
{
    public class clsEBMemberRegistration
    {        
        public string CaseRefNo  { get; set; }        
        public string MemberCode{ get; set; }
        public string RefNo { get; set; }
        public string CoverNoteNo{ get; set; }
        public string ClassId { get; set; }
        public string Class{ get; set; }
        public string ClientDate{ get; set; }
        public string ReceivedDate{ get; set; }
        public string PolicyNo{ get; set; }
        public string SendOutDate{ get; set; }
        public string POIFromDate{ get; set; }
        public string POIToDate{ get; set; }
        public string UWDate{ get; set; }
        public string ActivationDate{ get; set; }
        public string CardDispatchDate{ get; set; }
        public string DebitCreditNoteNo{ get; set; }
        public string UwriterCode{ get; set; }
        public string UwriterName{ get; set; }
        public string UwriterBillNo{ get; set; }
        public string CardNo{ get; set; }
        public string AICNo{ get; set; }
        public string CurrentCoverageCode{ get; set; }
        public string CurrentCoverageDescription{ get; set; }
        public string BenefitScheduleCode { get; set; }
        public string BenefitScheduleDesc { get; set; }
        public string PlanCode{ get; set; }
        public string PlanDescription{ get; set; }
        public string AccommodationLevelCode{ get; set; }
        public string AccommodationLevelDesc{ get; set; }
        public string EffectiveDate{ get; set; }
        public string ExpiryDate { get; set; }
        public string UserID { get; set; }

        public string MMParam { get; set; }
        public string EN_Remarks { get; set; }
        public string EN_EffectiveDate { get; set; }
        public string EN_AdjustmentRepNo { get; set; }
        public string EN_DateFromClient { get; set; }
        public string EN_AdjRepFromUW { get; set; }
        public string EN_DateToUW { get; set; }
        public string EN_AdjRepToCL { get; set; }
        public string EN_CardNo { get; set; }
        public string EN_CardDisDate { get; set; }
        public string EN_RefNo { get; set; }
        public string EmploymentDate { get; set; }
        public long MemberMovementId { get; set; }
        public string IsDependent { get; set; }
    }
}
