using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.RIBrokingModule.Invoice;
using BusinessObjectLayer.RIBrokingModule.CoverNote;

namespace BusinessAccessLayer.RIBrokingModule.Invoice
{
    public class RIInvoiceManager
    {
        DataAccess dataAccess = new DataAccess();
        public DataSet InvoiceSearchLoadInitialValues()
        {
            Object[] parametes = new Object[0];
            return dataAccess.LoadDataSet(parametes, "P_RIINV_Search_LoadInitialValues", "LoadInitialValues");
        }
        public DataSet GetCoverNoteForInvoice(RIInvoiceSearch objRIInvoiceSearch)
        {
            Object[] parametes  =   new Object[]
                                    {
                                        objRIInvoiceSearch.CoverNoteNo,
                                        objRIInvoiceSearch.CedantCode,
                                        objRIInvoiceSearch.CedantName,
                                        objRIInvoiceSearch.ReinsuredCode,
                                        objRIInvoiceSearch.ReinsuredName,
                                        objRIInvoiceSearch.ClientCode,
                                        objRIInvoiceSearch.ClientName,
                                        objRIInvoiceSearch.CedantPolicyNo,
                                        objRIInvoiceSearch.Project,
                                        objRIInvoiceSearch.MainClass,
                                        objRIInvoiceSearch.Handler,
                                        objRIInvoiceSearch.CreatedBy,
                                        objRIInvoiceSearch.From,
                                        objRIInvoiceSearch.InvoiceNo,
                                        objRIInvoiceSearch.Status,
                                        objRIInvoiceSearch.FromDate,
                                        objRIInvoiceSearch.ToDate,
                                        objRIInvoiceSearch.RISlipNo
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_CoverNoteSearch", "CoverNoteSearch");
        }
        public DataSet GetInvoiceSummary(string strTranRefNo, string struserId)
        {
            Object[] parametes = new Object[]
                                    {
                                        strTranRefNo,struserId
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_GetSummaryDetails", "GetSummaryDetails");
        }


        public DataSet GetReinsurerInvoiceSummary(string strTranRefNo, string struserId,string Pcode)
        {
            Object[] parametes = new Object[]
                                    {
                                        strTranRefNo,struserId,Pcode 
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_Reinsurer_GetSummaryDetails", "GetRISummaryDetails");
        }
        public DataSet UpdateInvoiceSummary(RIInvoiceSummary objInvoiceSummary)
        {
            Object[] parametes = new Object[]
                                    {
                                        objInvoiceSummary.TranRefNo,
                                        objInvoiceSummary.Remarks,
                                        objInvoiceSummary.UserId
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_UpdateSummaryDetails", "UpdateSummaryDetails");
        }


        //for saving Cedant details
        public DataSet InsertUpdateCedantInvoiceSummary(RIInvoiceCedantSummary  objInvoiceCedant)
        {
            Object[] parametes = new Object[]
                                    {
                         objInvoiceCedant.TranRefNo,
                         objInvoiceCedant.CedantCode ,
                         objInvoiceCedant.CedantName,
                         objInvoiceCedant.ClassID ,
                         objInvoiceCedant.Currency ,
                         objInvoiceCedant.TotalPremium,
                         objInvoiceCedant.VATper,
                         objInvoiceCedant.VATAmount,
                         objInvoiceCedant.DirectCommPer ,
                         objInvoiceCedant.DirectCommAmount ,
                         objInvoiceCedant.TotalPaybleAmount ,
                         objInvoiceCedant.UserId,
                         objInvoiceCedant.SubClassName,
                         objInvoiceCedant.SubClassCode 
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_InsertUpdate_CedantSummaryDetails", "UpdateCedantSummaryDetails");
        }
        //end

        //for saving Reinsurer details//
        public DataSet InsertUpdateRIInvoiceSummary(RIInvoiceRISummary objInvoiceRI)
        {
            Object[] parametes = new Object[]
                                    {
                         objInvoiceRI.TranRefNo,
                         objInvoiceRI.RICode,
                         objInvoiceRI.RIName ,
                         objInvoiceRI.RIType,
                         objInvoiceRI.ClassID ,
                         objInvoiceRI.Currency ,
                         objInvoiceRI.RISharePer ,
                         objInvoiceRI.RIPremium,
                         objInvoiceRI.VATPer ,
                         objInvoiceRI.VATAmount ,
                         objInvoiceRI.WHTPer ,
                         objInvoiceRI.WHTAmount ,
                         objInvoiceRI.DirectCommPer,
                         objInvoiceRI.DirectCommAmount ,
                         objInvoiceRI.RICommPer ,
                         objInvoiceRI.RICommAmount,
                         objInvoiceRI.VATAmountNew ,
                         objInvoiceRI.WHTAmountNew,
                         objInvoiceRI.NetPayable,
                         objInvoiceRI.UserId ,
                         objInvoiceRI.SubClassName ,
                         objInvoiceRI.SubClassCode
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_InsertUpdate_RISummaryDetails", "UpdateRISummaryDetails");
        }
        //end


        public DataSet GetInvoiceClientSummary(string strTranRefNo, string struserId)
        {
            Object[] parametes = new Object[]
                                    {
                                        strTranRefNo,struserId
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_GetClinetSummaryDetails", "GetClientSummaryDetails");
        }
        public DataSet UpdateClientInstalment(string strTranRefNo, string struserId,string strInstCount)
        {
            Object[] parametes = new Object[]
                                    {
                                        strTranRefNo,struserId,strInstCount
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_UpdateClientInstalment", "UpdateClientInstalment");
        }
        public DataSet LoadReInsurerInitialValues(RIReinsuerSummary ObjRIReinsuerSummary)
        {
            Object[] parametes = new Object[]
                                    {
                                        ObjRIReinsuerSummary.TranRefNo,
                                        ObjRIReinsuerSummary.UserId
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_LoadReInsurerInitialValues", "LoadReInsurerInitialValues");
        }

        //for fetch the Premium Reserve Data

        public DataSet LoadReInsurerPremiumReserve(RIReinsuerSummary ObjRIReinsuerSummary)
        {
            Object[] parametes = new Object[]
                                    {
                                        ObjRIReinsuerSummary.TranRefNo,
                                        ObjRIReinsuerSummary.RICode 
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_GetPremiumReserveData", "LoadReInsurerPremReserve");
        }


        public DataSet DeletePremiumReserveData(RIReinsuerSummary ObjRIReinsuerSummary)
        {
            Object[] parametes = new Object[]
                                    {
                                        ObjRIReinsuerSummary.TranRefNo,
                                           ObjRIReinsuerSummary.RICode ,
                                        ObjRIReinsuerSummary.ID 
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_Delete_PremiumReserveData", "DeleteReInsurerPremReserve");
        }

        //end

        
        public DataSet LoadReInsurerSummary(RIReinsuerSummary ObjRIReinsuerSummary)
        {
            Object[] parametes = new Object[]
                                    {
                                        ObjRIReinsuerSummary.TranRefNo,
                                        ObjRIReinsuerSummary.UserId,
                                        ObjRIReinsuerSummary.ReinsuerCode
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_LoadReInsurerSummary", "LoadReInsurerSummary");
        }
        public DataSet UpdateReInsurerRemarks(RIReinsuerSummary ObjRIReinsuerSummary)
        {
            Object[] parametes = new Object[]
                                    {
                                        ObjRIReinsuerSummary.TranRefNo,
                                        ObjRIReinsuerSummary.UserId,
                                        ObjRIReinsuerSummary.ReinsuerCode,
                                        ObjRIReinsuerSummary.Remarks
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_UpdateReInsurerRemarks", "UpdateReInsurerRemarks");
        }


        //added for saving the data of Premium Reserve
        public DataSet InsertUpdateReInsurerPremiumReserve(RIReinsuerSummary ObjRIReinsuerSummary)
        {
            Object[] parametes = new Object[]
                                    {
                ObjRIReinsuerSummary.ID ,                      
                ObjRIReinsuerSummary.TranRefNo ,
                ObjRIReinsuerSummary.RICode,
                ObjRIReinsuerSummary.RIName ,
                ObjRIReinsuerSummary.RISharedPremium ,
                ObjRIReinsuerSummary.PremiumReserve,
                ObjRIReinsuerSummary.InterestRate ,
                ObjRIReinsuerSummary.Frequency ,
                ObjRIReinsuerSummary.ReleaseDate ,
                ObjRIReinsuerSummary.UserId
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_InsertUpdateReInsurer_PremiumReserve", "InsertUpdateReInsurer_PremiumReserve");
        }
        //end



        public DataSet UpdateReInsurerInstalment(RIReinsuerSummary ObjRIReinsuerSummary)
        {
            Object[] parametes = new Object[]
                                    {
                                        ObjRIReinsuerSummary.TranRefNo,
                                        ObjRIReinsuerSummary.ReinsuerCode,
                                        ObjRIReinsuerSummary.InstNo,
                                        ObjRIReinsuerSummary.Deduction,
                                        ObjRIReinsuerSummary.NetPremium
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_UpdateReInsurerInstalment", "UpdateReInsurerInstalment");
        }
        public DataSet GetReinsurerInstallments(RIReinsuerSummary ObjRIReinsuerSummary)
        {
            Object[] parametes = new Object[]
                                    {
                                        ObjRIReinsuerSummary.TranRefNo,
                                        ObjRIReinsuerSummary.ReinsuerCode
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_GetReinsurerInstallment", "GetReinsurerInstallment");
        }
        public DataSet LoadReferralInitialValues(string strTranRefNo)
        {
            Object[] parametes = new Object[]{strTranRefNo};
            return dataAccess.LoadDataSet(parametes, "P_RIINV_LoadReferralInitialValues", "LoadReInsurerInitialValues");
        }

        public DataSet LoadReferralSummary(RIReferralSummary ObjRIReferralSummary)
        {
            Object[] parametes = new Object[]
                                    {
                                        ObjRIReferralSummary.TranRefNo,
                                        ObjRIReferralSummary.ReferralCode
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_LoadReferralSummary", "LoadReferralSummary");
        }
        public DataSet LoadAccountsSectionSummary(RIInvoiceAccountsSection ObjAccountsSection)
        {
            Object[] parametes = new Object[]
                                    {
                                        ObjAccountsSection.TranRefNo,
                                        ObjAccountsSection.UserId 
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_GetAccountsSectionSummary", "AccountsSectionSummary");
        }
        public DataSet UpdateAccountsSectionSummary(RIInvoiceAccountsSection ObjAccountsSection)
        {
            Object[] parametes = new Object[]
                                    {
                                        ObjAccountsSection.TranRefNo,
                                        ObjAccountsSection.SpreadPeriodFrom,
                                        ObjAccountsSection.SpreadPeriodTo,
                                        ObjAccountsSection.Lock,
                                        ObjAccountsSection.Export,
                                        ObjAccountsSection.UserId 
                                    };
            return dataAccess.LoadDataSet(parametes, "P_RIINV_GetAccountsSectionSummaryUpdate", "AccountsSectionSummaryUpdate");
        }

        public DataSet InvoiceGetUploadedFileList(string strCode)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { strCode };
            return dataAccess.LoadDataSet(parameters, "P_RIINV_FileAttachmentList", "FileAttachment");
        }
        public DataSet InvoiceDeleteFile(ClsFileAttachment objFileAttachment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objFileAttachment.TranRefNo, objFileAttachment.ID };
            return dataAccess.LoadDataSet(parameters, "P_RIINV_FileAttachmentDelete", "FileAttachment");
        }
        public DataSet InvoiceFileUpload(ClsFileAttachment objFileAttachment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { 
                        objFileAttachment.TranRefNo,
                        objFileAttachment.SavedFileName, 
                        objFileAttachment.FileName, 
                        objFileAttachment.FileType, 
                        objFileAttachment.Remarks, 
                        objFileAttachment.UserId,
                        objFileAttachment.UploadFolderPath };
            return dataAccess.LoadDataSet(parameters, "P_RIINV_FileAttachment", "FileAttachment");
        }

        public DataSet GetInvoioceNo(string strCode)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { strCode };
            return dataAccess.LoadDataSet(parameters, "P_RIINV_GetInvoiceNo", "GetInvoiceNo");
        }
        public DataSet ComplteInvoioce(string strCode,string strUserId)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { strCode, strUserId };
            return dataAccess.LoadDataSet(parameters, "P_RIINV_CompleteInvoice", "GetInvoiceNo");
        }
    }
}
