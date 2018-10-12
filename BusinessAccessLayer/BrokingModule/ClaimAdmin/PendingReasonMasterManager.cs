using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
    public class PendingReasonMasterManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadPendingReason(clsPendingReasonMaster objPendingReason)
        {
            object[] parameter = new object[1] { objPendingReason.PendingReasonId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_PendingReasonMaster_Select", "PendingReasonSelect");

        }
        public DataSet SavePendingReason(clsPendingReasonMaster objPendingReason)
        {
            DataAccessDs = new DataAccess();
            object[] parameter = new object[6]{
                                             objPendingReason.PendingReasonId,
                                             objPendingReason.PendingReasonDesc,
                                             objPendingReason.EffectivefromDate,
                                             objPendingReason.Effectivetodate,
                                             objPendingReason.User,
                                             objPendingReason.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_PendingReasonMaster_InsertUpdate", "PendingReasonDetail");

        }
    }
}
