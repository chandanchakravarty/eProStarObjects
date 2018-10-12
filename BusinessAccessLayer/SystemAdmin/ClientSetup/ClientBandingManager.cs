using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.ClientSetup;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class ClientBandingManager
    {
        DataAccess dataAccess = null;
        clsClientBandingMaster objinfo = new clsClientBandingMaster();

        public DataSet LoadClientBandingMasterData(clsClientBandingMaster objclsTemplateDefault)
        {
            object[] parameters = new object[] { 
                    objclsTemplateDefault.ClientBandingId,
                    objclsTemplateDefault.ClientBanding,
                    objclsTemplateDefault.BandingRange,
                    objclsTemplateDefault.EffectiveFromDate,
                    objclsTemplateDefault.EffectiveToDate,
                    objclsTemplateDefault.EffectiveFromDate1,
                    objclsTemplateDefault.EffectiveToDate1
            };

            return (new DataAccess()).LoadDataSet(parameters, "P_TM_ClientBandingMaster_Select", "TM_ClientBandingMaster");

        }
        public DataSet LoadClientBandingMasterDataAll(clsClientBandingMaster objclsTemplateDefault)
        {
            object[] parameters = new object[] { objclsTemplateDefault.ClientBandingId };
            return (new DataAccess()).LoadDataSet(parameters, "P_TM_ClientBandingMaster_SelectAll", "TM_ClientBandingMasterAll");

        }

        public DataSet SaveCBMaster(clsClientBandingMaster objCB)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objCB.ClientBandingId,
                                                 objCB.ClientBanding,
                                                 objCB.BandingRange,
                                                 objCB.EffectiveFromDate,
                                                 objCB.EffectiveToDate,
                                                 objCB.LoginUserId,
                                                 objCB.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Adm_ClientBanding_InsertUpdate", "ClientBanding");
        }
    }
}
