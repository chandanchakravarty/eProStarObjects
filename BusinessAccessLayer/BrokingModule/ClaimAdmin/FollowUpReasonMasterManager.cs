using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
   public  class FollowUpReasonMasterManager
    { 
       DataAccess DataAccessDs = null;
       public DataSet LoadFollowUpReasonMaster(clsFollowUpReasonMaster objFollowup)
       {
           DataAccessDs=new DataAccess();
           object[] parameter = new object[6] { objFollowup.FollowUpReasonId,objFollowup.FollowUpReasonDesc ,objFollowup.EffFromDate ,objFollowup.EffFromDate1,objFollowup.EffToDate,objFollowup.EffToDate1};
           return DataAccessDs.LoadDataSet(parameter, "P_CA_FollowupReasonMaster_Select", "FollowUpReasonSelect");
       }
       public DataSet SaveFollowUpReason(clsFollowUpReasonMaster objFollowup)
       {
           DataAccessDs = new DataAccess();
           object[] parameter = new object[]{objFollowup.FollowUpReasonId,
                                            objFollowup.FollowUpReasonDesc,
                                            objFollowup.EffFromDate,
                                            objFollowup.EffToDate,
                                            objFollowup.User,
                                            objFollowup.IsActive
                                           };
           return DataAccessDs.LoadDataSet(parameter, "P_CA_FollowupReasonMaster_InsertUpdate", "FollowUpReasonDetail");
       }
    }
}
