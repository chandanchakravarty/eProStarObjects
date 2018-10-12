using System;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsVehicleDetailMaster
    {
        public int VehicleTypeID { get; set; }
        public string VehicleType { get; set; }
        public string Units { get; set; }
        public string UnitsName { get; set; }
        public decimal? SumInsured { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
    }
}
