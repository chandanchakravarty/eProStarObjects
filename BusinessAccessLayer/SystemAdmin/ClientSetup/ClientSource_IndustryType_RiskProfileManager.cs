using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BusinessObjectLayer.SystemAdmin.ClientSetup ;
using DataAccessLayer;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
  public   class ClientSource_IndustryType_RiskProfileManager
    {
        DataAccess dataAccess = null;

        ////--------------------Client Soursce------------------//
        //public DataSet getDocumentComplianceDetails(clsClientSource_IndustryType_RiskProfile objCS)
        //{
        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[] { objCS.ClientSource, objCS.ClientSourceID };
        //    return dataAccess.LoadDataSet(parameters, "P_Pol_DocumentComplianceMasterSelectAll", "DocComplianceDetails");
        //}
        //public DataSet SaveDocumentComplianceDetails(clsClientSource_IndustryType_RiskProfile objCS)
        //{


        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[] {objCS.ClientSourceID  ,
        //                                       objCS.ClientSource  ,
        //                                       objCS.CreatedBy
        //                                            };
        //    return dataAccess.LoadDataSet(parameters, "P_Pol_DocumentComplianceMaster_InsertUpdate", "DocumentComplianceInsertUpdate");
        //}

    //--------------------Industry Type------------------//
        public DataSet getClientsourceIndustryTypeRiskProfileDetails(clsIndustryTypeRiskProfile objIT)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objIT.Type , objIT.Desc , objIT.TypeID,objIT.MasterName,objIT.EffFrom,objIT.EffTo ,objIT.EffFrom1,objIT.EffTo1   };
            return dataAccess.LoadDataSet(parameters, "P_Pol_ClientsourceIndustryTypeRiskProfile_SelectAll", "ClientsourceIndustryTypeRiskProfileDetails");
        }
        public DataSet SaveClientsourceIndustryTypeRiskProfileDetails(clsIndustryTypeRiskProfile objIT)
        {


            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objIT.TypeID   ,
                                               objIT.Type   ,
                                               objIT.Desc    ,
                                               objIT.CreatedBy,
                                               objIT.MasterName ,objIT.EffFrom,objIT.EffTo
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Pol_ClientsourceIndustryTypeRiskProfile_InsertUpdate", "ClientsourceIndustryTypeRiskProfileInsertUpdate");
        }


        

    }
    
}
