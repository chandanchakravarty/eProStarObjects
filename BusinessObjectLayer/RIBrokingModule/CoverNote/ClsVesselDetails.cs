using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.CoverNote
{    
    public class ClsVesselDetails
    {        
        public string RefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public string VesselMultipleBilling { get; set; }
        public string VesselName { get; set; }
        public string Built { get; set; }
        public string VesselType { get; set; }
        public string GRT { get; set; }
        public string NRT { get; set; }
        public string BHP { get; set; }
        public string Class { get; set; }
        public string Flag { get; set; }
        public string Dimension { get; set; }
        public string Owner { get; set; }
        public string Managers { get; set; }
        public string Mortgagees { get; set; }
        public string InceptionDate { get; set; }
        public string ExpiryDate { get; set; }

        //for Lawton Asia
        public string GT { get; set; }
        public string RegisteredLength { get; set; }
        public string RegisteredBreadth { get; set; }
        public string RegisteredDepth { get; set; }
        public string NoOfCarry { get; set; }
        public string RegisteredPlate { get; set; }
        public string HMValue { get; set; }
        public string IV { get; set; }
        //end      
        public string UserID { get; set; }

    }
    public class clsSectionDetails
    {
        public string RefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public int MainClassID { get; set; }
        public int SubClassID { get; set; }
        public double SumInsured { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }
        public double Loading { get; set; }
        public double Premium { get; set; }
        public string BillingParty { get; set; }
        public string UserID { get; set; }
        public string PageMode { get; set; }
    }

    public class clsVesselConditionWarrantyMajorExclDetails
    {
        public string RefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public int HeaderID { get; set; }
        public string ConditionHeader { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }
        public string frmFor { get; set; }
        public string PageMode { get; set; }
    }
    public class clsVesselUWDetails
    {
        public string RefNo { get; set; }
        public string CoverNoteNo { get; set; }

        public string UWName { get; set; }
        public string UWCode { get; set; }
        public string PageMode { get; set; }
    }
}
