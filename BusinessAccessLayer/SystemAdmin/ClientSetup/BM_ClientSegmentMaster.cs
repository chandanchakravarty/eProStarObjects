using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using System.Data;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class BM_ClientSegmentMaster
    {
        DataAccess dataAccessDS = null;


        public DataSet LoadClientSegmentMasterData(clsClientSegmentMaster objclsClientSegmentMaster)
        {
            object[] parameters = new object[] { objclsClientSegmentMaster.ClientSegmentId, objclsClientSegmentMaster.ClientSegmentCode, objclsClientSegmentMaster.ClientSegmentDesc, objclsClientSegmentMaster.EffectiveFromDate, objclsClientSegmentMaster.EffectiveFromDate1, objclsClientSegmentMaster.EffectiveToDate, objclsClientSegmentMaster.EffectiveToDate1 };
            return (new DataAccess()).LoadDataSet(parameters, "P_TM_ClientSegmentMaster_Select", "TM_ClientSegmentMaster");

        }

        public DataSet SaveClientSegmentMaster(clsClientSegmentMaster objclsClientSegmentMaster)
        {
            object[] parameters = new object[] { 
                                                    objclsClientSegmentMaster.ClientSegmentId,
                                                    objclsClientSegmentMaster.ClientSegmentCode,
                                                    objclsClientSegmentMaster.ClientSegmentDesc,
                                                    objclsClientSegmentMaster.EffectiveFromDate,
                                                    objclsClientSegmentMaster.EffectiveToDate,
                                                    objclsClientSegmentMaster.User
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ClientSegmentMaster_InsertUpdate", "TM_ClientSegmentMaster");
        }
    }
}
