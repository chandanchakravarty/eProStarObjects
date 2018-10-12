using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Data;
using BusinessObjectLayer.BrokingModule.ClaimAdmin;

namespace BusinessAccessLayer.BrokingModule.ClaimAdmin
{
    public class LossTypeManager
    {
        DataAccess DataAccessDs = null;
        public DataSet LoadLossType(clsLossTypeMaster objLossType)
        {
            object[] parameter = new object[8] { objLossType.LossTypeFor, objLossType.LossTypeId, objLossType.ClassName, objLossType.LossTypeName, objLossType.EffectivefromDate, objLossType.EffectivefromDate1, objLossType.Effectivetodate, objLossType.Effectivetodate1 };
            DataAccessDs = new DataAccess();
            return DataAccessDs.LoadDataSet(parameter, "P_CA_LossTypeMaster_Select", "LossTypeSelect");

        }
        public DataSet SaveLossType(clsLossTypeMaster objLossType)
        {
            DataAccessDs = new DataAccess();
            object[] parameter = new object[8]{
                                             objLossType.LossTypeId,
                                             objLossType.LossTypeFor,
                                             objLossType.ClassId,
                                             objLossType.LossTypeName,
                                             objLossType.EffectivefromDate,
                                             objLossType.Effectivetodate,
                                             objLossType.User,
                                             objLossType.IsActive
                                            };
            return DataAccessDs.LoadDataSet(parameter, "P_CA_LossTypeMaster_InsertUpdate", "LossTypeDetail");

        }

        #region <Location Panel>

        public DataSet GetLocationPanelDetails(clsLocationPanelMaster objLocationPanel)
        {
            DataAccessDs = new DataAccess();
            Object[] parameters = new Object[] { objLocationPanel.LocationPanelID, objLocationPanel.LocationPanel, objLocationPanel.EffFrom, objLocationPanel.EffFrom1, objLocationPanel.EffTo, objLocationPanel.EffTo1 };
            return DataAccessDs.LoadDataSet(parameters, "P_TM_GetLocationPanelDetails", "LocationPanelDetails");
        }

        public DataSet SaveLocationPanelDetails(clsLocationPanelMaster objLocationPanel)
        {
            DataAccessDs = new DataAccess();
            Object[] parameters = new Object[] {
                objLocationPanel.LocationPanelID,
                objLocationPanel.LocationPanel,
                objLocationPanel.EffFrom ,
                objLocationPanel.EffTo  ,
                objLocationPanel.CreatedBy
            };

            return DataAccessDs.LoadDataSet(parameters, "P_TM_LocationPanel_InsertUpdate", "LocationPanelInsertUpdate");
        }
        
        #endregion
    }
}
