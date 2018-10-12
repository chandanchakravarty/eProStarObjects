namespace FormsNReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;

    /// <summary>
    /// Summary description for tlrGSTSummaryTotAcqInTax.
    /// </summary>
    public partial class tlrGSTSummaryTotAcqInTax : Telerik.Reporting.Report
    {
        public tlrGSTSummaryTotAcqInTax()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public tlrGSTSummaryTotAcqInTax(DataSet DS)
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
                txtNPSRS1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => (P.GstCode == "TX" || P.GstCode == "BL") && P.GLCode != GLCapitalGoods).Sum(P => P.GstBaseAmount));
                txtNPSRS2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "TX").Sum(P => P.GstAmount));
                txtNPSRS3.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "BL").Sum(P => P.GstAmount));

                txtNPMES1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "EP").Sum(P => P.GstBaseAmount));
                //txtNPSRS2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "EP").Sum(P => P.GstAmount));                
                txtNPMES3.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "EP").Sum(P => P.GstAmount));

                txtNPIES1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "TX-E43" || P.GstCode == "TX-N43").Sum(P => P.GstBaseAmount));
                txtNPIES2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "TX-E43").Sum(P => P.GstAmount));
                txtNPIES3.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "TX-N43").Sum(P => P.GstAmount));

                txtCGSRS1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "TX" && P.GLCode == GLCapitalGoods).Sum(P => P.GstBaseAmount));
                txtCGSRS2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "TX" && P.GLCode == GLCapitalGoods).Sum(P => P.GstAmount));
                //txtNPIES3.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "TX-N43").Sum(P => P.GstAmount));

                txtCGMES1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "EP").Sum(P => P.GstBaseAmount));
                //txtNPSRS2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "EP").Sum(P => P.GstAmount));                
                txtCGMES3.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "EP").Sum(P => P.GstAmount));

                txtGI1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "IS" || P.GstCode == "IM").Sum(P => P.GstBaseAmount));
                txtGI2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "IS").Sum(P => P.GstAmount));
                txtGI3.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "IM").Sum(P => P.GstAmount));

                txtST1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "TX"
                    || P.GstCode == "BL"
                    || P.GstCode == "EP"
                    || P.GstCode == "TX-E43"
                    || P.GstCode == "TX-N43"
                    || P.GstCode == "IS"
                    || P.GstCode == "IM").Sum(P => P.GstBaseAmount));
                txtST2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "TX"
                     || P.GstCode == "TX-E43" 
                 || P.GstCode == "IS").Sum(P => P.GstAmount));

                txtST3.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "BL"
                      || P.GstCode == "EP"
                      || P.GstCode == "TX-N43"
                     || P.GstCode == "IM").Sum(P => P.GstAmount));

                txtBDR1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJP" && P.AdjType == "BDR").Sum(P => P.GstBaseAmount));
                txtBDR2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJP" && P.AdjType == "BDR").Sum(P => P.GstAmount));

                txtCNDN1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJP" && P.AdjType == "CNDN").Sum(P => P.GstBaseAmount));
                txtCNDN2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJP" && P.AdjType == "CNDN").Sum(P => P.GstAmount));

                txtCGA1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJP" && P.AdjType == "CGA").Sum(P => P.GstBaseAmount));
                txtCGA2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJP" && P.AdjType == "CGA").Sum(P => P.GstAmount));

                txtAAd1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJP" && P.AdjType == "AAD").Sum(P => P.GstBaseAmount));
                txtAAd2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJP" && P.AdjType == "AAD").Sum(P => P.GstAmount));

                txtOAd1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJP" && P.AdjType == "OAD").Sum(P => P.GstBaseAmount));
                txtOAd2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJP" && P.AdjType == "OAD").Sum(P => P.GstAmount)); 

                txtAST1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJP"
                    && P.AdjType !="").Sum(P => P.GstBaseAmount));

                txtAST2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "AJP"
                     && P.AdjType !="").Sum(P => P.GstAmount));
 

                txtGT1.Value = MiscUtil.MyFormat(decimal.Parse(txtST1.Value) + decimal.Parse(txtAST1.Value));
                txtGT2.Value = MiscUtil.MyFormat(decimal.Parse(txtST2.Value) + decimal.Parse(txtAST2.Value));
                txtGT3.Value = MiscUtil.MyFormat(decimal.Parse(txtST3.Value) + decimal.Parse(txtAST3.Value));

            }
        }

        
    }
}