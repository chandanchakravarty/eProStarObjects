namespace eProStarReports.AccountReports
{
    using System;
    using System.Data;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using DataAccessLayer;
    using BusinessObjectLayer.BrokingModule.BrokingSystem;
    using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
    /// <summary>
    /// <summary>
    /// Summary description for GSTInputOutputSummaryReport.
    /// </summary>
    public partial class GSTInputOutputSummaryReport : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];

        DataSet DsCompDtl = null;
        DataSet DsGSTDeatail = null;
        DataSet DsreportDetails = null;
        Double GSTTotalAmt = 0.0;
        Double GSTTotalBaseAmt = 0.0, TotalOutBasedAmt=0.0,TotalInBaseAmt=0.0;
        public GSTInputOutputSummaryReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public GSTInputOutputSummaryReport(string Param1, string Param2, string Param3, string DParam1, string par1, string Param5, string Param6, string Param7)
        {
            InitializeComponent();
            DsCompDtl = GetCompanyDetails();

            textBox1.Value = DsCompDtl.Tables[0].Rows[0]["CompName"].ToString();

            textBox2.Value = DParam1;
            DsGSTDeatail = GetGSTBasicDetails(Param1, Param2, Param3, Param5, Param6, Param7);

            table3.DataSource = DsGSTDeatail.Tables[0];

         
            //textBox4.Value = DsGSTDeatail.Tables[0].Rows[0]["GSTNature"].ToString();
            //textBox3.Value = DsGSTDeatail.Tables[0].Rows[0]["GstNatureSeries"].ToString();
            //textBox13.Value = DsGSTDeatail.Tables[0].Rows[0]["GLCode"].ToString();
            //textBox14.Value = DsGSTDeatail.Tables[0].Rows[0]["GSTTypeName"].ToString();
            //textBox26.Value = DsGSTDeatail.Tables[0].Rows[0]["GSTAmount"].ToString();
            //textBox21.Value = DsGSTDeatail.Tables[0].Rows[0]["GSTBaseAmount"].ToString();

            //for (int i = 0; i < DsGSTDeatail.Tables[0].Rows.Count; i++)
            //{
            //    try
            //    {
            //        GSTTotalAmt = GSTTotalAmt + Convert.ToDouble(DsGSTDeatail.Tables[0].Rows[i]["GSTAmount"].ToString());
            //    }
            //    catch { GSTTotalAmt = GSTTotalAmt; }
            //    try
            //    {
            //        GSTTotalBaseAmt = GSTTotalBaseAmt + Convert.ToDouble(DsGSTDeatail.Tables[0].Rows[i]["GSTBaseAmount"].ToString());

            //    }
            //    catch { GSTTotalBaseAmt = GSTTotalBaseAmt; }
            //}

            DsreportDetails = GetGSTReportSummary(Param1, Param2, Param3, Param5, Param6, Param7);
            //for (int i = 0; i < DsreportDetails.Tables[0].Rows.Count; i++)
            //{
            //    try
            //    {
            //        TotalOutBasedAmt = TotalOutBasedAmt + Convert.ToDouble(DsreportDetails.Tables[0].Rows[i]["OutBaseAmoutStd"].ToString()) + Convert.ToDouble(DsreportDetails.Tables[0].Rows[i]["OutBaseAmoutzero"].ToString()) + Convert.ToDouble(DsreportDetails.Tables[0].Rows[i]["OutBaseAmoutext"].ToString());
            //    }
            //    catch { TotalOutBasedAmt = TotalOutBasedAmt; }
            //    try
            //    {
            //        TotalInBaseAmt = TotalInBaseAmt + Convert.ToDouble(DsreportDetails.Tables[0].Rows[i]["INBaseAmoutStd"].ToString()) + Convert.ToDouble(DsreportDetails.Tables[0].Rows[i]["INBaseAmoutzero"].ToString());
            //    }
            //    catch { TotalInBaseAmt = TotalInBaseAmt; }
            //}

            //textBox27.Value = Convert.ToString(GSTTotalAmt);
            //textBox22.Value = Convert.ToString(GSTTotalBaseAmt);
            //textBox44.Value = Convert.ToString(GSTTotalAmt);
            //textBox45.Value = Convert.ToString(GSTTotalBaseAmt);

            textBox66.Value = DsreportDetails.Tables[0].Rows[0]["OutBaseAmoutStd"].ToString();
            textBox63.Value = DsreportDetails.Tables[0].Rows[0]["OutBaseAmoutzero"].ToString();
            textBox60.Value = DsreportDetails.Tables[0].Rows[0]["OutBaseAmoutext"].ToString();
            textBox69.Value = Convert.ToString(TotalOutBasedAmt);

            textBox86.Value = DsreportDetails.Tables[0].Rows[0]["INBaseAmoutStd"].ToString();
            textBox83.Value = DsreportDetails.Tables[0].Rows[0]["INBaseAmoutzero"].ToString();
            textBox80.Value = Convert.ToString(TotalInBaseAmt);

            textBox95.Value = DsreportDetails.Tables[0].Rows[0]["INBaseAmoutext"].ToString();
            textBox98.Value = DsreportDetails.Tables[0].Rows[0]["OutTotalGstAmt"].ToString();
            textBox92.Value = DsreportDetails.Tables[0].Rows[0]["INTotalGstAmt"].ToString();


            textBox107.Value = DsreportDetails.Tables[0].Rows[0]["INGstAmoutStd"].ToString();
            textBox101.Value = DsreportDetails.Tables[0].Rows[0]["INGstAmoutext"].ToString();
            textBox74.Value = DsreportDetails.Tables[0].Rows[0]["ZeroFileld"].ToString();
            textBox55.Value = DsreportDetails.Tables[0].Rows[0]["ZeroFileld"].ToString();
            textBox110.Value = DsreportDetails.Tables[0].Rows[0]["INTotalGstAmt"].ToString();

            try
            {
                textBox113.Value = Convert.ToString(Convert.ToDouble(textBox98.Value) + Convert.ToDouble(textBox92.Value));
            }
            catch
            {
                textBox113.Value = "0.00";

            }


        
        }

        private DataSet GetGSTReportSummary(string Param1, string Param2, string Dparam1, string Param5, string Param6, string Param7)
        {
           
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_GetDataForGSTInOutReportSummary  '" + Param1 + "','" + Param2 + "', '" + Dparam1 + "','" + Param5 + "','" + Param6 + "','" + Param7 + "'");
        }
        private DataSet GetGSTBasicDetails(string Param1, string Param2, string Dparam1, string Param5, string Param6, string Param7)
        {
           
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_GetDataForGSTInOutReport  '" + Param1 + "','" + Param2 + "', '" + Dparam1  + "','" + Param5 + "','" + Param6 + "','" + Param7 + "'");
        }
     
        
       private DataSet GetCompanyDetails()
       {

           dataAccess = new DatabaseInteraction(connectionstring);
           return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");
          
    
       }
    }
}