﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
    public class clsRegion
    {
        public int RegionId { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffectiveFromDate1 { get; set; }
        public string EffectiveToDate { get; set; }
        public string EffectiveToDate1 { get; set; }
        public string LoginUserId { get; set; }
        public string PageMethod { get; set; }
    }
}