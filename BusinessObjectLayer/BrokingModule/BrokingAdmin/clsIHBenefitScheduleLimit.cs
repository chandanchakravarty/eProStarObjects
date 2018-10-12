using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
   public class clsIHBenefitScheduleLimit
    {
            public int IHScheduleLimitID { get; set; }

            public int IHBenefitScheduleID { get; set; }
            public int IHScheduleGroupID { get; set; }
            public int IHScheduleLineID { get; set; }
            
            
            public int IHPlanID { get; set; }
            public string IHPlanName { get; set; }




            public string IHBenefitScheduleName { get; set; }
            public string IHBenefitScheduleLimitName { get; set; }
            public string EffFromDate { get; set; }
            public string EffFromDate2 { get; set; }
            public string EffToDate { get; set; }
            public string EffToDate2 { get; set; } 
            public string UserID { get; set; }
            public string IsActive { get; set; }
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }
            

    }
}
