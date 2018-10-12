
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;
using System.Data;
using System.Collections.Generic;
using System.Linq;
namespace FormsNReports
{
    /// <summary>
    /// Summary description for tlrGoodsAndServiceTaxReturn.
    /// </summary>
    public partial class tlrGoodsAndServiceTaxReturn : Telerik.Reporting.Report
    {
        public tlrGoodsAndServiceTaxReturn()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public tlrGoodsAndServiceTaxReturn(DataSet DS)
        {
            String GLBadDebt = "";
            InitializeComponent();
            if (!Object.Equals(DS, null))
            {
                DataRow DTCompany = DS.Tables[0].Rows[0];
                GLBadDebt = DTCompany["GLCodeBadDebt"].ToString();
                txtGSTNo.Value = DTCompany["GSTCode"].ToString();
                txtBusinessName.Value = DTCompany["CompanyName"].ToString();
                string FromDate = string.Format("{0:dd/MM/yyyy}", DTCompany["FromDate"]);
                string Todate = string.Format("{0:dd/MM/yyyy}", DTCompany["ToDate"]); 
                txtTaxableDate.Value = string.Format("{0} To {1}", FromDate, Todate);

                List<GstReport>  lstGstReport=new GstReport().GetGstReport(DS.Tables[1]);
                txtTotStandRate.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstType == "OUT" && P.GstAmount>0).Sum(P => P.GstBaseAmount));
                txtOtherAdjustment.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstType == "OUT" && P.GstAmount > 0).Sum(P => P.GstAmount));

                txtINTotStanRate.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstType == "IN" && P.GstAmount > 0).Sum(P => P.GstBaseAmount));
                txtInTotOtherAdj.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstType == "IN" && P.GstAmount > 0).Sum(P => P.GstAmount));

                if (decimal.Parse(txtOtherAdjustment.Value) > decimal.Parse(txtInTotOtherAdj.Value))
                {
                    txtGSTAmtPayable.Value = MiscUtil.MyFormat(decimal.Parse(txtOtherAdjustment.Value) - decimal.Parse(txtInTotOtherAdj.Value));
                }
                else
                {
                    txtGSTAmtClamable.Value = MiscUtil.MyFormat(decimal.Parse(txtInTotOtherAdj.Value) - decimal.Parse(txtOtherAdjustment.Value));
                }

                txtZeroRatedSup.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "ZRL").Sum(P => P.GstBaseAmount));
                txtTotExpSuplies.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "ZRE").Sum(P => P.GstBaseAmount));
                txtTotExeSupplies.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "ES" || P.GstCode == "ES43").Sum(P => P.GstBaseAmount));

                txtTotSupGSTRel.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "RS").Sum(P => P.GstBaseAmount));
                txtTotTradScheme.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "IM").Sum(P => P.GstBaseAmount));

                txtTotItem14.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "IM").Sum(P => P.GstAmount));
                txttotGoodsAcq.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GstCode == "TX" || P.GstCode == "EP").Sum(P => P.GstBaseAmount));

                txtTotRecIncTax.Value = MiscUtil.MyFormat(lstGstReport.FindAll(P => P.GLCode == GLBadDebt && P.GstType=="IN").Sum(P => P.GstAmount));

            }
 

        }

       
    }
}