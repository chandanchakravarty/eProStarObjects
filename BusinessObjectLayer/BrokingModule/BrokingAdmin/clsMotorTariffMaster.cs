using System;


namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsMotorTariffMaster
    {
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public int MotorTariffId { get; set; }
        public string MotorTariffName { get; set; }
        public int VehicleTypeId { get; set; }
        public int MotorCoverageId { get; set; }
        public decimal BasicRate { get; set; }
        public decimal RatePercentage { get; set; }
        public string txtSrchFromDateAdd { get; set; }
        public string txtSrchFromToAdd { get; set; }
        public DateTime EffectiveDateFrom { get; set; }
        public DateTime EffectiveDateTo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string IsActive { get; set; }
        public string Zone { get; set; }
        public string MotorcycleType { get; set; }
        public int? MotorcycleTypeId { get; set; }
        public string MultiplyingFactor { get; set; }
        public string User { get; set; }
        public string Status { get; set; }

    }

    public class clsMotorTariffDetail
    {
        public int MotorTariffDetailId { get; set; }
        public int MotorTariffId { get; set; }
        public string UnitTypeFrom { get; set; }
        public string UnitTypeTo { get; set; }
        public string AdditionalTon { get; set; }
        public string Comprehensive { get; set; }
        public string ThirdParty { get; set; }
        public string Act { get; set; }
        public string User { get; set; }

    }
}
