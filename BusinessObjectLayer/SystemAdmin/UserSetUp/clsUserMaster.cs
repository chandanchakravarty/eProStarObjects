using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
    public class clsUserMaster
    {
        public int UserId { get; set; }
        public string UserLoginId { get; set; }
        public string UserPassword { get; set; }
        //public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ChineseSurname { get; set; }
        public string ChineseName { get; set; }
        public string Email { get; set; }
        public string CCMail { get; set; }
        public string TelephoneNoCode { get; set; }
        public string TelephoneNo { get; set; }
        public string MobileNoCode { get; set; }
        public string MobileNo { get; set; }
        public int CompanyId { get; set; }
        public int TeamId { get; set; }
        public string EmploymentDate { get; set; }
        public string ResignationDate { get; set; }
        public string UserType_AH { get; set; }
        public string GroupAccessCode { get; set; }

        public int Level2ProspectClientLA1 { get; set; }
        public int Level2ProspectClientLA2 { get; set; }
        public int Level2CreditNoteLA1 { get; set; }
        public int Level2CreditNoteLA2 { get; set; }
        public int ClaimLimit { get; set; }
        public string CurrencyCode { get; set; }
        
        public int Level2ClientLA1 { get; set; }
        public int Level2ClientLA2 { get; set; }
        public int Level2CedantLA1 { get; set; }
        public int Level2CedantLA2 { get; set; }
        public int Level3ClientLA1 { get; set; }
        public int Level3ClientLA2 { get; set; }
        public int Level3ClientLA3 { get; set; }
        public int Level3CedantLA1 { get; set; }
        public int Level3CedantLA2 { get; set; }
        public int Level3CedantLA3 { get; set; }
        public int UWriterLA1 { get; set; }
        public int UWriterLA2 { get; set; }
        public int UWriterLA3 { get; set; }
        public int AgentLA1 { get; set; }
        public int AgentLA2 { get; set; }
        public int AgentLA3 { get; set; }
        public int ReInsurerLA1 { get; set; }
        public int ReInsurerLA2 { get; set; }
        public int ReInsurerLA3 { get; set; }
        public int GradeId { get; set; }

        public string EffectiveFromDate { get; set; }
        public string EffectiveEndDate { get; set; }
        //Added By Kumar Rituraj
        public string EffectiveFromDate2 { get; set; }
        public string EffectiveEndDate2 { get; set; }
        public string Team { get; set; }
        public string Group { get; set; }
        public string Ledger { get; set; }
        //End
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public string IsActive { get; set; }
        public string IsEnabled { get; set; }
        public Int32 AccessLevel { get; set; }
        public string IsPasswordResetFlag { get; set; }
        public int IncorrectPasswordAttempts { get; set; }
        public string PasswordLastChanged { get; set; }
        public string IsNewUser { get; set; }
        public int MaxPasswordAttempts { get; set; }
        public string RecentLoginTime { get; set; }
        public string PreviousLoginTime { get; set; }
        public string UserType_CH { get; set; }
        public string UserType_MR { get; set; }

        public bool OverrideAccess { get; set; }


        public int Level3BillingLA1 { get; set; }
        public int Level3BillingLA2 { get; set; }
        public int Level3BillingLA3 { get; set; }
        public int Level3DNWOCNLA1 { get; set; }
        public int Level3DNWOCNLA2 { get; set; }
        public int Level3DNWOCNLA3 { get; set; }
        ////public string Ledger { get; set; }
        ////public string Team { get; set; }
        ////public string EffectiveFromDate2 { get; set; }
        ////public string EffectiveEndDate2 { get; set; }
        ////public string Group { get; set; }

        //added by Kavita Kaushik.
        public int AccountUserAssociated_ID { get; set; }
        //end
        public int IsAccountUser { get; set; }
        public int UserLevelId { get; set; }
        public int ReportingManagerId { get; set; }
        public string ClassType { get; set; }
        public string UnitAccessIds { get; set; }
        public string ApproverLists { get; set; }
       

        public string TeamAccessID { get; set; }

        public string UserGroup { get; set; }
        public string ClientCode { get; set; }
        public int ManualOverwrite { get; set; }
    }
}
