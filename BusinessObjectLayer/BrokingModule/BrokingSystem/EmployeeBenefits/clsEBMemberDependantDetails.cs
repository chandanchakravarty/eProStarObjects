using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.EmployeeBenefits
{
    public class clsEBMemberDependantDetails
    {
        public string PageMode              { get; set; }
        public string CaseRefNo             { get; set; }
        public string MemberCode            { get; set; }    
        public string ClientCode            { get; set; }
        public string ClientName            { get; set; }
        public string DependantCode         { get; set; }
        public string DependantStatusCode   { get; set; }
        public string DependantStatusDesc   { get; set; }
        public string Prev_DependantCode    { get; set; }
        public string DependantName         { get; set; }
        public string CardDependantName     { get; set; }
        public string RelationShipCode      { get; set; }    
        public string RelationShipDesc      { get; set; }
        public string PassportNo            { get; set; }
        public string DateofBirth           { get; set; }
        public string Gender                { get; set; }
        public string MaritalStatus         { get; set; }
        public string NationalityCode       { get; set; }
        public string Nationality           { get; set; }
        public string StaffID               { get; set; }
        public string LocationCode          { get; set; }
        public string Location              { get; set; }
        public string OccupationCode        { get; set; }    
        public string OccupationDesc        { get; set; }
        public string BeneficiaryCode       { get; set; }
        public string BeneficiaryDesc       { get; set; }
        public string Position              { get; set; }        
        public string DateOfEmployment      { get; set; }
        public string VIPPrivilegeCode      { get; set; }
        public string VIPPrivilegeDesc      { get; set; }
        public string Remarks               { get; set; }
        public string EffectiveDate         { get; set; }
        public string TerminationDate       { get; set; }
        public string ReJoinDate            { get; set; }
        public decimal Salary { get; set; }
        public string UserID { get; set; }
        public string DeptType {get;set;}

    }
}
