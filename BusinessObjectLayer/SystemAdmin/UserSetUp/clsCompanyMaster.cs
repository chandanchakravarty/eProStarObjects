using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetup
{
    public class clsCompanyMaster
    {
        public int CompanyId { get; set; }

        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string FaxNoPrefx { get; set; }
        public string FaxNo { get; set; }
        public string TelephoneNoPrefx { get; set; }
        public string TelephoneNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string CountryCode { get; set; }
        public string Remarks { get; set; }
        public string EffectivefromDate { get; set; }
        public string EffectivefromDate1 { get; set; }
        public string Effectivetodate { get; set; }
        public string Effectivetodate1 { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
        public bool ThirdLevelAprvReq { get; set; }
        public string FinancialYearDay { get; set; }
        public string FinancialYearMonth { get; set; }
        public string Currency { get; set; }
        public string Attach_Location { get; set; }
        public string Attach_InternalFileName { get; set; }
        public string Attach_DisplayFileName { get; set; }
        public string Country { get; set; }
        public int ProvinceCode { get; set; }
        public int CityCode { get; set; }
        public string PageMethod { get; set; }
        public string DepartmentIds { get; set; }
    }
}
