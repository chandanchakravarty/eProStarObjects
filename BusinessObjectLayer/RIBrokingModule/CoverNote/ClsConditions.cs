using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.RIBrokingModule.CoverNote
{
    public class ClsConditions
    {
        public string TranRefNo { get; set; }
        public string CoverNoteNo { get; set; }
        public int MainClassId { get; set; }
        public int SubClassCode { get; set; }        
        public string ID { get; set; }
        public string IsChecked { get; set; }
        public string Clause { get; set; }
        public decimal Limit { get; set; }
        public decimal Percentage { get; set; }
        public string ClauseType { get; set; }
        public string UserId { get; set; }
        public string MainHeader { get; set;}
        public string TitleDescription { get; set; }
        public string frmfor { get; set; }
        public int HeaderID { get; set; }
        public int PrintOrder{ get; set; }
    }
}
