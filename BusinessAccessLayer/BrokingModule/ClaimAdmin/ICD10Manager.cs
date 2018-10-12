using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.ClaimAdmin ;
namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
   public class ICD10Manager
    {
       DataAccess dataAccess = null;
       clsICD10 objICD10 = new clsICD10();
       public DataSet getICD10(clsICD10 objICD10)
       {
           dataAccess = new DataAccess();
           Object[] parameters = new Object[7] { objICD10.ICD_ID, objICD10.ICD_Code, objICD10.ICD_Description, objICD10.EffFromDate, objICD10.EffFromDate1, objICD10.EffToDate, objICD10.EffToDate1 };
           return dataAccess.LoadDataSet(parameters, "P_ICD10_Select", "TM_ICD10");
       }

       public DataSet SaveICD10(clsICD10 objICD10)
       {

           dataAccess = new DataAccess();
           Object[] parameters = new Object[] {objICD10.ICD_ID,
               objICD10.ICD_Code,objICD10.ICD_Description,objICD10.EffFromDate,objICD10.EffToDate,objICD10.LoginUserId,objICD10.PageMethod   };
           return dataAccess.LoadDataSet(parameters, "P_ICD10_InsertUpdate", "ICD10Detail");
       } 
    }
}
