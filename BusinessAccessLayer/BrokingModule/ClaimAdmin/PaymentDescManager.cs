using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
    public class PaymentDescManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadPaymentDesc(clsPaymentDescMaster objPaymentDesc)
        {
            object[] parameter = new object[1] { objPaymentDesc.PaymentDescId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_PaymentDescriptionMaster_Select", "PaymentDescSelect");

        }
        public DataSet SavePaymentDesc(clsPaymentDescMaster objPaymentDesc)
        {
            DataAccessDs = new DataAccess();
            object[] parameter = new object[6]{
                                             objPaymentDesc.PaymentDescId,
                                             objPaymentDesc.PaymentDesc,
                                             objPaymentDesc.EffectivefromDate,
                                             objPaymentDesc.Effectivetodate,
                                             objPaymentDesc.User,
                                             objPaymentDesc.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_PaymentDescriptionMaster_InsertUpdate", "PaymentDescDetail");

        }
    }
}
