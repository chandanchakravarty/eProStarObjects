using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem
{
    [Serializable]
    public class clsUnApprovedInfo
    {
        public int RecId { get; set; }
        public string RecForType { get; set; }
        public string RecordType { get; set; }
        public string RecordFor { get; set; }
        public int RecForId { get; set; }
        public string RecForModule { get; set; }
        public string Code { get; set; }
        public string RejectReason { get; set; }
        public int AppliedBy { get; set; }
        public string AppliedDate { get; set; }
        public string ApprovingAuthority1 { get; set; }
        public string ApprovingAuthority2 { get; set; }
        public string AppStatus { get; set; }
        public string AppStatus1 { get; set; }
        public string RecData { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public int CedantId { get; set; }
        public string CedantCode { get; set; }
        public string CedantName { get; set; }
        public string CedantForModule { get; set; }
        public string scrval { get; set; }
        public string ClientType { get; set; }
        public string GLCode { get; set; }
        public string BankCode { get; set; }
        public string GLCodeDesc { get; set; }
        public string BankName { get; set; }
        public string ClientShortName { get; set; }
        public string ClientSourceCode { get; set; }
        public string CorporateGroupType { get; set; }
        public string PreviousCode { get; set; }
        public string HidDeleteIntroducer { get; set; }
        public string HidDeleteIntroducer2 { get; set; }
        
       // public string IndroducerData { get; set; }
       
    }
    [Serializable]
    public class UnApprovedContacts
    {
        public string SearchContactType { get; set; }
        public int ContactRecId { get; set; }
        public int ClientRecId { get; set; }
        public string IsPriorityContact { get; set; }
        public string RecForType { get; set; }
        public string RecordFor { get; set; }
        public int RecForId { get; set; }
        public string RecForModule { get; set; }
        public int AppliedBy { get; set; }
        public string AppliedDate { get; set; }
        public string ApprovingAuthority1 { get; set; }
        public string ApprovingAuthority2 { get; set; }
        public string AppStatus { get; set; }
        public string RecData { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public bool IsMainContact { get; set; }
        public string IsContactSOA { get; set; }

    }

    [Serializable]
    public class UnApprovedAgreements
    {
        public int AgreementRecId { get; set; }
        public int ClientRecId { get; set; }        
        public string RecForType { get; set; }
        public string RecordFor { get; set; }
        public int RecForId { get; set; }
        public string RecForModule { get; set; }
        public int AppliedBy { get; set; }
        public string AppliedDate { get; set; }
        public string ApprovingAuthority1 { get; set; }
        public string ApprovingAuthority2 { get; set; }
        public string AppStatus { get; set; }
        public string RecData { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
        public string AgreementNo { get; set; }
        public string AgentCode { get; set; }
        public string ClientCode { get; set; }
        public string ExpiryDateFrom { get; set; }
        public string ExpiryDateTo { get; set; }
    }
    [Serializable]
    public class UnApprovedCommission
    {
       
        public int CommitionRecId { get; set; }
        public int CommitionId { get; set; }
        public int ClientRecId { get; set; }
        public decimal IntroducerSharePer { get; set; }
        public string EffectiveFrom { get; set; }
        public string EffectiveTo { get; set; }
        public string RecForType { get; set; }
        public string RecordFor { get; set; }
        public int RecForId { get; set; }
        public string RecForModule { get; set; }
        public int AppliedBy { get; set; }
        public string AppliedDate { get; set; }
        public string AppStatus { get; set; }
        public string RecData { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }

    }

}
