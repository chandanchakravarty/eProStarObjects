using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.CoverNote
{
    public class clsRICNCoverage
    {
        public string Mode { get; set; }
        public string TranRefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public int MainClass { get; set; }
        public int SubClassCode { get; set; }
        public string Id { get; set; }
        public int GeographicalLimit { get; set; }
        public string TradingLimit { get; set; }
        public string ByAir { get; set; }
        public string PerLand { get; set; }
        public string PerWater { get; set; }
        public string Voyage { get; set; }
        public string Earthquake { get; set; }
        public string SRCC{ get; set; }
        public string Thyphoon{ get; set; }
        public string Terrorism{ get; set; }
        public string LoginUserId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
