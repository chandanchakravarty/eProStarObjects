using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Claims
{
    public class clsECClaimFileUpload
    {
        public string CaseRefNo { get; set; }
        public string ClaimRefNo { get; set; }
        public string RefNo { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Remarks { get; set; }
        public string UploadBy { get; set; }        
    }
}
