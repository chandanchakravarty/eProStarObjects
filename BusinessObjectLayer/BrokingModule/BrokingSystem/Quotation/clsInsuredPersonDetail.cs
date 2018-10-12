using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation
{
    public class clsInsuredPersonDetail
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int RefNo { get; set; }
        public string InsuredName { get; set; }
        public string Surname { get; set; }
        public string DOB { get; set; }
        public char Gender { get; set; }
        public char MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public string CountryOfRes { get; set; }
        public string StaffID { get; set; }
        public char IsActive { get; set; }
        public string UserID { get; set; }
    }
}
