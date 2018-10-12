namespace NWILetterReport.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Summary description for Aviva_COI.
    /// </summary>
    public partial class Aviva_COI : Telerik.Reporting.Report
    {
        public Aviva_COI(DataSet ds)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            if ((ds != null) && (ds.Tables.Count > 0))
            {
                tblIhRating.DataSource = ds.Tables[2];
                tblPremium.DataSource = ds.Tables[3];
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtComp.Value = ds.Tables[1].Rows[0]["CompanyName"].ToString();
                    txtscheme.Value = ds.Tables[1].Rows[0]["SchemeName"].ToString();
                    txtGeo.Value = ds.Tables[1].Rows[0]["area"].ToString();
                    txtCover.Value = ds.Tables[1].Rows[0]["BenefitName"].ToString();
                    txtDeduc.Value = ds.Tables[1].Rows[0]["Deductible"].ToString();
                    txtCoin.Value = ""; //ds.Tables[1].Rows[0]["CoInsurance"].ToString();
                    txtPolicy.Value = ds.Tables[1].Rows[0]["policyNo"].ToString();
                    txtComm.Value = ds.Tables[1].Rows[0]["Commencement"].ToString();
                    txtExpiry.Value = ds.Tables[1].Rows[0]["Expiry"].ToString();
                    txtAddress.Value = ds.Tables[1].Rows[0]["Address"].ToString();
                    txtRenewal_Buisiness.Value = "Renewal ( x )   New Business ( " + ds.Tables[1].Rows[0]["BusinessType"].ToString() + " )";
                }
                string OverallBene = "";
                if (ds.Tables.Count >= 8 && ds.Tables[8].Rows.Count > 0)
                {
                    OverallBene = ds.Tables[8].Rows[0]["TotalSumInsured"].ToString();
                }
                DataTable dtBenefitSchdule = ds.Tables[5];
                DataTable dtTemp = GetBenefitSchduleTable(dtBenefitSchdule, OverallBene);
                txtBenefitSchdule.DataSource = dtTemp;

                DataTable dtCondition = ds.Tables[6];
                string strCondition = getConditionAndExclusion(dtCondition);
                txtCondition.Value = strCondition;

                DataTable dtMajorExcl = ds.Tables[7];
                string strExclusion = getConditionAndExclusion(dtMajorExcl); ;
                txtMajorExclusion.Value = strExclusion;
                picHeaderSafety.Value = clsReportUtility.setClientLogo();
                PicHeaderAviva.Value = clsReportUtility.setClientLogo();
                if (ds.Tables[ds.Tables.Count - 1].Rows.Count > 0)
                {
                    if (ds.Tables[ds.Tables.Count - 1].Rows[0]["IsLogo"].ToString().Trim().ToUpper() == "NO")
                    {
                        PicHeaderAviva.Visible = false;
                        picHeaderSafety.Visible = false;
                        txtComp1Add1.Visible = false;
                        txtComp1Add2.Visible = false;
                        txtComp2Add1.Visible = false;
                        txtComp2Add2.Visible = false;
                    }
                }
            }
        }

        private static DataTable GetBenefitSchduleTable(DataTable dtBenefitSchdule, string OverallBenefit)
        {

            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("BenefitLine", typeof(string));
            dtTemp.Columns.Add("PlanValue", typeof(string));
            try
            {
                if (dtBenefitSchdule != null)
                {
                    var v = from m in dtBenefitSchdule.AsEnumerable() group m by m["IHPlanID"] into g select g;
                    foreach (var item in v)
                    {
                        DataTable dtBenefitName = item.CopyToDataTable();
                        if (dtTemp.Rows.Count == 0)
                        {
                            DataRow dHeaderrow = dtTemp.NewRow();
                            dHeaderrow["BenefitLine"] = "Cover Selected : " + dtBenefitName.Rows[0]["BenefitName"].ToString();
                            dHeaderrow["PlanValue"] = "Overall Benefit Maximum THB " + OverallBenefit;
                            dtTemp.Rows.Add(dHeaderrow);
                        }
                        else
                        {
                            DataRow dHeaderrow = dtTemp.NewRow();
                            dHeaderrow["BenefitLine"] = "";
                            dHeaderrow["PlanValue"] = dtBenefitName.Rows[0]["PlanName"].ToString();
                            dtTemp.Rows.Add(dHeaderrow);
                        }

                        var w = from m in dtBenefitName.AsEnumerable() group m by m["BenefitGrouplineId"] into g select g;
                        foreach (var item1 in w)
                        {
                            DataTable dtGroup = item1.CopyToDataTable();
                            for (int i = 0; i < dtGroup.Rows.Count; i++)
                            {
                                if (i == 0)
                                {
                                    DataRow dGrouprow = dtTemp.NewRow();
                                    dGrouprow["BenefitLine"] = dtGroup.Rows[i]["BenefitGroupLineName"].ToString();
                                    dGrouprow["PlanValue"] = "";
                                    dtTemp.Rows.Add(dGrouprow);
                                }
                                DataRow dLinerow = dtTemp.NewRow();
                                dLinerow["BenefitLine"] = dtGroup.Rows[i]["BenefitLineName"].ToString();
                                dLinerow["PlanValue"] = dtGroup.Rows[i]["LimitAmt"].ToString();
                                dtTemp.Rows.Add(dLinerow);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return dtTemp;

        }

        private static string getConditionAndExclusion(DataTable dtCondition)
        {
            string strCondition = "None";
            if (dtCondition != null)
            {
                for (int i = 0; i < dtCondition.Rows.Count; i++)
                {
                    strCondition = i + 1 + "." + dtCondition.Rows[i]["GroupHeader"].ToString() + "  ";

                    strCondition += dtCondition.Rows[i]["MainHeader"].ToString() + "   " + dtCondition.Rows[i]["TitleDescription"].ToString();

                }
            }
            return strCondition;
        }
    }
}