using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.ClientSetup;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class SubsidiarySCode1Manager
    {
        DataAccess dataAccess = null;
        clsSubsidiarySCode1 objSSC1 = new clsSubsidiarySCode1();

        public DataSet getSubsidiarySourceCode1(clsSubsidiarySCode1 objSSC1)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objSSC1.SSCode1Id, objSSC1.SSCode1Name, objSSC1.SOBId, objSSC1.SCodeId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_SubsidiarySCode1_Select", "SubsidiarySourceCode1List");
        }
        public DataSet SaveSubsidiarySourceCode1(clsSubsidiarySCode1 objSSC1)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objSSC1.SSCode1Id,
                                               objSSC1.SSCode1Name,
                                               objSSC1.SOBId,
                                               objSSC1.SCodeId,
                                               objSSC1.EffFromDate,
                                               objSSC1.EffToDate,
                                               //objSOB.Status,
                                               objSSC1.LoginUserId,
                                               objSSC1.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_SubsidiarySCode1_InsertUpdate", "SubsidiarySourceCode1");
        }
        public SqlDataReader getSSC1Master(clsSubsidiarySCode1 objSSC1)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objSSC1.SCodeId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            //return dataAccess.LoadDataSet(parameters, "P_GetSourceCodeBySOB", "MasterSourceCodeBySOB");
            return dataAccess.GetDataReader(parameters, "P_GetSubsidiarySourceCode1ById");
        }
        public DataSet getSSC1(clsSubsidiarySCode1 objSSC1)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objSSC1.SCodeId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GetSubsidiarySourceCode1ById", "SubsidiarySourceCode1ById");
            //return dataAccess.GetDataReader(parameters, "P_GetSubsidiarySourceCode1ById");
        }
    }
}
