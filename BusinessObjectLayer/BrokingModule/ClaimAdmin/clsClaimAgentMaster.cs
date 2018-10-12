using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.ClaimAdmin
{
    public class clsClaimAgentMaster
    {
        public int    CAgentID { get; set; }
        public string CAgentCode { get; set; }
        public string CAgentType { get; set; }
        public string CAgentFor { get; set; }
        public string CAgentSource { get; set; }
        public string CAgentLocationType { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Salutation { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string PrivateEMail { get; set; }
        public string TelNoResPref { get; set; }
        public string TelNoRes { get; set; }
        public string TelNoOffPref { get; set; }
        public string TelNoOff { get; set; }
        public string MobileNoPref { get; set; }
        public string MobileNo { get; set; }
        public string FaxNoPref { get; set; }
        public string FaxNo { get; set; }
        public int Country { get; set; }
        public string Remarks { get; set; }
        public string EffectivefromDate { get; set; }
        public string Effectivetodate { get; set; }
        // Added By Rituraj For Claim type filteration
        public string EffectivefromDate2 { get; set; }
        public string Effectivetodate2 { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
           }
    public class AgentContacts
    {

        public int ContactId { get; set; }
        public int CAgentID { get; set; }
        public string Salutation { get; set; }
        public string ContactName { get; set; }
        public string Designation { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string BuildingName { get; set; }
        public string Email { get; set; }
        public string TelNoResPref { get; set; }
        public string TelNoRes { get; set; }
        public string TelNoOffPref { get; set; }
        public string TelNoOff { get; set; }
        public string MobileNoPref { get; set; }
        public string MobileNo { get; set; }
        public string FaxNoPref { get; set; }
        public string FaxNo { get; set; }
        public int Country { get; set; }
        public string Nationality { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }
        public string PassportNo { get; set; }
        public string Dob { get; set; }
        public string PassportAttached { get; set; }
        public string LatestEducation { get; set; }
        public string ICAttached { get; set; }
        public string ICNo { get; set; }
        public string Remarks { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
    
    }
}
