using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BusinessObjectLayer.SystemAdmin.UserSetUp;
using DataAccessLayer;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class clsBranchListManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadBranchListByCompanyId(int CompanyId)
        {
            object[] parameters = new object[1] { CompanyId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserGrpCompBranch_Select", "BranchListSelect");
        }
        public DataSet LoadCompaniesByGroupCode(string GroupCode)
        {
            object[] parameters = new object[1] { GroupCode };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserGrpCompanyList_Select", "CompanyList");
        }
        public DataSet LoadSavedBranchList(string grpcode ,int CompanyId)
        {
            object[] parameters = new object[2] { grpcode,CompanyId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserGrpBranch_Select", "SelectBranch");
        }

        public DataSet SaveBranchListMaster(clsBranchList objBranchList)
        {
            object[] parameters = new object[7] { objBranchList.GrpCompBranchId,
                                                 objBranchList.isSelected,
                                                 objBranchList.GrpAccessCd,
                                                 objBranchList.CompanyId,
                                                 objBranchList.BranchID,
                                                 objBranchList.User,
                                                 objBranchList.IsActive                                                 
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserGrpCompBranch_InsertUpdate", "BranchListDetail");
        }
        public DataSet UpdateGroupComplete(string groupcode)
        {
            object[] parameters = new object[] { groupcode };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserGrpAccessMaster_Complete", "CompletedGroup");
        
        }
    }
}

