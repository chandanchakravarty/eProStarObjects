namespace FormsNReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for BalanceSheet.
    /// </summary>
    public partial class FinancialReport : Telerik.Reporting.Report
    {
        int counter = 0;
        public FinancialReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public FinancialReport(DataSet Ds, string Month, int YYYY, string filepath, string logfilepath)
        {
         
            InitializeComponent();
            ReportUtility objrep = new ReportUtility();
            textBox13.Visible = true;
            textBox9.Visible = true;
            textBox9.Value = "RUN DATE :" + DateTime.Now.ToString("MM/dd/yyyy");
            objrep.LogFile(textBox9.Value, "textBox9.Value +" + textBox9.Value + "", "FinancialReport", "", logfilepath);
            textBox13.Value ="For Financial Month :" + Month + ' ' + YYYY;
            objrep.LogFile(textBox13.Value, "textBox13.Value + " + textBox13.Value + " ", "FinancialReport", "", logfilepath);
            if (Ds.Tables[0].Rows.Count > 0)
            {
               // Image image1 = Image.FromFile(filepath);
               // this.pictureBox1.Value = image1;
                Ds.Tables[0].Rows[0].Delete();
                textBox2.Value = Ds.Tables[1].Rows[0]["CompanyName"].ToString();
                textBox4.Value = Ds.Tables[1].Rows[0]["CompanyAdd1"].ToString();
                textBox6.Value = Ds.Tables[1].Rows[0]["CompanyAdd2"].ToString();
                textBox8.Value = Ds.Tables[1].Rows[0]["CompanyAdd3"].ToString();
                textBox10.Value = Ds.Tables[1].Rows[0]["CompanyAdd4"].ToString();
                textBox1.Value = Ds.Tables[1].Rows[0]["Email"].ToString();
                textBox3.Value = Ds.Tables[1].Rows[0]["RegNo"].ToString();
                textBox5.Value = Ds.Tables[1].Rows[0]["GSTCode"].ToString();
                table2.DataSource = Ds;
            }

           
         
        }

        private void textBox2_ItemDataBinding(object sender, EventArgs e)
        {
            
        }

    }
}