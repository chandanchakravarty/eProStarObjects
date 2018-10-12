namespace NWILetterReport.IRMLetters
{
    using System;
    using System.Collections.Generic;
    using BusinessObjectLayer.RIBrokingModule.Reports;
    using System.Data;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class ltrINVDebitNoteLetter : Telerik.Reporting.Report
    {
        public ltrINVDebitNoteLetter()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ltrINVDebitNoteLetter(List<clsLetter> objLetter, DataSet dsFooterCountry, DataSet dsCurrency, string headerText, string LegislationNote)
        {
            InitializeComponent();
            table1.DataSource = objLetter;
            if ((dsFooterCountry != null) && (dsFooterCountry.Tables.Count > 0) && (dsFooterCountry.Tables[0].Rows.Count > 0))
            {
                if (dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString() != "Default")
                {
                    //txtCountry.Value = dsFooterCountry.Tables[0].Rows[0]["CompanyName"].ToString();
                    txtCountry.Value = "";
                    txtAddress.Value = "";
                    txtMail.Value = "";
                    //txtAddress.Value = dsFooterCountry.Tables[0].Rows[0]["CompContact"].ToString();
                    //txtMail.Value = dsFooterCountry.Tables[0].Rows[0]["CompEmail"].ToString();

                    if (dsFooterCountry.Tables[1].Rows[0]["BranchName"].ToString() != "Default")
                    {
                        Telerik.Reporting.HtmlTextBox TX = new Telerik.Reporting.HtmlTextBox();
                        TX.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.9, Telerik.Reporting.Drawing.UnitType.Inch));
                        TX.Name = "NameDataTextBox";
                        TX.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.2, Telerik.Reporting.Drawing.UnitType.Inch));
                        TX.Style.Font.Bold = true;
                        TX.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
                        TX.Style.Font.Name = "Arial";
                        TX.Value = dsFooterCountry.Tables[1].Rows[0]["BranchName"].ToString();

                        Telerik.Reporting.HtmlTextBox TX1 = new Telerik.Reporting.HtmlTextBox();
                        TX1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.1, Telerik.Reporting.Drawing.UnitType.Inch));
                        TX1.Name = "NameDataTextBox1";
                        TX1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.2, Telerik.Reporting.Drawing.UnitType.Inch));
                        TX1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
                        TX1.Style.Font.Name = "Arial";
                        TX1.Value = dsFooterCountry.Tables[1].Rows[0]["CompContact"].ToString();

                        Telerik.Reporting.HtmlTextBox TX2 = new Telerik.Reporting.HtmlTextBox();
                        TX2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.3, Telerik.Reporting.Drawing.UnitType.Inch));
                        TX2.Name = "NameDataTextBox2";
                        TX2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.2, Telerik.Reporting.Drawing.UnitType.Inch));
                        TX2.Value = dsFooterCountry.Tables[1].Rows[0]["CompEmail"].ToString();
                        TX2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(8, Telerik.Reporting.Drawing.UnitType.Point);
                        TX2.Style.Font.Name = "Arial";

                        Telerik.Reporting.HtmlTextBox TX3 = new Telerik.Reporting.HtmlTextBox();
                        TX3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.5, Telerik.Reporting.Drawing.UnitType.Inch));
                        TX3.Name = "NameDataTextBox3";
                        TX3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.2, Telerik.Reporting.Drawing.UnitType.Inch));
                        TX3.Value = "A member of the Hong Kong Confederation of Insurance Brokers.";
                        this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] { TX, TX1, TX2, TX3 });
                    }
                    else
                    {
                        Telerik.Reporting.HtmlTextBox TX3 = new Telerik.Reporting.HtmlTextBox();
                        TX3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.7, Telerik.Reporting.Drawing.UnitType.Inch));
                        TX3.Name = "NameDataTextBox3";
                        TX3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.2, Telerik.Reporting.Drawing.UnitType.Inch));
                        TX3.Value = "A member of the Hong Kong Confederation of Insurance Brokers.";
                        this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] { TX3 });
                    }
                }
                else if (dsFooterCountry.Tables[1].Rows[0]["BranchName"].ToString() != "Default")
                {
                    //txtCountry.Value = dsFooterCountry.Tables[1].Rows[0]["BranchName"].ToString();
                    //txtAddress.Value = dsFooterCountry.Tables[1].Rows[0]["CompContact"].ToString();
                    //txtMail.Value = dsFooterCountry.Tables[1].Rows[0]["CompEmail"].ToString();

                    txtCountry.Value = "";
                    txtAddress.Value = "";
                    txtMail.Value = "";
                }


                txtYourRef.Value = headerText;
                txtLegislationNote.Value = LegislationNote;
            }
            txtCountry.Value = "";
            txtAddress.Value = "";
            txtMail.Value = "";
        }

        private void table1_ItemDataBinding(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.DetailSection section = (sender as Telerik.Reporting.Processing.DetailSection);
        }

    }
}