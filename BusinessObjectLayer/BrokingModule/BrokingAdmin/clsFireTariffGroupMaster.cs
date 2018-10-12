using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsFireTariffGroupMaster
    {        
        public int FireTariffGroupId { get; set; }
        public string GroupCode { get; set; }
        public string Classification { get; set; }        
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string User { get; set; }
    }

    public class clsFireTariffMaster
    {
        public int FireTariffGroupId { get; set; }
        public int FireTariffId { get; set; }
        public string ConstructionClassification1A { get; set; }
        public string ConstructionClassification1B { get; set; }
        public string ConstructionClassification2 { get; set; }
        public string ConstructionClassification3 { get; set; }
        public string WarrantyApplicable { get; set; }
        public int Code { get; set; }
        public string TOClassification { get; set; }
        public string User { get; set; }
    }
}
