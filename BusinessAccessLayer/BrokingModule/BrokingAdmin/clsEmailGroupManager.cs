using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class clsEmailGroupManager
    {
        DataAccess dataAccess = null;
        clsEmailGroupMaster objEmailMaster = new clsEmailGroupMaster();

        public DataSet getEmailGroup(clsEmailGroupMaster objEmailMaster)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { objEmailMaster.EmailGroupId };
            return dataAccess.LoadDataSet(parametes, "P_SysAdm_USetup_GradeSelect", "EmailSelect");
        }

        public DataSet SaveEmailGroup(clsEmailGroupMaster objEmailMaster)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {objEmailMaster.EmailGroupId,
                                               objEmailMaster.GroupName,
                                               objEmailMaster.GroupDesc,
                                               objEmailMaster.DefEmailGroup,
                                               objEmailMaster.EffFromDate,
                                               objEmailMaster.EffToDate,
                                               objEmailMaster.UserName,
                                               objEmailMaster.Status,
                                               objEmailMaster.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parametes, "P_Adm_EmailMaster", "EmailGroup");
        }

        public DataSet SaveEmailUserGroup(clsEmailGroupMaster objEmailMaster)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {objEmailMaster.EmailGroupId,
                                               objEmailMaster.UserId,
                                               objEmailMaster.IsChecked 
                                                    };
            return dataAccess.LoadDataSet(parametes, "P_Adm_UserEmailGroupInsert", "EmailUserGroup");
        }

        public DataSet populateEmailGroup(clsEmailGroupMaster objEmailMaster)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEmailMaster.EmailGroupId };
            return dataAccess.LoadDataSet(parameters, "P_TM_UserEmailGroup_Select", "populateEmailGroup");
        }

        //public DataSet populateSendEmailDesc(clsEmailGroupMaster objEmailMaster)
        //{
        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[] { objEmailMaster.DefEmailGroup };
        //    return dataAccess.LoadDataSet(parameters, "P_TM_SendUserEmail", "populateSendEmailDesc");
        //}

        public DataSet populateSendEmailDesc(clsEmailGroupMaster objEmailMaster)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEmailMaster.GroupName };
            return dataAccess.LoadDataSet(parameters, "P_TM_SendUserEmail", "populateSendEmailDesc");
        }

        public DataSet populateGroupType()
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { };
            return dataAccess.LoadDataSet(parameters, "P_TM_EmailGroupType_Select", "populateGroupType");
        }

        public DataSet SelectPopUpEmailGroup(clsEmailGroupMaster objEmailMaster)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEmailMaster.DefEmailGroup };
            return dataAccess.LoadDataSet(parameters, "P_TM_SelectPopUpEmailGroup", "SelectPopUpEmailGroup");
        }

        public DataSet EditEmailGroup(clsEmailGroupMaster objEmailMaster)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEmailMaster.EmailGroupId,objEmailMaster.GroupName,objEmailMaster.GroupDesc,objEmailMaster.DefEmailGroup,objEmailMaster.EffFromDate,objEmailMaster.EffFromDate1,objEmailMaster.EffToDate,objEmailMaster.EffToDate1 };
            //return dataAccess.LoadDataSet(parameters, "P_Adm_EditEmailGroup", "EditEmailGroup");
            return dataAccess.LoadDataSet(parameters, "P_Adm_EmailGroupList", "EditEmailGroup");  
        }

    }
}
