using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
   public class clsIHPremiumRating
    {
       public int IH_ID { get; set; }
       public string Program { get; set; }
       public string Area { get; set; }
       public string Dedcutible {get;set;}
       public decimal Discount { get; set; }
       public int Age { get; set; }
       public string EffFromDate { get; set; }
       public string EffToDate { get; set; }
       public string lastupdatedby { get; set; }       
       public decimal premiumrating{get;set;}
       //By Rituraj for Export IH Card Printing Requirement on 109/09/2015
       public string Name { get; set; }
       public string PolicyNo { get; set; }
       public string Scheme { get; set; }
       public string PlanType { get; set; }
       public string SixtinthDigitsNo { get; set; }
       public string PolVersionId { get; set; }
       public string PolicyId { get; set; }
       //finish here
       public string ProductName { get; set; }
       //public string ProductCode { get; set; }
       public string UniqueNo { get; set; }
       public string UnderWriterName { get; set; }
       //public string UnderWriterCode { get; set; }
       public string calledFrom { get; set; }
   }
}
