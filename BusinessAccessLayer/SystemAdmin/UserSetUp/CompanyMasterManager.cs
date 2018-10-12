using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.UserSetup;

namespace BusinessAccessLayer.SystemAdmin.UserSetup
{

    public class CompanyMasterManager
    {

        DataAccess dataAccessDS = null;
        public DataSet LoadCompany(clsCompanyMaster objcomp)
        {
            object[] parameters = new object[1] { objcomp.CompanyId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_CompanyMaster_Select", "CompanySelect");

        }
        public DataSet SaveCompany(clsCompanyMaster objcomp)
        {
            object[] parameters = new object[] { objcomp.CompanyId,
                                                 objcomp.CompanyCode,
                                                 objcomp.CompanyName,
                                                 objcomp.Address1,
                                                 objcomp.Address2,
                                                 objcomp.Address3,
                                                 objcomp.FaxNoPrefx,
                                                 objcomp.FaxNo,
                                                 objcomp.TelephoneNoPrefx,
                                                 objcomp.TelephoneNo,
                                                 objcomp.Email,
                                                 objcomp.Website,
                                                 objcomp.CountryCode,
                                                 objcomp.Remarks,
                                                 objcomp.EffectivefromDate,
                                                 objcomp.Effectivetodate,
                                                 objcomp.User,
                                                 objcomp.IsActive,
                                                 objcomp.ThirdLevelAprvReq,
                                                 objcomp.FinancialYearDay,
                                                 objcomp.FinancialYearMonth,
                                                 objcomp.Currency,
                                                 objcomp.Attach_Location,
                                                 objcomp.Attach_DisplayFileName,
                                                 objcomp.Attach_InternalFileName,
                                                 objcomp.ProvinceCode,
                                                 objcomp.CityCode ,
                                                 objcomp.DepartmentIds
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_CompanyMaster_InsertUpdate", "CompanyDetail");

        }

        public DataSet LoadCompanyAll(clsCompanyMaster objcomp)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[6] { objcomp.CompanyCode ,objcomp.CompanyName,  objcomp.EffectivefromDate ,objcomp.EffectivefromDate1 ,objcomp.Effectivetodate , objcomp.Effectivetodate1 };
            return dataAccessDS.LoadDataSet(parameters, "P_Adm_CompanyListAll", "CompanyList");
        }

        public DataSet LoadCompanyDeptList(int intcompID)
        {
            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[1] { intcompID };
            return dataAccessDS.LoadDataSet(parameters, "P_Adm_CompanyDeptList", "CompanyList");
        }
    }
}
