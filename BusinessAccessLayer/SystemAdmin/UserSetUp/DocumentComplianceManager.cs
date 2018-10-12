using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BusinessObjectLayer.SystemAdmin.UserSetup;
using DataAccessLayer;
namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
  public  class DocumentComplianceManager
    {
   
        DataAccess dataAccess = null;



        public DataSet getDocumentComplianceDetails(clsDocumentCompliance objDoc)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objDoc.PaperType, objDoc.PaperDesc, objDoc.DocID  };
            return dataAccess.LoadDataSet(parameters, "P_Pol_DocumentComplianceMasterSelectAll", "DocComplianceDetails");
        }
        public DataSet SaveDocumentComplianceDetails(clsDocumentCompliance objDoc)
        {

        
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objDoc.DocID ,
                                               objDoc.PaperType ,
                                               objDoc.PaperDesc ,
                                               objDoc.CreatedBy
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Pol_DocumentComplianceMaster_InsertUpdate", "DocumentComplianceInsertUpdate");}



        public DataSet SaveRenewalLapsedReason(clsRenewalReason objDoc)
        {


            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objDoc.DocID ,
                                               objDoc.RenewalLapsedReason ,
                                               objDoc.Description ,
                                               objDoc.CreatedBy
                                                    };
            return dataAccess.LoadDataSet(parameters, "P_Pol_RenewalLapsedReason_InsertUpdate", "TM_RenewalLapsedMaster");
        }

        public DataSet getRenewalLapsedReason(clsRenewalReason objDoc)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objDoc.RenewalLapsedReason,objDoc.Description,objDoc.DocID};
            return dataAccess.LoadDataSet(parameters, "P_Pol_RenewalLapsedReasonSelectAll", "TM_RenewalLapsedMaster");
        }


    }
}
