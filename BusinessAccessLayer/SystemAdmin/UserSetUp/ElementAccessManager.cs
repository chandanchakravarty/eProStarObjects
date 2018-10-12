using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.UserSetUp;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
   public class ElementAccessManager
    {
        DataAccess dataAccess = null;
        clsElementAccess objElementAccess = new clsElementAccess();

        public DataSet LoadScreenElementList(string menuCode, string userId)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { menuCode, userId };
            return dataAccess.LoadDataSet(parametes, "Proc_getScreenElementsAccessRights", "TM_Screen_Elements");
        }

        public DataSet SaveElementAccess(clsElementAccess objElementAccess)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[11] { objElementAccess.EntityType, objElementAccess.EntityId, objElementAccess.ScreenID, objElementAccess.ReadAccess, objElementAccess.ModifyAccess, objElementAccess.DeleteAccess, objElementAccess.CreatedBy, objElementAccess.LastUpdatedBy, objElementAccess.IsActive, objElementAccess.ElementRefID, objElementAccess.UserID };
            return dataAccess.LoadDataSet(parametes, "P_TM_ScreenElementAccess_InsertUpdate", "TM_ElementAccessMaster");
        }
    }
}
