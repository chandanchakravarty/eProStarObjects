using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.RIBrokingModule.BrokingAdmin
{
    
    public class RI_DepartmentManager
    {
        DataAccess dataAccess = null;
        RI_Department objDep = new RI_Department();
        public DataSet getDepartment(RI_Department objDep)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { objDep.DeptCode, objDep.Status };
            return dataAccess.LoadDataSet(parametes, "P_Adm_DepartmentList", "DepartmentList");
        }
        public DataSet SaveDepartment(RI_Department objDep)
        { 
            
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {objDep.DeptCode,
                                               objDep.DeptName,
                                               objDep.DeptNameCh,
                                               objDep.EffFromDate,
                                               objDep.EffToDate,
                                               objDep.Status,
                                               objDep.LoginUserId,
                                               objDep.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parametes, "P_Adm_Dept_InsertUpdate", "Department");
        }
    }
}
