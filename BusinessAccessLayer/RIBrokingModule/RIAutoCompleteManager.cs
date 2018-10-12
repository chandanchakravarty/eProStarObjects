using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule;

namespace BusinessAccessLayer.RIBrokingModule
{
    public class RIAutoCompleteManager
    {
        DataAccess dataAccess = new DataAccess();
        public DataSet GetAutoCompleData(ClsRIAutoComplete objRIAutoComplete)
        {
            Object[] parametes = new Object[]
                                    {
                                        objRIAutoComplete.ReinsurerName,
                                        objRIAutoComplete.RequestFrom,
                                        objRIAutoComplete.SearchFor
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RI_AutoCompleteSearch", "AutoCompleteSearch");
        }

    }
}
