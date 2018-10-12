using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
    public class ClaimPaymentTypeManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadClaimPaymentType(clsClaimPaymentTypeMaster objClaimPaymentType)
        {
            object[] parameter = new object[8] { objClaimPaymentType.ClaimPaymentTypeFor, objClaimPaymentType.ClaimPaymentTypeId, objClaimPaymentType.ClaimPaymentTypeCode, objClaimPaymentType.ClaimPaymentTypeDesc, objClaimPaymentType.EffectivefromDate, objClaimPaymentType.EffectivefromDate1, objClaimPaymentType.Effectivetodate, objClaimPaymentType.Effectivetodate1 };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_ClaimPaymentTypeMaster_Select", "ClaimPaymentTypeSelect");

        }
        public DataSet SaveClaimPaymentType(clsClaimPaymentTypeMaster objClaimPaymentType)
        {
            DataAccessDs = new DataAccess();
            object[] parameter = new object[8]{
                                             objClaimPaymentType.ClaimPaymentTypeId,
                                             objClaimPaymentType.ClaimPaymentTypeFor,
                                             objClaimPaymentType.ClaimPaymentTypeCode,
                                             objClaimPaymentType.ClaimPaymentTypeDesc,
                                             objClaimPaymentType.EffectivefromDate,
                                             objClaimPaymentType.Effectivetodate,
                                             objClaimPaymentType.User,
                                             objClaimPaymentType.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_ClaimPaymentTypeMaster_InsertUpdate", "ClaimPaymentTypeDetail");

        }
    }
}
