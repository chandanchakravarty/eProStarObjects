using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Web;
using EtrekReports.text;
using EtrekReports.text.pdf;
using Utility.PDFGenerator;
using Utility;
using BusinessAccessLayer.Common;
using BusinessAccessLayer.BrokingModule.BrokingSystem;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessObjectLayer.RIBrokingModule.RIBrokingSystem;
using BusinessAccessLayer.RIBrokingModule.RIBrokingSystem;

namespace BusinessAccessLayer.Common
{
    public class RequestApprovalPDFGenerator : PDFGeneratorBase
    {
        protected PDFGeneratorEvents ereEvents = null;
        protected Cell clCurrCell = null;
        private string strText = "";
        private new Font fontNote = null;
        private new Font fontNoteUnderline = null;
        private new Font fontDocContent = null;
        private new Font fontDocContentBold = null;
        private new Font fontDocHdrBold = null;
        private new Font fontDocContentNote = null;
        private Font fontSmallNote = null;
        private Font fontSmallNoteBold = null;
        private Font fontMini = null;
        private Font fontConstantNote = null;
        private Font fontConstantMiddleNote = null;
        private Font fontConstantSmallNote = null;

        DataSet dsAgent = null;
        DataSet dsClient = null;
        DataSet dsUnderwriter = null;
        DataSet dsReinsurer = null;
        DataSet dsCedant = null;
        DataSet dsPriorityContact = null;
        clsCommon objcommon = new clsCommon();
        AgentRequestManager objAgentBal = null;
        clsClientManager objClientBAL = null;
        clsUnderwriterManager objUWBAL = null;
        clsReinsurerManager objReinsuerBAL = null;

        protected string forpage = "";
        protected int RecId;

        protected string Code = "";
        protected string Name = "";
        protected string ChName = "";
        protected string CorrAddress1 = "";
        protected string CorrAddress2 = "";
        protected string CorrAddress3 = "";
        protected string CorrAddress4 = "";
        
        protected string ChineseCorrAddress1 = "";
        protected string ChineseCorrAddress2 = "";
        protected string ChineseCorrAddress3 = "";
        protected string ChineseCorrAddress4 = "";
        
        protected string Country = "";
        protected string ChineseCountry = "";
        protected string ChCountry = "";

        protected string CorrSubDistrict = "";
        protected string CorrChSubDistrict = "";
        protected string CorrCity = "";
        protected string CorrChCity = "";
        protected string CorrProvince = "";
        protected string CorrChProvince = "";
        protected string CorrPostalCode = "";
        protected string CorrChPostalCode = "";

        protected string BillSubDistrict = "";
        protected string BillChSubDistrict = "";
        protected string BillCity = "";
        protected string BillChCity = "";
        protected string BillProvince = "";
        protected string BillChProvince = "";
        protected string BillPostalCode = "";
        protected string BillChPostalCode = "";
        protected string VIPType = "";

        protected string BillingAddress1 = "";
        protected string BillingAddress2 = "";
        protected string BillingAddress3 = "";
        protected string BillingAddress4 = "";
        protected string ChineseBillingAddress1 = "";
        protected string ChineseBillingAddress2 = "";
        protected string ChineseBillingAddress3 = "";
        protected string ChineseBillingAddress4 = "";
        protected string BillingCountry = "";
        protected string ChineseBillingCountry = "";
        protected string Description = "";
        protected string GeneralLineCode = "";
        protected string GeneralLineNo = "";
        protected string Nationality = "";
        protected string passportno = "";
        protected string RecordType = "";
        protected string ClientType = "";
        protected string Gender = "";
        protected string ddlRecordType = "";
        protected string FaxCode = "";
        protected string FaxNo = "";
        protected string CompRegistrationNo = "";
        protected string RegDate = "";
        protected string BusiRegistrationNo = "";
        protected string Email = "";
        protected string CreditLimit = "";
        protected string CreditTerms = "";
        protected string CreditOption = "";
        protected string CreditMonths = "";
        protected string CreditString = "";
        protected string AccountType = "";
        protected string NormalBal = "";
        protected string CreditControlAC = "";
        protected string Remarks = "";
        protected string SameCorrAddress = "";
        protected string SameChCorrAddress = "";
        protected string PaymentEffectiveFrom = "";
        protected string PaymentEffectiveTo = "";
        protected bool ChkJan = false;
        protected bool ChkFeb = false;
        protected bool ChkMar = false;
        protected bool ChkApr = false;
        protected bool ChkMay = false;
        protected bool ChkJun = false;
        protected bool ChkJul = false;
        protected bool ChkAug = false;
        protected bool ChkSep = false;
        protected bool ChkOct = false;
        protected bool ChkNov = false;
        protected bool ChkDec = false;
        protected string EffectiveFromDate = "";
        protected string EffectiveToDate = "";
        protected string Premium_settlement = "";
        protected bool Notification = false;
        protected string day = "";
        protected string month = "";
        protected string year = "";
        protected string maritalstatus = "";
        protected string occupation = "";
        protected string sourceOfBusiness = "";
        protected string MasterSourceCode = "";
        protected string subsidiarySourceCode1 = "";
        protected string subsidiarySourceCode2 = "";
        protected string sourceCodeMaster = "";
        protected string group = "";
        protected string subGroup = "";
        protected string BusinessNatureCode = "";

        protected string ClaimAccType = "";
        protected string ClaimNormalBal = "";
        protected string ClaimDebitAcc = "";
        //Priority Contact Detail
        protected string PriorityTeam = "";
        protected string PriorityChineseCorrAddress1 = "";
        protected string PriorityChineseCorrAddress2 = "";
        protected string PriorityChineseCorrAddress3 = "";
        protected string PriorityChineseCorrAddress4 = "";
        
        protected string PriorityChineseCountry = "";
        protected string PriorityChineseDept = "";
        protected string PriorityChineseFirstName = "";
        protected string PriorityChineseJobTitle = "";
        protected string PriorityChineseLastName = "";
        protected string PriorityCorrAddress1 = "";
        protected string PriorityCorrAddress2 = "";
        protected string PriorityCorrAddress3 = "";
        protected string PriorityCorrAddress4 = "";
        
        protected string PriorityCountry = "";


        protected string PrioritySubDistrict = "";
        protected string PriorityChSubDistrict = "";
        protected string PriorityCity = "";
        protected string PriorityChCity = "";
        protected string PriorityProvince = "";
        protected string PriorityChProvince = "";
        protected string PriorityPostalCode = "";
        protected string PriorityChPostalCode = "";

        protected string PriorityDept = "";
        protected string PriorityDirectLineCode = "";
        protected string PriorityDirectLineNo = "";
        protected string PriorityEffectiveFromDate = "";
        protected string PriorityEffectiveToDate = "";
        protected string PriorityEmail = "";
        protected string PriorityExtension = "";
        protected string PriorityFaxCode = "";
        protected string PriorityFaxNo = "";
        protected string PriorityFirstName = "";
        protected string PriorityGeneralLineCode = "";
        protected string PriorityGeneralLineNo = "";
        protected string PriorityJobTitle = "";
        protected string PriorityLastName = "";
        protected string PriorityMobileCode = "";
        protected string PriorityMobileNo = "";
        protected string PrioritySalutation = "";
        protected string PriorityChSalutation = "";
        //Approval Detail
        protected string Level1ApprovedBy = "";
        protected string Level1ApprovedDate = "";
        protected string Level1ApprovedTime = "";
        protected string Level2ApprovedBy = "";
        protected string Level2ApprovedDate = "";
        protected string Level2ApprovedTime = "";
        protected string Level3ApprovedBy = "";
        protected string Level3ApprovedDate = "";
        protected string Level3ApprovedTime = "";
        protected string AdminApprovedBy = "";
        protected string AdminApprovedDate = "";
        protected string AdminApprovedTime = "";
        //TimeStamp Detail
        protected string CreatedBy = "";
        protected string UpdatedBy = "";
        protected string CreatedDate = "";
        protected string UpdatedDate = "";
        protected string CreatedTime = "";
        protected string UpdatedTime = "";
        private string IsChineseRequired = "";

        public RequestApprovalPDFGenerator(string isChineseRequired)
        {
            //
            // TODO: Add constructor logic here
            //                       
            fontDocHdrBold = FontFactory.GetFont("Arial", 15, Font.NORMAL);
            fontNote = FontFactory.GetFont(FontFactory.COURIER, 9, Font.NORMAL);
            fontNoteUnderline = FontFactory.GetFont("Arial", 9, Font.UNDERLINE);
            fontDocContent = FontFactory.GetFont("Arial", 10, Font.NORMAL);
            fontDocContentNote = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            fontDocContentBold = FontFactory.GetFont("Arial", 10, Font.NORMAL);
            fontSmallNote = FontFactory.GetFont(FontFactory.COURIER, 7, Font.NORMAL);
            fontSmallNoteBold = FontFactory.GetFont(FontFactory.COURIER, 7, Font.NORMAL);
            fontMini = FontFactory.GetFont("Arial", 5, Font.NORMAL);
            fontConstantNote = FontFactory.GetFont("Arial", 9, Font.NORMAL);
            fontConstantMiddleNote = FontFactory.GetFont("Arial", 9, Font.NORMAL);
            fontConstantSmallNote = FontFactory.GetFont("Arial", 8, Font.NORMAL);
            this.IsChineseRequired = isChineseRequired;
        }

