using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
    public class NatureOfInjuryMasterManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadNatureOfInjury(clsNatureOfInjuryMaster objNatureOfInjury)
        {
            object[] parameter = new object[2] { objNatureOfInjury.NatureOfInjuryFor, objNatureOfInjury.NatureOfInjuryId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_NatureOfInjuryMaster_Select", "NatureOfInjurySelect");

        }
        public DataSet SaveNatureOfInjury(clsNatureOfInjuryMaster objNatureOfInjury)
        {
            DataAccessDs = new DataAccess();
            object[] parameter = new object[7]{
                                             objNatureOfInjury.NatureOfInjuryId,
                                             objNatureOfInjury.NatureOfInjuryFor,
                                             objNatureOfInjury.NatureOfInjury,
                                             objNatureOfInjury.EffectivefromDate,
                                             objNatureOfInjury.Effectivetodate,
                                             objNatureOfInjury.User,
                                             objNatureOfInjury.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_NatureOfInjuryMaster_InsertUpdate", "NatureOfInjuryDetail");

        }
    }
}
