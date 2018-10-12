using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits
{
    public class clsEBMemberUpload
    {
        public string CaseRefNo { get; set; }
        public string RefNo     { get; set; }
        public string PolicyNo { get; set; }
        public string FileName { get; set; }
        public byte[] FilePath { get; set; }
        public string FileType { get; set; }
        public string UploadBy { get; set; }
        public string UploadFromDate { get; set; }
        public string UploadToDate { get; set; }
        public string UploadType { get; set; }
        public string FromBatch { get; set; }
        public string CovernoteNo{ get; set; }
        public int AMC { get; set; }
        public int TotalRecord { get; set; }
        public int SuccessRecord { get; set; }
        public int FailedRecord { get; set; }
        public string SuccessRecordID { get; set; }
        public string ReportType { get; set; }

    }

    public class clsEB_RawClaim
    {
        public int BenefitLineID { get; set; }
        public string NonPanel { get; set; }
        public int MinValue { get; set; }
        public int RangeValue { get; set; }
        public int MaxValue { get; set; }
        public string IsSelected { get; set; }
        public string User { get; set; }
        

    }
}
