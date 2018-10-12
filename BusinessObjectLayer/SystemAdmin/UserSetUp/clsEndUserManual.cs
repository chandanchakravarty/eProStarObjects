using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsEndUserManual
    {
        public string FileName { get; set; }
        public string FileDesc { get; set; }
        public byte[] FilePath { get; set; }
        public string UploadBy { get; set; }
        public string UploadDate { get; set; }
        public string ProjectType { get; set; }
        public string IntFileName { get; set; }
        public int DelId { get; set; }

    }
}
