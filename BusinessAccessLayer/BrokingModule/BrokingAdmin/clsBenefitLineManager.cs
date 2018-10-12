using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class clsBenefitLineManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadBenefitLine(clsBenefitLineMaster objBenefitLine)
        {
            object[] parameters = new object[2] { objBenefitLine.BenefitLineID,objBenefitLine.DeptType  };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BenefitLineMaster_Select", "BenefitLineSelect");
       }

        public DataSet LoadSubBenefitLine(clsBenefitLineMaster objBenefitLine)
        {
            object[] parameters = new object[1] { objBenefitLine.BenefitLineID };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_Sub_BenefitLineMaster_Select", "SubBenefitLineSelect");
        }

        public DataSet LoadBenefitLineAll(clsBenefitLineMaster objBenefitLine)
        {
            object[] parameters = new object[6] { objBenefitLine.BenefitLineName,objBenefitLine.EffFromDate,objBenefitLine.EffFromDate1,objBenefitLine.EffToDate,objBenefitLine.EffToDate1,objBenefitLine.DeptType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BenefitLineMaster_SelectAll", "BenefitLineSelectAll");
        }
        
        public DataSet SaveBenefitLine(clsBenefitLineMaster objBenefitLine)
        {
            object[] parameters = new object[11] { 
                                                  objBenefitLine.BenefitGroupLineID,
                                                  objBenefitLine.BenefitLineID,
                                                  objBenefitLine.BenefitLineName,
                                                  objBenefitLine.EffFromDate,
                                                  objBenefitLine.EffToDate,
                                                  objBenefitLine.Status,
                                                  objBenefitLine.LoginUserId,
                                                  objBenefitLine.PageMethod,
                                                  objBenefitLine.DeptType
                                                  ,objBenefitLine.SubBenefitLineID
                                                  ,objBenefitLine.SubBenefitOrderID
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BenefitLineMaster_InsertUpdate", "BenefitLine");

        }
        public DataSet ValidateBenefitLine(clsBenefitLineMaster objBenefitLine)
        {
            object[] parameters = new object[] { 
                                                  objBenefitLine.BenefitLineName,
                                                  objBenefitLine.BenefitGroupLineID
                                                  
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BenefitLineMaster_GroupSelect", "BenefitLine");

        }

        //Added By Apurva For Redmine #17690
        public DataSet SaveSubBenefitLine(clsSubBenefitLineMaster objBenefitLine)
        {
            object[] parameters = new object[6] { 
                                                  objBenefitLine.SubBenefitLineID,
                                                  objBenefitLine.SubBenefitLineName,
                                                  objBenefitLine.EffFromDate,
                                                  objBenefitLine.EffToDate,
                                                  objBenefitLine.LoginUserId,
                                                  objBenefitLine.Status
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SubBenefitLineMaster_InsertUpdate", "SubBenefitLine");
        }

        //Added By Apurva For Redmine #17690
        public DataSet LoadSubBenefitLineAll(clsSubBenefitLineMaster objBenefitLine)
        {
            object[] parameters = new object[6] { 
                                                 objBenefitLine.SubBenefitLineID,   
                                                  objBenefitLine.SubBenefitLineName, 
                                                  objBenefitLine.EffFromDate, 
                                                  objBenefitLine.EffFromDate1, 
                                                  objBenefitLine.EffToDate, 
                                                  objBenefitLine.EffToDate1 
                                                 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SubBenefitLineMaster_Select", "SubBenefitLineSelect");
        }

        public DataSet SaveSubBenefitLineTest(clsSubBenefitLineMaster objBenefitLine)
        {
            object[] parameters = new object[9] { 
                                                  objBenefitLine.BenefitLineID,
                                                   objBenefitLine.SubBenefitLineID,
                                                  objBenefitLine.SubBenefitLineName,
                                                  objBenefitLine.EffFromDate,
                                                  objBenefitLine.EffToDate,
                                                   objBenefitLine.LoginUserId,
                                                  objBenefitLine.Status,
                                                  objBenefitLine.PageMethod,
                                                  objBenefitLine.DeptType
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SubBenefitLineMaster_InsertUpdate_N", "SubBenefitLine");
        }
    }
}
