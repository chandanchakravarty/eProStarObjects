using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin;
using System.Data;

namespace BusinessAccessLayer.SystemAdmin
{
    public class clsMigartionManager
    {
        DataAccess dataAccess = null;
        clsMigration objClass = new clsMigration();

        public DataSet GetMigration(clsMigration objMigration)
        {
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            Object[] parametes = new Object[] { 
                                                objMigration.MigrationFilesID,
                                              };
            ds = dataAccess.LoadDataSet(parametes, "P_MIG_MigrationFiles_SEL", "MigrationSelect");
            return ds;
        }

        public DataSet GetMigrationBillingWoClosingSlip(clsMigration objMigration)
        {
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            Object[] parametes = new Object[] { 
                                                objMigration.BatchRefNo,
                                                objMigration.FileName,
                                                objMigration.UploadDate
                                              };
            ds = dataAccess.LoadDataSet(parametes, "P_MIG_MigrationBillingWoClosingSlip_SEL", "MigrationSelect");
            return ds;
        }

        public DataSet SearchMigrationBillingWoClosingSlip(clsMigration objMigration)
        {
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            Object[] parametes = new Object[] { 
                                                objMigration.BatchRefNo,
                                                objMigration.FileName,
                                                objMigration.UploadDateFrom,
                                                objMigration.UploadDateTo
                                              };
            ds = dataAccess.LoadDataSet(parametes, "P_MIG_SearchMigrationBillingWoClosingSlip_SEL", "MigrationSelect");
            return ds;
        }


        public DataSet GetBillingWOCSMigrationDetails(string batchRefNo)
        {
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            Object[] parametes = new Object[] { batchRefNo };
            ds = dataAccess.LoadDataSet(parametes, "P_MIG_MigrationBillingWoClosingSlip_SEL", "MigrationDetailsSelect");
            return ds;
        }

        public DataSet GetMigrationType(Int32 ID)
        {
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            Object[] parametes = new Object[] { 
                                                ID
                                              };
            ds = dataAccess.LoadDataSet(parametes, "P_MIG_MigrationType_SEL", "MigrationType");
            return ds;
        }

        public DataSet GetMigrationBillingWoClosingSlipType()
        {
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            ds = dataAccess.LoadDataSet("P_MIG_MigrationBillingWoClosingSlipType_SEL", "MigrationType");
            return ds;
        }

        public DataSet MigrationInsUpd(clsMigration objMigration)
        {
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            Object[] parametes = new Object[] { 
                                                objMigration.MigrationFilesID,
                                                objMigration.MigrationTypeID,
                                                objMigration.Action,
                                                objMigration.FileName,
                                                objMigration.FileType,
                                                objMigration.TabName,
                                                objMigration.TotalNoOfRecords,
                                                objMigration.FailedRecords,
                                                objMigration.UploadedPath,
                                                objMigration.UploadDate,
                                                objMigration.Status,
                                                objMigration.IsProcessed,
                                                objMigration.ProcessedDate,
                                                objMigration.UploadedBy,
                                                objMigration.LastUpdatedBy,
                                                objMigration.LastUpdatedDate
                                              };
            ds = dataAccess.LoadDataSet(parametes, "P_MIG_MigrationFiles_INS_UPD", "MigrationInsUpd");
            return ds;
        }

        public DataSet MigrationBillingWoClosingSlipInsUpd(clsMigration objMigration)
        {
            dataAccess = new DataAccess();
            DataSet ds = new DataSet();
            Object[] parametes = new Object[] { 
                                                objMigration.BatchRefNo,
                                                objMigration.Action,
                                                objMigration.FileName,
                                                objMigration.FileType,
                                                objMigration.TotalNoOfRecords,
                                                objMigration.FailedRecords,
                                                objMigration.SuccessRecords,
                                                objMigration.UploadedPath,
                                                objMigration.UploadDate,
                                                objMigration.Status,
                                                objMigration.IsProcessed,
                                                objMigration.ProcessedDate,
                                                objMigration.UploadedBy,
                                                objMigration.LastUpdatedBy,
                                                objMigration.LastUpdatedDate
                                              };
            ds = dataAccess.LoadDataSet(parametes, "P_MIG_MigrationBillingWoClosingSlip_INS_UPD", "MigrationInsUpd");
            return ds;
        }
    }
}
