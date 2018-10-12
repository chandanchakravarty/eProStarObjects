using BusinessObjectLayer.SystemAdmin.ClientSetup;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class ClientProfileMaster
    {
        DataAccess dataAccess = null;

        public DataSet GetClientProfileDetails(clsClientProfileMaster objClientProfile)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objClientProfile.ClientProfileID, objClientProfile.ClientProfile, objClientProfile.EffFrom, objClientProfile.EffFrom1, objClientProfile.EffTo, objClientProfile.EffTo1 };
            return dataAccess.LoadDataSet(parameters, "P_TM_GetClientProfileDetails", "ClientProfileDetails");
        }

        public DataSet SaveClientProfileDetails(clsClientProfileMaster objClientProfile)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                objClientProfile.ClientProfileID,
                objClientProfile.ClientProfile,
                objClientProfile.EffFrom ,
                objClientProfile.EffTo  ,
                objClientProfile.CreatedBy
            };

            return dataAccess.LoadDataSet(parameters, "P_TM_ClientProfile_InsertUpdate", "ClientProfileInsertUpdate");
        }
    }
}
