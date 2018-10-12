using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits;
namespace BusinessAccessLayer.BrokingModule.BrokingSystem.EmployeeBenefits
{
    public class EBMemberManager
    {
        DataAccess dataAccess = null;
        public EBMemberManager() 
        { 

        }
        public DataSet InsertUpdateMemberDetails(clsEBMemberDetails objEBMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[31] { objEBMemberDetails.PageMode,objEBMemberDetails.CaseRefNo,objEBMemberDetails.MemberCode,objEBMemberDetails.ClientCode,objEBMemberDetails.ClientName,	   
                            objEBMemberDetails.MemberStatusCode ,objEBMemberDetails.MemberStatusDesc, objEBMemberDetails.Prev_MemberCode,objEBMemberDetails.MemberName, objEBMemberDetails.CardMemberName ,	
                            objEBMemberDetails.PassportNo , objEBMemberDetails.DateofBirth,objEBMemberDetails.Gender,objEBMemberDetails.MaritalStatus,objEBMemberDetails.NationalityCode,objEBMemberDetails.Nationality,objEBMemberDetails.StaffID,objEBMemberDetails.LocationCode, objEBMemberDetails.Location ,			
                            objEBMemberDetails.OccupationCode,objEBMemberDetails.OccupationDesc,objEBMemberDetails.BeneficiaryCode,objEBMemberDetails.BeneficiaryDesc,objEBMemberDetails.Position ,objEBMemberDetails.VIPPrivilegeCode,objEBMemberDetails.VIPPrivilegeDesc,	
                            objEBMemberDetails.Remarks,objEBMemberDetails.Salary,objEBMemberDetails.UserID ,objEBMemberDetails.CertificateNo,objEBMemberDetails.DeptType };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDetailsInsertUpdate", "MemberDetailsInsertUpdate");
        }
        //public DataSet InsertUpdateMemberDetails(clsEBMemberDetails objEBMemberDetails)
        //{
        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[34] { objEBMemberDetails.PageMode,objEBMemberDetails.CaseRefNo,objEBMemberDetails.MemberCode,objEBMemberDetails.ClientCode,objEBMemberDetails.ClientName,	   
        //                    objEBMemberDetails.MemberStatusCode ,objEBMemberDetails.MemberStatusDesc, objEBMemberDetails.Prev_MemberCode,objEBMemberDetails.MemberName, objEBMemberDetails.CardMemberName ,	
        //                    objEBMemberDetails.PassportNo , objEBMemberDetails.DateofBirth,objEBMemberDetails.Gender,objEBMemberDetails.MaritalStatus,objEBMemberDetails.NationalityCode,objEBMemberDetails.Nationality,objEBMemberDetails.StaffID,objEBMemberDetails.LocationCode, objEBMemberDetails.Location ,			
        //                    objEBMemberDetails.OccupationCode,objEBMemberDetails.OccupationDesc,objEBMemberDetails.BeneficiaryCode,objEBMemberDetails.BeneficiaryDesc,objEBMemberDetails.Position ,objEBMemberDetails.DateOfEmployment,objEBMemberDetails.VIPPrivilegeCode,objEBMemberDetails.VIPPrivilegeDesc,	
        //                    objEBMemberDetails.Remarks,objEBMemberDetails.EffectiveDate,objEBMemberDetails.TerminationDate,objEBMemberDetails.ReJoinDate,objEBMemberDetails.Salary,objEBMemberDetails.UserID ,objEBMemberDetails.CertificateNo};
        //    return dataAccess.LoadDataSet(parameters, "P_EB_MemberDetailsInsertUpdate", "MemberDetailsInsertUpdate");
        //}
        public DataSet InsertUpdateVoidMemberDetails(clsEBMemberDetails objEBMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] {objEBMemberDetails.CaseRefNo,objEBMemberDetails.MemberCode,objEBMemberDetails.Remarks,objEBMemberDetails.UserID};
            return dataAccess.LoadDataSet(parameters, "P_EB_VoidMemberInsertUpdate", "VoidMemberInsertUpdate");
        }
        public DataSet InsertSuspensionMember(clsEBMemberSuspension objEBMemberSuspension)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[9] { objEBMemberSuspension.CaseRefNo, objEBMemberSuspension.MemberCode, objEBMemberSuspension.SuspFromDate, 
                                objEBMemberSuspension.SuspReason, objEBMemberSuspension.SuspToDate, objEBMemberSuspension.CancelSuspDate, objEBMemberSuspension.CancelSuspReason, 
                                objEBMemberSuspension.UpdatedBY, objEBMemberSuspension.CalledFrom };
            return dataAccess.LoadDataSet(parameters, "EB_Suspension", "EBSuspension");
        }
        public DataSet InsertTerminateMember(clsEBMemberDetails objEBMemberSuspension)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[8] { objEBMemberSuspension.CaseRefNo, objEBMemberSuspension.MemberCode, objEBMemberSuspension.TerminationDate, 
                                objEBMemberSuspension.TerminateReason, objEBMemberSuspension.ReinstateDate, objEBMemberSuspension.ReinstateReason, 
                                objEBMemberSuspension.UpdatedBY, objEBMemberSuspension.CalledFrom };
            return dataAccess.LoadDataSet(parameters, "EB_TerminationDetails", "EBTerminationDetails");
        }
        public DataSet SelectSuspensionMember(clsEBMemberSuspension objEBMemberSuspension)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBMemberSuspension.CaseRefNo, objEBMemberSuspension.MemberCode };
            return dataAccess.LoadDataSet(parameters, "EB_SuspensionDetails", "EBSuspensionDetails");
        }
        public DataSet UpdateMemberStatus(clsEBMemberDetails objEBMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBMemberDetails.CaseRefNo,objEBMemberDetails.MemberCode,objEBMemberDetails.MemberStatusDesc,objEBMemberDetails.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberStatusUpdate", "EB_MemberStatusUpdate");
        }
        public DataSet GetMemberDetails(clsEBMemberDetails objEBMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBMemberDetails.CaseRefNo,objEBMemberDetails.MemberCode};
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDetails", "EB_MemberDetails");
        }
        public DataSet InsertUpdateMemberOrganisation(clsEBMemberOrganisation objEBMemberOrganisation)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[13] { objEBMemberOrganisation.CaseRefNo, objEBMemberOrganisation.MemberCode, objEBMemberOrganisation.SubsidiaryCode, objEBMemberOrganisation.SubsidiaryDescription, objEBMemberOrganisation.SubsidiaryEffectiveFromDate, objEBMemberOrganisation.DepartmentCode, objEBMemberOrganisation.DepartmentName, objEBMemberOrganisation.DepartmentEffectiveFromDate, objEBMemberOrganisation.ClassificationCode, objEBMemberOrganisation.ClassificationDescription, objEBMemberOrganisation.ClassificationEffectiveFromDate, objEBMemberOrganisation.UserID, objEBMemberOrganisation.CostCenter };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberOrganisationInsertUpdate", "EB_MemberOrganisationInsertUpdate");
        }
        public DataSet GetMemberOrganisationDetails(clsEBMemberOrganisation objEBMemberOrganisation)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBMemberOrganisation.CaseRefNo, objEBMemberOrganisation.MemberCode };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberOrganisationDetails", "EB_MemberOrganisationDetails");
        }
        public DataSet InsertUpdateMemberRegistration(clsEBMemberRegistration objEBMemberRegistration)
        { 
            dataAccess = new DataAccess();
            Object[] parameters = new Object[32] {  objEBMemberRegistration.CaseRefNo ,objEBMemberRegistration.MemberCode,objEBMemberRegistration.RefNo, objEBMemberRegistration.CoverNoteNo, objEBMemberRegistration.ClassId, objEBMemberRegistration.Class, objEBMemberRegistration.ClientDate,objEBMemberRegistration.ReceivedDate,
                                                    objEBMemberRegistration.PolicyNo,objEBMemberRegistration.SendOutDate,objEBMemberRegistration.POIFromDate,objEBMemberRegistration.POIToDate,objEBMemberRegistration.UWDate,objEBMemberRegistration.ActivationDate,objEBMemberRegistration.CardDispatchDate,objEBMemberRegistration.DebitCreditNoteNo,
                                                    objEBMemberRegistration.UwriterCode,objEBMemberRegistration.UwriterName,objEBMemberRegistration.UwriterBillNo,objEBMemberRegistration.CardNo,objEBMemberRegistration.AICNo,objEBMemberRegistration.CurrentCoverageCode,objEBMemberRegistration.CurrentCoverageDescription ,
                                                    objEBMemberRegistration.BenefitScheduleCode,objEBMemberRegistration.BenefitScheduleDesc, objEBMemberRegistration.PlanCode,objEBMemberRegistration.PlanDescription,objEBMemberRegistration.AccommodationLevelCode,objEBMemberRegistration.AccommodationLevelDesc,objEBMemberRegistration.EffectiveDate,objEBMemberRegistration.ExpiryDate,objEBMemberRegistration.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberRegistrationInsertUpdate", "EB_MemberOrganisationInsertUpdate");            
        }
        public DataSet InsertUpdateMemberRegistration_MM(clsEBMemberRegistration objEBMemberRegistration)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[20] { objEBMemberRegistration.UserID, objEBMemberRegistration.CaseRefNo ,objEBMemberRegistration.MemberCode,objEBMemberRegistration.RefNo, objEBMemberRegistration.CoverNoteNo, objEBMemberRegistration.PolicyNo, objEBMemberRegistration.ClassId, objEBMemberRegistration.Class, 
                                                    objEBMemberRegistration.BenefitScheduleCode,objEBMemberRegistration.BenefitScheduleDesc, objEBMemberRegistration.POIFromDate,objEBMemberRegistration.POIToDate, objEBMemberRegistration.CurrentCoverageCode,objEBMemberRegistration.CurrentCoverageDescription ,
                                                    objEBMemberRegistration.AccommodationLevelCode,objEBMemberRegistration.AccommodationLevelDesc,objEBMemberRegistration.PlanCode,objEBMemberRegistration.EmploymentDate, objEBMemberRegistration.IsDependent, objEBMemberRegistration.PlanDescription };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberRegistrationInsertUpdate_MM", "MemberRegistrationInsertUpdate_MM");
        }
        public DataSet InsertUpdateMemberMovement(clsEBMemberRegistration objEBMemberRegistration)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[16] {objEBMemberRegistration.MemberMovementId, objEBMemberRegistration.CoverNoteNo, objEBMemberRegistration.MMParam, objEBMemberRegistration.CaseRefNo ,objEBMemberRegistration.MemberCode,objEBMemberRegistration.RefNo, objEBMemberRegistration.EN_EffectiveDate, objEBMemberRegistration.EN_AdjustmentRepNo, objEBMemberRegistration.EN_DateFromClient,
                                                    objEBMemberRegistration.EN_AdjRepFromUW,objEBMemberRegistration.EN_DateToUW, objEBMemberRegistration.EN_AdjRepToCL,objEBMemberRegistration.EN_CardNo,objEBMemberRegistration.EN_CardDisDate, objEBMemberRegistration.EN_Remarks,objEBMemberRegistration.UserID };
            return dataAccess.LoadDataSet(parameters, "EB_InsertUpdateMemberMovement_Detail", "InsertUpdateMemberMovement");
        }
        public DataSet UpdateMemberMovement_Enrollment(clsEBMemberRegistration objEBMemberRegistration)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[13] {   objEBMemberRegistration.CoverNoteNo, objEBMemberRegistration.CaseRefNo ,objEBMemberRegistration.MemberCode,objEBMemberRegistration.RefNo, objEBMemberRegistration.EN_EffectiveDate, objEBMemberRegistration.EN_AdjustmentRepNo, objEBMemberRegistration.EN_DateFromClient,
                                                    objEBMemberRegistration.EN_AdjRepFromUW,objEBMemberRegistration.EN_DateToUW, objEBMemberRegistration.EN_AdjRepToCL,objEBMemberRegistration.EN_CardNo,objEBMemberRegistration.EN_CardDisDate,objEBMemberRegistration.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EB_UpdateMemberMovement_Enrollment", "P_EB_UpdateMemberMovement_Enrollment");
        }
        public DataSet GetMemberRegistrationDetails(clsEBMemberRegistration objEBMemberRegistration)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBMemberRegistration.CaseRefNo, objEBMemberRegistration.MemberCode, objEBMemberRegistration.RefNo, objEBMemberRegistration.CoverNoteNo};
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberRegistrationDetails", "EB_MemberRegistrationDetails");
        }
        public DataSet GetMemberEnrollmentDetails(clsEBMemberRegistration objEBMemberRegistration)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBMemberRegistration.CaseRefNo, objEBMemberRegistration.MemberCode, objEBMemberRegistration.RefNo, objEBMemberRegistration.CoverNoteNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberEnrollmentDetails", "EB_MemberEnrollmentDetails");
        }
        public DataSet GetMemberMovementDetails(clsEBMemberRegistration objEBMemberRegistration)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objEBMemberRegistration.MemberMovementId, objEBMemberRegistration.CaseRefNo, objEBMemberRegistration.MemberCode, objEBMemberRegistration.RefNo, objEBMemberRegistration.CoverNoteNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberMovementDetails", "EB_MemberMovementDetails");
        }
        public DataSet DeleteMemberRegistrationDetails(clsEBMemberRegistration objEBMemberRegistration)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBMemberRegistration.CaseRefNo, objEBMemberRegistration.MemberCode, objEBMemberRegistration.RefNo};
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberRegistrationDelete", "EB_MemberRegistrationDelete");
        }
        public DataSet InsertUpdateMemberRegistrationFileUpload(clsEBMemberRegistrationFileUpload objEBMemberRegistrationFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[8] { objEBMemberRegistrationFileUpload.CaseRefNo, objEBMemberRegistrationFileUpload.MemberCode, objEBMemberRegistrationFileUpload.MemberRefNo, objEBMemberRegistrationFileUpload.RefNo, objEBMemberRegistrationFileUpload.FileName, objEBMemberRegistrationFileUpload.FileType, objEBMemberRegistrationFileUpload.Remarks, objEBMemberRegistrationFileUpload.UploadBy};
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberRegistrationFileUploadInsertUpdate", "EB_MemberRegistrationDetails");
        }
        public DataSet GetMemberRegistrationFileUpload(clsEBMemberRegistrationFileUpload objEBMemberRegistrationFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBMemberRegistrationFileUpload.CaseRefNo, objEBMemberRegistrationFileUpload.MemberCode, objEBMemberRegistrationFileUpload.MemberRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberRegistrationFileUpload", "EB_MemberRegistrationDetails");
        }
        public DataSet DeleteMemberRegistrationFileUpload(clsEBMemberRegistrationFileUpload objEBMemberRegistrationFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBMemberRegistrationFileUpload.CaseRefNo, objEBMemberRegistrationFileUpload.MemberCode, objEBMemberRegistrationFileUpload.MemberRefNo, objEBMemberRegistrationFileUpload.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberRegistrationFileUploadDelete", "EB_MemberRegistrationFileUploadDelete");
        }
        public DataSet GetMemberRegistrationDebitNoteData(string strCoverNoteNo)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { strCoverNoteNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberRegistrationLoadCoverNoteData", "EB_MemberRegistrationLoadCoverNoteData");
        }
        public DataSet InsertUpdateMemberPayment(clsEBMemberPayment objEBMemberPayment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[13] { objEBMemberPayment.CaseRefNo, objEBMemberPayment.MemberCode, objEBMemberPayment.PaymentModeCode, objEBMemberPayment.PaymentModeDesc, objEBMemberPayment.BankAccountName, objEBMemberPayment.BankName, objEBMemberPayment.BankCode, objEBMemberPayment.BranchName, objEBMemberPayment.BranchCode, objEBMemberPayment.BankDetails, objEBMemberPayment.BankAccountNo, objEBMemberPayment.EffectiveDate, objEBMemberPayment.UserID};
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberPaymentInserUpdate", "EB_MemberRegistrationDetails");
        }
        public DataSet GetMemberPaymentDetails(clsEBMemberPayment objEBMemberPayment)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBMemberPayment.CaseRefNo, objEBMemberPayment.MemberCode };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberPaymentDetails", "EB_MemberRegistrationDetails");
        }
        public DataSet InsertUpdateMemberAddress(clsEBMemberAddress objEBMemberAddress)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[39] { objEBMemberAddress.CaseRefNo, objEBMemberAddress.MemberCode ,objEBMemberAddress.CorresPond_Address1,objEBMemberAddress.CorresPond_Address2 , objEBMemberAddress.CorresPond_Address3 ,objEBMemberAddress.CorresPond_CountryCode, objEBMemberAddress.CorresPond_CountryName ,
                                                   objEBMemberAddress.CorresPond_OfficeTelNo1 ,objEBMemberAddress.CorresPond_OfficeTelNo2	,objEBMemberAddress.CorresPond_MoblieNo1,objEBMemberAddress.CorresPond_MoblieNo2 ,objEBMemberAddress.CorresPond_FaxNo1 ,objEBMemberAddress.CorresPond_FaxNo2  ,
                                                   objEBMemberAddress.CorresPond_EffectiveFromDate ,objEBMemberAddress.CorresPond_EffectiveToDate , objEBMemberAddress.Resident_Address1 , objEBMemberAddress.Resident_Address2, objEBMemberAddress.Resident_Address3, objEBMemberAddress.Resident_CountryCode,
                                                   objEBMemberAddress.Resident_CountryName, objEBMemberAddress.Resident_OfficeTelNo1 , objEBMemberAddress.Resident_OfficeTelNo2	, objEBMemberAddress.Resident_MoblieNo1 , objEBMemberAddress.Resident_MoblieNo2, objEBMemberAddress.Resident_FaxNo1 ,objEBMemberAddress.Resident_FaxNo2,
                                                   objEBMemberAddress.Resident_EffectiveFromDate ,objEBMemberAddress.Resident_EffectiveToDate ,objEBMemberAddress.UserID, objEBMemberAddress.Coress_Email, objEBMemberAddress.Res_Email,
                                                   objEBMemberAddress.Coress_CountryId,objEBMemberAddress.Res_CountryId,
                                                   objEBMemberAddress.Coress_ProvinceId,objEBMemberAddress.Res_ProvinceId,
                                                   objEBMemberAddress.Coress_CityId,objEBMemberAddress.Res_CityId,
                                                   objEBMemberAddress.Coress_PostalCode,objEBMemberAddress.Res_PostalCode};
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberAddressInsertUpdate", "EB_MemberAddressInsertUpdate");
        }
        public DataSet GetMemberAddressDetails(clsEBMemberAddress objEBMemberAddress)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBMemberAddress.CaseRefNo, objEBMemberAddress.MemberCode };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberAddressDetails", "EB_MemberAddressDetails");
        }
        public DataSet InsertUpdateMemberUwriterbenefit(clsEBUnderwriterBenefit objEBUnderwriterBenefit)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[16] { objEBUnderwriterBenefit.CaseRefNo, objEBUnderwriterBenefit.MemberCode ,objEBUnderwriterBenefit.RefNo,objEBUnderwriterBenefit.CoverNoteNo ,objEBUnderwriterBenefit.PolicyNo,objEBUnderwriterBenefit.PolicyHolder, objEBUnderwriterBenefit.CertNo ,objEBUnderwriterBenefit.UWName ,objEBUnderwriterBenefit.Gender ,objEBUnderwriterBenefit.DateOfBirth,
                                                  objEBUnderwriterBenefit.Class,objEBUnderwriterBenefit.ExistSumInsured,objEBUnderwriterBenefit.ProposedSumInsured ,objEBUnderwriterBenefit.StatusCode,objEBUnderwriterBenefit.StatusDescription ,objEBUnderwriterBenefit.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUWriterBenefitInsertUpdate", "EB_MemberUWriterBenefit");
        }
        public DataSet GetMemberUwriterbenefit(clsEBUnderwriterBenefit objEBUnderwriterBenefit)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBUnderwriterBenefit.CaseRefNo, objEBUnderwriterBenefit.MemberCode };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUWriterBenefitDetails", "EB_MemberUWriterBenefitDetails");
        }
        public DataSet GetMemberDependantUwriterbenefit(clsEBUnderwriterBenefit objEBUnderwriterBenefit)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBUnderwriterBenefit.CaseRefNo, objEBUnderwriterBenefit.MemberCode };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDepedentUWriterBenefitDetails", "EB_MemberUWriterBenefitDetails");
        }
        public DataSet DeleteMemberUwriterbenefit(clsEBUnderwriterBenefit objEBUnderwriterBenefit)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBUnderwriterBenefit.CaseRefNo, objEBUnderwriterBenefit.MemberCode, objEBUnderwriterBenefit.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUWriterBenefitDelete", "EB_MemberUWriterBenefitDelete");
        }
        public DataSet InsertUpdateUwriterDetails(clsEBUnderwriterDetails objEBUwriterDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[30] { objEBUwriterDetails.CaseRefNo, objEBUwriterDetails.MemberCode,objEBUwriterDetails.CompleteDate,objEBUwriterDetails.Health_InsurerDate ,objEBUwriterDetails.Health_ClientDate ,objEBUwriterDetails.Health_SubmitDate, objEBUwriterDetails.Health_StatusCode,objEBUwriterDetails.Health_StatusDesc ,objEBUwriterDetails.Invitation_InsurerDate,objEBUwriterDetails.Invitation_ClientDate, 
                                                    objEBUwriterDetails.Invitation_ExamDate, objEBUwriterDetails.Invitation_StatusCode,objEBUwriterDetails.Invitation_StatusDesc ,objEBUwriterDetails.Futher_InsurerDate,objEBUwriterDetails.Futher_ClientDate ,objEBUwriterDetails.Futher_ExamSubmitDate, objEBUwriterDetails.Further_StatusCode,objEBUwriterDetails.Further_StatusDesc ,objEBUwriterDetails.First_SendOutDate  ,objEBUwriterDetails.First_ClientResponse ,objEBUwriterDetails.First_Remarks,
                                                    objEBUwriterDetails.Second_SendOutDate ,objEBUwriterDetails.Second_ClientResponse,objEBUwriterDetails.Second_Remarks,objEBUwriterDetails.Third_SendOutDate,objEBUwriterDetails.Third_CleintResponse ,objEBUwriterDetails.Third_Remarks ,objEBUwriterDetails.Folloup_Remarks,objEBUwriterDetails.UserID,objEBUwriterDetails.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUwriterDetailsInsertUpdate", "EB_MemberUwriterDetailsInsertUpdate");

        }
        public DataSet GetMemberUwriterDetails(clsEBUnderwriterDetails objEBUwriterDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBUwriterDetails.CaseRefNo, objEBUwriterDetails.MemberCode, objEBUwriterDetails.RefNo};
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUwriterDetails", "EB_MemberUwriterDetails");

        }
        public DataSet InsertUpdateUwriterDecisionDetails(clsEBUnderwriterDecision objEBUwriterDecision)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[11] { objEBUwriterDecision.CaseRefNo, objEBUwriterDecision.MemberCode,objEBUwriterDecision.RefNo,objEBUwriterDecision.UWRefNo, objEBUwriterDecision.StandardRate ,objEBUwriterDecision.StandardLoading ,objEBUwriterDecision.StandardEffectiveDate ,objEBUwriterDecision.ExclusionsApplied ,objEBUwriterDecision.ExclusionsEffectiveDate ,objEBUwriterDecision.UWRemarks ,objEBUwriterDecision.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUwriterDecisionInsertUpdate", "EB_MemberUwriterDecisionInsertUpdate");
        }
        public DataSet GetMemberUwriterDecisionDetails(clsEBUnderwriterDecision objEBUwriterDecision)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBUwriterDecision.CaseRefNo, objEBUwriterDecision.MemberCode, objEBUwriterDecision.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUwriterDecisionDetails", "EB_MemberUwriterDecisionDetails");

        }
        public DataSet DeleteMemberUwriterDecisionDetails(clsEBUnderwriterDecision objEBUwriterDecision)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBUwriterDecision.CaseRefNo, objEBUwriterDecision.MemberCode, objEBUwriterDecision.RefNo, objEBUwriterDecision.UWRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUwriterDecisionDetailsDelete", "EB_MemberUwriterDecisionDetailsDelete");

        }

        public DataSet InsertUpdateMemberUwriterFileUpload(clsEBUnderwriterFileUpload objEBMemberUWriterFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[7] { objEBMemberUWriterFileUpload.CaseRefNo, objEBMemberUWriterFileUpload.MemberCode, objEBMemberUWriterFileUpload.RefNo, objEBMemberUWriterFileUpload.FileName, objEBMemberUWriterFileUpload.FileType, objEBMemberUWriterFileUpload.Remarks, objEBMemberUWriterFileUpload.UploadBy };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUWriterFileUploadInsertUpdate", "EB_MemberUwriterDetails");
        }
        public DataSet GetMemberUwriterFileUpload(clsEBUnderwriterFileUpload objEBMemberUWriterFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBMemberUWriterFileUpload.CaseRefNo, objEBMemberUWriterFileUpload.MemberCode};
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUwriterFileUpload", "EB_MemberUwriterFileUpload");
        }
        public DataSet DeleteMemberUwriterFileUpload(clsEBUnderwriterFileUpload objEBMemberUWriterFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBMemberUWriterFileUpload.CaseRefNo, objEBMemberUWriterFileUpload.MemberCode, objEBMemberUWriterFileUpload.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUWriterFileUploadDelete", "EB_MemberUWriterFileUploadDelete");
        }
        public DataSet InsertUpdateMemberDependantDetails(clsEBMemberDependantDetails objEBMemberDependantDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[33] { objEBMemberDependantDetails.PageMode,objEBMemberDependantDetails.CaseRefNo,objEBMemberDependantDetails.MemberCode,objEBMemberDependantDetails.ClientCode,objEBMemberDependantDetails.ClientName,objEBMemberDependantDetails.DependantCode,	   
                            objEBMemberDependantDetails.DependantStatusCode ,objEBMemberDependantDetails.DependantStatusDesc, objEBMemberDependantDetails.Prev_DependantCode,objEBMemberDependantDetails.DependantName, objEBMemberDependantDetails.CardDependantName ,	objEBMemberDependantDetails.RelationShipCode, objEBMemberDependantDetails.RelationShipDesc ,
                            objEBMemberDependantDetails.PassportNo , objEBMemberDependantDetails.DateofBirth,objEBMemberDependantDetails.Gender,objEBMemberDependantDetails.MaritalStatus,objEBMemberDependantDetails.NationalityCode,objEBMemberDependantDetails.Nationality,objEBMemberDependantDetails.StaffID,objEBMemberDependantDetails.LocationCode ,objEBMemberDependantDetails.Location ,			
                            objEBMemberDependantDetails.OccupationCode,objEBMemberDependantDetails.OccupationDesc,objEBMemberDependantDetails.BeneficiaryCode,objEBMemberDependantDetails.BeneficiaryDesc,objEBMemberDependantDetails.Position ,objEBMemberDependantDetails.VIPPrivilegeCode,objEBMemberDependantDetails.VIPPrivilegeDesc,	
                            objEBMemberDependantDetails.Remarks,objEBMemberDependantDetails.Salary,objEBMemberDependantDetails.UserID,objEBMemberDependantDetails.DeptType  };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDependantDetailsInsertUpdate", "EB_MemberDependantDetailsInsertUpdate");
        }
        //public DataSet InsertUpdateMemberDependantDetails(clsEBMemberDependantDetails objEBMemberDependantDetails)
        //{
        //    dataAccess = new DataAccess();
        //    Object[] parameters = new Object[36] { objEBMemberDependantDetails.PageMode,objEBMemberDependantDetails.CaseRefNo,objEBMemberDependantDetails.MemberCode,objEBMemberDependantDetails.ClientCode,objEBMemberDependantDetails.ClientName,objEBMemberDependantDetails.DependantCode,	   
        //                    objEBMemberDependantDetails.DependantStatusCode ,objEBMemberDependantDetails.DependantStatusDesc, objEBMemberDependantDetails.Prev_DependantCode,objEBMemberDependantDetails.DependantName, objEBMemberDependantDetails.CardDependantName ,	objEBMemberDependantDetails.RelationShipCode, objEBMemberDependantDetails.RelationShipDesc ,
        //                    objEBMemberDependantDetails.PassportNo , objEBMemberDependantDetails.DateofBirth,objEBMemberDependantDetails.Gender,objEBMemberDependantDetails.MaritalStatus,objEBMemberDependantDetails.NationalityCode,objEBMemberDependantDetails.Nationality,objEBMemberDependantDetails.StaffID,objEBMemberDependantDetails.LocationCode ,objEBMemberDependantDetails.Location ,			
        //                    objEBMemberDependantDetails.OccupationCode,objEBMemberDependantDetails.OccupationDesc,objEBMemberDependantDetails.BeneficiaryCode,objEBMemberDependantDetails.BeneficiaryDesc,objEBMemberDependantDetails.Position ,objEBMemberDependantDetails.DateOfEmployment,objEBMemberDependantDetails.VIPPrivilegeCode,objEBMemberDependantDetails.VIPPrivilegeDesc,	
        //                    objEBMemberDependantDetails.Remarks,objEBMemberDependantDetails.EffectiveDate,objEBMemberDependantDetails.TerminationDate,objEBMemberDependantDetails.ReJoinDate,objEBMemberDependantDetails.Salary,objEBMemberDependantDetails.UserID };
        //    return dataAccess.LoadDataSet(parameters, "P_EB_MemberDependantDetailsInsertUpdate", "EB_MemberDependantDetailsInsertUpdate");
        //}
        public DataSet GetMemberDependantDetails(clsEBMemberDependantDetails objEBMemberDependantDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBMemberDependantDetails.CaseRefNo, objEBMemberDependantDetails.MemberCode, objEBMemberDependantDetails.DependantCode };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDependantDetails", "EB_MemberDependantDetails");
        }

        public DataSet InsertUpdateMemberDependantRegistration(clsEBMemberDependantRegistration objEBMemberDependantRegistration)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[31] {  objEBMemberDependantRegistration.CaseRefNo ,objEBMemberDependantRegistration.MemberCode,objEBMemberDependantRegistration.DependantCode, objEBMemberDependantRegistration.RefNo, objEBMemberDependantRegistration.CoverNoteNo, objEBMemberDependantRegistration.ClassId, objEBMemberDependantRegistration.Class, objEBMemberDependantRegistration.ClientDate,objEBMemberDependantRegistration.ReceivedDate,
                                                    objEBMemberDependantRegistration.PolicyNo,objEBMemberDependantRegistration.SendOutDate,objEBMemberDependantRegistration.POIFromDate,objEBMemberDependantRegistration.POIToDate,objEBMemberDependantRegistration.UWDate,objEBMemberDependantRegistration.ActivationDate,objEBMemberDependantRegistration.CardDispatchDate,objEBMemberDependantRegistration.DebitCreditNoteNo,
                                                    objEBMemberDependantRegistration.UwriterCode,objEBMemberDependantRegistration.UwriterName,objEBMemberDependantRegistration.UwriterBillNo,objEBMemberDependantRegistration.CardNo,objEBMemberDependantRegistration.AICNo,objEBMemberDependantRegistration.CurrentCoverageCode,objEBMemberDependantRegistration.CurrentCoverageDescription ,
                                                    objEBMemberDependantRegistration.PlanCode,objEBMemberDependantRegistration.PlanDescription,objEBMemberDependantRegistration.AccommodationLevelCode,objEBMemberDependantRegistration.AccommodationLevelDesc,objEBMemberDependantRegistration.EffectiveDate,objEBMemberDependantRegistration.ExpiryDate,objEBMemberDependantRegistration.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDependantRegistrationInsertUpdate", "MemberDependantRegistrationInsertUpdate");
        }
        public DataSet GetMemberDependantRegistrationDetails(clsEBMemberDependantRegistration objEBMemberDependantRegistration)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBMemberDependantRegistration.CaseRefNo, objEBMemberDependantRegistration.MemberCode, objEBMemberDependantRegistration.DependantCode };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDependantRegistrationDetails", "EB_MemberRegistrationDetails");
        }
        public DataSet DeleteMemberDependantRegistrationDetails(clsEBMemberDependantRegistration objEBMemberRegistration)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBMemberRegistration.CaseRefNo, objEBMemberRegistration.MemberCode, objEBMemberRegistration.DependantCode,objEBMemberRegistration.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDependantRegistrationDelete", "EB_MemberRegistrationDelete");
        }
        public DataSet InsertUpdateMemberDependantRegistrationFileUpload(clsEBMemberDependantRegistrationFileUpload objEBMemberDependantRegistrationFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[9] { objEBMemberDependantRegistrationFileUpload.CaseRefNo, objEBMemberDependantRegistrationFileUpload.MemberCode, objEBMemberDependantRegistrationFileUpload.DependantCode, objEBMemberDependantRegistrationFileUpload.MemberRefNo, objEBMemberDependantRegistrationFileUpload.RefNo, objEBMemberDependantRegistrationFileUpload.FileName, objEBMemberDependantRegistrationFileUpload.FileType, objEBMemberDependantRegistrationFileUpload.Remarks, objEBMemberDependantRegistrationFileUpload.UploadBy };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDependantRegistrationFileUploadInsertUpdate", "EB_MemberRegistrationDetails");
        }
        public DataSet GetMemberDependantRegistrationFileUpload(clsEBMemberDependantRegistrationFileUpload objEBMemberDependantRegistrationFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[4] { objEBMemberDependantRegistrationFileUpload.CaseRefNo, objEBMemberDependantRegistrationFileUpload.MemberCode, objEBMemberDependantRegistrationFileUpload.DependantCode, objEBMemberDependantRegistrationFileUpload.MemberRefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDependantRegistrationFileUpload", "EB_MemberRegistrationDetails");
        }
        public DataSet DeleteMemberDependantRegistrationFileUpload(clsEBMemberDependantRegistrationFileUpload objEBMemberDependantRegistrationFileUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objEBMemberDependantRegistrationFileUpload.CaseRefNo, objEBMemberDependantRegistrationFileUpload.MemberCode,objEBMemberDependantRegistrationFileUpload.DependantCode, objEBMemberDependantRegistrationFileUpload.MemberRefNo, objEBMemberDependantRegistrationFileUpload.RefNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDependantRegistrationFileUploadDelete", "EB_MemberRegistrationFileUploadDelete");
        }
        public DataSet GetMemberHistoryDetails(clsEBMemberDetails objEBMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBMemberDetails.CaseRefNo, objEBMemberDetails.MemberCode };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberHistoryDetails", "EB_MemberHistoryDetails");
        }
        public DataSet GetMemberDependantHistoryDetails(clsEBMemberDependantDetails objEBMemberDependantDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBMemberDependantDetails.CaseRefNo, objEBMemberDependantDetails.MemberCode, objEBMemberDependantDetails.DependantCode};
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDependantHistoryDetails", "EB_MemberDependantHistoryDetails");
        }
        public DataSet UpdateMemberDependantStatus(clsEBMemberDependantDetails objEBMemberDependantDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[5] { objEBMemberDependantDetails.CaseRefNo, objEBMemberDependantDetails.MemberCode, objEBMemberDependantDetails.DependantCode, objEBMemberDependantDetails.DependantStatusDesc, objEBMemberDependantDetails.UserID };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDependantStatusUpdate", "EB_MemberDependantStatusUpdate");
        }
        public DataSet InsertBatchUploadMember(clsEBMemberUpload objEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[6] { objEBMemberUpload.CaseRefNo, objEBMemberUpload.RefNo, objEBMemberUpload.FileName, objEBMemberUpload.FileType, objEBMemberUpload.UploadBy, objEBMemberUpload.UploadType };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUploadInsertUpdate", "EB_MemberUploadInsertUpdate");
        }

        public DataSet InsertBatchRawClaimUpload(clsEBMemberUpload objEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBMemberUpload.CaseRefNo, objEBMemberUpload.FileName, objEBMemberUpload.FilePath, objEBMemberUpload.FileType, objEBMemberUpload.FromBatch, objEBMemberUpload.UploadBy, objEBMemberUpload.UploadType ,
            objEBMemberUpload.TotalRecord,objEBMemberUpload.SuccessRecord,objEBMemberUpload.FailedRecord,objEBMemberUpload.SuccessRecordID};
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUploadForRawClaimInsert", "RAWClaimUpload");
        }
        public DataSet UpdateBatchRawClaimUpload(clsEBMemberUpload objEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBMemberUpload.CaseRefNo, objEBMemberUpload.FileName, objEBMemberUpload.FilePath, objEBMemberUpload.FileType, objEBMemberUpload.FromBatch, objEBMemberUpload.UploadBy, objEBMemberUpload.UploadType ,
            objEBMemberUpload.TotalRecord,objEBMemberUpload.SuccessRecord,objEBMemberUpload.FailedRecord,objEBMemberUpload.SuccessRecordID,objEBMemberUpload.RefNo};
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUploadForRawClaim_Update", "RAWClaimUpload");
        }
        public DataSet GetBatchRawClaimUpload(clsEBMemberUpload objEBMemberUpload)
        {
            return GetBatchRawClaimUpload(objEBMemberUpload, "");
        }
        public DataSet GetBatchRawClaimUpload(clsEBMemberUpload objEBMemberUpload, string ConString)
        {
            if (ConString.Trim() != "")
                dataAccess = new DataAccess(ConString, "");
            else
                dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBMemberUpload.FromBatch };
            return dataAccess.LoadDataSet(parameters, "P_RawClaimUploadDetailsPathSelect", "RAWClaimUpload");
        }
        public DataSet GetRawClaimUpload(clsEBMemberUpload objclsEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {objclsEBMemberUpload.FileName ,
                                                objclsEBMemberUpload.RefNo ,
                                                objclsEBMemberUpload.CovernoteNo ,
                                                objclsEBMemberUpload.UploadFromDate ,
                                                objclsEBMemberUpload.UploadToDate
                                                };
            return dataAccess.LoadDataSet(parameters, "P_RawClaimUploadDetailsSelect", "RAWClaimUpload");
        }
        public DataSet GetRawClaimUploadFailed(clsEBMemberUpload objclsEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                                                objclsEBMemberUpload.CovernoteNo ,
                                                
                                                };
            return dataAccess.LoadDataSet(parameters, "P_EB_RawDataClaim_select", "RAWClaimUpload");
        }
        public DataSet GetBenefitSheduleDetail(clsEBMemberUpload objclsEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                                                objclsEBMemberUpload.CovernoteNo ,
                                                
                                                };
            return dataAccess.LoadDataSet(parameters, "P_Pol_Benefits_Select", "RAWClaimUpload");
        }


        public DataSet SetRawClaimReprocess(clsEBMemberUpload objclsEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] {
                                                objclsEBMemberUpload.CovernoteNo
                                                
                                                };
            return dataAccess.LoadDataSet(parameters, "P_RawClaimUploadDetailsUpdate", "RAWClaimUpload");
        }


        public DataSet GetMemberBatch(clsEBMemberDetails objMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objMemberDetails.CaseRefNo, objMemberDetails.MemberCode, objMemberDetails.CovernoteNo  };
            return dataAccess.LoadDataSet(parameters, "P_GetMemberBatch", "EB_MemberUpload");
        }
        public DataSet UpdateBatchUploadMember(clsEBMemberUpload objEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBMemberUpload.CaseRefNo, objEBMemberUpload.RefNo, objEBMemberUpload.FilePath};
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUploadUpdate", "EB_MemberUploadUpdate");
        }        
        
        public DataSet GetDebitNoteDetails(clsEBMemberUpload objEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objEBMemberUpload.CaseRefNo};
            return dataAccess.LoadDataSet(parameters, "P_EB_DebitNoteDetails", "EB_DebitNoteDetails");
        }
        public DataSet GetMemberUploadList(clsEBMemberUpload objEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[8] { objEBMemberUpload.FileName, objEBMemberUpload.RefNo, objEBMemberUpload.UploadFromDate, objEBMemberUpload.UploadToDate, objEBMemberUpload.UploadType, objEBMemberUpload.PolicyNo, objEBMemberUpload.FromBatch,objEBMemberUpload.CovernoteNo };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUploadList", "EB_MemberUploadList");
        }
        public DataSet GetMemberUploadFailedList(clsEBMemberUpload objEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBMemberUpload.RefNo, objEBMemberUpload.UploadType};
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberUploadFailRecord", "EB_MemberUploadFailRecord");
        }

        public DataSet GetMemberEnquiry(clsEBMemberDetails objMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[29] { objMemberDetails.PolicyNo, objMemberDetails.ClientCode, objMemberDetails.ClientName, objMemberDetails.Prev_MemberCode, objMemberDetails.MemberCode, objMemberDetails.MemberName,objMemberDetails.DependantName, objMemberDetails.PassportNo,objMemberDetails.MemberType,
             objMemberDetails.CovernoteNo ,
            objMemberDetails.POIFromDate,
            objMemberDetails.POIToDate,
            objMemberDetails.CertificateNo,
            objMemberDetails.Plan,
            objMemberDetails.EffectiveDate,
            objMemberDetails.DateToUW ,
            objMemberDetails.CardDispatch ,
            objMemberDetails.AdjustmentReportDispatch,
            objMemberDetails.AdjustmentReportNo,
            objMemberDetails.HDFToClient ,
            objMemberDetails.HDFToUW,
            objMemberDetails.CalledFrom,objMemberDetails.DeptType,objMemberDetails.UNType,objMemberDetails.UNStatus,objMemberDetails.PlanType,
             objMemberDetails.PIHNo,objMemberDetails.SchemeType, objMemberDetails.MemberStatusDesc };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDetailList", "EB_MemberUploadList");
        }
        public DataSet GetMemberEnquiry_CRUD(clsEBMemberDetails objMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[24] { objMemberDetails.PolicyNo, objMemberDetails.ClientCode, objMemberDetails.ClientName, objMemberDetails.Prev_MemberCode,
                                                   objMemberDetails.MemberCode, objMemberDetails.MemberName, objMemberDetails.PassportNo, objMemberDetails.MemberType, 
                                                   objMemberDetails.CalledFrom, objMemberDetails.SuspFromDate, objMemberDetails.SuspToDate, objMemberDetails.TerminateDate,
            objMemberDetails.CovernoteNo ,
            objMemberDetails.POIFromDate,
            objMemberDetails.POIToDate,
            objMemberDetails.CertificateNo,
            objMemberDetails.Plan,
            objMemberDetails.EffectiveDate,
            objMemberDetails.DateToUW ,
            objMemberDetails.CardDispatch ,
            objMemberDetails.AdjustmentReportDispatch,
            objMemberDetails.AdjustmentReportNo,
            objMemberDetails.HDFToClient ,
            objMemberDetails.HDFToUW };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDetailList_CRUD", "P_EB_MemberDetailList_CRUD");
        }
        public DataSet GetMemberDependantEnquiry(clsEBMemberDetails objMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[24] { objMemberDetails.PolicyNo, objMemberDetails.ClientCode, objMemberDetails.ClientName, objMemberDetails.Prev_MemberCode, objMemberDetails.MemberCode, objMemberDetails.MemberName, objMemberDetails.DependantCode, objMemberDetails.DependantName, objMemberDetails.PassportNo,
            objMemberDetails.CovernoteNo ,
            objMemberDetails.POIFromDate,
            objMemberDetails.POIToDate,
            objMemberDetails.CertificateNo,
            objMemberDetails.Plan,
            objMemberDetails.EffectiveDate,
            objMemberDetails.DateToUW ,
            objMemberDetails.CardDispatch ,
            objMemberDetails.AdjustmentReportDispatch,
            objMemberDetails.AdjustmentReportNo,
            objMemberDetails.HDFToClient ,
            objMemberDetails.HDFToUW,
            objMemberDetails.DeptType ,objMemberDetails.UNType,objMemberDetails.UNStatus
            };
            return dataAccess.LoadDataSet(parameters, "P_EB_MemberDependantDetailList", "EB_MemberUploadList");
        }

        public DataSet GetAdjustmentReportList(clsEBMemberDetails objEBMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[1] { objEBMemberDetails.ReportId };
            return dataAccess.LoadDataSet(parameters, "P_EB_AjustmentReportFileUpload_Select", "EB_AjustmentReportFileUpload");
        }

        public DataSet SetAdjustmentReportList(clsEBMemberDetails objEBMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBMemberDetails.ReportId, objEBMemberDetails.CovernoteNo,
                objEBMemberDetails.AdjustmentPremuim , objEBMemberDetails.AdjustmentReportNo, objEBMemberDetails.DateToClient, objEBMemberDetails.FileName, objEBMemberDetails.FileType, objEBMemberDetails.UpdatedBY};
            return dataAccess.LoadDataSet(parameters, "P_EB_AjustmentReportFileUpload_InsertUpdate", "EB_AjustmentReportFileUpload");
        }

        public DataSet SearchMovementLetter(clsEBMemberDetails objEBMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBMemberDetails.CovernoteNo, 
            objEBMemberDetails.PolicyNo,
            objEBMemberDetails.ClientName 
            };
            return dataAccess.LoadDataSet(parameters, "P_MovementEBLetter", "MovementEBLetter");
        }

        public DataSet SearchAdjustmentReportList(clsEBMemberDetails objEBMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objEBMemberDetails.CovernoteNo, 
            objEBMemberDetails.PolicyNo,
            objEBMemberDetails.ClientName ,
            objEBMemberDetails.UWName,
            objEBMemberDetails.POIFromDate ,
            objEBMemberDetails.POIToDate ,
            objEBMemberDetails.SubClassName };
            return dataAccess.LoadDataSet(parameters, "P_EB_AjustmentReportSummary", "EB_AjustmentReportFileUpload");
        }
        public DataSet GetEBPlanDetails(clsEBMemberDetails objEBMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBMemberDetails.CaseRefNo, objEBMemberDetails.MemberCode };
            return dataAccess.LoadDataSet(parameters, "P_EB_PlanDetail_Select", "EB_PlanDetails");
        }
        public DataSet GetEBClaimDetails(clsEBMemberDetails objEBMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[2] { objEBMemberDetails.CaseRefNo, objEBMemberDetails.MemberCode };
            return dataAccess.LoadDataSet(parameters, "P_EB_ClaimDetail_Select", "EB_ClamDetails");
        }

        public DataSet GetEBPlanReport(clsEBMemberDetails objEBMemberDetails)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[3] { objEBMemberDetails.CaseRefNo, objEBMemberDetails.MemberCode, objEBMemberDetails.Plan };
            string[] Tables = { "PolicyDetails", "PlanDetails" };
            return dataAccess.LoadDataSets(parameters, "P_PlanReport",Tables);
        }

        public DataSet GetEB_RawClaimBenefitLineRange(clsEBMemberUpload objclsEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objclsEBMemberUpload.CovernoteNo  };

            return dataAccess.LoadDataSet(parameters, "P_EB_RawClaimBenefitLineRangeSelect", "EB_RawClaim");
        }

        public DataSet SetEB_RawClaimBenefitLineRange(clsEB_RawClaim objclsclsEB_RawClaim)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objclsclsEB_RawClaim.BenefitLineID, objclsclsEB_RawClaim.NonPanel,
                                                 objclsclsEB_RawClaim.MinValue, objclsclsEB_RawClaim.RangeValue,
                                                 objclsclsEB_RawClaim.MaxValue, objclsclsEB_RawClaim.IsSelected,objclsclsEB_RawClaim.User };

            return dataAccess.LoadDataSet(parameters, "EB_RawClaimBenefitLineRange_InsertUpdate", "EB_RawClaim");
        }
        public DataSet GetEB_RawDataClaimReport(clsEBMemberUpload objclsEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objclsEBMemberUpload.CovernoteNo, objclsEBMemberUpload.UploadFromDate, objclsEBMemberUpload.UploadToDate };

            return dataAccess.LoadDataSet(parameters, "P_EB_RawDataClaim_Rpt", "EB_RawClaimReport");
        }

        public DataSet GetEB_RawDataClaim_ClaimReport(clsEBMemberUpload objclsEBMemberUpload)
        {
            dataAccess = new DataAccess();
            Object[] parameters = new Object[] { objclsEBMemberUpload.CovernoteNo, objclsEBMemberUpload.UploadFromDate, objclsEBMemberUpload.UploadToDate,objclsEBMemberUpload.AMC };
            string[] Tables = { "ClaimReportOutpatient", "ClaimReportInpatient", "ClaimReportTotal", "ClaimReportOutpatientYearly", "ClaimReportInpatientYearly", "ClaimReportTotalYearly" };
            return dataAccess.LoadDataSets(parameters, "P_EB_RawDataClaim_ClaimReport", Tables);
   
       
        }

        public DataSet GetProvinceByTertID(int TerritoryId)
        {
            dataAccess = new DataAccess();
            object[] parameters = new Object[1] { TerritoryId };
            return dataAccess.LoadDataSet(parameters, "P_TM_ProvinceMaster_SelectByTertId", "ProvinceList");

        }

        public DataSet GetCityByProviceID(int territoryId, int ProvinceId)
        {
            dataAccess = new DataAccess();
            object[] parameters = new Object[2] { territoryId, ProvinceId };
            return dataAccess.LoadDataSet(parameters, "P_TM_City_Select", "CityList");

        }

        public DataSet GetTerritory(int TertId)
        {
            dataAccess = new DataAccess();
            object[] parameters = new Object[5] { TertId, null, null, null, null };
            return dataAccess.LoadDataSet(parameters, "P_TM_TerritoryMaster_Select", "TerritoryList");
        }

        public DataSet GetReportAnalysisData(clsEBMemberUpload objclsEBMemberUpload)
        {
            dataAccess = new DataAccess();
            object[] parameters = new Object[] { objclsEBMemberUpload.UploadFromDate, objclsEBMemberUpload.UploadToDate};
            return dataAccess.LoadDataSet(parameters, "P_Claim_AnalysisReport", "P_Claim_AnalysisReport");
        }
        public DataSet GetReportTop10HospitalBenefitData(clsEBMemberUpload objclsEBMemberUpload)
        {
            dataAccess = new DataAccess();
            object[] parameters = new Object[] { objclsEBMemberUpload.UploadFromDate, objclsEBMemberUpload.UploadToDate, objclsEBMemberUpload.ReportType};
            return dataAccess.LoadDataSet(parameters, "P_Claim_Top10Amount_Report", "P_Claim_Top10Amount_Report");
        }
        public DataSet GetReportAnalysisByAmtVisits(clsEBMemberUpload objclsEBMemberUpload)
        {
            dataAccess = new DataAccess();
            object[] parameters = new Object[] { objclsEBMemberUpload.UploadFromDate, objclsEBMemberUpload.UploadToDate, objclsEBMemberUpload.ReportType};
            return dataAccess.LoadDataSet(parameters, "P_ClaimAnalysisByAmtVisits", "P_ClaimAnalysisByAmtVisits");
        }
        public DataSet GetReportsName()
        {
            dataAccess = new DataAccess();
            object[] parameters = new Object[] { };
            return dataAccess.LoadDataSet(parameters, "P_Claim_Report_Select", "P_Claim_Report_Select");
        }
        public DataSet GetCoverageANDMasterCN(string CoverNoteNo)
        {
            dataAccess = new DataAccess();
            object[] parameters = new Object[] { CoverNoteNo };
            return dataAccess.LoadDataSet(parameters, "P_IH_GetCoverageAndMasterPolicy", "P_IH_GetCoverageAndMasterPolicy");
        }
        
    }
}
