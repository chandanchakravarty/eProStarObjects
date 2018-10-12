using System;
using System.Collections.Generic;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation
{
    public class clsQuotation
    {
        public string IsEndorse { get; set; }
        public string PolId { get; set; }
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public Int64 PolicyUniqueNo { get; set; }
        public string UWCode { get; set; }
        public string Product { get; set; }
        public string ModeOfPayment { get; set; }
        public int SecId { get; set; }
        public long SourcePolicyId { get; set; }
        public int SourcePolVersionId { get; set; }
        public string SourcePolicyNo { get; set; }
        public string QuotationNo { get; set; }
        public string PolicyNo { get; set; }

        public int ClientId { get; set; }
        public int MainClassId { get; set; }
        public int SubClassId { get; set; }
        public string SubClassName { get; set; }
        public int BenefitScheduleId { get; set; }
        public string BusinessDesc { get; set; }
        public string Remarks { get; set; }

        public string BusinessType { get; set; }

        //added by kavita on 30th'june//
        public char IsGlobal { get; set; }
        //end//
        public string IsStdBenefitSchedule { get; set; }
        public char RenewalType { get; set; }
        public int PrimaryAccHandler { get; set; }
        public int SecondaryAccHandler { get; set; }
        public char DateType { get; set; }
        public string POIHeader { get; set; }
        public string POIFooter { get; set; }
        public string POIFromDate { get; set; }
        public int POIFromTimeHH { get; set; }
        public int POIFromTimeMM { get; set; }
        public string POIToDate { get; set; }
        public int POIToTimeHH { get; set; }
        public int POIToTimeMM { get; set; }
        public bool POIBothDaysInclude { get; set; }
        public string MaintainPeriodHeader { get; set; }
        public string MaintainPeriodFooter { get; set; }
        public string MaintenancePeriodFromDate { get; set; }
        public int MaintenancePeriodFromDateHH { get; set; }
        public int MaintenancePeriodFromDateMM { get; set; }
        public string MaintenancePeriodToDate { get; set; }
        public int MaintenancePeriodToDateHH { get; set; }
        public int MaintenancePeriodToDateMM { get; set; }
        public bool MaintainPeriodBothDaysInclude { get; set; }
        public int MonthsThereafter { get; set; }
        public string EBPolicyCurrency { get; set; }
        public string EBPremiumCurrency { get; set; }
        public string UWCoinsuranceApplicable { get; set; }
        public string BrokerageType { get; set; }

        //added by kavita on 17 th march//
        public string PolicyType { get; set; }

        //end of line
        //-----cnquotation start ----------- 30th Sep 2011

        public string RefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public string PrevPolicyNo { get; set; }
        public string InsurerDBNote { get; set; }
        public string BillingDate { get; set; }
        public string PremiumRate { get; set; }
        public string FollowupDate { get; set; }
        public string FollowupReason { get; set; }
        public string EndDebitNoteNo { get; set; }
        public string EndBillingDate { get; set; }

        //-----till here------

        public char MultipleBillPayor { get; set; }
        public char Installments { get; set; }
        public int NoOfInstallments { get; set; }
        public char MultipleLocations { get; set; }
        public string BillingRemarks { get; set; }

        public string MultipleBillingInstallmentsRemarks { get; set; }
        public string Currency { get; set; }
        public string SumInsured { get; set; }
        public string Rate { get; set; }
        public string SumInsuredLocalCurr { get; set; }
        public string Multiplier { get; set; }
        public string PremiumLocalCurr { get; set; }

        public string TotalPremium { get; set; }
        public string AdditionalPremium { get; set; }
        public string ClientDiscount { get; set; }
        public string ClientDiscountRate { get; set; }

        public string TotalSurcharge { get; set; }
        public string TotalPremiumSurcharge { get; set; }
        public string SpecialDiscount { get; set; }
        public string SpecialDiscountRate { get; set; }
        public string DueFromClient { get; set; }
        public string HandlingFeePercent { get; set; }
        public string HandlingFeeAmount { get; set; }

        public string UWTotalShare { get; set; }
        public string UWTotalSharedPremium { get; set; }
        public string UWTotalBrokerage { get; set; }
        public string UWTotalFees { get; set; }

        public int BaseDay { get; set; }
        public int TotalDay { get; set; }

        public string ProRataPremium { get; set; }
        public string ProRataCurrency { get; set; }
        public string ProRataAdditionalPremium { get; set; }

        public string ProRataClientDiscount { get; set; }
        public string ProRataTotalSurcharge { get; set; }
        public string ProRataPremiumSurcharge { get; set; }
        public string ProRataSpecialDiscount { get; set; }
        public string ProRataHandlingFeeRate { get; set; }
        public string ProRataHandlingFeeAmount { get; set; }
        public string ProRataDueFromClient { get; set; }
        public int ProRataBaseDay { get; set; }
        public int ProRataTotalDay { get; set; }

        public string ProRataUWTotalShare { get; set; }
        public string ProRataUWTotalSharedPremium { get; set; }
        public string ProRataUWTotalBrokerage { get; set; }
        public string ProRataUWTotalFees { get; set; }

        public bool IsComplete { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
        public string LastInactivedDate { get; set; }

        public int CompanyId { get; set; } // added by anshul
        public int BranchID { get; set; }  // added by anshul
        public int TeamId { get; set; }

        public string Pol_Status { get; set; }

        public string scrfor { get; set; }

        public string EndorsementNo { get; set; }
        public string EndorsementType { get; set; }
        public string EndorsementEffdate { get; set; }
        public string EndorsementRemark { get; set; }
        public string EndorsementCategory { get; set; }   // added for #21705

        public string RenPolStatus { get; set; }
        public int RenewalReasonId { get; set; }
        public long TransLogID { get; set; }
        public long TransLogEndorseID { get; set; }
        public string TblPrimaryKeysValues { get; set; }
        public string MCDFor { get; set; }
        public bool ManualOverwritePremium { get; set; }  //itrack #267
        public string PremiumBase { get; set; }  //itrack #31180
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public string JobTitle { get; set; }
        public string GeneralLineCode { get; set; }
        public string GeneralLineNo { get; set; }
        public string DirectLineCode { get; set; }
        public string DirectLineNo { get; set; }
        public string MobileNoCode { get; set; }
        public string MobileNo { get; set; }
        public string FaxNoCode { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string CorrAddress1 { get; set; }
        public string CorrAddress2 { get; set; }
        public string CorrAddress3 { get; set; }
        public string CorrAddress4 { get; set; } //--New Feild Added
        public string Country { get; set; }

        //Added By Apurva in Designation
        public string Designation { get; set; }
        public int CorporateGroup { get; set; }

        public string PrintedSlipFields { get; set; }
        public string PlanNames { get; set; }

        public int RowId { get; set; }
        public int TableId { get; set; }
        public int ItemId { get; set; }
        public string ItemFor { get; set; }
        public int OrderNo { get; set; }
        public string ItemText { get; set; }
        public string RowType { get; set; }
        public string HeaderCellText { get; set; }
        public string RowCellText { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }

        public int UnderwriterId { get; set; }

        //added by kavita
        public string DateFormat { get; set; }

        //added on 24th augest for adding reinsurence column
        public string IsReinsurance { get; set; }
        public int ReinsurerDetails { get; set; }
        public string RiskDetailsSubClassType { get; set; }
        //added for fronting policy
        public string IsFrontingPolicy { get; set; }
        //added for Divisional Grouping
        public string DivisionalGrouping { get; set; }
        //public string TotalPremiumLAW { get; set; }
        //public string StDutyLAW { get; set; }
        //public string TaxTypeLAW { get; set; }
        //public string TaxLAW { get; set; }
        //public string SpDiscLAW { get; set; }
        //public string WHTPercentLAW { get; set; }
        //public string NetPayLAW { get; set; }
        //public string TaxLawrdb { get; set; }
        public string VessedId { get; set; }
        public string HistoricalData { get; set; }
        public string RiskLocationType { get; set; }
        public string BillingType { get; set; }
        /*Added by Sheepu for redmine 18341 */
        public string IsBillingleadInsurer { get; set; }
        public string IsHOC { get; set; }
        /*Added by Sheepu for redmine 20409 */
        public string InsurerTaxInvoice { get; set; }

        /* Added for redmine 21283*/

        public string PolicyAnniversaryDate { get; set; }

        public int NoOfYears { get; set; }

        /* Added for redmine 21283 */

        //Added for Redmine #21288
        public int SecurityId { get; set; }
        public string Security { get; set; }
        public string SecurityType { get; set; }
        public string Sum_Insured { get; set; }
        public string Share_Percent { get; set; }
        public string Security_Premium { get; set; }
        //Added for Redmine #21288

        //Added for Redmine #23514
        public string PlanType { get; set; }


        /*==== Added for redmine 23512========*/
        public string MasterPolicyNo { get; set; }
        public string ReplacingPolicyNo { get; set; }

        /* added by himanshu for redmine 18065=====*/
        public string PolicyReceivedDate { get; set; }
        public string InsurerTaxInvoiceNumber { get; set; }
        public string PPW_Waive_Status { get; set; }
        public string NewDate { get; set; }
        public string EndrsmntStartDate { get; set; }
        public string EndrsmntEndDate { get; set; }



    }
    public class clsRiskLocationsInterest
    {
        public int PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int LocationId { get; set; }
        public int InterestId { get; set; }
        public string UserId { get; set; }
        public string InterestHeader { get; set; }
        public string InterestDescription { get; set; }
        public string SumInsured { get; set; }
        public string Valuation { get; set; }
        public string Rates { get; set; }
        public string Premium { get; set; }
        public string Remarks { get; set; }

    }
    public class clsInterestInsured
    {
        public int PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int InterestId { get; set; }
        public string InterestDescription { get; set; }
        public string SumInsured { get; set; }
        public string Rates { get; set; }
        public string Premium { get; set; }
        public string Remarks { get; set; }

    }
    public class clsPolicyUnderwriter
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        //public string CoverageToInclude { get; set; }
        public int UWId { get; set; }
        public int InsuredUWId { get; set; }
        public string ID { get; set; }
        public string VesselId { get; set; }
        public bool HoldCover { get; set; }
        public string Shares { get; set; }
        public string Brokerage { get; set; }
        public string Premium { get; set; }
        public string SharedPremium { get; set; }
        public string ClientDiscount { get; set; }
        public string Coinsurance { get; set; }
        public string Surcharge { get; set; }
        public bool Leader { get; set; }
        public bool IsLowtonIH { get; set; }


        public string LeaderFeePercent { get; set; }
        public string LeaderFeeAmount { get; set; }
        public string TotalFee { get; set; }
        public string BrokerageRate { get; set; }
        public string Currency { get; set; }

        public string ProRataPremium { get; set; }
        public string ProrataClientDiscount { get; set; }
        public string ProrataCoinsurance { get; set; }
        public string ProRataBrokerage { get; set; }
        public string ProRataSurcharge { get; set; }
        public string ProRataLeaderFee { get; set; }
        public bool ProRataIsLeader { get; set; }
        public string ProRataCurrency { get; set; }

        public string ProRataShare { get; set; }
        public string ProRataBrokerageRate { get; set; }
        public string ProRataLeaderFeeRate { get; set; }

        public string ProrataTotalFee { get; set; }

        //coinsurance changes

        public string UWCurrency { get; set; }
        public string UWSumInsured { get; set; }
        public string UWSumInsuredLocalCurr { get; set; }
        public string UWRate { get; set; }
        public string UWMultiplier { get; set; }
        public string UWPremiumLocalCurr { get; set; }
        public string UWTotalPremium { get; set; }
        public string UWAdditionalPremium { get; set; }

        public string UWClientDiscountRate { get; set; }
        public string UWClientDiscount { get; set; }
        public string UWSpecialDiscountRate { get; set; }

        public string UWSpecialDiscount { get; set; }

        public string UWTotalSurcharge { get; set; }
        public string UWTotalPremiumSurcharge { get; set; }
        public string UWHandlingFeeRate { get; set; }
        public string UWHandlingFeeAmount { get; set; }

        public string UWDueFromClient { get; set; }
        public string UWProRataCurrency { get; set; }

        public string UWProRataAdditionalPremium { get; set; }

        public string UWProRataClientDiscount { get; set; }
        public string UWProRataTotalSurcharge { get; set; }
        public string UWProRataPremiumSurcharge { get; set; }
        public string UWProRataSpecialDiscount { get; set; }
        public string UWProRataHandlingFeeAmount { get; set; }
        public string UWProRataDueFromClient { get; set; }
        public string UWProRataTotalPremium { get; set; }

        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactCC { get; set; }
        public string ContactNo { get; set; }

        public string User { get; set; }

        //For Lawton Asia
        public string TotalPremiumLAW { get; set; }
        public string StDutyLAW { get; set; }
        public string StDutyLAWAmt { get; set; }
        public string TaxTypeLAW { get; set; }
        public string TaxLAW { get; set; }
        public string SpDiscPerLAW { get; set; }
        public string SpDiscLAW { get; set; }
        public string WHTPercentLAW { get; set; }
        public string WHTAMT { get; set; }
        public string NetPayClient { get; set; }
        public string NetPayLAW { get; set; }
        public string TaxLawrdb { get; set; }
        //public string WHTAmountLAW { get; set; }
        //ForLawton Asia UWGridAnnual
        public string PremiumLaw { get; set; }
        public string UWShare { get; set; }
        public string UWShareAmt { get; set; }
        public string InsurerTaxPerLaw { get; set; }
        public string InsurerTaxLaw { get; set; }
        public string WHTPerLaw { get; set; }
        public string WHTAmt { get; set; }
        public string CommissionPerLaw { get; set; }
        public string CommissionAmtLaw { get; set; }
        public string TAXPerLaw { get; set; }
        public string TAXAmtLaw { get; set; }
        public string WHTPerLaw1 { get; set; }
        public string WHTAmtLaw1 { get; set; }
        public string LeaderFeePercentageLaw { get; set; }
        public string LeaderFeeLaw { get; set; }
        public string TotalFeeLaw { get; set; }
        public string CurrencyLaw { get; set; }

        //added for vessel data
        public string PolicyCharge { get; set; }
        public string InsurerGSTPer { get; set; }
        public string InsurerGSTPerId { get; set; }
        public string InsurerGSTAmount { get; set; }
        public string brokerGST { get; set; }
        public string brokerGSTId { get; set; }
        public string BrokerGSTAmount { get; set; }
        public string ServiceFee { get; set; }
        public string ServiceFeeGSTPer { get; set; }
        public string ServiceFeeGSTPerId { get; set; }
        public string ServiceFeeGSTAmount { get; set; }
        public string StampDuty { get; set; }
        public string BrokerageFee { get; set; }

        //added for BIB Client
        public string DisplayIn { get; set; }
        public string NCDPer { get; set; }
        public string NCDAmount { get; set; }
        public string LoadingByInsurerPer { get; set; }
        public string LoadingByInsurerAmt { get; set; }
        public string DiscountByInsurerPer { get; set; }
        public string DiscountByInsurerAmt { get; set; }
        public string NettPremium { get; set; }
        public string OtherCharges { get; set; }
        
        //Added for BIB Client Grid Binding
        public decimal NCD { get; set; }
        //public decimal NCDAmount { get; set; }
        public decimal LodingByInsurer { get; set; }
        public decimal LodingByInsurerAmount { get; set; }
        public decimal DiscountByInsurer { get; set; }
        public decimal DiscountByInsurerAmount { get; set; }
        //public decimal NettPremium { get; set; }
        public decimal TotalNettPremium { get; set; }
        //public decimal OtherCharges { get; set; }

        public int ServiceFeeType { get; set; }
        public int OtherChargesFeeType { get; set; }
    }

    public class clsPolUWList
    {
        public List<clsPolicyUnderwriter> PolUWList { get; set; }

    }

    public class clsPolInterestInsuredList
    {
        public List<clsInterestInsured> PolIInsList { get; set; }

    }
    public class clsPolicyAgent
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int AgentId { get; set; }
        public int AutoId { get; set; }

        public int UWId { get; set; }

        public string User { get; set; }
        public string id { get; set; }
        public string Currency { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal Totalbrokerage { get; set; }
        public decimal IntroducerShare { get; set; }
        public decimal TotalDue { get; set; }

        public int InstNo { get; set; }
        public decimal InstPercentage { get; set; }

        public string DebitNoteDate { get; set; }
        public string PeriodFrom { get; set; }
        public string PeriodTo { get; set; }

        public string IsEndorsement { get; set; }

    }

    public class clsPolicyIntroducer
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int AgentId { get; set; }
        public string Currency { get; set; }
        public string NettPremium { get; set; }
        public string UWBrokerageAmt { get; set; }
        public string INTFee { get; set; }
        public string INTFeeAmt { get; set; }
        public string INTFeeGST { get; set; }
        public string INTFeeGSTAmt { get; set; }
        public string TotalDueToYou { get; set; }
        public string RiskId { get; set; }
    }

    public class clsPolINTList
    {
        public List<clsPolicyIntroducer> PolINTList { get; set; }

    }

    public class clsCoverageRiskHeader
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public long PolicyUWCovDetailId { get; set; }
        public int BM_TemplateId { get; set; }
        public int HeaderId { get; set; }
        public int ClassId { get; set; }
        public int SubClassId { get; set; }
        public string frmFor { get; set; }
        public int? PrintOrder { get; set; }
        public string MainHeader { get; set; }
        public string TitleDescription { get; set; }
        public string User { get; set; }
        public char ToIncluded { get; set; }
        public string GroupHeader { get; set; }
        public int UWID { get; set; }
        public string HeaderDescription { get; set; }
        public string HeaderFullDescription { get; set; }
        public string TariffReferenceCode { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public int? ConditionType { get; set; }
        public int? ToPrint { get; set; }

    }
    public class clsPolicyUnderwriterPlans
    {
        public int UWPlanId { get; set; }
        public int PolPlanId { get; set; }
        public string PlanName { get; set; }
        public string User { get; set; }
        public string IsStdBSL { get; set; }
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }

    }
    public class clsInCompleteQuotation
    {
        public string POIFromDate { get; set; }
        public string POIEndDate { get; set; }
        public string QuotationNo { get; set; }
        public string CovernoteNo { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string UnderwriterCode { get; set; }
        public string UnderwriterName { get; set; }
        public string UnderwriterShortName { get; set; }
        public string MainClassId { get; set; }
        public string SubClassId { get; set; }
        public string AccountHandler { get; set; }
        public string CreatedBy { get; set; }
        public string IsInc { get; set; }
        public string frmFor { get; set; }
        public string scrFor { get; set; }
        public string Status { get; set; }
        public string Channel { get; set; }

        // added for Endorsement
        public string PolicyNumber { get; set; }
        public string IsHOC { get; set; }
        public string ReferenceNo { get; set; }
        // added for Renewal
        public string RenewalType { get; set; }
        public string RenewalStatus { get; set; }

        //added for EB Renewal Letter
        public string PaymentMode { get; set; }
        public string EBRenewalLetterType { get; set; }

        // Added for Enquiry
        public string EnquiryType { get; set; }
        public string Group { get; set; }
        public string SubGroup { get; set; }
        public string BNC { get; set; }
        public string SourceCode { get; set; }
        public string DebitNoteDateFrom { get; set; }
        public string DebitNoteDateTo { get; set; }

        public string VehicalNo { get; set; }
        public string VehicalName { get; set; }
        public string BillingParty { get; set; }
        public string Location { get; set; }
        public string InsuredPerson { get; set; }

        // added for client type
        public string ClientType { get; set; }
        public string DateFormat { get; set; }
        public string DiaryType { get; set; }
        public int userID { get; set; }

        //added fon 20th April
        public string DivisionalGrouping { get; set; }
        public string KeyAccountmanager { get; set; }
        public string Industrytype { get; set; }

        //added fon 12th may 17632
        public string ProjectTitle { get; set; }
        public string TeamId { get; set; }

        //by himanshu for 18065
        public string SrchPPWStatus { get; set; }
    }
    public class clsEBPolicyUnderwriterPlans
    {
        public int UWPlanPremRateId { get; set; }
        public int BenefitGroupLineID { get; set; }
        public int UWPlanId { get; set; }
        public int PolPlanId { get; set; }
        public string PlanFor { get; set; }
        public string PremRate { get; set; }
        public string NoOfLives { get; set; }
        public string TotalPrem { get; set; }
        public string User { get; set; }
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public string SumInsured { get; set; }
        public string RateBy1000 { get; set; }
    }
    public class clsPolUWPlanPremList
    {
        public List<clsEBPolicyUnderwriterPlans> PolUWPlanPremRate { get; set; }

    }

    public class clsQuotedStatus
    {
        public int QuotedStatusId { get; set; }
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public long PolUWId { get; set; }
        public string RepliedDate { get; set; }
        public string QuotedStatus { get; set; }
        public decimal Rate { get; set; }
        public decimal Premium { get; set; }
        public string Interest { get; set; }
        public decimal SumInsured { get; set; }
        public string QuotedStatusRemarks { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }

        //Added Regarding RM 17851 on 08/23/2017
        public decimal DeductibleExcess { get; set; }
        public decimal Brokerage { get; set; }
    }

    public class clsQuotationUWPreferrence
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public long PolUWId { get; set; }
        public string IsPreferred { get; set; }
        public int PreferrenceOrder { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
    }

    public class clsClientEnquiry
    {
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ClientType { get; set; }
        public string BusinessNatureCode { get; set; }
        public string Group { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public string ForAudit { get; set; }
        public string DateFormat { get; set; }
        public string BusinessType { get; set; }
        public string ClientSource { get; set; }
        public string Corelated { get; set; }
        public string ClientStatus { get; set; }
    }

    public class clsUnderwriterEnquiry
    {
        public string UNCode { get; set; }
        public string UNName { get; set; }
        public string UNShortName { get; set; }
        public string Email { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public string ForAudit { get; set; }
        public string DateFormat { get; set; }
    }

    public class clsCoverNoteEnquiry
    {
        public string POIFrom { get; set; }
        public string POITo { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string MAinClass { get; set; }
        public string SubClass { get; set; }
        public string CoverNoteNo { get; set; }
        public string DateFormat { get; set; }
    }

    public class clsAgentEnquiry
    {
        public string AGCode { get; set; }
        public string AGType { get; set; }
        public string BusinessNatureCode { get; set; }
        public string Group { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        public string ForAudit { get; set; }
        public string DateFormat { get; set; }
        public string AGName { get; set; }

    }

    public class clsBirthdayEnquiry
    {
        public string BDayMonth { get; set; }
        public string Day1 { get; set; }
        public string Month1 { get; set; }
        public string Year1 { get; set; }
        public string Day2 { get; set; }
        public string Month2 { get; set; }
        public string Year2 { get; set; }
        public string DateFormat { get; set; }

    }

    public class clsRiskLocations
    {
        public int PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public string LocationDescription { get; set; }
        public int LocationId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public string UserId { get; set; }
        public string Mode { get; set; }
        public string POIFromDate { get; set; }
        public string POIToDate { get; set; }
        public string InterestId { get; set; }
        public string InterestDescription { get; set; }
        public string MultipleBilling { get; set; }
        public string subClassBilling { get; set; }

    }
    public class clsEngineeringDetails
    {
        public int PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int EngDetailId { get; set; }
        public string JobNo { get; set; }
        public decimal CompensationLimit { get; set; }
        public string ProjLocationDesc { get; set; }
        public string Principal { get; set; }
        public string ContractValue { get; set; }
        public string CommencementDate { get; set; }
        public string CompletionDate { get; set; }
        public int Days { get; set; }
        public string DefLiabilityPeriodFrom { get; set; }
        public string DefLiabilityPeriodTo { get; set; }
        public int DefLiabilityDays { get; set; }
        public decimal PremiumRate { get; set; }
        public decimal Total { get; set; }
        public decimal BalanceLia { get; set; }
        public decimal PremiumRatePer { get; set; }
        public decimal CARBalance { get; set; }
        public decimal Balance { get; set; }
        public string UserId { get; set; }
        public string Mode { get; set; }
        public string LimitOfLiabilty { get; set; }
    }
    public class clsDomesticHelperDet
    {
        public int PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int HelperNameId { get; set; }
        public string HelperName { get; set; }
        public string DateOfBirth { get; set; }
        public string PassportNo { get; set; }
        public string Nationality { get; set; }
        public string PlaceOfEmployment { get; set; }
        public string POIFromDate { get; set; }
        public string POIToDate { get; set; }
        public string UserID { get; set; }
    }

    // Added for Memo tab
    public class clsMemotab
    {
        public int MemoId { get; set; }
        public int PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public string MemoDate { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdatedBy { get; set; }            
        public string IsActive { get; set; }
        public string TranType { get; set; }
        
    }
}


