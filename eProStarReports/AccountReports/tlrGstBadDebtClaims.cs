namespace eProStarReports.AccountReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for tlrGstBadDebtClaims.
    /// </summary>
   internal partial class tlrGstBadDebtClaims : Telerik.Reporting.Report
    {
        public tlrGstBadDebtClaims()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public tlrGstBadDebtClaims(DataSet DS)
        {
            String GLBadDebt = "", GLCapitalGoods = "";
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            if (!Object.Equals(DS, null))
            {
                DataRow DTCompany = DS.Tables[0].Rows[0];

                GLBadDebt = DTCompany["GLCodeBadDebt"].ToString();
                GLCapitalGoods = DTCompany["CapitalGoods"].ToString();

                string FromDate = string.Format("{0:dd/MM/yyyy}", DTCompany["FromDate"]);
                string Todate = string.Format("{0:dd/MM/yyyy}", DTCompany["ToDate"]);
                htmlTextBox2.Value = "Adjustment as at: " + Todate;

                table2.DataSource = DS.Tables[3];
            }

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}