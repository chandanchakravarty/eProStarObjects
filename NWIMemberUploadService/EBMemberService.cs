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

namespace MemberUploadService
{
    public partial class MemberUploadSerivce : ServiceBase
    {
        private System.Timers.Timer timer = null;

        public MemberUploadSerivce()
        {
            WriteLog("Constructor");
            InitializeComponent();
            ConfigurationSettingReader csr = new ConfigurationSettingReader();
            int interval = 1;
            string strLookUpInterval = "";
            strLookUpInterval = ConfigurationSettingReader.Interval.ToString();
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
            WriteLog("OnStartUp");
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }

        protected override void OnStop()
        {
            WriteLog("OnStop");
            timer.AutoReset = false;
            timer.Enabled = false;
        }

        private void WriteLog(string text)
        {
            try
            {
                //string DirectoryPath = System.Web.Hosting.HostingEnvironment.MapPath("~") + @"LogFiles";
                //string DirectoryPath = @"D:\EProPlusStar\Application\LogFiles_Lawton_Service";
                string DirectoryPath = ConfigurationSettingReader.LogFilePath;
                if (Directory.Exists(DirectoryPath) == false)
                {
                    Directory.CreateDirectory(DirectoryPath);
                }
                string path = DirectoryPath +@"\Log_WinService.txt";
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine(DateTime.Now.ToString() + " : " + text + "\n");
                sw.Close();
            }
            catch (Exception err)
            {
                //throw err;
            }
        }
        private void tmrFileLookUp_Tick(object sender, ElapsedEventArgs e)
        {
            //WriteLog("Tick1");
            try
            {
                this.timer.Stop();
                //WriteLog("Tick2");
                
                BatchProcess bObj = new BatchProcess();
                bObj.beginProcess();
                WriteLog("Batch Process service started");

                BatchProcessRawClaim objBatchProcessRawClaim = new BatchProcessRawClaim();
                objBatchProcessRawClaim.BeginProcess();
                WriteLog("Batch Process Raw Claim service started");

                BatchProcessReimbursementClaim objBatchProcessReimbursementClaim = new BatchProcessReimbursementClaim();
                objBatchProcessReimbursementClaim.beginProcess();
                WriteLog("Batch Process Reimbursement Claim service started");

                BatchProcessNonEBClaim objBatchProcessNonEBClaim = new BatchProcessNonEBClaim();
                objBatchProcessNonEBClaim.beginProcess();
                WriteLog("Batch Process Non EB Claim service started");

                BatchProcessVessel objVessel = new BatchProcessVessel();
                objVessel.beginProcess();
                WriteLog("Batch Process Vessel Upload service started");

                this.timer.Start();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
                EventLogs.Publish(ex.Message, System.Diagnostics.EventLogEntryType.Information);
                this.timer.Start();
                //EventLogs.WriteLogInFile(ex.Message, System.Diagnostics.EventLogEntryType.Information);
            }
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
    }
}
