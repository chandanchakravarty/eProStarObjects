using System;


namespace BusinessObjectLayer.SystemAdmin.ClientSetup
{
   public class clsOccupationMaster
    {
        public int Lookup_ID { get; set; }
        //public string LooKup_value { get; set; }
        public string Lookup_desc { get; set; }
        public string User { get; set; }
        public string IsEditable { get; set; }
        public string IsActive { get; set; }
    }
}
