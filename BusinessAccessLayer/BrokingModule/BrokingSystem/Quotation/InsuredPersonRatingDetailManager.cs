using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem.Quotation
{
   public  class InsuredPersonRatingDetailManager
    {
        DataAccess dataAccess = null;

        public DataSet SaveInsuredPersonRatingDetails(clsRatingDetails  objInsuredPersonDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[34] { objInsuredPersonDetails.RefNo, objInsuredPersonDetails.PolicyId, 
                objInsuredPersonDetails.PolVersionId,objInsuredPersonDetails.Insurer ,
            objInsuredPersonDetails.InsuredName,objInsuredPersonDetails.Surname,
            objInsuredPersonDetails.DOB, objInsuredPersonDetails.age , objInsuredPersonDetails.Gender,objInsuredPersonDetails.Nationality,
            objInsuredPersonDetails.CountryOfRes, objInsuredPersonDetails.PIHCardNo,objInsuredPersonDetails.Scheme,
            objInsuredPersonDetails.Program,objInsuredPersonDetails.PlanType,objInsuredPersonDetails.Deductible,
            objInsuredPersonDetails.PremiumRate, objInsuredPersonDetails.PremWithInstl,objInsuredPersonDetails.StamDuty,objInsuredPersonDetails.SBT,objInsuredPersonDetails.VAT
            ,objInsuredPersonDetails.GrossPremium,objInsuredPersonDetails.Commission,objInsuredPersonDetails.IsActive, 
            objInsuredPersonDetails.UserID,objInsuredPersonDetails.IHDiscount,objInsuredPersonDetails.IHDiscountAmt,objInsuredPersonDetails.MemberType,objInsuredPersonDetails.ageDays,objInsuredPersonDetails.ageMonth,objInsuredPersonDetails.IHSbtAmount,objInsuredPersonDetails.IHStampDutyAmount
            ,objInsuredPersonDetails.IHLoadingPer,objInsuredPersonDetails.IHLoadingPerAmt}; 
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_InsuredPersonRatingDetailsInsertUpdate", "PolicyInsuredPersonRatingDetailsInsertUpdate");
        }

        public DataSet GetInsuredPersonRatingDetails(clsRatingDetails  objInsuredPersonDetails)
        {
            dataAccess = new DataAccess();
            
            Object[] parametes = new Object[3] { objInsuredPersonDetails.PolicyId, objInsuredPersonDetails.PolVersionId, objInsuredPersonDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_InsuredPersonRatingDetails", "PolicyInsuredPersonRatingDetails");
        }

        public DataSet DeleteInsuredPersonRatingDetails(clsRatingDetails  objInsuredPersonDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objInsuredPersonDetails.PolicyId, objInsuredPersonDetails.PolVersionId, objInsuredPersonDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_InsuredPersonRatingDetails_Delete", "PolicyInsuredPersonRatingDetails");
        }
        public DataSet SelectInsuredPersonRatingDetails(clsRatingDetails objInsuredPersonDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { objInsuredPersonDetails.PolicyId, objInsuredPersonDetails.PolVersionId};
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_InsuredPersonRatingDetails_Select", "PolicyInsuredPersonRatingDetails");
        }

        public DataSet SelectIHPersonFirstVerRefNoForEndt(clsRatingDetails objInsuredPersonDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objInsuredPersonDetails.PolicyId, objInsuredPersonDetails.PolVersionId, objInsuredPersonDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_Pol_IHPersonDetails_FirstVerRefNo_Endorsement", "IHParentPolicyRefNo");
        }


        public DataSet GetInsuredPersonDetails(clsRatingDetails objInsuredPersonDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { objInsuredPersonDetails.PolicyId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_GEt_Policy_InsuredPersonRatingDetails", "PolicyInsuredPersonRatingDetails");
        }

        public DataSet GetBindInsuredDetails(clsRatingDetails  objInsuredPersonDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { objInsuredPersonDetails.PolicyId, objInsuredPersonDetails.PolVersionId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_InsuredPersonRatingDetailsBind", "PolicyInsuredPersonRatingDetailsBind");
        }
       public DataSet GetBindInsuredGridBind(clsRatingDetails  objInsuredPersonDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { objInsuredPersonDetails.PolicyId, objInsuredPersonDetails.PolVersionId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_InsuredPersonRatingDetailsGridBind", "PolicyInsuredPersonRatingDetailsBind");
        }
       public DataSet getIHPremium(clsRatingDetails objInsuredPersonDetails)
        {
            dataAccess = new DataAccess();
            //Previous code
            //Object[] parametes = new Object[3] { objInsuredPersonDetails.PolicyId, objInsuredPersonDetails.PolVersionId, objInsuredPersonDetails.RefNo };
            //end
            Object[] parametes = new Object[4] { objInsuredPersonDetails.Program, objInsuredPersonDetails.PlanType, objInsuredPersonDetails.Deductible, objInsuredPersonDetails.age};
            return dataAccess.LoadDataSet(parametes, "P_Pol_getPremiumRate", "IHPremiumRate");

        }
       public DataSet getIHMasterPolicyReport(clsRatingDetails objInsuredPersonDetails)
       {   // IH Master Policy Report
           dataAccess = new DataAccess();
           Object[] parametes = new Object[4] { objInsuredPersonDetails.ClientCode, objInsuredPersonDetails.ClientName, objInsuredPersonDetails.MasterPolicyNo, objInsuredPersonDetails.ConfirmationSlipNo };
           return dataAccess.LoadDataSet(parametes, "Sp_IHReport_MasterPolicy", "IHMasterPolicyReport");

       }

       public DataSet getIHMonthlyProfitabilityReport(clsRatingDetails objInsuredPersonDetails)
       {   // IH Monthly Profitability Report
           dataAccess = new DataAccess();
           Object[] parametes = new Object[6] { objInsuredPersonDetails.ClientCode, objInsuredPersonDetails.ClientName, objInsuredPersonDetails.MasterPolicyNo, objInsuredPersonDetails.ConfirmationSlipNo, objInsuredPersonDetails.POIFrom, objInsuredPersonDetails.POIToDate };
           return dataAccess.LoadDataSet(parametes, "Sp_Monthly_Profitability_Report", "IHMonthlyProfitabilityReport");

       }
       public DataSet getIHAvivaMonthlyReport(clsRatingDetails objInsuredPersonDetails)
       {   // IH Aviva Database Profitability Report
           dataAccess = new DataAccess();
           Object[] parametes = new Object[6] { objInsuredPersonDetails.ClientName, objInsuredPersonDetails.InsuredFullName, objInsuredPersonDetails.PolicyNo, objInsuredPersonDetails.POIFrom, objInsuredPersonDetails.POIToDate, objInsuredPersonDetails.RptType };
           return dataAccess.LoadDataSet(parametes, "Sp_IHReport_AvivaMonthlyreport", "AvivaDatabaseMonthlyReport");

       }
       public DataSet getHBCDailyReport(clsRatingDetails objInsuredPersonDetails)
       {   // IH Aviva Database Profitability Report
           dataAccess = new DataAccess();
           Object[] parametes = new Object[5] { objInsuredPersonDetails.Program, objInsuredPersonDetails.PlanType, objInsuredPersonDetails.Scheme, objInsuredPersonDetails.POIFrom, objInsuredPersonDetails.POIToDate};
           return dataAccess.LoadDataSet(parametes, "Sp_HBCDailyReport_IH", "HBCDailyReport");

       }
       public DataSet getIHSafetySummaryReport(clsRatingDetails objInsuredPersonDetails)
       {   // IH Safety Summary Report
           dataAccess = new DataAccess();
           Object[] parametes = new Object[6] { objInsuredPersonDetails.PolicyNo, objInsuredPersonDetails.InsuredFullName, objInsuredPersonDetails.ClientName, objInsuredPersonDetails.RptType, objInsuredPersonDetails.POIFrom, objInsuredPersonDetails.POIToDate };
           return dataAccess.LoadDataSet(parametes, "Sp_IHReport_SafetySummaryReport", "SafetySummaryReport");

       }
       public DataSet getIHIndividualSummaryReport(clsRatingDetails objInsuredPersonDetails)
       {   // IH Individual Summary Report
           dataAccess = new DataAccess();
           Object[] parametes = new Object[4] { objInsuredPersonDetails.PolicyNo, objInsuredPersonDetails.InsuredFullName, objInsuredPersonDetails.POIFrom, objInsuredPersonDetails.POIToDate };
           return dataAccess.LoadDataSet(parametes, "IH_Individual_inforce_Policy_Sum_Rpt", "IndividualSummaryReport");

       }
    }
}
