using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.CoverNote
{
    public class ClsFileAttachment
    {
        public string TranRefNo { get; set; }
        public string ID { get; set; }
        public string SavedFileName { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }
        public string UploadFolderPath { get; set; }
        public string PrintedSlipFields { get; set; }

        public string Underwriter { get; set; }
        public string Client { get; set; }
        public string Own { get; set; }
        public string UnderwriterCompanyLogo { get; set; }
        public string ClientCompanyLogo { get; set; }
        public string OwnCompanyLogo { get; set; }
    }
}
