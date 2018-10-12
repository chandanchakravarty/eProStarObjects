using BusinessObjectLayer.BrokingModule.BrokingAdmin;
using DataAccessLayer;
using System.Data;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class BM_ExtraneousPerilsMasterManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadExtraneousPerils(clsExtraneousPerilsMaster objExtraneousPerils)
        {
            object[] parameter = new object[4] { objExtraneousPerils.ExtraneousPerilID, objExtraneousPerils.Item, objExtraneousPerils.Coverage, objExtraneousPerils.SubCoverage };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_BM_ExtraneousPerilsMaster_Select", "ExtraneousPerilsSelect");
        }

        public DataSet SaveBM_ExtraneousPerils(clsExtraneousPerilsMaster objclsBM_ExtraneousPerils)
        {
            object[] parameters = new object[] { objclsBM_ExtraneousPerils.ExtraneousPerilID,
                                                 objclsBM_ExtraneousPerils.Item,
                                                 objclsBM_ExtraneousPerils.Coverage,
                                                 objclsBM_ExtraneousPerils.SubCoverage,
                                                 objclsBM_ExtraneousPerils.Excess,
                                                 objclsBM_ExtraneousPerils.StdTariffRate,
                                                 objclsBM_ExtraneousPerils.LoadingRate,
                                                 objclsBM_ExtraneousPerils.Rules,
                                                 objclsBM_ExtraneousPerils.User,
                                              };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameters, "P_BM_ExtraneousPerils_InsertUpdate", "TM_BM_ExtraneousPeril");
        }
    }
}
