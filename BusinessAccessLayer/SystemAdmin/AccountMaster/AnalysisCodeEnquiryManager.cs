using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessAccessLayer.SystemAdmin.AccountMaster
{
    public class AnalysisCodeEnquiryManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadAnalysisCode(int strCategory)
        {
            object[] parameters = new object[1] {strCategory };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_AnalysisCodeEnquiry_SelectCode", "AnalysisSelect");


        }
        public DataSet LoadAnalysisEnquiry(int  strCategory,string code)
        {
            object[] parameters = new object[2] { strCategory,code };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_AnalysisCodeEnquiry_Select", "AnalysisEnquiry");


        }

        public DataSet LoadAnalysisEnquiryWithReport(int strCategory, string code, string fromdate, string todate)
        {
            object[] parameters = new object[4] { strCategory, code,fromdate,todate  };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_AnalysisCodeEnquiry_Select_Report", "AnalysisEnquiryReport");


        }
    }
}
