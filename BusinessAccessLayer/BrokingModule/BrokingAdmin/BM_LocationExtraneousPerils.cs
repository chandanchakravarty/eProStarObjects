using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
   public class BM_LocationExtraneousPerils
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadLocationExtraneousPeril(int PolicyId, int PolicyVerId)
        {
            object[] parameters = new object[] { PolicyId, PolicyVerId };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameters,"P_Pol_Policy_LocationExtraneousPerils", "LocationExtraneousPeuril");
        }


        public DataSet PolExtraneousPerilInsertUpdate(clsPolExtraneousPerils objExtraneousPeril)
        {
            object[] parametes = new object[] {
                                    objExtraneousPeril.PolicyId, 
                                    objExtraneousPeril.PolicyVerId, 
                                    objExtraneousPeril.ExtraneousPerilID,
                                    objExtraneousPeril.Item,
                                    objExtraneousPeril.Coverage,
                                    objExtraneousPeril.SubCoverage,
                                    objExtraneousPeril.ItemIndured,
                                    objExtraneousPeril.StdTariffRate,
                                    objExtraneousPeril.LoadingRate,
                                    objExtraneousPeril.Rules,
                                    objExtraneousPeril.LocationsId,
                                    objExtraneousPeril.PremRateApplicable,
                                    objExtraneousPeril.UserId
                                };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parametes, "P_Pol_Policy_ExtraneousPerils_InsertUpdate", "ExtraneousPerilInsertUpdate");
        }

    }



}
