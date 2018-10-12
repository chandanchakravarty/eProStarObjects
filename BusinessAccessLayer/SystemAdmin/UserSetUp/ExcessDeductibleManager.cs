using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.UserSetUp;
using System.Data;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class ExcessDeductibleManager
    {
        DataAccess dataAccess = null;

        public DataSet getExcessDeductible(ExcessDeductible objExcessDeductible)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objExcessDeductible.ExcessDeductibleId };
            return dataAccess.LoadDataSet(parameters, "P_Adm_ExcessDeductibleList", "ExcessDeductibleList");
        }

        public DataSet getExcessDeductibleAll(ExcessDeductible objExcessDeductible)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objExcessDeductible.ExcessDeductibleDiscription, objExcessDeductible.EffFromDate, objExcessDeductible.EffFromDate1, objExcessDeductible.EffToDate, objExcessDeductible.EffToDate1 };
            return dataAccess.LoadDataSet(parameters, "P_Adm_ExcessDeductibleListAll", "ExcessDeductibleList");
        }

        public DataSet SaveExcessDeductible(ExcessDeductible objExcessDeductible)
        {

            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objExcessDeductible.ExcessDeductibleId,
                                                objExcessDeductible.ExcessDeductibleDiscription, 
                                               objExcessDeductible.EffFromDate,
                                               objExcessDeductible.EffToDate, 
                                               objExcessDeductible.LoginUserId
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Adm_ExcessDeductible_InsertUpdate", "ExcessDeductible");
        }
    }
}
