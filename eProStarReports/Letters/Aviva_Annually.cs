namespace eProStarReports.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for Aviva_Annually.
    /// </summary>
   internal partial class Aviva_Annually : Telerik.Reporting.Report
    {
        public Aviva_Annually(DataSet ds)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //

            // TODO: Add any constructor code after InitializeComponent call
            //
             DataTable dt = null;
             if ((ds != null) && (ds.Tables.Count > 0))
             {
                 dt = ds.Tables[0];
                 tblIhRating.DataSource = dt;
                 if (ds.Tables.Count >= 1 && ds.Tables[1].Rows.Count > 0)
                 {
                     txtContact1.Value = ds.Tables[1].Rows[0]["Name"].ToString();
                     txtTel1.Value = ds.Tables[1].Rows[0]["TelNo"].ToString();
                     txtEmail1.Value = ds.Tables[1].Rows[0]["Email"].ToString();
                     txtGeo1.Value = ds.Tables[1].Rows[0]["area"].ToString();
                     txtProg1.Value = ds.Tables[1].Rows[0]["program"].ToString();
                     txtDeductable1.Value = ds.Tables[1].Rows[0]["Deductible"].ToString();
                     txtComm1.Value = ds.Tables[1].Rows[0]["Commencement"].ToString();
                     if (ds.Tables[1].Rows[0]["NoOfInstallments"].ToString() == "0")
                     {
                         txtPayment1.Value = "Annually";
                     }
                     else if (ds.Tables[1].Rows[0]["NoOfInstallments"].ToString() == "2")
                     {
                         txtPayment1.Value = "Half Yearly";
                     }
                     else if (ds.Tables[1].Rows[0]["NoOfInstallments"].ToString() == "4")
                     {
                         txtPayment1.Value = "Quaterly";
                     }
                     else
                     {
                         txtPayment1.Value = "Others";
                     }
                 }
                 if (ds.Tables[ds.Tables.Count - 1].Rows.Count > 0)
                 {
                     if (ds.Tables[ds.Tables.Count - 1].Rows[0]["IsLogo"].ToString().Trim().ToUpper() == "NO")
                     {
                         picHeader.Visible = false;
                         txtAddreass1.Visible = false;
                         txtAddress2.Visible = false;
                         //pictureBox1.Visible = false;
                         
                     }
                 }
             }
        }
    }
}