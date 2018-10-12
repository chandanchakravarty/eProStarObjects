using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using BusinessObjectLayer.FlexServices.FlexIRM;


namespace BusinessObjectLayer.FlexServices.FlexIRM
{
   
    public class FlexAttachementList
    {
        //ExportManager objExpManager = null;

        #region Fields
        private System.Int64? _attachID;
        private System.String _attachInternalFileName;
        private System.String _attachDisplayFileName;
        private System.String _attachFileDesc;
        private System.String _attachFor;
        private System.String _attachEnitityId;
        private System.Int64? _polClientID;
        private System.Int16? _polPolicyID;
        private System.Int16? _polPolicyVerID;
        private System.String _fileType;
        private System.String _user;
        private System.String _mischemark;
        private System.Int32? _totalNoOfRecords;
        private System.Int32? _successfulRecords;
        private System.Int32? _failedRecords;
        private System.String _status;
        private System.String _batchReferenceID;

        #endregion


        #region Properties
        public System.Int64? AttachID
        {
            get
            {
                return _attachID;
            }
            set
            {
                _attachID = value;
            }
        }

        public System.String AttachInternalFileName
        {
            get
            {
                return _attachInternalFileName;
            }
            set
            {
                _attachInternalFileName = value;
            }
        }

        public System.String AttachDisplayFileName
        {
            get
            {
                return _attachDisplayFileName;
            }
            set
            {
                _attachDisplayFileName = value;
            }
        }

        public System.String AttachFileDesc
        {
            get
            {
                return _attachFileDesc;
            }
            set
            {
                _attachFileDesc = value;
            }
        }

        public System.String AttachFor
        {
            get
            {
                return _attachFor;
            }
            set
            {
                _attachFor = value;
            }
        }

        public System.String AttachEnitityId
        {
            get
            {
                return _attachEnitityId;
            }
            set
            {
                _attachEnitityId = value;
            }
        }

        public System.Int64? PolClientID
        {
            get
            {
                return _polClientID;
            }
            set
            {
                _polClientID = value;
            }
        }

        public System.Int16? PolPolicyID
        {
            get
            {
                return _polPolicyID;
            }
            set
            {
                _polPolicyID = value;
            }
        }

        public System.Int16? PolPolicyVerID
        {
            get
            {
                return _polPolicyVerID;
            }
            set
            {
                _polPolicyVerID = value;
            }
        }

        public System.String FileType
        {
            get
            {
                return _fileType;
            }
            set
            {
                _fileType = value;
            }
        }

        public System.String User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }


        public System.String Mischemark
        {
            get
            {
                return _mischemark;
            }
            set
            {
                _mischemark = value;
            }
        }

        public System.Int32? TotalNoOfRecords
        {
            get
            {
                return _totalNoOfRecords;
            }
            set
            {
                _totalNoOfRecords = value;
            }
        }

        public System.Int32? SuccessfulRecords
        {
            get
            {
                return _successfulRecords;
            }
            set
            {
                _successfulRecords = value;
            }
        }

        public System.Int32? FailedRecords
        {
            get
            {
                return _failedRecords;
            }
            set
            {
                _failedRecords = value;
            }
        }

        public System.String Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public System.String BatchReferenceID
        {
            get
            {
                return _batchReferenceID;
            }
            set
            {
                _batchReferenceID = value;
            }
        }

        #endregion

        #region Methods
        protected void MapFrom(DataRow dr)
        {
            AttachID = dr["Attach_ID"] != DBNull.Value ? Convert.ToInt32(dr["Attach_ID"]) : AttachID = null;
            AttachInternalFileName = dr["Attach_InternalFileName"] != DBNull.Value ? Convert.ToString(dr["Attach_InternalFileName"]) : AttachInternalFileName = null;
            AttachDisplayFileName = dr["Attach_DisplayFileName"] != DBNull.Value ? Convert.ToString(dr["Attach_DisplayFileName"]) : AttachDisplayFileName = null;
            AttachFileDesc = dr["Attach_File_Desc"] != DBNull.Value ? Convert.ToString(dr["Attach_File_Desc"]) : AttachFileDesc = null;
            AttachFor = dr["Attach_For"] != DBNull.Value ? Convert.ToString(dr["Attach_For"]) : AttachFor = null;
            AttachEnitityId = dr["Attach_EnitityId"] != DBNull.Value ? Convert.ToString(dr["Attach_EnitityId"]) : AttachEnitityId = null;
            PolClientID = dr["Pol_ClientID"] != DBNull.Value ? Convert.ToInt64(dr["Pol_ClientID"]) : PolClientID = null;
            PolPolicyID = dr["Pol_PolicyID"] != DBNull.Value ? Convert.ToInt16(dr["Pol_PolicyID"]) : PolPolicyID = null;
            PolPolicyVerID = dr["Pol_PolicyVerID"] != DBNull.Value ? Convert.ToInt16(dr["Pol_PolicyVerID"]) : PolPolicyVerID = null;
            FileType = dr["FILE_TYPE"] != DBNull.Value ? Convert.ToString(dr["FILE_TYPE"]) : FileType = null;

            Mischemark = dr["Mischemark"] != DBNull.Value ? Convert.ToString(dr["Mischemark"]) : Mischemark = null;
            TotalNoOfRecords = dr["Total_No_of_Records"] != DBNull.Value ? Convert.ToInt32(dr["Total_No_of_Records"]) : TotalNoOfRecords = null;
            SuccessfulRecords = dr["Successful_Records"] != DBNull.Value ? Convert.ToInt32(dr["Successful_Records"]) : SuccessfulRecords = null;
            FailedRecords = dr["Failed_Records"] != DBNull.Value ? Convert.ToInt32(dr["Failed_Records"]) : FailedRecords = null;
            Status = dr["Status"] != DBNull.Value ? Convert.ToString(dr["Status"]) : Status = null;
            BatchReferenceID = dr["BatchReferenceID"] != DBNull.Value ? Convert.ToString(dr["BatchReferenceID"]) : BatchReferenceID = null;
        }
        #endregion
       
    }
}
