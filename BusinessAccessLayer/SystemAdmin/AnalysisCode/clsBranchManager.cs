using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using System.Data.SqlClient;
using BusinessObjectLayer.SystemAdmin.AnalysisCode;

namespace BusinessAccessLayer.SystemAdmin.AnalysisCode
{
    public class clsBranchManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadBranch(clsBranch objBranch)
        {
            object[] parameters = new object[1] { objBranch.BranchId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BranchMaster_Select", "BranchSelect");

        }
        public DataSet SaveBranchMaster(clsBranch objBranch)
        {
            object[] parameters = new object[] { objBranch.BranchId,
                                                 objBranch.AnalysisCategory,
                                                 objBranch.BalBF_NRP,
                                                 objBranch.CompanyId,
                                                 objBranch.BranchCode,
                                                 objBranch.BranchName,
                                                 objBranch.EffFromDate,
                                                 objBranch.EffToDate,
                                                 objBranch.Status,
                                                 objBranch.LoginUserId,
                                                 objBranch.PageMethod,
                                                 objBranch.Address1,
                                                 objBranch.Address2,
                                                 objBranch.Address3,
                                                 objBranch.FaxNoPrefx,
                                                 objBranch.FaxNo,
                                                 objBranch.TelephoneNoPrefx,
                                                 objBranch.TelephoneNo,
                                                 objBranch.Email,
                                                 objBranch.CountryCode,
                                                 objBranch.IncludeHeadOffice
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BranchMaster_InsertUpdate", "BranchDetail");

        }
        public SqlDataReader getBranch(clsBranch objBranch)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[1] { objBranch.CompanyId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            //return dataAccess.LoadDataSet(parameters, "P_GetSourceCodeBySOB", "MasterSourceCodeBySOB");
            return dataAccessDS.GetDataReader(parameters, "P_GetBranchById");
        }
        public SqlDataReader getUserBranch(clsBranch objBranch)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[2] { objBranch.CompanyId,objBranch.LoginUserId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            //return dataAccess.LoadDataSet(parameters, "P_GetSourceCodeBySOB", "MasterSourceCodeBySOB");
            return dataAccessDS.GetDataReader(parameters, "P_GetBranchByUserId");
        }
    }
}
