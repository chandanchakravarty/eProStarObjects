using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.ClaimAdmin
{
    public class clsClaimPaymentTypeMaster
    {
        public int ClaimPaymentTypeId { get; set; }
        public string ClaimPaymentTypeFor { get; set; }
        public string ClaimPaymentTypeCode { get; set; }
        public string ClaimPaymentTypeDesc { get; set; }
        public string EffectivefromDate { get; set; }
        public string EffectivefromDate1 { get; set; }
        public string Effectivetodate { get; set; }
        public string Effectivetodate1 { get; set; }
        public string User { get; set; }
        public string IsActive { get; set; }
    }
}
