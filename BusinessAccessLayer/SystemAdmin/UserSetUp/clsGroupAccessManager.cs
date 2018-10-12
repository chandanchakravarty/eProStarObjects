using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.UserSetUp;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class clsGroupAccessManager
    {
        DataAccess dataAccess = null;
        clsGroupAccess objGrpAccess = new clsGroupAccess();
        public DataSet getGrpAccess(clsGroupAccess objGrpAccess)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { objGrpAccess.GrpAccessCd };
            return dataAccess.LoadDataSet(parametes, "P_TM_UsrGrpAccessMaster_Select", "GroupAccessSelect");
        }
        public DataSet getGrpAccessAll(clsGroupAccess objGrpAccess)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[7] { objGrpAccess.GrpAccessCd, objGrpAccess.GrpName, objGrpAccess.GrpDescription, objGrpAccess.EffectiveFromDate, objGrpAccess.EffFrom2, objGrpAccess.EffectiveEndDate, objGrpAccess.EffectiveEndDate2 };
            return dataAccess.LoadDataSet(parametes, "P_TM_UsrGrpAccessMaster_SelectAll", "GroupAccessSelect");
        }
        public DataSet SaveGroupAccess(clsGroupAccess objGrpAccess)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {objGrpAccess.GrpAccessCd,
                                               objGrpAccess.GrpName,
                                               objGrpAccess.GrpDescription,
                                               objGrpAccess.EffectiveFromDate,
                                               objGrpAccess.EffectiveEndDate,
                                               objGrpAccess.Status,
                                               objGrpAccess.User,
                                               objGrpAccess.PageMethod
                                                    };
            return dataAccess.LoadDataSet(parametes, "P_TM_UsrGrpAccessMaster_InsertUpdate", "GroupAccess");
        }
        public DataSet getGrpAccessRights(clsGroupAccessRights objGrpAccessRights)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { objGrpAccessRights.GroupAccessCode };
            DataSet ds = new DataSet();
            ds=dataAccess.LoadDataSet(parametes, "P_TM_GrpAccessRights_Select", "GroupAccessRightsSelect");
            return ds;
        }
        public DataSet SaveGroupAccessRights(clsGroupAccessRights objGroupAccess)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { 
                                                objGroupAccess.GroupAccessId,
                                                objGroupAccess.GroupAccessCode,
                                                objGroupAccess.MenuCode,
                                                objGroupAccess.ReadAccess,
                                                objGroupAccess.EditAccess,
                                                objGroupAccess.DeleteAccess,
                                                objGroupAccess.PageMethod 
                                                    };
            return dataAccess.LoadDataSet(parametes, "P_TM_GrpAccessRights_InsertUpdate", "GroupAccessRights");
        }
        public DataSet LoadMenu(string strParentMenuCode)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { strParentMenuCode};
            return dataAccess.LoadDataSet(parametes, "P_TM_GetMenusItems", "MenuItems");
        }
        public DataSet LoadTopMenu(string strRootMenuCode)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { strRootMenuCode };
            return dataAccess.LoadDataSet(parametes, "P_TM_Menu_SelectTopMenu", "TopMenuItems");
        }
        public DataSet LoadGroupAccessMenuList(string parentmenucode,string strGrpAccessCd)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { parentmenucode, strGrpAccessCd };
            return dataAccess.LoadDataSet(parametes, "P_TM_Menus_GetGroupAccessList", "GroupAccessMenuList");
        }

        
    }
}
