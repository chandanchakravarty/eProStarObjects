using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsIHProduct
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public Int64 UniqueNo { get; set; }
        public string UWName { get; set; }
        public string UWCode { get; set; }
        public string EffFromDate { get; set; }
        public string EffFromDate1 { get; set; }
        public string EffToDate { get; set; }
        public string EffToDate1 { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public string PageMode { get; set; }
    }
}
