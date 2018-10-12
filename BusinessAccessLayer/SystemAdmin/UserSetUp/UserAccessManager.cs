using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.UserSetUp;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class UserAccessManager
    {
        DataAccess dataAccess = null;
        clsUserAccess objGrpAccess = new clsUserAccess();
       
       
        public DataSet getUserAccess(int userId)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { userId };
            DataSet ds = new DataSet();
            ds = dataAccess.LoadDataSet(parametes, "P_TM_UserAccessMaster_Select", "UserAccessSelect");
            return ds;
        }
        public DataSet SaveUserAccess(string xmlFile)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { xmlFile };
            return dataAccess.LoadDataSet(parametes, "P_TM_UserAccessMaster_InsertUpdate", "UserAccess");
        }
        public DataSet LoadMenu(string strParentMenuCode)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { strParentMenuCode };
            return dataAccess.LoadDataSet(parametes, "P_TM_GetMenusItems", "MenuItems");
        }
        public DataSet LoadTopMenu(string strRootMenuCode)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { strRootMenuCode };
            return dataAccess.LoadDataSet(parametes, "P_TM_Menu_SelectTopMenu", "TopMenuItems");
        }
        public DataSet LoadGroupAccessMenuList(string parentmenucode, string strGrpAccessCd)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { parentmenucode, strGrpAccessCd };
            return dataAccess.LoadDataSet(parametes, "P_TM_Menus_GetGroupAccessList", "GroupAccessMenuList");
        }


    }
}
