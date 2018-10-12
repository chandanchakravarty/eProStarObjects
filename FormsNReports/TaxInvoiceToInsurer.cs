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
    /// Summary description for TaxInvoiceToInsurer.
    /// </summary>
    public partial class TaxInvoiceToInsurer : Telerik.Reporting.Report
    {
        public TaxInvoiceToInsurer()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public TaxInvoiceToInsurer(DataTable txInvoice)
        { 
            InitializeComponent();
            table1.DataSource = txInvoice;            
        }
    }
}