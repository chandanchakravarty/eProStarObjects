using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits
{
   public class clsEBUnderwriterDetails
    {
        public string CaseRefNo     { get; set; }
        public string MemberCode    { get; set; }
        public string RefNo { get; set; }
        public string CompleteDate  { get; set; }
        public string Health_InsurerDate    { get; set; }
        public string Health_ClientDate     { get; set; }
        public string Health_SubmitDate     { get; set; }
        public string Health_StatusCode { get; set; }
        public string Health_StatusDesc { get; set; }
        public string Invitation_InsurerDate{ get; set; }
        public string Invitation_ClientDate { get; set; }
        public string Invitation_ExamDate   { get; set; }
        public string Invitation_StatusCode { get; set; }
        public string Invitation_StatusDesc { get; set; }    
        public string Futher_InsurerDate    { get; set; }
        public string Futher_ClientDate     { get; set; }
        public string Futher_ExamSubmitDate { get; set; }
        public string Further_StatusCode    { get; set; }
        public string Further_StatusDesc    { get; set; }    
        public string First_SendOutDate     { get; set; }
        public string First_ClientResponse  { get; set; }
        public string First_Remarks         { get; set; }
        public string Second_SendOutDate    { get; set; }
        public string Second_ClientResponse { get; set; }
        public string Second_Remarks        { get; set; }    
        public string Third_SendOutDate     { get; set; }
        public string Third_CleintResponse  { get; set; }
        public string Third_Remarks         { get; set; }
        public string Folloup_Remarks       { get; set; }
        public string UserID { get; set; }
    }
}
