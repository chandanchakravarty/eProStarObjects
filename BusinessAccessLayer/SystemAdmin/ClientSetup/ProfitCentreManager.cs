using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.ClientSetup;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class ProfitCentreManager
    {
        DataAccess dataAccess = null;
        ClsProfitCentre objPCinfo = new ClsProfitCentre();

        public DataSet getProfitCentreAll(ClsProfitCentre objinfo){
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objinfo.ProfitCentreId };
            return dataAccess.LoadDataSet(parameters, "P_Adm_ProfitCentreList", "ProfitCentreList");
        }

        public DataSet getProfitCentreSrch(ClsProfitCentre objProfitCentreinfo)
        {
            dataAccess = new DataAccess();
            if (objProfitCentreinfo.ProfitCentreDesc == null)
            {
                objProfitCentreinfo.ProfitCentreDesc = "";
            }
            if (objProfitCentreinfo.EffectiveFromDate == null)
            {
                objProfitCentreinfo.EffectiveFromDate = "";
            }
            if (objProfitCentreinfo.EffectiveFromDate1 == null)
            {
                objProfitCentreinfo.EffectiveFromDate1 = "";
            }
            if (objProfitCentreinfo.EffectiveToDate == null)
            {
                objProfitCentreinfo.EffectiveToDate = "";
            }
            if (objProfitCentreinfo.EffectiveToDate1 == null)
            {
                objProfitCentreinfo.EffectiveToDate1 = "";
            }
            Object[] parameters = new Object[] { objProfitCentreinfo.ProfitCentreDesc, objProfitCentreinfo.EffectiveFromDate, objProfitCentreinfo.EffectiveFromDate1, objProfitCentreinfo.EffectiveToDate, objProfitCentreinfo.EffectiveToDate1 };
            return dataAccess.LoadDataSet(parameters, "P_Adm_ProfitCentreListAll", "ProfitCentreList");
        }


        public DataSet SaveProfitCentreMaster(ClsProfitCentre objProfitCentre)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objProfitCentre.ProfitCentreId,
                                               objProfitCentre.ProfitCentreDesc,
                                               objProfitCentre.EffectiveFromDate,
                                               objProfitCentre.EffectiveToDate,
                                               objProfitCentre.LoginUserId,
                                               objProfitCentre.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Adm_ProfitCentre_InsertUpdate", "ProfitCentre");
        }
    }
}
