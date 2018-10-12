using System;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem;
using BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation;

namespace BusinessAccessLayer.BrokingModule.BrokingSystem.Quotation
{
    public class VesselDetailManager
    {
        DataAccess dataAccess = null;
        public DataSet getVesselHistory(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {objVesselDetails.PolicyId,objVesselDetails.PolVersionId  };
            return dataAccess.LoadDataSet(parametes, "get_Vessel_History", "get_Vessel_History");
        }
        public DataSet getUWCodeForVesselId(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] {objVesselDetails.PolicyId, objVesselDetails.PolVersionId};
            return dataAccess.LoadDataSet(parametes, "P_Get_UW_For_Vessel", "P_Get_UW_For_Vessel");
        }
        public DataSet bulkUploadVesselDetails(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { objVesselDetails.dt, objVesselDetails.PolicyId, objVesselDetails.PolVersionId, objVesselDetails.VesselMultipleBilling, objVesselDetails.UserID };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_VesselDetails_BulkInsert", "P_Pol_Policy_VesselDetails_BulkInsert");
        }

        public DataSet SaveVesselDetails(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[48] { objVesselDetails.RefNo, objVesselDetails.PolicyId, objVesselDetails.PolVersionId, objVesselDetails.VesselMultipleBilling,
            objVesselDetails.VesselName, objVesselDetails.Built, objVesselDetails.VesselType, objVesselDetails.GRT,
            objVesselDetails.NRT, objVesselDetails.BHP, objVesselDetails.Class,
            objVesselDetails.Flag, objVesselDetails.Dimension, objVesselDetails.Owner, objVesselDetails.Managers,
            objVesselDetails.Mortgagees, objVesselDetails.InceptionDate, objVesselDetails.ExpiryDate, objVesselDetails.UserID, objVesselDetails.GT, objVesselDetails.RegisteredLength, objVesselDetails.RegisteredBreadth, objVesselDetails.RegisteredDepth, objVesselDetails.NoOfCarry, objVesselDetails.RegisteredPlate, objVesselDetails.HMValue, objVesselDetails.IV,
            objVesselDetails.DWT, objVesselDetails.IMONo, objVesselDetails.IVInsuredValue, objVesselDetails.AOIInsuredValue, objVesselDetails.AdditionalAssureds, objVesselDetails.GeneralAverage ,
            /*Below parameter Added for redmine 23517*/
             objVesselDetails.Classification ,
            objVesselDetails.LengthOverall ,
            objVesselDetails.DesignDraft ,
            objVesselDetails.HullNo ,
            objVesselDetails.RegisteredOwner ,
            objVesselDetails.OtherInsuredParties ,
            objVesselDetails.Shipyard ,
            objVesselDetails.CallsignDistincitiveNo ,
            objVesselDetails.BollardPull ,
            objVesselDetails.CraneLiftingCapacity ,
            objVesselDetails.Clause12 ,
            objVesselDetails.TradingPlyingLimit ,
            objVesselDetails.AMD ,
            objVesselDetails.ValueofVessels,
            objVesselDetails.VesselStatus,
           
            };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_VesselDetailsInsertUpdate", "PolicyVesselDetailsInsertUpdate");
        }

        /* Added for redmine 23*/


        public DataSet SaveRIVesselDetails(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[27] { objVesselDetails.RefNo, objVesselDetails.TranRefNo, objVesselDetails.CoverNoteNo,objVesselDetails.VesselMultipleBilling ,
             objVesselDetails.VesselName,objVesselDetails.Built,objVesselDetails.VesselType,objVesselDetails.GRT,
             objVesselDetails.NRT ,objVesselDetails.BHP,objVesselDetails.Class,
             objVesselDetails.Flag,objVesselDetails.Dimension,objVesselDetails.Owner,objVesselDetails.Managers,
                objVesselDetails.Mortgagees ,objVesselDetails.InceptionDate,objVesselDetails.ExpiryDate,  objVesselDetails.UserID,objVesselDetails.GT,objVesselDetails.RegisteredLength,objVesselDetails.RegisteredBreadth, objVesselDetails.RegisteredDepth,objVesselDetails.NoOfCarry , objVesselDetails.RegisteredPlate,objVesselDetails.HMValue,objVesselDetails.IV};
            return dataAccess.LoadDataSet(parametes, "RI_CN_VesselDetailsInsertUpdate", "RIVesselDetailsInsertUpdate");
        }

