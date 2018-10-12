using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.AccountModule
{
    public class clsDirectInsurerPayment
    {
        public string JournalNo { get; set; }
        public string JournalDate { get; set; }
        public string JournalTypeCode { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ClientAdd1 { get; set; }
        public string ClientAdd2 { get; set; }
        public string ClientAdd3 { get; set; }
        public string ClientAdd4 { get; set; }
        public decimal LocalAmount { get; set; }
        public string StmtDesc { get; set; }
        public string JournalDesc { get; set; }
        public int UserId { get; set; }
        public string JournalSource { get; set; }
        public string JournalInsurerDate { get; set; }
        public decimal InsurerAmount { get; set; }
        public string InsurerCurrency { get; set; }
        public string InsurerBankName { get; set; }
        public string InsurerTypeCode { get; set; }
        public string InsurerCode { get; set; }
        public string InsurerName { get; set; }
        public string IsPayment { get; set; }
        public string AccMonth { get; set; }
        public BrokingModule.BrokingAdmin.AuditLog_HeaderMaster AuditLogHeader { get; set; }
        public string Status { get; set; }
    }
    public class clsBankPayment
    {
        public string PaymentNo { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentTypeCode { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ClientAdd1 { get; set; }
        public string ClientAdd2 { get; set; }
        public string ClientAdd3 { get; set; }
        public string ClientAdd4 { get; set; }
        public decimal LocalAmount { get; set; }
        public string StmtDesc { get; set; }
        public string RecptDesc { get; set; }
        public int UserId { get; set; }
        public string PaymentSource { get; set; }
        public string AccMonth { get; set; }
    }

    public class clsNonTradeForPayment
    {
        public int TranNo { get; set; }
        public string PaymentNo { get; set; }
        public string GLCode { get; set; }
        public decimal DBAmountP { get; set; }
        public decimal DBGSTAmount { get; set; }
        public decimal DBAmount { get; set; }
        public decimal CRAmountP { get; set; }
        public decimal CRGSTAmount { get; set; }
        public decimal CRAmount { get; set; }
        public decimal DebitAmtPFC { get; set; }
        public decimal CreditAmtPFC { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public string GlTranDesc { get; set; }
        public string DebitGSTType { get; set; }
        public string CreditGSTType { get; set; }
        public int UserId { get; set; }
        public decimal GSTType { get; set; }
        public decimal DBWhtAmt { get; set; }
        public decimal CRWhtAmt { get; set; }
        public decimal DBWhtP { get; set; }
        public decimal CRWhtP { get; set; }

        public string ProfitCenter { get; set; }
        public string FundCode { get; set; }

    }

    public class clsCompanyDetails
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAdd1 { get; set; }
        public string CompanyAdd2 { get; set; }
        public string CompanyAdd3 { get; set; }
        public string CompanyAdd4 { get; set; }
        public string EMail { get; set; }
        public string CompanyGstCode { get; set; }
        public int MonthStart { get; set; }
        public int YearStart { get; set; }
        public int CalMonthStart { get; set; }
        public int CalYearStart { get; set; }
        public string CompanyUnmatchedAmountLimit { get; set; }
        public int StmtAgDtType { get; set; }
        public string OperatingBank { get; set; }
        public string OfficeBank { get; set; }
        public string RIOperatingBank { get; set; }
        public string RIOfficeBank { get; set; }
        public string BusinessRegNo { get; set; }
        public string UserId { get; set; }
        public string LocalCurrency { get; set; }
        public string IsAutoPosting { get; set; }
        public bool? DeferredRevRule { get; set; }
        public string GLCode { get; set; }
    }

    public class clsGSTCodeSetting
    {
        public string GstTaxCode { get; set; }
        public string GstTaxCodeNew { get; set; }
        public string GSTDescription { get; set; }
        public string GSTTypeCode { get; set; }
        public string Userid { get; set; }
        public string AddEditMode { get; set; }
        public string TranNo { get; set; }
        public string TaxObject { get; set; }
        public string RangeFrom { get; set; }
        public string RangeTo { get; set; }
        public string GSTRateValue { get; set; }
        public decimal TaxRate { get; set; }
        public string TaxType { get; set; }
    }

    public class clsCurrency
    {
        public string CurrencyCode { get; set; }
        public string CurrencyDispCode { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string IsDefault { get; set; }

    }

    public class clsGLCLass
    {
        public int Mode { get; set; }
        public string GLClassCode { get; set; }
        public string GLTypeCode { get; set; }
        public string GLAccountType { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string GLClassOrder { get; set; }

    }

    public class clsGLType
    {
        public int Mode { get; set; }
        public string GLTypeCode { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

    }

    public class clsGLCategory
    {
        public int Mode { get; set; }
        public string GLCategoryCode { get; set; }
        public string GLClassCode { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string GLparentId { get; set; }
        public string SubCategory { get; set; }

    }

    public class clsNonTradeCustomer
    {
        public int PageMode { get; set; }
        public string CusM_ID { get; set; }
        public string CusM_Name1 { get; set; }
        public string CusM_DispName { get; set; }
        public string CusM_Country { get; set; }
        public string CusM_PostalCode { get; set; }
        public string CusM_ContactTelOffice { get; set; }
        public string CusM_ContactTelHome { get; set; }
        public string CusM_ContactPager { get; set; }
        public string CusM_ContactHP { get; set; }
        public string CusM_ContactPerson { get; set; }
        public string CusM_Fax { get; set; }
        public string CusM_ContactEmail { get; set; }
        public string CusM_Remarks { get; set; }
        public string CusM_Address1 { get; set; }
        public string CusM_Address2 { get; set; }
        public string CusM_Address3 { get; set; }
        public string CusM_Address4 { get; set; }
        public decimal Credit_Limit { get; set; }
        public string GLCode { get; set; }
        public string GSTRegistrationNo { get; set; }
        public string SelfBilling { get; set; }
        public string RMCDApprovalNo { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffectiveToDate { get; set; }
        public string UserId { get; set; }
        public string PreviousCode { set; get; }

        //Added by Shikha 12903
        public int CorporateGroup { get; set; }
        public int Region { get; set; }
        public int Branch { get; set; }
        public int ProfitCentre { get; set; }
        public string FundCode { get; set; }
        public string IsActive { get; set; }
    }
    public class clsBatchPost
    {
        public string TranType { get; set; }
        public string TranRefNo { get; set; }
        public string AccountType { get; set; }
        public string ClientName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string SortBy { get; set; }
        public string SortType { get; set; }
        public string PostedStatus { get; set; }
    }
   

    public class clsMonthClosing
    {
        public string GLMonth { get; set; }
        public string GLYear { get; set; }
        public string BrokModule { get; set; }
        public string RIBrokModule { get; set; }
        public string AccModule { get; set; }
        public string JournalModule { get; set; }
        public int userId { get; set; }

    }
   
    public class clsTemplate
    {
        public int Mode { get; set; }
        public string TempId { get; set; }
        public string TemplateType { get; set; }
        public string TemplateName { get; set; }
        public string TempDesc { get; set; }
        public int UserId { get; set; }

        public string TempColType { get; set; }
        public string RowOrder { get; set; }
        public string ColHeading { get; set; }
        public string ColAttributes { get; set; }
        public string GLClassCode { get; set; }
        public string TotalSign { get; set; }

    }

    public class clsAccountClosing
    {
        public int counter { get; set; }
        public int query { get; set; }
        public string Id { get; set; }
        public string MonthYear { get; set; }
        public string FromdateBroking { get; set; }
        public string ToDateBroking { get; set; }
        public string statusBroking { get; set; }
        public string BrokingMode { get; set; }
        public string FromdateRIBroking { get; set; }
        public string ToDateRIBroking { get; set; }
        public string statusRIBroking { get; set; }
        public string BrokingRIMode { get; set; }
        public string FromdateAccounts { get; set; }
        public string ToDateAccounts { get; set; }
        public string statusAccounts { get; set; }
        public string AccountMode { get; set; }
        public string FromdateJournal { get; set; }
        public string ToDateJournal { get; set; }
        public string statusJournal { get; set; }
        public string JournalMode { get; set; }

        public int pGLMonth { get; set; }
        public int pGLYear { get; set; }
        public string pGLMonthN { get; set; }
        public string BrokModule { get; set; }
        public string RIBrokModule { get; set; }
        public string AccModule { get; set; }
        public string JournalModule { get; set; }

        public int UserId { get; set; }

    }

    public class clsNonTradeCreditNote
    {
        public int TranNo { get; set; }
        public string DrCrNo { get; set; }
        public string GLCode { get; set; }
        public decimal DBAmountP { get; set; }
        public decimal DBGSTAmount { get; set; }
        public decimal DBAmount { get; set; }
        public decimal CRAmountP { get; set; }
        public decimal CRGSTAmount { get; set; }
        public decimal CRAmount { get; set; }
        public int UserId { get; set; }
        public string DBGSTType { get; set; }
        public string CRGSTType { get; set; }
        public string GLDesc { get; set; }
        public decimal DBWhtAmt { get; set; }
        public decimal CRWhtAmt { get; set; }
        public decimal DBWhtP { get; set; }
        public decimal CRWhtP { get; set; }


        public string CreditNoteNo { get; set; }
        public string CreditNoteDate { get; set; }
        public string CusM_Id { get; set; }
        public string CusM_Name { get; set; }
        public string CusM_Add1 { get; set; }
        public string CusM_Add2 { get; set; }
        public string CusM_Add3 { get; set; }
        public string CusM_Add4 { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchRate { get; set; }
        public decimal LocalAmount { get; set; }
        public string StmtDesc { get; set; }
        public string DrCrDesc { get; set; }
        public string AccMonth { get; set; }


    }

    public class clsReciept
    {

        public string ReceiptNo { get; set; }
        public string ReceiptDate { get; set; }
        public string ReceiptTypeCode { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ClientAdd1 { get; set; }
        public string ClientAdd2 { get; set; }
        public string ClientAdd3 { get; set; }
        public string ClientAdd4 { get; set; }
        public decimal LocalAmount { get; set; }
        public string StmtDesc { get; set; }
        public string RecptDesc { get; set; }
        public int UserId { get; set; }
        public string ReceiptSource { get; set; }
        public string Accdate { get; set; }
        public string Status { get; set; }

        public int TranNo { get; set; }
        public string BankCode { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeDate { get; set; }
        public string ClearDate { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }

        public string PCCode { get; set; }
        public string PCDate { get; set; }

        public string GLCode { get; set; }
        public decimal DBAmount { get; set; }
        public decimal CRAmount { get; set; }
        public decimal DBAmountP { get; set; }
        public decimal DBGSTAmount { get; set; }
        public decimal CRAmountP { get; set; }
        public decimal CRGSTAmount { get; set; }
        public decimal DebitAmtPFC { get; set; }
        public decimal CreditAmtPFC { get; set; }
        public string GlTranDesc { get; set; }
        public string DebitGSTType { get; set; }
        public string CreditGSTType { get; set; }
        public string DBGstCode { get; set; }
        public string CRGstCode { get; set; }
        public decimal DBWhtAmt { get; set; }
        public decimal CRWhtAmt { get; set; }
        public decimal DBWhtP { get; set; }
        public decimal CRWhtP { get; set; }

        public string ProfitCenter { get; set; }
        public string FundCode { get; set; }
        public BrokingModule.BrokingAdmin.AuditLog_HeaderMaster AuditLogHeader { get; set; }
    }
    public class clsPayment
    {
        public string PaymentNo { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentTypeCode { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ClientAdd1 { get; set; }
        public string ClientAdd2 { get; set; }
        public string ClientAdd3 { get; set; }
        public string ClientAdd4 { get; set; }
        public decimal LocalAmount { get; set; }
        public string StmtDesc { get; set; }
        public string RecptDesc { get; set; }
        public int UserId { get; set; }
        public string PaymentSource { get; set; }
        public string AccMonth { get; set; }
        public string Status { get; set; }
        public BrokingModule.BrokingAdmin.AuditLog_HeaderMaster AuditLogHeader { get; set; }
    }

    public class clsClaimTimeReport
    {
        public string LossFromDate { get; set; }
        public string LossToDate { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public string MainClass { get; set; }
        public string SubClass { get; set; }
        public string UnderwriterName { get; set; }
        public string ClaimStatus { get; set; }
    }

    public class clsMasterClientEnquiry
    {
        public string ReportType { get; set; }
        public string BillingFrom { get; set; }
        public string BillingTo { get; set; }
        public string InsuredName { get; set; }
        public string InsuredName1 { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string ClientCode { get; set; }
        public string AccountServicer { get; set; }
        public string PolicyNo { get; set; }
        public string Class { get; set; }
        public decimal GrossPremRM { get; set; }
        public decimal BrokerageRM { get; set; }
        public decimal NetPremRM { get; set; }
        public decimal PaidClaimRM { get; set; }
        public decimal OSClaimRM { get; set; }
        public string Product { get; set; }
        public string CoverNoteNo { get; set; }
        public string DebitNoteNo { get; set; }
        public decimal TotalGrossPremRM { get; set; }
        public decimal TotalBrokerageRM { get; set; }
        public decimal TotalNetPremRM { get; set; }
        public decimal TotalPaidClaimRM { get; set; }
        public decimal TotalOSClaimRM { get; set; }
    }


}
