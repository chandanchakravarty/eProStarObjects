using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation
{
    public class clsDiaryInfo
    {
        public long DiaryId { get; set; }
        public int DiaryFor { get; set; }
        public string DiaryDate { get; set; }
        public int ClientId { get; set; }
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public string DiaryDesc { get; set; }
        public string Status { get; set; }
        public string ReDiaryDate { get; set; }
        public string ReDiaryStatus { get; set; }
        public string User { get; set; }
    }
    public class ClsRenewalLetter
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public int ClientId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public string AuthName { get; set; }
        public string AuthDesignation { get; set; }
        public string User { get; set; }
    }
    public class ClsRenewalLetter_RI
    {
        public string PolicyId { get; set; }
        public string PolVersionId { get; set; }
        public string ClientId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public string AuthName { get; set; }
        public string AuthDesignation { get; set; }
        public string User { get; set; }
    }
    public class clsDiaryInfo_RI
    {
        public long DiaryId { get; set; }
        public int DiaryFor { get; set; }
        public string DiaryDate { get; set; }
        public int ClientId { get; set; }
        public string CoverNoteNo { get; set; }
        public string TranRefNo { get; set; }
        public string DiaryDesc { get; set; }
        public string Status { get; set; }
        public string ReDiaryDate { get; set; }
        public string ReDiaryStatus { get; set; }
        public string User { get; set; }
    }
    public class ClsRenContentData
    {
        public string Header { get; set; }
        public string Subject { get; set; }
        public string Para1 { get; set; }
        public string Para2 { get; set; }
        public string Para3 { get; set; }
        public string Para4 { get; set; }
        public string Footer { get; set; }

    }
}
