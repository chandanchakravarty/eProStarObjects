using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
    public class RejectReasonMasterManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadRejectReason(clsRejectReasonMaster objRejectReason)
        {
            object[] parameter = new object[1] { objRejectReason.RejectReasonId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_RejectReasonMaster_Select", "RejectReasonSelect");
        }


        public DataSet LoadRejectReasonAll(clsRejectReasonMaster objRejectReason)
        {
            object[] parameter = new object[5] {objRejectReason.RejectReasonDesc,objRejectReason.EffFromDate,objRejectReason.EffFromDate1,objRejectReason.EffToDate,objRejectReason.EffToDate1  };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_RejectReasonMaster_SelectAll", "RejectReasonSelectAll");

        }

        public DataSet LoadRejectReasonMaster(clsRejectReasonMaster objRejectReason)
        {
            object[] parameter = new object[5] { objRejectReason.RejectReasonDesc, objRejectReason.EffFromDate, objRejectReason.EffFromDate1, objRejectReason.EffToDate, objRejectReason.EffToDate1 };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_RejectReasonMaster", "RejectReasonSelectAll");

        }

        public DataSet SaveRejectReason(clsRejectReasonMaster objRejectReason)
        {
            DataAccessDs = new DataAccess();
            object[] parameter = new object[6]{
                                             objRejectReason.RejectReasonId,
                                             objRejectReason.RejectReasonDesc,
                                             objRejectReason.EffFromDate ,
                                             objRejectReason.EffToDate,
                                             objRejectReason.User,
                                             objRejectReason.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_RejectReasonMaster_InsertUpdate", "RejectReasonDetail");

        }
    }
}
