using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

namespace MemberUploadService
{
    public class ConfigurationSettingReader
    {
        public ConfigurationSettingReader()
        {
            readAndAssignConfigValue();
        }
        protected static string _Interval = "";
        public static string Interval
        {
            get { return _Interval; }
        }

        protected static string _FolderPath = "";
        public static string FolderPath
        {
            get { return _FolderPath; }
        }

        protected static string _InitialFolderPath = "";
        public static string InitialFolderPath
        {
            get { return _InitialFolderPath; }
        }

        protected static string _ReClaimFolderPath = "";
        public static string ReClaimFolderPath
        {
            get { return _ReClaimFolderPath; }
        }

        protected static string _NonEBClaimFolderPath = "";
        public static string NonEBClaimFolderPath
        {
            get { return _NonEBClaimFolderPath; }
        }

        protected static string _EnrolledFolderPath = "";
        public static string EnrolledFolderPath
        {
            get { return _EnrolledFolderPath; }
        }

        protected static string _MassAdjustmentFolderPath = "";
        public static string MassAdjustmentFolderPath
        {
            get { return _MassAdjustmentFolderPath; }
        }

        protected static string _CSVSourceFilePath = "";
        public static string CSVSourceFilePath
        {
            get { return _CSVSourceFilePath; }
        }

        protected static string _VesselFolderPath = "";
        public static string VesselFolderPath
        {
            get { return _VesselFolderPath; }
        }

        protected static string _LogFilePath = "";
        public static string LogFilePath
        {
            get { return _LogFilePath; }
        }

