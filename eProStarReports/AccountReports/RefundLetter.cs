namespace eProStarReports.AccountReports
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for RefundLetter.
    /// </summary>
    public partial class RefundLetter : Telerik.Reporting.Report
    {
        public RefundLetter(DataSet dsObj, DataTable details)
        {
            InitializeComponent();
            SetPremDataCredit(dsObj, details);
        }

        private void SetPremDataCredit(DataSet dsObj, DataTable details)
        {
            txtDateValue.Value = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")); //dsObj.Tables[0].Rows[0]["PaymentDate"].ToString();
            txtClientCodeValue.Value = Convert.ToString(details.Rows[0]["ClientCode"]);
            txtClientNameValue.Value = Convert.ToString(details.Rows[0]["ClientName"]);
            txtClientAddressValue.Value = Convert.ToString(details.Rows[0]["ClientAdd1"]);
            if (!string.IsNullOrEmpty(Convert.ToString(details.Rows[0]["ClientAdd2"])))
            {
                txtClientAddressValue2.Visible = true;
                txtClientAddressValue2.Value = Convert.ToString(details.Rows[0]["ClientAdd2"]);
            }
            else
                txtClientAddressValue2.Visible = false;

            if (!string.IsNullOrEmpty(Convert.ToString(details.Rows[0]["ClientAdd3"])))
            {
                txtClientAddressValue3.Visible = true;
                txtClientAddressValue3.Value = Convert.ToString(details.Rows[0]["ClientAdd3"]);
            }
            else
                txtClientAddressValue3.Visible = false;

            if (!string.IsNullOrEmpty(Convert.ToString(details.Rows[0]["ClientAdd4"])))
            {
                txtClientAddressValue4.Visible = true;
                txtClientAddressValue4.Value = Convert.ToString(details.Rows[0]["ClientAdd4"]);
            }
            else
                txtClientAddressValue4.Visible = false;

            txtClientAddressValue5.Value = Convert.ToString(details.Rows[0]["CountryName"]) + " " + Convert.ToString(details.Rows[0]["PostalCode"]);

            txtBankValue.Value = Convert.ToString(details.Rows[0]["BankName"]);
            txtChequeNoValue.Value = Convert.ToString(details.Rows[0]["ChequeNo"]);
            txtAmountValue.Value = Convert.ToString(details.Rows[0]["Amount"]);

            table1.DataSource = dsObj;
        }
    }
}