using System;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
   public class clsBM_HeaderMaster
    {
        public string frmfor { get; set; }
        public int ClassId { get; set; }
        public int SubClassId { get; set; }
        public string MainClass { get; set; }
        public string SubClass { get; set; }
        public int HeaderId { get; set; }
        public string Header { get; set; }
        public string HeaderCH { get; set; }
        public string HeaderDescription { get; set; }
        public string HeaderFullDescription { get; set; }
        public string TariffReferenceCode { get; set; }
        public int? ConditionType { get; set; }
        public int? ToPrint { get; set; }
        public string PrintFor { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public string GroupHeader { get; set; }
    }

   public class AuditLog_HeaderMaster
   {
       public int @TransTypeID { get; set; }
       public int @RecordedBy { get; set; }
       public string @RecordedByName { get; set; }
       public string @RecFor { get; set; }
       public long @RecForClientID { get; set; }
       public long @RecForPolicyID { get; set; }
       public int @RecForPolicyVerID { get; set; }
       public long @RecForIDAddnl { get; set; }
       public string @ScrMenuCode { get; set; }
       public string @TblName { get; set; }
       public string @TblPrimaryKeys { get; set; }
       public string @TblPrimaryKeysValues { get; set; }
       public string @Trans_Desc { get; set; }
       public string @TransLogDetails { get; set; }
       public string @IsEndorse { get; set; }
       public string @Trans_Desc_Text { get; set; }
       public string @IsRenew { get; set; }
   }
}
