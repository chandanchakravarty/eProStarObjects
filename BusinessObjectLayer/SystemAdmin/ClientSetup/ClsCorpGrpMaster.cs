using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
   public class ClsCorpGrpMaster
    {
        public int? CorpGroupId { get; set; }

        public string CorpGroupCode { get; set; }

        public string CorpGroupType { get; set; }

        public string CorpGroupDesc { get; set; }

        public string EffectiveFromDate { get; set; }

        public string EffectiveToDate { get; set; }

        public string EffectiveFromDate1 { get; set; }

        public string EffectiveToDate1 { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public string IsActive { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
    }
}
