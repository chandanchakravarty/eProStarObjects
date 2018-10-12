using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
   public class IHSchedulelimitManager
    {

        DataAccess dataAccessDS = null;
        public DataSet LoadIHScheduleLimit(clsIHBenefitScheduleLimit objIHScheduleLimit)
        {
            object[] parameters = new object[] { objIHScheduleLimit.IHScheduleLimitID };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_IHScheduleLimitMaster_Select", "IHScheduleSelect");
        }

        public DataSet LoadIHScheduleLimitAll(clsIHBenefitScheduleLimit objIHScheduleLimit)
        {
            object[] parameters = new object[] { objIHScheduleLimit.IHBenefitScheduleName, objIHScheduleLimit.IHBenefitScheduleID,
                objIHScheduleLimit.IHBenefitScheduleLimitName, objIHScheduleLimit.EffFromDate, objIHScheduleLimit.EffFromDate2, 
                objIHScheduleLimit.EffToDate, objIHScheduleLimit.EffToDate2 };
            dataAccessDS = new DataAccess();

            return dataAccessDS.LoadDataSet(parameters, "P_TM_IHScheduleLimitMaster_SelectAll", "IHScheduleLimitSelectAll");
        }

        public DataSet SaveBenefitLine(clsIHBenefitScheduleLimit objIHScheduleLimit)
        {
            object[] parameters = new object[] { objIHScheduleLimit.IHBenefitScheduleID, 
                           };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "insert procedure name", "IHSchedule");

        }
        public DataSet BindIHScheduleLimitMaster()
        {
            object[] parameters = new object[] { };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_IH_BenefitSchdule", "P_IH_BenefitSchdule");
        }

        public DataSet GetIHBenefitSchdule(int id)
        {
            object[] parameters = new object[] { id };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_IH_GetBenefitLine", "P_IH_GetBenefitLine");
        }

        public DataSet GetIHBenefitPlanForSchduleId(int LimitId,int schduleBenefitID)
        {
            object[] parameters = new object[] { LimitId, schduleBenefitID };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_IH_GetPlan", "P_IH_GetPlan");
        }
        public DataSet GetDataForPlanOnBenefit(clsIHBenefitScheduleLimit objIHScheduleLimit)
        {
            object[] parameters = new object[] { objIHScheduleLimit.IHScheduleGroupID, 
                objIHScheduleLimit.IHScheduleLineID,objIHScheduleLimit.IHPlanID };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_IH_GetPlanDetail", "P_IH_GetPlanDetail");
        }
        public DataSet InsertPlanName(clsIHBenefitScheduleLimit objIHScheduleLimit)
        {
            object[] parameters = new object[] { objIHScheduleLimit.IHScheduleLimitID, 
                objIHScheduleLimit.IHPlanName,objIHScheduleLimit.CreatedBy };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_IH_BenefitPlanName_InsertUpdate", "P_IH_BenefitPlanName_InsertUpdate");
        }
        public DataSet InsertPlanDetails(clsIHBenefitScheduleLimit objIHScheduleLimit)
        {
            object[] parameters = new object[] { objIHScheduleLimit.IHScheduleGroupID, 
                objIHScheduleLimit.IHScheduleLineID,objIHScheduleLimit.IHPlanID,
                objIHScheduleLimit.IHPlanName,objIHScheduleLimit.CreatedBy};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_IH_BenefitPlan_InsertUpdate", "P_IH_BenefitPlan_InsertUpdate");
        }
        public DataSet InsertUpdateMasterDetails(clsIHBenefitScheduleLimit objIHScheduleLimit)
        {
            object[] parameters = new object[] { objIHScheduleLimit.IHScheduleLimitID,objIHScheduleLimit.IHBenefitScheduleID, 
                objIHScheduleLimit.IHBenefitScheduleLimitName , objIHScheduleLimit.EffFromDate,objIHScheduleLimit.EffToDate,objIHScheduleLimit.CreatedBy};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_IH_BenefitSchduleMaster_InsertUpdate", "P_IH_BenefitSchduleMaster_InsertUpdate");
        }
        //public DataSet GetIHBenefitPlanForSchduleId(int SchduleId, int LimitId)
        //{
        //    object[] parameters = new object[] { SchduleId, LimitId };
        //    dataAccessDS = new DataAccess();
        //    return dataAccessDS.LoadDataSet(parameters, "SP", "P_IH_GetBenefitLine");
        //}
    }
}
