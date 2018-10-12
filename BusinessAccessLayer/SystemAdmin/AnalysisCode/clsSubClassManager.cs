using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.AnalysisCode;

namespace BusinessAccessLayer.SystemAdmin.AnalysisCode
{
    public class clsSubClassManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadSubClass(clsSubClass objSubClass)
        {
            object[] parameters = new object[1] { objSubClass.SubClassId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SubClassMaster_Select", "SubClassSelect");

        }
        public DataSet LoadSubClassAll(clsSubClass objSubClass)
        {
            object[] parameters = new object[] { objSubClass.SubClassId, objSubClass.SubClassCode, objSubClass.SubClassName, objSubClass.ClassID,objSubClass.EffFromDate,objSubClass.EffFromDate2,objSubClass.EffToDate,objSubClass.EffToDate2,objSubClass.SubClassType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SubClassMaster_SelectAll", "SubClassSelect");

        }
        public DataSet IsExistDefaultSubClass(clsSubClass objSubClass) 
        {
            object[] parameters = new object[1] { objSubClass.SubClassId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TemplateDefaultData_Exist", "TemplateDefault");

        }
        public DataSet LoadCompanySubClassId(int classid,int subclassid)
        {
            object[] parameters = new object[2] {classid,subclassid };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_LedgerSubClass_SelectBySubClass", "SubClassCompanySelect");

        }
        public DataSet SaveSubClassMaster(clsSubClass objSubClass)
        {
            object[] parameters = new object[] { objSubClass.SubClassId,
                                                 objSubClass.AnalysisCategory,
                                                 objSubClass.BalBF_NRP,
                                                 objSubClass.ClassID,
                                                 
                                                 objSubClass.SubClassCode,
                                                 objSubClass.SubClassName,
                                                 objSubClass.EffFromDate,
                                                 objSubClass.EffToDate,
                                                 objSubClass.Status,
                                                 objSubClass.LoginUserId,
                                                 objSubClass.PageMethod,
                                                 objSubClass.PremWarrnty, 
                                                 objSubClass.GST,
                                                 objSubClass.GSTType,
                                                 objSubClass.RenewalType,
                                                 objSubClass.BNClass,
                                                 objSubClass.CashBeforeCover,
                                                 objSubClass.Currency,
                                                 objSubClass.EffFromDate2,
                                                 objSubClass.EffToDate2,
                                                 objSubClass.underwritername,
                                                 objSubClass.IsPremium,
                                                 objSubClass.premium,
                                                 objSubClass.minPremiumId,
                                                 objSubClass.SubClassType,
                                                 objSubClass.PPWDaysCredit
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SubClassMaster_InsertUpdate", "SubClassDetail");

        }
        public DataSet ChangeStatus(clsSubClass objSubClass)
        {
            object[] parameters = new object[] { objSubClass.SubClassId,
                                                 objSubClass.CStatus,
                                                 objSubClass.LoginUserId,
                                                 
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SubClassMaster_ChangeStatus", "SubClassStatus");
        }
        public DataSet GetGSTType(string Type)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = new object[1] { Type };
            return dataAccessDS.LoadDataSet(parameters, "P_Get_GSTType", "P_Get_GSTType");
        }
        public DataSet GetMainClassDetails(int ClassID)
        {
            DataAccess dataAccessDS = new DataAccess();
            object[] parameters = new object[1] { ClassID };
            return dataAccessDS.LoadDataSet(parameters, "P_Get_MainClass_Details", "P_Get_MainClass_Details");
        }
        public DataSet GetRenewalType(string sCategory)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = new object[1] { sCategory };
            return dataAccessDS.LoadDataSet(parameters, "P_Get_RenewalType", "P_Get_RenewalType");
        }
    }

    public static class clsManageClass
    {
        static DataAccess dataAccess = new DataAccess();
        public static DataSet GetMainClassDetails(int ClassID)
        {
            object[] parameters = new object[1] { ClassID };
            return dataAccess.LoadDataSet(parameters, "P_Get_MainClass_Details", "P_Get_MainClass_Details");
        }
    }
}
