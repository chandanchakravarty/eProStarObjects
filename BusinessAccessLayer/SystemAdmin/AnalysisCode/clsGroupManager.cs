using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.AnalysisCode;

namespace BusinessAccessLayer.SystemAdmin.AnalysisCode
{
    public class clsGroupManager
    {
        DataAccess dataAccess = null;
        clsGroupMaster objGroup = new clsGroupMaster();

        public DataSet getGroupList(clsGroupMaster objGroup)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objGroup.GroupId,objGroup.SOBId,objGroup.SCodeId,objGroup.SSCode1Id,objGroup.SSCode2Id,objGroup.SCId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GroupMaster_Select", "GroupMasterList");
        }
        public DataSet SaveGroup(clsGroupMaster objGroup)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objGroup.GroupId,
                                                objGroup.GroupCode,
                                                objGroup.GroupName,
                                                objGroup.AnalysisCategory,
                                                objGroup.BusinessType,
                                                objGroup.SSCode1Id,
                                                objGroup.SSCode2Id,
                                               objGroup.SOBId,
                                               objGroup.SCodeId,
                                               objGroup.SCId,
                                               objGroup.EffFromDate,
                                               objGroup.EffToDate,
                                               //objSOB.Status,
                                               objGroup.LoginUserId,
                                               objGroup.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_GroupMaster_InsertUpdate", "GroupMaster");
        }
        public SqlDataReader getGroup(clsGroupMaster objGroup)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objGroup.SCId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            //return dataAccess.LoadDataSet(parameters, "P_GetSourceCodeBySOB", "MasterSourceCodeBySOB");
            return dataAccess.GetDataReader(parameters, "P_GetGroupById");
        }
        public DataSet getGroupData(clsGroupMaster objGroup)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objGroup.SCId };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GetGroupById", "GroupById");
            //return dataAccess.GetDataReader(parameters, "P_GetGroupById");
        }
    }
}
