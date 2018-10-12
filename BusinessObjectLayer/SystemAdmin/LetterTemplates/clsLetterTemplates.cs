using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.LetterTemplates
{
    public class clsLetterTemplates
    {
        public int LtrTemplatedId { get; set; }
        public string LtrTemplateName { get; set; }
        public string TemplateType { get; set; }
        public string LoginUserId { get; set; }
    }
    public class clsBodyContents
    {
        public int LtrBId { get; set; }
        public string LtrBDesc { get; set; }
        
    }
    public class clsLetterTemplateDetail
    {
        public int LtrTemplateId { get; set; }
        public int LtrLtrBId { get; set; }
    }
}
