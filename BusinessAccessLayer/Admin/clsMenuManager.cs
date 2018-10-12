using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectLayer.Admin;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.Admin
{
    public class clsMenuManager
    {
        DataAccess dataAccess = null;
        

        public DataSet getMenus(clsMenu objMenu)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objMenu.ParentMenuCode};
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_TM_GetMenus", "MenuList");
        }
        public DataSet getMenusByGroupCode(int UserId, string ChildBand, string MiddleBand, string TopBand,string TopMostband,string menuCode)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { UserId, menuCode, ChildBand, MiddleBand, TopBand, TopMostband };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GetMenuHierarchyByGrpAccess", "MenuListByGroupCode");
        }

        public DataSet getMenusByGroupCode(int UserId, string menuCode)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { UserId, menuCode };
            //Object[] parameters = new Object[3] { objSOB.SOBId, objSOB.SOBName, objSOB.Status };
            return dataAccess.LoadDataSet(parameters, "P_GetMenuHierarchyByGrpAccessGeneric", "MenuListByGroupCode");
        }

        public DataSet getMenusGeneric(clsMenu objMenu)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objMenu.ParentMenuCode };
            return dataAccess.LoadDataSet(parameters, "P_TM_GetMenus_Generic", "MenuList");
        }
        public DataSet getMenusUserBases(clsMenu objMenu)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objMenu.ParentMenuCode,objMenu.LoginUserId };
            return dataAccess.LoadDataSet(parameters, "P_TM_GetMenus_UserAccess", "MenuList");
        }
    }
}
