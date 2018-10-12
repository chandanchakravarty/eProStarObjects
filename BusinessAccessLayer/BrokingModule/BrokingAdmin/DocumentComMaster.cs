using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
   public class DocumentComMaster
    {
       DataAccess dataAccessDS = null;
        public DataSet LoadDocumentComMasterDetail(clsDocumentComMaster objclsDocumentComMaster)
        {
            object[] parameters = new object[] { objclsDocumentComMaster.DocumentComId};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_DocComplianceMaster_Select", "TM_DocComplianceMaster");

        }

        public DataSet SaveDocumentComMasterDetail(clsDocumentComMaster objclsDocumentComMaster)
        {
            object[] parameters = new object[] { 
                                                 objclsDocumentComMaster.DocumentComId,
                                                 objclsDocumentComMaster.DocumentCom,
                                                 objclsDocumentComMaster.PaperDescription,
                                                 objclsDocumentComMaster.EffectiveDateFrom,
                                                 objclsDocumentComMaster.EffectiveDateTo,
                                                 objclsDocumentComMaster.User,
                                                 objclsDocumentComMaster.Status
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_DocComplianceMaster_InsertUpdate", "TM_DocComplianceMaster");
        }
    }
}
