using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BusinessObjectLayer.BrokingModule.BrokingSystem.Quotation
{
    public class clsVesselDetails
    {
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public string RefNo { get; set; }
        public string VesselMultipleBilling { get; set; }
        public string VesselName{ get; set; }
        public string Built{ get; set; }
        public string VesselType{ get; set; }
        public string GRT { get; set; }
        public string NRT{get;set;}
        public string BHP { get; set; }
        public string Class  {get;set;}
        public string Flag { get; set; }
        public string Dimension { get; set; }
        public string Owner { get; set; }
        public string Managers { get; set; }
        public string Mortgagees { get; set; }
        public string InceptionDate { get; set; }
        public string ExpiryDate { get; set; }
        //  Extra fields for Vessel Upload
        public string DWT { get; set; }
        public string IMONo { get; set; }
        public string IVInsuredValue { get; set; }
        public string AOIInsuredValue { get; set; }
        public string AdditionalAssureds { get; set; }
        public string GeneralAverage { get; set; }

        public string TranRefNo { get; set; }
        public string CoverNoteNo { get; set; }
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
        public DataTable dt { get; set; }
        public string COI { get; set; }
        public string frmFor { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FilePath { get; set; }
        public string UploadedBy { get; set; }
        public string UploadFromDate { get; set; }
        public string UploadToDate { get; set; }
        public string Source { get; set; }
        public int TotalRecord { get; set; }
        public int SuccessRecord { get; set; }
        public int FailRecord { get; set; }

        /*Added for rdmine 23517*/

        public string DesignDraft { get; set; }
        public string RegisteredOwner { get; set; }
        public string OtherInsuredParties { get; set; }
        public string Shipyard { get; set; }
        public string CallsignDistincitiveNo { get; set; }
        public string CraneLiftingCapacity { get; set; }
        public string TradingPlyingLimit { get; set; }
        public string ValueofVessels { get; set; }
        public string Classification { get; set; }
        public string LengthOverall { get; set; }
        public string HullNo { get; set; }
        public string BollardPull { get; set; }
        public string Clause12 { get; set; }
        public string AMD { get; set; }
        public string VesselStatus { get; set; }
        public string LayupReturn { get; set; }
    }
    public class clsSectionDetails
    {        
        public long PolicyId { get; set; }
        public int PolVersionId { get; set; }
        public string RefNo { get; set; }
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

        public string TranRefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public double Share { get; set; }
        public string UnderWriterCode { get; set; }
        public string Remarks { get; set; }
        public string Deductible { get; set; }
        public string LayUpReturn { get; set; }
    }

    public class clsVesselConditionWarrantyMajorExclDetails
    {
        public string RefNo { get; set; }
        public long PolicyID { get; set; }
        public int PolicyVerID { get; set; }
        public int HeaderID { get; set; }
        public string ConditionHeader { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }
        public string frmFor { get; set; }
        public string PageMode { get; set; }

        public string TranRefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public int UnderwriterId { get; set; }
        public string  IsChecked { get; set; }

    }
    public class clsVesselUWDetails
    {
        public string RefNo { get; set; }
        public long PolicyID { get; set; }
        public int PolicyVerID { get; set; }
        public int SubClassId { get; set; }
        public string UWName { get; set; }
        public string UWCode { get; set; }
        public string PageMode { get; set; }
    }
}
