using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.AccountMaster;

namespace BusinessAccessLayer.SystemAdmin.AccountMaster
{
   public class AccPeriod
    {

       DataAccess dataAccess = null;
       clsAccPeriod objclsAccPeriod = new clsAccPeriod();
       public DataSet LoadAccPeriod(clsAccPeriod objclsAccPeriod)
       {
           dataAccess = new DataAccess();
           DataSet ds = new DataSet();
           
           Object[] parametes = new Object[] { objclsAccPeriod.AccYear,
                                               objclsAccPeriod.AccMonth
                                             };
           ds = dataAccess.LoadDataSet(parametes, "P_TM_AnalysisCatMaster_Select", "TM_AnalysisCatMaster");
           return ds;
       }

       public DataSet SaveAccPeriod(clsAccPeriod objclsAccPeriod)
       {

           dataAccess = new DataAccess();
           Object[] parametes = new Object[] {
                                               objclsAccPeriod.AccYear,
                                               objclsAccPeriod.AccMonth,
                                               objclsAccPeriod.EffectiveDateFrom,
                                               objclsAccPeriod.EffectiveDateTo,
                                               objclsAccPeriod.User
                                             };
           return dataAccess.LoadDataSet(parametes, "P_TM_AnalysisCatMaster_InsertUpdate", "TM_AnalysisCatMaster");
           
       
       }
    }
}
