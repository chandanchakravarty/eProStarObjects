using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
    public class LossNatureManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadLossNature(clsLossNatureMaster objLossNature)
        {
            object[] parameter = new object[9] { objLossNature.LossNatureFor, objLossNature.LossNatureId,objLossNature.LossNatureDesc ,objLossNature.MainClass ,objLossNature.LossType, objLossNature.EffFromDate,objLossNature.EffFromDate1 ,objLossNature.EffToDate ,objLossNature.EffToDate1 };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_LossNatureMaster_Select", "LossNatureSelect");

        }
        public DataSet LoadLossTypeByClassId(clsLossTypeMaster objLosstype)
        {
            object[] parameter = new object[2] { objLosstype.LossTypeFor, objLosstype.ClassId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_LossNatureMaster_SelectByClassId", "LossTypeList");

        }
        public DataSet LoadLossType(clsLossTypeMaster objLosstype)
        {
            object[] parameter = new object[1] { objLosstype.LossTypeFor };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_LossNatureMaster", "LossTypeList");

        }
        public DataSet SaveLossNature(clsLossNatureMaster objLossNature)
        {
            DataAccessDs = new DataAccess();
            object[] parameter = new object[9]{
                                             objLossNature.LossNatureId,
                                             objLossNature.LossNatureFor,
                                             objLossNature.ClassId,
                                             objLossNature.LossTypeId,
                                             objLossNature.LossNatureDesc,
                                             objLossNature.EffFromDate ,
                                             objLossNature.EffToDate ,
                                             objLossNature.User,
                                             objLossNature.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_LossNatureMaster_InsertUpdate", "LossNatureDetail");

        }
    }
}
