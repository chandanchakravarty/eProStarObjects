using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BusinessObjectLayer.SystemAdmin.AnalysisCode;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingAdmin;

namespace BusinessAccessLayer.SystemAdmin.AnalysisCode
{
    public class SubClassTemplateManager
    {
        DataAccess dataAccessDS = null;
        public DataSet SaveSubClassTemplate(clsSubClassTemplate objSubClassTemp, string xmltempDetail)
        {
            dataAccessDS = new DataAccess();
            object[] parameters ={objSubClassTemp.SubClassTemplateID,
                                  objSubClassTemp.ClassID,
                                  objSubClassTemp.SubClassID,
                                  objSubClassTemp.SubClassTemplateName,
                                  objSubClassTemp.FieldLanguage,
                                  objSubClassTemp.UserId,
                                  objSubClassTemp.IsActive,
                                  xmltempDetail
                                };
            return dataAccessDS.LoadDataSet(parameters, "P_TM_SubClassTemplate_InsertUpadte", "SubClassTemplate");
        }
        public DataSet LoadSubClassTemplate(int SubClassId)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = { SubClassId };
            string[] tables = { "Template", "TemplateDetail" };
            return dataAccessDS.LoadDataSets(parameters, "P_TM_SubClassTemplate_Select", tables);


        }
        public DataSet LoadClassTemplate(int ClassId)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = { ClassId };
            string[] tables = { "Template", "TemplateDetail" };
            return dataAccessDS.LoadDataSets(parameters, "P_TM_MainClassTemplate_Select", tables);


        }
        public DataSet LoadTemplateByClassTempId(int ClassTempId)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = { ClassTempId };
            string[] tables = { "Template" };
            return dataAccessDS.LoadDataSets(parameters, "P_TM_SubClassTemplate_SelByClassTempId", tables);


        }
        public DataSet LoadTemplateBySubClassTempId1(int ClassTempId, int SubClassId)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = { ClassTempId, SubClassId };
            string[] tables = { "Template" };
            return dataAccessDS.LoadDataSets(parameters, "P_TM_SubClassTemplate_SelByClassTempId", tables);

        }
        public DataSet LoadTemplateBySubClassTempIdForCov(int ClassTempId, int SubClassId , int UwCoverageId )
        {
            dataAccessDS = new DataAccess();
            object[] parameters = { ClassTempId, SubClassId, UwCoverageId };
            string[] tables = { "Template" };
            return dataAccessDS.LoadDataSets(parameters, "P_TM_SubClassTemplate_SelByClassTempIdForCov", tables);

        }
        public DataSet LoadTemplateBySubClassTempIdForRICov(int ClassTempId, int SubClassId, int UwCoverageId,string refno,string covernoteno)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = { ClassTempId, SubClassId, UwCoverageId,refno,covernoteno};
            string[] tables = { "Template" };
            return dataAccessDS.LoadDataSets(parameters, "RI_TM_SubClassTemplate_SelByClassTempIdForCov", tables);

        }

        public DataSet GetItemInfo(clsTemplateDefault objclsTemplateDefault)
        {

            object[] parameters = new object[] { objclsTemplateDefault.ClassId, objclsTemplateDefault.SubClassId, objclsTemplateDefault.ItemFor };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_pol_PolicyCovExcessRemark_DefaultDetails_Select", "pol_PolicyCovExcessRemark");
        }

        public DataSet SaveItemInfo(clsTemplateDefault objclsTemplateDefault)
        {

            object[] parameters = new object[] { objclsTemplateDefault.ItemId, objclsTemplateDefault.ClassId, objclsTemplateDefault.SubClassId, 
                objclsTemplateDefault.ItemFor,objclsTemplateDefault.OrderNo,objclsTemplateDefault.ItemText, objclsTemplateDefault.RowCellText, objclsTemplateDefault.User };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_pol_PolicyCovExcessRemarkDefaultDetails_InsertUpdate", "pol_PolicyCovExcessRemark");
        }

        public DataSet RemoveItemInfo(clsTemplateDefault objclsTemplateDefault)
        {

            object[] parameters = new object[] { objclsTemplateDefault.ItemId, objclsTemplateDefault.ClassId, objclsTemplateDefault.SubClassId, 
                objclsTemplateDefault.ItemFor };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_pol_PolicyCovExcessRemark_DefaultDetails_Delete", "pol_PolicyCovExcessRemark");
        }

       

        public DataSet GetCoverageSubSectionInfo(clsTemplateDefault objclsTemplateDefault)
        {

            object[] parameters = new object[] { objclsTemplateDefault.ItemId, objclsTemplateDefault.TableId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "Pol_PolicyCoverageSubSection_Default_SelectAll", "Pol_PolicyCoverageSubSection");
        }

        public DataSet SaveCoverageSubSectionInfo(clsTemplateDefault objclsTemplateDefault)
        {

            object[] parameters = new object[] { objclsTemplateDefault.RowId, objclsTemplateDefault.ItemId, objclsTemplateDefault.TableId,objclsTemplateDefault.ClassId,objclsTemplateDefault.SubClassId,objclsTemplateDefault.RowType,
                objclsTemplateDefault.Field1, objclsTemplateDefault.Field2, objclsTemplateDefault.Field3, objclsTemplateDefault.Field4, objclsTemplateDefault.Field5, objclsTemplateDefault.User };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyCoverageSubSection_Default_Insert", "Pol_PolicyCoverageSubSection");
        }

        public DataSet GetCoverageSubSection(clsTemplateDefault objclsTemplateDefault)
        {

            object[] parameters = new object[] { objclsTemplateDefault.ItemId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "Pol_PolicyCoverageSubSection_Default_Select", "Pol_PolicyCoverageSubSection");
        }

        public DataSet RemoveCoverageSubSection(clsTemplateDefault objclsTemplateDefault)
        {

            object[] parameters = new object[] { objclsTemplateDefault.ItemId, objclsTemplateDefault.TableId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyCoverageSubSection_Default_Delete", "Pol_PolicyCoverageSubSection");
        }
        public DataSet RemoveCoverageSubSectionRow(clsTemplateDefault objclsTemplateDefault)
        {

            object[] parameters = new object[] { objclsTemplateDefault.ItemId, objclsTemplateDefault.TableId, objclsTemplateDefault.RowId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_Pol_PolicyCoverageSubSection_Default_DeleteRow", "Pol_PolicyCoverageSubSection");
        }



    }
}
