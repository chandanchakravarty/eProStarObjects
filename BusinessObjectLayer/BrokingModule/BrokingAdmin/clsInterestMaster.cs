using System;


namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsInterestMaster
    {
        public int ClassId { get; set; }
        public int SubClassId { get; set; }
        public int InterestId { get; set; }
        public string Header { get; set; }
        public string InterestDescription { get; set; }
        public decimal SumInsured { get; set; }
        public decimal Valuation { get; set; }
        public string EffectiveDateFrom { get; set; }
        public string EffectiveDateFrom1 { get; set; }
        public string EffectiveDateTo { get; set; }
        public string EffectiveDateTo1 { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public int PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public string InterestIds { get; set; }
        public string Remarks { get; set; }
        public string Rates { get; set; }
        public string Premium { get; set; }
        public int LocationInterestId { get; set; }
        public int Construction { get; set; }
        public string PIAM { get; set; }
        public string Order { get;set;}
        public int isReload { get; set; }
    }
}
