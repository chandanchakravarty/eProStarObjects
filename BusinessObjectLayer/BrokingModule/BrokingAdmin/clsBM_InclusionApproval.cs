using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsBM_InclusionApproval
    {
        public string frmfor { get; set; }
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public int ClassId { get; set; }
        public int SubClassId { get; set; }
        public string MainClass { get; set; }
        public string SubClass { get; set; }
        public int HeaderId { get; set; }
        public string Header { get; set; }
        public string HeaderCH { get; set; }
        public string HeaderDescription { get; set; }
        public string EffFromDate { get; set; }
        public string EffDateTo { get; set; }
        public string HeaderFullDescription { get; set; }
        public string TariffReferenceCode { get; set; }
        public int ConditionType { get; set; }
        public int ToPrint { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public string GroupHeader { get; set; }
    }

    public class clsBM_InclusionApproval_Rejection_Status
    {
        public int TemplateId { get; set; }
        public int HeaderId { get; set; }
        public string user { get; set; }
        public int ApprovalStatus { get; set; } ///--0 for Rejected, 1 for Approved
        public string RejectReason { get; set; }
    }
}

