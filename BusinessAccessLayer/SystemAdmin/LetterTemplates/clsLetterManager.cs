using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.LetterTemplates;

namespace BusinessAccessLayer.SystemAdmin.LetterTemplates
{
    public class clsLetterManager
    {
        DataAccess dataAccessDS = null;
        public DataSet GetLetterTemplates(clsLetterTemplates objLetter)
        {
            object[] parameters = new object[2] { objLetter.LtrTemplatedId,objLetter.TemplateType };
            //object[] parameters = new object[1] { objLetter.LtrTemplatedId};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Ltr_TemplateMaster_Select", "LetterTemplateSelect");
        }
        public DataSet SaveLetterTemplates(clsLetterTemplates objLetter)
        {

            dataAccessDS = new DataAccess();
            Object[] parameters = new Object[] {objLetter.LtrTemplatedId,
                                                objLetter.LtrTemplateName,
                                                objLetter.LoginUserId
                                               
                                                    };
            return dataAccessDS.LoadDataSet(parameters, "P_Ltr_LetterTemplate_InsertUpdate", "LetterTemplateSelect");
        }
        public DataSet GetBodyContents(int LetterTemplateId)
        {
            object[] parameters = new object[1] { LetterTemplateId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Ltr_BodyContentsMaster_Select", "BodyContentsMaster");
        }
        public DataSet SaveLetterBodyContents(clsLetterTemplateDetail objLetterBody,string BodyContentIds)
        {
            object[] parameters = new object[] {objLetterBody.LtrTemplateId,BodyContentIds };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Ltr_LetterContentMapping_InsertUpdate", "BodyContentsMaster");
        }
    }
}
