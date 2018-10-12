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
    public class ClientSourceManager
    {
        DataAccess dataAccess = null;
        clsClientSource objinfo = new clsClientSource();

        public DataSet getClientSourceAll(clsClientSource objcsinfo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objcsinfo.ClientSourceId };
            return dataAccess.LoadDataSet(parameters, "P_Adm_ClientSourceList", "CSList");
        }

        public DataSet getClientSourceSrch(clsClientSource objclientsourceInfo)
        {
            dataAccess = new DataAccess();
            if (objclientsourceInfo.ClientSourceCode == null)
            {
                objclientsourceInfo.ClientSourceCode = "";
            }
            if (objclientsourceInfo.ClientSourceDesc == null)
            {
                objclientsourceInfo.ClientSourceDesc = "";
            }
            if (objclientsourceInfo.EffectiveFromDate == null)
            {
                objclientsourceInfo.EffectiveFromDate = "";
            }
            if (objclientsourceInfo.EffectiveFromDate1 == null)
            {
                objclientsourceInfo.EffectiveFromDate1 = "";
            }
            if (objclientsourceInfo.EffectiveToDate == null)
            {
                objclientsourceInfo.EffectiveToDate = "";
            }
            if (objclientsourceInfo.EffectiveToDate1 == null)
            {
                objclientsourceInfo.EffectiveToDate1 = "";
            }
            Object[] parameters = new Object[] { objclientsourceInfo.ClientSourceCode, objclientsourceInfo.ClientSourceDesc, objclientsourceInfo.EffectiveFromDate, objclientsourceInfo.EffectiveFromDate1, objclientsourceInfo.EffectiveToDate, objclientsourceInfo.EffectiveToDate1 };
            return dataAccess.LoadDataSet(parameters, "P_Adm_ClientSourceListAll", "ClientsourceList");
        }

        public DataSet SaveCSMaster(clsClientSource objCS)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objCS.ClientSourceId,
                                                objCS.ClientSourceCode,
                                               objCS.ClientSourceDesc,
                                               objCS.EffectiveFromDate,
                                               objCS.EffectiveToDate,
                                               objCS.LoginUserId,
                                               objCS.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Adm_ClientSource_InsertUpdate", "ClientSource");
        }

        public DataSet GetClientSourceOnSelect()
        {
            dataAccess = new DataAccess();
            object[] parameters = new Object[0] { };
            return dataAccess.LoadDataSet(parameters, "[P_Adm_ClientSourceList_OnSelect]", "ClientsourceList1");
        }
    }
}
