using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
    public class clsClientSegmentMaster
    {

        public int ClientSegmentId { get; set; }

        public string ClientSegmentCode { get; set; }

        public string ClientSegmentDesc { get; set; }

        public string EffectiveFromDate { get; set; }

        public string EffectiveToDate { get; set; }

        public string EffectiveFromDate1 { get; set; }

        public string EffectiveToDate1 { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedDate { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public string IsActive { get; set; }

        public string User { get; set; }

    }
}
