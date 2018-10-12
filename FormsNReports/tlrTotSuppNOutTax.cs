namespace FormsNReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using System.Collections.Generic;
    using System.Linq;
    /// <summary>
    /// Summary description for tlrTotSuppNOutTax.
    /// </summary>
    public partial class tlrTotSuppNOutTax : Telerik.Reporting.Report
    {
        public tlrTotSuppNOutTax()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }


        public tlrTotSuppNOutTax(DataSet DS)
        {
            String GLBadDebt = "",GLCapitalGoods="";
            InitializeComponent();
            if (!Object.Equals(DS, null))
            {
                DataRow DTCompany = DS.Tables[0].Rows[0];

                GLBadDebt = DTCompany["GLCodeBadDebt"].ToString();
                GLCapitalGoods = DTCompany["CapitalGoods"].ToString();

                string FromDate = string.Format("{0:dd/MM/yyyy}", DTCompany["FromDate"]);
                string Todate = string.Format("{0:dd/MM/yyyy}", DTCompany["ToDate"]);
                txtTaxPeriod.Value = string.Format(" for Taxable Period {0} To {1}", FromDate, Todate);

                List<GstReport> lstGstReport = new GstReport().GetGstReport(DS.Tables[1]);
                txtSRNS1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => (P.GstCode == "SR" ) ).Sum(P => P.GstBaseAmount));
                txtSRNS2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "SR").Sum(P => P.GstAmount));

                //txtSRDBA1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "DS" && P.GLCode == GLCapitalGoods).Sum(P => P.GstBaseAmount));
                //txtSRDBA2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "DS" && P.GLCode == GLCapitalGoods).Sum(P => P.GstAmount));

                //txtSRAUP1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "DS" && P.GLCode != GLCapitalGoods).Sum(P => P.GstBaseAmount));
                //txtSRAUP2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "DS" && P.GLCode != GLCapitalGoods).Sum(P => P.GstAmount));

                txtSRDBA1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "DS" && P.GLCode == GLCapitalGoods).Sum(P => P.GstBaseAmount));
                txtSRDBA2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "DS" && P.GLCode == GLCapitalGoods).Sum(P => P.GstAmount));

                txtSRAUP1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "DS" && P.GLCode != GLCapitalGoods).Sum(P => P.GstBaseAmount));
                txtSRAUP2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "DS" && P.GLCode != GLCapitalGoods).Sum(P => P.GstAmount));


                txtST1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "SR" || P.GstCode == "DS").Sum(P => P.GstBaseAmount));
                txtST2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "SR" || P.GstCode == "DS").Sum(P => P.GstAmount));
 


                txtBDR1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJS" && P.AdjType == "BDR").Sum(P => P.GstBaseAmount));
                txtBDR2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJS" && P.AdjType == "BDR").Sum(P => P.GstAmount));

                txtCNDN1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJS" && P.AdjType == "CNDN").Sum(P => P.GstBaseAmount));
                txtCNDN2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJS" && P.AdjType == "CNDN").Sum(P => P.GstAmount));

                txtCGA1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJS" && P.AdjType == "CGA").Sum(P => P.GstBaseAmount));
                txtCGA2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJS" && P.AdjType == "CGA").Sum(P => P.GstAmount));

                txtAAd1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJS" && P.AdjType == "AAD").Sum(P => P.GstBaseAmount));
                txtAAd2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJS" && P.AdjType == "AAD").Sum(P => P.GstAmount));

                txtOAd1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJS" && P.AdjType == "OAD").Sum(P => P.GstBaseAmount));
                txtOAd2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJS" && P.AdjType == "OAD").Sum(P => P.GstAmount));

                txtAST1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJS" && (P.AdjType == "BDR"
                    ||P.AdjType == "CNDN"||P.AdjType == "CGA"||P.AdjType == "AAD"||P.AdjType == "OAD")).Sum(P => P.GstBaseAmount));
                txtAST2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJS" && (P.AdjType == "BDR"
                    || P.AdjType == "CNDN" || P.AdjType == "CGA" || P.AdjType == "AAD" || P.AdjType == "OAD")).Sum(P => P.GstAmount));

                txtGT1.Value = MiscUtil.MyFormat(decimal.Parse(txtST1.Value) + decimal.Parse(txtAST1.Value));
                txtGT2.Value = MiscUtil.MyFormat(decimal.Parse(txtST2.Value) + decimal.Parse(txtAST2.Value));               

            }
         }

        
    }
}