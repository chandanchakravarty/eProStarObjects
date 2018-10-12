using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.Reports
{
    public class clsEBRenewalLetter
    {
        public string ClientName { get; set; }
        public string ClientContactName { get; set; }
        public string ClientAddress { get; set; }
        public string ClientContactCountry { get; set; }
        public string AccountHandlerName { get; set; }
        public string ContactCountry { get; set; }
        public string ClientFirstName { get; set; }
        public string PolicyNo { get; set; }
        public string PrimaryHandlerDescription { get; set; }
        public string SecondaryHandlerDescription { get; set; }
        public string SubClassName { get; set; }
        public string POIFromDate { get; set; }
        public string POIToDate { get; set; }
        public string UnderwriterName { get; set; }
        public string ClientFullName { get; set; }
        public string fortnightBeforePOIToDate { get; set; }
        public string PaymentMode { get; set; }
        public string TotalPremium { get; set; }
        public string Currency { get; set; }
        public string DebitNoteNo { get; set; }
        public string ContactCorrAddress1 { get; set; }
        public string ContactCorrAddress2 { get; set; }
        public string ContactCorrAddress3 { get; set; }
    }
}
