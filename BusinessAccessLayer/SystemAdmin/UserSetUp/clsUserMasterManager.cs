using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccessLayer;
using BusinessObjectLayer.SystemAdmin.UserSetUp;

namespace BusinessAccessLayer.SystemAdmin.UserSetUp
{
    public class clsUserMasterManager
    {
        DataAccess dataAccessDS = null;
        public DataSet LoadUserMaster(clsUserMaster objUser)
        {
            object[] parameters = new object[1] { objUser.UserId};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserMaster_Select", "UserSelect");


        }
         public DataSet LoadUserMasterAll(clsUserMaster objUser)
        {
            object[] parameters = new object[10] { objUser.UserId, objUser.UserLoginId, objUser.Ledger, objUser.Team, objUser.Group, objUser.EffectiveFromDate, objUser.EffectiveFromDate2, objUser.EffectiveEndDate, objUser.EffectiveEndDate2,objUser.Status };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserMaster_SelectAll", "UserSelect");

        }
        public DataSet LoadTeam(int teamId)
        {
            object[] parameters = new object[1] { teamId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserMaster_SelectTeam", "TeamList");

        }
        public DataSet LoadGrade(int GradeId)
        {
            object[] parameters = new object[1] { GradeId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserMaster_SelectGrade", "GradeList");

        }

        public DataSet UnlockUser(int UserId)
        {
            object[] parameters = new object[1] { UserId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserMaster_Unlock", "UserSelect");

        }
         public DataSet LoadUserLimits(int userId,int LimitId)
        {
            object[] parameters = new object[2] {userId,LimitId};
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserLimit_Select", "UserLimitSelect");

        }

         public DataSet GetUserApprovalNotification(int userId, int ApproverId)
         {
             object[] parameters = new object[2] { userId, ApproverId };
             dataAccessDS = new DataAccess();
             return dataAccessDS.LoadDataSet(parameters, "P_TM_UserApprovalNotification", "UserApprovalNotification");
         }
         public DataSet SaveUserMaster_Portal(clsUserMaster objUser)
         {
             object[] parameters = new object[] { objUser.UserId,
                                                 objUser.UserLoginId,
                                                 objUser.UserPassword,
                                                 objUser.FirstName,
                                                 objUser.LastName,
                                                 objUser.ChineseSurname,
                                                 objUser.ChineseName,
                                                 objUser.Email,
                                                 objUser.CCMail,
                                                 objUser.TelephoneNoCode,
                                                 objUser.TelephoneNo,
                                                 objUser.MobileNoCode,
                                                 objUser.MobileNo,
                                                 objUser.CompanyId,
                                                 objUser.TeamId,
                                                 objUser.EmploymentDate,
                                                 objUser.ResignationDate,
                                                 objUser.UserType_AH,
                                                 objUser.UserType_MR,
                                                 objUser.GroupAccessCode,

                                                 objUser.Level2ProspectClientLA1,
                                                 objUser.Level2ProspectClientLA2,
                                                 objUser.Level2CreditNoteLA1,
                                                 objUser.Level2CreditNoteLA2,
                                                 objUser.CurrencyCode,
                                                 objUser.ClaimLimit,

                                                 objUser.Level2ClientLA1,
                                                 objUser.Level2ClientLA2,
                                                 objUser.Level2CedantLA1,
                                                 objUser.Level2CedantLA2,
                                                 objUser.Level3ClientLA1,
                                                 objUser.Level3ClientLA2,
                                                 objUser.Level3ClientLA3,
                                                 objUser.Level3CedantLA1,
                                                 objUser.Level3CedantLA2,
                                                 objUser.Level3CedantLA3,
                                                 objUser.UWriterLA1,
                                                 objUser.UWriterLA2,
                                                 objUser.UWriterLA3,
                                                 objUser.AgentLA1,
                                                 objUser.AgentLA2,
                                                 objUser.AgentLA3,
                                                 objUser.ReInsurerLA1,
                                                 objUser.ReInsurerLA2,
                                                 objUser.ReInsurerLA3,
                                                 objUser.GradeId,
                                                 objUser.EffectiveFromDate,
                                                 objUser.EffectiveEndDate,
                                                 objUser.Status,
                                                 objUser.LoginUserId,
                                                 objUser.PageMethod,
                                                 objUser.UserType_CH,
                                                 objUser.OverrideAccess,
                                                 objUser.AccessLevel,
                                                 //objUser.IncorrectPasswordAttempts,
                                                 //objUser.IsActive,
                                                 //objUser.IsEnabled,
                                                 //objUser.IsNewUser,
                                                 //objUser.IsPasswordResetFlag,
                                                 //objUser.LastName,
                                                 //objUser.MaxPasswordAttempts,
                                                 //objUser.PasswordLastChanged,
                                                 //objUser.PreviousLoginTime,
                                                 //objUser.RecentLoginTime
                                                 
                                                 objUser.Level3BillingLA1,
                                                 objUser.Level3BillingLA2,
                                                 objUser.Level3BillingLA3,
                                                 objUser.Level3DNWOCNLA1,
                                                 objUser.Level3DNWOCNLA2,
                                                 objUser.Level3DNWOCNLA3,
                                                 //added new column//
                                                 objUser.AccountUserAssociated_ID,
                                                 objUser.IsAccountUser,
                                                 objUser.ReportingManagerId,
                                                 objUser.UserLevelId,
                                                 objUser.ClassType,
                                                 objUser.TeamAccessID,
                                                 objUser.ApproverLists,
                                                 objUser.UserGroup,
                                                 objUser.ClientCode,
                                                 objUser.ManualOverwrite
                                               };
             dataAccessDS = new DataAccess();
             return dataAccessDS.LoadDataSet(parameters, "P_TM_UserMaster_InsertUpdate", "UserMasterDetail");

         }
        public DataSet SaveUserMaster(clsUserMaster objUser)
        {
            object[] parameters = new object[] { objUser.UserId,
                                                 objUser.UserLoginId,
                                                 objUser.UserPassword,
                                                 objUser.FirstName,
                                                 objUser.LastName,
                                                 objUser.ChineseSurname,
                                                 objUser.ChineseName,
                                                 objUser.Email,
                                                 objUser.CCMail,
                                                 objUser.TelephoneNoCode,
                                                 objUser.TelephoneNo,
                                                 objUser.MobileNoCode,
                                                 objUser.MobileNo,
                                                 objUser.CompanyId,
                                                 objUser.TeamId,
                                                 objUser.EmploymentDate,
                                                 objUser.ResignationDate,
                                                 objUser.UserType_AH,
                                                 objUser.UserType_MR,
                                                 objUser.GroupAccessCode,

                                                 objUser.Level2ProspectClientLA1,
                                                 objUser.Level2ProspectClientLA2,
                                                 objUser.Level2CreditNoteLA1,
                                                 objUser.Level2CreditNoteLA2,
                                                 objUser.CurrencyCode,
                                                 objUser.ClaimLimit,

                                                 objUser.Level2ClientLA1,
                                                 objUser.Level2ClientLA2,
                                                 objUser.Level2CedantLA1,
                                                 objUser.Level2CedantLA2,
                                                 objUser.Level3ClientLA1,
                                                 objUser.Level3ClientLA2,
                                                 objUser.Level3ClientLA3,
                                                 objUser.Level3CedantLA1,
                                                 objUser.Level3CedantLA2,
                                                 objUser.Level3CedantLA3,
                                                 objUser.UWriterLA1,
                                                 objUser.UWriterLA2,
                                                 objUser.UWriterLA3,
                                                 objUser.AgentLA1,
                                                 objUser.AgentLA2,
                                                 objUser.AgentLA3,
                                                 objUser.ReInsurerLA1,
                                                 objUser.ReInsurerLA2,
                                                 objUser.ReInsurerLA3,
                                                 objUser.GradeId,
                                                 objUser.EffectiveFromDate,
                                                 objUser.EffectiveEndDate,
                                                 objUser.Status,
                                                 objUser.LoginUserId,
                                                 objUser.PageMethod,
                                                 objUser.UserType_CH,
                                                 objUser.OverrideAccess,
                                                 objUser.AccessLevel,
                                                 //objUser.IncorrectPasswordAttempts,
                                                 //objUser.IsActive,
                                                 //objUser.IsEnabled,
                                                 //objUser.IsNewUser,
                                                 //objUser.IsPasswordResetFlag,
                                                 //objUser.LastName,
                                                 //objUser.MaxPasswordAttempts,
                                                 //objUser.PasswordLastChanged,
                                                 //objUser.PreviousLoginTime,
                                                 //objUser.RecentLoginTime
                                                 
                                                 objUser.Level3BillingLA1,
                                                 objUser.Level3BillingLA2,
                                                 objUser.Level3BillingLA3,
                                                 objUser.Level3DNWOCNLA1,
                                                 objUser.Level3DNWOCNLA2,
                                                 objUser.Level3DNWOCNLA3,
                                                 //added new column//
                                                 objUser.AccountUserAssociated_ID,
                                                 objUser.IsAccountUser,
                                                 objUser.ReportingManagerId,
                                                 objUser.UserLevelId,
                                                 objUser.ClassType,
                                                 objUser.TeamAccessID,
                                                 objUser.ApproverLists
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserMaster_InsertUpdate", "UserMasterDetail");

        }
        public DataSet SaveUserLimit(clsUserLimit objUserLimit)
        {
            object[] parameters = new object[] {
                                                 objUserLimit.UserLimitId,
                                                 objUserLimit.UserId,
                                                 objUserLimit.ClassId,
                                                 objUserLimit.Type,
                                                 objUserLimit.PremiumCurrency,
                                                 objUserLimit.PremiumAmt,
                                                 objUserLimit.SumInsuredCurrency,
                                                 objUserLimit.SumInsuredAmt,
                                                 objUserLimit.PageMethod 
                                               };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(parameters, "P_TM_UserLimit_InsertUpdate", "UserLimitDetail");

        }
        public DataSet DeleteUserLimit(int UserLimitId)
        {
            object[] param = new object[] { UserLimitId };
            dataAccessDS = new DataAccess();
            return dataAccessDS.LoadDataSet(param, "P_TM_UserLimit_Delete", "UserLimitDelete");
        }

        public DataSet GetReportingManager(clsUserMaster objUser)
        {
            dataAccessDS = new DataAccess();
            object[] parameters = new Object[] { objUser.UserLevelId, objUser.TeamId, objUser.UserId };
            return dataAccessDS.LoadDataSet(parameters, "P_TM_ReportingManager_Select", "P_TM_ReportingManager_Select");
        }

        public DataSet GetUserLevel()
        {
            dataAccessDS = new DataAccess();
            object[] parameters = new Object[] { };
            return dataAccessDS.LoadDataSet(parameters, "P_User_Level_Select", "P_User_Level_Select");
        }

        public DataSet LoadActivityApprovalList(string userId)
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[1] { userId };
            return dataAccessDS.LoadDataSet(parametes, "Proc_GetApprovalActivities", "TM_ApprovalActivities");
        }

        clsActivityApprovalAuthority objActivityApprovalAuthority = new clsActivityApprovalAuthority();

        public DataSet SaveApprovalAuthority(clsActivityApprovalAuthority objActivityApprovalAuthority)
        {
            dataAccessDS = new DataAccess();

            Object[] parametes = new Object[7] { objActivityApprovalAuthority.ActivityRefID, objActivityApprovalAuthority.UserID, objActivityApprovalAuthority.AuthorityLevelI, objActivityApprovalAuthority.AuthorityLevelII, objActivityApprovalAuthority.CreatedBy, objActivityApprovalAuthority.LastUpdatedBy, objActivityApprovalAuthority.IsActive };
            return dataAccessDS.LoadDataSet(parametes, "P_TM_ActivityApprovalAuthority_InsertUpdate", "TM_UserApprovalAuthorities");
        }


        public DataSet LoadActivityApprovalLevelList()
        {
            dataAccessDS = new DataAccess();
            Object[] parametes = new Object[0] { };
            return dataAccessDS.LoadDataSet(parametes, "Proc_GetActivityApprovalLevel", "TM_ApprovalActivities");
        }

        public DataSet SaveActivityApprovalLevel(clsUserActivityApprovalLevel objActivityApprovalLevel)
        {
            dataAccessDS = new DataAccess();

            Object[] parametes = new Object[4] { objActivityApprovalLevel.ActivityRefID, objActivityApprovalLevel.ActivityID, objActivityApprovalLevel.CreatedBy, objActivityApprovalLevel.ApprovalLevel };
            return dataAccessDS.LoadDataSet(parametes, "P_TM_ActivityApprovalLevel_InsertUpdate", "TM_ApprovalActivities");
        }
    }
}
 
