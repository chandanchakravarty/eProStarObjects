using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.Reports;

namespace BusinessAccessLayer.SystemAdmin.Reports
{
    public class ProductionReport
    {
        DataAccess dataAccess = null;
        public DataSet GetProductionReportPerUser(clsProductionReport objProductionReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
                                objProductionReport.CreatedBy,
                                objProductionReport.ModifyBy ,
                                objProductionReport.DocumentType,
                                objProductionReport.CreatedDateFrom ,
                                objProductionReport.CreatedDateTo ,
                                objProductionReport.ModifyDateFrom ,
                                objProductionReport.ModifyDateTo, 
                                objProductionReport.DocumentDateFrom,
                                objProductionReport.DocumentDateTo,
                                                };
            return dataAccess.LoadDataSet(parameters, "P_GetProductionReportPerUser_Select", "ProductionReport");
        }

        public DataSet GetLedgerBranchList(clsProductionReport objProductionReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
                                                    objProductionReport.Company
                                                };
            return dataAccess.LoadDataSet(parameters, "P_GetLedgerBranchList_Select", "LedgerBranchReport");
        }

        public DataSet GetTemplateList(clsProductionReport objProductionReport)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
                                                objProductionReport.SubClassCode,
                                                objProductionReport.MainClass,                    
                                                objProductionReport.CompanyId
                                                };
            return dataAccess.LoadDataSet(parameters, "P_GetTemplateList_Select", "TemplateListReport");
        }

    }
}
