using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits
{
   public class clsEBMemberAddress
    {
          public string CaseRefNo	            { get; set; }
          public string MemberCode	            { get; set; }
          public string CorresPond_Address1	    { get; set; }
          public string CorresPond_Address2	    { get; set; }
          public string CorresPond_Address3	    { get; set; }
          public string CorresPond_CountryCode	{ get; set; }
          public string CorresPond_CountryName	{ get; set; }
          public string CorresPond_OfficeTelNo1	{ get; set; }
          public string CorresPond_OfficeTelNo2	{ get; set; }
          public string CorresPond_MoblieNo1	{ get; set; }
          public string CorresPond_MoblieNo2	{ get; set; }
          public string CorresPond_FaxNo1	    { get; set; }
          public string CorresPond_FaxNo2	    { get; set; }
          public string CorresPond_EffectiveFromDate { get; set; }
          public string CorresPond_EffectiveToDate	 { get; set; }
          public string Resident_Address1	    { get; set; }
          public string Resident_Address2	    { get; set; }
          public string Resident_Address3	    { get; set; }
          public string Resident_CountryCode	{ get; set; }
          public string Resident_CountryName	{ get; set; }
          public string Resident_OfficeTelNo1	{ get; set; }
          public string Resident_OfficeTelNo2	{ get; set; }
          public string Resident_MoblieNo1	    { get; set; }
          public string Resident_MoblieNo2	    { get; set; }
          public string Resident_FaxNo1	        { get; set; }
          public string Resident_FaxNo2	        { get; set; }
          public string Resident_EffectiveFromDate	  { get; set; }
          public string Resident_EffectiveToDate { get; set; }
          public string UserID { get; set; }
          public string Res_Email { get; set; }
          public string Coress_Email { get; set; }

          public int Coress_CountryId { get; set; }
          public int Res_CountryId { get; set; }
          public int Coress_CityId { get; set; }
          public int Res_CityId { get; set; }
          public int Coress_ProvinceId { get; set; }
          public int Res_ProvinceId { get; set; }
          public string Coress_PostalCode { get; set; }
          public string Res_PostalCode { get; set; }
         



    }
}
