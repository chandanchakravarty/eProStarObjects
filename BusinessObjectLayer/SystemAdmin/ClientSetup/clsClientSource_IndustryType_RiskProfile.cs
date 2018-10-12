using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
    public class clsClientSource_IndustryType_RiskProfile
    {
        public int ClientSourceID { get; set; }
        public string ClientSource { get; set; }
        public string CreatedBy { get; set; }
    }
    public class clsIndustryTypeRiskProfile
    {
        public int TypeID { get; set; }
        public string Type { get; set; }
        public string Desc { get; set; }
        public string CreatedBy { get; set; }
        public string MasterName { get; set; }

        public string EffFrom { get; set; }
        public string EffFrom1 { get; set; }
        public string EffTo { get; set; }
        public string EffTo1 { get; set; }

    }
    //public class clsRiskProfile
    //{

    //    public int RiskProfileID { get; set; }
    //    public string RiskProfileType { get; set; }
    //    public string RiskProfileDesc { get; set; }
    //    public string CreatedBy { get; set; }

    //}
    public class ReminderSetup
    {
        public int ReminderSetUpId { get; set; }
        public string Class { get; set; }
        public string ReminderType { get; set; }
        public string ClaimType { get; set; }
        public string LogClaim { get; set; }
        public decimal ReminderDays { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffectiveFromDate2 { get; set; }
        public string EffectiveToDate { get; set; }
        public string EffectiveToDate2 { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public string LastUpdatedDate { get; set; }
    }
}
