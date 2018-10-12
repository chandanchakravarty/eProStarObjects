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
    /// Summary description for StandardRatedListingToInsurer.
    /// </summary>
    public partial class StandardRatedListingToInsurer : Telerik.Reporting.Report
    {
        public StandardRatedListingToInsurer()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public StandardRatedListingToInsurer(DataSet DsComp, DataSet DsParam, DataSet DsRated)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            textBox1.Value = DsComp.Tables[0].Rows[0]["CompName"].ToString();
            table1.DataSource = DsRated.Tables[0];
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}