namespace FormsNReports
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
    /// Summary description for CompanyProductivityByClass.
    /// </summary>
    public partial class CompanyProductivityByClass : Telerik.Reporting.Report
    {
        public CompanyProductivityByClass()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public CompanyProductivityByClass(DataSet DsComp,DataSet param,DataSet DsReport)
        {
            InitializeComponent();

            //int counter = 0;
            //int Counter2 = 1;
            //int i = 1;
            //decimal GrossPremiumLI = 0;
            //decimal discountLc = 0;
            //decimal netpremiumLI = 0; 
            //decimal GSTLI = 0;
            //decimal commissionAmtLI = 0; 
            //decimal gstcommamtli = 0; 
            //decimal AgentCommL = 0;
            //decimal FinalPremiumFI = 0;
            //decimal FirmComm = 0;


            //DataTable copyDataTable;
            //copyDataTable = DsReport.Tables[0].Copy();
            //string[] strSummCities = DsReport.Tables[0].AsEnumerable().Select(s => s.Field<string>("mainclasscode")).ToArray<string>();


            //for (int k = 0; k < DsReport.Tables[0].Rows.Count; k++)
            //{
            //    GrossPremiumLI += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[9]);
            //    discountLc += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[10]);
            //    netpremiumLI += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[11]);
            //    GSTLI += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[12]);
            //    commissionAmtLI += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[13]);
            //    gstcommamtli += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[14]);
            //    AgentCommL += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[15]);
            //    FinalPremiumFI += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[16]);
            //    FirmComm += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[17]);

            //    if (i != 1)
            //    {
                   
            //        if (DsReport.Tables[0].Rows[k].ItemArray[8].ToString() != strSummCities[counter])
            //        {
                       
            //            DataRow row1 = copyDataTable.NewRow();
            //            copyDataTable.Rows.InsertAt(row1, counter + Counter2);
            //            copyDataTable.Rows[counter + Counter2][3] = "Sub Total (ALL RISKS)";
            //            copyDataTable.Rows[counter + Counter2][9] = GrossPremiumLI;
            //            copyDataTable.Rows[counter + Counter2][10] = discountLc;
            //            copyDataTable.Rows[counter + Counter2][11] = netpremiumLI;
            //            copyDataTable.Rows[counter + Counter2][12] = GSTLI;
            //            copyDataTable.Rows[counter + Counter2][13] = commissionAmtLI;
            //            copyDataTable.Rows[counter + Counter2][14] = gstcommamtli;
            //            copyDataTable.Rows[counter + Counter2][15] = AgentCommL;
            //            copyDataTable.Rows[counter + Counter2][16] = FinalPremiumFI;
            //            copyDataTable.Rows[counter + Counter2][17] = FirmComm;

            //            Counter2++;
            //            GrossPremiumLI = 0;
            //            discountLc = 0;
            //            netpremiumLI = 0;
            //            GSTLI = 0;
            //            commissionAmtLI = 0;
            //            gstcommamtli = 0;
            //            AgentCommL = 0;
            //            FinalPremiumFI = 0;
            //            FirmComm = 0;

            //        }
            //        counter++;
            //    }
            //    i++;

            //    if (DsReport.Tables[0].Rows.Count-1 == k)
            //    {

            //        GrossPremiumLI += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[9]);
            //        discountLc += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[10]);
            //        netpremiumLI += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[11]);
            //        GSTLI += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[12]);
            //        commissionAmtLI += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[13]);
            //        gstcommamtli += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[14]);
            //        AgentCommL += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[15]);
            //        FinalPremiumFI += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[16]);
            //        FirmComm += Convert.ToDecimal(DsReport.Tables[0].Rows[k].ItemArray[17]);

            //        DataRow row1 = copyDataTable.NewRow();
            //        copyDataTable.Rows.InsertAt(row1, counter + Counter2);
            //        copyDataTable.Rows[counter + Counter2][3] = "Sub Total (ALL RISKS)";
            //        copyDataTable.Rows[counter + Counter2][9] = GrossPremiumLI;
            //        copyDataTable.Rows[counter + Counter2][10] = discountLc;
            //        copyDataTable.Rows[counter + Counter2][11] = netpremiumLI;
            //        copyDataTable.Rows[counter + Counter2][12] = GSTLI;
            //        copyDataTable.Rows[counter + Counter2][13] = commissionAmtLI;
            //        copyDataTable.Rows[counter + Counter2][14] = gstcommamtli;
            //        copyDataTable.Rows[counter + Counter2][15] = AgentCommL;
            //        copyDataTable.Rows[counter + Counter2][16] = FinalPremiumFI;
            //        copyDataTable.Rows[counter + 1][17] = FirmComm;
            //    }
            //}



                            //foreach (DataRow row in DsReport.Tables[0].Rows)
                            //{
                            //    GrossPremiumLI += Convert.ToDecimal(row.ItemArray[9]);
                            //    discountLc += Convert.ToDecimal(row.ItemArray[10]);
                            //    netpremiumLI += Convert.ToDecimal(row.ItemArray[11]);
                            //    GSTLI += Convert.ToDecimal(row.ItemArray[12]);
                            //    commissionAmtLI += Convert.ToDecimal(row.ItemArray[13]);
                            //    gstcommamtli += Convert.ToDecimal(row.ItemArray[14]);
                            //    AgentCommL += Convert.ToDecimal(row.ItemArray[15]);
                            //    FinalPremiumFI += Convert.ToDecimal(row.ItemArray[16]);
                            //    FirmComm += Convert.ToDecimal(row.ItemArray[17]);
                            //    if (i != 1)
                            //    {
                            //        if (row.ItemArray[8].ToString() != strSummCities[counter])
                            //        {
                            //            DataRow row1 = copyDataTable.NewRow();
                            //            copyDataTable.Rows.InsertAt(row1, counter + 1);
                            //            copyDataTable.Rows[counter + 1][3] = "Sub Total (ALL RISKS)";
                            //            copyDataTable.Rows[counter + 1][9] = GrossPremiumLI;
                            //            copyDataTable.Rows[counter + 1][10] = discountLc;
                            //            copyDataTable.Rows[counter + 1][11] = netpremiumLI;
                            //            copyDataTable.Rows[counter + 1][12] = GSTLI;
                            //            copyDataTable.Rows[counter + 1][13] = commissionAmtLI;
                            //            copyDataTable.Rows[counter + 1][14] = gstcommamtli;
                            //            copyDataTable.Rows[counter + 1][15] = AgentCommL;
                            //            copyDataTable.Rows[counter + 1][16] = FinalPremiumFI;
                            //            copyDataTable.Rows[counter + 1][17] = FirmComm;
                            //            GrossPremiumLI = 0;
                            //            discountLc = 0;
                            //            netpremiumLI = 0;
                            //            GSTLI = 0;
                            //            commissionAmtLI = 0;
                            //            gstcommamtli = 0;
                            //            AgentCommL = 0;
                            //            FinalPremiumFI = 0;
                            //            FirmComm = 0;

                            //        }
                            //        counter++;
                            //    }
                            //    i++;

                            //}
            table1.DataSource = DsComp.Tables[0];
            table2.DataSource = param.Tables[0];
            table5.DataSource = DsReport.Tables[0];//DsReport.Tables[0];
           
        }
    }
}