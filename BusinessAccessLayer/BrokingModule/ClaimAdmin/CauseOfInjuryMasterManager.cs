using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
    public class CauseOfInjuryMasterManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadCauseOfInjury(clsCauseOfInjuryMaster objCauseOfInjury)
        {
            object[] parameter = new object[2] { objCauseOfInjury.CauseOfInjuryFor,
                                                 objCauseOfInjury.CauseOfInjuryId    
                                                };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_CauseOfInjuryMaster_Select", "CauseOfInjurySelect");

        }
        public DataSet SaveCauseOfInjury(clsCauseOfInjuryMaster objCauseOfInjury)
        {
            DataAccessDs = new DataAccess();
            object[] parameter = new object[7]{
                                             objCauseOfInjury.CauseOfInjuryId,
                                             objCauseOfInjury.CauseOfInjuryFor,
                                             objCauseOfInjury.CauseOfInjury,
                                             objCauseOfInjury.EffectivefromDate,
                                             objCauseOfInjury.Effectivetodate,
                                             objCauseOfInjury.User,
                                             objCauseOfInjury.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_CauseOfInjuryMaster_InsertUpdate", "CauseOfInjuryDetail");

        }
    }
}
