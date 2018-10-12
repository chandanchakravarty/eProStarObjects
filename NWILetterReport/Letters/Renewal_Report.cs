namespace NWILetterReport.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for Renewal_Report.
    /// </summary>
    public partial class Renewal_Report : Telerik.Reporting.Report
    {
        public Renewal_Report(DataSet ds)
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
                if (ds.Tables.Count >= 4)
                {
                    dt = ds.Tables[4];
                    tblIhRating.DataSource = dt;
                }
                if (ds.Tables.Count >= 1 && ds.Tables[1].Rows.Count > 0)
                {
                    txtContact1.Value = ds.Tables[1].Rows[0]["Name"].ToString();
                    txtTel1.Value = ds.Tables[1].Rows[0]["TelNo"].ToString();
                    txtEmail1.Value = ds.Tables[1].Rows[0]["Email"].ToString();
                    txtGeo1.Value = ds.Tables[1].Rows[0]["area"].ToString();
                    txtProg1.Value = ds.Tables[1].Rows[0]["program"].ToString();
                    txtDeductable1.Value = ds.Tables[1].Rows[0]["Deductible"].ToString();
                    txtComm1.Value = ds.Tables[1].Rows[0]["Commencement"].ToString();
                    txtExpiry.Value = ds.Tables[1].Rows[0]["Expiry"].ToString();
                    txtGroupScheme.Value = ds.Tables[1].Rows[0]["SchemeName"].ToString();
                    if (ds.Tables[1].Rows[0]["NoOfInstallments"].ToString() == "0")
                    {
                        txtPayment1.Value += "Annually";
                    }
                    else if (ds.Tables[1].Rows[0]["NoOfInstallments"].ToString() == "2")
                    {
                        txtPayment1.Value += "Half Yearly";
                    }
                    else if (ds.Tables[1].Rows[0]["NoOfInstallments"].ToString() == "4")
                    {
                        txtPayment1.Value += "Quaterly";
                    }
                    else
                    {
                        txtPayment1.Value += "Others";
                    }
                }
                if (ds.Tables.Count >= 8 && ds.Tables[8].Rows.Count > 0)
                {
                    txtFooNet.Value = ds.Tables[8].Rows[0]["net"].ToString();
                    txtFooSBT.Value = ds.Tables[8].Rows[0]["Tax"].ToString();
                    txtFooStamp.Value = ds.Tables[8].Rows[0]["stampDuty"].ToString();
                    txtFooTotalP.Value = ds.Tables[8].Rows[0]["total"].ToString();
                }
                

            }
        }
    }
}