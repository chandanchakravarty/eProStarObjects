using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.AnalysisCode;

namespace BusinessAccessLayer.SystemAdmin.AnalysisCode
{
    public class SA_ClassManager
    {
        DataAccess dataAccess = null;
        SA_Class objClass = new SA_Class();
        public DataSet getClass(SA_Class objClass)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { objClass.ClassId };
            return dataAccess.LoadDataSet(parametes, "P_TM_ClassMaster_SelectforMaster", "ClassSelect");
        }
        public DataSet getClassAll(SA_Class objClass)
        {

            dataAccess = new DataAccess();
            //objClass.ClassId,
            Object[] parametes = new Object[] { objClass.ClassId,objClass.ClassCode, objClass.ClassName, objClass.EffFromDate, objClass.EffFromDate2, objClass.EffToDate, objClass.EffToDate2 };
            return dataAccess.LoadDataSet(parametes, "P_TM_ClassMaster_SelectAll", "ClassSelect");
        }

        public DataSet getCoverageToInclude()
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {  };
            return dataAccess.LoadDataSet(parametes, "getCoverageValue_LookUp", "ClassCoverage");
        }

        public DataSet SaveClassMaster(SA_Class objClass)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {
                                                objClass.ClassId,
                                                objClass.ClassCode,
                                                objClass.ClassName,
                                                objClass.BusinessType,
                                                objClass.EffFromDate,
                                                objClass.EffToDate,
                                                objClass.UserName,
                                                objClass.Status,
                                                objClass.PageMethod,
                                                objClass.CoverageToInclude,
                                                objClass.PrmWarranty,
                                                objClass.GST,
                                                objClass.ClassType,
                                                objClass.IsPackagePolicy
                                            };
            return dataAccess.LoadDataSet(parametes, "P_TM_ClassMaster_InsertUpdate", "Class");
        }
        public DataSet LoadCompanyDeptt(int intcompID)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { intcompID };
            return dataAccess.LoadDataSet(parameters, "P_Adm_CompanyORDeptt", "ClassId");
        }
        public DataSet ChangeStatus(SA_Class objClass)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {objClass.ClassId,
                                                objClass.CStatus,
                                                objClass.UserName
                                                };
                                               
            return dataAccess.LoadDataSet(parametes, "P_TM_ClassMaster_ChangeStatus", "ClassStatus");
        }
        public DataSet getSubClassForPackagePolicy(int ClassId)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { ClassId };
            return dataAccess.LoadDataSet(parametes, "P_PackagePolicySubClass_Select", "PackagePolicySelect");
        }
        public DataSet DeleteSubClassForPackagePolicy(SA_Class objClass)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] {   
                                                    objClass.ClassId,
                                                    objClass.SubClassId
                                                };
            return dataAccess.LoadDataSet(parameters, "P_PackagePolicySubClass_Delete", "P_PackagePolicySubClass_Delete");
        }
        public DataSet getSelectedSubClass(int ClassId, string SubClassIds)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { ClassId, SubClassIds };
            return dataAccess.LoadDataSet(parametes, "P_Adm_SubClassMaster", "SubClassMaster");
        }
        public DataSet SavePackagePolicySubClass(string xmlSubClassFile)
        {
            DataSet dsResult = new DataSet();
            object[] parameters = new object[] { xmlSubClassFile };
            dataAccess = new DataAccess();
            dsResult = dataAccess.LoadDataSet(parameters, "P_TM_PackagePolicy_InsertUpdate", "PackagePolicyDetail");
            return dsResult;
        }
        public DataSet getPPWDays(int subClassid)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { subClassid };
            return dataAccess.LoadDataSet(parametes, "getPPWDaysByID", "TM_SubClassMaster");
        }
    }
}
