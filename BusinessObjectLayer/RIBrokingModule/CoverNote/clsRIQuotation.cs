using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.CoverNote
{
   public  class clsRIQuotation
    {
        public class clsRIEngineeringDetails
        {
            public string TranRefNo { get; set; }
            public string CovernoteNo { get; set; }
            public int EngDetailId { get; set; }
            public string JobNo { get; set; }
            public decimal CompensationLimit { get; set; }
            public string ProjLocationDesc { get; set; }
            public string Principal { get; set; }
            public decimal ContractValue { get; set; }
            public string CommencementDate { get; set; }
            public string CompletionDate { get; set; }
            public int Days { get; set; }
            public string DefLiabilityPeriodFrom { get; set; }
            public string DefLiabilityPeriodTo { get; set; }
            public int DefLiabilityDays { get; set; }
            public decimal PremiumRate { get; set; }
            public decimal Total { get; set; }
            public decimal BalanceLia { get; set; }
            public decimal PremiumRatePer { get; set; }
            public decimal CARBalance { get; set; }
            public decimal Balance { get; set; }
            public string UserId { get; set; }
            public string Mode { get; set; }
        }

        public class clsRIMotorDetails
        {
            public string  TranRefNo { get; set; }
            public string  CovernoteNo { get; set; }
            public int RefNo { get; set; }
            public string VehicleType { get; set; }
            public bool MotorMultipleBilling { get; set; }
            public string RegistrationNo { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public string EngineNo { get; set; }
            public string ChassisNo { get; set; }
            public string CubicCapacity { get; set; }
            public string SeatingCapacity { get; set; }
            public string TypeOfBody { get; set; }
            public decimal NoOfClaimDiscount { get; set; }
            public string FleetNo { get; set; }
            public string RegistrationDate { get; set; }
            public string ManufactureYear { get; set; }
            public string CommecimalVehType { get; set; }
            public string LicenceExpiryDate { get; set; }
            public string Licensed { get; set; }
            public string BusAirCon { get; set; }
            public string BusType { get; set; }
            public int VehicleTypeID { get; set; }
            public string VehicleTypeName { get; set; }
            public int CoverageID { get; set; }
            public string CoverageName { get; set; }
            public decimal BasicRate { get; set; }
            public decimal RatePercentage { get; set; }
            public decimal SumInsured { get; set; }
            public decimal Premium { get; set; }
            public string UserID { get; set; }
            public string Excess { get; set; }

        }

        public class clsRIRiskLocations
        {
            public string TranRefNo { get; set; }
            public string CoverNoteNo { get; set; }
            //public int PolVersionId { get; set; }
            public string LocationDescription { get; set; }
            public int LocationId { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string Address3 { get; set; }
            public int Country { get; set; }
            public string UserId { get; set; }
            public string Mode { get; set; }
            public string POIFromDate { get; set; }
            public string POIToDate { get; set; }
            public string InterestId { get; set; }
            public string InterestDescription { get; set; }
            public string MultipleBilling { get; set; }
            public string  RiskLocMutipleBill { get; set; }
        }
        public class clsRiskLocationsInterest
        {
            public string  TranRefNo { get; set; }
            public string CoverNoteNo { get; set; }
            public int LocationId { get; set; }
            public int InterestId { get; set; }
            public string UserId { get; set; }
            public string InterestHeader { get; set; }
            public string InterestDescription { get; set; }
            public string SumInsured { get; set; }
            public string Valuation { get; set; }

        }
    }
}
