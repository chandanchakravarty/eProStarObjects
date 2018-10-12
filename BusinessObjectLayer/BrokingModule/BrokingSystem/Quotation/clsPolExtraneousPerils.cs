using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation
{
    public class clsPolExtraneousPerils
    {
        public int Pol_ExtraneousPerilID { get; set; }
        public string PolicyId { get; set; }
        public string PolicyVerId { get; set; }
        public int ExtraneousPerilID { get; set; }
        public string Item { get; set; }
        public string Coverage { get; set; }
        public string SubCoverage { get; set; }
        public decimal ItemIndured { get; set; }
        public decimal StdTariffRate { get; set; }
        public decimal LoadingRate { get; set; }
        public string Rules { get; set; }
        public string LocationsId { get; set; }
        public string PremRateApplicable { get; set; }
        public string UserId { get; set; }

    }
}
