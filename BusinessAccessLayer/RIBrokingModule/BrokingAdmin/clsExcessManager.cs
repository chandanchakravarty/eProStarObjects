using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.RIBrokingModule.BrokingAdmin
{
    public class clsExcessManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadExcess(clsExcessMaster objExcess)
        {
            object[] parameters = new object[1] { objExcess.ExcessID };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ExcessMaster_Select", "ExcessSelect");

        }
        public DataSet SaveExcess(clsExcessMaster objExcess)
        {
            object[] parameters = new object[] { objExcess.ExcessID,
                                                 objExcess.ClassID,
                                                 objExcess.SubClassID,
                                                 objExcess.Description,
                                                 objExcess.EffFromDate,
                                                 objExcess.EffToDate,
                                                 objExcess.Status,
                                                 objExcess.LoginUserId,
                                                 objExcess.PageMethod
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ExcessMaster_InsertUpdate", "Excess");

        }
    }
}
