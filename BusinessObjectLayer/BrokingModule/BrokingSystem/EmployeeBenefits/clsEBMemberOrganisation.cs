using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits
{
    public class clsEBMemberOrganisation
    {
         public string CaseRefNo      { get; set; }
         public string MemberCode         { get; set; }
         public string SubsidiaryCode   { get; set; }
         public string SubsidiaryDescription   { get; set; }
         public string SubsidiaryEffectiveFromDate { get; set; }
         public string DepartmentCode   { get; set; }
         public string DepartmentName   { get; set; }
         public string DepartmentEffectiveFromDate { get; set; }
         public string ClassificationCode   { get; set; }
         public string ClassificationDescription { get; set; }
         public string ClassificationEffectiveFromDate { get; set; }
         public string UserID { get; set; }
         public string CostCenter { get; set; }
    }
}
