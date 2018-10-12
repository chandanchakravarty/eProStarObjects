using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.AnalysisCode
{
    public class clsSubClass
    {
        public Int32 SubClassId { get; set; }
        public string AnalysisCategory { get; set; }
        public string BalBF_NRP { get; set; }
        public int ClassID { get; set; }
        public string SubClassCode { get; set; }
        public string SubClassName { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate2 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate2 { get; set; }
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public bool CStatus { get; set; }
        public string PremWarrnty { get; set; }
        public string GST { get; set; }
        public string CashBeforeCover { get; set; }
        public string BNClass { get; set; }
        public string Currency { get; set; }
        public string premium { get; set; }
        public string underwritername { get; set; }
        public int IsPremium { get; set; }
        public int minPremiumId { get; set; }
        public int GSTType { get; set; }
        public string RenewalType { get; set; }

        public string SubClassType { get; set; }
        public int PPWDaysCredit { get; set; }
    }
}
