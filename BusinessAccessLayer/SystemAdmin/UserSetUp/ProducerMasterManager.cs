using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.SystemAdmin.UserSetUp;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
  public  class ProducerMasterManager
    {

      DataAccess dataAccessDS = null;
      public DataSet LoadProducerMaster(clsProducerMaster objProdMaster)
      {
          object[] parameters = new object[6] {   objProdMaster.ProdId,
                                                  objProdMaster.ProductionName, 
                                                  objProdMaster.EffFromDate,
                                                  objProdMaster.EffFromDate1, 
                                                  objProdMaster.EffToDate, 
                                                  objProdMaster.EffToDate1 };
          dataAccessDS = new DataAccess();
          return dataAccessDS.LoadDataSet(parameters, "P_TM_ProducerMaster_Select", "TM_ProducerMaster");
      }

      public DataSet SaveProducerMaster(clsProducerMaster objProdMaster)
      {
          object[] parameters = new object[] { objProdMaster.ProdId,
                                                 objProdMaster.ProductionName,                                                 
                                                 objProdMaster.EffFromDate,
                                                 objProdMaster.EffToDate,
                                                 objProdMaster.UserName,
                                                 objProdMaster.Status,
                                                 objProdMaster.PageMethod
                                              };
          dataAccessDS = new DataAccess();
          return dataAccessDS.LoadDataSet(parameters, "P_SysAdm_USetup_Production_InsertUpdate", "TM_ProducerMaster");
      }
    }
}
