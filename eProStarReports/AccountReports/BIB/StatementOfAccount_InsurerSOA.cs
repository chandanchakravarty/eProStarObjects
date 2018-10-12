namespace eProStarReports.AccountReports.BIB
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using System.Collections;
    using System.Linq;

    /// <summary>
    /// Summary description for StatementofAccount.
    /// </summary>
   internal partial class StatementOfAccount_InsurerSOA : Telerik.Reporting.Report
    {
        public StatementOfAccount_InsurerSOA()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public StatementOfAccount_InsurerSOA(DataSet ds)
        {
            
            InitializeComponent();
            table1.DataSource = ds.Tables[0];   
          //  textBox30.Value = "For the Month of " + ;
            //table3.DataSource = result;

            if (ds.Tables[1].Rows.Count > 0)
            {
                //txtCompanyName.Value = ds.Tables[1].Rows[0]["CompanyName"].ToString();
                //txtCompanyName1.Value = ds.Tables[1].Rows[0]["CompanyName"].ToString();
                //txtCompanyName2.Value = ds.Tables[1].Rows[0]["CompanyName"].ToString();
                //txtCompanyEmail.Value = ds.Tables[1].Rows[0]["CompanyEmail"].ToString();
                //txtBankAccNo.Value = ds.Tables[1].Rows[0]["BankAccNo"].ToString();
                //txtBankName.Value = ds.Tables[1].Rows[0]["BankName"].ToString();
                //txtBankAdd1.Value = ds.Tables[1].Rows[0]["BankAdd1"].ToString();
                //txtBankAdd2.Value = ds.Tables[1].Rows[0]["BankAdd2"].ToString();
                //txtBankAdd3.Value = ds.Tables[1].Rows[0]["BankAdd3"].ToString();
                //txtBankBranch.Value = ds.Tables[1].Rows[0]["BranchName"].ToString();
                //txtBankSwiftCode.Value = ds.Tables[1].Rows[0]["SwiftCode"].ToString();
                //txtCompany.Value = ds.Tables[1].Rows[0]["Company"].ToString();
                //txtRegistration.Value = ds.Tables[1].Rows[0]["RegistrationNo"].ToString();

                txtCompanyNameFooter.Value = ds.Tables[1].Rows[0]["CompanyName"].ToString();
                txtCompanyAddressFooter.Value = ds.Tables[1].Rows[0]["CompanyAddress"].ToString();
            }
        }

        public static string ConvertIntoNumeric(decimal number)
        {
            string str;
            if (Convert.ToDecimal(number) < 0)
            {
                str = Convert.ToDecimal(-1 * number).ToString("#,##0.00");
                str = "(" + str + ")";
            }
            else
            {
                str = Convert.ToDecimal(number).ToString("#,##0.00");
            }
            //String.Format("{0:n}", Convert.ToDouble(number));
            return str;

        }
    }
}