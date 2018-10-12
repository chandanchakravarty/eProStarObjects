using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsBenefitSchedule
    {
         public int BenefitId { get; set; }
         public string Benefitname { get; set; }
         public int SubClassId { get; set; }
         public string SubClassName { get; set; }
         public string Benefittype { get; set; }
         public string BenefitClassType { get; set; }
         public string EffFromDate { get; set; }
         public string EffFromDate1 { get; set; }
         public string EffToDate { get; set; }
         public string EffToDate1 { get;set; } 
         public string User { get; set; }
         public string IsActive{get;set;}
         public string DeptType { get; set; }
         public string IsIH { get; set; }
		
    }
    public class clsBenefitScheduleDetial
    {
        public int BenefitScheduleId { get; set;}
        public int BenefitGroupLineId { get; set; }
        public string BenefitGroupLinename { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
        public int IsSelected { get; set; }
        public int OrderNo { get; set; }
    
    }
    //public class BenefitScheduleDetialList
    //{
    //    public List<clsBenefitScheduleDetial> BenefitScheduleList { get; set; }
    //}
}
