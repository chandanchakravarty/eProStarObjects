using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjectLayer.SystemAdmin.UserSetUp
{
  public class clsDivisionalGrouping
    {
        public int ID { get; set; }
        public string DivType { get; set; }
        public string Channel { get; set; }
        public string SubChannel { get; set; }
        public string EffFrom { get; set; }
        public string EffFrom1 { get; set; }
        public string EffTo { get; set; }
        public string EffTo1 { get; set; }
        public string CreatedBy { get; set; }
        public string DivCode { get; set; }
        public string DivName { get; set; }
    }
}
