using System;


namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsBenefitGroupLineMaster
    {
        public int BenefitScheduleID { get; set; }
        public int BenefitGroupLineID { get; set; }
        public string BenefitGroupLineName { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public string IsSelected { get; set; }
        public string DeptType { get; set; }
    }
}
