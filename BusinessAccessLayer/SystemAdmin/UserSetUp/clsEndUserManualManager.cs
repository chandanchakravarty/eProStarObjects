using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BusinessObjectLayer.SystemAdmin.UserSetUp;
using DataAccessLayer;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class clsEndUserManualManager
    {
        DataAccess dataAccessDS = null;

        public DataSet LoadEndUserManual(clsEndUserManual objEndUserManual)
        {
            object[] parameters = new object[6] {   objEndUserManual.FileName, 
                                                    objEndUserManual.FileDesc, 
                                                    objEndUserManual.FilePath,
                                                    objEndUserManual.UploadBy,
                                                    objEndUserManual.ProjectType,
                                                    objEndUserManual.IntFileName
 
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_EndUserManual_Insert", "EndUserManual");
        }

        public DataSet getEndUserManualList(clsEndUserManual objEndUserManual)
        {
            object[] parameter = new object[1] { objEndUserManual.ProjectType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameter, "P_TM_EndUserManual_Select", "EndUserManualList");
        }

        public DataSet DeleteEndUserManualList(clsEndUserManual objEndUserManual)
        {
            object[] parameter = new object[1] { objEndUserManual.DelId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameter, "P_TM_EndUserManual_Delete", "EndUserManualList");
        }

    }
}
