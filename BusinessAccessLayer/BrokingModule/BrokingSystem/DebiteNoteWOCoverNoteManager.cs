using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
namespace BusinessAccessLayer.BrokingModule.BrokingSystem
{
    public class DebiteNoteWOCoverNoteManager
    {
        DataAccess dataAccess = null;

        public DataSet getVesselId(string subSlipCN)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { subSlipCN };
            return dataAccess.LoadDataSet(parametes, "P_pol_getvesselID_From_Subslip", "P_pol_getvesselID_From_Subslip");
        }

        public DataSet getAccMont()
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { };
            return dataAccess.LoadDataSet(parametes, "P_GetAccountOpenMonth", "P_GetAccountOpenMonth");
        }
        public DataSet GetAccountingMonth()
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { };
            return dataAccess.LoadDataSet(parametes, "P_GetAccountingMonth", "P_GetAccountingMonth");
        }
        public DataSet getPrintCovernaote(string caseRefNo)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { caseRefNo };
            return dataAccess.LoadDataSet(parametes, "P_DebitNot_Client_Print", "P_DebitNot_Client_Print");
        }

        public DataSet getContactDetailsForPremiumWarranty(string ClientCode)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { ClientCode };
            return dataAccess.LoadDataSet(parametes, "P_Pol_ClientContactDetails_PremiumWarrantyPrint", "P_ClientContactDetails_PremiumWarrantyPrint");
        }
        public DebiteNoteWOCoverNoteManager()
        {

        }
        public DataSet GetCoverNoteDetail(Int64 polid, Int16 polVerid, string vesselId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { polid, polVerid, vesselId };
            return dataAccess.LoadDataSet(parameters, "P_Pol_Policy_DebitNoteWithCoverNote_SelectCoverNote", "CoverNoteDetail");
        }
        public DataSet GetDebitNoteTypeDetails(string vesselId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { vesselId };
            return dataAccess.LoadDataSet(parameters, "P_Pol_DebitNoteType", "DebitNoteDetail");
        }
        public DataSet GetCaseRefNo(string CaseRefNo  ,string CoverNoteNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] {CaseRefNo, CoverNoteNo };
            return dataAccess.LoadDataSet(parameters, "P_Pol_Policy_DebitNoteWithCoverNote_SelectCaseRefNo", "SelectCaseRefNo");
        }
        public DataSet GetPolicyAgentDetails(clsPolicyAgent objPolicyAgent)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objPolicyAgent.PolicyId, objPolicyAgent.PolVersionId, objPolicyAgent.id };
            //return dataAccess.LoadDataSet(parameters, "P_IntroducerSummary", "AgentMasterList");

            return dataAccess.LoadDataSet(parameters, "P_Pol_PolicyAgents_Select_Details", "AgentMasterList");
        }

        public DataSet GetPolicyAgentDetailsForAcclaim(clsPolicyAgent objPolicyAgent)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objPolicyAgent.PolicyId, objPolicyAgent.PolVersionId, objPolicyAgent.id, objPolicyAgent.IsEndorsement };
            return dataAccess.LoadDataSet(parameters, "P_IntroducerSummary", "AgentMasterList");

            // return dataAccess.LoadDataSet(parameters, "P_Pol_PolicyAgents_Select_Details", "AgentMasterList");
        }
        public DataSet GetDebiteNoteWithCoverNoteInstalments(string CaseRefNo, string UWcode)
        {
            dataAccess = new DataAccess();
            string[] tables = { "ClientInst", "UwriterInst", "AgentIsnt" };
            Object[] parameters = new Object[2] { CaseRefNo, UWcode };
            return dataAccess.LoadDataSets(parameters, "P_DN_DebitNoteWithCoverNote_SelectInstallment", tables);
        }
        public DataSet GetDebiteNoteWOCoverNote(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.IsFromHistory, objDebitNoteWoCoverNote.RefCaseRefNo };
            return dataAccess.LoadDataSet(parameters, "P_Get_DebitNoWOCoverNo", "DebitNoteWOCovernote");
        }
        public DataSet GetSelectedDebiteNoteWOCoverNote(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.IsFromHistory, objDebitNoteWoCoverNote.RefCaseRefNo };
            return dataAccess.LoadDataSet(parameters, "P_Get_SelectedDebitNoWOCoverNo", "DebitNoteWOCovernote");
        }
        public DataSet InsertUpdateDebiteNoteWOCoverNote(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {  objDebitNoteWoCoverNote.DbtNoteType,objDebitNoteWoCoverNote.PageMode, objDebitNoteWoCoverNote.CaseRefNo , objDebitNoteWoCoverNote.DebitNoteNo ,objDebitNoteWoCoverNote.DebitNoteType , objDebitNoteWoCoverNote.RiskLocationType ,objDebitNoteWoCoverNote.DebitNoteTo ,objDebitNoteWoCoverNote.ClientCode ,objDebitNoteWoCoverNote.ClientName ,objDebitNoteWoCoverNote.ClientSubCode ,
		                                            objDebitNoteWoCoverNote.BranchCode ,objDebitNoteWoCoverNote.BranchName ,objDebitNoteWoCoverNote.EffectiveDate ,objDebitNoteWoCoverNote.CoverNoteNo ,objDebitNoteWoCoverNote.MainClassCode ,objDebitNoteWoCoverNote.MainClassName ,objDebitNoteWoCoverNote.SubClassCode ,                                     
		                                            objDebitNoteWoCoverNote.SubClassName ,objDebitNoteWoCoverNote.POIFromDate ,objDebitNoteWoCoverNote.POIToDate ,objDebitNoteWoCoverNote.SumInsuredCurrency ,objDebitNoteWoCoverNote.SumInsuredAmount ,objDebitNoteWoCoverNote.GrossPremCurrency ,objDebitNoteWoCoverNote.GrossPremiumAmount , objDebitNoteWoCoverNote.Primary_AccountHandler, objDebitNoteWoCoverNote.Secondary_AccountHandler,                    
		                                            objDebitNoteWoCoverNote.PolicyNo ,objDebitNoteWoCoverNote.PreviouPolicyNo ,objDebitNoteWoCoverNote.InsurerDebitNote ,objDebitNoteWoCoverNote.BillingDate ,objDebitNoteWoCoverNote.MultipleBilling  ,objDebitNoteWoCoverNote.Installment ,objDebitNoteWoCoverNote.NoOfInst ,objDebitNoteWoCoverNote.CoInsurance ,
		                                            objDebitNoteWoCoverNote.SubBroker ,objDebitNoteWoCoverNote.Remarks ,objDebitNoteWoCoverNote.UserID ,
                                                    objDebitNoteWoCoverNote.EndtInsurerNo ,objDebitNoteWoCoverNote.EndtEffectivetDate, objDebitNoteWoCoverNote.EndtRemarks , objDebitNoteWoCoverNote.PaymentStatus, objDebitNoteWoCoverNote.PaymentStatusDesc, objDebitNoteWoCoverNote.AdditionalPremCurrency,objDebitNoteWoCoverNote.AdditionalPremiumAmount,objDebitNoteWoCoverNote.TotalPremCurrency,objDebitNoteWoCoverNote.TotalPremiumAmount,
                                                    objDebitNoteWoCoverNote.spreadFrom, objDebitNoteWoCoverNote.spreadTo, objDebitNoteWoCoverNote.EB, objDebitNoteWoCoverNote.isLock, objDebitNoteWoCoverNote.isExportToFlex , objDebitNoteWoCoverNote.PWNoOfDays,objDebitNoteWoCoverNote.PWDate, objDebitNoteWoCoverNote.PolicyID, objDebitNoteWoCoverNote.PolicyVerId,objDebitNoteWoCoverNote.DueDatePPW,objDebitNoteWoCoverNote.TeamId,
                                                    objDebitNoteWoCoverNote.Assured,objDebitNoteWoCoverNote.Month,objDebitNoteWoCoverNote.debitNoteRiskLocations,objDebitNoteWoCoverNote.DivisionalGrouping,objDebitNoteWoCoverNote.DebitCreditDueDate ,objDebitNoteWoCoverNote.IsBillingleadInsurer, objDebitNoteWoCoverNote.LinkedIntroducer//new added parameters
                                                    ,objDebitNoteWoCoverNote.RefCaseRefNo,objDebitNoteWoCoverNote.IsRenew,objDebitNoteWoCoverNote.IsRenewalType, objDebitNoteWoCoverNote.DateOverride,objDebitNoteWoCoverNote.FeeBillingDueDate};
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteInsertUpdate", "DebitNoteWOCovernoteInsertUpdate");
        }
        public DataSet InsertUpdateDebiteNoteWOCoverNote_Harmonized(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {  objDebitNoteWoCoverNote.DbtNoteType,objDebitNoteWoCoverNote.PageMode, objDebitNoteWoCoverNote.CaseRefNo , objDebitNoteWoCoverNote.DebitNoteNo ,objDebitNoteWoCoverNote.DebitNoteType ,objDebitNoteWoCoverNote.DebitNoteTo ,objDebitNoteWoCoverNote.ClientCode ,objDebitNoteWoCoverNote.ClientName ,objDebitNoteWoCoverNote.ClientSubCode ,
		                                            objDebitNoteWoCoverNote.BranchCode ,objDebitNoteWoCoverNote.BranchName ,objDebitNoteWoCoverNote.EffectiveDate ,objDebitNoteWoCoverNote.CoverNoteNo ,objDebitNoteWoCoverNote.MainClassCode ,objDebitNoteWoCoverNote.MainClassName ,objDebitNoteWoCoverNote.SubClassCode ,                                     
		                                            objDebitNoteWoCoverNote.SubClassName ,objDebitNoteWoCoverNote.POIFromDate ,objDebitNoteWoCoverNote.POIToDate ,objDebitNoteWoCoverNote.SumInsuredCurrency ,objDebitNoteWoCoverNote.SumInsuredAmount ,objDebitNoteWoCoverNote.GrossPremCurrency ,objDebitNoteWoCoverNote.GrossPremiumAmount , objDebitNoteWoCoverNote.Primary_AccountHandler, objDebitNoteWoCoverNote.Secondary_AccountHandler,                    
		                                            objDebitNoteWoCoverNote.PolicyNo ,objDebitNoteWoCoverNote.PreviouPolicyNo ,objDebitNoteWoCoverNote.InsurerDebitNote ,objDebitNoteWoCoverNote.BillingDate ,objDebitNoteWoCoverNote.MultipleBilling  ,objDebitNoteWoCoverNote.Installment ,objDebitNoteWoCoverNote.NoOfInst ,objDebitNoteWoCoverNote.CoInsurance ,
		                                            objDebitNoteWoCoverNote.SubBroker ,objDebitNoteWoCoverNote.Remarks ,objDebitNoteWoCoverNote.UserID ,
                                                    objDebitNoteWoCoverNote.EndtInsurerNo ,objDebitNoteWoCoverNote.EndtEffectivetDate, objDebitNoteWoCoverNote.EndtRemarks , objDebitNoteWoCoverNote.PaymentStatus, objDebitNoteWoCoverNote.PaymentStatusDesc, objDebitNoteWoCoverNote.AdditionalPremCurrency,objDebitNoteWoCoverNote.AdditionalPremiumAmount,objDebitNoteWoCoverNote.TotalPremCurrency,objDebitNoteWoCoverNote.TotalPremiumAmount,
                                                    objDebitNoteWoCoverNote.spreadFrom, objDebitNoteWoCoverNote.spreadTo, objDebitNoteWoCoverNote.EB, objDebitNoteWoCoverNote.isLock, objDebitNoteWoCoverNote.isExportToFlex , objDebitNoteWoCoverNote.PWNoOfDays,objDebitNoteWoCoverNote.PWDate, objDebitNoteWoCoverNote.PolicyID, objDebitNoteWoCoverNote.PolicyVerId,objDebitNoteWoCoverNote.DueDatePPW,objDebitNoteWoCoverNote.TeamId,objDebitNoteWoCoverNote.Assured,objDebitNoteWoCoverNote.Month,objDebitNoteWoCoverNote.debitNoteRiskLocations,
                                                    objDebitNoteWoCoverNote.HistoricalData,objDebitNoteWoCoverNote.InsurerTax,objDebitNoteWoCoverNote.DivisionalGrouping,objDebitNoteWoCoverNote.PreviousPlacement,objDebitNoteWoCoverNote.IsBillingleadInsurer,//new added parameters
                                                    objDebitNoteWoCoverNote.ServiceFeeType,objDebitNoteWoCoverNote.OtherChargeFeeType,objDebitNoteWoCoverNote.FeeType,objDebitNoteWoCoverNote.BillingDueDate,
                                                    objDebitNoteWoCoverNote.RefCaseRefNo,objDebitNoteWoCoverNote.IsRenew,objDebitNoteWoCoverNote.IsRenewalType,objDebitNoteWoCoverNote.DateOverride,objDebitNoteWoCoverNote.FeeBillingDueDate
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteInsertUpdate", "DebitNoteWOCovernoteInsertUpdate");
        }
        public DataSet GetDebiteNoteWOCoverNoteDetails(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.IsFromHistory, objDebitNoteWoCoverNote.LocationId };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNoteDetails", "DebitNoteWOCovernoteDetails");
        }
        public DataSet getLocation(clsQuotation objclsQuotation)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objclsQuotation.PolicyId, objclsQuotation.PolVersionId, objclsQuotation.UWCoinsuranceApplicable };
            return dataAccess.LoadDataSet(parametes, "P_DN_DebitNoteWithCoverNote_SelectLocation", "SelectLocation");
        }

        public DataSet GetDebiteNoteWithCoverNoteClient(string CaseRefNo, string locationId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { CaseRefNo, locationId };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWithCoverNote_SelectClient", "P_DN_DebitNoteWithCoverNote_SelectClient");
        }
        public DataSet GetDebiteNoteWithCoverNoteUwriter(string CaseRefNo, string UWriterCode)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { CaseRefNo, UWriterCode };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWithCoverNote_SelectUwriter", "P_DN_DebitNoteWithCoverNote_SelectUwriter");
        }

        public DataSet GetDebiteNoteWithCoverNoteUwriter(string CaseRefNo, string UWriterCode, string location)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { CaseRefNo, UWriterCode, location };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWithCoverNote_SelectUwriter", "P_DN_DebitNoteWithCoverNote_SelectUwriter");
        }

        public DataSet GetDebiteNoteWOCoverNoteClientSummary(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.IsFromHistory };
            return dataAccess.LoadDataSet(parameters, "P_DNDebitNoteWOCoverClientSummary", "DebitNoteWOCovernoteDetails");
        }
        public DataSet GetDebiteNoteWOCoverNoteClientDetails(clsDebitNoteWOCoverNoteClient objDebitNoteWoCoverNoteClient)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWoCoverNoteClient.CaseRefNo, objDebitNoteWoCoverNoteClient.DebitNoteNo, objDebitNoteWoCoverNoteClient.IsFromHistory, objDebitNoteWoCoverNoteClient.RiskLocationId };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteClientDetails", "DebitNoteWOCovernoteClientDetails");
        }
        public DataSet GetDebiteNoteWOCoverNoteUwriterDetails(clsDebitNoteWOCoverNoteUnderWriter objDebitNoteWoCoverNoteUwriter)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objDebitNoteWoCoverNoteUwriter.CaseRefNo, objDebitNoteWoCoverNoteUwriter.DebiteNoteNo, objDebitNoteWoCoverNoteUwriter.IsFromHistory, objDebitNoteWoCoverNoteUwriter.UnderWriterCode, objDebitNoteWoCoverNoteUwriter.LocationId };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteUwriterDetails", "DebitNoteWOCovernoteUWriterDetails");
        }
        public DataSet GetDebiteNoteWOCoverNoteAgentDetails(clsDebitNoteWOCoverNoteAgent objDebitNoteWoCoverNoteAgent)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWoCoverNoteAgent.CaseRefNo, objDebitNoteWoCoverNoteAgent.DebitNoteNo, objDebitNoteWoCoverNoteAgent.IsFromHistory, objDebitNoteWoCoverNoteAgent.LocatinId };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteAgentDetails", "DebitNoteWOCovernoteAgentDetails");
        }
        public DataSet InsertUpdateDebiteNoteWOCoverNoteDetails(clsDebiteNoteWOCoverNoteDetails objDebitNoteWoCoverNoteDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[65] {  objDebitNoteWoCoverNoteDetails.CaseRefNo, objDebitNoteWoCoverNoteDetails.DebitNoteDate,objDebitNoteWoCoverNoteDetails.NoOfInstallment, objDebitNoteWoCoverNoteDetails.NoOfClients, objDebitNoteWoCoverNoteDetails.NoOfUnderWriters, objDebitNoteWoCoverNoteDetails.NoOfAgents, objDebitNoteWoCoverNoteDetails.Currency,
                                                    objDebitNoteWoCoverNoteDetails.TotalPremium,objDebitNoteWoCoverNoteDetails.AdditionalPremium,objDebitNoteWoCoverNoteDetails.TotalDiscount,objDebitNoteWoCoverNoteDetails.TotalFees,objDebitNoteWoCoverNoteDetails.TotalBrokerage,objDebitNoteWoCoverNoteDetails.TotalSpecialDiscount ,
                                                    objDebitNoteWoCoverNoteDetails.TotalSurcharge,objDebitNoteWoCoverNoteDetails.TotalDue,
                                                    objDebitNoteWoCoverNoteDetails.UWriter_Currency ,objDebitNoteWoCoverNoteDetails.UWriter_TotalPremium , objDebitNoteWoCoverNoteDetails.UWriter_TotalDiscount ,
                                                    objDebitNoteWoCoverNoteDetails.UWriter_TotalFees  , objDebitNoteWoCoverNoteDetails.UWriter_TotalBrokerage ,objDebitNoteWoCoverNoteDetails.UWriter_TotalSpecialDiscount , 
                                                    objDebitNoteWoCoverNoteDetails.UWriter_TotalSurcharge ,objDebitNoteWoCoverNoteDetails.UWriter_NetAmount , objDebitNoteWoCoverNoteDetails.UWriter_UWShare ,objDebitNoteWoCoverNoteDetails.UWriter_TotalDue ,
                                                    objDebitNoteWoCoverNoteDetails.Agent_Currency , objDebitNoteWoCoverNoteDetails.AgentBroker_TotalPremium ,objDebitNoteWoCoverNoteDetails.AgentBroker_TotalBrokerage  ,objDebitNoteWoCoverNoteDetails.AgentBroker_Share , objDebitNoteWoCoverNoteDetails.AgentBroker_TotalDue ,objDebitNoteWoCoverNoteDetails.UserID,
                                                    objDebitNoteWoCoverNoteDetails.ClientTotalPremium,objDebitNoteWoCoverNoteDetails.ClientDiscountRate,objDebitNoteWoCoverNoteDetails.ClientDiscountAmount,objDebitNoteWoCoverNoteDetails.ClientSurchargeRate, objDebitNoteWoCoverNoteDetails.ClientSurchargeAmount,objDebitNoteWoCoverNoteDetails.ClientSPDiscountRate,objDebitNoteWoCoverNoteDetails.ClientSPDiscountAmount,
                                                    objDebitNoteWoCoverNoteDetails.PaymentModeCode ,objDebitNoteWoCoverNoteDetails.PaymentMode,objDebitNoteWoCoverNoteDetails.InsurerNameCode,objDebitNoteWoCoverNoteDetails.InsurerName, objDebitNoteWoCoverNoteDetails.ClientShare , objDebitNoteWoCoverNoteDetails.ClientFeesRate,objDebitNoteWoCoverNoteDetails.ClientFeesAmount,objDebitNoteWoCoverNoteDetails.OtherPayableTo,objDebitNoteWoCoverNoteDetails.BankId,objDebitNoteWoCoverNoteDetails.BankCurrency,objDebitNoteWoCoverNoteDetails.IsPrintLegNote,
                                                    objDebitNoteWoCoverNoteDetails.StampDuty,
                                                    objDebitNoteWoCoverNoteDetails.Tax,
                                                    objDebitNoteWoCoverNoteDetails.GroupDiscount ,
                                                    objDebitNoteWoCoverNoteDetails.OtherDiscount ,
                                                    objDebitNoteWoCoverNoteDetails.WHTAmount,
                                                    objDebitNoteWoCoverNoteDetails.UWriter_StampDuty ,
                                                    objDebitNoteWoCoverNoteDetails.UWriter_Tax,
                                                    objDebitNoteWoCoverNoteDetails.UWriter_TaxAmt,
                                                    objDebitNoteWoCoverNoteDetails.UWriter_CommissionAmt,
                                                    objDebitNoteWoCoverNoteDetails.UWriter_WHTAmt,
                                                    objDebitNoteWoCoverNoteDetails.UWriter_TotalLeaderFee ,

                                                    objDebitNoteWoCoverNoteDetails.TotalNettPremium,
                                                    objDebitNoteWoCoverNoteDetails.IsManualOverwrite,
                                                    objDebitNoteWoCoverNoteDetails.ClientContactName ,//used as a ClientContactCode
                                                    objDebitNoteWoCoverNoteDetails.PremiumWarrantyCode ,
                                                    objDebitNoteWoCoverNoteDetails.PremiumWarrantyDesc
            };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNoteDetailsInsertUpdate", "DebitNoteWOCovernoteDetailsInsertUpdate");
        }
        public DataSet InsertUpdateDebiteNoteWOCoverNoteInstallmentDetails(clsDebiteNoteWOCoverNoteDetails objDebitNoteWoCoverNoteDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWoCoverNoteDetails.CaseRefNo, objDebitNoteWoCoverNoteDetails.NoOfInstallment, objDebitNoteWoCoverNoteDetails.UserID, objDebitNoteWoCoverNoteDetails.IsManualOverwrite };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNoteDetailsInstallmentUpdate", "DebitNoteWOCovernoteInstallmentDetailsInsertUpdate");
        }
        public DataSet InsertUpdateDebiteNoteWOCoverNoteClient(clsDebitNoteWOCoverNoteClient objDebitNoteWoCoverNoteClient)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objDebitNoteWoCoverNoteClient.CaseRefNo, objDebitNoteWoCoverNoteClient.RefNo, objDebitNoteWoCoverNoteClient.ClientCode, objDebitNoteWoCoverNoteClient.ClientName, objDebitNoteWoCoverNoteClient.Currency, objDebitNoteWoCoverNoteClient.Premium, objDebitNoteWoCoverNoteClient.Discount, objDebitNoteWoCoverNoteClient.Fees, objDebitNoteWoCoverNoteClient.BrokerageRate, objDebitNoteWoCoverNoteClient.Brokerage, objDebitNoteWoCoverNoteClient.SpecialDiscount, objDebitNoteWoCoverNoteClient.Surcharge, objDebitNoteWoCoverNoteClient.TotalDue, 
                objDebitNoteWoCoverNoteClient.TotalPremium , objDebitNoteWoCoverNoteClient.ClientShare , objDebitNoteWoCoverNoteClient.TotalDiscount, objDebitNoteWoCoverNoteClient.DiscountRate, objDebitNoteWoCoverNoteClient.TotalSurcharge, objDebitNoteWoCoverNoteClient.SurchargeRate, objDebitNoteWoCoverNoteClient.TotalSPDiscount, objDebitNoteWoCoverNoteClient.SPDiscountRate, objDebitNoteWoCoverNoteClient.FeesRate, objDebitNoteWoCoverNoteClient.RiskLocationId, 
                  objDebitNoteWoCoverNoteClient.StampDuty,
                  objDebitNoteWoCoverNoteClient.Tax,
                  objDebitNoteWoCoverNoteClient.GroupDiscountPer,
                  objDebitNoteWoCoverNoteClient.GroupDiscount,
                  objDebitNoteWoCoverNoteClient.OtherDiscountPer,
                  objDebitNoteWoCoverNoteClient.OtherDiscount,
                  objDebitNoteWoCoverNoteClient.WHTAmount,
                  objDebitNoteWoCoverNoteClient.StampDutyAmount,
                  objDebitNoteWoCoverNoteClient.VATSBT,
                  objDebitNoteWoCoverNoteClient.WHTPer,
                  objDebitNoteWoCoverNoteClient.PolicyCharge,
                  objDebitNoteWoCoverNoteClient.InsurerGSTPer,
                  objDebitNoteWoCoverNoteClient.InsurerGSTPerId,
                  objDebitNoteWoCoverNoteClient.InsurerGSTAmount,
                  objDebitNoteWoCoverNoteClient.ServiceFee,
                  objDebitNoteWoCoverNoteClient.ServiceFeeGSTPer,
                  objDebitNoteWoCoverNoteClient.ServiceFeeGSTPerId,
                  objDebitNoteWoCoverNoteClient.ServiceFeeGSTAmount,
                  objDebitNoteWoCoverNoteClient.NCD,
                  objDebitNoteWoCoverNoteClient.NCDAmount,
                  objDebitNoteWoCoverNoteClient.LodingByInsurer,
                  objDebitNoteWoCoverNoteClient.LodingByInsurerAmount,
                  objDebitNoteWoCoverNoteClient.DiscountByInsurer,

                  objDebitNoteWoCoverNoteClient.DiscountByInsurerAmount,
                  objDebitNoteWoCoverNoteClient.OtherCharges,
                  objDebitNoteWoCoverNoteClient.NettPremium,
                  objDebitNoteWoCoverNoteClient.ServiceFeeType,
                  objDebitNoteWoCoverNoteClient.OtherChargesType,
                  objDebitNoteWoCoverNoteClient.Remarks
            };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteClientInsertUpdate", "DebitNoteWOCovernoteClientInsertUpdate");
        }
        public DataSet InsertUpdateDebiteNoteWOCoverNoteUwriter(clsDebitNoteWOCoverNoteUnderWriter objDebitNoteWoCoverNoteUwriter)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objDebitNoteWoCoverNoteUwriter.CaseRefNo, objDebitNoteWoCoverNoteUwriter.RefNo, objDebitNoteWoCoverNoteUwriter.IsLeader, objDebitNoteWoCoverNoteUwriter.UnderWriterCode, objDebitNoteWoCoverNoteUwriter.UnderWriterName, objDebitNoteWoCoverNoteUwriter.Currency, objDebitNoteWoCoverNoteUwriter.Premium, objDebitNoteWoCoverNoteUwriter.Discount, objDebitNoteWoCoverNoteUwriter.Fees, objDebitNoteWoCoverNoteUwriter.Brokerage, objDebitNoteWoCoverNoteUwriter.SpecialDiscount, objDebitNoteWoCoverNoteUwriter.Surcharge, objDebitNoteWoCoverNoteUwriter.NetAmount, objDebitNoteWoCoverNoteUwriter.UwShare, objDebitNoteWoCoverNoteUwriter.TotalDue, objDebitNoteWoCoverNoteUwriter.IsCoinsurance,
                                objDebitNoteWoCoverNoteUwriter.TotalPremium,objDebitNoteWoCoverNoteUwriter.BrokerageRate,objDebitNoteWoCoverNoteUwriter.FeesRate,objDebitNoteWoCoverNoteUwriter.LocationDesc,objDebitNoteWoCoverNoteUwriter.StampDuty,objDebitNoteWoCoverNoteUwriter.Tax,objDebitNoteWoCoverNoteUwriter.CommissionPer,objDebitNoteWoCoverNoteUwriter.CommissionAmt,
                                objDebitNoteWoCoverNoteUwriter.TaxAmt,
                                objDebitNoteWoCoverNoteUwriter.WHTAmt,
                                objDebitNoteWoCoverNoteUwriter.LeaderFeePer,
                                objDebitNoteWoCoverNoteUwriter.LeaderFee,
                                objDebitNoteWoCoverNoteUwriter.VATSBT,
                                objDebitNoteWoCoverNoteUwriter.InsuTaxPer,
                                objDebitNoteWoCoverNoteUwriter.WHTPer,objDebitNoteWoCoverNoteUwriter.InsuTaxAmount,  objDebitNoteWoCoverNoteUwriter.PolicyCharge,
                  objDebitNoteWoCoverNoteUwriter.InsurerGSTPer,
                  objDebitNoteWoCoverNoteUwriter.InsurerGSTId,
                  objDebitNoteWoCoverNoteUwriter.InsurerGSTAmount,  objDebitNoteWoCoverNoteUwriter.BrokerGST, objDebitNoteWoCoverNoteUwriter.BrokerGSTId,objDebitNoteWoCoverNoteUwriter.BrokerGSTAmount
            };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteUnderWriterInsertUpdate", "DebitNoteWOCovernoteUwriterInsertUpdate");
        }
        public DataSet InsertUpdateDebiteNoteWithCoverNoteUwriter(clsDebitNoteWOCoverNoteUnderWriter objDebitNoteWoCoverNoteUwriter)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objDebitNoteWoCoverNoteUwriter.CaseRefNo, objDebitNoteWoCoverNoteUwriter.RefNo, objDebitNoteWoCoverNoteUwriter.IsLeader, objDebitNoteWoCoverNoteUwriter.UnderWriterCode, objDebitNoteWoCoverNoteUwriter.UnderWriterName, objDebitNoteWoCoverNoteUwriter.Currency, objDebitNoteWoCoverNoteUwriter.Premium, objDebitNoteWoCoverNoteUwriter.Discount, objDebitNoteWoCoverNoteUwriter.Fees, objDebitNoteWoCoverNoteUwriter.Brokerage, objDebitNoteWoCoverNoteUwriter.SpecialDiscount, objDebitNoteWoCoverNoteUwriter.Surcharge, objDebitNoteWoCoverNoteUwriter.NetAmount, objDebitNoteWoCoverNoteUwriter.UwShare, objDebitNoteWoCoverNoteUwriter.TotalDue, objDebitNoteWoCoverNoteUwriter.IsCoinsurance,
                                objDebitNoteWoCoverNoteUwriter.TotalPremium,objDebitNoteWoCoverNoteUwriter.BrokerageRate,objDebitNoteWoCoverNoteUwriter.FeesRate,objDebitNoteWoCoverNoteUwriter.LocationDesc,objDebitNoteWoCoverNoteUwriter.StampDuty,objDebitNoteWoCoverNoteUwriter.Tax,objDebitNoteWoCoverNoteUwriter.CommissionPer,objDebitNoteWoCoverNoteUwriter.CommissionAmt,objDebitNoteWoCoverNoteUwriter.TaxAmt,objDebitNoteWoCoverNoteUwriter.WHTAmt,objDebitNoteWoCoverNoteUwriter.LeaderFeePer,objDebitNoteWoCoverNoteUwriter.LeaderFee,objDebitNoteWoCoverNoteUwriter.PolicyCharge
                                ,objDebitNoteWoCoverNoteUwriter.InsurerGSTPer, objDebitNoteWoCoverNoteUwriter.InsurerGSTId, objDebitNoteWoCoverNoteUwriter.InsurerGSTAmount,
                                objDebitNoteWoCoverNoteUwriter.BrokerGST, objDebitNoteWoCoverNoteUwriter.BrokerGSTId,objDebitNoteWoCoverNoteUwriter.BrokerGSTAmount,objDebitNoteWoCoverNoteUwriter.InsuTaxPer,
                                objDebitNoteWoCoverNoteUwriter.InsuTaxAmount,
                                objDebitNoteWoCoverNoteUwriter.WHTPer, objDebitNoteWoCoverNoteUwriter.BrokerageFee, objDebitNoteWoCoverNoteUwriter.LocationId 
            };
            return dataAccess.LoadDataSet(parameters, "P_DN_WithCoverNoteUnderWriterInsertUpdate", "DebitNoteWOCovernoteUwriterInsertUpdate");
        }


        public DataSet CopyDebiteNoteWithCoverNoteUwriter(clsDebitNoteWOCoverNoteUnderWriter objDebitNoteWoCoverNoteUwriter)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objDebitNoteWoCoverNoteUwriter.CaseRefNo, objDebitNoteWoCoverNoteUwriter.LocationId ,objDebitNoteWoCoverNoteUwriter.RefNo,
            };
            return dataAccess.LoadDataSet(parameters, "P_Pol_PolicyUnderwriters_TotalDue_CopyBilling", "DebitNoteWOCovernoteUwriterInsertUpdate");
        }
        public DataSet InsertUpdateDebiteNoteWOCoverNoteAgent(clsDebitNoteWOCoverNoteAgent objDebitNoteWoCoverNoteAgent)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objDebitNoteWoCoverNoteAgent.CaseRefNo, objDebitNoteWoCoverNoteAgent.RefNo, objDebitNoteWoCoverNoteAgent.AgentCode, objDebitNoteWoCoverNoteAgent.AgentName, objDebitNoteWoCoverNoteAgent.Currency, objDebitNoteWoCoverNoteAgent.Premium, objDebitNoteWoCoverNoteAgent.Brokerage, objDebitNoteWoCoverNoteAgent.AgentShare, objDebitNoteWoCoverNoteAgent.TotalDue, objDebitNoteWoCoverNoteAgent.IsSubBroker, objDebitNoteWoCoverNoteAgent.LocatinDesc,
            objDebitNoteWoCoverNoteAgent.LocatinId};
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteAgentInsertUpdate", "DebitNoteWOCovernoteAgentInsertUpdate");
        }
        public DataSet GetDebiteNoteWOCoverNoteClientInstallmentDetails(clsDebitNoteWOCoverNoteClient objDebitNoteWoCoverNoteClient, int intInstallCount)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objDebitNoteWoCoverNoteClient.CaseRefNo, objDebitNoteWoCoverNoteClient.RefNo, intInstallCount, objDebitNoteWoCoverNoteClient.DebitNoteNo, objDebitNoteWoCoverNoteClient.IsFromHistory };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteClientInstallment", "DebitNoteWOCovernoteClientDetailsInstallment");
        }

        public DataSet GetDebiteNoteWOCoverNoteUWriterInstallmentDetails(clsDebitNoteWOCoverNoteUnderWriter objDebitNoteWoCoverNoteUwriter, int intInstallCount)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objDebitNoteWoCoverNoteUwriter.CaseRefNo, objDebitNoteWoCoverNoteUwriter.RefNo, intInstallCount, objDebitNoteWoCoverNoteUwriter.DebiteNoteNo, objDebitNoteWoCoverNoteUwriter.IsFromHistory };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteUWriterInstallment", "DebitNoteWOCovernoteUwriterDetailsInstallment");
        }
        public DataSet GetDebiteNoteWOCoverNoteAgentInstallmentDetails(clsDebitNoteWOCoverNoteAgent objDebitNoteWoCoverNoteAgent, int intInstallCount)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objDebitNoteWoCoverNoteAgent.CaseRefNo, objDebitNoteWoCoverNoteAgent.RefNo, intInstallCount, objDebitNoteWoCoverNoteAgent.DebitNoteNo, objDebitNoteWoCoverNoteAgent.IsFromHistory };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteAgentInstallment", "DebitNoteWOCovernoteAgentDetailsInstallment");
        }

        public DataSet InsertUpdateDebitNoteFileUpload(clsDebitNoteWOCoverNoteFileUpload objDebitNoteWoCoverNoteFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objDebitNoteWoCoverNoteFileUpload.CaseRefNo, objDebitNoteWoCoverNoteFileUpload.RefNo, objDebitNoteWoCoverNoteFileUpload.FileName, objDebitNoteWoCoverNoteFileUpload.FileType, objDebitNoteWoCoverNoteFileUpload.Remarks, objDebitNoteWoCoverNoteFileUpload.UploadBy };
            return dataAccess.LoadDataSet(parameters, "P_Adm_DebiteNoteWOCoverNoteFileUploadInsertUpdate", "DebitNoteWOCovernoteFileUpload");
        }

        public DataSet GetDebitNoteFileUpload(clsDebitNoteWOCoverNoteFileUpload objDebitNoteWoCoverNoteFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objDebitNoteWoCoverNoteFileUpload.CaseRefNo, objDebitNoteWoCoverNoteFileUpload.DebitNoteNo, objDebitNoteWoCoverNoteFileUpload.IsFromHistory };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebiteNoteWOCoverNoteFileUpload", "DebitNoteWOCovernoteFileUpload");
        }
        public DataSet DeleteDebiteNoteWOCoverNoteClient(clsDebitNoteWOCoverNoteClient objDebitNoteWoCoverNoteClient)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objDebitNoteWoCoverNoteClient.CaseRefNo, objDebitNoteWoCoverNoteClient.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteClientDelete", "DebitNoteWOCovernoteClientDelete");
        }
        public DataSet DeleteDebiteNoteWOCoverNoteUWriter(clsDebitNoteWOCoverNoteUnderWriter objDebitNoteWoCoverNoteUWriter)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objDebitNoteWoCoverNoteUWriter.CaseRefNo, objDebitNoteWoCoverNoteUWriter.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteUWriterDelete", "DebitNoteWOCovernoteUwriterDelete");
        }
        public DataSet DeleteDebiteNoteWOCoverNoteAgent(clsDebitNoteWOCoverNoteAgent objDebitNoteWoCoverNoteAgent)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objDebitNoteWoCoverNoteAgent.CaseRefNo, objDebitNoteWoCoverNoteAgent.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteAgentDelete", "DebitNoteWOCovernoteAgentDelete");
        }
        public DataSet DeleteDebiteNoteWOCoverNoteFileUpload(clsDebitNoteWOCoverNoteFileUpload objDebitNoteWoCoverNoteFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objDebitNoteWoCoverNoteFileUpload.CaseRefNo, objDebitNoteWoCoverNoteFileUpload.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteFileUploadDelete", "DebitNoteWOCovernoteFileUploadDelete");
        }
        public DataSet DebitNoteCompleted(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.CompanyId, objDebitNoteWoCoverNote.ApprovalStatus };
            // return dataAccess.LoadDataSet(parameters, "P_GenerateDebitCreditNoteNo", "DebitNoteWOCovernoteComplete");
            return dataAccess.LoadDataSet(parameters, "P_GenerateDebitCreditNoteNoNEW", "DebitNoteWOCovernoteComplete");
        }
        public DataSet DebitNoteModifyAmendmend(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.UserID };
            // return dataAccess.LoadDataSet(parameters, "P_GenerateDebitCreditNoteNo", "DebitNoteWOCovernoteComplete");
            return dataAccess.LoadDataSet(parameters, "P_DebitNoteModifyAmendmend", "DebitNoteWOCovernoteComplete");
        }

        //public DataSet CreditNoteCompleted(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        //{
        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[4] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.CompanyId,objDebitNoteWoCoverNote.ApprovalStatus };
        //    // return dataAccess.LoadDataSet(parameters, "P_GenerateDebitCreditNoteNo", "DebitNoteWOCovernoteComplete");
        //    return dataAccess.LoadDataSet(parameters, "P_GenerateDebitCreditNoteNoNEW", "DebitNoteWOCovernoteComplete");
        //}
        public DataSet GetDebitNoteApprovalStatus(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.UserApprovalId, objDebitNoteWoCoverNote.DebitNoteType };
            return dataAccess.LoadDataSet(parameters, "P_DNCNApprovalStatus", "DNCNApprovalStatus");
        }
        public DataSet UpdateDebitNoteApprovalStatus(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[8] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.ApprovalStatus, objDebitNoteWoCoverNote.AppliedBy, objDebitNoteWoCoverNote.AppAuthority1, objDebitNoteWoCoverNote.AppAuthority2, objDebitNoteWoCoverNote.AppAuthority3, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.DebitNoteType };
            return dataAccess.LoadDataSet(parameters, "P_Update_DNCNApprovalStatus", "UpdateDNCNApprovalStatus");
        }
        public DataSet InsertDebitNoteWOCoverNoteHistory(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.MultipleBilling, objDebitNoteWoCoverNote.CoInsurance, objDebitNoteWoCoverNote.SubBroker, objDebitNoteWoCoverNote.UserID };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebiteNoteWOCoverNoteSaveHistory", "DebitNoteWOCovernoteHistory");
        }
        public DataSet GetDebiteNoteWOCoverNoteNonFinancialData(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.UserID };
            return dataAccess.LoadDataSet(parameters, "P_DN_NonFinancialDataLoad", "DebitNoteWOCovernote");
        }
        public DataSet GetDebitNoteDetailsPrintList(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.CalledFrom };
            return dataAccess.LoadDataSet(parameters, "P_GetDebitNoteDetailsPrintList", "GetDebitNoteDetailsPrintList");
        }
        // Added By Apurva
        public DataSet GetDebitNoteDetailsPrintList_BIB(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.DebitNoteType };
            return dataAccess.LoadDataSet(parameters, "P_GetDebitNoteDetailsPrint_BIB", "GetDebitNoteDetailsPrintList_BIB");
        }
        public int MarkDebitNotePrinted(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo };
            return dataAccess.ExecuteScalar("P_MarkDebitNotePrinted", parameters);
        }
        public DataSet GetDebitNoteDetailsPrintList_Acclaim(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo };
            return dataAccess.LoadDataSet(parameters, "P_GetDebitNoteDetailsPrintList_Acclaim", "GetDebitNoteDetailsPrintList");
        }


        public DataSet GetCoverageForDNPrint_LCH(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objDebitNoteWoCoverNote.CaseRefNo };
            return dataAccess.LoadDataSet(parameters, "P_GetCoverageForDebitNotePrint_LCH", "CoverageDetails");
        }


        //Added By neetu

        public DataSet GetchekInstallment(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo };
            return dataAccess.LoadDataSet(parameters, "P_GetCheckMultiInstallment", "CoverageDetails");
        }
        public DataSet GetDebitNoteDetailsPrint_LCH(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote, string coverageType)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo, coverageType };
            return dataAccess.LoadDataSet(parameters, "P_GetDebitNoteDetailsPrint_LCH", "P_GetDebitNoteDetailsPrint_LCH");
        }
        public DataSet GetDebitNotePrint_BIB(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote, string CIUCode, string RecFor)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo, CIUCode, RecFor };
            return dataAccess.LoadDataSet(parameters, "P_GetDebitNotePrint_BIB", "P_GetDebitNotePrint_BIB");
        }
        public DataSet GetDebitNotePrint_Howden(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote, string CIUCode, string RecFor)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo, CIUCode, RecFor };
            return dataAccess.LoadDataSet(parameters, "P_GetDebitNotePrint_Howden", "P_GetDebitNotePrint_BIB");
        }
        public DataSet GetDebitNoteDetailsPrint_LawtonAsia(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote, string strRefNo, string strUWRefNo, string strAgRefNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo, strRefNo, strUWRefNo, strAgRefNo };
            return dataAccess.LoadDataSet(parameters, "P_GetDebitNoteDetailsPrint_LawtonAsia", "P_GetDebitNoteDetailsPrint_LawtonAsia");
        }

        //
        public DataSet GetDebitNoteDetailsPrint_Acclaim(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote, string coverageType)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo, coverageType };
            return dataAccess.LoadDataSet(parameters, "P_GetDebitNoteDetailsPrint_Acclaim", "P_GetDebitNoteDetailsPrint_Acclaim");
        }

        //
        public DataSet GetDebitNoteDetailsPrintInstallment_Acclaim(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote, string coverageType, string installment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo, coverageType, installment };
            return dataAccess.LoadDataSet(parameters, "P_GetDebitNoteDetailsPrintInstallment_Acclaim", "P_GetDebitNoteDetailsPrint_Acclaim");
        }


        public DataSet GetDebitNotePrintDetails(string strCaseRefNo, string strDebitNoteNo, string strRefNo, string strUWRefNo, string strAgRefNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { strCaseRefNo, strDebitNoteNo, strRefNo, strUWRefNo, strAgRefNo };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNoteReport", "DebitNoteWOCoverNoteReport");
        }

        public DataSet GetConsolidatedDebitNotePrintDetails(string strCaseRefNo, string strDebitnoteNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { strCaseRefNo, strDebitnoteNo };
            return dataAccess.LoadDataSet(parameters, "P_DN_ConsolidatedDebitNoteWOCoverNoteReport", "DebitNoteWOCoverNoteReport");
        }

        public DataSet GetDebitNoteFooterDetail(string strCaseRefNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { strCaseRefNo };
            string[] Tables = { "CompanyFooter", "BranchFooter", "PrintLogo" };
            return dataAccess.LoadDataSets(parameters, "P_PrintFooter_SelectForDebitNote", Tables);
            //return dataAccess.LoadDataSet(parameters, "P_PrintFooter_SelectForDebitNote", "DebitNoteWOCoverNoteReport");
        }

        //public DataSet GetDebitNotePrintDetailsSurcharge(string strCaseRefNo, string strDebitNoteNo, string strClientCode, string mstrRefNo)
        //{
        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[4] { strCaseRefNo, strDebitNoteNo, strClientCode, mstrRefNo };
        //    return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNoteReportSurcharge", "DebitNoteWOCoverNoteReport");
        //}

        public DataSet GetDebiteNoteWOCoverNoteMemberUploadEnquiry(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objDebitNoteWoCoverNote.ClientCode, objDebitNoteWoCoverNote.ClientName, objDebitNoteWoCoverNote.CoverNoteNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_DebitNoteNoList", "EB_DebitNoteNoList");
        }

        public DataSet GetDebiteNoteWOCoverNoteEnquiry(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[22] { objDebitNoteWoCoverNote.DbtNoteType, objDebitNoteWoCoverNote.FromDate, objDebitNoteWoCoverNote.ToDate, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.ClientName, objDebitNoteWoCoverNote.ClientCode, objDebitNoteWoCoverNote.Primary_AccountHandler, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.MainClassName, objDebitNoteWoCoverNote.UnderwriterName, objDebitNoteWoCoverNote.CoverNoteNo, objDebitNoteWoCoverNote.SubClassName, objDebitNoteWoCoverNote.DebitNoteStatus, objDebitNoteWoCoverNote.BranchId, objDebitNoteWoCoverNote.CompanyId, objDebitNoteWoCoverNote.KeyAccountmanager, objDebitNoteWoCoverNote.Industrytype, objDebitNoteWoCoverNote.UserLoginId, objDebitNoteWoCoverNote.UnderwriterShortName, objDebitNoteWoCoverNote.BillingDueFromDate, objDebitNoteWoCoverNote.BillingDueToDate, objDebitNoteWoCoverNote.IsRenewalType };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNote", "P_DN_DebitNoteWOCoverNote");
        }

        //added on 10th November
        public DataSet GetDebiteNoteWOCoverNote_StandardLetter(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objDebitNoteWoCoverNote.CoverNoteNo, objDebitNoteWoCoverNote.ClientName, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.FromDate, objDebitNoteWoCoverNote.ToDate };
            return dataAccess.LoadDataSet(parameters, "P_DN_StandardLetterEnquiry", "P_DN_DebitNoteStandardLetterEnquiry");
        }


        public DataSet GetDebiteNoteWOCoverNote_DebitCreditNoteList()
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitCreditList", "TM_DebitCreditNoteList");

        }
        //end

        //added on 15th November
        public DataSet GetClientDetails(string clientcode)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { clientcode };
            return dataAccess.LoadDataSet(parameters, "GetClientDetails_ForStandardLetterBilling", "TM_GetClientDetails_ForStandardLetterBilling");
        }
        //end
        public DataSet GetCreditNoteCoverNoteEnquiryL1(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[16] { objDebitNoteWoCoverNote.DbtNoteType, objDebitNoteWoCoverNote.FromDate, objDebitNoteWoCoverNote.ToDate, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.ClientName, objDebitNoteWoCoverNote.ClientCode, objDebitNoteWoCoverNote.Primary_AccountHandler, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.MainClassName, objDebitNoteWoCoverNote.UnderwriterName, objDebitNoteWoCoverNote.CoverNoteNo, objDebitNoteWoCoverNote.SubClassName, objDebitNoteWoCoverNote.DebitNoteStatus, objDebitNoteWoCoverNote.BranchId, objDebitNoteWoCoverNote.CompanyId, objDebitNoteWoCoverNote.ApprovalStatus };
            return dataAccess.LoadDataSet(parameters, "P_DN_GetCreditNoteCoverNote", "P_DN_CreditNoteCoverNote");

        }
        public DataSet GetDebiteNoteWOCoverNoteApprovalEnquiry(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[9] { objDebitNoteWoCoverNote.CoverNoteNo, objDebitNoteWoCoverNote.ClientName, objDebitNoteWoCoverNote.ClientCode, objDebitNoteWoCoverNote.Primary_AccountHandler, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.MainClassName, objDebitNoteWoCoverNote.SubClassName, objDebitNoteWoCoverNote.UnderwriterName, objDebitNoteWoCoverNote.UserApprovalId };
            return dataAccess.LoadDataSet(parameters, "P_GetApprovalViseDN", "P_DN_DebitNoteWOCoverNote");
        }
        public DataSet GetDebiteNoteWOCoverNoteApprovalStatusEnquiry(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[11] { objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.CoverNoteNo, objDebitNoteWoCoverNote.ClientName, objDebitNoteWoCoverNote.ClientCode, objDebitNoteWoCoverNote.Primary_AccountHandler, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.MainClassName, objDebitNoteWoCoverNote.SubClassName, objDebitNoteWoCoverNote.UnderwriterName, objDebitNoteWoCoverNote.UserApprovalId, objDebitNoteWoCoverNote.ApprovalStatus };
            return dataAccess.LoadDataSet(parameters, "P_GetApprovalViseDNStatus", "P_DN_DebitNoteWOCoverNote");
        }
        public DataSet GetDebiteNoteWOCoverNoteUpdate(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[18] { objDebitNoteWoCoverNote.DbtNoteType, objDebitNoteWoCoverNote.FromDate, objDebitNoteWoCoverNote.ToDate, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.ClientName, objDebitNoteWoCoverNote.ClientCode, objDebitNoteWoCoverNote.Primary_AccountHandler, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.MainClassName, objDebitNoteWoCoverNote.UnderwriterName, objDebitNoteWoCoverNote.CoverNoteNo, objDebitNoteWoCoverNote.SubClassName, objDebitNoteWoCoverNote.BranchId, objDebitNoteWoCoverNote.CompanyId, objDebitNoteWoCoverNote.KeyAccountmanager, objDebitNoteWoCoverNote.Industrytype, objDebitNoteWoCoverNote.UnderwriterShortName, objDebitNoteWoCoverNote.IsRenewalType };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNoteUpdate", "P_DN_DebitNoteWOCoverNoteUpdate");

        }
        public DataSet GetDebitNoteWOCoverNoteEndorsementListEnquiry(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[19] { objDebitNoteWoCoverNote.FromDate, objDebitNoteWoCoverNote.ToDate, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.ClientName, objDebitNoteWoCoverNote.ClientCode, objDebitNoteWoCoverNote.Primary_AccountHandler, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.MainClassName, objDebitNoteWoCoverNote.UnderwriterName, objDebitNoteWoCoverNote.CoverNoteNo, objDebitNoteWoCoverNote.SubClassName, objDebitNoteWoCoverNote.DebitNoteStatus, objDebitNoteWoCoverNote.BranchId, objDebitNoteWoCoverNote.CompanyId, objDebitNoteWoCoverNote.KeyAccountmanager, objDebitNoteWoCoverNote.Industrytype, objDebitNoteWoCoverNote.UserLoginId, objDebitNoteWoCoverNote.UnderwriterShortName, objDebitNoteWoCoverNote.IsRenewalType };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNoteEndorsementList", "DN_DebitNoteWOCoverNoteEndorsementList");
        }
        public DataSet GetDebitNoteWOCoverNoteHistoryListEnquiry(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[18] { objDebitNoteWoCoverNote.DbtNoteType, objDebitNoteWoCoverNote.FromDate, objDebitNoteWoCoverNote.ToDate, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.ClientName, objDebitNoteWoCoverNote.ClientCode, objDebitNoteWoCoverNote.Primary_AccountHandler, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.MainClassName, objDebitNoteWoCoverNote.UnderwriterName, objDebitNoteWoCoverNote.CoverNoteNo, objDebitNoteWoCoverNote.SubClassName, objDebitNoteWoCoverNote.DebitNoteStatus, objDebitNoteWoCoverNote.BranchId, objDebitNoteWoCoverNote.CompanyId, objDebitNoteWoCoverNote.UserLoginId, objDebitNoteWoCoverNote.UnderwriterShortName, objDebitNoteWoCoverNote.IsRenewalType };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNoteHistoryList", "DN_DebitNoteWOCoverNoteHistoryList");
        }
        public DataSet GetDebitNoteWOCoverNotePrintListEnquiry(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[25] { objDebitNoteWoCoverNote.PolicyNo, objDebitNoteWoCoverNote.DbtNoteType, objDebitNoteWoCoverNote.FromDate, objDebitNoteWoCoverNote.ToDate, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.ClientName, objDebitNoteWoCoverNote.ClientCode, objDebitNoteWoCoverNote.Primary_AccountHandler, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.MainClassName, objDebitNoteWoCoverNote.UnderwriterName, objDebitNoteWoCoverNote.CoverNoteNo, objDebitNoteWoCoverNote.SubClassName, objDebitNoteWoCoverNote.DebitNoteStatus, objDebitNoteWoCoverNote.BranchId, objDebitNoteWoCoverNote.CompanyId, objDebitNoteWoCoverNote.KeyAccountmanager, objDebitNoteWoCoverNote.Industrytype, objDebitNoteWoCoverNote.UserLoginId, objDebitNoteWoCoverNote.UnderwriterShortName, objDebitNoteWoCoverNote.BillingDueFromDate, objDebitNoteWoCoverNote.BillingDueToDate, objDebitNoteWoCoverNote.InstaDueFromDate, objDebitNoteWoCoverNote.InstaDueToDate, objDebitNoteWoCoverNote.IsRenewalType };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNotePrintList", "DN_DebitNoteWOCoverNoteHistoryList");
        }


        public DataSet InsertDebitNoteWOCoverNoteClientInstalment(clsDebitNoteWOCoverNoteInstalment objDebitNoteWOCoverNoteClientInstalment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {  objDebitNoteWOCoverNoteClientInstalment.CaseRefNo ,objDebitNoteWOCoverNoteClientInstalment.RefNo ,objDebitNoteWOCoverNoteClientInstalment.InstNo,objDebitNoteWOCoverNoteClientInstalment.InstPercentage,objDebitNoteWOCoverNoteClientInstalment.Currency, objDebitNoteWOCoverNoteClientInstalment.DebitNoteDate	,objDebitNoteWOCoverNoteClientInstalment.PeriodFrom,objDebitNoteWOCoverNoteClientInstalment.PeriodTo ,objDebitNoteWOCoverNoteClientInstalment.Premium,objDebitNoteWOCoverNoteClientInstalment.Discount ,objDebitNoteWOCoverNoteClientInstalment.Fees, objDebitNoteWOCoverNoteClientInstalment.Brokerage,objDebitNoteWOCoverNoteClientInstalment.SpecialDiscount ,objDebitNoteWOCoverNoteClientInstalment.Surcharge,objDebitNoteWOCoverNoteClientInstalment.TotalDue ,objDebitNoteWOCoverNoteClientInstalment.ClientShare,
            objDebitNoteWOCoverNoteClientInstalment.DiscountRate,objDebitNoteWOCoverNoteClientInstalment.SurchargeRate, objDebitNoteWOCoverNoteClientInstalment.SPDiscountRate, objDebitNoteWOCoverNoteClientInstalment.FeesRate ,objDebitNoteWOCoverNoteClientInstalment.PolicyCharge,
            objDebitNoteWOCoverNoteClientInstalment.InsurerGST,objDebitNoteWOCoverNoteClientInstalment.ServiceFee, objDebitNoteWOCoverNoteClientInstalment.ServiceFeeGST, objDebitNoteWOCoverNoteClientInstalment.StampDuty,objDebitNoteWOCoverNoteClientInstalment.TaxRate,
            objDebitNoteWOCoverNoteClientInstalment.TaxAmount,objDebitNoteWOCoverNoteClientInstalment.WHTrate, objDebitNoteWOCoverNoteClientInstalment.WHTAmount,objDebitNoteWOCoverNoteClientInstalment.StampDutyRate,
            objDebitNoteWOCoverNoteClientInstalment.InsurerGSTPer,objDebitNoteWOCoverNoteClientInstalment.InsurerGSTPerId,objDebitNoteWOCoverNoteClientInstalment.ServiceFeeGSTPer,objDebitNoteWOCoverNoteClientInstalment.ServiceFeeGSTPerId,objDebitNoteWOCoverNoteClientInstalment.DebitNoteDueDate};
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNoteClientsInstallmentInsertUpdate", "DebitNoteWOCoverNoteClientsInstallmentInsertUpdate");

        }
        public DataSet GetDataDebiteNoteWOCoverNoteClientInstallmentDetails(clsDebitNoteWOCoverNoteInstalment objDebitNoteWOCoverNoteClientInstalment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWOCoverNoteClientInstalment.CaseRefNo, objDebitNoteWOCoverNoteClientInstalment.RefNo, objDebitNoteWOCoverNoteClientInstalment.DebitNoteNo, objDebitNoteWOCoverNoteClientInstalment.IsFromHistory };
            return dataAccess.LoadDataSet(parameters, "P_DNWOCoverNoteClientInstalmentDetails", "DebitNoteWOCovernoteClientDetailsInstallment");
        }
        public DataSet InsertDebitNoteWOCoverNoteUWriterInstalment(clsDebitNoteWOCoverNoteInstalment objDebitNoteWOCoverNoteClientInstalment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {  objDebitNoteWOCoverNoteClientInstalment.CaseRefNo ,objDebitNoteWOCoverNoteClientInstalment.RefNo ,objDebitNoteWOCoverNoteClientInstalment.InstNo,objDebitNoteWOCoverNoteClientInstalment.InstPercentage,objDebitNoteWOCoverNoteClientInstalment.Currency, objDebitNoteWOCoverNoteClientInstalment.DebitNoteDate	,objDebitNoteWOCoverNoteClientInstalment.PeriodFrom,objDebitNoteWOCoverNoteClientInstalment.PeriodTo ,objDebitNoteWOCoverNoteClientInstalment.Premium,objDebitNoteWOCoverNoteClientInstalment.Discount ,objDebitNoteWOCoverNoteClientInstalment.Fees, objDebitNoteWOCoverNoteClientInstalment.Brokerage,objDebitNoteWOCoverNoteClientInstalment.SpecialDiscount ,objDebitNoteWOCoverNoteClientInstalment.Surcharge,objDebitNoteWOCoverNoteClientInstalment.NetAmount,objDebitNoteWOCoverNoteClientInstalment.UWShare,objDebitNoteWOCoverNoteClientInstalment.TotalDue,objDebitNoteWOCoverNoteClientInstalment.BrokerageRate,  objDebitNoteWOCoverNoteClientInstalment.FeesRate ,objDebitNoteWOCoverNoteClientInstalment.PolicyCharge, objDebitNoteWOCoverNoteClientInstalment.InsurerGST,objDebitNoteWOCoverNoteClientInstalment.StampDuty,  objDebitNoteWOCoverNoteClientInstalment.BrokerGSTAmount,objDebitNoteWOCoverNoteClientInstalment.InsurerTaxRate,objDebitNoteWOCoverNoteClientInstalment.InsurerTaxAmount,
            objDebitNoteWOCoverNoteClientInstalment.CommissionRate,objDebitNoteWOCoverNoteClientInstalment.CommissionAmount,objDebitNoteWOCoverNoteClientInstalment.TaxRate,objDebitNoteWOCoverNoteClientInstalment.TaxAmount,objDebitNoteWOCoverNoteClientInstalment.WHTrate,objDebitNoteWOCoverNoteClientInstalment.WHTAmount,objDebitNoteWOCoverNoteClientInstalment.InsurerGSTPer,objDebitNoteWOCoverNoteClientInstalment.InsurerGSTPerId,objDebitNoteWOCoverNoteClientInstalment.BrokerGSTper,objDebitNoteWOCoverNoteClientInstalment.BrokerGSTperId,objDebitNoteWOCoverNoteClientInstalment.DebitNoteDueDate};
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNoteUWriterInstallmentInsertUpdate", "DebitNoteWOCoverNoteUWriterInstallmentInsertUpdate");

        }
        public DataSet GetDataDebiteNoteWOCoverNoteUWriterInstallmentDetails(clsDebitNoteWOCoverNoteInstalment objDebitNoteWOCoverNoteClientInstalment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWOCoverNoteClientInstalment.CaseRefNo, objDebitNoteWOCoverNoteClientInstalment.RefNo, objDebitNoteWOCoverNoteClientInstalment.DebitNoteNo, objDebitNoteWOCoverNoteClientInstalment.IsFromHistory };
            return dataAccess.LoadDataSet(parameters, "P_DNWOCoverNoteUWriterInstalmentDetails", "DNWOCoverNoteUWriterInstalmentDetails");
        }
        public DataSet InsertDebitNoteWOCoverNoteAgentInstalment(clsDebitNoteWOCoverNoteInstalment objDebitNoteWOCoverNoteClientInstalment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[14] { objDebitNoteWOCoverNoteClientInstalment.CaseRefNo, objDebitNoteWOCoverNoteClientInstalment.RefNo, objDebitNoteWOCoverNoteClientInstalment.InstNo, objDebitNoteWOCoverNoteClientInstalment.InstPercentage, objDebitNoteWOCoverNoteClientInstalment.Currency, objDebitNoteWOCoverNoteClientInstalment.DebitNoteDate, objDebitNoteWOCoverNoteClientInstalment.PeriodFrom, objDebitNoteWOCoverNoteClientInstalment.PeriodTo, objDebitNoteWOCoverNoteClientInstalment.Premium, objDebitNoteWOCoverNoteClientInstalment.Brokerage, objDebitNoteWOCoverNoteClientInstalment.AgentShare, objDebitNoteWOCoverNoteClientInstalment.TotalDue, objDebitNoteWOCoverNoteClientInstalment.User, objDebitNoteWOCoverNoteClientInstalment.DebitNoteDueDate };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNoteAgentInstallmentInsertUpdate", "DebitNoteWOCoverNoteAgentInstallmentInsertUpdate");

        }
        public DataSet GetDataDebiteNoteWOCoverNoteAgentInstallmentDetails(clsDebitNoteWOCoverNoteInstalment objDebitNoteWOCoverNoteClientInstalment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWOCoverNoteClientInstalment.CaseRefNo, objDebitNoteWOCoverNoteClientInstalment.RefNo, objDebitNoteWOCoverNoteClientInstalment.DebitNoteNo, objDebitNoteWOCoverNoteClientInstalment.IsFromHistory };
            return dataAccess.LoadDataSet(parameters, "P_DNWOCoverNoteAgentInstalmentDetails", "DNWOCoverNoteAgentInstalmentDetails");
        }
        //done by Satya
        public DataSet GetDebiteNoteInstalment(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[23] { objDebitNoteWoCoverNote.PolicyNo, objDebitNoteWoCoverNote.DbtNoteType, objDebitNoteWoCoverNote.FromDate, objDebitNoteWoCoverNote.ToDate, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.ClientName, objDebitNoteWoCoverNote.ClientCode, objDebitNoteWoCoverNote.Primary_AccountHandler, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.MainClassName, objDebitNoteWoCoverNote.UnderwriterName, objDebitNoteWoCoverNote.CoverNoteNo, objDebitNoteWoCoverNote.SubClassName, objDebitNoteWoCoverNote.DebitNoteStatus, objDebitNoteWoCoverNote.BranchId, objDebitNoteWoCoverNote.CompanyId, objDebitNoteWoCoverNote.KeyAccountmanager, objDebitNoteWoCoverNote.Industrytype, objDebitNoteWoCoverNote.UserLoginId, objDebitNoteWoCoverNote.UnderwriterShortName, objDebitNoteWoCoverNote.InstaDueFromDate, objDebitNoteWoCoverNote.InstaDueToDate, objDebitNoteWoCoverNote.TeamId };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteTrackInst", "P_DN_DebitNoteTrackInst");
        }
        public DataSet ApproveDebiteNote(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteApproval", "P_DN_DebitNoteTrackInst");
        }
        public DataSet GetDebitNoteWithCoverNoteRePrint(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[21] { objDebitNoteWoCoverNote.DbtNoteType, objDebitNoteWoCoverNote.FromDate, objDebitNoteWoCoverNote.ToDate, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.ClientName, objDebitNoteWoCoverNote.ClientCode, objDebitNoteWoCoverNote.Primary_AccountHandler, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.MainClassName, objDebitNoteWoCoverNote.UnderwriterName, objDebitNoteWoCoverNote.CoverNoteNo, objDebitNoteWoCoverNote.SubClassName, objDebitNoteWoCoverNote.DebitNoteStatus, objDebitNoteWoCoverNote.BranchId, objDebitNoteWoCoverNote.CompanyId, objDebitNoteWoCoverNote.KeyAccountmanager, objDebitNoteWoCoverNote.Industrytype, objDebitNoteWoCoverNote.UserLoginId, objDebitNoteWoCoverNote.UnderwriterShortName, objDebitNoteWoCoverNote.InstaDueFromDate, objDebitNoteWoCoverNote.InstaDueToDate };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWithCoverNoteRePrint", "DN_DebitNoteWithCoverNoteRePrint");
        }
        //till here

        public DataSet BulkInsertDebitNoteCoverNoteClient(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objDebitNoteWoCoverNote.CaseRefNo };
            return dataAccess.LoadDataSet(parameters, "P_TM_DebitNoteWOCoverNoteClientsBulkInsert", "TM_DebitNoteWOCoverNoteClientsbulkInsert");

        }

        public void SqlInsertMPFEmployeeDataTableWithParam(string strConStr, DataTable dtExcel, clsDebiteNoteWOCoverNote objDebitWOCN)
        {
            SqlConnection sqlcon = null;
            try
            {
                sqlcon = new SqlConnection(strConStr);
                sqlcon.Open();
                SqlCommand scCmd = new SqlCommand("P_Pol_MPFClient_BulkInsert", sqlcon);
                scCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@MPFupload", SqlDbType.Structured);
                param.Value = dtExcel;
                SqlParameter[] tvp = new SqlParameter[]
                {
                    new SqlParameter("@CaseRefNo", objDebitWOCN.CaseRefNo),
                    new SqlParameter("@UserID", objDebitWOCN.UserID),
                    param
                };
                scCmd.Parameters.AddRange(tvp);
                scCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcon.Close();
            }
        }

        //added on 15th November
        public DataSet GetCompanyDetails()
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { };
            return dataAccess.LoadDataSet(parameters, "getCompanyDetails", "TM_GetCompanyDetails");
        }
        // added on 16 March for RedmineIS 12730
        public DataSet GetDebitNoteDetailsPrintConsultancyFee(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote, string coverageType)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.DebitNoteNo, coverageType };
            return dataAccess.LoadDataSet(parameters, "P_GetDebitNoteDetailsPrintConsultancyFee", "P_GetDebitNoteDetailsPrintConsultancy_Acclaim");
        }

        public void UpdateIsPrintStatus(clsDebiteNoteWOCoverNote objDebitWOCN)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] {   objDebitWOCN.CaseRefNo
                                                };
            dataAccess.ExecuteNonQuery("P_Pol_DebitNoteIsPrintedUpdate", parameters);
        }

        public DataSet getPrintDebitNote_IH(string caserefno)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { caserefno };
            return dataAccess.LoadDataSet(parametes, "P_DebitNote_PrintInstallment_IH", "TM_DebitNote_PrintInstallment_IH");
        }

        public DataSet GetFeeBillingLinkedIntroducers(string caserefno)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { caserefno };
            return dataAccess.LoadDataSet(parametes, "P_FeeB_GetLinkedIntroducer", "P_FeeB_GetLinkedIntroducer");
        }

        public DataSet CheckACMonth_ForCompleteDrCrNote(string DrCrNoteCreationDate)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { DrCrNoteCreationDate };
            return dataAccess.LoadDataSet(parameters, "P_CheckACMonth_ForCompleteDrCrNote", "P_CheckACMonth_ForCompleteDrCrNote");
        }

        public DataSet AmendmentClientDetailsDelete(clsDebiteNoteWOCoverNote objDebitWOCN)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objDebitWOCN.CaseRefNo };
            return dataAccess.LoadDataSet(parameters, "P_DN_Amendt_ClientDetails_Delete", "P_DN_Amendt_ClientDetails_Delete");
        }

        public DataSet GetDebiteNoteWOCoverNoteForRenewal(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[18] { objDebitNoteWoCoverNote.DbtNoteType, objDebitNoteWoCoverNote.FromDate, objDebitNoteWoCoverNote.ToDate, objDebitNoteWoCoverNote.DebitNoteNo, objDebitNoteWoCoverNote.CoverNoteNo, objDebitNoteWoCoverNote.PolicyNo, objDebitNoteWoCoverNote.ClientName, objDebitNoteWoCoverNote.ClientCode, objDebitNoteWoCoverNote.Primary_AccountHandler, objDebitNoteWoCoverNote.UserID, objDebitNoteWoCoverNote.DivisionalGrouping, objDebitNoteWoCoverNote.MainClassName, objDebitNoteWoCoverNote.SubClassName, objDebitNoteWoCoverNote.UnderwriterName, objDebitNoteWoCoverNote.KeyAccountmanager, objDebitNoteWoCoverNote.Industrytype, objDebitNoteWoCoverNote.UserLoginId, objDebitNoteWoCoverNote.IsRenewalType };
            return dataAccess.LoadDataSet(parameters, "P_DN_DebitNoteWOCoverNote_Renewal", "P_DN_DebitNoteWOCoverNote");
        }


        public DataSet GetDebiteNoteWOCoverNoteIsInserted(string CaseRefNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { CaseRefNo };
            return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteInsertCheckForRenewal", "P_DN_WOCoverNoteInsertCheckForRenewal");
        }
        //public DataSet DebiteNoteWOCoverNoteInsertForRenewal(string CaseRefNo)
        //{
        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[1] { CaseRefNo };
        //    return dataAccess.LoadDataSet(parameters, "P_DN_WOCoverNoteInsertUpdateRenewal", "P_DN_DebitNoteWOCoverNote");
        //}

        //Added for #24376
        public DataSet CreateDebitNote_Copy(clsDebiteNoteWOCoverNote objDebitWOCN)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objDebitWOCN.CaseRefNo };
            return dataAccess.LoadDataSet(parameters, "P_TM_DebitNoteWOCoverNoteCreateCopy", "TM_DebitNoteWOCoverNote");
        }
        //Added for #24376
        public DataSet GetSavedRiskData(clsDebiteNoteWOCoverNote objDebitWOCN)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objDebitWOCN.CaseRefNo };
            return dataAccess.LoadDataSet(parameters, "P_GetSavedRisk", "TM_DebitNoteWOCoverNote");
        }
        //Added for 13832
        public DataSet GetEndorsementPrintList_BIB(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.PolicyID, objDebitNoteWoCoverNote.PolicyVerId };
            return dataAccess.LoadDataSet(parameters, "P_GetEndorsementPrint_BIB", "TM_DebitNoteWOCoverNote");
        }

        public DataSet GetEndorsementDetails(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objDebitNoteWoCoverNote.PolicyID, objDebitNoteWoCoverNote.PolicyVerId };
            return dataAccess.LoadDataSet(parameters, "P_GetEndorsementType", "TM_DebitNoteWOCoverNote");
        }
        public DataSet GetBrokerageRevenueDetails(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objDebitNoteWoCoverNote.PolicyID, objDebitNoteWoCoverNote.PolicyVerId, objDebitNoteWoCoverNote.CaseRefNo };
            return dataAccess.LoadDataSet(parameters, "P_GetBrokerageRevenue", "TM_DebitNoteWOCoverNoteBrokerageRevenue");
        }
        public DataSet UpdateBrokerageRevenue(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objDebitNoteWoCoverNote.CaseRefNo, objDebitNoteWoCoverNote.PeriodNo, objDebitNoteWoCoverNote.RecogPercentage, objDebitNoteWoCoverNote.RecogAmount };
            return dataAccess.LoadDataSet(parameters, "P_UpdateBrokerageRevenue", "TM_DebitNoteWOCoverNoteBrokerageRevenue");
        }


        public DataSet GetDebitNoteStatus(clsDebiteNoteWOCoverNote objDebitNoteWoCoverNote)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objDebitNoteWoCoverNote.CaseRefNo };
            return dataAccess.LoadDataSet(parameters, "P_GetDebitCreditNoteStatus", "TM_DebitNoteWOCoverNote");
        }
    }
}
