using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetup
{
  public class clsDocumentCompliance
    {
            public int DocID { get; set; }
            public int UserId { get; set; }
            public string PaperType { get; set; }
            public string PaperDesc { get; set; }
            public string CreatedBy { get; set; }
    }
  public class clsRenewalReason
  {
      public int DocID { get; set; }
      public int UserId { get; set; }
      public string RenewalLapsedReason { get; set; }
      public string Description { get; set; }
      public string CreatedBy { get; set; }
  }



}
