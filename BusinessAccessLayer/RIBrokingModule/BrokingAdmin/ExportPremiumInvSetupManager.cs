using System;
using System.Collections.Generic;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.RIBrokingModule.BrokingAdmin
{
    public class ExportPremiumInvSetupManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadPremiumInvSetup(string ForModule)
        {
            object[] parameters = new object[1] {ForModule};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_PremiumExportSetup_Select", "ExportSelect");

        }
        public DataSet SavePremiumInvSetup(clsExportPremiumInvSetup objExport)
        {
            object[] parameters = new object[10] {objExport.ExportId,
                                                 objExport.Action,
                                                 objExport.RangFrom,
                                                 objExport.RangTo,
                                                 objExport.fromDate,
                                                 objExport.todate,
                                                 objExport.SystemMessage,
                                                 objExport.User,
                                                 objExport.IsActive,
                                                 objExport.ForModule

                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_PremiumExportSetup_InsertUpdate", "PremiumExport");

        }
        public DataSet SearchPremiumInvSetupDetails(clsExportPremiumInvSetup objExport)
        {
            //object[] parameters = new object[6] { objExport.DebitRangFrom,objExport.DebitRangTo,objExport.fromDate,objExport.todate ,objExport.BatchRefNo,objExport.DebitNoteStatus};
            object[] parameters = new object[5] { objExport.DebitRangFrom, objExport.DebitRangTo, objExport.fromDate, objExport.todate, objExport.BatchRefNo };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BSPremiumExportSetup_Select", "ExportSelect");
        }

        public DataSet SearchRIPremiumInvSetupDetails(clsExportPremiumInvSetup objExport)
        {
            object[] parameters = new object[5] { objExport.DebitRangFrom, objExport.DebitRangTo, objExport.fromDate, objExport.todate, objExport.BatchRefNo };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_RIPremiumExportSetup_Select", "RIExportSelect");
        }

        public DataSet SaveBSPremiumInvSetup(clsExportPremiumInvSetup objExport,string DebitNoteNo)
        {
            object[] parameters = new object[] {objExport.ForModule,
                                                 objExport.User,
                                                 DebitNoteNo,
                                                 objExport.Action,
                                                 objExport.BatchRefNo,
                                                 objExport.CsvFileName
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_DNPremiumExport_LockUnLock", "PremiumExport");
        }

        public DataSet SaveRIPremiumInvSetup(clsExportPremiumInvSetup objExport, string DebitNoteNo)
        {
            object[] parameters = new object[] {objExport.ForModule,
                                                 objExport.User,
                                                 DebitNoteNo,
                                                 objExport.Action,
                                                 objExport.BatchRefNo,
                                                 objExport.CsvFileName
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_RI_DNPremiumExport_LockUnLock", "PremiumExport");
        }

    }
}