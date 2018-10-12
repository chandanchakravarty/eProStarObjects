using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.Reports;

namespace BusinessAccessLayer.RIBrokingModule.Reports
{
    public class clsReportManager
    {
        DataAccess dataAccess = null;
        public DataSet GetRenewalReportrList(clsReport objReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objReport.PeriodFrom, objReport.PeriodTo };
            return dataAccess.LoadDataSet(parameters, "P_IRM_Report_RenewalList_Select", "Rep_RenewalList");
        }

        public DataSet GetRenewalReportPrintData(clsReport objReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objReport.PeriodFrom, objReport.PeriodTo };
            return dataAccess.LoadDataSet(parameters, "P_IRM_Report_RenewalList_Print", "Rep_RenewalPrint");
        }

        public DataSet GetClaimInvoiceReportPrintData(clsReport objReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objReport.ClaimNo, 
                                                    objReport.InvoiceNo, 
                                                    objReport.CoverNoteNo, 
                                                    objReport.ReinsurerName,
                                                    objReport.Reinsurercode, 
                                                    objReport.CedantName, 
                                                    objReport.Cedantcode, 
                                                    objReport.ClientName,
                                                    objReport.Clientcode, 
                                                    objReport.MainClass, 
                                                    objReport.SubClass, 
                                                    objReport.ClaimCreateMonth };
            return dataAccess.LoadDataSet(parameters, "P_IRM_Report_ClaimInvoiceList_Print", "Rep_ClaimInvoicePrint");
        }

        public DataSet GetOutstandingClaimReportPrintData(clsReport objReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objReport.CoverNoteNo, 
                                                    objReport.ReinsurerName,
                                                    objReport.Reinsurercode, 
                                                    objReport.CedantName, 
                                                    objReport.Cedantcode, 
                                                    objReport.ClientName,
                                                    objReport.Clientcode, 
                                                    objReport.CedantPolicyNo, 
                                                    objReport.Currency, 
                                                    objReport.PeriodFrom,
                                                    objReport.PeriodTo };
            return dataAccess.LoadDataSet(parameters, "P_IRM_Report_OutstandingClaimList_Print", "Rep_OutClaimPrint");
        }

        public DataSet GetBrokerageReportPrintData(clsReport objReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objReport.CoverNote
                                                ,objReport.InvoiceNo 
                                                ,objReport.ReinsurerName
                                                ,objReport.Reinsurercode
                                                ,objReport.InsurerCode 
                                                ,objReport.InsurerName 
                                                ,objReport.MonthDate 
                                                ,objReport.User 
                                                ,objReport.MainClass
                                                ,objReport.Currency };
            return dataAccess.LoadDataSet(parameters, "P_IRM_Report_Brokerage", "Rep_BrokeragePrint");
        }
        public DataSet GetOSLossesClaimPaymentPrintData(clsReport objReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
                                                objReport.ReinsurerName
                                                ,objReport.Reinsurercode
                                                ,objReport.MainClass
                                                ,objReport.SubClass
                                                ,objReport.Currency 
                                                ,objReport.PeriodFrom
                                                ,objReport.PeriodTo};
            return dataAccess.LoadDataSet(parameters, "P_IRM_Report_OSLossesClaimPayment", "Rep_OSLossesClaimPayment");
        }

    }
}
