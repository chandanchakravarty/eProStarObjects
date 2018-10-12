using System;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
   public class clsPaymentModeManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadIHPaymentMode(clsIHPaymentMode objIHpaymentMode)
        {
            object[] parameters = new object[] {  objIHpaymentMode.PaymentModeId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_PaymentMaster_Select", "IHPaymentModeSelect");
        }

        public DataSet LoadIHPaymentModeAll(clsIHPaymentMode objIHpaymentMode)
        {
            object[] parameters = new object[] { objIHpaymentMode.PaymentModeCode, objIHpaymentMode.PaymentModeName, objIHpaymentMode.EffFromDate, objIHpaymentMode.EffFromDate1, objIHpaymentMode.EffToDate, objIHpaymentMode.EffToDate1 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_PaymentmodeMaster_SelectAll", "IHPaymentModeSelect");
        }
        public DataSet ValidatePaymentModeNo(clsIHPaymentMode objIHpaymentMode)
        {

            object[] parameters = new object[] { objIHpaymentMode.PaymentModeCode };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "IH_ValidatePaymentModeCode", "IHPaymentModeSelect");
        }

        public DataSet SavePaymentMode(clsIHPaymentMode objIHpaymentMode)
        {
            object[] parameters = new object[] { objIHpaymentMode.PaymentModeCode, objIHpaymentMode.PaymentModeName,objIHpaymentMode.NoOfInstl,objIHpaymentMode.InstlFee, objIHpaymentMode.EffFromDate, objIHpaymentMode.EffToDate, objIHpaymentMode.User, objIHpaymentMode.PageMode, objIHpaymentMode.PaymentModeId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "sp_IHPaymentModeDetails_InsertUpdate", "IHPaymentModeSelect");

        }
    }
}


