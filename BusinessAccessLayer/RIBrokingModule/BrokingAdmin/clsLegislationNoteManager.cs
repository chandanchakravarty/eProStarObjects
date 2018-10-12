using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.RIBrokingModule.BrokingAdmin
{
    public class clsLegislationNoteManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadLegislationNote(clsLegislationNoteMaster objLegislationNote)
        {
            object[] parameters = new object[2] { objLegislationNote.LegislationNoteID, objLegislationNote.LegislationNoteType };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_IRM_LegislationNotMaster_Select", "LegislationNoteDetail");
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
            return dataAccessDS.LoadDataSet(parameters, "P_TM_IRM_LegislationNoteDetailsMaster_InsertUpdate", "LegislationNote");
        }
    }
}
