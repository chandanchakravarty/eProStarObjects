using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
   public class clsBMSchemeManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadIHScHeme(cls_BMScheme objIHScheme)
        {
            object[] parameters = new object[] { objIHScheme.SchemeCode };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SchemeMaster_Select", "IHSchemeSelect");
        }

        public DataSet LoadIHSchemeAll(cls_BMScheme objIHScheme)
        {
            object[] parameters = new object[] { objIHScheme.SchemeCode, objIHScheme.SchemeName, objIHScheme.EffFromDate, objIHScheme.EffFromDate1, objIHScheme.EffToDate, objIHScheme.EffToDate1 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SchemeMaster_SelectAll", "IHSchemeSelectAll");
        }

        public DataSet SaveScheme(cls_BMScheme objIHScheme)
        {
            object[] parameters = new object[] { objIHScheme.SchemeCode, objIHScheme.SchemeName, objIHScheme.EffFromDate, objIHScheme.EffToDate, objIHScheme.User,objIHScheme.PageMode };     
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "sp_IHSchemeDetails_InsertUpdate", "IHSchemeSelect");

        }
    }
}
