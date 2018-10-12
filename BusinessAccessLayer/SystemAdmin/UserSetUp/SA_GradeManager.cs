using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.UserSetUp;
using BusinessObjectLayer.SystemAdmin.UserSetup;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    
    public class SA_GradeManager
    {
        DataAccess dataAccess = null;
        SA_Grade objGrade = new SA_Grade();

        public DataSet getGrade(SA_Grade objGrade)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { objGrade.GradeId };
            return dataAccess.LoadDataSet(parametes, "P_SysAdm_USetup_GradeSelect", "GradeSelect");
        }
        public DataSet getGradeAll(SA_Grade objGrade)
        {

            dataAccess = new DataAccess();
            // objGrade.GradeId,objGrade.GradeId,
            Object[] parametes = new Object[6] { objGrade.GradeId,objGrade.GradeName, objGrade.EffFromDate, objGrade.EffFromDate1, objGrade.EffToDate, objGrade.EffToDate1 };
            return dataAccess.LoadDataSet(parametes, "P_SysAdm_USetup_GradeSelectAll", "GradeSelectAll");
        }
        public DataSet SaveGrade(SA_Grade objGrade)
        { 
            
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {objGrade.GradeId,
                                               objGrade.GradeName,
                                               objGrade.EffFromDate,
                                               objGrade.EffToDate,
                                               objGrade.UserName,
                                               objGrade.Status,
                                               objGrade.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parametes, "P_SysAdm_USetup_Grade_InsertUpdate", "Grade");
        }
        public DataSet LoadGradeLimits(int GradeId, int LimitId)
        {
            object[] parameters = new object[2] { GradeId, LimitId };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(parameters, "P_TM_GradeLimit_Select", "GradeLimitSelect");

        }
        public DataSet SaveGradeLimit(clsGradeLimit objGradeLimit)
        {
            object[] parameters = new object[] {
                                                 objGradeLimit.GradeLimitId,
                                                 objGradeLimit.GradeId,
                                                 objGradeLimit.ClassId,
                                                 objGradeLimit.Type,
                                                 objGradeLimit.PremiumCurrency,
                                                 objGradeLimit.PremiumAmt,
                                                 objGradeLimit.SumInsuredCurrency,
                                                 objGradeLimit.SumInsuredAmt,
                                                 objGradeLimit.PageMethod 
                                               };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(parameters, "P_TM_GradeLimit_InsertUpdate", "GradeLimitDetail");

        }
        public DataSet DeleteGradeLimit(int GradeLimitId)
        {
            object[] param = new object[] { GradeLimitId };
            dataAccess = new DataAccess();
            return dataAccess.LoadDataSet(param, "P_TM_GradeLimit_Delete", "GradeLimitDelete");
        }
    }
}

  