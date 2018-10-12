namespace eProStarReports.Letters.Acclaim
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;
    /// <summary>
    /// Summary description for ClaimFileReport.
    /// </summary>
    public partial class ClaimFileReport : Telerik.Reporting.Report
    {
        public ClaimFileReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }


        public ClaimFileReport(DataSet dsObj, string strCaseRefNo, string ClaimRefNo, string ClientCode)
        {
            //
            // Required for telerik Reporting designer support
            //

            InitializeComponent();
            txtCurrentDate.Value = DateTime.Now.Date.ToString("dd/MM/yyyy");
            if (dsObj.Tables[0].Rows.Count > 0)
            {

                // }
                txtBrokerSlipNo1.Value = dsObj.Tables[0].Rows[0]["CoverNoteNo"].ToString();
                txtClaimNo1.Value = dsObj.Tables[0].Rows[0]["ClaimNo"].ToString();
                txtInsuredName.Value = dsObj.Tables[0].Rows[0]["ClientName"].ToString();


                txtClass1.Value = dsObj.Tables[0].Rows[0]["MainClassName"].ToString();


                txtInsurerName.Value = dsObj.Tables[0].Rows[0]["UnderwriterName"].ToString().ToUpper();
                //txtComName.Value = dsObj.Tables[0].Rows[0]["TopCompanyName"].ToString().ToUpper();

                txtPolicyNo.Value = dsObj.Tables[0].Rows[0]["PolicyNo"].ToString();

                txtPOIDate.Value = dsObj.Tables[0].Rows[0]["POI"].ToString();

                txtInsurerClaimNo.Value = dsObj.Tables[0].Rows[0]["UWClaimNo"].ToString();
                txtDateofLoss.Value = dsObj.Tables[0].Rows[0]["AccidentDate"].ToString();
                txtVehicleNo.Value = dsObj.Tables[0].Rows[0]["VehicleNo"].ToString();
                txtVesselName.Value = dsObj.Tables[0].Rows[0]["VehicleVesselName"].ToString();
                txtClaimant.Value = dsObj.Tables[0].Rows[0]["ClaimaintName"].ToString();


                txtDescLoss.Value = dsObj.Tables[0].Rows[0]["LossDetails"].ToString();

                txtReserve.Value = "SGD " + dsObj.Tables[0].Rows[0]["ReserveAmount"].ToString();

                txtAmountPaid.Value = "SGD " + dsObj.Tables[0].Rows[0]["TotalPaid"].ToString();

                txtOSAmount.Value = "SGD " + dsObj.Tables[0].Rows[0]["OutstandingAmount"].ToString();

                txtDiaryDesc.Value = dsObj.Tables[0].Rows[0]["FollowUpReason"].ToString();
                ttxtDiaryDate.Value = dsObj.Tables[0].Rows[0]["FollowUpDate"].ToString();

                txtHospitalName.Value = dsObj.Tables[0].Rows[0]["HospitalClinicName"].ToString();

                txtDateofAdmission.Value = dsObj.Tables[0].Rows[0]["ReportDate"].ToString();

                txtDateofDischarge.Value = dsObj.Tables[0].Rows[0]["DateOfDischarge"].ToString();

                txtSurveyor.Value = dsObj.Tables[0].Rows[0]["SurveyorCode"].ToString();

                txtSurveyorName.Value = dsObj.Tables[0].Rows[0]["SurveyorName"].ToString();

                txtClaimStatus.Value = dsObj.Tables[0].Rows[0]["Claim_Status"].ToString();

                txtContactNo.Value = dsObj.Tables[0].Rows[0]["ContactNo"].ToString();

                txtRemarks.Value = dsObj.Tables[0].Rows[0]["Note"].ToString();

               
                FeeSettlement(dsObj);

                //For Footer Details
                txtQSNNo.Value = dsObj.Tables[0].Rows[0]["ClaimNo"].ToString();
                txtFooterDate.Value = DateTime.Now.Date.ToString("dd/MM/yyyy");

            }
        }
        public void FeeSettlement(DataSet dsObj)
        {
            table1.DataSource = dsObj.Tables[1];
        }

        //public void FeeSettlement(DataSet dsObj, string strCaseRefNo, string ClaimRefNo)
        //{
        //    //int PanelXLocation;
        //    int PanelYLocation = 6;

        //    //create an instance of the report
        //    ClaimFileReport report = new ClaimFileReport();

        //    if (dsObj.Tables[1].Rows.Count > 0)
        //    {

        //        for (int i = 0; i < dsObj.Tables[1].Rows.Count; i++)
        //        {

        //            Telerik.Reporting.Panel panel_i = new Telerik.Reporting.Panel();

        //            //panel1
        //            panel_i.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(PanelYLocation, Telerik.Reporting.Drawing.UnitType.Cm));
        //            panel_i.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(6, Telerik.Reporting.Drawing.UnitType.Cm));
        //            //panel1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;


        //            Telerik.Reporting.TextBox txtClaimSettlementHeader_i = new Telerik.Reporting.TextBox();
        //            Telerik.Reporting.TextBox txtSPaymentDate_i = new Telerik.Reporting.TextBox();
        //            Telerik.Reporting.TextBox txtSCurrency_i = new Telerik.Reporting.TextBox();
        //            Telerik.Reporting.TextBox txtSPaymentAmount_i = new Telerik.Reporting.TextBox();
        //            Telerik.Reporting.TextBox txtSChequeNo_i = new Telerik.Reporting.TextBox();
        //            Telerik.Reporting.TextBox txtSBankName_i = new Telerik.Reporting.TextBox();
        //            Telerik.Reporting.TextBox txtSPaymentType_i = new Telerik.Reporting.TextBox();
        //            Telerik.Reporting.TextBox txtSPaymentDesc_i = new Telerik.Reporting.TextBox();
        //            Telerik.Reporting.TextBox txtSPaymentDesc0_i = new Telerik.Reporting.TextBox();
        //            Telerik.Reporting.TextBox txtSPaymentDesc1_i = new Telerik.Reporting.TextBox();
        //            Telerik.Reporting.TextBox txtSPaymentDesc2_i = new Telerik.Reporting.TextBox();
        //            Telerik.Reporting.TextBox txtSPaymentDesc3_i = new Telerik.Reporting.TextBox();
        //            Telerik.Reporting.TextBox txtSPaymentDesc4_i = new Telerik.Reporting.TextBox();

        //            //-----1-//

        //            txtClaimSettlementHeader_i.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtClaimSettlementHeader_i.Name = "ClaimSettlementHeader";
        //            txtClaimSettlementHeader_i.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(10.0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.6, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtClaimSettlementHeader_i.Value = "Claim Settlement Detail : ";

        //            txtSPaymentDate_i.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtSPaymentDate_i.Name = "PaymentDate";
        //            txtSPaymentDate_i.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(10.0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.6, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtSPaymentDate_i.Value = (i + 1) + " Date         : " + dsObj.Tables[1].Rows[i]["PaymentDate"].ToString();


        //            //-----2-//
        //            txtSCurrency_i.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtSCurrency_i.Name = "Currency";
        //            txtSCurrency_i.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(10.0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.6, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtSCurrency_i.Value = "Currency         : " + dsObj.Tables[1].Rows[i]["Currency"].ToString();


        //            //-----3-//
        //            txtSPaymentAmount_i.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(3, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtSPaymentAmount_i.Name = "PaymentAmount";
        //            txtSPaymentAmount_i.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(10.0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.6, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtSPaymentAmount_i.Value = "Amount         : " + dsObj.Tables[1].Rows[i]["PaidAmount"].ToString();

        //            //-----4-//
        //            txtSChequeNo_i.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(4, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtSChequeNo_i.Name = "ChequeNo";
        //            txtSChequeNo_i.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(10.0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.6, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtSChequeNo_i.Value = "Cheque No.         : " + dsObj.Tables[1].Rows[i]["ChequeNo"].ToString();


        //            //-----5-//
        //            txtSBankName_i.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(5, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtSBankName_i.Name = "BankName";
        //            txtSBankName_i.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(10.0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.6, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtSBankName_i.Value = "Bank Name         : " + dsObj.Tables[1].Rows[i]["BankName"].ToString().ToUpper();


        //            //-----6-//
        //            txtSPaymentType_i.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(6, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtSPaymentType_i.Name = "PaymentType";
        //            txtSPaymentType_i.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(10.0, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(0.6, Telerik.Reporting.Drawing.UnitType.Cm));
        //            txtSPaymentType_i.Value = "Payment Type         : " + dsObj.Tables[1].Rows[i]["PaymentType"].ToString();


                    

        //            panel_i.Items.AddRange(new Telerik.Reporting.ReportItemBase[] { txtClaimSettlementHeader_i, txtSPaymentDate_i, txtSCurrency_i, txtSPaymentAmount_i, txtSChequeNo_i, txtSBankName_i, txtSPaymentType_i,
        //            });
        //            panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] { panel_i });

        //            detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] { panel1 });
        //            //end

        //            PanelYLocation = PanelYLocation + 6;

        //        }


        //    }
        //}
       

    }
}