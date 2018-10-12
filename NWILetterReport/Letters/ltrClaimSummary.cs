namespace NWILetterReport.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;

    /// <summary>
    /// Summary description for ltrClaimSummary.
    /// </summary>
    public partial class ltrClaimSummary : Telerik.Reporting.Report
    {
        public ltrClaimSummary(DataSet ds)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
           // pictureBox1.Value = Server Server.MapPath("~PurpleBlueGray\images\logo.png");
            textBox1.Value = "Summary Report Claim Analysis By Benefit";
            pictureBox1.Value = clsReportUtility.setClientLogo();
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                //Telerik.Reporting.ObjectDataSource objectDataSource = new Telerik.Reporting.ObjectDataSource();
                //objectDataSource1.DataSource = ds.Tables[0];
                //table1.DataSource = ds.Tables[2];
                tblNormal.DataSource = ds.Tables[0];
                tblPlan.DataSource = ds.Tables[1];
                tblRelation.DataSource = ds.Tables[2];
                //txtCountry.Value = ds.Tables[0].Rows[0]["Company"].ToString();
               // txtPolicy.Value = ds.Tables[0].Rows[0]["PolicyNo"].ToString();
               // txtInsurer.Value = ds.Tables[0].Rows[0]["Insurer"].ToString();
            }
        }

        
    }
}