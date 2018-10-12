using System;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
   public class clsBM_TemplateMaster
    {
        public string frmFor { get; set; }
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public int ClassId { get; set; }
        public string MainClass { get; set; }
        public int SubClassId { get; set; }
        public string SubClass { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public string UnderWriterList { get; set; }
        public int UWID { get; set; }
   }
}