        public DataSet SaveVesselDetails_Section(clsSectionDetails  objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { objVesselDetails.RefNo, objVesselDetails.PolicyId, objVesselDetails.PolVersionId, 
                objVesselDetails.MainClassID , objVesselDetails.SubClassID , objVesselDetails.SumInsured,
             objVesselDetails.Currency ,objVesselDetails.Rate,objVesselDetails.Loading,
             objVesselDetails.Premium,objVesselDetails.BillingParty,  objVesselDetails.UserID,objVesselDetails.PageMode,
             objVesselDetails.Share,objVesselDetails.UnderWriterCode, objVesselDetails.Remarks, objVesselDetails.Deductible,objVesselDetails.LayUpReturn  };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyVessel_SectionDetailsInsertUpdate", "PolicyVesselSectionDetailsInsertUpdate");
        }

        public DataSet SaveRIVesselDetails_Section(clsSectionDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[13] { objVesselDetails.RefNo, objVesselDetails.TranRefNo, objVesselDetails.CoverNoteNo, 
                objVesselDetails.MainClassID , objVesselDetails.SubClassID , objVesselDetails.SumInsured,
             objVesselDetails.Currency ,objVesselDetails.Rate,objVesselDetails.Loading,
             objVesselDetails.Premium,objVesselDetails.BillingParty,  objVesselDetails.UserID,objVesselDetails.PageMode  };
            return dataAccess.LoadDataSet(parametes, "RI_CN_PolicyVessel_SectionDetailsInsertUpdate", "RIVesselSectionDetailsInsertUpdate");
        }
        public DataSet SaveVesselDetails_Underwriter(clsVesselUWDetails  objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[6] { objVesselDetails.RefNo, objVesselDetails.PolicyID , objVesselDetails.PolicyVerID, 
                objVesselDetails.UWName  , objVesselDetails.UWCode ,objVesselDetails.PageMode  };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyVessel_UWDetailsInsertUpdate", "PolicyVesselUWDetailsInsertUpdate");
        }

        public DataSet CheckDetailsForUnderwriter(clsVesselUWDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[] { objVesselDetails.PolicyID , objVesselDetails.PolicyVerID, 
                objVesselDetails.UWCode,objVesselDetails.RefNo,objVesselDetails.SubClassId };
            return dataAccess.LoadDataSet(parametes, "P_UpdateUWDetailsVessel", "P_UpdateUWDetailsVessel");
        }

