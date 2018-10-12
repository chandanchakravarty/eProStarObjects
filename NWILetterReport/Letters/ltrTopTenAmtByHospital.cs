namespace NWILetterReport.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;


    /// <summary>
    /// Summary description for ltrTopTenAmtByHospital.
    /// </summary>
    public partial class ltrTopTenAmtByHospital : Telerik.Reporting.Report
    {
        public ltrTopTenAmtByHospital(DataSet ds)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            pictureBox1.Value = clsReportUtility.setClientLogo();
            DataTable dt = null;
            DataTable dt2 = null;
            if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                dt = ds.Tables[0];
                dt2 = ds.Tables[1];
                dt.TableName = "ReportByAmtVisits";
                table1.DataSource = dt;
                if (dt.Rows.Count > 0 && dt.Rows[0]["ReportType"].ToString() == "ABH")
                {
                    txtReport.Value = "Report Claim Analysis By Top Ten Amount By Hospital/Clinic";
                    _PieChartAmount.ChartTitle.TextBlock.Text = "Top Ten Amount By Hospital/Clinic";
                    clsReportUtility.GeneratePieChart(dt2, _PieChartAmount, "A_Percentage", "Hospital");                    
                }
                else if (dt.Rows.Count > 0 && dt.Rows[0]["ReportType"].ToString() == "VBH")
                {
                    txtReport.Value = "Report Claim Analysis By Top Ten Visits By Hospital/Clinic";
                    _PieChartAmount.ChartTitle.TextBlock.Text = "Top Ten Visits By Hospital/Clinic";
                    clsReportUtility.GeneratePieChart(dt2, _PieChartAmount, "V_Percentage", "Hospital");
                }
                else if (dt.Rows.Count > 0 && dt.Rows[0]["ReportType"].ToString() == "ABD")
                {
                    txtReport.Value = "Report Claim Analysis By Top Ten Amount By Disease";
                    _PieChartAmount.ChartTitle.TextBlock.Text = "Top Ten Amount By Disease";
                    clsReportUtility.GeneratePieChart(dt2, _PieChartAmount, "A_Percentage", "DISEASE");
                }
                else if (dt.Rows.Count > 0 && dt.Rows[0]["ReportType"].ToString() == "VBD")
                {
                    txtReport.Value = "Report Claim Analysis By Top Ten Visits By Disease";
                    _PieChartAmount.ChartTitle.TextBlock.Text = "Top Ten Visits By Disease";
                    clsReportUtility.GeneratePieChart(dt2, _PieChartAmount, "V_Percentage", "DISEASE");
                }
                else if (dt.Rows.Count > 0 && dt.Rows[0]["ReportType"].ToString() == "ABM")
                {
                    txtReport.Value = "Report Claim Analysis By Top Ten Amount By Member";
                    _PieChartAmount.ChartTitle.TextBlock.Text = "Top Ten Amount By Member";
                    clsReportUtility.GeneratePieChart(dt2, _PieChartAmount, "A_Percentage", "Name");
                }
                else if (dt.Rows.Count > 0 && dt.Rows[0]["ReportType"].ToString() == "VBM")
                {
                    txtReport.Value = "Report Claim Analysis By Top Ten Visits By Member";
                    _PieChartAmount.ChartTitle.TextBlock.Text = "Top Ten Visits By Member";
                    clsReportUtility.GeneratePieChart(dt2, _PieChartAmount, "V_Percentage", "Name");
                }
                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HOSPITAL")
                {
                    txtSortBy.Value = "Hospital / Clinic Name";
                    txtSortValue.Value = "=HOSPITAL";
                }
                else if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "DISEASE")
                {
                    txtSortBy.Value = "Disease";
                    txtSortValue.Value = "=DISEASE";
                }
                else if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "Name")
                {
                    txtSortBy.Value = "Member";
                    txtSortValue.Value = "=Name";
                }

            }
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void _PieChart_NeedDataSource(object sender, EventArgs e)
        {

        }
    }
}