/***************************************
 * Auther:  Pravesh K Chandel
 * date :   5 May 2017
 * Purpose: To Make a single service which will serve for all the clients hosted on the server.
 * Modified date:
 * Modified By:
 *****************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.IO;
using System.Configuration;
using System.Xml;

namespace eProStarServices
{
    partial class eProStarService : ServiceBase
    {
        private System.Timers.Timer timer = null;
        XmlDocument ServiceConfig = null;
        List<ConfigurationSettingReader> ClientConfigReaders = null;
        public eProStarService()
        {
            ServiceUtility.WriteLog("eProStar Service Initialized.");
            InitializeComponent();
            //ConfigurationSettingReader csr = new ConfigurationSettingReader();
            int interval = 1;
            string strLookUpInterval = "";
            if (ConfigurationManager.AppSettings["Interval"] != null)
                strLookUpInterval = ConfigurationManager.AppSettings["Interval"].ToString().Trim();
            if (strLookUpInterval.Length > 0)
            {
                try
                {
                    interval = Convert.ToInt32(strLookUpInterval);
                    interval = interval * 10000;
                }
                catch
                {
                    interval = 10000;
                }
            }
            timer = new Timer(interval);
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(tmrFileLookUp_Tick);
        }

        protected override void OnStart(string[] args)
        {
            ServiceUtility.WriteLog("eProStar Service Started.");
            LoadServiceConfig();
            ServiceUtility.WriteLog("Service Config loaded.");
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }

        protected override void OnStop()
        {
            ServiceUtility.WriteLog("eProStar Service Stoped.");
            timer.AutoReset = false;
            timer.Enabled = false;
            ServiceConfig = null;
        }
        private void tmrFileLookUp_Tick(object sender, ElapsedEventArgs e)
        {
            //ServiceUtility.WriteLog("Starting Processing of services at " + DateTime.Now.Ticks.ToString());
            try
            {
                this.timer.Stop();
                if (ClientConfigReaders == null) InitializeClientConfig();
                foreach (ConfigurationSettingReader ClientConfig in ClientConfigReaders)
                {
                    try
                    {
                        try
                        {
                            ServiceUtility.WriteLog("Starting Batch Process for Member service for client " + ClientConfig.ClientCode);
                            BatchProcessMember bObj = new BatchProcessMember(ClientConfig);
                            bObj.beginProcess();
                            ServiceUtility.WriteLog("Batch Process for Member service processed for client " + ClientConfig.ClientCode);
                        }
                        catch (Exception ex)
                        {
                            ServiceUtility.WriteLog("Error in Member service for Client " + ClientConfig.ClientCode + ":" + ex.Message);
                        }

                        try
                        {
                            ServiceUtility.WriteLog("Starting Batch Process Raw Claim service for client " + ClientConfig.ClientCode);
                            BatchProcessRawClaim objBatchProcessRawClaim = new BatchProcessRawClaim(ClientConfig);
                            objBatchProcessRawClaim.BeginProcess();
                            ServiceUtility.WriteLog("Batch Process Raw Claim service processed  for client " + ClientConfig.ClientCode);
                        }
                        catch (Exception ex)
                        {
                            ServiceUtility.WriteLog("Error in Raw Claim service for Client " + ClientConfig.ClientCode + ":" + ex.Message);
                        }

                        try
                        {
                            ServiceUtility.WriteLog("Starting Batch Process Reimbursement service for client " + ClientConfig.ClientCode);
                            BatchProcessReimbursementClaim objBatchProcessReimbursementClaim = new BatchProcessReimbursementClaim(ClientConfig);
                            objBatchProcessReimbursementClaim.beginProcess();
                            ServiceUtility.WriteLog("Batch Process Reimbursement Claim service processed for client " + ClientConfig.ClientCode);
                        }
                        catch (Exception ex)
                        {
                            ServiceUtility.WriteLog("Error in Reimbursement Claim service for Client " + ClientConfig.ClientCode + ":" + ex.Message);
                        }

                        try
                        {
                            ServiceUtility.WriteLog("Starting Batch Process Non EB Claim service for client " + ClientConfig.ClientCode);
                            BatchProcessNonEBClaim objBatchProcessNonEBClaim = new BatchProcessNonEBClaim(ClientConfig);
                            objBatchProcessNonEBClaim.beginProcess();
                            ServiceUtility.WriteLog("Batch Process Non EB Claim service processed for client " + ClientConfig.ClientCode);
                        }
                        catch (Exception ex)
                        {
                            ServiceUtility.WriteLog("Error in Non EB Claim service for Client " + ClientConfig.ClientCode + ":" + ex.Message);
                        }

                        try
                        {
                            ServiceUtility.WriteLog("Starting Batch Process Vessel Upload service for client " + ClientConfig.ClientCode);
                            BatchProcessVessel objVessel = new BatchProcessVessel(ClientConfig);
                            objVessel.beginProcess();
                            ServiceUtility.WriteLog("Batch Process Vessel Upload service processed for client " + ClientConfig.ClientCode);
                        }
                        catch (Exception ex)
                        {
                            ServiceUtility.WriteLog("Error in Vessel service for Client " + ClientConfig.ClientCode + ":" + ex.Message);
                        }

                        try
                        {
                            ServiceUtility.WriteLog("Starting Batch Process Billing Without Closing Slip Upload service for client " + ClientConfig.ClientCode);
                            BillingWOClosingSlip objBillingWoClosingSlip = new BillingWOClosingSlip(ClientConfig);
                            objBillingWoClosingSlip.beginProcess();
                            ServiceUtility.WriteLog("Batch Process Billing Without Closing Slip Upload service processed for client " + ClientConfig.ClientCode);
                        }
                        catch (Exception ex)
                        {
                            ServiceUtility.WriteLog("Error in Billing Without Closing Slip service for Client " + ClientConfig.ClientCode + ":" + ex.Message);
                        }
                        try
                        {
                            ServiceUtility.WriteLog("Starting Deferred Brokerage Recognition Posting for client " + ClientConfig.ClientCode);
                            BatchDeferredPosting objBatchDeferredPosting = new BatchDeferredPosting(ClientConfig);
                            objBatchDeferredPosting.beginProcess();
                            ServiceUtility.WriteLog("Deferred Brokerage Recognition Posting for client " + ClientConfig.ClientCode);
                        }
                        catch (Exception ex)
                        {
                            ServiceUtility.WriteLog("Error in Deferred Brokerage Recognition Posting for client " + ClientConfig.ClientCode + ":" + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        ServiceUtility.WriteLog("Error for Client " + ClientConfig.ClientCode + ":" + ex.Message);
                        EventLogs.Publish(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                        this.timer.Start();
                        //EventLogs.WriteLogInFile(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                    }
                }
                this.timer.Start();
            }
            catch (Exception ex)
            {
                ServiceUtility.WriteLog(ex.Message);
                EventLogs.Publish(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                this.timer.Start();
            }
            //ServiceUtility.WriteLog("End of Processing of services at " + DateTime.Now.Ticks.ToString());
        }

        protected override void OnPause()
        {
            this.timer.Stop();
        }

        protected override void OnContinue()
        {
            this.timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        private void LoadServiceConfig()
        {
            if (ServiceConfig != null)
                ServiceConfig = null;
            ServiceConfig = new XmlDocument();
            ServiceConfig.Load(AppDomain.CurrentDomain.BaseDirectory + "/Service.config");

        }

        private List<ConfigurationSettingReader> InitializeClientConfig()
        {
            ServiceUtility.WriteLog("Initializing Client Configurations.");
            ClientConfigReaders = null;
            ClientConfigReaders = new List<ConfigurationSettingReader>();
            if (ServiceConfig == null) LoadServiceConfig();
            if (ServiceConfig != null)
            {
                XmlNodeList ClientsConfig = ServiceConfig.SelectNodes("eProStarService/Client");
                foreach (XmlNode client in ClientsConfig)
                {
                    ConfigurationSettingReader ConfigReader = new ConfigurationSettingReader(client);
                    ClientConfigReaders.Add(ConfigReader);
                }
            }
            ServiceUtility.WriteLog("Client Configurations intialized.");
            return ClientConfigReaders;
        }
    }
}
