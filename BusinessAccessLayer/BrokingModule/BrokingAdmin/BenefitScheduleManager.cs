using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;
using DataAccessLayer;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class BenefitScheduleManager
    {
        DataAccess dataAccessDS = null;
        public DataSet GetBenefitSchedule(int BenfitId,string DeptType)
        {
          dataAccessDS = new DataAccess();
          object[] parameter=new object[2]{BenfitId,DeptType};
          return dataAccessDS.LoadDataSet(parameter, "P_TM_BenefitScheduleMaster_Select", "BenefitScheduleSelect");
        
        }
        //added by kavita kaushik//
        public DataSet GetBenefitScheduleAll(clsBenefitSchedule objclsBenefitSchedule)
        {
            dataAccessDS = new DataAccess();
            object[] parameter = new object[7] {objclsBenefitSchedule.SubClassName,objclsBenefitSchedule.Benefitname ,objclsBenefitSchedule.EffFromDate,objclsBenefitSchedule.EffFromDate1 , objclsBenefitSchedule.EffToDate,objclsBenefitSchedule.EffToDate1,objclsBenefitSchedule.DeptType };
            return dataAccessDS.LoadDataSet(parameter, "P_TM_BenefitScheduleMaster_SelectAll", "BenefitScheduleSelectAll");

        }
        //end here 
       
        public DataSet SearchBenefitSchedule(clsBenefitSchedule objBenefit)
        {
            dataAccessDS = new DataAccess();
            object[] parameter = new object[6]{
                                         objBenefit.SubClassId,
                                         objBenefit.Benefittype,
                                         objBenefit.BenefitClassType,
                                         objBenefit.EffFromDate ,
                                         objBenefit.EffToDate ,
                                         objBenefit.IsIH
                                       
                                        };
            return dataAccessDS.LoadDataSet(parameter, "P_TM_BenefitScheduleMaster_SelectBySubClassId", "BenefitScheduleSelect");

        }
        public DataSet GetBenefitScheduleDetail(int BenfitScheduleId,string DeptType)
        {
            dataAccessDS = new DataAccess();
            object[] parameter = new object[2] { BenfitScheduleId,DeptType  };
            return dataAccessDS.LoadDataSet(parameter, "P_TM_BenefitScheduleDetail_Select", "BenefitScheduleDetailSelect");


        }

       // public DataSet GetBenefitScheduleDetailMotor(int BenfitScheduleId, string DeptType)
       // {
       //     dataAccessDS = new DataAccess();
       //     object[] parameter = new object[2] { BenfitScheduleId, DeptType };
       //     return dataAccessDS.LoadDataSet(parameter, "P_TM_BenefitLineMasterMotor_SelectbyBGroupLineID", "BenefitScheduleDetailSelectMotor");
       //}

       // public DataSet GetBenefitScheduleDetailForMotor(int BenfitScheduleId, string DeptType)
       // {
       //     dataAccessDS = new DataAccess();
       //     object[] parameter = new object[2] { BenfitScheduleId, DeptType };
       //     return dataAccessDS.LoadDataSet(parameter, "P_TM_BenefitLineMasterMotor_SelectbyBGroupLineID", "BenefitScheduleDetailSelectMotor");


       // }
        public DataSet DeleteBenefitLine(int benefitlineid, int benefitscheduleid)
        {
            object[] parameters = new object[2] { benefitscheduleid, benefitlineid };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BenefitScheduleDetail_Delete", "BenefitLineDelete");

        }
        public DataSet SaveBenefitSchedule(clsBenefitSchedule objBenefit)
        {
            dataAccessDS = new DataAccess();
            object[] parameter = new object[10]{objBenefit.BenefitId,
                                         objBenefit.Benefitname,
                                         objBenefit.Benefittype,
                                         objBenefit.BenefitClassType,
                                         objBenefit.SubClassId,
                                         objBenefit.EffFromDate ,
                                         objBenefit.EffToDate ,
                                         objBenefit.User,
                                         objBenefit.IsActive,
                                           objBenefit.DeptType 
                                        };
            return dataAccessDS.LoadDataSet(parameter, "P_TM_BenefitScheduleMaster_InsertUpdate", "BenefitSchedule");

        }
        public DataSet SaveBenefitScheduleDetail(clsBenefitScheduleDetial objBenefitDetail)
        {
            dataAccessDS = new DataAccess();
            object[] parameter = new object[6]{  objBenefitDetail.BenefitScheduleId,
                                                 objBenefitDetail.BenefitGroupLineId,
                                                 objBenefitDetail.User,
                                                 objBenefitDetail.IsActive,
                                                 objBenefitDetail.IsSelected,
                                                 objBenefitDetail.OrderNo
                                        };
            return dataAccessDS.LoadDataSet(parameter, "P_TM_BenefitScheduleDetail_InsertUpdate", "BenefitScheduleDetail");

        }

        public DataSet GetBenefitScheduleSummary(int BenfitScheduleId, string DeptType)
        {
            dataAccessDS = new DataAccess();
            object[] parameter = new object[2] { BenfitScheduleId, DeptType };
            return dataAccessDS.LoadDataSet(parameter, "P_TM_BenefitSummaryDetail_Select", "BenefitScheduleDetailSelect");


        }
    }
}
