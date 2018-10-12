using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using BusinessObjectLayer.Admin;
using System.Data;

namespace BusinessAccessLayer.Admin
{
    public class MenuItem
    {
         DataAccess dataAccess = new DataAccess();

         public MenuItem()
        {
        }

         public DataSet GetMenues()
         {
             string[] tableList ={ 
                "MenuType"
            };
             return dataAccess.LoadDataSets("sp_TM_Menu_selByID", tableList);

         }
         public DataSet GetMenuesByID(Menu obj)
         {
             Object[] parametes = new Object[1] { obj.MenuCode  };
             return dataAccess.LoadDataSet(parametes, "sp_TM_Menu_selByParent", "MenuList");
         }
    }
}
