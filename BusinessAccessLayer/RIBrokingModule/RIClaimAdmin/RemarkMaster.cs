using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.RIClaimAdmin;

namespace BusinessAccessLayer.RIBrokingModule.RIClaimAdmin
{
    public class RemarkMaster
    {
        DataAccess objDataAccess = null;
        public DataSet InsertUpdateRemarkDescription(clsRemarkMaster objclsRemarkMaster)
        {
            objDataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objclsRemarkMaster.RemarkId, objclsRemarkMaster.RemarkDescription, objclsRemarkMaster.EffectiveDateFrom, objclsRemarkMaster.EffectiveDateTo, objclsRemarkMaster.User, objclsRemarkMaster.IsActive };
            return objDataAccess.LoadDataSet(parameters, "P_TM_RemarkMaster_InsertUpdate", "TM_RemarkMaster");
        }

        public DataSet GetRemarkDescription(clsRemarkMaster objclsRemarkMaster)
        {
            objDataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objclsRemarkMaster.RemarkId};
            return objDataAccess.LoadDataSet(parameters, "P_TM_RemarkDescription_Select", "TM_RemarkMaster");
        }
    }
}