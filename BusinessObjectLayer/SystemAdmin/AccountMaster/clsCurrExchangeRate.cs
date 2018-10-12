using System;


namespace BusinessObjectLayer.SystemAdmin.AccountMaster
{
   public class clsCurrExchangeRate
    {
       public int CurrExchangeRateId { get; set; }
       public int CurrencyId { get; set; }
       public string CurrencyCode { get; set; }
       public string isExport { get; set; }
       public string EffectiveFromDate { get; set; }
       public string EffectiveToDate { get; set; }
       public decimal ExchangeRateToCurr { get; set; }
       public decimal ExchangeRateToHKD { get; set; }
       public string AccYear { get; set; }
       public string User { get; set; }
       public int PrevCurrExchangeRateId { get; set; }
    }
}
