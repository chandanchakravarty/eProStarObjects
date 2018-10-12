namespace eProStarReports.AccountReports
{
    using System;
    using System.Data;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using DataAccessLayer;
    using BusinessObjectLayer.BrokingModule.BrokingSystem;
    using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;

    /// <summary>
    /// Summary description for PremiumWarrantyLetter.
    /// </summary>
    public partial class PremiumWarrantyLetter : Telerik.Reporting.Report
    {
        DatabaseInteraction dataAccess = null;
        string connectionstring = System.Configuration.ConfigurationManager.AppSettings["DBConnectionString"];


        DataSet DsEnclosureDeatail = null;
        public PremiumWarrantyLetter()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public PremiumWarrantyLetter(DataSet ds)
        {
            InitializeComponent();
            //DsEnclosureDeatail = GetGetEnclosureLetterDetails(Param1, Param2, Param3, Param4);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count  > 0)
            {
                table2.Visible = true;
                table1.Visible = true;
                textBox6.Value = DateTime.Now.ToString("dd/MM/yyyy");
                table2.DataSource = ds.Tables[0];
            }
            else
            {
                table2.Visible = false;
                table1.Visible = true;
            }
        

        }
        public static string convertIntoNumeric(decimal number)
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

            return str;

        }
    }
}