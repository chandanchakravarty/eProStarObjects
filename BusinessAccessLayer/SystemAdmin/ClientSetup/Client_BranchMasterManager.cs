using BusinessObjectLayer.SystemAdmin.ClientSetup;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class Client_BranchMasterManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadBranchMaster(clsBranchMaster objBranchMaster)
        {
            object[] parameters = new object[7] { objBranchMaster.BranchID, objBranchMaster.BranchCode, objBranchMaster.BranchName, objBranchMaster.EffectivefromDate1, objBranchMaster.EffectivefromDate2, objBranchMaster.Effectivetodate1, objBranchMaster.Effectivetodate2 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BranchMaster_Sel", "TM_BranchMaster");
        }

        public DataSet SaveBranchMaster(clsBranchMaster objBranchMaster)
        {
            object[] parameters = new object[] { objBranchMaster.BranchID,
                                                 objBranchMaster.BranchCode,
                                                 objBranchMaster.BranchName,                                                 
                                                 objBranchMaster.EffectivefromDate1,
                                                 objBranchMaster.Effectivetodate1,
                                                 objBranchMaster.User
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BranchMaster_InsUpd", "TM_BranchMaster");
        }
    }
}
