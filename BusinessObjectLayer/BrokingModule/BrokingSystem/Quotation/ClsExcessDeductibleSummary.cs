namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation
{
    public class ClsExcessDeductibleSummary
    {
        public string PolicyId { get; set; }
        public string PolicyVerId { get; set; }
        public int SubClassCode { get; set; }
        public string ID { get; set; }
        public string IsChecked { get; set; }
        public string Category { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
        public string Basis { get; set; }
        public string UserId { get; set; }
    }
}
