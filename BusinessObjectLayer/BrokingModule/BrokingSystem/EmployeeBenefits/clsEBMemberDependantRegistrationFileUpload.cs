using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits
{
    public class clsEBMemberDependantRegistrationFileUpload
    {
        public string CaseRefNo { get; set; }
        public string MemberCode { get; set; }
        public string DependantCode { get; set; }
        public string MemberRefNo { get; set; }
        public string RefNo { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Remarks { get; set; }
        public string UploadBy { get; set; } 
    }
}
