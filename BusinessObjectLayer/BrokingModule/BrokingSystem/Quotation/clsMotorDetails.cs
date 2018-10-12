using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation
{
    public class clsMotorDetails
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int RefNo { get; set; }
        public string VehicleType{ get; set; }
        public bool MotorMultipleBilling { get; set; }
        public string RegistrationNo{ get; set; }
        public string Make{ get; set; }
        public string Model{ get; set; }
        public string EngineNo{ get; set; }
        public string ChassisNo{ get; set; }
        public string CubicCapacity{ get; set; }
        public string SeatingCapacity{ get; set; }
        public string TypeOfBody{ get; set; }
        public decimal NoOfClaimDiscount{ get; set; }
        public string FleetNo{ get; set; }
        public string RegistrationDate{ get; set; }
        public string ManufactureYear{ get; set; }
        public string CommecimalVehType{ get; set; }
        public string LicenceExpiryDate{ get; set; }
        public string Licensed{ get; set; }
        public string BusAirCon{ get; set; }
        public string BusType { get; set; }        
        public int    VehicleTypeID { get; set; }
        public string VehicleTypeName { get; set; }
        public int    CoverageID { get; set; }
        public string CoverageName { get; set; }
        public decimal BasicRate { get; set; }
        public decimal RatePercentage { get; set; }
        public decimal SumInsured { get; set; }
        public decimal Premium { get; set; }
        public string UserID { get; set; }
        public string Excess { get; set; }

        public string ZoneType {get; set; }
        public int CCTonnage { get; set; }
        public string VehicleLogBookNo { get; set; }
        public decimal WindscreenSI { get; set; }
        public decimal LoadingPer { get; set; }
        public decimal LoadingAmt { get; set; }
        public decimal AllRiderPer { get; set; }
        public decimal AllRiderAmt { get; set; }
        public decimal NCBPer { get; set; }
        public decimal NCBAmt { get; set; }
        public decimal WindscreenPer { get; set; }
        public decimal WindscreenAmt { get; set; }
        public decimal ADND { get; set; }
        public decimal LLTP { get; set; }
        public decimal LLOP { get; set; }
        public decimal SRCC { get; set; }
        public decimal RdoCassettePer { get; set; }
        public decimal RdoCassetteAmt { get; set; }
        public decimal Flood { get; set; }
        public decimal TPWR { get; set; }
        public decimal TotalPremium { get; set; }
    }
}
