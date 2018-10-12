using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjectLayer.SystemAdmin.LetterTemplates;

namespace BusinessObjectLayer.BrokingModule.Reports
{
    public class clsECLetter
    {
        public string PolicyNo { get; set; }
        public string DateOfAccident { get; set; }
        public string NameOfInjured { get; set; }
        public string ClientName { get; set; }
        public string ClientDescription { get; set; }
        public string FaxNo { get; set; }
        public List<clsBodyContents> lstLetterBodyContents { get; set; }
        public String ClaimNo { get; set; }
        public String ClaimHandler { get; set; }
        public String ChequeNo { get; set; }
    }

    public class clsClaimReport
    {
        public string ClientName { get; set; }
        public string PolicyNo { get; set; }
        public int AnnMonth { get; set; }
        public string Period { get; set; }
        public string AnnualPremiumInpatient { get; set; }
        public string AnnualPremiumOutpatient { get; set; }
        public string AnnualPremiumTotal { get; set; }
        public string ProrataPremiumInpatient { get; set; }
        public string ProrataPremiumOutpatient { get; set; }
        public string ProrataPremiumTotal { get; set; }
        public string IncurredAmtInpatient { get; set; }
        public string IncurredAmtOutpatient { get; set; }
        public string IncurredAmtTotal { get; set; }
        public string PaidAmtInpatient { get; set; }
        public string PaidAmtOutpatient { get; set; }
        public string PaidAmtTotal { get; set; }
        public string UsageRatioInpatient { get; set; }
        public string UsageRatioOutpatient { get; set; }
        public string UsageRatioTotal { get; set; }
        public string LossRatioInpatient { get; set; }
        public string LossRatioOutpatient { get; set; }
        public string LossRatioTotal { get; set; }

        public string AnnualPremiumInpatientYearly { get; set; }
        public string AnnualPremiumOutpatientYearly { get; set; }
        public string AnnualPremiumTotalYearly { get; set; }

        public string IncurredAmtInpatientYearly { get; set; }
        public string IncurredAmtOutpatientYearly { get; set; }
        public string IncurredAmtTotalYearly { get; set; }
        public string PaidAmtInpatientYearly { get; set; }
        public string PaidAmtOutpatientYearly { get; set; }
        public string PaidAmtTotalYearly { get; set; }
        public string UsageRatioInpatientYearly { get; set; }
        public string UsageRatioOutpatientYearly { get; set; }
        public string UsageRatioTotalYearly { get; set; }
        public string LossRatioInpatientYearly { get; set; }
        public string LossRatioOutpatientYearly { get; set; }
        public string LossRatioTotalYearly { get; set; }
    }
}
