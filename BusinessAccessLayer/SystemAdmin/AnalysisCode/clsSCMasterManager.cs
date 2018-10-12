using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using BusinessObjectLayer.SystemAdmin.AnalysisCode;

namespace BusinessAccessLayer.SystemAdmin.AnalysisCode
{
    public class clsSCMasterManager
    {
        DataAccess dataAccess = null;
        clsSourceCodeMaster objSC = new clsSourceCodeMaster();

        public DataSet getSourceCodeList(clsSourceCodeMaster objSC)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[9] { objSC.SCId,objSC.AnalysisCategory,objSC.BusinessType,objSC.SOBId,objSC.SCodeId,objSC.SSCode1Id,objSC.SSCode2Id,objSC.SCode,objSC.SCDesc};
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_SourceCodeMaster_Select", "SourceCodeMasterList");
        }
        public DataSet SaveSourceCode(clsSourceCodeMaster objSC)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objSC.SCId,
                                                objSC.AnalysisCategory,
                                                objSC.BusinessType,
                                               objSC.SCode,
                                               objSC.SCDesc,
                                               objSC.SSCode2Id,
                                               objSC.SSCode1Id,
                                               objSC.SOBId,
                                               objSC.SCodeId,
                                               objSC.IsGroupMandatory,
                                               objSC.IsSubGroupMandatory,
                                               objSC.LinkWithFlex,
                                               objSC.EffFromDate,
                                               objSC.EffToDate,
                                               //objSOB.Status,
                                               objSC.LoginUserId,
                                               objSC.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_SourceCodeMaster_InsertUpdate", "SourceCodeMaster");
        }
        public SqlDataReader getSC(clsSourceCodeMaster objSC)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objSC.SSCode2Id,objSC.IsGroupMandatory,objSC.IsSubGroupMandatory };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            //return dataAccess.LoadDataSet(parameters, "P_GetSourceCodeBySOB", "MasterSourceCodeBySOB");
            return dataAccess.GetDataReader(parameters, "P_GetSourceCodeMasterById");
        }
        public DataSet getSCMaster(clsSourceCodeMaster objSC)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objSC.SSCode2Id, objSC.IsGroupMandatory, objSC.IsSubGroupMandatory };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            //return dataAccess.LoadDataSet(parameters, "P_GetSourceCodeBySOB", "MasterSourceCodeBySOB");
            return dataAccess.LoadDataSet(parameters, "P_GetSourceCodeMasterById", "SourceCodeMasterById");
            //return dataAccess.GetDataReader(parameters, "P_GetSourceCodeMasterById");
        }
    }
}
