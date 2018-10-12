using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    public class clsBMAutoComplete
    {
        public string SearchString { get; set; }
        public string RequestFrom { get; set; }
        public string SearchFor { get; set; }
        public string strUser { get; set; }
        public int strCompany{ get; set; }
        public int strBranch{ get; set; }
        public char charIsComplete { get; set; }
    }
}
