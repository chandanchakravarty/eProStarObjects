using System;


namespace BusinessObjectLayer.SystemAdmin.AccountMaster
{
    public class clsAccPeriod
    {
        public int AccYear { get; set; }
        public int AccMonth { get; set; }
        public string EffectiveDateFrom { get; set; }
        public string EffectiveDateTo { get; set; }
        public string User { get; set; }
    }
}
