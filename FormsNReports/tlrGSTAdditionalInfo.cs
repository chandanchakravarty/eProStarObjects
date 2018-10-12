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
    /// Summary description for tlrGSTAdditionalInfo.
    /// </summary>
    public partial class tlrGSTAdditionalInfo : Telerik.Reporting.Report
    {
        public tlrGSTAdditionalInfo()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

        }
        public tlrGSTAdditionalInfo(DataSet DS)
        {
            String GLBadDebt = "", GLCapitalGoods = "";
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
                txtRLS1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => (P.GstCode == "ZRL")).Sum(P => P.GstBaseAmount));
                txtRLS2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "ZRL").Sum(P => P.GstAmount));

                txtVES1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => (P.GstCode == "ZRE")).Sum(P => P.GstBaseAmount));
                txtVES2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "ZRE").Sum(P => P.GstAmount));

                txtExmS1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => (P.GstCode == "ES")).Sum(P => P.GstBaseAmount));
                txtExmS2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "ES").Sum(P => P.GstAmount));

                txtSGR1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => (P.GstCode == "RS")).Sum(P => P.GstBaseAmount));
                txtSGR2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "RS").Sum(P => P.GstAmount)); 

                txtSGS1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => (P.GstCode == "IM")).Sum(P => P.GstBaseAmount));
                txtSGS2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "IM").Sum(P => P.GstAmount));

                txtVDS1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => (P.GstCode == "GS")).Sum(P => P.GstBaseAmount));
                txtVDS2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "GS").Sum(P => P.GstAmount));

                txtGT1.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "ZRL"
                    || P.GstCode == "ZRE"
                    || P.GstCode == "ES"
                    || P.GstCode == "RS"
                    || P.GstCode == "GS"
                    || P.GstCode == "IM"
                    || P.GstCode == "GS" 
                    ).Sum(P => P.GstBaseAmount));

                txtGT2.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "ZRL"
                   || P.GstCode == "ZRE"
                   || P.GstCode == "ES"
                   || P.GstCode == "RS"
                   || P.GstCode == "GS"
                   || P.GstCode == "IM"
                   || P.GstCode == "GS"
                   ).Sum(P => P.GstAmount));
            }
        }
    }
}