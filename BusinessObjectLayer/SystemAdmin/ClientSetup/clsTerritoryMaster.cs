using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
    public class clsTerritoryMaster
    {
        public int TerritoryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryShortCode { get; set; }
        public string TerritoryName { get; set; }
        public string TerritoryNameChinese { get; set; }
        public int Codepattern_UW { get; set; }
        public int Codepattern_Agent { get; set; }
        public string User { get; set; }
        public string isActive { get; set; }

        public string EffFrom { get; set; }
        public string EffFrom1 { get; set; }
        public string EffTo { get; set; }
        public string EffTo1 { get; set; }

        //Added By Apurva
        public string WorldReg { get; set; }

    }

    public class clsCorporateMaster
    {
        public int CorporateId { get; set; }
        public string CorporateGroupCode { get; set; }
        public string CorporateGroupType { get; set; }
        public string Corporatedescripation { get; set; }
    
        public string User { get; set; }
        public string isActive { get; set; }

        public string EffFrom { get; set; }
        public string EffFrom1 { get; set; }
        public string EffTo { get; set; }
        public string EffTo1 { get; set; }

    }







}
