using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;
using DataAccessLayer;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem.Quotation
{
    public class UWCoverageManager
    {

        DataAccess dataAccess = null;

        public DataSet getUWriters(Int64 polid, int polVerid)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] {polid,polVerid };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUnderwriters_Select", "PolicyUnderwriters");
        }

        public DataSet getEBUWriters(Int64 polid, int polVerid,string IsstsdBSL)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { polid, polVerid, IsstsdBSL };
            return dataAccess.LoadDataSet(parametes, "P_Pol_EB_PolicyUnderwriters_Select", "EB_PolicyUnderwriters");
        }

        public DataSet getBenefitScheduleLimit(int UWPlanId)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { UWPlanId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWPlanBenefitLimits_Select", "Pol_PolicyUWPlanBenefitLimits");
        }

        public DataSet getBenefitScheduleLimitPivot(Int64 polid, int polVerid, int UWPlanId)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { polid, polVerid, UWPlanId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWPlanBenefitLimits_Pivot_Select", "Pol_PolicyUWPlanBenefitLimits");
        }
        public DataSet getBenefitScheduleLimitReport(Int64 polid, int polVerid)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { polid, polVerid};
            //P_PlanBenefitLimits_Report_Test
           // return dataAccess.LoadDataSet(parametes, "P_PlanBenefitLimits_Report", "Pol_PolicyUWPlanBenefitLimits");
            return dataAccess.LoadDataSet(parametes, "P_PlanBenefitLimits_Report_Test", "Pol_PolicyUWPlanBenefitLimits");
        }

        
        public DataSet getEBBenefitScheduleLimit(Int64 polid, int polVerid)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { polid, polVerid };
            return dataAccess.LoadDataSet(parametes, "P_Pol_EB_BenefitScheduleLimit_Select", "EBBenefitScheduleLimit");
        }

        public DataSet getEBBenefitScheduleLimit_PlanSelect(int UWPlanId, Int64 polid, int polVerid)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { UWPlanId, polid, polVerid };
            return dataAccess.LoadDataSet(parametes, "P_Pol_EB_BenefitScheduleLimit_Plan_Select", "EBBenefitScheduleLimit_plan");
        }
        public DataSet getIHBenefitScheduleLimit_PlanSelect(int BenefitScheduleId)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { BenefitScheduleId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_IH_BenefitScheduleLimit_Plan_Select", "IHBenefitScheduleLimit_plan");
        }
        public DataSet getEBBenefitScheduleLimit_PlanInsertUpdate(int _UWPlanBenefitLimitID,int UWPlanId, int PolPlanId, int BenefitLineId, int BenefitGroupLineId, string _limitAmt, string CreatedBy, string LastUpdateBy, char PageMethod)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[9] { _UWPlanBenefitLimitID, UWPlanId, PolPlanId, BenefitLineId, BenefitGroupLineId, _limitAmt, CreatedBy, LastUpdateBy, PageMethod };
            return dataAccess.LoadDataSet(parametes, "P_Pol_EB_BenefitScheduleLimit_InsertUpdate", "EBBenefitScheduleLimit_plan_IU");
        }

        public DataSet getMotorBenefitScheduleLimit_PlanInsertUpdate(int _UWPlanBenefitLimitID, int Motorid, int Polid, int PolVerid,
            int PolPlanId, int UWPlanId, string AnPriType, string _limitAmt, string CreatedBy, string LastUpdateBy, char PageMethod)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { _UWPlanBenefitLimitID, Motorid, Polid, PolVerid,PolPlanId,UWPlanId,AnPriType,
                _limitAmt, CreatedBy, LastUpdateBy, PageMethod };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Motor_BenefitScheduleLimit_InsertUpdate", "P_Pol_Motor_BenefitScheduleLimit_InsertUpdate");
        }

        public DataSet getMotorBenefitScheduleLimit_Select(int Motorid, int Polid, int PolVerid,
            int PolPlanId, int UWPlanId, string AnPriType)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { Motorid, Polid, PolVerid,PolPlanId,UWPlanId,AnPriType,};
            return dataAccess.LoadDataSet(parametes, "P_Pol_Motor_BenefitScheduleLimit_Select", "P_Pol_Motor_BenefitScheduleLimit_Select");
        }

        public DataSet getEBBenefitScheduleLimit_EditBSL(int UWPlanId, int PolPlanId, int BenefitLineId, int BenefitGroupLineId)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[4] { UWPlanId, PolPlanId, BenefitLineId, BenefitGroupLineId};
            return dataAccess.LoadDataSet(parametes, "P_Pol_EB_BenefitScheduleLimit_EditBSL", "EBBenefitScheduleLimit_plan_IU");
        }

        public DataSet getClassTemplate(int classId, string pagemode, int coverageId)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { classId,  pagemode, coverageId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWCoverage_SelectByClass", "TemplateDetail");
        }


        public DataSet getTemplate(int classId, int subClassId,string pagemode,int coverageId)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[4] {classId,subClassId,pagemode,coverageId};
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWCoverage_SelectByClassAndSubClass", "TemplateDetail");
        }

        public DataSet CopyDefaultCovExcessRemark(int policyId, int PolicyVersionId, string itemFor, string user)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[4] { policyId, PolicyVersionId, itemFor, user };
            return dataAccess.LoadDataSet(parametes, "P_pol_PolicyCovExcessRemark_CopyDefault", "pol_PolicyCovExcessRemark");
        }

        public DataSet getTemplateDefaultValue(int classId, int subClassId)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { classId, subClassId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWCovDetails_DefaultTempValue_Select", "TemplateValue");
        }
        public DataSet getMandTemplateFields(int subClassID)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] { subClassID };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWCoverage_SelectMand", "MandTemplateDetail");
        }
        public DataSet getUWCoverage(int UnderWriterId, int UwCoverageId, Int64 polid, int polVerid)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[4] { UnderWriterId, UwCoverageId, polid, polVerid   };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWCovDetails_Select", "TemplateDetail");
        }

        public DataSet getRIUWCoverage(int UnderWriterId, int UwCoverageId, string RefNo, string CoverNoteNo,int subclassid)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[5] { UnderWriterId, UwCoverageId, RefNo, CoverNoteNo,subclassid};
            return dataAccess.LoadDataSet(parametes, "RI_CN_UWCovDetails_Select", "TemplateDetail");
        }

        ////added on 12th augest
        public DataSet getUWCoverageMultipleSubClass(int UnderWriterId, int UwCoverageId, Int64 polid, int polVerid, int subclassid)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[5] { UnderWriterId, UwCoverageId, polid, polVerid, subclassid };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWCovDetails_MultipleSubCLass_Select", "TemplateDetail");
        }
        ////
        public DataSet getCoverageTemplateSortOrder(int subclassTempId, int UwCoverageId)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[2] { subclassTempId, UwCoverageId };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWCovDetails_SortOrder_Select", "TemplateDetail");
        }



        public DataSet getTemplateFields(int polUWCovId,int subClassTemplateId, string csvTemplateFieldsId,string pagemode)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[4] { polUWCovId,subClassTemplateId, csvTemplateFieldsId,pagemode };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWCoverage_SelectByTemplateFieldIds", "Template");
        }
        public DataSet SaveCovTemplate(clsUWCoverage objCov,int SubClassTemplateId,string xmlstring)
        {

            dataAccess = new DataAccess();
            Object[] parametes =    new Object[] {  objCov.PolUWCovId,
                                                    objCov.PolUWId,
                                                    objCov.UnderwriterId,
                                                    objCov.PolicyId,
                                                    objCov.PolicyVerId,
                                                    objCov.User,
                                                    objCov.isActive,
                                                    objCov.SubClassId ,
                                                    objCov.RiskDetailsSubClassType ,
                                                    SubClassTemplateId,
                                                    xmlstring
                                                   
                                                 };

            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWCoverage_Update", "CovTemplate");
        }

        public DataSet SaveRICovTemplate(clsUWCoverage objCov, int SubClassTemplateId, string xmlstring)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {  objCov.PolUWCovId,
                                                    objCov.PolUWId,
                                                    objCov.UnderwriterId,
                                                    objCov.RefNo,
                                                    objCov.CoverNoteNo,
                                                    objCov.User,
                                                    objCov.isActive,                                                    
                                                    objCov.ClassId ,
                                                    objCov.SubClassId,
                                                    objCov.RiskDetailsSubClassType ,
                                                    SubClassTemplateId,
                                                    xmlstring
                                                   
                                                 };

            return dataAccess.LoadDataSet(parametes, "RI_CN_UWCoverage_Update", "CovTemplate");
        }

        //public DataSet SaveCovTemplateMultipleClass(clsUWCoverage objCov, int SubClassTemplateId, string xmlstring, int subclassid)
        //{

        //    dataAccess = new DataAccess();
        //    Object[] parametes =    new Object[] {  objCov.PolUWCovId,
        //                                            objCov.PolUWId,
        //                                            objCov.UnderwriterId,
        //                                            objCov.PolicyId,
        //                                            objCov.PolicyVerId,
        //                                            objCov.User,
        //                                            objCov.isActive,
        //                                            SubClassTemplateId,
        //                                            xmlstring,
        //                                            subclassid 
        //                                         };

        //    return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWCoverage_Update", "CovTemplate");
        //}

        
        public DataSet SaveCovTemplateInTemplate(clsUWCoverage objCov, int SubClassTemplateId, string xmlstring)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {  objCov.PolUWCovId,
                                                    objCov.PolUWId,
                                                    objCov.UnderwriterId,
                                                    objCov.PolicyId,
                                                    objCov.PolicyVerId,
                                                    objCov.User,
                                                    objCov.isActive,
                                                    SubClassTemplateId,
                                                    objCov.FieldLanguage,
                                                    objCov.SubClassId ,
                                                    xmlstring
                                                 };

            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWCoverage_InsertUpdate", "CovTemplate");
        }

        public DataSet SaveRICovTemplateInTemplate(clsUWCoverage objCov, int SubClassTemplateId, string xmlstring)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {  objCov.PolUWCovId,
                                                    objCov.PolUWId,
                                                    objCov.UnderwriterId,
                                                    objCov.RefNo,
                                                    objCov.CoverNoteNo,
                                                    objCov.User,
                                                    objCov.isActive,
                                                    SubClassTemplateId,
                                                    objCov.FieldLanguage,
                                                    objCov.ClassId ,
                                                    objCov.SubClassId ,
                                                    xmlstring
                                                 };

            return dataAccess.LoadDataSet(parametes, "RI_CN_PolicyUWCoverage_InsertUpdate", "CovTemplate");
        }
        public DataSet DeleteCovTemplate(clsUWCoverage objCov)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[4] {   objCov.PolUWCovId,
                                                    objCov.PolUWId,
                                                    objCov.PolicyId,
                                                    objCov.PolicyVerId,
                                                    
                                                 };

            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWCoverage_Delete", "CovTemplate");
        }

        public DataSet DeleteUnSavedCovDetail(int PolUWCovId)
        {

            dataAccess = new DataAccess();
            Object[] parametes = new Object[1] {   PolUWCovId  };

            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyUWCoverage_DeleteUnSaved", "CovTemplate");
        }
        public DataSet getPolicyUWCovDetailId(clsPolicyUWCovDetails objclsPolicyUWCovDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { objclsPolicyUWCovDetails.PolUWCovId, objclsPolicyUWCovDetails.FieldLabel };
            return dataAccess.LoadDataSet(parametes, "P_PolicyUWCovDetailId_SelectbyPolUWCovId_FieldLabel", "PolicyUWCovDetailId");
        }

        public DataSet getCondition_Warranties_MajorExclusion(int PolicyId, int PolVersionId, int SubClassId, string PrintType, string RiskType)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[5] { PolicyId, PolVersionId, SubClassId, PrintType, RiskType };
            return dataAccess.LoadDataSet(parametes, "Get_Condition_Warranties_MajorExclusion_ForPrintCoverNote", "ConWarrMajor");
        }
    }
}
