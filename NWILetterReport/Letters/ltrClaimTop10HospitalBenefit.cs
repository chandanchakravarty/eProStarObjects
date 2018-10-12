namespace NWILetterReport.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using Telerik.Charting;

    /// <summary>
    /// Summary description for ltrClaimTop10HospitalBenefit.
    /// </summary>
    public partial class ltrClaimTop10HospitalBenefit : Telerik.Reporting.Report
    {
        public ltrClaimTop10HospitalBenefit(DataSet ds)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            pictureBox1.Value = clsReportUtility.setClientLogo();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //              
              DataTable dt = null;
              if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
              {
                  dt = ds.Tables[0];
                  tblNormal.DataSource = dt;
                  if (dt.Rows.Count > 0 && dt.Columns[1].ToString() == "HOSPITAL")
                  {
                     // tblNormal.ColumnGroups.RemoveAt(1);
                     // tblNormal.Body.Columns.Remove(tblNormal.Body.Columns[1]);
                      tblNormal.Visible = false;
                      tblMember.Visible = true;
                      tblMember.DataSource = dt;
                      tblMember.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Pixel(0), Telerik.Reporting.Drawing.Unit.Pixel(250));
                      txtReport.Value = "Report Claim Analysis By Top Ten Amount Of Hospital / Clinic All Benefit";
                      txtsortByMember.Value = "Hospital / Clinic Name";
                      txtsortValueMember.Value = "=HOSPITAL";                  
                    
                      //txtSortBy.Value = "Hospital / Clinic Name";
                     // txtSortByThai.Value = "Hospital / Clinic Name";
                      //txtSortValue.Value = "=HOSPITAL";
                     // txtSortValueThai.Value = "=HOSPITAL";
                      _PieChartAmount.ChartTitle.TextBlock.Text = "Claim Cost Amount";
                      _pieChartFrequency.ChartTitle.TextBlock.Text = "Claim Frequency of Visits";
                      clsReportUtility.GeneratePieChart(dt, _PieChartAmount, "A_Percentage", "Hospital");
                      clsReportUtility.GeneratePieChart(dt, _pieChartFrequency, "F_Percentage", "Hospital");
                  }
                  else if (dt.Rows.Count > 0 && dt.Columns[1].ToString() == "DISEASE")
                  {
                      txtReport.Value = "Report Claim Analysis By Top Ten Amount Of Disease All Benefit";
                      txtSortBy.Value = "Disease";
                      txtSortByThai.Value = "Disease Thai";
                      txtSortValue.Value = "=DISEASE";
                      txtSortValueThai.Value = "=DISEASE_THAI";
                      tblNormal.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Pixel(0), Telerik.Reporting.Drawing.Unit.Pixel(250));
                      _PieChartAmount.ChartTitle.TextBlock.Text = "Claim Cost Amount";
                      _pieChartFrequency.ChartTitle.TextBlock.Text = "Claim Frequency of Visits";
                      clsReportUtility.GeneratePieChart(dt, _PieChartAmount, "A_Percentage", "DISEASE");
                      clsReportUtility.GeneratePieChart(dt, _pieChartFrequency, "F_Percentage", "DISEASE");
                  }

                  else if (dt.Rows.Count > 0 && dt.Columns[1].ToString() == "Name")
                  {
                      tblNormal.Visible = false;
                      tblMember.Visible = true;
                      tblMember.DataSource = dt;
                      tblMember.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Pixel(0), Telerik.Reporting.Drawing.Unit.Pixel(250));
                      txtReport.Value = "Report Claim Analysis By Top Ten Amount Of Member All Benefit";
                      txtsortByMember.Value = "Member Name";
                      txtsortValueMember.Value = "=Name";                  
                      _PieChartAmount.ChartTitle.TextBlock.Text = "Claim Cost Amount";
                      _pieChartFrequency.ChartTitle.TextBlock.Text = "Claim Frequency of Visits";
                      clsReportUtility.GeneratePieChart(dt, _PieChartAmount, "A_Percentage", "Name");
                      clsReportUtility.GeneratePieChart(dt, _pieChartFrequency, "F_Percentage", "Name");
                  }
              }
             
        }

       

        private void _PieChart_NeedDataSource(object sender, EventArgs e)
        {
            
        }
    }
}