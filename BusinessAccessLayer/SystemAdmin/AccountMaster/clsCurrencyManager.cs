using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.AccountMaster;

namespace BusinessAccessLayer.SystemAdmin.AccountMaster
{
    public class clsCurrencyManager
    {
        DataAccess dataAccess = null;
        clsCurrency objClass = new clsCurrency();
        public DataSet getCurrency(clsCurrency objCurrency)
        {
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            Object[] parametes = new Object[1] { objCurrency.CurrencyId };
             ds=dataAccess.LoadDataSet(parametes, "P_TM_CurrencyMaster_Select", "CurrencySelect");
             return ds;
        }
        public DataSet SaveCurrency(clsCurrency objClass)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {
                                               objClass.CurrencyId,
                                               objClass.CurrencyCode,
                                               objClass.CurrencyDescription,
                                               objClass.EffFromDate,
                                               objClass.EffToDate,
                                               objClass.Status,
                                               objClass.LoginUserId,
                                               objClass.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parametes, "P_TM_CurrencyMaster_InsertUpdate", "Currency");
        }
        public DataSet getCurrencyDetails(string CurrencyCode)
        {
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            Object[] parametes = new Object[1] { CurrencyCode };
            ds = dataAccess.LoadDataSet(parametes, "P_TM_CurrencyDetails_Select", "CurrencySelect");
            return ds;
        }
    }
}
