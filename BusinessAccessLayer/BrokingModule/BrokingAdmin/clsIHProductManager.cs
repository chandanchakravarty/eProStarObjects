using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
  public  class clsIHProductManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadIHProduct(clsIHProduct objIHproduct)
        {
            object[] parameters = new object[] { objIHproduct.ProductCode };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ProductMaster_Select", "IHProductSelect");
        }

        public DataSet LoadIHProductAll(clsIHProduct objIHProduct)
        {
            object[] parameters = new object[] { objIHProduct.ProductCode, objIHProduct.ProductName, objIHProduct.UniqueNo, objIHProduct.UWName, objIHProduct.EffFromDate, objIHProduct.EffFromDate1, objIHProduct.EffToDate, objIHProduct.EffToDate1 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ProductMaster_SelectAll", "IHProductSelect");
        }
        public DataSet ValidateUniqueNo(clsIHProduct objIHProduct)
        {
            
            object[] parameters = new object[] { objIHProduct.UniqueNo };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "IH_ValidateProductUniqueNo", "IHProductSelect");
        }

        public DataSet SaveProduct(clsIHProduct objIHProduct)
        {
            object[] parameters = new object[] { objIHProduct.ProductCode, objIHProduct.ProductName, objIHProduct.UniqueNo, objIHProduct.UWName, objIHProduct.UWCode, objIHProduct.EffFromDate, objIHProduct.EffToDate ,objIHProduct.User,objIHProduct.PageMode };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "sp_IHProductDetails_InsertUpdate", "IHProductSelect");

        }
    }
}