        public RequestApprovalPDFGenerator()
        {
            //
            // TODO: Add constructor logic here
            //                       
            fontDocHdrBold = FontFactory.GetFont("Arial", 15, Font.NORMAL);
            fontNote = FontFactory.GetFont(FontFactory.COURIER, 9, Font.NORMAL);
            fontNoteUnderline = FontFactory.GetFont("Arial", 9, Font.UNDERLINE);
            fontDocContent = FontFactory.GetFont("Arial", 10, Font.NORMAL);
            fontDocContentNote = FontFactory.GetFont("Arial", 12, Font.NORMAL);
            fontDocContentBold = FontFactory.GetFont("Arial", 10, Font.NORMAL);
            fontSmallNote = FontFactory.GetFont(FontFactory.COURIER, 7, Font.NORMAL);
            fontSmallNoteBold = FontFactory.GetFont(FontFactory.COURIER, 7, Font.NORMAL);
            fontMini = FontFactory.GetFont("Arial", 5, Font.NORMAL);
            fontConstantNote = FontFactory.GetFont("Arial", 9, Font.NORMAL);
            fontConstantMiddleNote = FontFactory.GetFont("Arial", 9, Font.NORMAL);
            fontConstantSmallNote = FontFactory.GetFont("Arial", 8, Font.NORMAL);            
        }
        public void GetApprovalDetails(DataTable dt)
        {
            try
            {

                Level1ApprovedBy = dt.Rows[0]["Level1ApprovedBy"].ToString();
                Level1ApprovedDate = dt.Rows[0]["Level1ApprovedDate"].ToString();
                Level1ApprovedTime = dt.Rows[0]["Level1ApprovedTime"].ToString();
                Level2ApprovedBy = dt.Rows[0]["Level2ApprovedBy"].ToString();
                Level2ApprovedDate = dt.Rows[0]["Level2ApprovedDate"].ToString();
                Level2ApprovedTime = dt.Rows[0]["Level2ApprovedTime"].ToString();
                Level3ApprovedBy = dt.Rows[0]["Level3ApprovedBy"].ToString();
                Level3ApprovedDate = dt.Rows[0]["Level3ApprovedDate"].ToString();
                Level3ApprovedTime = dt.Rows[0]["Level3ApprovedTime"].ToString();
                AdminApprovedBy = dt.Rows[0]["AdminApprovedBy"].ToString();
                AdminApprovedDate = dt.Rows[0]["AdminApprovedDate"].ToString();
                AdminApprovedTime = dt.Rows[0]["AdminApprovedTime"].ToString();
            }
            catch (Exception ex)
            {

            }

        }
        public void GetTimestampDetails(DataSet ds)
        {


            CreatedBy = Convert.ToString(ds.Tables[0].Rows[0]["CreatedBy"]);
            CreatedDate = Convert.ToString(ds.Tables[0].Rows[0]["CreatedDate"]);
            UpdatedBy = Convert.ToString(ds.Tables[0].Rows[0]["LastUpdatedBy"]);
            UpdatedDate = Convert.ToString(ds.Tables[0].Rows[0]["LastUpdatedDate"]);
            UpdatedTime = Convert.ToString(ds.Tables[0].Rows[0]["LastUpdatedTime"]);
            CreatedTime = Convert.ToString(ds.Tables[0].Rows[0]["CreatedTime"]);
        }
        public bool CreateRequestApprovalPDF(clsUnApprovedInfo objUnaprvedInfo, UnApprovedContacts objUnapprContact)
        {
            bool blCreationSuccess = true;
            ereEvents = new PDFGeneratorEvents();
            try
            {
                createAndOpenNewDoc();
                objAgentBal = new AgentRequestManager();
                dsAgent = objAgentBal.LoadAgentDetail(objUnaprvedInfo);
                dsPriorityContact = new DataSet();
                dsPriorityContact = objAgentBal.getUnApprAgentContactList(objUnapprContact);
                foreach (DataRow dRow in dsAgent.Tables[0].Rows)
                {

                    //RejectReason = dsAgent.Tables[0].Rows[0]["RejectReason"].ToString();

                    try { Code = dsAgent.Tables[0].Rows[0]["AgentCode"].ToString(); }catch { }
                    try {Name = dsAgent.Tables[0].Rows[0]["AgentName"].ToString();}catch { }
                    try {ChName = dsAgent.Tables[0].Rows[0]["ChAgentName"].ToString();}catch { }
                    try {CorrAddress1 = dsAgent.Tables[0].Rows[0]["CorrAddress1"].ToString();}catch { }
                    try {CorrAddress2 = dsAgent.Tables[0].Rows[0]["CorrAddress2"].ToString();}catch { }
                    try {CorrAddress3 = dsAgent.Tables[0].Rows[0]["CorrAddress3"].ToString();}catch { }
                    try {CorrAddress4 = dsAgent.Tables[0].Rows[0]["CorrAddress4"].ToString();}catch { }
                    try {ChineseCorrAddress1 = dsAgent.Tables[0].Rows[0]["ChCorrAddress1"].ToString();}catch { }
                    try {ChineseCorrAddress2 = dsAgent.Tables[0].Rows[0]["ChCorrAddress2"].ToString();}catch { }
                    try {ChineseCorrAddress3 = dsAgent.Tables[0].Rows[0]["ChCorrAddress3"].ToString();}catch { }
                    try { ChineseCorrAddress4 = dsAgent.Tables[0].Rows[0]["ChCorrAddress4"].ToString(); }catch { }

                    if (dsAgent.Tables[0].Rows[0]["SubDistrict"].ToString() == "Please Select")
                    {
                        CorrSubDistrict = "";
                    }
                    else
                    {
                       try { CorrSubDistrict = dsClient.Tables[0].Rows[0]["SubDistrict"].ToString();}catch { }
                    }

                    if (dsAgent.Tables[0].Rows[0]["City"].ToString() == "Please Select")
                    {
                        CorrCity = "";
                    }
                    else
                    {
                        try { CorrCity = dsClient.Tables[0].Rows[0]["City"].ToString(); }catch { }
                    }
                    //CorrSubDistrict = dsAgent.Tables[0].Rows[0]["SubDistrict"].ToString();
                    //CorrCity = dsAgent.Tables[0].Rows[0]["City"].ToString();

                    int CorrProvinc =0;
                    try { CorrProvinc=Convert.ToInt32(dsAgent.Tables[0].Rows[0]["Country"]);}catch { }
                    if (objcommon.GetProvinceByTertID(CorrProvinc).Tables[0].Rows.Count > 0)
                    {
                       try { CorrProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsAgent.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceName"].ToString();}catch { }
                    }
                  //  CorrProvince = dsAgent.Tables[0].Rows[0]["Province"].ToString();
                     try {CorrPostalCode = dsAgent.Tables[0].Rows[0]["PostalCode"].ToString();}catch { }
                    if (dsAgent.Tables[0].Rows[0]["ChSubDistrict"].ToString() == "Please Select")
                    {
                        CorrChSubDistrict = "";
                    }
                    else
                    {
                       try { CorrChSubDistrict = dsAgent.Tables[0].Rows[0]["ChSubDistrict"].ToString();}catch { }
                    }
                    if (dsAgent.Tables[0].Rows[0]["ChCity"].ToString() == "Please Select")
                    {
                        CorrChCity = "";
                    }
                    else
                    {
                        try {CorrChCity = dsAgent.Tables[0].Rows[0]["ChCity"].ToString();}catch { }
                    }
                    //CorrChSubDistrict = dsAgent.Tables[0].Rows[0]["ChSubDistrict"].ToString();
                    //CorrChCity = dsAgent.Tables[0].Rows[0]["ChCity"].ToString();
                    int CorrChProvinc = 0;
                        try {CorrChProvinc =Convert.ToInt32(dsAgent.Tables[0].Rows[0]["Country"]);}catch { }
                    if (objcommon.GetProvinceByTertID(CorrProvinc).Tables[0].Rows.Count > 0)
                    {
                        try { CorrChProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsAgent.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceNameChinese"].ToString(); }
                        catch { }
                    }

                  //  CorrChProvince = dsAgent.Tables[0].Rows[0]["ChProvince"].ToString();
                   try {  CorrChPostalCode = dsAgent.Tables[0].Rows[0]["ChPostalCode"].ToString();}catch { }


                    if (dsAgent.Tables[0].Rows[0]["BillingSubDistrict"].ToString() == "Please Select")
                    {
                        BillSubDistrict = "";
                    }
                    else
                    {
                       try { BillSubDistrict = dsAgent.Tables[0].Rows[0]["BillingSubDistrict"].ToString();}catch { }
                    }
                    if (dsAgent.Tables[0].Rows[0]["BillingCity"].ToString() == "Please Select")
                    {
                        BillCity = "";
                    }
                    else
                    {
                        try {BillCity = dsAgent.Tables[0].Rows[0]["BillingCity"].ToString();}catch { }
                    }
                    //BillSubDistrict = dsAgent.Tables[0].Rows[0]["BillingSubDistrict"].ToString();
                    //BillCity = dsAgent.Tables[0].Rows[0]["BillingCity"].ToString();
                    int BillProvinc =0;
                        try {BillProvinc =Convert.ToInt32(dsAgent.Tables[0].Rows[0]["Country"]);}catch { }
                    if (objcommon.GetProvinceByTertID(CorrProvinc).Tables[0].Rows.Count > 0)
                    {
                        try { BillProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsAgent.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceName"].ToString(); }
                        catch { }
                    }
                    //BillProvince = dsAgent.Tables[0].Rows[0]["BillingProvince"].ToString();
                    BillPostalCode = dsAgent.Tables[0].Rows[0]["BillingPostalCode"].ToString();

                    if (dsAgent.Tables[0].Rows[0]["ChBillingSubDistrict"].ToString() == "Please Select")
                    {
                        BillChSubDistrict = "";
                    }
                    else
                    {
                        try { BillChSubDistrict = dsAgent.Tables[0].Rows[0]["ChBillingSubDistrict"].ToString(); }
                        catch { }
                    }
                    if (dsAgent.Tables[0].Rows[0]["ChBillingCity"].ToString() == "Please Select")
                    {
                        BillChCity = "";
                    }
                    else
                    {
                       try{ BillChCity = dsAgent.Tables[0].Rows[0]["ChBillingCity"].ToString();}catch { }
                    }
                    //BillChCity = dsAgent.Tables[0].Rows[0]["ChBillingSubDistrict"].ToString();
                    //BillChCity = dsAgent.Tables[0].Rows[0]["ChBillingCity"].ToString();
                    int BillChProvinc =0;
            try{ BillChProvinc =Convert.ToInt32(dsAgent.Tables[0].Rows[0]["Country"]);}catch { }
                    if (objcommon.GetProvinceByTertID(CorrProvinc).Tables[0].Rows.Count > 0)
                    {
                     try{   BillChProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsAgent.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceNameChinese"].ToString();}catch { }
                    }

                  //  BillChProvince = dsAgent.Tables[0].Rows[0]["ChBillingProvince"].ToString();
                  try{  BillChPostalCode = dsAgent.Tables[0].Rows[0]["ChBillingPostalCode"].ToString();}catch { }

                  try{  Country = objcommon.GetTerritory(Convert.ToInt32(dsAgent.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["TerritoryName"].ToString();}catch { }
                   try{ ChineseCountry = objcommon.GetTerritory(Convert.ToInt32(dsAgent.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["TerritoryNameChinese"].ToString();}catch { }
                    //Country= dsAgent.Tables[0].Rows[0]["Country"].ToString();
                  try{  ChCountry = objcommon.GetTerritory(Convert.ToInt32(dsAgent.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["TerritoryName"].ToString();}catch { }
                  try{  BillingAddress1 = dsAgent.Tables[0].Rows[0]["BillingAddress1"].ToString();}catch { }
                  try{  BillingAddress2 = dsAgent.Tables[0].Rows[0]["BillingAddress2"].ToString();}catch { }
                  try{  BillingAddress3 = dsAgent.Tables[0].Rows[0]["BillingAddress3"].ToString();}catch { }
                  try{  BillingAddress4 = dsAgent.Tables[0].Rows[0]["BillingAddress4"].ToString();}catch { }

                   try{ ChineseBillingAddress1 = dsAgent.Tables[0].Rows[0]["ChBillingAddress1"].ToString();}catch { }
                  try{  ChineseBillingAddress2 = dsAgent.Tables[0].Rows[0]["ChBillingAddress2"].ToString();}catch { }
                 try{   ChineseBillingAddress3 = dsAgent.Tables[0].Rows[0]["ChBillingAddress3"].ToString();}catch { }
                 try{   ChineseBillingAddress4 = dsAgent.Tables[0].Rows[0]["ChBillingAddress4"].ToString();}catch { }

                 try{   BillingCountry = objcommon.GetTerritory(Convert.ToInt32(dsAgent.Tables[0].Rows[0]["BillingCountry"])).Tables[0].Rows[0]["TerritoryName"].ToString();}catch { }
                 try{   ChineseBillingCountry = objcommon.GetTerritory(Convert.ToInt32(dsAgent.Tables[0].Rows[0]["BillingCountry"])).Tables[0].Rows[0]["TerritoryName"].ToString();}catch { }
                  try{  Description = dsAgent.Tables[0].Rows[0]["AgentDescription"].ToString();}catch { }
                 try{   GeneralLineCode = dsAgent.Tables[0].Rows[0]["GeneralLineCode"].ToString();}catch { }
                 try{   GeneralLineNo = dsAgent.Tables[0].Rows[0]["GeneralLineNo"].ToString();}catch { }
                 try{   Nationality = Convert.ToString(dsAgent.Tables[0].Rows[0]["nationality"]);}catch { }
                    //Nationality = objcommon.GetCountry(dsAgent.Tables[0].Rows[0]["nationality"].ToString()).Tables[0].Rows[0]["CountryName"].ToString();
                  try{  passportno = dsAgent.Tables[0].Rows[0]["passportNo"].ToString();}catch { }
                  try{  Gender = (dsAgent.Tables[0].Rows[0]["Gender"].ToString() == "M") ? "Male" : "Female";}catch { }
                  try{  RecordType = dsAgent.Tables[0].Rows[0]["RecordType"].ToString();}catch { }
                  try{  FaxCode = dsAgent.Tables[0].Rows[0]["FaxNoCode"].ToString();}catch { }
                  try{  FaxNo = dsAgent.Tables[0].Rows[0]["FaxNo"].ToString();}catch { }
                  try{  CompRegistrationNo = dsAgent.Tables[0].Rows[0]["CompanyRegistrationNo"].ToString();}catch { }
                   try{ RegDate = dsAgent.Tables[0].Rows[0]["RegistrationDate"].ToString();}catch { }
                   try{ BusiRegistrationNo = dsAgent.Tables[0].Rows[0]["BusinessRegistrationNo"].ToString();}catch { }
                   try{ Email = dsAgent.Tables[0].Rows[0]["Email"].ToString();}catch { }
                    //txtCreditLimit.Text = dsAgent.Tables[0].Rows[0]["CreditLimit"].ToString();
                   try{ CreditLimit = Convert.ToDecimal(dsAgent.Tables[0].Rows[0]["CreditLimit"]).ToString("#,##0.00");}catch { }
                   try{ CreditTerms = dsAgent.Tables[0].Rows[0]["creditTerms"].ToString();}catch { }
                   try{ CreditOption = dsAgent.Tables[0].Rows[0]["CreditTermsOption"].ToString();}catch { }
                   try{ CreditMonths = dsAgent.Tables[0].Rows[0]["CreditTermsOptionValue"].ToString();}catch { }
                    if (CreditOption == "Days" || CreditOption == "Months")
                        CreditString = CreditMonths + " " + CreditOption;
                    else
                        CreditString = "";
                   try{ AccountType = dsAgent.Tables[0].Rows[0]["AccountType"].ToString();}catch { }
                   try{ NormalBal = dsAgent.Tables[0].Rows[0]["NormalBalance"].ToString();}catch { }
                   try{ CreditControlAC = dsAgent.Tables[0].Rows[0]["CreditControlAccountNo"].ToString();}catch { }
                   try{ Remarks = dsAgent.Tables[0].Rows[0]["Remarks"].ToString();}catch { }
                    try{PaymentEffectiveFrom = Convert.ToString(dsAgent.Tables[0].Rows[0]["PaymentEffectiveFrom"]);}catch { }
                    try{PaymentEffectiveTo = Convert.ToString(dsAgent.Tables[0].Rows[0]["PaymentEffectiveTo"]);}catch { }
                    try{ChkJan = Convert.ToBoolean(dsAgent.Tables[0].Rows[0]["Jan"]);}catch { }
                    try{ChkFeb = Convert.ToBoolean(dsAgent.Tables[0].Rows[0]["Feb"]);}catch { }
                    try{ChkMar = Convert.ToBoolean(dsAgent.Tables[0].Rows[0]["Mar"]);}catch { }
                    try{ChkApr = Convert.ToBoolean(dsAgent.Tables[0].Rows[0]["Apr"]);}catch { }
                    try{ChkMay = Convert.ToBoolean(dsAgent.Tables[0].Rows[0]["May"]);}catch { }
                    try{ChkJun = Convert.ToBoolean(dsAgent.Tables[0].Rows[0]["jun"]);}catch { }
                    try{ChkJul = Convert.ToBoolean(dsAgent.Tables[0].Rows[0]["Jul"]);}catch { }
                    try{ChkAug = Convert.ToBoolean(dsAgent.Tables[0].Rows[0]["Aug"]);}catch { }
                    try{ChkSep = Convert.ToBoolean(dsAgent.Tables[0].Rows[0]["Sep"]);}catch { }
                    try{ChkOct = Convert.ToBoolean(dsAgent.Tables[0].Rows[0]["Oct"]);}catch { }
                    try{ChkNov = Convert.ToBoolean(dsAgent.Tables[0].Rows[0]["Nov"]);}catch { }
                    try{ChkDec = Convert.ToBoolean(dsAgent.Tables[0].Rows[0]["Dec"]);}catch { }
                    try{EffectiveFromDate = Convert.ToString(dsAgent.Tables[0].Rows[0]["EffectivefromDate"]);}catch { }
                    try{EffectiveToDate = Convert.ToString(dsAgent.Tables[0].Rows[0]["Effectivetodate"]);}catch { }
                    foreach (DataRow dataRow in dsPriorityContact.Tables[0].Rows)
                    {

                        try{PriorityTeam = objcommon.GetTeam(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Team"])).Tables[0].Rows[0]["TeamName"].ToString();}catch { }
                        try{PriorityChineseCorrAddress1 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress1"].ToString();}catch { }
                        try{PriorityChineseCorrAddress2 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress2"].ToString();}catch { }
                        try{PriorityChineseCorrAddress3 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress3"].ToString();}catch { }
                        try{PriorityChineseCorrAddress4 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress4"].ToString();}catch { }
                        if (Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"]) != 0)
                            try
                            {
                                int CountrychPr =0;
                               try{CountrychPr =Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"]);}catch { }
                                if (objcommon.GetTerritory(CountrychPr).Tables[0].Rows.Count > 0)
                                {
                                  try{  PriorityChineseCountry = objcommon.GetTerritory(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"])).Tables[0].Rows[0]["TerritoryName"].ToString();}catch { }
                                }
                            }
                            catch 
                            {
                                
                              
                            } 
                     try{   PriorityChineseDept = dsPriorityContact.Tables[0].Rows[0]["ChDept"].ToString();}catch { }
                     try{   PriorityChineseFirstName = dsPriorityContact.Tables[0].Rows[0]["ChFirstName"].ToString();}catch { }
                     try{   PriorityChineseJobTitle = dsPriorityContact.Tables[0].Rows[0]["ChJobTitle"].ToString();}catch { }
                     try{   PriorityChineseLastName = dsPriorityContact.Tables[0].Rows[0]["ChLastName"].ToString();}catch { }
                     try{   PriorityCorrAddress1 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress1"].ToString();}catch { }
                     try{   PriorityCorrAddress2 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress2"].ToString();}catch { }
                     try{   PriorityCorrAddress3 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress3"].ToString();}catch { }
                     try{   PriorityCorrAddress4 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress4"].ToString();}catch { }
try{
                        if (dsPriorityContact.Tables[0].Rows[0]["SubDistrict"].ToString() == "Please Select")
                        {
                            PrioritySubDistrict = "";
                        }
                        else
                        {
                            PrioritySubDistrict = dsPriorityContact.Tables[0].Rows[0]["SubDistrict"].ToString();
                        }
                        if (dsPriorityContact.Tables[0].Rows[0]["City"].ToString() == "Please Select")
                        {
                            PriorityCity = "";
                        }
                        else
                        {
                            PriorityCity = dsPriorityContact.Tables[0].Rows[0]["City"].ToString();
                        }
}catch { }
                        //PrioritySubDistrict = dsPriorityContact.Tables[0].Rows[0]["SubDistrict"].ToString();
                        //PriorityCity = dsPriorityContact.Tables[0].Rows[0]["City"].ToString();
try{
                        int PriorityProvinc = Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Country"]);
                        if (objcommon.GetProvinceByTertID(CorrProvinc).Tables[0].Rows.Count > 0)
                        {
                            PriorityProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceName"].ToString();
                        }

                      //  PriorityProvince = dsPriorityContact.Tables[0].Rows[0]["Province"].ToString();
                        PriorityPostalCode = dsPriorityContact.Tables[0].Rows[0]["PostalCode"].ToString();

                        if (dsPriorityContact.Tables[0].Rows[0]["ChSubDistrict"].ToString() == "Please Select")
                        {
                            PriorityChSubDistrict = "";
                        }
                        else
                        {
                            PriorityChSubDistrict = dsPriorityContact.Tables[0].Rows[0]["ChSubDistrict"].ToString();
                        }
                        if (dsPriorityContact.Tables[0].Rows[0]["ChCity"].ToString() == "Please Select")
                        {
                            PriorityChCity = "";
                        }
                        else
                        {
                            PriorityChCity = dsPriorityContact.Tables[0].Rows[0]["ChCity"].ToString();
                        }
                        //PriorityChSubDistrict = dsPriorityContact.Tables[0].Rows[0]["ChSubDistrict"].ToString();
                        //PriorityChCity = dsPriorityContact.Tables[0].Rows[0]["ChCity"].ToString();
                        int PriorityChProvinc = Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Country"]);
                        if (objcommon.GetProvinceByTertID(CorrProvinc).Tables[0].Rows.Count > 0)
                        {
                            PriorityChProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceNameChinese"].ToString();
                        }
}catch { }
                      //  PriorityChProvince = dsPriorityContact.Tables[0].Rows[0]["ChProvince"].ToString();
                       try {  PriorityChPostalCode = dsPriorityContact.Tables[0].Rows[0]["ChPostalCode"].ToString();}catch { }

                       try {  PriorityCountry = objcommon.GetTerritory(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["TerritoryName"].ToString();}catch { }
                        // PriorityChineseCountry = objcommon.GetTerritoryByCode(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        //  PriorityDept = objcommon.GetDepartment(dsPriorityContact.Tables[0].Rows[0]["Dept"].ToString(),null).Tables[0].Rows[0]["DeptName"].ToString();
                       try {  PriorityDept = dsPriorityContact.Tables[0].Rows[0]["Dept"].ToString();}catch { }
                       try {  PriorityDirectLineCode = dsPriorityContact.Tables[0].Rows[0]["DirectLineCode"].ToString();}catch { }
                       try { PriorityDirectLineNo = dsPriorityContact.Tables[0].Rows[0]["DirectLineNo"].ToString();}catch { }
                       try {  PriorityEffectiveFromDate = dsPriorityContact.Tables[0].Rows[0]["EffectivefromDate"].ToString();}catch { }
                       try {  PriorityEffectiveToDate = dsPriorityContact.Tables[0].Rows[0]["Effectivetodate"].ToString();}catch { }
                       try {  PriorityEmail = dsPriorityContact.Tables[0].Rows[0]["Email"].ToString();}catch { }
                       try {  PriorityExtension = dsPriorityContact.Tables[0].Rows[0]["Extension"].ToString();}catch { }
                       try {  PriorityFaxCode = dsPriorityContact.Tables[0].Rows[0]["FaxNoCode"].ToString();}catch { }
                       try {  PriorityFaxNo = dsPriorityContact.Tables[0].Rows[0]["FaxNo"].ToString();}catch { }
                       try {  PriorityFirstName = dsPriorityContact.Tables[0].Rows[0]["FirstName"].ToString();}catch { }
                       try {  PriorityGeneralLineCode = dsPriorityContact.Tables[0].Rows[0]["GeneralLineCode"].ToString();}catch { }
                       try {  PriorityGeneralLineNo = dsPriorityContact.Tables[0].Rows[0]["GeneralLineNo"].ToString();}catch { }
                       try {  PriorityJobTitle = dsPriorityContact.Tables[0].Rows[0]["JobTitle"].ToString();}catch { }
                       try {  PriorityLastName = dsPriorityContact.Tables[0].Rows[0]["LastName"].ToString();}catch { }
                       try { PriorityMobileCode = dsPriorityContact.Tables[0].Rows[0]["MobileNoCode"].ToString();}catch { }
                       try {  PriorityMobileNo = dsPriorityContact.Tables[0].Rows[0]["MobileNo"].ToString();}catch { }
                        // PriorityTeam = objcommon.GetTeam(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Team"])).Tables[0].Rows[0]["TeamName"].ToString();
                       try {  PrioritySalutation = dsPriorityContact.Tables[0].Rows[0]["Salutation"].ToString();}catch { }
                       try { PriorityChSalutation = dsPriorityContact.Tables[0].Rows[0]["ChSalutation"].ToString();}catch { }
                    }
                    if (dsAgent.Tables.Count > 1)
                    {
                        if (dsAgent.Tables[1].Rows.Count > 0)
                            GetApprovalDetails(dsAgent.Tables[1]);
                    }

                    GetTimestampDetails(dsAgent);
                    //
                    ereEvents.ShowPageNumber = true;
                    //ereEvents.PrintFooter = false;
                    ereEvents.UWCOPY = false;
                    CreateAgentPDF(dRow);
                    docPDF.NewPage();
                }


            }
            catch (Exception ex)
            {
                string strTemp = ex.Message;
                blCreationSuccess = false;
            }
            finally
            {
                closeDoc();
            }
            return blCreationSuccess;

        }
        private void CreateAgentPDF(DataRow dr)
        {
            Table tblContent = new Table(1);
            tblContent.AutoFillEmptyCells = true;
            tblContent.WidthPercentage = 100;
            tblContent.Border = Table.NO_BORDER;
            tblContent.Cellspacing = 2;
            tblContent.DefaultCellBorder = Cell.NO_BORDER;
            tblContent.InsertTable(getAgentFirstTable());
            docPDF.Add(tblContent);

            Table tblContent1 = new Table(1);
            tblContent1.AutoFillEmptyCells = true;
            tblContent1.WidthPercentage = 100;
            tblContent1.Border = Table.NO_BORDER;
            tblContent1.Cellspacing = 2;
            tblContent1.DefaultCellBorder = Cell.NO_BORDER;
            tblContent1.InsertTable(getAgentPaymentMonthTable());
            docPDF.Add(tblContent1);

            Table tblContent2 = new Table(1);
            tblContent2.AutoFillEmptyCells = true;
            tblContent2.WidthPercentage = 100;
            tblContent2.Border = Table.NO_BORDER;
            tblContent2.Cellspacing = 2;
            tblContent2.DefaultCellBorder = Cell.NO_BORDER;
            tblContent2.InsertTable(getPriorityContactTable());
            docPDF.Add(tblContent2);

            Table tblContent3 = new Table(1);
            tblContent3.AutoFillEmptyCells = true;
            tblContent3.WidthPercentage = 100;
            tblContent3.Border = Table.NO_BORDER;
            tblContent3.Cellspacing = 2;
            tblContent3.DefaultCellBorder = Cell.NO_BORDER;
            tblContent3.InsertTable(getApprovalTable());
            docPDF.Add(tblContent3);

            Table tblContent4 = new Table(1);
            tblContent4.AutoFillEmptyCells = true;
            tblContent4.WidthPercentage = 100;
            tblContent4.Border = Table.NO_BORDER;
            tblContent4.Cellspacing = 2;
            tblContent4.DefaultCellBorder = Cell.NO_BORDER;
            tblContent4.InsertTable(getTimeStampTable());
            docPDF.Add(tblContent4);

        }

        private Table getAgentFirstTable()
        {
            Table tblFirstSec = new Table(4);
            int[] flColWidth = { 20, 30, 20, 30 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 2;

            strText = "Introducer Information";
            clCurrCell = getCell(strText, "NOTECH", "Center", "CENTER", 4, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "Introducer Information";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //strText = "Flex Control Account";
            strText = "";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.AddCell(new Phrase("Introducer Code", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Code, fontThaiSmall));

            //commented
            tblFirstSec.AddCell(new Phrase(""));
            tblFirstSec.AddCell(new Phrase(""));
            //tblFirstSec.AddCell(new Phrase("Account Type", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(AccountType, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //end

            //tblFirstSec.AddCell(new Phrase("Description", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(Description, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Introducer Name", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Name, fontThaiSmall));

            //commented
            tblFirstSec.AddCell(new Phrase(""));
            tblFirstSec.AddCell(new Phrase(""));
            //tblFirstSec.AddCell(new Phrase("Normal Balance", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(NormalBal, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //end

            tblFirstSec.AddCell(new Phrase("Record Type", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(RecordType, fontThaiSmall));

            //commented
            tblFirstSec.AddCell(new Phrase(""));
            tblFirstSec.AddCell(new Phrase(""));
            //tblFirstSec.AddCell(new Phrase("Credit Control A/C", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(CreditControlAC, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //end
            //Dynamic
            if (RecordType == "Individual")
            {
                tblFirstSec.AddCell(new Phrase("Nationality", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Nationality, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

                tblFirstSec.AddCell(new Phrase("Passport Number", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(passportno, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

                tblFirstSec.AddCell(new Phrase("Gendor", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Gender, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            }
            else
            {
                tblFirstSec.AddCell(new Phrase("Company Registration Number", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CompRegistrationNo, fontThaiSmall));
                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

                tblFirstSec.AddCell(new Phrase("Date of Registeration", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(RegDate, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

                tblFirstSec.AddCell(new Phrase("Business Registration Number", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BusiRegistrationNo, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            }
            //
            tblFirstSec.AddCell(new Phrase("General Line", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(GeneralLineCode + "-" + GeneralLineNo, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Fax", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(FaxCode + "-" + FaxNo, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Effective From Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(EffectiveFromDate, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Effective To Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(EffectiveToDate, fontThaiSmall));
            //Second Heading
            strText = "Introducer Address";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (IsChineseRequired == "Y")
            {
                strText = "ที่อยู่ของ บริษัท ตัวแทน";
                clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 2".ToString(), fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrSubDistrict, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("แขวง/ตำบล", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChSubDistrict, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("ขต/อำเภอ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("จังหวัด", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("รหัสไปรษณีย์", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Country, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("ประเทศ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillSubDistrict, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("แขวง/ตำบล", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChSubDistrict, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("เขต/อำเภอ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("จังหวัด", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("หัสไปรษณีย์", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("ประเทศ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));
            }
            else
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2".ToString(), fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrSubDistrict, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChSubDistrict, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Country, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillSubDistrict, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChSubDistrict, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

            }
            strText = "Introducer Credit Details";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 4, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);


            tblFirstSec.AddCell(new Phrase("Credit Limit", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(CreditLimit, fontThaiSmall));


            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Credit Terms", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(CreditTerms, fontThaiSmall));


            tblFirstSec.AddCell(new Phrase("Credit Option", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(CreditString, fontThaiSmall));


            return tblFirstSec;
        }
        private Table getAgentPaymentMonthTable()
        {
            Table tblFirstSec = new Table(12);
            int[] flColWidth = { 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 2;


            strText = "Payment Months";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 12, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);


            tblFirstSec.AddCell(new Phrase("Jan", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(getYesNo(ChkJan), fontThaiSmall));


            tblFirstSec.AddCell(new Phrase("Feb", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(getYesNo(ChkFeb), fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("March", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(getYesNo(ChkMar), fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("April", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(getYesNo(ChkApr), fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("May", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(getYesNo(ChkMay), fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("June", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(getYesNo(ChkJun), fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("July", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(getYesNo(ChkJul), fontThaiSmall));
            tblFirstSec.AddCell(new Phrase("Aug", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(getYesNo(ChkAug), fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Sep", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(getYesNo(ChkSep), fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Oct", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(getYesNo(ChkOct), fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Nov", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(getYesNo(ChkOct), fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Dec", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(getYesNo(ChkDec), fontThaiSmall));


            return tblFirstSec;
        }
        private Table getPriorityContactTable()
        {
            Table tblFirstSec = new Table(4);
            int[] flColWidth = { 20, 30, 20, 30 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 2;

            strText = "Priority Contact Person Information";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 4, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.AddCell(new Phrase("Department", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(PriorityDept, fontThaiSmall));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            if (IsChineseRequired == "Y")
            {
                tblFirstSec.AddCell(new Phrase("Other Name", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityLastName, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("นามสกุล", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseLastName, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("First Name", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityFirstName, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("ชื่อ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseFirstName, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Salutation", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PrioritySalutation, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("คำนำหน้า", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChSalutation, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Job Title", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(PriorityJobTitle, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("ตำแหน่งงาน", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(PriorityChineseJobTitle, fontThaiSmall));
            }
            else
            {
                tblFirstSec.AddCell(new Phrase("Other Name", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityLastName, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Other Name", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseLastName, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("First Name", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityFirstName, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("First Name", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseFirstName, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Salutation", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PrioritySalutation, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Salutation", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChSalutation, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Job Title", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(PriorityJobTitle, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Job Title", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(PriorityChineseJobTitle, fontThaiSmall));
            }
            //tblFirstSec.AddCell(new Phrase("Department", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(PriorityDept, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //tblFirstSec.AddCell(new Phrase("Department", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(PriorityChineseDept, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("General Line", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(PriorityGeneralLineCode + "-" + PriorityGeneralLineNo, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Extension", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(PriorityExtension, fontThaiSmall));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Direct Line", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(PriorityDirectLineCode + "-" + PriorityDirectLineNo, fontThaiSmall));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Mobile", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(PriorityMobileCode + "-" + PriorityMobileNo, fontThaiSmall));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Fax", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(PriorityFaxCode + "-" + PriorityFaxNo, fontThaiSmall));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Email", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(PriorityEmail, fontThaiSmall));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //Second Heading
            strText = "Contact Person Address";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (IsChineseRequired == "Y")
            {
                strText = "ที่อยู่ผู้ติดต่อ";
                clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityCorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityCorrAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseCorrAddress4, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(PrioritySubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("แขวง/ตำบล", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(PriorityChSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(PriorityCity, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("เขต/อำเภอ", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(PriorityChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("จังหวัด", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("PostalCode", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("รหัสไปรษณีย์", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChPostalCode, fontThaiSmall));


                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("ประเทศ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseCountry, fontThaiSmall));
            }
            else
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityCorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityCorrAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseCorrAddress4, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(PrioritySubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(PriorityChSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(PriorityCity, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(PriorityChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChPostalCode, fontThaiSmall));


                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(PriorityChineseCountry, fontThaiSmall));
            }
            tblFirstSec.AddCell(new Phrase("Effective From Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(PriorityEffectiveFromDate, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Effective To Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(PriorityEffectiveToDate, fontThaiSmall));

            return tblFirstSec;
        }
        private Table getApprovalTable()
        {
            Table tblFirstSec = new Table(6);
            //int[] flColWidth = { 12, 12, 12, 12, 12, 12, 12, 12 };
            int[] flColWidth = { 12, 12, 12, 12, 12, 12};
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 2;


            strText = "Approval Detail";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 6, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);


            tblFirstSec.AddCell(new Phrase("Requested By", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Level1ApprovedBy, fontThaiSmall));


            tblFirstSec.AddCell(new Phrase("Approved By", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Level2ApprovedBy, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("System Admin Approved By", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Level3ApprovedBy, fontThaiSmall));

            //tblFirstSec.AddCell(new Phrase("System Admin Approved By", fontThaiSmall));
            //tblFirstSec.AddCell(new Phrase(Level3ApprovedBy, fontThaiSmall));



            tblFirstSec.AddCell(new Phrase("Requested Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Level1ApprovedDate, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Approved Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Level2ApprovedDate, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Approved Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(AdminApprovedDate, fontThaiSmall));

            //tblFirstSec.AddCell(new Phrase("Approved Date", fontThaiSmall));
            //tblFirstSec.AddCell(new Phrase(Level3ApprovedDate, fontThaiSmall));



            tblFirstSec.AddCell(new Phrase("Requested Time", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Level1ApprovedTime, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Approved Time", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Level2ApprovedTime, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Approved Time", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(AdminApprovedTime, fontThaiSmall));

            //tblFirstSec.AddCell(new Phrase("Approved Time", fontThaiSmall));
            //tblFirstSec.AddCell(new Phrase(Level3ApprovedTime, fontThaiSmall));


            return tblFirstSec;
        }
        private Table getTimeStampTable()
        {
            Table tblFirstSec = new Table(4);
            int[] flColWidth = { 25, 25, 25, 25 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 2;


            strText = "Timestamp Details";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 4, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);


            tblFirstSec.AddCell(new Phrase("Created By", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(CreatedBy, fontThaiSmall));


            tblFirstSec.AddCell(new Phrase("Updated By", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(UpdatedBy, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Created Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(CreatedDate, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Updated Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(UpdatedDate, fontThaiSmall));



            tblFirstSec.AddCell(new Phrase("Created Time", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(CreatedTime, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Updated Time", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(UpdatedTime, fontThaiSmall));

            return tblFirstSec;
        }
        protected void createAndOpenNewDoc()
        {
            docPDF = new Document(PageSize.A4, mintLeftBorder, mintRightBorder, mintTopBorder, mintBottomBorder);
            FileStream fsPDFStream = new FileStream(strPDFFilePath, FileMode.Create);
            PdfWriter pdfWriter = PdfWriter.GetInstance(docPDF, fsPDFStream);
            pdfWriter.PageEvent = ereEvents;
            docPDF.Open();
            isPDFCreated = true;
        }
        protected string getYesNo(bool flag)
        {
            if (flag)
                return "Yes";
            else
            {
                //string strLogoPath ="../Images/MitsuiLogoPDF.jpg";
                return "No";
            }
        }
        public bool CreateClientRequestApprovalPDF(clsUnApprovedInfo objUnaprvedInfo, UnApprovedContacts objUnapprContact)
        {
            bool blCreationSuccess = true;
            int BillingChCountry = 0;
            ereEvents = new PDFGeneratorEvents();
            try
            {
                createAndOpenNewDoc();
                objClientBAL = new clsClientManager();
                dsClient = objClientBAL.getUnApprovClientList(objUnaprvedInfo);
                dsPriorityContact = new DataSet();
                dsPriorityContact = objClientBAL.getUnApprovContactList(objUnapprContact);
                foreach (DataRow dRow in dsClient.Tables[0].Rows)
                {

                    //RejectReason = dsAgent.Tables[0].Rows[0]["RejectReason"].ToString();

                    Code = dsClient.Tables[0].Rows[0]["Code"].ToString();
                    Name = dsClient.Tables[0].Rows[0]["ClientName"].ToString();
                    ChName = dsClient.Tables[0].Rows[0]["ChClientName"].ToString();
                    CorrAddress1 = dsClient.Tables[0].Rows[0]["CorrAddress1"].ToString();
                    CorrAddress2 = dsClient.Tables[0].Rows[0]["CorrAddress2"].ToString();
                    CorrAddress3 = dsClient.Tables[0].Rows[0]["CorrAddress3"].ToString();
                    CorrAddress4 =  dsClient.Tables[0].Rows[0]["CorrAddress4"].ToString();

                    ChineseCorrAddress1 = dsClient.Tables[0].Rows[0]["ChCorrAddress1"].ToString();
                    ChineseCorrAddress2 = dsClient.Tables[0].Rows[0]["ChCorrAddress2"].ToString();
                    ChineseCorrAddress3 = dsClient.Tables[0].Rows[0]["ChCorrAddress3"].ToString();
                    ChineseCorrAddress4 = dsClient.Tables[0].Rows[0]["ChCorrAddress4"].ToString();

                    if (dsClient.Tables[0].Rows[0]["SubDistrict"].ToString() == "Please Select")
                    {
                        CorrSubDistrict = "";
                    }
                    else
                    {
                        CorrSubDistrict = dsClient.Tables[0].Rows[0]["SubDistrict"].ToString();
                    }

                    if (dsClient.Tables[0].Rows[0]["City"].ToString() == "Please Select")
                    {
                        CorrCity = "";
                    }
                    else
                    {
                        CorrCity = dsClient.Tables[0].Rows[0]["City"].ToString();
                    }
                   // CorrCity = dsClient.Tables[0].Rows[0]["City"].ToString();
                   int CorrProvinc = Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"]);
                   if (objcommon.GetProvinceByTertID(CorrProvinc).Tables[0].Rows.Count > 0)
                    {
                        CorrProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceName"].ToString();
                    }

                    CorrPostalCode = dsClient.Tables[0].Rows[0]["PostalCode"].ToString();

                    if (dsClient.Tables[0].Rows[0]["ChSubDistrict"].ToString() == "Please Select")
                    {
                        CorrChSubDistrict = "";
                    }
                    else
                    {
                        CorrChSubDistrict = dsClient.Tables[0].Rows[0]["ChSubDistrict"].ToString();
                    }

                    if (dsClient.Tables[0].Rows[0]["ChCity"].ToString() == "Please Select")
                    {
                        CorrChCity = "";
                    }
                    else
                    {
                        CorrChCity = dsClient.Tables[0].Rows[0]["ChCity"].ToString();
                    }
                    //CorrChSubDistrict = dsClient.Tables[0].Rows[0]["ChSubDistrict"].ToString();
                    //CorrChCity = dsClient.Tables[0].Rows[0]["ChCity"].ToString();
                    //CorrChProvince = dsClient.Tables[0].Rows[0]["ChProvince"].ToString();
                    int CorrChProvinc = Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"]);
                    if (objcommon.GetProvinceByTertID(CorrProvinc).Tables[0].Rows.Count > 0)
                    {
                        CorrChProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceNameChinese"].ToString();
                    }

                    CorrChPostalCode = dsClient.Tables[0].Rows[0]["ChPostalCode"].ToString();

                    if (dsClient.Tables[0].Rows[0]["BillingSubDistrict"].ToString() == "Please Select")
                    {
                        BillSubDistrict = "";
                    }
                    else
                    {
                        BillSubDistrict = dsClient.Tables[0].Rows[0]["BillingSubDistrict"].ToString();
                    }

                    if (dsClient.Tables[0].Rows[0]["BillingCity"].ToString() == "Please Select")
                    {
                        BillCity = "";
                    }
                    else
                    {
                        BillCity = dsClient.Tables[0].Rows[0]["BillingCity"].ToString();
                    }
                    //BillSubDistrict = dsClient.Tables[0].Rows[0]["BillingSubDistrict"].ToString();
                    //BillCity = dsClient.Tables[0].Rows[0]["BillingCity"].ToString();
                   // BillProvince = dsClient.Tables[0].Rows[0]["BillingProvince"].ToString();
                    int BillProvinc = Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"]);
                    if (objcommon.GetProvinceByTertID(BillProvinc).Tables[0].Rows.Count > 0)
                    {
                        BillProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceName"].ToString();
                    }

                    BillPostalCode = dsClient.Tables[0].Rows[0]["BillingPostalCode"].ToString();

                    if (dsClient.Tables[0].Rows[0]["ChBillingSubDistrict"].ToString() == "Please Select")
                    {
                        BillChSubDistrict = "";
                    }
                    else
                    {
                        BillChSubDistrict = dsClient.Tables[0].Rows[0]["ChBillingSubDistrict"].ToString();
                    }

                    if (dsClient.Tables[0].Rows[0]["ChBillingCity"].ToString() == "Please Select")
                    {
                        BillChCity = "";
                    }
                    else
                    {
                        BillChCity = dsClient.Tables[0].Rows[0]["ChBillingCity"].ToString();
                    }
                    //BillChSubDistrict = dsClient.Tables[0].Rows[0]["ChBillingSubDistrict"].ToString();
                    //BillChCity = dsClient.Tables[0].Rows[0]["ChBillingCity"].ToString();
                    //BillChProvince = dsClient.Tables[0].Rows[0]["ChBillingProvince"].ToString();
                    int BillChProvinc = Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"]);
                    if (objcommon.GetProvinceByTertID(BillChProvinc).Tables[0].Rows.Count > 0)
                    {
                        BillChProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceNameChinese"].ToString();
                    }
                    
                    BillChPostalCode = dsClient.Tables[0].Rows[0]["ChBillingPostalCode"].ToString();
                    int CountryC = Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"]);
                    if (objcommon.GetTerritory(CountryC).Tables[0].Rows.Count > 0)
                    {
                        Country = objcommon.GetTerritory(Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["TerritoryName"].ToString();
                        //ChineseCountry = objcommon.GetTerritoryByCode(dsClient.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryNameChinese"].ToString();
                        //ChCountry = objcommon.GetTerritoryByCode(dsClient.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryNameChinese"].ToString();
                    }

                    int CountryCH = Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"]);
                    if (objcommon.GetTerritory(CountryCH).Tables[0].Rows.Count > 0)
                    {
                        ChCountry = objcommon.GetTerritory(Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["TerritoryNameChinese"].ToString();
                    }
                    //Country = objcommon.GetTerritoryByCode(dsClient.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                    //ChineseCountry = objcommon.GetTerritoryByCode(dsClient.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                    //Country= dsAgent.Tables[0].Rows[0]["Country"].ToString();     //already commented
                    // ChCountry = objcommon.GetTerritoryByCode(dsClient.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();

                    sourceOfBusiness = dsClient.Tables[0].Rows[0]["SOBName"].ToString();
                    MasterSourceCode = dsClient.Tables[0].Rows[0]["SCodeName"].ToString();
                    subsidiarySourceCode1 = dsClient.Tables[0].Rows[0]["SSCode1Name"].ToString();
                    subsidiarySourceCode2 = dsClient.Tables[0].Rows[0]["SSCode2Name"].ToString();
                    sourceCodeMaster = dsClient.Tables[0].Rows[0]["SCDesc"].ToString();
                    group = dsClient.Tables[0].Rows[0]["GroupName"].ToString();
                    subGroup = dsClient.Tables[0].Rows[0]["SubGroupName"].ToString();
                    BusinessNatureCode = dsClient.Tables[0].Rows[0]["BusinessNatureDescription"].ToString();

                    BillingAddress1 = dsClient.Tables[0].Rows[0]["BillingAddress1"].ToString();
                    BillingAddress2 = dsClient.Tables[0].Rows[0]["BillingAddress2"].ToString();
                    BillingAddress3 = dsClient.Tables[0].Rows[0]["BillingAddress3"].ToString();
                    BillingAddress4 = dsClient.Tables[0].Rows[0]["BillingAddress4"].ToString();

                    ChineseBillingAddress1 = dsClient.Tables[0].Rows[0]["ChBillingAddress1"].ToString();
                    ChineseBillingAddress2 = dsClient.Tables[0].Rows[0]["ChBillingAddress2"].ToString();
                    ChineseBillingAddress3 = dsClient.Tables[0].Rows[0]["ChBillingAddress3"].ToString();
                    ChineseBillingAddress4 = dsClient.Tables[0].Rows[0]["ChBillingAddress4"].ToString();

                    int BillingCt = Convert.ToInt32(dsClient.Tables[0].Rows[0]["BillingCountry"]);
                    if (objcommon.GetTerritory(BillingCt).Tables[0].Rows.Count > 0)
                    {
                        BillingCountry = objcommon.GetTerritory(Convert.ToInt32(dsClient.Tables[0].Rows[0]["BillingCountry"])).Tables[0].Rows[0]["TerritoryName"].ToString();
                     
                    }
                    
                    try
                    {
                         BillingChCountry = Convert.ToInt32(dsClient.Tables[0].Rows[0]["ChBillingCountry"]);
                    }
                    catch(Exception ex)
                    {
                    }
                    if (objcommon.GetTerritory(BillingChCountry).Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            ChineseBillingCountry = objcommon.GetTerritory(Convert.ToInt32(dsClient.Tables[0].Rows[0]["ChBillingCountry"])).Tables[0].Rows[0]["TerritoryNameChinese"].ToString();
     
                        }
                        catch 
                        {
                        }
                     }
                    //BillingCountry = objcommon.GetTerritoryByCode(dsClient.Tables[0].Rows[0]["BillingCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                    //ChineseBillingCountry = objcommon.GetTerritoryByCode(dsClient.Tables[0].Rows[0]["BillingCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                    Description = dsClient.Tables[0].Rows[0]["ClientDescription"].ToString();
                    GeneralLineCode = dsClient.Tables[0].Rows[0]["GeneralLineCode"].ToString();
                    GeneralLineNo = dsClient.Tables[0].Rows[0]["GeneralLineNo"].ToString();
                    Nationality = dsClient.Tables[0].Rows[0]["nationality"].ToString(); // objcommon.GetCountry(dsClient.Tables[0].Rows[0]["nationality"].ToString()).Tables[0].Rows[0]["CountryName"].ToString();
                    passportno = dsClient.Tables[0].Rows[0]["PassportNumber"].ToString();
                    Gender = dsClient.Tables[0].Rows[0]["Gender"].ToString();
                    RecordType = dsClient.Tables[0].Rows[0]["RecordType"].ToString();
                    ClientType = ((dsClient.Tables[0].Rows[0]["ClientType"].ToString() == "C") ? "Client" : "Potential");
                    VIPType = dsClient.Tables[0].Rows[0]["VIPType"].ToString();
                    FaxCode = dsClient.Tables[0].Rows[0]["FaxNoCode"].ToString();
                    FaxNo = dsClient.Tables[0].Rows[0]["FaxNo"].ToString();

                    Notification = Convert.ToBoolean((dsClient.Tables[0].Rows[0]["SendNotification"].ToString() == "F") ? false : true);
                    CompRegistrationNo = dsClient.Tables[0].Rows[0]["CompanyRegistrationNo"].ToString();
                    //RegDate = dsAgent.Tables[0].Rows[0]["RegistrationDate"].ToString();
                    BusiRegistrationNo = dsClient.Tables[0].Rows[0]["BusinessRegistrationNo"].ToString();
                    Email = dsClient.Tables[0].Rows[0]["CompanyEmail"].ToString();
                    //txtCreditLimit.Text = dsAgent.Tables[0].Rows[0]["CreditLimit"].ToString();
                    day = dsClient.Tables[0].Rows[0]["DayOfBirth"].ToString();
                    month = dsClient.Tables[0].Rows[0]["MonthOfBirth"].ToString();
                    year = dsClient.Tables[0].Rows[0]["YearOfBirth"].ToString();

                    maritalstatus = dsClient.Tables[0].Rows[0]["MaritalSatus"].ToString();
                    //txtOccupation.Text = dsClient.Tables[0].Rows[0]["Occupation"].ToString();
                    occupation = objcommon.GetOccupation(dsClient.Tables[0].Rows[0]["Occupation"].ToString()).Tables[0].Rows[0]["Lookup_desc"].ToString();
                    //occupation = dsClient.Tables[0].Rows[0]["Occupation"].ToString();
                    AccountType = dsClient.Tables[0].Rows[0]["AccountType"].ToString();
                    NormalBal = dsClient.Tables[0].Rows[0]["NormalBalance"].ToString();
                    CreditControlAC = dsClient.Tables[0].Rows[0]["DebtorControlAccountNo"].ToString();
                    Remarks = dsClient.Tables[0].Rows[0]["Remarks"].ToString();

                    EffectiveFromDate = Convert.ToString(dsClient.Tables[0].Rows[0]["EffectivefromDate"]);
                    EffectiveToDate = Convert.ToString(dsClient.Tables[0].Rows[0]["Effectivetodate"]);
                    foreach (DataRow dataRow in dsPriorityContact.Tables[0].Rows)
                    {
                        try
                        {
                            PriorityTeam = objcommon.GetTeam(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Team"])).Tables[0].Rows[0]["TeamName"].ToString();
                        }
                        catch 
                        {
                        }
                        PriorityChineseCorrAddress1 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress1"].ToString();
                        PriorityChineseCorrAddress2 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress2"].ToString();
                        PriorityChineseCorrAddress3 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress3"].ToString();
                        int ChineseCt = 0;
                        try
                        {
                         ChineseCt = (Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"]));
                        }
                        catch 
                        {
                        }
                       
                        if (objcommon.GetTerritory(ChineseCt).Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                PriorityChineseCountry = objcommon.GetTerritory((Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"]))).Tables[0].Rows[0]["TerritoryNameChinese"].ToString();
                            }
                            catch
                            {
                            }
                        }
                        //PriorityChineseCountry = objcommon.GetTerritoryByCode(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        PriorityChineseDept = dsPriorityContact.Tables[0].Rows[0]["ChDept"].ToString();
                        PriorityChineseFirstName = dsPriorityContact.Tables[0].Rows[0]["ChFirstName"].ToString();
                        PriorityChineseJobTitle = dsPriorityContact.Tables[0].Rows[0]["ChJobTitle"].ToString();
                        PriorityChineseLastName = dsPriorityContact.Tables[0].Rows[0]["ChLastName"].ToString();
                        PriorityCorrAddress1 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress1"].ToString();
                        PriorityCorrAddress2 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress2"].ToString();
                        PriorityCorrAddress3 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress3"].ToString();
                        PriorityCorrAddress4 = dsClient.Tables[0].Rows[0]["CorrAddress4"].ToString();

                        if (dsPriorityContact.Tables[0].Rows[0]["SubDistrict"].ToString() == "Please Select")
                        {
                            PrioritySubDistrict = "";
                        }
                        else
                        {
                            PrioritySubDistrict = dsPriorityContact.Tables[0].Rows[0]["SubDistrict"].ToString();
                        }

                        if (dsPriorityContact.Tables[0].Rows[0]["City"].ToString() == "Please Select")
                        {
                            PriorityCity = "";
                        }
                        else
                        {
                            PriorityCity = dsPriorityContact.Tables[0].Rows[0]["City"].ToString();
                        }
                        //PrioritySubDistrict = dsPriorityContact.Tables[0].Rows[0]["SubDistrict"].ToString();
                        //PriorityCity = dsPriorityContact.Tables[0].Rows[0]["City"].ToString();
                       // PriorityProvince = dsPriorityContact.Tables[0].Rows[0]["Province"].ToString();
                        int PriorityProvin = Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"]);
                        if (objcommon.GetProvinceByTertID(PriorityProvin).Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                PriorityProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceName"].ToString();
                            }
                            catch
                            {
                            }
                         }
                        PriorityPostalCode = dsPriorityContact.Tables[0].Rows[0]["PostalCode"].ToString();
                        if (dsPriorityContact.Tables[0].Rows[0]["ChSubDistrict"].ToString() == "Please Select")
                        {
                            PriorityChSubDistrict = "";
                        }
                        else
                        {
                            PriorityChSubDistrict = dsPriorityContact.Tables[0].Rows[0]["ChSubDistrict"].ToString();
                        }

                        if (dsPriorityContact.Tables[0].Rows[0]["ChCity"].ToString() == "Please Select")
                        {
                            PriorityChCity = "";
                        }
                        else
                        {
                            PriorityChCity = dsPriorityContact.Tables[0].Rows[0]["ChCity"].ToString();
                        }
                        //PriorityChSubDistrict = dsPriorityContact.Tables[0].Rows[0]["ChSubDistrict"].ToString();
                        //PriorityChCity = dsPriorityContact.Tables[0].Rows[0]["ChCity"].ToString();
                        //PriorityChProvince = dsPriorityContact.Tables[0].Rows[0]["ChProvince"].ToString();
                        int PriorityChProvin = Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"]);
                        if (objcommon.GetProvinceByTertID(PriorityChProvin).Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                PriorityChProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsClient.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceNameChinese"].ToString();
                            }
                            catch
                            {
                            }
                         }
                        PriorityChPostalCode = dsPriorityContact.Tables[0].Rows[0]["ChPostalCode"].ToString();
                        string CountryPr = dsPriorityContact.Tables[0].Rows[0]["Country"].ToString();
                        if (objcommon.GetTerritoryByCode(CountryPr).Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                PriorityCountry = objcommon.GetTerritoryByCode(dsPriorityContact.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                            }
                            catch
                            {
                            }
                         }
                        string CountrychPr = dsPriorityContact.Tables[0].Rows[0]["Country"].ToString();
                        if (objcommon.GetTerritoryByCode(CountrychPr).Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                PriorityChineseCountry = objcommon.GetTerritoryByCode(dsPriorityContact.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryNameChinese"].ToString();
                            }
                            catch
                            {
                            }
                        }


                        //PriorityCountry = objcommon.GetTerritoryByCode(dsPriorityContact.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        //already commented    // PriorityChineseCountry = objcommon.GetTerritoryByCode(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        //already commented     //PriorityDept = objcommon.GetDepartment(dsPriorityContact.Tables[0].Rows[0]["Dept"].ToString(), null).Tables[0].Rows[0]["DeptName"].ToString();
                        PriorityDept = dsPriorityContact.Tables[0].Rows[0]["Dept"].ToString();
                        PriorityDirectLineCode = dsPriorityContact.Tables[0].Rows[0]["DirectLineCode"].ToString();
                        PriorityDirectLineNo = dsPriorityContact.Tables[0].Rows[0]["DirectLineNo"].ToString();
                        PriorityEffectiveFromDate = dsPriorityContact.Tables[0].Rows[0]["EffectivefromDate"].ToString();
                        PriorityEffectiveToDate = dsPriorityContact.Tables[0].Rows[0]["Effectivetodate"].ToString();
                        PriorityEmail = dsPriorityContact.Tables[0].Rows[0]["Email"].ToString();
                        PriorityExtension = dsPriorityContact.Tables[0].Rows[0]["Extension"].ToString();
                        PriorityFaxCode = dsPriorityContact.Tables[0].Rows[0]["FaxNoCode"].ToString();
                        PriorityFaxNo = dsPriorityContact.Tables[0].Rows[0]["FaxNo"].ToString();
                        PriorityFirstName = dsPriorityContact.Tables[0].Rows[0]["FirstName"].ToString();
                        PriorityGeneralLineCode = dsPriorityContact.Tables[0].Rows[0]["GeneralLineCode"].ToString();
                        PriorityGeneralLineNo = dsPriorityContact.Tables[0].Rows[0]["GeneralLineNo"].ToString();
                        PriorityJobTitle = dsPriorityContact.Tables[0].Rows[0]["JobTitle"].ToString();
                        PriorityLastName = dsPriorityContact.Tables[0].Rows[0]["LastName"].ToString();
                        PriorityMobileCode = dsPriorityContact.Tables[0].Rows[0]["MobileNoCode"].ToString();
                        PriorityMobileNo = dsPriorityContact.Tables[0].Rows[0]["MobileNo"].ToString();
                        // PriorityTeam = objcommon.GetTeam(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Team"])).Tables[0].Rows[0]["TeamName"].ToString();
                        PrioritySalutation = dsPriorityContact.Tables[0].Rows[0]["Salutation"].ToString();
                        PriorityChSalutation = dsPriorityContact.Tables[0].Rows[0]["ChSalutation"].ToString();
                    }
                    if (dsClient.Tables.Count > 1)
                    {
                        if (dsClient.Tables[1].Rows.Count > 0)
                            GetApprovalDetails(dsClient.Tables[1]);
                    }
                    //GetApprovalDetails(dsClient.Tables[1]);
                    GetTimestampDetails(dsClient);
                    //
                    ereEvents.ShowPageNumber = true;
                    //ereEvents.PrintFooter = false;
                    ereEvents.UWCOPY = false;
                    CreateClientPDF(dRow);
                    docPDF.NewPage();
                }


            }
            catch (Exception ex)
            {
                string strTemp = ex.Message;
                blCreationSuccess = false;
            }
            finally
            {
                closeDoc();
            }
            return blCreationSuccess;

        }
        private Table getClientFirstTable()
        {
            Table tblFirstSec = new Table(4);
            int[] flColWidth = { 20, 30, 20, 30 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 2;

            strText = "Client Information";
            clCurrCell = getCell(strText, "NOTECH", "Center", "CENTER", 4, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "Client Information";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.AddCell(new Phrase("Client Code", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Code, fontThaiSmall));

            //commented
            tblFirstSec.AddCell(new Phrase(""));
            tblFirstSec.AddCell(new Phrase(""));

            //tblFirstSec.AddCell(new Phrase("Account Type", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(AccountType, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //end

            //tblFirstSec.AddCell(new Phrase("Description", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(Description, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Client Name", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Name, fontThaiSmall));

            //commented
            tblFirstSec.AddCell(new Phrase(""));
            tblFirstSec.AddCell(new Phrase(""));
            //tblFirstSec.AddCell(new Phrase("Normal Balance", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(NormalBal, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //end

            tblFirstSec.AddCell(new Phrase("Client Type", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(ClientType, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Record Type", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(RecordType, fontThaiSmall));

            //commented
            tblFirstSec.AddCell(new Phrase(""));
            tblFirstSec.AddCell(new Phrase(""));
            //tblFirstSec.AddCell(new Phrase("Debtor Control A/C", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(CreditControlAC, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //end
            //Dynamic
            if (RecordType == "Individual")
            {
                tblFirstSec.AddCell(new Phrase("Nationality", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Nationality, fontThaiSmall));

                //commented
                tblFirstSec.AddCell(new Phrase(""));
                tblFirstSec.AddCell(new Phrase(""));
                //tblFirstSec.AddCell(new Phrase("Source Of Business", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(sourceOfBusiness, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                tblFirstSec.AddCell(new Phrase("Passport/ID number", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(passportno, fontThaiSmall));

                //commented
                tblFirstSec.AddCell(new Phrase(""));
                tblFirstSec.AddCell(new Phrase(""));
                //tblFirstSec.AddCell(new Phrase("Master Source Code", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(MasterSourceCode, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                tblFirstSec.AddCell(new Phrase("Date of Birth", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase("DD" + day + "MM" + month + "YYYY" + year, fontThaiSmall));

                //commented
                tblFirstSec.AddCell(new Phrase(""));
                tblFirstSec.AddCell(new Phrase(""));
                //tblFirstSec.AddCell(new Phrase("Subsidiary Source Code1", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(subsidiarySourceCode1, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                tblFirstSec.AddCell(new Phrase("Gender", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Gender, fontThaiSmall));

                //commented
                tblFirstSec.AddCell(new Phrase(""));
                tblFirstSec.AddCell(new Phrase(""));
                //tblFirstSec.AddCell(new Phrase("Subsidiary Source Code2", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(subsidiarySourceCode2, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                tblFirstSec.AddCell(new Phrase("Marital Status", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(maritalstatus, fontThaiSmall));

                //commented
                tblFirstSec.AddCell(new Phrase(""));
                tblFirstSec.AddCell(new Phrase(""));
                //tblFirstSec.AddCell(new Phrase("Source Code", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(sourceCodeMaster, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                tblFirstSec.AddCell(new Phrase("Occupation", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(occupation, fontThaiSmall));

                //commented
                tblFirstSec.AddCell(new Phrase(""));
                tblFirstSec.AddCell(new Phrase(""));
                //tblFirstSec.AddCell(new Phrase("Business Nature Code", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(BusinessNatureCode, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                //commented
                ////tblFirstSec.AddCell(new Phrase("Group(for analysis purpose)", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                ////tblFirstSec.AddCell(new Phrase(group, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                ////end

                //commented
                //tblFirstSec.AddCell(new Phrase("Group", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(group, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                //commented             
                //tblFirstSec.AddCell(new Phrase("Sub-Group(for analysis purpose)", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(subGroup, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                //commented
                //tblFirstSec.AddCell(new Phrase("Sub-Group", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(subGroup, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                tblFirstSec.AddCell(new Phrase("General Line", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(GeneralLineCode + "-" + GeneralLineNo, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

                tblFirstSec.AddCell(new Phrase("Fax", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(FaxCode + "-" + FaxNo, fontThaiSmall));


                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

                tblFirstSec.AddCell(new Phrase("Email", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Email, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            }
            else
            {
                tblFirstSec.AddCell(new Phrase("Company Registration Number", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CompRegistrationNo, fontThaiSmall));

                //commented
                tblFirstSec.AddCell(new Phrase(""));
                tblFirstSec.AddCell(new Phrase(""));
                //tblFirstSec.AddCell(new Phrase("Source Of Business", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(sourceOfBusiness, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                tblFirstSec.AddCell(new Phrase("Business Registration Number", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BusiRegistrationNo, fontThaiSmall));

                //commented
                tblFirstSec.AddCell(new Phrase(""));
                tblFirstSec.AddCell(new Phrase(""));
                //tblFirstSec.AddCell(new Phrase("Master Source Code", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(MasterSourceCode, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                tblFirstSec.AddCell(new Phrase("General Line", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(GeneralLineCode + "-" + GeneralLineNo, fontThaiSmall));

                //commented
                tblFirstSec.AddCell(new Phrase(""));
                tblFirstSec.AddCell(new Phrase(""));
                //tblFirstSec.AddCell(new Phrase("Subsidiary Source Code1", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(subsidiarySourceCode1, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                tblFirstSec.AddCell(new Phrase("Fax", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(FaxCode + "-" + FaxNo, fontThaiSmall));

                //commented
                tblFirstSec.AddCell(new Phrase(""));
                tblFirstSec.AddCell(new Phrase(""));
                //tblFirstSec.AddCell(new Phrase("Subsidiary Source Code2", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(subsidiarySourceCode2, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                tblFirstSec.AddCell(new Phrase("Company Email", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Email, fontThaiSmall));

                //commented
                tblFirstSec.AddCell(new Phrase(""));
                tblFirstSec.AddCell(new Phrase(""));
                //tblFirstSec.AddCell(new Phrase("Source Code", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(sourceCodeMaster, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                tblFirstSec.AddCell(new Phrase("VIP Type", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(VIPType, fontThaiSmall));

                //commented
                tblFirstSec.AddCell(new Phrase(""));
                tblFirstSec.AddCell(new Phrase(""));
                //tblFirstSec.AddCell(new Phrase("Business Nature Code", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(BusinessNatureCode, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                //commented
                //tblFirstSec.AddCell(new Phrase("Group(for analysis purpose)", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(group, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                //commented
                //tblFirstSec.AddCell(new Phrase("Group", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(group, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                //commented
                //tblFirstSec.AddCell(new Phrase("Sub-Group(for analysis purpose)", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(subGroup, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //end

                ////commented
                ////tblFirstSec.AddCell(new Phrase("Sub-Group", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                ////tblFirstSec.AddCell(new Phrase(subGroup, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                ////end


            }
            //


            tblFirstSec.AddCell(new Phrase("Effective From Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(EffectiveFromDate, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Effective To Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(EffectiveToDate, fontThaiSmall));
            //Second Heading
            strText = "Client Address";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);
            if (IsChineseRequired == "Y")
            {
                strText = "ที่อยู่ลูกค้า";
                clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress4, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("แขวง/ตำบล", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrChSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrCity, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("เขต/อำเภอ", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("จังหวัด", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("รหัสไปรษณีย์", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Country, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("ประเทศ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress4, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(BillSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("แขวง/ตำบล", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(BillChSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(BillCity, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("เขต/อำเภอ", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(BillChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("จังหวัด", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("รหัสไปรษณีย์", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("ประเทศ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));
            }
            else
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress4, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrChSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrCity, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Country, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress4, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(BillSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(BillChSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(BillCity, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("เDistrict", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(BillChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));
            }
            return tblFirstSec;
        }
        private void CreateClientPDF(DataRow dr)
        {
            Table tblContent = new Table(1);
            tblContent.AutoFillEmptyCells = true;
            tblContent.WidthPercentage = 100;
            tblContent.Border = Table.NO_BORDER;
            tblContent.Cellspacing = 2;
            tblContent.DefaultCellBorder = Cell.NO_BORDER;
            tblContent.InsertTable(getClientFirstTable());
            docPDF.Add(tblContent);


            Table tblContent2 = new Table(1);
            tblContent2.AutoFillEmptyCells = true;
            tblContent2.WidthPercentage = 100;
            tblContent2.Border = Table.NO_BORDER;
            tblContent2.Cellspacing = 2;
            tblContent2.DefaultCellBorder = Cell.NO_BORDER;
            tblContent2.InsertTable(getPriorityContactTable());
            docPDF.Add(tblContent2);

            Table tblContent3 = new Table(1);
            tblContent3.AutoFillEmptyCells = true;
            tblContent3.WidthPercentage = 100;
            tblContent3.Border = Table.NO_BORDER;
            tblContent3.Cellspacing = 2;
            tblContent3.DefaultCellBorder = Cell.NO_BORDER;
            tblContent3.InsertTable(getApprovalTable());
            docPDF.Add(tblContent3);

            Table tblContent4 = new Table(1);
            tblContent4.AutoFillEmptyCells = true;
            tblContent4.WidthPercentage = 100;
            tblContent4.Border = Table.NO_BORDER;
            tblContent4.Cellspacing = 2;
            tblContent4.DefaultCellBorder = Cell.NO_BORDER;
            tblContent4.InsertTable(getTimeStampTable());
            docPDF.Add(tblContent4);

        }
        public bool CreateUnderwriterRequestApprovalPDF(clsUnApprovedInfo objUnaprvedInfo, UnApprovedContacts objUnapprContact)
        {
            bool blCreationSuccess = true;
            ereEvents = new PDFGeneratorEvents();
            try
            {
                createAndOpenNewDoc();
                objUWBAL = new clsUnderwriterManager();
                dsUnderwriter = objUWBAL.getUnApprovedUWList(objUnaprvedInfo);
                dsPriorityContact = new DataSet();
                dsPriorityContact = objUWBAL.getUnApprovUWContacts(objUnapprContact);
                foreach (DataRow dRow in dsUnderwriter.Tables[0].Rows)
                {

                    //RejectReason = dsAgent.Tables[0].Rows[0]["RejectReason"].ToString();

                   try{ Code = dsUnderwriter.Tables[0].Rows[0]["UnderwriterCode"].ToString();}catch { }
                   try{ Name = dsUnderwriter.Tables[0].Rows[0]["UnderwriterName"].ToString();}catch { }
                    try{ChName = dsUnderwriter.Tables[0].Rows[0]["ChUnderwriterName"].ToString();}catch { }
                    try{CorrAddress1 = dsUnderwriter.Tables[0].Rows[0]["CorrAddress1"].ToString();}catch { }
                   try{ CorrAddress2 = dsUnderwriter.Tables[0].Rows[0]["CorrAddress2"].ToString();}catch { }
                    try{CorrAddress3 = dsUnderwriter.Tables[0].Rows[0]["CorrAddress3"].ToString();}catch { }
                    try{CorrAddress4 = dsUnderwriter.Tables[0].Rows[0]["CorrAddress4"].ToString();}catch { }
                   try{ ChineseCorrAddress1 = dsUnderwriter.Tables[0].Rows[0]["ChCorrAddress1"].ToString();}catch { }
                   try{ ChineseCorrAddress2 = dsUnderwriter.Tables[0].Rows[0]["ChCorrAddress2"].ToString();}catch { }
                    try{ChineseCorrAddress3 = dsUnderwriter.Tables[0].Rows[0]["ChCorrAddress3"].ToString();}catch { }
                    try { ChineseCorrAddress4 = dsUnderwriter.Tables[0].Rows[0]["ChCorrAddress3"].ToString(); }
                    catch { }
                    try { 
                    if (dsUnderwriter.Tables[0].Rows[0]["SubDistrict"].ToString() == "Please Select")
                    {
                        CorrSubDistrict = "";
                    }
                    else
                    {
                        CorrSubDistrict = dsUnderwriter.Tables[0].Rows[0]["SubDistrict"].ToString();
                    }
                    }
                    catch { }
                    try { 
                    if (dsUnderwriter.Tables[0].Rows[0]["City"].ToString() == "Please Select")
                    {
                        CorrCity = "";
                    }
                    else
                    {
                        CorrCity = dsUnderwriter.Tables[0].Rows[0]["City"].ToString();
                    }
                    }
                    catch { }
                    //CorrSubDistrict = dsUnderwriter.Tables[0].Rows[0]["SubDistrict"].ToString();
                    //CorrCity = dsUnderwriter.Tables[0].Rows[0]["City"].ToString();

                    int CorrProvinc = 0;
                    try{CorrProvinc = Convert.ToInt32(dsUnderwriter.Tables[0].Rows[0]["Country"]);}catch { }
                    if (objcommon.GetProvinceByTertID(CorrProvinc).Tables[0].Rows.Count > 0)
                    {
                        try { CorrProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsUnderwriter.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceName"].ToString(); }
                        catch { }
                    }
                    //CorrProvince = dsUnderwriter.Tables[0].Rows[0]["Province"].ToString();
                    try { CorrPostalCode = dsUnderwriter.Tables[0].Rows[0]["PostalCode"].ToString(); }
                    catch { }

                    if (dsUnderwriter.Tables[0].Rows[0]["ChSubDistrict"].ToString() == "Please Select")
                    {
                        CorrChSubDistrict = "";
                    }
                    else
                    {
                        try { CorrChSubDistrict = dsUnderwriter.Tables[0].Rows[0]["ChSubDistrict"].ToString(); }
                        catch { }
                    }

                    if (dsUnderwriter.Tables[0].Rows[0]["ChCity"].ToString() == "Please Select")
                    {
                        CorrChCity = "";
                    }
                    else
                    {
                        try { CorrChCity = dsUnderwriter.Tables[0].Rows[0]["ChCity"].ToString(); }
                        catch { }
                    }
                    //CorrChSubDistrict = dsUnderwriter.Tables[0].Rows[0]["ChSubDistrict"].ToString();
                    //CorrChCity = dsUnderwriter.Tables[0].Rows[0]["ChCity"].ToString();

                    int CorrChProvinc = 0;
                    try
                    {
                        CorrChProvinc = Convert.ToInt32(dsUnderwriter.Tables[0].Rows[0]["Country"]);
                    }
                    catch { }
                    if (objcommon.GetProvinceByTertID(CorrProvinc).Tables[0].Rows.Count > 0)
                    {
                       try {CorrChProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsUnderwriter.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceNameChinese"].ToString();}
                    catch { }
                    }
                   // CorrChProvince = dsUnderwriter.Tables[0].Rows[0]["ChProvince"].ToString();
                    try{CorrChPostalCode = dsUnderwriter.Tables[0].Rows[0]["ChPostalCode"].ToString();}
                    catch { }
                    try{
                    if (dsUnderwriter.Tables[0].Rows[0]["BillingSubDistrict"].ToString() == "Please Select")
                    {
                        BillSubDistrict = "";
                    }
                    else
                    {
                        BillSubDistrict = dsUnderwriter.Tables[0].Rows[0]["BillingSubDistrict"].ToString();
                    }
                    }catch { }
                    try{
                    if (dsUnderwriter.Tables[0].Rows[0]["BillingCity"].ToString() == "Please Select")
                    {
                        BillCity = "";
                    }
                    else
                    {
                        BillCity = dsUnderwriter.Tables[0].Rows[0]["BillingCity"].ToString();
                    }
                    }catch { }
                    //BillSubDistrict = dsUnderwriter.Tables[0].Rows[0]["BillingSubDistrict"].ToString();
                    //BillCity = dsUnderwriter.Tables[0].Rows[0]["BillingCity"].ToString();
                    int BillProvinc = 0;
                    try { BillProvinc = Convert.ToInt32(dsUnderwriter.Tables[0].Rows[0]["Country"]);}catch { }
                    try{
                    if (objcommon.GetProvinceByTertID(BillProvinc).Tables[0].Rows.Count > 0)
                    {
                        BillProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsUnderwriter.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceName"].ToString();
                    }
                        }
                    catch { }
                    //BillProvince = dsUnderwriter.Tables[0].Rows[0]["BillingProvince"].ToString();
                   try{ BillPostalCode = dsUnderwriter.Tables[0].Rows[0]["BillingPostalCode"].ToString();}catch { }
                    try{
                    if (dsUnderwriter.Tables[0].Rows[0]["ChBillingSubDistrict"].ToString() == "Please Select")
                    {
                        BillChSubDistrict = "";
                    }
                    else
                    {
                        BillChSubDistrict = dsUnderwriter.Tables[0].Rows[0]["ChBillingSubDistrict"].ToString();
                    }
                    }catch{}

                    try{
                    if (dsUnderwriter.Tables[0].Rows[0]["ChBillingCity"].ToString() == "Please Select")
                    {
                        BillChCity = "";
                    }
                    else
                    {
                        BillChCity = dsUnderwriter.Tables[0].Rows[0]["ChBillingCity"].ToString();
                    }
                     }catch{}
                    //BillChSubDistrict = dsUnderwriter.Tables[0].Rows[0]["ChBillingSubDistrict"].ToString();
                    //BillChCity = dsUnderwriter.Tables[0].Rows[0]["ChBillingCity"].ToString();

                    try { BillChProvince = dsUnderwriter.Tables[0].Rows[0]["ChBillingProvince"].ToString(); }
                    catch { }
                      try{BillChPostalCode = dsUnderwriter.Tables[0].Rows[0]["ChBillingPostalCode"].ToString();}catch{}

                    try
                    {
                        Country = objcommon.GetTerritory(Convert.ToInt32(dsUnderwriter.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["TerritoryName"].ToString();
                    }
                    catch 
                    {
                        Country = "";
                    }
                    try
                    {
                        ChineseCountry = objcommon.GetTerritory(Convert.ToInt32(dsUnderwriter.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["TerritoryNameChinese"].ToString();
                    }
                    catch { ChineseCountry = ""; }
                    //Country= dsAgent.Tables[0].Rows[0]["Country"].ToString();
                    try
                    {
                        ChCountry = objcommon.GetTerritory(Convert.ToInt32(dsUnderwriter.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["TerritoryNameChinese"].ToString();

                    }
                    catch { ChCountry = ""; }
                    try { BillingAddress1 = dsUnderwriter.Tables[0].Rows[0]["BillingAddress1"].ToString();}catch { }
                    try {BillingAddress2 = dsUnderwriter.Tables[0].Rows[0]["BillingAddress2"].ToString();}catch { }
                    try {BillingAddress3 = dsUnderwriter.Tables[0].Rows[0]["BillingAddress3"].ToString();}catch { }
                    try {BillingAddress4 = dsUnderwriter.Tables[0].Rows[0]["BillingAddress4"].ToString();}catch { }
                    try {ChineseBillingAddress1 = dsUnderwriter.Tables[0].Rows[0]["ChBillingAddress1"].ToString();}catch { }
                    try {ChineseBillingAddress2 = dsUnderwriter.Tables[0].Rows[0]["ChBillingAddress2"].ToString();}catch { }
                    try {ChineseBillingAddress3 = dsUnderwriter.Tables[0].Rows[0]["ChBillingAddress3"].ToString();}catch { }
                    try { ChineseBillingAddress4 = dsUnderwriter.Tables[0].Rows[0]["ChBillingAddress3"].ToString(); }
                    catch { }
                    try
                    {
                        BillingCountry = objcommon.GetTerritory(Convert.ToInt32(dsUnderwriter.Tables[0].Rows[0]["BillingCountry"])).Tables[0].Rows[0]["TerritoryName"].ToString();

                    }catch { }
                    try{
                        ChineseBillingCountry = objcommon.GetTerritory(Convert.ToInt32(dsUnderwriter.Tables[0].Rows[0]["BillingCountry"])).Tables[0].Rows[0]["TerritoryNameChinese"].ToString();
                    }catch { }
                    try { Description = dsUnderwriter.Tables[0].Rows[0]["UnderwriterDescription"].ToString(); }catch { }
                    try {GeneralLineCode = dsUnderwriter.Tables[0].Rows[0]["GeneralLineCode"].ToString();}catch{}
                    try {GeneralLineNo = dsUnderwriter.Tables[0].Rows[0]["GeneralLineNo"].ToString();}catch{}

                    try {RecordType = dsUnderwriter.Tables[0].Rows[0]["RecordType"].ToString();}catch{}
                    try {FaxCode = dsUnderwriter.Tables[0].Rows[0]["FaxNoCode"].ToString();}catch{}
                    try {FaxNo = dsUnderwriter.Tables[0].Rows[0]["FaxNo"].ToString();}catch{}

                    try {CompRegistrationNo = dsUnderwriter.Tables[0].Rows[0]["CompanyRegistrationNo"].ToString();}catch{}
                    //RegDate = dsAgent.Tables[0].Rows[0]["RegistrationDate"].ToString();
                    try {BusiRegistrationNo = dsUnderwriter.Tables[0].Rows[0]["BusinessRegistrationNo"].ToString();}catch{}
                    try {RegDate = dsUnderwriter.Tables[0].Rows[0]["RegistrationDate"].ToString();}catch{}
                    try {Email = dsUnderwriter.Tables[0].Rows[0]["Email"].ToString();}catch{}

                    try {AccountType = dsUnderwriter.Tables[0].Rows[0]["AccountType"].ToString();}catch{}
                    try {NormalBal = dsUnderwriter.Tables[0].Rows[0]["NormalBalance"].ToString();}catch{}
                    try {CreditControlAC = dsUnderwriter.Tables[0].Rows[0]["CreditControlAccountNo"].ToString();}catch{}
                    try {Remarks = dsUnderwriter.Tables[0].Rows[0]["Remarks"].ToString();}catch{}

                   try { EffectiveFromDate = Convert.ToString(dsUnderwriter.Tables[0].Rows[0]["EffectivefromDate"]);}catch{}
                    try {EffectiveToDate = Convert.ToString(dsUnderwriter.Tables[0].Rows[0]["Effectivetodate"]);}catch{}
                    try{
                    if (Convert.ToString(dsUnderwriter.Tables[0].Rows[0]["Premium_Settlement"]).Equals("N") == true)
                    {
                        Premium_settlement = "Net";
                    }
                    else if (Convert.ToString(dsUnderwriter.Tables[0].Rows[0]["Premium_Settlement"]).Equals("G") == true)
                    {
                        Premium_settlement = "Gross";
                    }
                      }catch{}
                    foreach (DataRow dataRow in dsPriorityContact.Tables[0].Rows)
                    {
                        try
                        {
                            PriorityTeam = objcommon.GetTeam(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Team"])).Tables[0].Rows[0]["TeamName"].ToString();
                        }catch {}

                        try { PriorityChineseCorrAddress1 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress1"].ToString(); }
                        catch { }
                        try{PriorityChineseCorrAddress2 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress2"].ToString();}catch{}
                        try{PriorityChineseCorrAddress3 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress3"].ToString();}catch{}
                        try{PriorityChineseCorrAddress4 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress3"].ToString();}catch{}

                        int ChineseCt=0;
                        try{
                            ChineseCt = Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"]);
                        }catch{}
                       
                       try {
                        if (objcommon.GetTerritory(ChineseCt).Tables[0].Rows.Count > 0)
                        {
                            
                          PriorityChineseCountry = objcommon.GetTerritory(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"])).Tables[0].Rows[0]["TerritoryNameChinese"].ToString();
                            
                        }
                           }
                            catch { }
                        try{PriorityChineseDept = dsPriorityContact.Tables[0].Rows[0]["ChDept"].ToString();}catch { }
                        try{PriorityChineseFirstName = dsPriorityContact.Tables[0].Rows[0]["ChFirstName"].ToString();}catch { }
                        try{PriorityChineseJobTitle = dsPriorityContact.Tables[0].Rows[0]["ChJobTitle"].ToString();}catch { }
                        try{PriorityChineseLastName = dsPriorityContact.Tables[0].Rows[0]["ChLastName"].ToString();}catch { }
                        try{PriorityCorrAddress1 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress1"].ToString();}catch { }
                        try{PriorityCorrAddress2 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress2"].ToString();}catch { }
                        try{PriorityCorrAddress3 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress3"].ToString();}catch { }
                        try { PriorityCorrAddress4 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress4"].ToString(); }
                        catch { }
                        try{
                        if (dsPriorityContact.Tables[0].Rows[0]["SubDistrict"].ToString() == "Please Select")
                        {
                            PrioritySubDistrict = "";
                        }
                        else
                        {
                            PrioritySubDistrict = dsPriorityContact.Tables[0].Rows[0]["SubDistrict"].ToString();
                        }
                            }
                            catch { }
                        try{
                        if (dsPriorityContact.Tables[0].Rows[0]["City"].ToString() == "Please Select")
                        {
                            PriorityCity = "";
                        }
                        else
                        {
                            PriorityCity = dsPriorityContact.Tables[0].Rows[0]["City"].ToString();
                        }
                            }
                            catch { }
                        //PrioritySubDistrict = dsPriorityContact.Tables[0].Rows[0]["SubDistrict"].ToString();
                        //PriorityCity = dsPriorityContact.Tables[0].Rows[0]["City"].ToString();
                        int PriorityProvinc = 0;
                        try
                        {
                            PriorityProvinc = Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Country"]);
                        }
                        catch {}
                        try{
                        if (objcommon.GetProvinceByTertID(PriorityProvinc).Tables[0].Rows.Count > 0)
                        {
                            PriorityProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceName"].ToString();
                        }
                            }
                            catch { }
                       // PriorityProvince = dsPriorityContact.Tables[0].Rows[0]["Province"].ToString();
                        try{
                        PriorityPostalCode = dsPriorityContact.Tables[0].Rows[0]["PostalCode"].ToString();
                            }
                            catch { }
                        try{
                        if (dsPriorityContact.Tables[0].Rows[0]["ChSubDistrict"].ToString() == "Please Select")
                        {
                            PriorityChSubDistrict = "";
                        }
                        else
                        {
                            PriorityChSubDistrict = dsPriorityContact.Tables[0].Rows[0]["ChSubDistrict"].ToString();
                        }
                            }
                            catch { }

                        try{
                        if (dsPriorityContact.Tables[0].Rows[0]["ChCity"].ToString() == "Please Select")
                        {
                            PriorityChCity = "";
                        }
                        else
                        {
                            PriorityChCity = dsPriorityContact.Tables[0].Rows[0]["ChCity"].ToString();
                        }
                            }
                            catch { }
                        //PriorityChSubDistrict = dsPriorityContact.Tables[0].Rows[0]["ChSubDistrict"].ToString();
                        //PriorityChCity = dsPriorityContact.Tables[0].Rows[0]["ChCity"].ToString();
                        int PriorityChProvinc = 0;
                        try
                        {
                           PriorityChProvinc = Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Country"]);
                        }
                        catch { }
                       try{
                        if (objcommon.GetProvinceByTertID(CorrProvinc).Tables[0].Rows.Count > 0)
                        {
                            PriorityChProvince = objcommon.GetProvinceByTertID(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["ProvinceNameChinese"].ToString();
                        }
                           }
                            catch { }
                        //PriorityChProvince = dsPriorityContact.Tables[0].Rows[0]["ChProvince"].ToString();
                       try
                       { PriorityChPostalCode = dsPriorityContact.Tables[0].Rows[0]["ChPostalCode"].ToString(); }
                       catch { }
                        try
                        {
                            PriorityCountry = objcommon.GetTerritory(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Country"])).Tables[0].Rows[0]["TerritoryName"].ToString();

                        } catch { }
                        // PriorityChineseCountry = objcommon.GetTerritoryByCode(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        //PriorityDept = objcommon.GetDepartment(dsPriorityContact.Tables[0].Rows[0]["Dept"].ToString(), null).Tables[0].Rows[0]["DeptName"].ToString();
                       try
                        { PriorityDept = dsPriorityContact.Tables[0].Rows[0]["Dept"].ToString();} catch { }
                       try
                        { PriorityDirectLineCode = dsPriorityContact.Tables[0].Rows[0]["DirectLineCode"].ToString();} catch { }
                       try
                        { PriorityDirectLineNo = dsPriorityContact.Tables[0].Rows[0]["DirectLineNo"].ToString();} catch { }
                        try
                        {PriorityEffectiveFromDate = dsPriorityContact.Tables[0].Rows[0]["EffectivefromDate"].ToString();} catch { }
                       try
                        { PriorityEffectiveToDate = dsPriorityContact.Tables[0].Rows[0]["Effectivetodate"].ToString();} catch { }
                       try
                        { PriorityEmail = dsPriorityContact.Tables[0].Rows[0]["Email"].ToString();} catch { }
                       try
                        { PriorityExtension = dsPriorityContact.Tables[0].Rows[0]["Extension"].ToString();} catch { }
                        try
                        {PriorityFaxCode = dsPriorityContact.Tables[0].Rows[0]["FaxNoCode"].ToString();} catch { }
                        try
                        {PriorityFaxNo = dsPriorityContact.Tables[0].Rows[0]["FaxNo"].ToString();} catch { }
                        try
                        {PriorityFirstName = dsPriorityContact.Tables[0].Rows[0]["FirstName"].ToString();} catch { }
                        try
                        {PriorityGeneralLineCode = dsPriorityContact.Tables[0].Rows[0]["GeneralLineCode"].ToString();} catch { }
                        try
                        {PriorityGeneralLineNo = dsPriorityContact.Tables[0].Rows[0]["GeneralLineNo"].ToString();} catch { }
                        try
                        {PriorityJobTitle = dsPriorityContact.Tables[0].Rows[0]["JobTitle"].ToString();} catch { }
                        try
                        {PriorityLastName = dsPriorityContact.Tables[0].Rows[0]["LastName"].ToString();} catch { }
                        try
                        {PriorityMobileCode = dsPriorityContact.Tables[0].Rows[0]["MobileNoCode"].ToString();} catch { }
                        try
                        {PriorityMobileNo = dsPriorityContact.Tables[0].Rows[0]["MobileNo"].ToString();} catch { }
                        // PriorityTeam = objcommon.GetTeam(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Team"])).Tables[0].Rows[0]["TeamName"].ToString();
                        try
                        {PrioritySalutation = dsPriorityContact.Tables[0].Rows[0]["Salutation"].ToString();} catch { }
                        try
                        { PriorityChSalutation = dsPriorityContact.Tables[0].Rows[0]["ChSalutation"].ToString(); }
                        catch { }
                    }
                    if (dsUnderwriter.Tables.Count > 1)
                    {
                        if (dsUnderwriter.Tables[1].Rows.Count > 0)
                            GetApprovalDetails(dsUnderwriter.Tables[1]);
                    }
                    //GetApprovalDetails(dsUnderwriter.Tables[1]);
                    GetTimestampDetails(dsUnderwriter);
                    //
                    ereEvents.ShowPageNumber = true;
                    //ereEvents.PrintFooter = false;
                    ereEvents.UWCOPY = false;
                    CreateUnderwriterPDF(dRow);
                    docPDF.NewPage();
                }


            }
            catch (Exception ex)
            {
                string strTemp = ex.Message;
                blCreationSuccess = false;
            }
            finally
            {
                closeDoc();
            }
            return blCreationSuccess;

        }
        private void CreateUnderwriterPDF(DataRow dr)
        {
            Table tblContent = new Table(1);
            tblContent.AutoFillEmptyCells = true;
            tblContent.WidthPercentage = 100;
            tblContent.Border = Table.NO_BORDER;
            tblContent.Cellspacing = 2;
            tblContent.DefaultCellBorder = Cell.NO_BORDER;
            tblContent.InsertTable(getUnderwriterFirstTable());
            docPDF.Add(tblContent);


            Table tblContent2 = new Table(1);
            tblContent2.AutoFillEmptyCells = true;
            tblContent2.WidthPercentage = 100;
            tblContent2.Border = Table.NO_BORDER;
            tblContent2.Cellspacing = 2;
            tblContent2.DefaultCellBorder = Cell.NO_BORDER;
            tblContent2.InsertTable(getPriorityContactTable());
            docPDF.Add(tblContent2);

            Table tblContent3 = new Table(1);
            tblContent3.AutoFillEmptyCells = true;
            tblContent3.WidthPercentage = 100;
            tblContent3.Border = Table.NO_BORDER;
            tblContent3.Cellspacing = 2;
            tblContent3.DefaultCellBorder = Cell.NO_BORDER;
            tblContent3.InsertTable(getApprovalTable());
            docPDF.Add(tblContent3);

            Table tblContent4 = new Table(1);
            tblContent4.AutoFillEmptyCells = true;
            tblContent4.WidthPercentage = 100;
            tblContent4.Border = Table.NO_BORDER;
            tblContent4.Cellspacing = 2;
            tblContent4.DefaultCellBorder = Cell.NO_BORDER;
            tblContent4.InsertTable(getTimeStampTable());
            docPDF.Add(tblContent4);

        }
        private Table getUnderwriterFirstTable()
        {
            Table tblFirstSec = new Table(4);
            int[] flColWidth = { 20, 30, 20, 30 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 2;

            strText = "Insurer Information";
            clCurrCell = getCell(strText, "NOTECH", "Center", "CENTER", 4, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "Insurer Information";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            //strText = "Flex Control Account";
            strText = "";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.AddCell(new Phrase("Insurer Code", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Code, fontThaiSmall));

            // commented for remove flex related fields
            tblFirstSec.AddCell(new Phrase(""));
            tblFirstSec.AddCell(new Phrase(""));
            //tblFirstSec.AddCell(new Phrase("Account Type", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(AccountType, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //end

            //tblFirstSec.AddCell(new Phrase("Description", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(Description, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("Insurer Name", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Name, fontThaiSmall));


            // commented for remove flex related fields
            tblFirstSec.AddCell(new Phrase(""));
            tblFirstSec.AddCell(new Phrase(""));
            //tblFirstSec.AddCell(new Phrase("Normal Balance", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(NormalBal, new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //end

            tblFirstSec.AddCell(new Phrase("Record Type", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(RecordType, fontThaiSmall));

            // commented for remove flex related fields
            tblFirstSec.AddCell(new Phrase(""));
            tblFirstSec.AddCell(new Phrase(""));
            //tblFirstSec.AddCell(new Phrase("Credit Control A/C", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //end

            tblFirstSec.AddCell(new Phrase("Company Registration Number", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(CompRegistrationNo, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Date of Registration", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(RegDate, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));


            tblFirstSec.AddCell(new Phrase("Business Registration Number", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(BusiRegistrationNo, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("General Line", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(GeneralLineCode + "-" + GeneralLineNo, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Fax", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(FaxCode + "-" + FaxNo, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Company Email", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Email, fontThaiSmall));


            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Effective From Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(EffectiveFromDate, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Effective To Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(EffectiveToDate, fontThaiSmall));

            //added by kavita
            tblFirstSec.AddCell(new Phrase("Premium Settlement", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Premium_settlement, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase(""));
            tblFirstSec.AddCell(new Phrase(""));
            //end

            //Second Heading
            strText = "Insurer Address";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (IsChineseRequired == "Y")
            {
                strText = "ที่อยู่ผู้รับประกันภัย";
                clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //tblFirstSec.AddCell(new Phrase("Underwriter Name", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(Name, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

                //tblFirstSec.AddCell(new Phrase("Underwriter Name", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(ChName, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress4, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("แขวง/ตำบล", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrChSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrCity, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("เขต/อำเภอ", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("จังหวัด", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("รหัสไปรษณีย์", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Country, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("ประเทศ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillSubDistrict, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("แขวง/ตำบล", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChSubDistrict, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("เขต/อำเภอ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("จังหวัด", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("รหัสไปรษณีย์", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("ประเทศ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));
            }
            else
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                //tblFirstSec.AddCell(new Phrase("Underwriter Name", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(Name, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

                //tblFirstSec.AddCell(new Phrase("Underwriter Name", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
                //tblFirstSec.AddCell(new Phrase(ChName, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress4, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrChSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrCity, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(CorrChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Country, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress4, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address4", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress4, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(BillSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("Sub-District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(BillChSubDistrict, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(BillCity, fontThaiSmall));

                //tblFirstSec.AddCell(new Phrase("District", fontThaiSmall));
                //tblFirstSec.AddCell(new Phrase(BillChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

            }


            return tblFirstSec;
        }

        public bool CreateReinsurerRequestApprovalPDF(clsUnApprovedInfo objUnaprvedInfo, UnApprovedContacts objUnapprContact)
        {
            bool blCreationSuccess = true;
            ereEvents = new PDFGeneratorEvents();
            try
            {
                createAndOpenNewDoc();
                objReinsuerBAL = new clsReinsurerManager();
                dsReinsurer = objReinsuerBAL.getUnApprovReinsurerList(objUnaprvedInfo);
                dsPriorityContact = new DataSet();
                dsPriorityContact = objReinsuerBAL.getUnApprovReinsurerContacts(objUnapprContact);
                foreach (DataRow dRow in dsReinsurer.Tables[0].Rows)
                {

                    //RejectReason = dsAgent.Tables[0].Rows[0]["RejectReason"].ToString();

                    Code = dsReinsurer.Tables[0].Rows[0]["ReinsurerCode"].ToString();
                    Name = dsReinsurer.Tables[0].Rows[0]["ReinsurerName"].ToString();
                    ChName = dsReinsurer.Tables[0].Rows[0]["ChReinsurerName"].ToString();
                    CorrAddress1 = dsReinsurer.Tables[0].Rows[0]["CorrAddress1"].ToString();
                    CorrAddress2 = dsReinsurer.Tables[0].Rows[0]["CorrAddress2"].ToString();
                    CorrAddress3 = dsReinsurer.Tables[0].Rows[0]["CorrAddress3"].ToString();
                    ChineseCorrAddress1 = dsReinsurer.Tables[0].Rows[0]["ChCorrAddress1"].ToString();
                    ChineseCorrAddress2 = dsReinsurer.Tables[0].Rows[0]["ChCorrAddress2"].ToString();
                    ChineseCorrAddress3 = dsReinsurer.Tables[0].Rows[0]["ChCorrAddress3"].ToString();

                    if ((objcommon.GetTerritoryByCode(dsReinsurer.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows.Count) > 0)
                    {
                        Country = objcommon.GetTerritoryByCode(dsReinsurer.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        ChineseCountry = objcommon.GetTerritoryByCode(dsReinsurer.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        ChCountry = objcommon.GetTerritoryByCode(dsReinsurer.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                    }
                   //Country= dsAgent.Tables[0].Rows[0]["Country"].ToString();
                    BillingAddress1 = dsReinsurer.Tables[0].Rows[0]["BillingAddress1"].ToString();
                    BillingAddress2 = dsReinsurer.Tables[0].Rows[0]["BillingAddress2"].ToString();
                    BillingAddress3 = dsReinsurer.Tables[0].Rows[0]["BillingAddress3"].ToString();

                    ChineseBillingAddress1 = dsReinsurer.Tables[0].Rows[0]["ChBillingAddress1"].ToString();
                    ChineseBillingAddress2 = dsReinsurer.Tables[0].Rows[0]["ChBillingAddress2"].ToString();
                    ChineseBillingAddress3 = dsReinsurer.Tables[0].Rows[0]["ChBillingAddress3"].ToString();

                    CorrCity = dsReinsurer.Tables[0].Rows[0]["City"].ToString();
                    CorrProvince = dsReinsurer.Tables[0].Rows[0]["Province"].ToString();
                    CorrPostalCode = dsReinsurer.Tables[0].Rows[0]["PostalCode"].ToString();
                    CorrChCity = dsReinsurer.Tables[0].Rows[0]["ChCity"].ToString();
                    CorrChProvince = dsReinsurer.Tables[0].Rows[0]["ChProvince"].ToString();
                    CorrChPostalCode = dsReinsurer.Tables[0].Rows[0]["ChPostalCode"].ToString();

                    BillCity = dsReinsurer.Tables[0].Rows[0]["BillingCity"].ToString();
                    BillProvince = dsReinsurer.Tables[0].Rows[0]["BillingProvince"].ToString();
                    BillPostalCode = dsReinsurer.Tables[0].Rows[0]["BillingPostalCode"].ToString();
                    BillChCity = dsReinsurer.Tables[0].Rows[0]["ChBillingCity"].ToString();
                    BillChProvince = dsReinsurer.Tables[0].Rows[0]["ChBillingProvince"].ToString();
                    BillChPostalCode = dsReinsurer.Tables[0].Rows[0]["ChBillingPostalCode"].ToString();
                    if ((objcommon.GetTerritoryByCode(dsReinsurer.Tables[0].Rows[0]["BillingCountry"].ToString()).Tables[0].Rows.Count) > 0)
                    {
                        BillingCountry = objcommon.GetTerritoryByCode(dsReinsurer.Tables[0].Rows[0]["BillingCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        ChineseBillingCountry = objcommon.GetTerritoryByCode(dsReinsurer.Tables[0].Rows[0]["BillingCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();

                    } Description = dsReinsurer.Tables[0].Rows[0]["ReinsurerDescription"].ToString();
                    GeneralLineCode = dsReinsurer.Tables[0].Rows[0]["GeneralLineCode"].ToString();
                    GeneralLineNo = dsReinsurer.Tables[0].Rows[0]["GeneralLineNo"].ToString();

                    RecordType = dsReinsurer.Tables[0].Rows[0]["RecordType"].ToString();
                    FaxCode = dsReinsurer.Tables[0].Rows[0]["FaxNoCode"].ToString();
                    FaxNo = dsReinsurer.Tables[0].Rows[0]["FaxNo"].ToString();

                    CreditControlAC = dsReinsurer.Tables[0].Rows[0]["CreditControlAccountNo"].ToString();
                    ClaimAccType = dsReinsurer.Tables[0].Rows[0]["ClaimAccountType"].ToString();
                    ClaimNormalBal = dsReinsurer.Tables[0].Rows[0]["ClaimNormalBalance"].ToString();
                    ClaimDebitAcc = dsReinsurer.Tables[0].Rows[0]["ClaimDebitControlAccountNo"].ToString();
                    //RegDate = dsAgent.Tables[0].Rows[0]["RegistrationDate"].ToString();
                    BusiRegistrationNo = dsReinsurer.Tables[0].Rows[0]["BusinessRegistrationNo"].ToString();
                    //RegDate = dsReinsurer.Tables[0].Rows[0]["RegistrationDate"].ToString();
                    Email = dsReinsurer.Tables[0].Rows[0]["Email"].ToString();

                    AccountType = dsReinsurer.Tables[0].Rows[0]["AccountType"].ToString();
                    NormalBal = dsReinsurer.Tables[0].Rows[0]["NormalBalance"].ToString();
                    //CreditControlAC = dsReinsurer.Tables[0].Rows[0]["CreditControlAccountNo"].ToString();
                    Remarks = dsReinsurer.Tables[0].Rows[0]["Remarks"].ToString();

                    EffectiveFromDate = Convert.ToString(dsReinsurer.Tables[0].Rows[0]["EffectivefromDate"]);
                    EffectiveToDate = Convert.ToString(dsReinsurer.Tables[0].Rows[0]["Effectivetodate"]);
                    foreach (DataRow dataRow in dsPriorityContact.Tables[0].Rows)
                    {

                        PriorityTeam = objcommon.GetTeam(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Team"])).Tables[0].Rows[0]["TeamName"].ToString();
                        PriorityChineseCorrAddress1 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress1"].ToString();
                        PriorityChineseCorrAddress2 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress2"].ToString();
                        PriorityChineseCorrAddress3 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress3"].ToString();
                        PriorityChineseCountry = objcommon.GetTerritoryByCode(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        PriorityChineseDept = dsPriorityContact.Tables[0].Rows[0]["ChDept"].ToString();
                        PriorityChineseFirstName = dsPriorityContact.Tables[0].Rows[0]["ChFirstName"].ToString();
                        PriorityChineseJobTitle = dsPriorityContact.Tables[0].Rows[0]["ChJobTitle"].ToString();
                        PriorityChineseLastName = dsPriorityContact.Tables[0].Rows[0]["ChLastName"].ToString();
                        PriorityCorrAddress1 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress1"].ToString();
                        PriorityCorrAddress2 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress2"].ToString();
                        PriorityCorrAddress3 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress3"].ToString();


                        PriorityCity = dsPriorityContact.Tables[0].Rows[0]["City"].ToString();
                        PriorityProvince = dsPriorityContact.Tables[0].Rows[0]["Province"].ToString();
                        PriorityPostalCode = dsPriorityContact.Tables[0].Rows[0]["PostalCode"].ToString();
                        PriorityChCity = dsPriorityContact.Tables[0].Rows[0]["ChCity"].ToString();
                        PriorityChProvince = dsPriorityContact.Tables[0].Rows[0]["ChProvince"].ToString();
                        PriorityChPostalCode = dsPriorityContact.Tables[0].Rows[0]["ChPostalCode"].ToString();
                        if ((objcommon.GetTerritoryByCode(dsReinsurer.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows.Count) > 0)
                        {
                            PriorityCountry = objcommon.GetTerritoryByCode(dsPriorityContact.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        }  // PriorityChineseCountry = objcommon.GetTerritoryByCode(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        //PriorityDept = objcommon.GetDepartment(dsPriorityContact.Tables[0].Rows[0]["Dept"].ToString(), null).Tables[0].Rows[0]["DeptName"].ToString();
                        PriorityDirectLineCode = dsPriorityContact.Tables[0].Rows[0]["DirectLineCode"].ToString();
                        PriorityDirectLineNo = dsPriorityContact.Tables[0].Rows[0]["DirectLineNo"].ToString();
                        PriorityEffectiveFromDate = dsPriorityContact.Tables[0].Rows[0]["EffectivefromDate"].ToString();
                        PriorityEffectiveToDate = dsPriorityContact.Tables[0].Rows[0]["Effectivetodate"].ToString();
                        PriorityEmail = dsPriorityContact.Tables[0].Rows[0]["Email"].ToString();
                        PriorityExtension = dsPriorityContact.Tables[0].Rows[0]["Extension"].ToString();
                        PriorityFaxCode = dsPriorityContact.Tables[0].Rows[0]["FaxNoCode"].ToString();
                        PriorityFaxNo = dsPriorityContact.Tables[0].Rows[0]["FaxNo"].ToString();
                        PriorityFirstName = dsPriorityContact.Tables[0].Rows[0]["FirstName"].ToString();
                        PriorityGeneralLineCode = dsPriorityContact.Tables[0].Rows[0]["GeneralLineCode"].ToString();
                        PriorityGeneralLineNo = dsPriorityContact.Tables[0].Rows[0]["GeneralLineNo"].ToString();
                        PriorityJobTitle = dsPriorityContact.Tables[0].Rows[0]["JobTitle"].ToString();
                        PriorityLastName = dsPriorityContact.Tables[0].Rows[0]["LastName"].ToString();
                        PriorityMobileCode = dsPriorityContact.Tables[0].Rows[0]["MobileNoCode"].ToString();
                        PriorityMobileNo = dsPriorityContact.Tables[0].Rows[0]["MobileNo"].ToString();
                        // PriorityTeam = objcommon.GetTeam(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Team"])).Tables[0].Rows[0]["TeamName"].ToString();
                        PrioritySalutation = dsPriorityContact.Tables[0].Rows[0]["Salutation"].ToString();
                        PriorityChSalutation = dsPriorityContact.Tables[0].Rows[0]["ChSalutation"].ToString();
                    }
                    if (dsReinsurer.Tables.Count > 1)
                    {
                        if (dsReinsurer.Tables[1].Rows.Count > 0)
                            GetApprovalDetails(dsReinsurer.Tables[1]);
                    }
                    //GetApprovalDetails(dsReinsurer.Tables[1]);
                    GetTimestampDetails(dsReinsurer);
                    //
                    ereEvents.ShowPageNumber = true;
                    //ereEvents.PrintFooter = false;
                    ereEvents.UWCOPY = false;
                    CreateReinsurerPDF(dRow);
                    docPDF.NewPage();
                }


            }
            catch (Exception ex)
            {
                string strTemp = ex.Message;
                blCreationSuccess = false;
            }
            finally
            {
                closeDoc();
            }
            return blCreationSuccess;

        }
        private Table getReinsurerFirstTable()
        {
            Table tblFirstSec = new Table(4);
            int[] flColWidth = { 20, 30, 20, 30 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 2;

            strText = "Reinsurer Information";
            clCurrCell = getCell(strText, "NOTECH", "Center", "CENTER", 4, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "Reinsurer Information";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.AddCell(new Phrase("Reinsurer Code", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Code, fontThaiSmall));


            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            //tblFirstSec.AddCell(new Phrase("Description", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            //tblFirstSec.AddCell(new Phrase(Description, new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Reinsurer Name", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Name, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Record Type", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(RecordType, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            strText = "";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.AddCell(new Phrase("General Line", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(GeneralLineCode + "-" + GeneralLineNo, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Fax", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(FaxCode + "-" + FaxNo, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Company Email", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Email, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Effective From Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(EffectiveFromDate, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Effective To Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(EffectiveToDate, fontThaiSmall));
            //Second Heading
            strText = "Address";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (IsChineseRequired == "Y")
            {
                strText = "ที่อยู่";
                clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("City", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("เมือง", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Province", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("จังหวัด", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("รหัสไปรษณีย์", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Country, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("ประเทศ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("City", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("เมือง", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Province", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("จังหวัด", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("รหัสไปรษณีย์", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("ประเทศ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));
            }
            else
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("City", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("City", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Province", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Province", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Country, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("City", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("City", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Province", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Province", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

            }

            return tblFirstSec;
        }
        private void CreateReinsurerPDF(DataRow dr)
        {
            Table tblContent = new Table(1);
            tblContent.AutoFillEmptyCells = true;
            tblContent.WidthPercentage = 100;
            tblContent.Border = Table.NO_BORDER;
            tblContent.Cellspacing = 2;
            tblContent.DefaultCellBorder = Cell.NO_BORDER;
            tblContent.InsertTable(getReinsurerFirstTable());
            docPDF.Add(tblContent);


            Table tblContent2 = new Table(1);
            tblContent2.AutoFillEmptyCells = true;
            tblContent2.WidthPercentage = 100;
            tblContent2.Border = Table.NO_BORDER;
            tblContent2.Cellspacing = 2;
            tblContent2.DefaultCellBorder = Cell.NO_BORDER;
            tblContent2.InsertTable(getPriorityContactTable());
            docPDF.Add(tblContent2);

            Table tblContent3 = new Table(1);
            tblContent3.AutoFillEmptyCells = true;
            tblContent3.WidthPercentage = 100;
            tblContent3.Border = Table.NO_BORDER;
            tblContent3.Cellspacing = 2;
            tblContent3.DefaultCellBorder = Cell.NO_BORDER;
            tblContent3.InsertTable(getApprovalTable());
            docPDF.Add(tblContent3);

            Table tblContent4 = new Table(1);
            tblContent4.AutoFillEmptyCells = true;
            tblContent4.WidthPercentage = 100;
            tblContent4.Border = Table.NO_BORDER;
            tblContent4.Cellspacing = 2;
            tblContent4.DefaultCellBorder = Cell.NO_BORDER;
            tblContent4.InsertTable(getTimeStampTable());
            docPDF.Add(tblContent4);

        }

        public bool CreateCedantRequestApprovalPDF(clsUnApprovedInfo objUnaprvedInfo, UnApprovedContacts objUnapprContact)
        {
            bool blCreationSuccess = true;
            dsCedant = new DataSet();
            ereEvents = new PDFGeneratorEvents();
            try
            {
                createAndOpenNewDoc();
                clsCedantManager objCedantBAL = new clsCedantManager();
                dsCedant = objCedantBAL.getUnApprovCedantList(objUnaprvedInfo);
                dsPriorityContact = new DataSet();
                dsPriorityContact = objCedantBAL.getUnApprovCedantContacts(objUnapprContact);
                foreach (DataRow dRow in dsCedant.Tables[0].Rows)
                {

                    //RejectReason = dsAgent.Tables[0].Rows[0]["RejectReason"].ToString();

                    Code = dsCedant.Tables[0].Rows[0]["CedantCode"].ToString();
                    Name = dsCedant.Tables[0].Rows[0]["CedantName"].ToString();
                    ChName = dsCedant.Tables[0].Rows[0]["ChCedantName"].ToString();
                    CorrAddress1 = dsCedant.Tables[0].Rows[0]["CorrAddress1"].ToString();
                    CorrAddress2 = dsCedant.Tables[0].Rows[0]["CorrAddress2"].ToString();
                    CorrAddress3 = dsCedant.Tables[0].Rows[0]["CorrAddress3"].ToString();
                    ChineseCorrAddress1 = dsCedant.Tables[0].Rows[0]["ChCorrAddress1"].ToString();
                    ChineseCorrAddress2 = dsCedant.Tables[0].Rows[0]["ChCorrAddress2"].ToString();
                    ChineseCorrAddress3 = dsCedant.Tables[0].Rows[0]["ChCorrAddress3"].ToString();

                    CorrCity = dsCedant.Tables[0].Rows[0]["City"].ToString();
                    CorrProvince = dsCedant.Tables[0].Rows[0]["Province"].ToString();
                    CorrPostalCode = dsCedant.Tables[0].Rows[0]["PostalCode"].ToString();
                    CorrChCity = dsCedant.Tables[0].Rows[0]["ChCity"].ToString();
                    CorrChProvince = dsCedant.Tables[0].Rows[0]["ChProvince"].ToString();
                    CorrChPostalCode = dsCedant.Tables[0].Rows[0]["ChPostalCode"].ToString();

                    BillCity = dsCedant.Tables[0].Rows[0]["BillingCity"].ToString();
                    BillProvince = dsCedant.Tables[0].Rows[0]["BillingProvince"].ToString();
                    BillPostalCode = dsCedant.Tables[0].Rows[0]["BillingPostalCode"].ToString();
                    BillChCity = dsCedant.Tables[0].Rows[0]["ChBillingCity"].ToString();
                    BillChProvince = dsCedant.Tables[0].Rows[0]["ChBillingProvince"].ToString();
                    BillChPostalCode = dsCedant.Tables[0].Rows[0]["ChBillingPostalCode"].ToString();

                    Country = objcommon.GetTerritoryByCode(dsCedant.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                    ChineseCountry = objcommon.GetTerritoryByCode(dsCedant.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                    //Country= dsAgent.Tables[0].Rows[0]["Country"].ToString();
                    ChCountry = objcommon.GetTerritoryByCode(dsCedant.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();

                    BillingAddress1 = dsCedant.Tables[0].Rows[0]["BillingAddress1"].ToString();
                    BillingAddress2 = dsCedant.Tables[0].Rows[0]["BillingAddress2"].ToString();
                    BillingAddress3 = dsCedant.Tables[0].Rows[0]["BillingAddress3"].ToString();

                    ChineseBillingAddress1 = dsCedant.Tables[0].Rows[0]["ChBillingAddress1"].ToString();
                    ChineseBillingAddress2 = dsCedant.Tables[0].Rows[0]["ChBillingAddress2"].ToString();
                    ChineseBillingAddress3 = dsCedant.Tables[0].Rows[0]["ChBillingAddress3"].ToString();
                    BillingCountry = objcommon.GetTerritoryByCode(dsCedant.Tables[0].Rows[0]["BillingCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                    ChineseBillingCountry = objcommon.GetTerritoryByCode(dsCedant.Tables[0].Rows[0]["BillingCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                    Description = dsCedant.Tables[0].Rows[0]["CedantDescription"].ToString();
                    GeneralLineCode = dsCedant.Tables[0].Rows[0]["GeneralLineCode"].ToString();
                    GeneralLineNo = dsCedant.Tables[0].Rows[0]["GeneralLineNo"].ToString();

                    RecordType = dsCedant.Tables[0].Rows[0]["RecordType"].ToString();
                    if (RecordType == "False")
                        RecordType = "Not Lapsed";
                    else
                        RecordType = "Lapsed";
                    FaxCode = dsCedant.Tables[0].Rows[0]["FaxNoCode"].ToString();
                    FaxNo = dsCedant.Tables[0].Rows[0]["FaxNo"].ToString();

                    CreditControlAC = dsCedant.Tables[0].Rows[0]["CreditControlAccountNo"].ToString();
                    ClaimAccType = dsCedant.Tables[0].Rows[0]["ClaimAccountType"].ToString();
                    ClaimNormalBal = dsCedant.Tables[0].Rows[0]["ClaimNormalBalance"].ToString();
                    ClaimDebitAcc = dsCedant.Tables[0].Rows[0]["ClaimDebitControlAccountNo"].ToString();
                    //RegDate = dsAgent.Tables[0].Rows[0]["RegistrationDate"].ToString();
                    BusiRegistrationNo = dsCedant.Tables[0].Rows[0]["BusinessRegistrationNo"].ToString();
                    //RegDate = dsCedant.Tables[0].Rows[0]["RegistrationDate"].ToString();
                    Email = dsCedant.Tables[0].Rows[0]["Email"].ToString();

                    AccountType = dsCedant.Tables[0].Rows[0]["AccountType"].ToString();
                    NormalBal = dsCedant.Tables[0].Rows[0]["NormalBalance"].ToString();
                    //CreditControlAC = dsCedant.Tables[0].Rows[0]["CreditControlAccountNo"].ToString();
                    Remarks = dsCedant.Tables[0].Rows[0]["Remarks"].ToString();

                    EffectiveFromDate = Convert.ToString(dsCedant.Tables[0].Rows[0]["EffectivefromDate"]);
                    EffectiveToDate = Convert.ToString(dsCedant.Tables[0].Rows[0]["Effectivetodate"]);
                    foreach (DataRow dataRow in dsPriorityContact.Tables[0].Rows)
                    {

                        PriorityTeam = objcommon.GetTeam(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Team"])).Tables[0].Rows[0]["TeamName"].ToString();
                        PriorityChineseCorrAddress1 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress1"].ToString();
                        PriorityChineseCorrAddress2 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress2"].ToString();
                        PriorityChineseCorrAddress3 = dsPriorityContact.Tables[0].Rows[0]["ChContactCorrAddress3"].ToString();
                        PriorityChineseCountry = objcommon.GetTerritoryByCode(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        PriorityChineseDept = dsPriorityContact.Tables[0].Rows[0]["ChDept"].ToString();
                        PriorityChineseFirstName = dsPriorityContact.Tables[0].Rows[0]["ChFirstName"].ToString();
                        PriorityChineseJobTitle = dsPriorityContact.Tables[0].Rows[0]["ChJobTitle"].ToString();
                        PriorityChineseLastName = dsPriorityContact.Tables[0].Rows[0]["ChLastName"].ToString();
                        PriorityCorrAddress1 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress1"].ToString();
                        PriorityCorrAddress2 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress2"].ToString();
                        PriorityCorrAddress3 = dsPriorityContact.Tables[0].Rows[0]["CorrAddress3"].ToString();


                        PriorityCity = dsPriorityContact.Tables[0].Rows[0]["City"].ToString();
                        PriorityProvince = dsPriorityContact.Tables[0].Rows[0]["Province"].ToString();
                        PriorityPostalCode = dsPriorityContact.Tables[0].Rows[0]["PostalCode"].ToString();
                        PriorityChCity = dsPriorityContact.Tables[0].Rows[0]["ChCity"].ToString();
                        PriorityChProvince = dsPriorityContact.Tables[0].Rows[0]["ChProvince"].ToString();
                        PriorityChPostalCode = dsPriorityContact.Tables[0].Rows[0]["ChPostalCode"].ToString();

                        PriorityCountry = objcommon.GetTerritoryByCode(dsPriorityContact.Tables[0].Rows[0]["Country"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        // PriorityChineseCountry = objcommon.GetTerritoryByCode(dsPriorityContact.Tables[0].Rows[0]["ChContactCountry"].ToString()).Tables[0].Rows[0]["TerritoryName"].ToString();
                        //PriorityDept = objcommon.GetDepartment(dsPriorityContact.Tables[0].Rows[0]["Dept"].ToString(), null).Tables[0].Rows[0]["DeptName"].ToString();
                        PriorityDirectLineCode = dsPriorityContact.Tables[0].Rows[0]["DirectLineCode"].ToString();
                        PriorityDirectLineNo = dsPriorityContact.Tables[0].Rows[0]["DirectLineNo"].ToString();
                        PriorityEffectiveFromDate = dsPriorityContact.Tables[0].Rows[0]["EffectivefromDate"].ToString();
                        PriorityEffectiveToDate = dsPriorityContact.Tables[0].Rows[0]["Effectivetodate"].ToString();
                        PriorityEmail = dsPriorityContact.Tables[0].Rows[0]["Email"].ToString();
                        PriorityExtension = dsPriorityContact.Tables[0].Rows[0]["Extension"].ToString();
                        PriorityFaxCode = dsPriorityContact.Tables[0].Rows[0]["FaxNoCode"].ToString();
                        PriorityFaxNo = dsPriorityContact.Tables[0].Rows[0]["FaxNo"].ToString();
                        PriorityFirstName = dsPriorityContact.Tables[0].Rows[0]["FirstName"].ToString();
                        PriorityGeneralLineCode = dsPriorityContact.Tables[0].Rows[0]["GeneralLineCode"].ToString();
                        PriorityGeneralLineNo = dsPriorityContact.Tables[0].Rows[0]["GeneralLineNo"].ToString();
                        PriorityJobTitle = dsPriorityContact.Tables[0].Rows[0]["JobTitle"].ToString();
                        PriorityLastName = dsPriorityContact.Tables[0].Rows[0]["LastName"].ToString();
                        PriorityMobileCode = dsPriorityContact.Tables[0].Rows[0]["MobileNoCode"].ToString();
                        PriorityMobileNo = dsPriorityContact.Tables[0].Rows[0]["MobileNo"].ToString();
                        // PriorityTeam = objcommon.GetTeam(Convert.ToInt32(dsPriorityContact.Tables[0].Rows[0]["Team"])).Tables[0].Rows[0]["TeamName"].ToString();
                        PrioritySalutation = dsPriorityContact.Tables[0].Rows[0]["Salutation"].ToString();
                        PriorityChSalutation = dsPriorityContact.Tables[0].Rows[0]["ChSalutation"].ToString();
                    }
                    if (dsCedant.Tables.Count > 1)
                    {
                        if (dsCedant.Tables[1].Rows.Count > 0)
                            GetApprovalDetails(dsCedant.Tables[1]);
                    }
                    //GetApprovalDetails(dsCedant.Tables[1]);
                    GetTimestampDetails(dsCedant);
                    //
                    ereEvents.ShowPageNumber = true;
                    //ereEvents.PrintFooter = false;
                    ereEvents.UWCOPY = false;
                    CreateCedantPDF(dRow);
                    docPDF.NewPage();
                }


            }
            catch (Exception ex)
            {
                string strTemp = ex.Message;
                blCreationSuccess = false;
            }
            finally
            {
                closeDoc();
            }
            return blCreationSuccess;

        }
        private Table getCedantFirstTable()
        {
            Table tblFirstSec = new Table(4);
            int[] flColWidth = { 20, 30, 20, 30 };
            tblFirstSec.SetWidths(flColWidth);
            tblFirstSec.AutoFillEmptyCells = true;
            tblFirstSec.WidthPercentage = 100;
            tblFirstSec.Border = Table.NO_BORDER;
            tblFirstSec.Cellspacing = 2;

            strText = "Cedant Information";
            clCurrCell = getCell(strText, "NOTECH", "Center", "CENTER", 4, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "Cedant Information";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            strText = "";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.AddCell(new Phrase("Cedant Code", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Code, fontThaiSmall));


            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));


            tblFirstSec.AddCell(new Phrase("Cedant Name", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Name, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Record Type", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(RecordType, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Business Registration Number", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(BusiRegistrationNo, fontThaiSmall));

            strText = "";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            tblFirstSec.AddCell(new Phrase("General Line", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(GeneralLineCode + "-" + GeneralLineNo, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Fax", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(FaxCode + "-" + FaxNo, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Company Email", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(Email, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));
            tblFirstSec.AddCell(new Phrase("", new Font(Font.HELVETICA, 5f, Font.NORMAL)));

            tblFirstSec.AddCell(new Phrase("Effective From Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(EffectiveFromDate, fontThaiSmall));

            tblFirstSec.AddCell(new Phrase("Effective To Date", fontThaiSmall));
            tblFirstSec.AddCell(new Phrase(EffectiveToDate, fontThaiSmall));
            //Second Heading
            strText = "Address";
            clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
            clCurrCell.Border = Cell.NO_BORDER;
            tblFirstSec.AddCell(clCurrCell);

            if (IsChineseRequired == "Y")
            {
                strText = "ที่อยู่";
                clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);


                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่ติดต่อ 3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("City", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("เมือง", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("จังหวัด", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("รหัสไปรษณีย์ ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Country, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("ประเทศ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("สถานที่เรียกเก็บเงิน 3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("City", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("เมือง", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("จังหวัด", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("รหัสไปรษณีย์", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("ประเทศ", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));
            }
            else
            {
                strText = "";
                clCurrCell = getCell(strText, "NOTECH", "Left", "MIDDLE", 2, false, 10);
                clCurrCell.Border = Cell.NO_BORDER;
                tblFirstSec.AddCell(clCurrCell);


                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Corresponding Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseCorrAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("City", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("City", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(CorrChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(Country, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address1", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress1, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address2", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress2, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Billing Address3", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChineseBillingAddress3, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("City", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("City", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChCity, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("State", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChProvince, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Postal Code", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillChPostalCode, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(BillingCountry, fontThaiSmall));

                tblFirstSec.AddCell(new Phrase("Country", fontThaiSmall));
                tblFirstSec.AddCell(new Phrase(ChCountry, fontThaiSmall));

            }


            return tblFirstSec;
        }
        private void CreateCedantPDF(DataRow dr)
        {
            Table tblContent = new Table(1);
            tblContent.AutoFillEmptyCells = true;
            tblContent.WidthPercentage = 100;
            tblContent.Border = Table.NO_BORDER;
            tblContent.Cellspacing = 2;
            tblContent.DefaultCellBorder = Cell.NO_BORDER;
            tblContent.InsertTable(getCedantFirstTable());
            docPDF.Add(tblContent);


            Table tblContent2 = new Table(1);
            tblContent2.AutoFillEmptyCells = true;
            tblContent2.WidthPercentage = 100;
            tblContent2.Border = Table.NO_BORDER;
            tblContent2.Cellspacing = 2;
            tblContent2.DefaultCellBorder = Cell.NO_BORDER;
            tblContent2.InsertTable(getPriorityContactTable());
            docPDF.Add(tblContent2);

            Table tblContent3 = new Table(1);
            tblContent3.AutoFillEmptyCells = true;
            tblContent3.WidthPercentage = 100;
            tblContent3.Border = Table.NO_BORDER;
            tblContent3.Cellspacing = 2;
            tblContent3.DefaultCellBorder = Cell.NO_BORDER;
            tblContent3.InsertTable(getApprovalTable());
            docPDF.Add(tblContent3);

            Table tblContent4 = new Table(1);
            tblContent4.AutoFillEmptyCells = true;
            tblContent4.WidthPercentage = 100;
            tblContent4.Border = Table.NO_BORDER;
            tblContent4.Cellspacing = 2;
            tblContent4.DefaultCellBorder = Cell.NO_BORDER;
            tblContent4.InsertTable(getTimeStampTable());
            docPDF.Add(tblContent4);

        }
    }
}
