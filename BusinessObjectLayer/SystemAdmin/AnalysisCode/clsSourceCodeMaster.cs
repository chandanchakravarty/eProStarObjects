﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.AnalysisCode
{
    public class clsSourceCodeMaster
    {
        public int SCId { get; set; }
        public string SCode { get; set; }
        public string SCDesc { get; set; }
        public string AnalysisCategory { get; set; }
        public string BusinessType { get; set; }
        public int SOBId { get; set; }
        public int SCodeId { get; set; }
        public int SSCode1Id { get; set; }
        public int SSCode2Id { get; set; }
        public string IsGroupMandatory { get; set; }
        public string IsSubGroupMandatory { get; set; }
        public string LinkWithFlex { get; set; }
        public string EffFromDate { get; set; }
        public string EffToDate { get; set; }
        //public string Status { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
    }
}