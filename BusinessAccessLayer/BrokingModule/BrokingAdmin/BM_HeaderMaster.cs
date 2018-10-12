using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class BM_HeaderMaster
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadBM_HeaderDetail(clsBM_HeaderMaster objclsBM_HeaderMaster)
        {
            object[] parameters = new object[] { objclsBM_HeaderMaster.frmfor, objclsBM_HeaderMaster.HeaderId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_HeaderMaster_Select", "TM_BM_HeaderMaster");
        }

        public DataSet LoadBM_HeaderDetailAll(clsBM_HeaderMaster objclsBM_HeaderMaster)
        {
            object[] parameters = new object[] { objclsBM_HeaderMaster.frmfor, objclsBM_HeaderMaster.MainClass, objclsBM_HeaderMaster.SubClass, objclsBM_HeaderMaster.Header, objclsBM_HeaderMaster.HeaderDescription, objclsBM_HeaderMaster.EffFromDate, objclsBM_HeaderMaster.EffFromDate1, objclsBM_HeaderMaster.EffToDate, objclsBM_HeaderMaster.EffToDate1 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_HeaderMaster_SelectAll", "TM_BM_HeaderMasterAll");

        }

        public DataSet SaveAuditLog_HeaderDetail(AuditLog_HeaderMaster objAuditLog_HeaderMaster)
        {
            object[] parameters = new object[] { 
                                                    objAuditLog_HeaderMaster.TransTypeID, 
                                                    objAuditLog_HeaderMaster.RecordedBy, 
                                                    objAuditLog_HeaderMaster.RecordedByName, 
                                                    objAuditLog_HeaderMaster.RecFor, 
                                                    objAuditLog_HeaderMaster.RecForClientID, 
                                                    objAuditLog_HeaderMaster.RecForPolicyID, 
                                                    objAuditLog_HeaderMaster.RecForPolicyVerID, 
                                                    objAuditLog_HeaderMaster.RecForIDAddnl, 
                                                    objAuditLog_HeaderMaster.ScrMenuCode, 
                                                    objAuditLog_HeaderMaster.TblName, 
                                                    objAuditLog_HeaderMaster.TblPrimaryKeys,
                                                    objAuditLog_HeaderMaster.TblPrimaryKeysValues,
                                                    objAuditLog_HeaderMaster.Trans_Desc,
                                                    objAuditLog_HeaderMaster.TransLogDetails, 
                                                    objAuditLog_HeaderMaster.IsEndorse,
                                                    objAuditLog_HeaderMaster.Trans_Desc_Text,
                                                    objAuditLog_HeaderMaster.IsRenew
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "Txn_AuditLog", "Txn_AuditLog");
        }


        public DataSet SaveBM_HeaderDetail(clsBM_HeaderMaster objclsBM_HeaderMaster)
        {
            object[] parameters = new object[] { objclsBM_HeaderMaster.frmfor,
                                                 objclsBM_HeaderMaster.ClassId,
                                                 objclsBM_HeaderMaster.SubClassId,
                                                 objclsBM_HeaderMaster.HeaderId,
                                                 objclsBM_HeaderMaster.Header,
                                                 objclsBM_HeaderMaster.HeaderCH,
                                                 objclsBM_HeaderMaster.HeaderDescription,
                                                 objclsBM_HeaderMaster.HeaderFullDescription,
                                                 objclsBM_HeaderMaster.TariffReferenceCode,
                                                 objclsBM_HeaderMaster.ConditionType,
                                                 objclsBM_HeaderMaster.ToPrint,
                                                 objclsBM_HeaderMaster.EffFromDate ,
                                                 objclsBM_HeaderMaster.EffToDate ,
                                                 objclsBM_HeaderMaster.User,
                                                 objclsBM_HeaderMaster.Status,
                                                 objclsBM_HeaderMaster.GroupHeader,
                                                 objclsBM_HeaderMaster.PrintFor
                                              };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_BM_HeaderMaster_InsertUpdate", "TM_BM_HeaderMaster");

        }
    }
}
