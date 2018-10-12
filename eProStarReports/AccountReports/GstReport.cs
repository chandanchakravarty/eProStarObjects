using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace eProStarReports.AccountReports
{
    public class GstReport
    {
        public string TranType { get; set; }
        public string TranRefNo { get; set; }
        public string TranRefNo1 { get; set; }

        public decimal GstAmount { get; set; }
        public decimal GstBaseAmount { get; set; }
        public decimal GstIncAmount { get; set; }

        public string GLCode { get; set; }
        public string GstType { get; set; }
        public string GstCode { get; set; }
        
        public decimal GstRate { get; set; }
        public string GSTID { get; set; }
        public string TranDate { get; set; }
        public string AdjType { get; set; }

        public List<GstReport> GetGstReport(DataTable dtGstReport)
        {
            List<GstReport> lstGstReport = new List<GstReport>();
            foreach (DataRow dro in dtGstReport.Rows)
            {
                try
                {
                    lstGstReport.Add(
                        new GstReport()
                        {
                            TranType = dro["TranType"].ToString(),
                            TranRefNo = dro["TranRefNo"].ToString(),
                            TranRefNo1 = dro["TranRefNo1"].ToString(),

                            GstAmount = decimal.Parse(dro["GstAmount"].ToString()),
                            GstBaseAmount = decimal.Parse(dro["GstBaseAmount"].ToString()),
                            GstIncAmount = decimal.Parse(dro["GstIncAmount"].ToString()),

                            GLCode = dro["GLCode"].ToString(),
                            GstType = dro["GstType"].ToString(),
                            GstCode = dro["GstCode"].ToString(),

                            GstRate = decimal.Parse(dro["GstRate"].ToString()),
                            TranDate = dro["TranDate"].ToString(),
                            AdjType = dro["AdjType"].ToString()
                        }
                        );
                }

                catch (Exception ex)
                {
                }
            }
            return lstGstReport;
        }

    }
}
