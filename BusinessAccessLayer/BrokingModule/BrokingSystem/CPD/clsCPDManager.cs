using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BusinessObjectLayer.BrokingModule.BrokingSystem.CPD;
using DataAccessLayer;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem.CPD
{
    public class clsCPDManager
    {
        DataAccess dataAccess = null;
        public DataSet getCPDDetails(clsCPD objCPD)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objCPD.TraineeName, objCPD.CourseStartDate, objCPD.CourseStartDate1, objCPD.CourseEndDate, objCPD.CourseEndDate1,objCPD.CPDid };
            return dataAccess.LoadDataSet(parameters, "TM_CPDMasterSelectAll", "CPDDetails");
        }
        public DataSet SaveCPDDetails(clsCPD objCPD)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objCPD.CPDid,
                                                objCPD.UserId,
                                               objCPD.CpdYear,
                                               objCPD.CourseStartDate,
                                               objCPD.CourseEndDate,
                                               objCPD.CourseName,
                                               objCPD.TrainingProvider,
                                               objCPD.TrainingHours,
                                               objCPD.CPDHoursAccredited,
                                               objCPD.Remarks,
                                               objCPD.CreatedBy
                                                    };
            return dataAccess.LoadDataSet(parameters, "TM_CPDMaster_InsertUpdate", "CPD");
        }
    }
}
