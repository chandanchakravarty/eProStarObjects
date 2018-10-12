using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.CPD
{
    public class clsCPD
    {
        public int CPDid { get; set; }
        public int UserId { get; set; }
        public string TraineeName { get; set; }
        public string CpdYear { get; set; }
        public string CourseStartDate { get; set; }
        public string CourseEndDate { get; set; }
        public string CourseStartDate1 { get; set; }
        public string CourseEndDate1 { get; set; }
        public string CourseName { get; set; }
        public string TrainingProvider { get; set; }
        public decimal TrainingHours { get; set; }
        public decimal CPDHoursAccredited { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }

    }
}
