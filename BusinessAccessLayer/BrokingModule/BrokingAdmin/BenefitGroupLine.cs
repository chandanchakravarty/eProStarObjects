using System;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class BenefitGroupLine
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadBenefitGroupLine(clsBenefitGroupLineMaster objBenefitGroupLineMaster)
        {
            object[] parameters = new object[2] { objBenefitGroupLineMaster.BenefitGroupLineID,objBenefitGroupLineMaster.DeptType  };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BenefitGroupLineMaster_Select", "BenefitGroupLineSelect");
        }

        public DataSet LoadBenefitGroupLineWithExpireRecord(clsBenefitGroupLineMaster objBenefitGroupLineMaster)
        {
            object[] parameters = new object[2] { objBenefitGroupLineMaster.BenefitGroupLineID, objBenefitGroupLineMaster.DeptType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BenefitGroupLineMaster_SelectWithExpireRecord", "BenefitGroupLineSelectWithExpire");
        }

        public DataSet LoadBenefitGroupLineAll(clsBenefitGroupLineMaster objBenefitGroupLineMaster)
        {
            object[] parameters = new object[6] { objBenefitGroupLineMaster.BenefitGroupLineName,objBenefitGroupLineMaster.EffFromDate,objBenefitGroupLineMaster.EffFromDate1,objBenefitGroupLineMaster.EffToDate,objBenefitGroupLineMaster.EffToDate1,objBenefitGroupLineMaster.DeptType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BenefitGroupLineMaster_SelectAll", "BenefitGroupLineSelectAll");
        }


        public DataSet SaveBenefitGroupLine(clsBenefitGroupLineMaster objBenefitGroupLineMaster)
        {
            object[] parameters = new object[] { 
                                                  objBenefitGroupLineMaster.BenefitScheduleID,
                                                  objBenefitGroupLineMaster.BenefitGroupLineID,
                                                  objBenefitGroupLineMaster.BenefitGroupLineName,
                                                  objBenefitGroupLineMaster.EffFromDate,
                                                  objBenefitGroupLineMaster.EffToDate,
                                                  objBenefitGroupLineMaster.Status,
                                                  objBenefitGroupLineMaster.LoginUserId,
                                                  objBenefitGroupLineMaster.PageMethod,
                                                  objBenefitGroupLineMaster.DeptType 
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BenefitGroupLineMaster_InsertUpdate", "BenefitGroupLine");

        }

        public DataSet GetBenefitLine(int BenfitGroupLineId,string DeptType)
        {
            dataAccessDS = new DataAccess();
            object[] parameter = new object[2] { BenfitGroupLineId,DeptType };
            return dataAccessDS.LoadDataSet(parameter, "P_TM_BenefitLineMaster_SelectbyBGroupLineID", "P_TM_BenefitLineMaster");


        }
        public DataSet GetBenefitLineMotor( int scheduleid, string deptype)
        {
            dataAccessDS = new DataAccess();
            object[] parameter = new object[2] {scheduleid, deptype };
            return dataAccessDS.LoadDataSet(parameter , "P_TM_BenefitLineMasterMotor_SelectbyBGroupLineID", "P_TM_BenefitLineMaster");
        }


        public DataSet SaveBenefitLine(clsBenefitLineMaster objclsBenefitLineMaster)
        {
           
            dataAccessDS = new DataAccess();
            object[] parameter = new object[]{  objclsBenefitLineMaster.BenefitGroupLineID,
                                                 objclsBenefitLineMaster.BenefitLineID,
                                                 objclsBenefitLineMaster.OrderNo,
                                                 objclsBenefitLineMaster.IsSelected
                                        };
            return dataAccessDS.LoadDataSet(parameter, "P_TM_BenefitGroupLineMapping_InsertUpdate", "TM_BenefitGroupLineMapping");
        }


        // Changes done for Redmine #17690
        public DataSet GetSubBenefitLine(int BenfitLineId, string DeptType)
        {
            dataAccessDS = new DataAccess();
            object[] parameter = new object[2] { BenfitLineId, DeptType };
            return dataAccessDS.LoadDataSet(parameter, "P_TM_SubBenefitLineMaster_SelectbyBenefitLineID", "P_TM_SubBenefitLineMaster");
        }

        public DataSet LoadSubBenefitGroupLine(clsBenefitLineMaster objBenefitLineMaster)
        {
            object[] parameters = new object[2] { objBenefitLineMaster.BenefitLineID, objBenefitLineMaster.DeptType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BenefitLineMaster_Select", "BenefitLineSelect");
        }

    }
}
