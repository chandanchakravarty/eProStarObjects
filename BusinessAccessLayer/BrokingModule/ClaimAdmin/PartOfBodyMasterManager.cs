using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
    public class PartOfBodyMasterManager
    {
        DataAccess DataAccessDs=null;
        public DataSet LoadPartOfBody(clsPartOfBodyMaster objPartOfBody)
        {
            object[] parameter = new object [2] {   objPartOfBody.PartOfBodyFor,
                                                    objPartOfBody.PartOfBodyId, };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_PartofBodyMaster_Select", "PartOfBodySelect");
        
        }
        public DataSet SavePartOfBody(clsPartOfBodyMaster objPartOfBody)
        { 
            DataAccessDs=new DataAccess();
            object[] parameter = new object[7]{
                                             objPartOfBody.PartOfBodyId,
                                             objPartOfBody.PartOfBodyFor,
                                             objPartOfBody.PartOfBody,
                                             objPartOfBody.EffectivefromDate,
                                             objPartOfBody.Effectivetodate,
                                             objPartOfBody.User,
                                             objPartOfBody.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_PartofBodyMaster_InsertUpdate", "PartOfBodyDetail");
        
        }
    }
}
