using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using System.Data.SqlClient;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class SOBManager
    {
        DataAccess dataAccess = null;
        clsSOB objSOB = new clsSOB();

        public DataSet getSOB(clsSOB objSOB)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objSOB.SOBId, objSOB.SOBName };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_SourceOfBusiness_Select", "SOBList");
        }
        public DataSet SaveSOB(clsSOB objSOB)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objSOB.SOBId,
                                               objSOB.SOBName,
                                               objSOB.EffFromDate,
                                               objSOB.EffToDate,
                                               //objSOB.Status,
                                               objSOB.LoginUserId,
                                               objSOB.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_SourceOfBusiness_InsertUpdate", "SourceOfBusiness");
        }
        public DataSet getSOBMaster()
        {
            dataAccess = new DataAccess();
            //Object[] parameters = new Object[2] { objSOB.SOBId, objSOB.SOBName };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet("SELECT SOBID,SOBName FROM TM_SourceOfBusiness","SourceOfBusiness");
     }
        public SqlDataReader getSOB()
        {
            dataAccess = new DataAccess();
            //Object[] parameters = new Object[2] { objSOB.SOBId, objSOB.SOBName };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            //return dataAccess.LoadDataSet("SELECT SOBID,SOBName FROM TM_SourceOfBusiness","SourceOfBusiness");
            return dataAccess.GetDataReader("SELECT SOBID,SOBName FROM TM_SourceOfBusiness");
        }
    }
}
