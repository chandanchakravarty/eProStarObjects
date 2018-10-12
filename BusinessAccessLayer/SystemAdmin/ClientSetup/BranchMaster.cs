using BusinessObjectLayer.SystemAdmin.ClientSetup;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class BranchMaster
    {
        DataAccess dataAccess = null;

        public DataSet GetBranchDetails(clsBranchMaster objBranch)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objBranch.BranchID, objBranch.BranchCode, objBranch.BranchName, objBranch.EffFrom, objBranch.EffFrom1, objBranch.EffTo, objBranch.EffTo1 };
            return dataAccess.LoadDataSet(parameters, "P_TM_GetBranchDetails", "BranchDetails");
        }

        public DataSet SaveBranchDetails(clsBranchMaster objBranch)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                objBranch.BranchID,
                objBranch.BranchCode,
                objBranch.BranchName,
                objBranch.EffFrom ,
                objBranch.EffTo  ,
                objBranch.CreatedBy
            };

            return dataAccess.LoadDataSet(parameters, "P_TM_BranchDetails_InsertUpdate", "BranchInsertUpdate");
        }
    }
}
