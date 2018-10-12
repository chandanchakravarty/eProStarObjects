using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin
{
    public class clsMigration : clsMigrationType
    {
        public long MigrationFilesID { get; set; }
        public string BatchRefNo { get; set; }
        public int Action { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string TabName { get; set; }
        public int? TotalNoOfRecords { get; set; }
        public int? FailedRecords { get; set; }
        public int? SuccessRecords { get; set; }
        public string UploadedPath { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Status { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string UploadedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? UploadDateFrom { get; set; }
        public DateTime? UploadDateTo { get; set; }
    }

    public class clsMigrationType
    {
        public int MigrationTypeID { get; set; }
        public string MigrationType { get; set; }
        public string MigrationSubType { get; set; }
        public string MigrationTableName { get; set; }
        public string MigrationFields { get; set; }
    }

}
