using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    public class clsContacts
    {
        public int ContactId { get; set; }
        public int Id { get; set; }
        public int ForModule { get; set; }
        public string IsPriorityContact { get; set; }
        public string LastName { get; set; }
        public string ChLastName { get; set; }
        public string FirstName { get; set; }
        public string ChFirstName { get; set; }
        public string JobTitle { get; set; }
        public string ChJobTitle { get; set; }
        public string Department { get; set; }
        public string ChDepartment { get; set; }
        public string ContactCorrAddress1 { get; set; }
        public string ContactCorrAddress2 { get; set; }
        public string ContactCorrAddress3 { get; set; }
        public string ContactCorrAddress4 { get; set; }  // by himanshu 

        public string ChContactCorrAddress1 { get; set; }
        public string ChContactCorrAddress2 { get; set; }
        public string ChContactCorrAddress3 { get; set; }
        public string ChContactCorrAddress4 { get; set; }  // by himanshu 
        public bool SameCorrAddress { get; set; }
        public bool SameChCorrAddress { get; set; }

        public string ContactCountry { get; set; }
        public string ChContactCountry { get; set; }
        public string Team { get; set; }
        public string GeneralLineCode { get; set; }
        public string GeneralLineNo { get; set; }
        public string Extension { get; set; }
        public string DirectLineCode { get; set; }
        public string DirectLineNo { get; set; }
        public string Salutation { get; set; }
        public string ChSalutation { get; set; }
        public string MobileNoCode { get; set; }
        public string MobileNo { get; set; }
        public string FaxNoCode { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffectiveTodate { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }

        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string ChCity { get; set; }
        public string ChProvince { get; set; }
        public string ChPostalCode { get; set; }
        public string SubDistrict { get; set; }
        public string ChSubDistrict { get; set; }
        
    }
}
