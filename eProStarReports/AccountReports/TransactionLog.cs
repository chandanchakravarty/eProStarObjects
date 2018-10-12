namespace eProStarReports.AccountReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using DataAccessLayer;
    using System.Data.SqlClient;
    using DataAccessLayer;
    using BusinessObjectLayer.BrokingModule.BrokingSystem;
    using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
    /// <summary>
    /// Summary description for TransactionLog.
    /// </summary>
   internal partial class TransactionLog : Telerik.Reporting.Report
   {
       DatabaseInteraction dataAccess = null;
       string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];
      
       DataSet DsCompDtl = null;
       DataSet DsParamD = null;
       DataSet DsreportDetails = null;
        public TransactionLog()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

      
        public TransactionLog(string Param1,string Param2,string Param3,string Param8,string Param4,string Param5,string Param6,string Param7,string strblank,string str,string DParam1, string DParam2,string DParam3,string DParam4,string DParam5)
        {
            InitializeComponent();
            DsCompDtl = GetCompanyDetails();
            DsreportDetails = GetGenericSearchDataForTranList( Param1, Param2, Param3, Param8, Param4, Param5, Param6, Param7, strblank, str);
            DsParamD = Get_OtherGenericSearchDataForTranList(DParam1,DParam2,DParam3,DParam4,DParam5);
            table1.DataSource = DsParamD.Tables[0];
            textBox1.Value = DsCompDtl.Tables[0].Rows[0]["CompName"].ToString();
            table2.DataSource = DsreportDetails.Tables[0];
        }

       private DataSet  GetGenericSearchDataForTranList( string Param1,string Param2,string Param3,string Param8,string Param4,string Param5,string Param6,string Param7,string strblank,string str)
        {
           
            dataAccess = new DatabaseInteraction(connectionstring);
            return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_GetGenericSearchDataForTranList  '" + Param1 + "','" + Param2 + "','" + Param3 + "','" + Param8 + "','" + Param4 + "','" + Param5 + "','" + Param6 + "','" + Param7 + "','" + strblank + "','" + str + "'");
        }

       private DataSet Get_OtherGenericSearchDataForTranList(string DParam1, string DParam2, string DParam3, string DParam4, string DParam5)
       {

           dataAccess = new DatabaseInteraction(connectionstring);
           return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_ReportParameters  '" + DParam1 + "','" + DParam2 + "','" + DParam3 + "','" + DParam4 + "','" + DParam5 + "'");
          
       }

       private DataSet GetCompanyDetails()
       {

           dataAccess = new DatabaseInteraction(connectionstring);
           return dataAccess.RunSQLWithDataSet("AC_SQLREPORT_CompanyDetails");
          
    
       }
    }
}