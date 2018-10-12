using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using System.Data.SqlClient;
using BusinessObjectLayer.SystemAdmin.ClientSetup;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class SubsidiarySCode2Manager
    {
        DataAccess dataAccess = null;
        clsSubsidiarySCode2 objSSC2 = new clsSubsidiarySCode2();

        public DataSet getSubsidiarySourceCode2(clsSubsidiarySCode2 objSSC2)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objSSC2.SSCode2Id, objSSC2.SSCode1Id, objSSC2.SSCode2Name, objSSC2.SOBId, objSSC2.SCodeId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_SubsidiarySCode2_Select", "SubsidiarySourceCode2List");
        }
        public DataSet SaveSubsidiarySourceCode2(clsSubsidiarySCode2 objSSC2)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objSSC2.SSCode2Id,
                                                objSSC2.SSCode1Id,
                                               objSSC2.SSCode2Name,
                                               objSSC2.SOBId,
                                               objSSC2.SCodeId,
                                               objSSC2.EffFromDate,
                                               objSSC2.EffToDate,
                                               //objSOB.Status,
                                               objSSC2.LoginUserId,
                                               objSSC2.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_SubsidiarySCode2_InsertUpdate", "SubsidiarySourceCode2");
        }
        public SqlDataReader getSSC2Master(clsSubsidiarySCode2 objSSC2)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objSSC2.SSCode1Id };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            //return dataAccess.LoadDataSet(parameters, "P_GetSourceCodeBySOB", "MasterSourceCodeBySOB");
            return dataAccess.GetDataReader(parameters, "P_GetSubsidiarySourceCode2ById");
        }
        public DataSet getSSC2(clsSubsidiarySCode2 objSSC2)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objSSC2.SSCode1Id };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GetSubsidiarySourceCode2ById", "SubsidiarySourceCode2ById");
            //return dataAccess.GetDataReader(parameters, "P_GetSubsidiarySourceCode2ById");
        }
    }
}
