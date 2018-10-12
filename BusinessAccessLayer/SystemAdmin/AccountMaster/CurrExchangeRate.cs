using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.AccountMaster;

namespace BusinessAccessLayer.SystemAdmin.AccountMaster
{
   public class CurrExchangeRate
    {
        DataAccess dataAccess = null;
        clsCurrExchangeRate objclsCurrExchangeRate = new clsCurrExchangeRate();
        public DataSet GetCurrExchangeDate(clsCurrExchangeRate objclsCurrExchangeRate)
        {
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            Object[] parametes = new Object[] {
                                                objclsCurrExchangeRate.CurrencyCode,
                                                objclsCurrExchangeRate.CurrExchangeRateId
                                             };
            ds = dataAccess.LoadDataSet(parametes, "P_TM_CurrExchangeRateMaster_selectExchangeDate", "TM_CurrExchangeRateMaster");
            return ds;
            
        }

        public DataSet LoadCurrExchangeRate(clsCurrExchangeRate objclsCurrExchangeRate)
       {
           dataAccess = new DataAccess();
           DataSet ds = new DataSet();
           
           Object[] parametes = new Object[] {
                                                objclsCurrExchangeRate.CurrExchangeRateId
                                                
                                             };
           ds = dataAccess.LoadDataSet(parametes, "P_TM_CurrExchangeRateMaster_select", "TM_CurrExchangeRateMaster");
           return ds;
       }

        public DataSet SaveCurrExchangeRate( clsCurrExchangeRate objclsCurrExchangeRate)
       {

           dataAccess = new DataAccess();
           Object[] parametes = new Object[] {
                                               objclsCurrExchangeRate.CurrExchangeRateId,
                                               objclsCurrExchangeRate.CurrencyId,
                                               objclsCurrExchangeRate.CurrencyCode,
                                               objclsCurrExchangeRate.isExport,
                                               objclsCurrExchangeRate.EffectiveFromDate,
                                               objclsCurrExchangeRate.EffectiveToDate,
                                               objclsCurrExchangeRate.ExchangeRateToCurr,
                                               objclsCurrExchangeRate.ExchangeRateToHKD,
                                               objclsCurrExchangeRate.AccYear,
                                               objclsCurrExchangeRate.User,
                                               objclsCurrExchangeRate.PrevCurrExchangeRateId
                                             };
           return dataAccess.LoadDataSet(parametes, "P_TM_CurrExchangeRateMaster_InsertUpdate", "TM_CurrExchangeRateMaster");
           
       
       }
        public bool IsCodeExists(string CurrencyCode)
        {
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            Object[] parametes = new Object[] {
                                                CurrencyCode
                                               
                                             };
            ds = dataAccess.LoadDataSet(parametes, "P_ADM_CurrencyCodeExist", "TM_CurrExchangeRateMaster");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            

        }
        public string IsDateValid(string dt, string strCode, int TransId)
        {
            string strResult = string.Empty;
            dataAccess = new DataAccess();
            Object[] parametes = new Object[4] { strCode, dt, "MATCH", TransId };
            DataSet ds = dataAccess.LoadDataSet(parametes, "P_AdmCurrencyRate_ValidateDate", "Temp");
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    strResult = "Date already exists.";
            //}
            //else
            //{
                parametes = new Object[4] { strCode, dt, "VALID", TransId };
                ds = dataAccess.LoadDataSet(parametes, "P_AdmCurrencyRate_ValidateDate", "Temp");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strResult = "Expire date must be greater then effective date.";
                }
            //}
            return strResult;
        }
        public DataSet UpdateCurrEffecToDate(clsCurrExchangeRate objclsCurrExchangeRate)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {
                                                objclsCurrExchangeRate.CurrExchangeRateId,
                                               objclsCurrExchangeRate.CurrencyCode,
                                               objclsCurrExchangeRate.EffectiveFromDate
                                              
                                             };
            return dataAccess.LoadDataSet(parametes, "P_TM_CurrEffecTo_Update", "TM_CurrExchangeRateMaster");


        }


    }
}
