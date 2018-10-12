using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Common
{
    public class FileUpload
    {
        private string _Code;
        private string _UploadFileName;
        private int _UploadFileSize;
        private string _UploadFilePath;
        public string _UploadFileType;
        private string _LoginUserId;
        private string _OriginalFileName;
        private string _UserIPAddress;
        public string _Remarks;
        public string _Module;

        public FileUpload()
        {
            _Code = string.Empty;
            _UploadFileName = string.Empty;
            _UploadFileType = string.Empty;
            _UploadFilePath = string.Empty;
            _UploadFileSize = 0;
            _Remarks = string.Empty;
            _Module = string.Empty;
        }

        public string Code
        {
            set { _Code = value; }
            get { return _Code; }
        }

        public string Module
        {
            set { _Module = value; }
            get { return _Module; }
        }

        public string UploadFileName
        {
            set { _UploadFileName = value; }
            get { return _UploadFileName; }
        }

        public string UploadFileType
        {
            set { _UploadFileType = value; }
            get { return _UploadFileType; }
        }

        public string UploadFilePath
        {
            set { _UploadFilePath = value; }
            get { return _UploadFilePath; }
        }

        public string OriginalFileName
        {
            set { _OriginalFileName = value; }
            get { return _OriginalFileName; }
        }

        public int UploadFileSize
        {
            set { _UploadFileSize = value; }
            get { return _UploadFileSize; }
        }

        public string LoginUserId
        {
            set { _LoginUserId = value; }
            get { return _LoginUserId; }
        }

        public string UserIPAddress
        {
            set { _UserIPAddress = value; }
            get { return _UserIPAddress; }
        }

        public string Remarks
        {
            set { _Remarks = value; }
            get { return _Remarks; }
        }
    }
}
