namespace eProStarReports.AccountReports.BIB
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for SOA.
    /// </summary>
    public partial class SOA : Telerik.Reporting.Report
    {
        public SOA()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public SOA(DataSet ds, string clinetName)
        {
            InitializeComponent();
           
            if (clinetName == "Howden" || clinetName == "HowdenSG")
            {
                pictureBox1.Visible = false;
                txtCompanyName1.Value = "Insurance Brokers Sdn Bhd";
                txtCompanyName2.Value = "Insurance Brokers Sdn Bhd";
                txtCompanyEmail.Value = "accountsdepartment@.com.my";
                table2.Visible = false;
            }
            else
            {
                pictureBox1.Visible = true;
                txtCompanyName1.Value = "BIB Insurance Brokers Sdn Bhd";
                txtCompanyName2.Value = "BIB Insurance Brokers Sdn Bhd";
                txtCompanyEmail.Value = "accountsdepartment@bib.com.my";
                table2.Visible = true;
            }
            //this.Report.DataSource = ds.Tables[0];
            table1.DataSource = ds.Tables[0];
            //  textBox30.Value = "For the Month of " + ;
            //table3.DataSource = result;
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtClientCode.Value = ds.Tables[0].Rows[0]["ClientId"].ToString();
                txtCurrencyCode.Value = ds.Tables[0].Rows[0]["CurrencyCode"].ToString();
                txtClientName.Value = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtClientAddress.Value = ds.Tables[0].Rows[0]["ClientAdress"].ToString();
                txtForTheMonthOf.Value = "FOR THE MONTH OF " + Convert.ToString(ds.Tables[0].Rows[0]["AccountMonth"]);
                
                
            }
            //For Ageing...
            if (ds.Tables[1].Rows.Count > 0)
            {
                txt0To30days.Value = ConvertIntoNumeric(Convert.ToDecimal(ds.Tables[1].Rows[0]["CurrentMonth"]));
                txt30To60days.Value = ConvertIntoNumeric(Convert.ToDecimal(ds.Tables[1].Rows[0]["Days30To60"]));
                txt60To180days.Value = ConvertIntoNumeric(Convert.ToDecimal(ds.Tables[1].Rows[0]["Days60To180"]));
                txt181to365.Value = ConvertIntoNumeric(Convert.ToDecimal(ds.Tables[1].Rows[0]["Days180To360"]));
                txt365.Value = ConvertIntoNumeric(Convert.ToDecimal(ds.Tables[1].Rows[0]["Days360above"]));
                txtAmountDue.Value = ConvertIntoNumeric(Convert.ToDecimal(ds.Tables[1].Rows[0]["Total"]));
            }
            if (ds.Tables[2].Rows.Count > 0)
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
                txtCompanyName.Value = ds.Tables[2].Rows[0]["CompanyName"].ToString().ToUpper();
                txtCompanyNameFooter.Value = ds.Tables[2].Rows[0]["CompanyName"].ToString().ToUpper() + " (" + ds.Tables[2].Rows[0]["RegistrationNo"].ToString() + ")";
                txtCompanyAddressFooter.Value = ds.Tables[2].Rows[0]["CompanyAddress"].ToString();
                
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