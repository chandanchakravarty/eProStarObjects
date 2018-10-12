using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation
{
    public class clsPremiumDetails
    {

    }
    public class clsAnnualPremSec1
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int UWId { get; set; }
        public int SecId { get; set; }
        public string SubSectionName { get; set; }
        public string PreviousCurrency { get; set; }
        public string PreviousSumInsured { get; set; }
        public string Currency { get; set; }
        public string SumInsured { get; set; }
        public string SumInsuredInLocalCurr { get; set; }
        public string Rate { get; set; }
        public string BasicRate { get; set; }
        public string Multiplier { get; set; }
        public string Premium { get; set; }
        public string PremiumInLocalCurr { get; set; }
        public string CoverageType { get; set; }
        public string ID { get; set; }
        public string ExchangeRate { get; set; }
        public string MultiplierAmount { get; set; }


        public string PremiumExchangeRate { get; set; }  //for redmine #33909
        public string PremiumExchangeCurrency { get; set; } //for redmine #33909


    }
    public class clsAnnualPremSec2
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int UWId { get; set; }
        public int SecId { get; set; }
        public string SubSectionName { get; set; }
        public string PreviousSumInsured { get; set; }
        public string SumInsured { get; set; }
        public string Rate { get; set; }
        public string Premium { get; set; }
        public string CoverageType { get; set; }
        public int ID { get; set; }
        
    }
    public class clsProRataSec1
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int UWId { get; set; }
        public int SecId { get; set; }
        public string SubSectionName { get; set; }
        public string Currency { get; set; }
        public string Premium { get; set; }
        public string CoverageType { get; set; }
        public int ID { get; set; }
    }
    public class clsProRataSec2
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int UWId { get; set; }
        public int SecId { get; set; }
        public string SubSectionName { get; set; }
        public string Premium { get; set; }
        public string CoverageType { get; set; }
        public int ID { get; set; }

    }
    public class clsAnuualPremSec1List
    {
        public List<clsAnnualPremSec1> AnnualPremSec1 { get; set; }
    }
    public class clsAnuualPremSec2List
    {
        public List<clsAnnualPremSec2> AnnualPremSec2 { get; set; }
    }
    public class clsProRataSec1List
    {
        public List<clsProRataSec1> ProRataSec1 {get; set;}
    }
    public class clsProRataSec2List
    {
        public List<clsProRataSec2> ProRataSec2 { get; set; }
    }
    public class clsAdditionprem
    {
        public long PolicyAddnlPremId { get; set; }
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int UWId { get; set; }
        public int ID { get; set; }        
        public string PremDescription { get; set; }
        public string PremRate { get; set; }
        public string PremChange { get; set; }
        public string PremSubTotal { get; set; }
    }
    public class clsAdditionpremList
    {
        public List<clsAdditionprem> AdditionPrem { get; set; }
    }
}
