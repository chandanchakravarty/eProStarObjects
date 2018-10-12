using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
namespace BusinessAccessLayer.BrokingModule.BrokingSystem
{
    public class BMAutoCompleteManager
    {
        DataAccess dataAccess = new DataAccess();        
        public DataSet GetAutoCompleData(clsBMAutoComplete objBMAutoComplete)
        {
            Object[] parametes = new Object[]
                                    {
                                        objBMAutoComplete.SearchString,
                                        objBMAutoComplete.RequestFrom,
                                        objBMAutoComplete.SearchFor
                                    };
            return dataAccess.LoadDataSet(parametes, "P_BM_AutoCompleteSearch", "AutoCompleteSearch");
        }

        public DataSet GetINCAutoSearchData(clsBMAutoComplete objBMAutoComplete)
        {
            Object[] parametes = new Object[]
                                    {
                                        objBMAutoComplete.SearchString,
                                        objBMAutoComplete.RequestFrom,
                                        objBMAutoComplete.SearchFor
                                    };
            return dataAccess.LoadDataSet(parametes, "P_POL_InCompleteQuotation_AutoSearch", "INCAutoSearch");
        }

        
        
        public DataSet GetINCAutoSearchLocation(clsBMAutoComplete objBMAutoComplete)
        {
            Object[] parametes = new Object[]
                                    {
                                        objBMAutoComplete.SearchString,
                                        objBMAutoComplete.RequestFrom
                                        
                                    };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyMaster_GetRiskLocation", "INCAutoSearch");
        }

        public DataSet GetINCAutoSearchVehRegNo(clsBMAutoComplete objBMAutoComplete)
        {
            Object[] parametes = new Object[]
                                    {
                                        objBMAutoComplete.SearchString,
                                        objBMAutoComplete.RequestFrom
                                        
                                    };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyMaster_GetVehicleRegNo", "INCAutoSearch");
        }

        public DataSet GetINCAutoSearchQuotation(clsBMAutoComplete objBMAutoComplete)
        {
            Object[] parametes = new Object[]
                                    {
                                        objBMAutoComplete.SearchString,
                                        //objBMAutoComplete.strUser,
                                        objBMAutoComplete.strCompany,
                                        objBMAutoComplete.strBranch,
                                        objBMAutoComplete.charIsComplete
                                    };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyMaster_QutationAutoSearch", "Pol_PolicyMaster");
        }

        public DataSet GetINCAutoSearchPolicyType(clsBMAutoComplete objBMAutoComplete)
        {
            Object[] parametes = new Object[]
                                    {
                                        objBMAutoComplete.SearchString,
                                        objBMAutoComplete.strCompany,
                                        objBMAutoComplete.strBranch,
                                        //objBMAutoComplete.charIsComplete
                                    };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyMaster_PolTypeSearch", "Pol_PolicyMaster");
        }

        public DataSet GetINCAutoSearchCovernote(clsBMAutoComplete objBMAutoComplete)
        {
            Object[] parametes = new Object[]
                                    {
                                        objBMAutoComplete.SearchString,
                                        //objBMAutoComplete.strUser,
                                        objBMAutoComplete.strCompany,
                                        objBMAutoComplete.strBranch
                                        //,objBMAutoComplete.charIsComplete
                                    };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyMaster_CovernoteAutoSearch", "Pol_PolicyMaster");
        }

        public DataSet GetINCAutoSearchCovernoteByClientInfo(clsBMAutoComplete objBMAutoComplete)
        {
            Object[] parametes = new Object[]
                                    {
                                        objBMAutoComplete.SearchString,
                                        //objBMAutoComplete.strUser,
                                        objBMAutoComplete.strCompany,
                                        objBMAutoComplete.strBranch,
                                        objBMAutoComplete.strUser
                                        //,objBMAutoComplete.charIsComplete
                                    };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyMaster_CovernoteAutoSearchByClientInfo", "Pol_PolicyMaster");
        }

        public DataSet GetINCAutoSearchCovernoteRawClaim(clsBMAutoComplete objBMAutoComplete)
        {
            Object[] parametes = new Object[]
                                    {
                                        objBMAutoComplete.SearchString,
                                        //objBMAutoComplete.strUser,
                                        objBMAutoComplete.strCompany,
                                        objBMAutoComplete.strBranch,
                   
                                        //,objBMAutoComplete.charIsComplete
                                    };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyMaster_CovernoteAutoSearchByRawClaim", "Pol_PolicyMaster");
        }

        public DataSet GetINCAutoSearchPolicyNumber(clsBMAutoComplete objBMAutoComplete)
        {
            Object[] parametes = new Object[]
                                    {
                                        objBMAutoComplete.SearchString,
                                        //objBMAutoComplete.strUser,
                                        objBMAutoComplete.strCompany,
                                        objBMAutoComplete.strBranch
                                        //,objBMAutoComplete.charIsComplete
                                    };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyMaster_PolicyNoAutoSearch", "Pol_PolicyMaster");
        }



    }
}
