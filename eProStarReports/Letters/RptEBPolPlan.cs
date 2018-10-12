namespace eProStarReports.Letters
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    using BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for RptEBPolPlan.
    /// </summary>
   internal partial class RptEBPolPlan : Telerik.Reporting.Report
    {
        public RptEBPolPlan(DataSet DsPlan, List<clsEBPlan> objPlan)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            txtClientinfo.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["ClientInfo"].ToString();
            txtCovernote.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["CoverNoteNo"].ToString();
            txtPOI.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["POI"].ToString();
            txtClass.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["Class"].ToString();
            txtBS.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["BenefitScheduleDesc"].ToString();
            txtCurrency.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["EBPolicyCurrency"].ToString();
            txtUW.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["UWInfo"].ToString();
            txtPolicyNo.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["PolicyNo"].ToString();
            txtMemberinfo.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["MemberInfo"].ToString();
            txtType.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["MemberType"].ToString();
            txtPassport.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["PassportNo"].ToString();
            txtRelationship.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["RelationShip"].ToString();
            if (DsPlan.Tables["PlanDetails"] != null)
            {
                if (DsPlan.Tables["PlanDetails"].Rows.Count > 0)
                {
                    txtPlan.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["PlanType"].ToString();
                    //txtPlanLimit.Value = "=fields." + DsPlan.Tables["PlanDetails"].Columns[4].ToString();
                    tblPlanDetail.DataSource = objPlan;
                }
                else
                {
                    txtPlan.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["PlanType"].ToString();
                }
            }
            else
            {
                txtPlan.Value = DsPlan.Tables["PolicyDetails"].Rows[0]["PlanType"].ToString();
            }
            
        }
    }
}