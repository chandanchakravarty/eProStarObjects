using System;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsExtraneousPerilsMaster
    {
        public int ExtraneousPerilID { get; set; }
        public string Item { get; set; }
        public string Coverage { get; set; }
        public string SubCoverage { get; set; }
        public decimal? Excess { get; set; }
        public decimal? StdTariffRate { get; set; }
        public decimal? LoadingRate { get; set; }
        public string Rules { get; set; }
        public string RulesName { get; set; }
        public string User { get; set; }
        public string PageMethod { get; set; }
    }
}
