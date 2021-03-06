namespace NWILetterReport.IRMLetters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;
    //using BusinessObjectLayer.BrokingModule.Reports;
    using BusinessObjectLayer.RIBrokingModule.Reports;
    using System.Data;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class ltrCashCallLetter : Telerik.Reporting.Report
    {
        public ltrCashCallLetter()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ltrCashCallLetter(List<clsLetter> objLetter, DataSet dsFooterCountry, DataSet dsCurrency)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            table1.DataSource = objLetter;
            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();
            }

            if (dsCurrency != null && dsCurrency.Tables.Count > 0 && dsCurrency.Tables[0].Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("First", typeof(string));
                dt.Columns.Add("Second", typeof(string));

                for (int k = 0; k < dsCurrency.Tables[0].Rows.Count; k++)
                {
                    dr = dt.NewRow();
                    dr["First"] = "For " + dsCurrency.Tables[0].Rows[k]["CurrencyCode"].ToString() + " Currency";
                    dr["Second"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["First"] = "Correspondent Bank :";
                    dr["Second"] = dsCurrency.Tables[0].Rows[k]["BankName"].ToString();
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["First"] = "Swift code :";
                    dr["Second"] = dsCurrency.Tables[0].Rows[k]["SwiftCode"].ToString();
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["First"] = "In favour of :";
                    dr["Second"] = dsCurrency.Tables[0].Rows[k]["InFavourOf"].ToString();
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["First"] = "Account No. :";
                    dr["Second"] = dsCurrency.Tables[0].Rows[k]["AccountNo"].ToString();
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["First"] = "By order of :";
                    dr["Second"] = dsCurrency.Tables[0].Rows[k]["ByOrderOf"].ToString();
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["First"] = "Message :";
                    dr["Second"] = dsCurrency.Tables[0].Rows[k]["CuuMessage"].ToString();
                    dt.Rows.Add(dr);
                }
                table2.DataSource = dt.DefaultView;
            }
        }

        public List<string> GetOptions()
        {
            List<string> lstOptions = new List<string>();
            lstOptions.Add("Open");
            lstOptions.Add("Closed");
            lstOptions.Add("Outstanding");
            return lstOptions;
        }

        private void table1_ItemDataBinding(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.DetailSection section = (sender as Telerik.Reporting.Processing.DetailSection);
        }
    }
}