using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem
{
    public class clsEmailNotification
    {
        public DataSet EmailNotificationTeam(int TeamId)
        {
            DataAccess dataAccess = new DataAccess();
            Object[] parameters = new Object[] { TeamId};
            return dataAccess.LoadDataSet(parameters, "P_TM_EmailNotification_TeamSelect", "EmailNotificationTeam");
        }

        public DataSet EmailNotificationEmailGroup()
        {
            DataAccess dataAccess = new DataAccess();
            Object[] parameters = new Object[] { };
            return dataAccess.LoadDataSet(parameters, "P_TM_EmailNotification_EmailGroupSelect", "EmailNotificationEmailGroup");
        }

    }
}
