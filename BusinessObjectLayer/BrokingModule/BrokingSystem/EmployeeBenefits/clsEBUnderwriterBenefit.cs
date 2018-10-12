using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits
{
    public class clsEBUnderwriterBenefit
    {
        public string   CaseRefNo            { get; set; }
        public string   MemberCode           { get; set; }
        public string   RefNo                { get; set; }
        public string   CoverNoteNo          { get; set; }  
        public string   PolicyNo             { get; set; }
        public string   PolicyHolder         { get; set; }
        public string   CertNo               { get; set; }
        public string   UWName               { get; set; }
        public string   Gender               { get; set; }
        public string   DateOfBirth          { get; set; }
        public string   Class                { get; set; }
        public decimal  ExistSumInsured      { get; set; }
        public decimal  ProposedSumInsured   { get; set; }
        public string   StatusCode           { get; set; }
        public string   StatusDescription    { get; set; }
        public string   UserID { get; set; }
    }
}
