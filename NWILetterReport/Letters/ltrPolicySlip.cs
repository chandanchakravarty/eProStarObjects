namespace NWILetterReport.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;
    using BusinessObjectLayer.BrokingModule.Reports;
    using System.Data;

    /// <summary>
    /// Summary description for ltrPolicySlip.
    /// </summary>
    public partial class ltrPolicySlip : Telerik.Reporting.Report
    {
        public ltrPolicySlip()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public ltrPolicySlip(List<clsPolicySlip> objLetter)
        {
        
            //objLetter = objLettera;
            //
            // Required for telerik Reporting designer support
            //


            InitializeComponent();
            table1.DataSource = objLetter;
        }
    }
}