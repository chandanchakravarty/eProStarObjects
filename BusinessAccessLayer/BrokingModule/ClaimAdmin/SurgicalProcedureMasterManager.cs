using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
    public class SurgicalProcedureMasterManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadSurgicalProcedure(clsSurgicalProcedureMaster objSurgicalProcedure)
        {
            object[] parameter = new object[1] { objSurgicalProcedure.SurgicalProcedureId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_SurgicalProcedureMaster_Select", "SurgicalProcedureSelect");

        }
        public DataSet SaveSurgicalProcedure(clsSurgicalProcedureMaster objSurgicalProcedure)
        {
            DataAccessDs = new DataAccess();
            object[] parameter = new object[7]{
                                             objSurgicalProcedure.SurgicalProcedureId,
                                             objSurgicalProcedure.SurgicalProcedureCode,
                                             objSurgicalProcedure.SurgicalProcedureDesc,
                                             objSurgicalProcedure.EffectivefromDate,
                                             objSurgicalProcedure.Effectivetodate,
                                             objSurgicalProcedure.User,
                                             objSurgicalProcedure.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_SurgicalProcedureMaster_InsertUpdate", "SurgicalProcedureDetail");

        }
    }
}