        protected static string _FromEmail = "";
        public static string FromEmail
        {
            get { return _FromEmail; }
        }
        protected static string _SMTPServer = "";
        public static string SMTPServer
        {
            get { return _SMTPServer; }
        }
        protected static string _LogEnabled = "";
        public static string LogEnabled
        {
            get { return _LogEnabled; }
        }
        private void readAndAssignConfigValue()
        {
            bool blLoadFromFile = true;
            //try
            //{
            //    if (ConfigurationManager.AppSettings["CheckDBConfig"].ToString().Trim().ToUpper().Equals("YES"))
            //    {
            //        Object[] parametes = new Object[1] { "WindowService"};
            //        DataSet dsReturn =  dataAccess.LoadDataSet( "P_GetConfig ", "Config");
            //        if (dsReturn.Tables.Count > 0 && dsReturn.Tables[0].Rows.Count > 0)
            //        {
            //            //Interval
            //            DataRow[] drConfigDtl = dsReturn.Tables[0].Select("Configkey = 'Interval'");
            //            if (drConfigDtl.Length > 0)
            //            {
            //                _Interval = drConfigDtl[0]["Configvalue"].ToString();
            //            }
            //            else
            //            {
            //                _Interval = ConfigurationManager.AppSettings["Interval"].ToString().Trim();
            //            }
            //            //InsurerCode
            //            drConfigDtl = dsReturn.Tables[0].Select("Configkey = 'InsurerCode'");
            //            if (drConfigDtl.Length > 0)
            //            {
            //                _InsurerCode = drConfigDtl[0]["Configvalue"].ToString();
            //            }
            //            else
            //            {
            //                _InsurerCode = ConfigurationManager.AppSettings["InsurerCode"].ToString().Trim();
            //            }
            //            //SMTPServer
            //            drConfigDtl = dsReturn.Tables[0].Select("Configkey = 'SMTPServer'");
            //            if (drConfigDtl.Length > 0)
            //            {
            //                _SMTPServer = drConfigDtl[0]["Configvalue"].ToString();
            //            }
            //            else
            //            {
            //                _SMTPServer = ConfigurationManager.AppSettings["SMTPServer"].ToString().Trim();
            //            }
            //            //LogEnabled
            //            drConfigDtl = dsReturn.Tables[0].Select("Configkey = 'LogEnabled'");
            //            if (drConfigDtl.Length > 0)
            //            {
            //                _LogEnabled = drConfigDtl[0]["Configvalue"].ToString();
            //            }
            //            else
            //            {
            //                _LogEnabled = ConfigurationManager.AppSettings["LogEnabled"].ToString().Trim();
            //            }
            //            //LogEnabled
            //            drConfigDtl = dsReturn.Tables[0].Select("Configkey = 'PAsiaWS'");
            //            if (drConfigDtl.Length > 0)
            //            {
            //                _PAsiaWS = drConfigDtl[0]["PAsiaWS"].ToString();
            //            }
            //            else
            //            {
            //                _PAsiaWS = ConfigurationManager.AppSettings["PAsiaWS"].ToString().Trim();
            //            }
            //            drConfigDtl = dsReturn.Tables[0].Select("Configkey = 'EbixWS'");
            //            if (drConfigDtl.Length > 0)
            //            {
            //                _EbixWS = drConfigDtl[0]["EbixWS"].ToString();
            //            }
            //            else
            //            {
            //                _EbixWS = ConfigurationManager.AppSettings["EbixWS"].ToString().Trim();
            //            }
            //            drConfigDtl = dsReturn.Tables[0].Select("Configkey = 'FileSavePath'");
            //            if (drConfigDtl.Length > 0)
            //            {
            //                _FileSavePath = drConfigDtl[0]["FileSavePath"].ToString();
            //            }
            //            else
            //            {
            //                _FileSavePath = ConfigurationManager.AppSettings["FileSavePath"].ToString().Trim();
            //            }
            //            drConfigDtl = dsReturn.Tables[0].Select("Configkey = 'ReportUrlPath'");
            //            if (drConfigDtl.Length > 0)
            //            {
            //                _ReportUrlPath = drConfigDtl[0]["ReportUrlPath"].ToString();
            //            }
            //            else
            //            {
            //                _ReportUrlPath = ConfigurationManager.AppSettings["ReportUrlPath"].ToString().Trim();
            //            }
            //        }
            //        else
            //        {
            //            blLoadFromFile = true;
            //        }
            //    }
            //    else
            //    {					
            //        blLoadFromFile = true;
            //    }
            //}
            //catch(Exception exp)
            //{
            //    EventLogs.Publish("Configuration Reader Error." + exp.Message + " - Loaded with file settings ",System.Diagnostics.EventLogEntryType.Error);							
            //    blLoadFromFile = true;
            //}
            if (blLoadFromFile)
            {
                _Interval = ConfigurationManager.AppSettings["Interval"].ToString().Trim();
                _FolderPath = ConfigurationManager.AppSettings["FolderPath"].ToString().Trim();
                _CSVSourceFilePath = ConfigurationManager.AppSettings["CSVSourceFilePath"].ToString().Trim();

                _InitialFolderPath = ConfigurationManager.AppSettings["InitialFilePath"].ToString().Trim();
                _EnrolledFolderPath = ConfigurationManager.AppSettings["EnrolledFilePath"].ToString().Trim();
                _MassAdjustmentFolderPath = ConfigurationManager.AppSettings["MassAdjustmentFilePath"].ToString().Trim();

                _ReClaimFolderPath = ConfigurationManager.AppSettings["ReClaimFolderPath"].ToString().Trim();
                _NonEBClaimFolderPath = ConfigurationManager.AppSettings["NonEBClaimFolderPath"].ToString().Trim();
                
                _VesselFolderPath = ConfigurationManager.AppSettings["VesselFolderPath"].ToString().Trim();
                _LogFilePath = ConfigurationManager.AppSettings["LogFilePath"].ToString().Trim();

                //_SMTPServer = ConfigurationManager.AppSettings["FromEmail"].ToString().Trim();
                //_FromEmail = ConfigurationManager.AppSettings["SMTPServer"].ToString().Trim();
                //_LogEnabled = ConfigurationManager.AppSettings["LogEnabled"].ToString().Trim();

                //_Interval = "1";
                //_FolderPath = @"D:\Projects\eProfessional_NWI\eProfessional_N\MainUploads";
                //_CSVSourceFilePath = "MemberUpload";
                _SMTPServer = "localhost";
                _FromEmail = "etreksupport@etreksolutions.com";
                _LogEnabled = "True";
            }

        }
    }
}
