using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
    public class BankMasterManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadBank(clsBankMaster objBank)
        {
            object[] parameter = new object[1] { objBank.BankId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_BankMaster_Select", "BankSelect");

        }
        public DataSet SaveBank(clsBankMaster objBank)
        {
            DataAccessDs = new DataAccess();
            object[] parameter = new object[7]{
                                             objBank.BankId,
                                             objBank.BankCode,
                                             objBank.BankName,
                                             objBank.EffectivefromDate,
                                             objBank.Effectivetodate,
                                             objBank.User,
                                             objBank.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_BankMaster_InsertUpdate", "BankDetail");

        }
    }
}
