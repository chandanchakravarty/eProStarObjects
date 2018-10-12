using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.AnalysisCode
{
   public class clsClassTemplate
   {
    public int ClassTemplateID {get;set;}
	public string ClassTemplateName {get;set;}
	public int ClassID {get;set;}
	public string UserId {get;set;}
    public string IsActive { get; set; }
    
   }
   public class clsClassTemplateDetail
   {
       public int ClassTemplateID { get; set; }
       public int TemplateId { get; set; }
       public string FieldLabel { get; set; }
       public string ChFieldLabel { get; set; }
       public int IncDispOrder { get; set; }
       public string IsMandatory { get; set; }
       public string ToBePrinted { get; set; }
       public int ToBePrintedOrder { get; set; }
       public string DebitNoteField { get; set; }
       public int DebitNoteOrder { get; set; }
       public string CreditNoteField { get; set; }
       public int CreditNoteOrder { get; set; }
       public int IsSelected { get; set; }
      
   }
   public class ClassTemplateDetailList
   { 
   public List<clsClassTemplateDetail> TemplateList{get;set;} 
   }
}
