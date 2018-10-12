namespace BusinessObjectLayer.RIBrokingModule.Reports
{
    public class clsReport
    {
        public string PeriodFrom { get; set; }
        public string PeriodTo { get; set; }

        public string ClaimNo { get; set; }
        public string InvoiceNo { get; set; }
        public string CoverNoteNo { get; set; }
        public string ReinsurerName { get; set; }
        public string Reinsurercode { get; set; }
        public string CedantName { get; set; }
        public string Cedantcode { get; set; }
        public string ClientName { get; set; }
        public string Clientcode { get; set; }
        public string MainClass { get; set; }
        public string SubClass { get; set; }
        public string ClaimCreateMonth { get; set; }
        public string CedantPolicyNo { get; set; }

        //For Brokerage Report
        public string CoverNote { get; set; }
        //public string InvoiceNo { get; set; }

        //public string ReinsurerName { get; set; }
        //public string ReinsuredCode { get; set; }
        public string InsurerCode { get; set; }
        public string InsurerName { get; set; }
        public string MonthDate { get; set; }
        public string User { get; set; }
        //public string MainClass { get; set; }
        public string Currency { get; set; }
    }
}
