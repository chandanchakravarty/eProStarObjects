using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.RIBrokingSystem;

namespace BusinessAccessLayer.RIBrokingModule.RIBrokingSystem
{
    public class clsIRMAutoCompleteManager
    {
        DataAccess dataAccess = new DataAccess();

        public DataSet GetAutoCompleData(clsIRMAutoComplete objIRMAutoComplete)
        {
            Object[] parametes = new Object[]
                                    {
                                        objIRMAutoComplete.SearchString,
                                        objIRMAutoComplete.RequestFrom,
                                        objIRMAutoComplete.SearchFor
                                    };
            return dataAccess.LoadDataSet(parametes, "P_IRM_AutoCompleteSearch", "AutoCompleteSearch");
        }

    }
}
