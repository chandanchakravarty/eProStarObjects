using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.AnalysisCode;

namespace BusinessAccessLayer.SystemAdmin.AnalysisCode
{
    public class clsSubGroupManager
    {

        DataAccess dataAccess = null;
        clsSubGroupMaster objSubGroup = new clsSubGroupMaster();

        public DataSet GetAll(clsSubGroupMaster objSubGroup)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[7] { objSubGroup.SubGroupId,objSubGroup.SOBId,objSubGroup.SCodeId,objSubGroup.SSCode1Id,objSubGroup.SSCode2Id,objSubGroup.SCId,objSubGroup.GroupId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_SubGroupMaster_Select", "SubGroupMasterList");
        }
        public DataSet SaveSubGroup(clsSubGroupMaster objSubGroup)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objSubGroup.SubGroupId,
                                                objSubGroup.SubGroupCode,
                                                objSubGroup.SubGroupName,
                                                objSubGroup.AnalysisCategory,
                                                objSubGroup.BusinessType,
                                                objSubGroup.SSCode1Id,
                                                objSubGroup.SSCode2Id,
                                               objSubGroup.SOBId,
                                               objSubGroup.SCodeId,
                                               objSubGroup.SCId,
                                               objSubGroup.GroupId,
                                               objSubGroup.EffFromDate,
                                               objSubGroup.EffToDate,
                                               //objSOB.Status,
                                               objSubGroup.LoginUserId,
                                               objSubGroup.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_SubGroupMaster_InsertUpdate", "SubGroupMaster");
        }
        public SqlDataReader getSubGroup(clsSubGroupMaster objSubGroup)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objSubGroup.GroupId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            //return dataAccess.LoadDataSet(parameters, "P_GetSourceCodeBySOB", "MasterSourceCodeBySOB");
            return dataAccess.GetDataReader(parameters, "P_GetSubGroupById");
        }
        public DataSet getSubGroupData(clsSubGroupMaster objSubGroup)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objSubGroup.GroupId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GetSubGroupById", "SubGroupById");
            //return dataAccess.GetDataReader(parameters, "P_GetSubGroupById");
        }
    }
}
