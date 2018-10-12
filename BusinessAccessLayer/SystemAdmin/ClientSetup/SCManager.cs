using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using System.Data.SqlClient;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class SCManager
    {
        DataAccess dataAccess = null;
        clsSourceCode objSC = new clsSourceCode();

        public DataSet getSourceCode(clsSourceCode objSC)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objSC.SCId, objSC.SCName, objSC.SOBId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_MasterSourceCode_Select", "MasterSourceCodeList");
        }
        public DataSet SaveSourceCode(clsSourceCode objSC)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objSC.SCId,
                                               objSC.SCName,
                                               objSC.SOBId,
                                               objSC.EffFromDate,
                                               objSC.EffToDate,
                                               //objSOB.Status,
                                               objSC.LoginUserId,
                                               objSC.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_MasterSourceCode_InsertUpdate", "MasterSourceCode");
        }
        public DataSet getSC(clsSourceCode objSC)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objSC.SOBId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GetSourceCodeBySOB", "MasterSourceCodeBySOB");
        }
        public SqlDataReader getSCMaster(clsSourceCode objSC)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objSC.SOBId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            //return dataAccess.LoadDataSet(parameters, "P_GetSourceCodeBySOB", "MasterSourceCodeBySOB");
            return dataAccess.GetDataReader(parameters, "P_GetSourceCodeBySOB");
        }
    }
}
