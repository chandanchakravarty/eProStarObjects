using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace eProStarServices
{
    public class ConfigurationSettingReader
    {

        public ConfigurationSettingReader(XmlNode ClientNode)
        {
            ReadAndAssignConfigValue(ClientNode);
        }
        protected  string _Interval = "";
        public  string Interval
        {
            get { return _Interval; }
        }

        protected  string _FolderPath = "";
        public  string FolderPath
        {
            get { return _FolderPath; }
        }

        protected  string _InitialFolderPath = "";
        public  string InitialFolderPath
        {
            get { return _InitialFolderPath; }
        }

        protected  string _ReClaimFolderPath = "";
        public  string ReClaimFolderPath
        {
            get { return _ReClaimFolderPath; }
        }

        protected  string _NonEBClaimFolderPath = "";
        public  string NonEBClaimFolderPath
        {
            get { return _NonEBClaimFolderPath; }
        }

        protected  string _EnrolledFolderPath = "";
        public  string EnrolledFolderPath
        {
            get { return _EnrolledFolderPath; }
        }

        protected  string _MassAdjustmentFolderPath = "";
        public  string MassAdjustmentFolderPath
        {
            get { return _MassAdjustmentFolderPath; }
        }

        protected  string _CSVSourceFilePath = "";
        public  string CSVSourceFilePath
        {
            get { return _CSVSourceFilePath; }
        }

        protected  string _VesselFolderPath = "";
        public  string VesselFolderPath
        {
            get { return _VesselFolderPath; }
        }

        protected  string _LogFilePath = "";
        public  string LogFilePath
        {
            get { return _LogFilePath; }
        }

        protected  string _FromEmail = "";
        public  string FromEmail
        {
            get { return _FromEmail; }
        }
        protected  string _SMTPServer = "";
        public  string SMTPServer
        {
            get { return _SMTPServer; }
        }
        protected  string _LogEnabled = "";
        public  string LogEnabled
        {
            get { return _LogEnabled; }
        }
        protected string _ExcelConnXLS = "";
        public string ExcelConnXLS
        {
            get { return _ExcelConnXLS; }
        }
        protected string _ExcelConnXLSX = "";
        public string ExcelConnXLSX
        {
            get { return _ExcelConnXLSX; }
        }
        protected string _ConnString = "";
        public string ConnString
        {
            get { return _ConnString; }
        }
        protected string _ClientCode = "";
        public string ClientCode
        {
            get { return _ClientCode; }
        }

        private void ReadAndAssignConfigValue(XmlNode ClientNode)
        {
            try
            {
                if (ClientNode != null)
                {
                    _ClientCode = ClientNode.Attributes["Code"].Value;
                    XmlNodeList KeyList = ClientNode.SelectNodes("add");
                    foreach (XmlNode key in KeyList)
                    {
                        string strkey = key.Attributes["key"].Value;
                        string strValue = key.Attributes["value"].Value;
                        if (strkey == "ConnectionString")
                            _ConnString = strValue;

                        //else if(strkey=="  CheckDBConfig")
                        //      _CheckDBConfig = strValue;  
                        else if (strkey == "Interval")
                            _Interval = strValue;
                        else if (strkey == "FolderPath")
                            _FolderPath = strValue;
                        //else if (strkey == "InitialFolderPath")
                        //    _InitialFolderPath = strValue;
                        else if (strkey == "LogFilePath")
                            _LogFilePath = strValue;
                        else if (strkey == "CSVSourceFilePath")
                            _CSVSourceFilePath = strValue;
                        else if(strkey=="InitialFilePath")
                            _InitialFolderPath = strValue;
                        else if (strkey == "EnrolledFilePath")
                            _EnrolledFolderPath = strValue;
                        else if (strkey == "MassAdjustmentFilePath")
                            _MassAdjustmentFolderPath = strValue;
                        else if (strkey == "ReClaimFolderPath")
                            _ReClaimFolderPath = strValue;
                        else if (strkey == "NonEBClaimFolderPath")
                            _NonEBClaimFolderPath = strValue;

                        else if (strkey == "VesselFolderPath")
                            _VesselFolderPath = strValue;
                        else if (strkey == "SMTPServer")
                            _SMTPServer = strValue;
                        else if (strkey == "FromEmail")
                            _FromEmail = strValue;
                        //else if(strkey=="ToEmail")
                        //    _ToEmail = strValue;
                        else if (strkey == "LogEnabled")
                            _LogEnabled = strValue;
                        //else if(strkey=="LogErrorEvents")
                        //    _LogEr = strValue;
                        //else if(strkey=="LogWarningEvents")
                        //    _Lo  = strValue;
                        //else if(strkey=="LogInformationEvents")
                        //    _Lo = strValue;
                        //else if(strkey=="LogAuditSuccessEvents")
                        //    _lo  = strValue;
                        //else if(strkey=="LogAuditFailureEvents")
                        //    _lo  = strValue;
                        //else if(strkey=="EventLogName")
                        //    _Eve  = strValue;
                        //else if(strkey=="EventLogSourceName")
                        //    _Eve  = strValue;
                        //else if(strkey=="ClientSettingsProvider.ServiceUri")
                        //    _Eve  = strValue;
                        else if(strkey=="ExcelConnXLS")
                            _ExcelConnXLS  = strValue;
                        else if(strkey=="ExcelConnXLSX")
                            _ExcelConnXLSX  = strValue;
                    }


                }
            }
            catch (Exception ex)
            {
                ServiceUtility.WriteLog("Error while initializing configuration for client " + ClientCode + "." + ex.Message, ClientCode);
            }
            finally
            {
                ClientNode = null;
            }
        }
    }
}

