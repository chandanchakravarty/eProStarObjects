using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.ClaimAdmin
{
    public class clsLossNatureMaster
    {
        public int LossNatureId { get; set; }
        public string LossNatureFor { get; set; }
        public int ClassId { get; set; }
        public string MainClass { get; set; }
        public int LossTypeId { get; set; }
        public string LossType { get; set; }
        public string LossNatureDesc { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
    
    }
}