        public DataSet DeleteVesselDetails_Underwriter(clsVesselUWDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objVesselDetails.RefNo, objVesselDetails.PolicyID , objVesselDetails.PolicyVerID};
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyVessel_UWDetailsDelete", "PolicyVesselUWDetailsDelete");
        }
        
        public DataSet GetVesselDetails(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objVesselDetails.PolicyId, objVesselDetails.PolVersionId, objVesselDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_VesselDetails", "PolicyVesselDetails");
        }
        public DataSet GetRIVesselDetails(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objVesselDetails.TranRefNo, objVesselDetails.CoverNoteNo, objVesselDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "RI_CN_Policy_VesselDetails", "RIVesselDetails");
        }

        public DataSet GetVesselSectionDetails(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objVesselDetails.PolicyId, objVesselDetails.PolVersionId, objVesselDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_Pol_LoadPolicyVessel_SectionDetails", "PolicyVesselSectionDetails");
        }

        public DataSet GetRIVesselSectionDetails(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objVesselDetails.TranRefNo, objVesselDetails.CoverNoteNo, objVesselDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "RI_CN_LoadPolicyVessel_SectionDetails", "RIVesselSectionDetails");
        }

        public DataSet GetVesselUWDetails(int policyid,int policyverid,string refno)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { policyid,policyverid,refno  };
            return dataAccess.LoadDataSet(parametes, "P_Pol_LoadPolicyVessel_UWDetails", "PolicyVesselUWDetails");
        }
        public DataSet GetVesselCWEDetails(string refno,int policyid, int policyverid,string type ,int uwid)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[5] {refno, policyid, policyverid,type ,uwid};
            return dataAccess.LoadDataSet(parametes, "P_Policy_Vessel_Condition_Warranty_ExclusionDetailsSelect", "PolicyVesselCWEDetails");
        }

        public DataSet GetRIVesselCWEDetails(string refno, string TranRefNo, string CoverNoteNo, string type)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[4] { refno, TranRefNo, CoverNoteNo, type };
            return dataAccess.LoadDataSet(parametes, "RI_CN_Vessel_Condition_Warranty_ExclusionDetailsSelect", "PolicyVesselCWEDetails");
        }

        public DataSet DeleteVesselDetails(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objVesselDetails.PolicyId, objVesselDetails.PolVersionId, objVesselDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_VesselDetails_Delete", "PolicyVesselDetails");
        }
        public DataSet ResetVesselDetails(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objVesselDetails.PolicyId, objVesselDetails.PolVersionId, objVesselDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyVessel_VesselDetails_Reset", "PolicyVesselUWDetailsDelete");
        }
        public DataSet DeleteRIVesselDetails(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objVesselDetails.TranRefNo, objVesselDetails.CoverNoteNo, objVesselDetails.RefNo };
            return dataAccess.LoadDataSet(parametes, "RI_CN_Policy_VesselDetails_Delete", "RIVesselDetails");
        }
        public DataSet GetBindVesselDetails(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objVesselDetails.PolicyId, objVesselDetails.PolVersionId ,objVesselDetails.VesselName };
            return dataAccess.LoadDataSet(parametes, "P_Pol_Policy_VesselDetailsBind", "PolicyVesselDetailsBind");
        }

        public DataSet GetBindRIVesselDetails(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parametes = new Object[3] { objVesselDetails.TranRefNo, objVesselDetails.CoverNoteNo, objVesselDetails.VesselName };
            return dataAccess.LoadDataSet(parametes, "RI_CN_Policy_VesselDetailsBind", "RIVesselDetailsBind");
        }

        public DataSet GetVesselConditionWarrantyMajorExclDetails(clsVesselConditionWarrantyMajorExclDetails objvessel,int templateid)
        {
            dataAccess = new DataAccess();
            object[] parametes = new object[6] { objvessel.PolicyID,objvessel.PolicyVerID,objvessel.frmFor,objvessel.RefNo ,objvessel.UnderwriterId , templateid   };
            return dataAccess.LoadDataSet(parametes, "P_Policy_Vessel_Condition_Warranty_ExclusionDetails", "PolicyVesselCWEBind");
        }

        public DataSet GetRIVesselConditionWarrantyMajorExclDetails(clsVesselConditionWarrantyMajorExclDetails objvessel, int templateid)
        {
            dataAccess = new DataAccess();
            object[] parametes = new object[3] { objvessel.TranRefNo, objvessel.CoverNoteNo, objvessel.frmFor};
            return dataAccess.LoadDataSet(parametes, "RI_CN_Vessel_Condition_Warranty_ExclusionDetails", "PolicyVesselCWEBind");
        }

        public DataSet SaveVesselConditionWarrantyMajorExclDetails( clsVesselConditionWarrantyMajorExclDetails objvesselDetails)
        {
            dataAccess = new DataAccess();
            object[] parametes = new object[11] { objvesselDetails.RefNo ,objvesselDetails.PolicyID,objvesselDetails.PolicyVerID,objvesselDetails.HeaderID,
            objvesselDetails.ConditionHeader,objvesselDetails.Description ,objvesselDetails.frmFor,objvesselDetails.UserID,objvesselDetails.PageMode ,objvesselDetails.UnderwriterId,
            objvesselDetails.IsChecked };
            return dataAccess.LoadDataSet(parametes, "P_Pol_PolicyVessel_ConditionWarrantyExclDetailsInsertUpdate", "PolicyVesselCWEInsert");
        }
        public DataSet SaveRIVesselConditionWarrantyMajorExclDetails(clsVesselConditionWarrantyMajorExclDetails objvesselDetails)
        {
            dataAccess = new DataAccess();
            object[] parametes = new object[9] { objvesselDetails.RefNo ,objvesselDetails.PolicyID,objvesselDetails.PolicyVerID,objvesselDetails.HeaderID,
            objvesselDetails.ConditionHeader,objvesselDetails.Description ,objvesselDetails.frmFor,objvesselDetails.UserID,objvesselDetails.PageMode };
            return dataAccess.LoadDataSet(parametes, "RI_CN_PolicyVessel_ConditionWarrantyExclDetailsInsertUpdate", "RIVesselCWEInsert");
        }
        public DataSet GetUWSharePercentTotal(clsVesselDetails objvessel)
        {
            dataAccess = new DataAccess();
            object[] parametes = new object[4] { objvessel.PolicyId, objvessel.PolVersionId, objvessel.COI, objvessel.frmFor };
            return dataAccess.LoadDataSet(parametes, "P_Validate_SharePercent_UNW", "Pol_PolicyVessel_SectionDetails");
        }
        public DataSet InsertBatchUploadVessel(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[7] { objVesselDetails.RefNo, objVesselDetails.FileName, objVesselDetails.FileType, objVesselDetails.UploadedBy, objVesselDetails.PolicyId, objVesselDetails.PolVersionId, objVesselDetails.frmFor };
            return dataAccess.LoadDataSet(parameters, "P_Vessel_BatchUploadInsert", "Vessel_BatchUploadInsert");
        }
        public DataSet UpdateBatchUploadVessel(clsVesselDetails objVesselDetails)
        {
            return UpdateBatchUploadVessel(objVesselDetails, "");
        }
        public DataSet UpdateBatchUploadVessel(clsVesselDetails objVesselDetails, string strConString)
        {
            if (strConString.Trim() != "")
                dataAccess = new DataAccess(strConString, "");
            else
                dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objVesselDetails.RefNo, objVesselDetails.FilePath, objVesselDetails.Source, objVesselDetails.TotalRecord, objVesselDetails.SuccessRecord, objVesselDetails.FailRecord };
            return dataAccess.LoadDataSet(parameters, "P_Vessel_BatchUploadUpdate", "Vessel_BatchUploadUpdate");
        }
        public DataSet GetVesselBatchFileUploadList(clsVesselDetails objVesselDetails)
        {
            return GetVesselBatchFileUploadList(objVesselDetails, "");
        }
        public DataSet GetVesselBatchFileUploadList(clsVesselDetails objVesselDetails, string strConString)
        {
            if (strConString.Trim() != "")
                dataAccess = new DataAccess(strConString, "");
            else
                dataAccess = new DataAccess();
            Object[] parameters = new Object[7] { objVesselDetails.FileName, objVesselDetails.RefNo, objVesselDetails.UploadFromDate, objVesselDetails.UploadToDate, objVesselDetails.frmFor, objVesselDetails.PolicyId, objVesselDetails.PolVersionId };
            return dataAccess.LoadDataSet(parameters, "P_Vessel_BatchUploadList", "Vessel_BatchUploadList");
        }
        public DataSet GetVesselData(clsVesselDetails objVesselDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objVesselDetails.RefNo, objVesselDetails.PolicyId, objVesselDetails.PolVersionId };
            return dataAccess.LoadDataSet(parameters, "Get_VesselData", "Vessel_UploadDownload");
        }
    }
}
