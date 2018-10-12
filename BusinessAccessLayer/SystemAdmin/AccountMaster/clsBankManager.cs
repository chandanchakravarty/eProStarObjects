using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.AccountMaster;


namespace BusinessAccessLayer.SystemAdmin.AccountMaster
{
    public class clsBankManager
    {
        DataAccess dataAccess = null;
        clsBankMaster objInfo = new clsBankMaster();

        public DataSet getBank(clsBankMaster objBank)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objBank.BankId};
            return dataAccess.LoadDataSet(parameters, "P_TM_BankMaster_Select", "BankList");
        }
        public DataSet SaveBankDetails(clsBankMaster objBank)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {
                                               objBank.BankId,
                                               objBank.CompanyId,
                                               objBank.CurrencyId,
                                               objBank.CorresName,
                                               objBank.CorresAddress,
                                               objBank.CorresSwiftCode,
                                               objBank.Name,
                                               objBank.Address,
                                               objBank.SwiftCode,
                                               objBank.InFavourOf,
                                               objBank.AccountNo,
                                               objBank.ByOrderOf,
                                               objBank.Message,
                                               objBank.EffectiveFromDate,
                                               objBank.EffectiveToDate,
                                               objBank.User
                                             };
            return dataAccess.LoadDataSet(parametes, "P_TM_BankMaster_InsertUpdate", "SavedBankDetails");


        }
       
    }
}
