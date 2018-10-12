using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingAdmin
{
    public class clsLocationInterestMaster
    {
        public Int32 LocationID { get; set; }
        public string Location { get; set; }

        public string Occupation { get; set; }

        public string Construction { get; set; }
        public string ConstructionName { get; set; }

        public Int32 PIAM { get; set; }
        public string PIAMName { get; set; }

        public string SumInsuredValue { get; set; }

        public string User { get; set; }
        public string IsActive { get; set; }

        public int PolicyId { get; set; }

        public int PolVersionId { get; set; }

        public string QuotationNo { get; set; }

        public int MainClassid { get; set; }
        public int SubclassId { get; set; }

    }
}
