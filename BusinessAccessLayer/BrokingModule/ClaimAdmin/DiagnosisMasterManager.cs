using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
    public class DiagnosisMasterManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadDiagnosis(clsDiagnosisMaster objDiagnosis)
        {
            object[] parameter = new object[1] { objDiagnosis.DiagnosisId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_DiagnosisMaster_Select", "DiagnosisSelect");

        }
        public DataSet SaveDiagnosis(clsDiagnosisMaster objDiagnosis)
        {
            DataAccessDs = new DataAccess();
            object[] parameter = new object[7]{
                                             objDiagnosis.DiagnosisId,
                                             objDiagnosis.DiagnosisCode, //-- Added by anshul #itrack 106 Enhancement
                                             objDiagnosis.DiagnosisDesc,
                                             objDiagnosis.EffectivefromDate,
                                             objDiagnosis.Effectivetodate,
                                             objDiagnosis.User,
                                             objDiagnosis.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_DiagnosisMaster_InsertUpdate", "DiagnosisDetail");

        }
    }
}
