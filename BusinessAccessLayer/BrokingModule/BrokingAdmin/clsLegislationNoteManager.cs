using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.BrokingModule.BrokingAdmin
{
    public class clsLegislationNoteManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadLegislationNote(clsLegislationNoteMaster objLegislationNote)
        {
            object[] parameters = new object[2] { objLegislationNote.LegislationNoteID,objLegislationNote.LegislationNoteType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_LegislationNotMaster_Select", "LegislationNoteDetail");

        }

        public DataSet LoadLegislationNoteAll(clsLegislationNoteMaster objLegislationNote)
        {
            object[] parameters = new object[6] {objLegislationNote.LegislationNote,objLegislationNote.EffFromDate,objLegislationNote.EffFromDate1,objLegislationNote.EffToDate,objLegislationNote.EffToDate1 , objLegislationNote.LegislationNoteType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_LegislationNotMaster_SelectAll", "LegislationNoteDetailAll");

        }

        public DataSet SaveLegislationNote(clsLegislationNoteMaster objLegislationNote)
        {
            object[] parameters = new object[8] { 
                                                  objLegislationNote.LegislationNoteID,
                                                  objLegislationNote.LegislationNote,
                                                  objLegislationNote.EffFromDate,
                                                  objLegislationNote.EffToDate,
                                                  objLegislationNote.Status,
                                                  objLegislationNote.LoginUserId,
                                                  objLegislationNote.PageMethod,
                                                  objLegislationNote.LegislationNoteType
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_LegislationNoteDetailsMaster_InsertUpdate", "LegislationNote");

        }
    }
}
