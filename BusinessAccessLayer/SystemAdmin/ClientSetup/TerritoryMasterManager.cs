using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.SystemAdmin.ClientSetup;
using DataAccessLayer;

namespace BusinessAccessLayer.SystemAdmin.ClientSetup
{
    public class TerritoryMasterManager
    {

        DataAccess dataAccessDS = null;
        public DataSet GetBindCorporatetype()
        {
            dataAccessDS = new DataAccess();
    
            return dataAccessDS.LoadDataSet("P_BindLookup_Corporategroup", "corporatemaster");
        }



        public DataSet LoadTerritory(clsTerritoryMaster objTeritory)
        {
            object[] parameters = new object[] { objTeritory.TerritoryId ,objTeritory.EffFrom,objTeritory.EffFrom1,objTeritory.EffTo,objTeritory.EffTo1};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TerritoryMaster_Select", "TerritorySelect");

        }

        public DataSet LoadTerritoryAll(clsTerritoryMaster objTeritory)
        {
            object[] parameters = new object[] { objTeritory.CountryCode, objTeritory.CountryShortCode, objTeritory.TerritoryName, objTeritory.EffFrom, objTeritory.EffFrom1, objTeritory.EffTo, objTeritory.EffTo1,objTeritory.WorldReg };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TerritoryMaster_SelectAll", "TerritorySelectAll");

        }
        public DataSet LoadCoporate(clsCorporateMaster objcorporate)
        {
            object[] parameters = new object[] { objcorporate.CorporateId, objcorporate.EffFrom, objcorporate.EffFrom1, objcorporate.EffTo, objcorporate.EffTo1 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_CorporaterMaster_Select", "CorpoarteSelect");

        }

        public DataSet LoadCoporateAll(clsCorporateMaster objcorporate)
        {
            object[] parameters = new object[] { objcorporate.CorporateGroupCode, objcorporate.CorporateGroupType, objcorporate.Corporatedescripation, objcorporate.EffFrom, objcorporate.EffFrom1, objcorporate.EffTo, objcorporate.EffTo1 };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_CorporaterMaster_SelectAll", "CorpoarteSelectAll");

        }


        public DataSet SaveTerritory(clsTerritoryMaster objTeritory)
        {
            object[] parameters = new object[] { objTeritory.TerritoryId,
                                                 objTeritory.CountryCode,
                                                 objTeritory.CountryShortCode,
                                                 objTeritory.TerritoryName,
                                                 objTeritory.TerritoryNameChinese,
                                                 objTeritory.Codepattern_UW,
                                                 objTeritory.Codepattern_Agent,
                                                 objTeritory.User,
                                                 objTeritory.isActive,
                                                 objTeritory.EffFrom,
                                                 objTeritory.EffTo,
                                                 objTeritory.WorldReg
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_TerritoryMaster_InsertUpdate", "TerritoryDetail");

        }

        public DataSet SaveCorporate(clsCorporateMaster objCorporate)
        {
            object[] parameters = new object[] { objCorporate.CorporateId,
                                                 objCorporate.CorporateGroupCode,
                                                 objCorporate.CorporateGroupType,
                                                 objCorporate.Corporatedescripation,
                                               
                                                 objCorporate.isActive,
                                                 objCorporate.EffFrom,
                                                 objCorporate.EffTo,
                                                  objCorporate.User
                                                };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_CorporateMaster_InsertUpdate", "CorporateDetail");

        }

        // Added By Apurva
        public DataSet GetWorldRegionOnSelect()
        {
            dataAccessDS = new DataAccess();
            object[] parameters = new Object[] { };
            return dataAccessDS.LoadDataSet(parameters, "[P_Adm_WorldRegionList_OnSelect]", "TM_WordRegions");
        }
    }
}
