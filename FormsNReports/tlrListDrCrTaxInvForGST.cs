namespace FormsNReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Summary description for tlrListDrCrTaxInvForGST.
    /// </summary>
    public partial class tlrListDrCrTaxInvForGST : Telerik.Reporting.Report
    {
        public tlrListDrCrTaxInvForGST()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }


        public tlrListDrCrTaxInvForGST(DataSet DS)
        {
            String GLBadDebt = "", GLCapitalGoods = "";
            InitializeComponent();
            if (!Object.Equals(DS, null))
            {
                DataRow DTCompany = DS.Tables[0].Rows[0];

                GLBadDebt = DTCompany["GLCodeBadDebt"].ToString();
                GLCapitalGoods = DTCompany["CapitalGoods"].ToString();

                string FromDate = string.Format("{0:dd/MM/yyyy}", DTCompany["FromDate"]);
                string Todate = string.Format("{0:dd/MM/yyyy}", DTCompany["ToDate"]);
                htmlTextBox2.Value = "Adjustment as at: " + Todate;
                table2.DataSource = DS.Tables[2];
                
                //txtTaxPeriod.Value = string.Format(" for Taxable Period {0} To {1}", FromDate, Todate);

                //List<GstReport> lstGstReport = new GstReport().GetGstReport(DS.Tables[1]);
                //txtSRNS1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => (P.GstCode == "SR")).Sum(P => P.GstBaseAmount));
                //txtSRNS2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "SR").Sum(P => P.GstAmount));

                //txtSRDBA1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "DS" && P.GLCode == GLCapitalGoods).Sum(P => P.GstBaseAmount));
                //txtSRDBA2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "DS" && P.GLCode == GLCapitalGoods).Sum(P => P.GstAmount));
            }
        }

    }
}