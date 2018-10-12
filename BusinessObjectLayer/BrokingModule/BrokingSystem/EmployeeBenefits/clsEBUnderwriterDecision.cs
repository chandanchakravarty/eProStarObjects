using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits
{
    public class clsEBUnderwriterDecision
    {
        public string CaseRefNo          { get; set; }
        public string MemberCode         { get; set; }
        public string RefNo              { get; set; }
        public string UWRefNo            { get; set; }
        public decimal StandardRate       { get; set; }
        public string StandardLoading    { get; set; }
        public string StandardEffectiveDate { get; set; }
        public string ExclusionsApplied { get; set; }
        public string ExclusionsEffectiveDate { get; set; }
        public string UWRemarks { get; set; }
        public string UserID { get; set; }

    }
}
