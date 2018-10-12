using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation
{
    public class clsRatingDetails
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public string RefNo { get; set; }
        public string Insurer { get; set; }
        public string InsuredName { get; set; }
        public string Surname { get; set; }
        public string DOB { get; set; }
        public int age { get; set; }
        public int ageMonth { get; set; }
        public int ageDays { get; set; }
        public char Gender { get; set; }
        public string Nationality { get; set; }
        public string CountryOfRes { get; set; }
        public string PIHCardNo { get; set; }
        public string MemberNo { get; set; }
        public string MemberType { get; set; }

        public string Scheme { get; set; }
        public string Program { get; set; }
        public string PlanType { get; set; }
        public string Deductible { get; set; }
        public string IHDiscount { get; set; }
        public decimal PremiumRate { get; set; }
        public decimal PremWithInstl { get; set; }
        public decimal StamDuty { get; set; }
        public decimal SBT { get; set; }
        public decimal VAT { get; set; }
        public double GrossPremium { get; set; }
        public decimal Commission { get; set; }
        public decimal IHDiscountAmt { get; set; }

        public char IsActive { get; set; }
        public string UserID { get; set; }

        // Added By Rituraj on 10/02/2016 For IH Master Policy Report
        public string InsuredFullName { get; set; }
        public string MemberCode { get; set; }
        public string ClientCode { get; set; }

        public string ClientName { get; set; }
        public string MasterPolicyNo { get; set; }
        public string ConfirmationSlipNo { get; set; }
        public string POIFrom { get; set; }
        public string POIToDate { get; set; }
        public string RptType { get; set; }
        public string PolicyNo { get; set; }

        public decimal IHSbtAmount { get; set; }
        public decimal IHStampDutyAmount { get; set; }

        //public string RptType { get; set; }

        //Added For #26865
        public decimal IHLoadingPer { get; set; }
        public decimal IHLoadingPerAmt { get; set; }
    }
}
