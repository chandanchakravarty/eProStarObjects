using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.Common
{
    public class JobSchedule
    {
        public string JobFinishDate { get; set; }
        public string JobNumber { get; set; }
        public string JobStartDate { get; set; }
        public string JobStatus { get; set; }
        public string JobType { get; set; }
        public string ProcessRefNo { get; set; }
        public string QueueEndDate { get; set; }
        public string QueueStartDate { get; set; }
        public string Remarks { get; set; }
        public string ScheduledStartDateTime { get; set; }
        public string ScheduledStartDateTimeFrom { get; set; }
        public string ScheduledStartDateTimeTo { get; set; }
    }
}
