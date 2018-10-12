
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using Telerik.Charting.Styles;
using System.Dynamic;
using System.IO;
using BusinessAccessLayer.Common;

namespace eProStarReports
{
    public class ReportsUtility
    {
        private static string _appCssPath = "";
        public static void GeneratePieChart(DataTable dt, Telerik.Reporting.Chart _PieChart, string perField, string lblField)
        {
            try
            {
                Color[] colors = (new Color[10]
                    {
                        
                        Color.Red,
                        Color.Orange,
                        Color.Yellow,
                        Color.Green,
                        Color.Blue,
                        Color.Indigo,
                        Color.Violet,
                        Color.Wheat,
                        Color.SkyBlue,
                        Color.Purple,

                    });

                _PieChart.Width = Telerik.Reporting.Drawing.Unit.Pixel(610);
                _PieChart.Height = Telerik.Reporting.Drawing.Unit.Pixel(500);
                if (perField == "A_Percentage" || perField == "V_Percentage")
                {
                    _PieChart.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Pixel(0), Telerik.Reporting.Drawing.Unit.Pixel(700));
                }
                else if (perField == "F_Percentage")
                {
                    _PieChart.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Pixel(0), Telerik.Reporting.Drawing.Unit.Pixel(1300));
                }

                _PieChart.IntelligentLabelsEnabled = false;
                Telerik.Reporting.Charting.ChartSeries _ChartSeries = new Telerik.Reporting.Charting.ChartSeries();

                _ChartSeries.Appearance.LabelAppearance.Distance = 60;
                _ChartSeries.DefaultLabelValue = "#Y, (#%{#0.##%})";
                _ChartSeries.Appearance.ShowLabelConnectors = true;
                //_ChartSeries.Appearance.StartAngle = 30;
                _ChartSeries.Name = "NameOfSeries";
                _ChartSeries.Type = Telerik.Reporting.Charting.ChartSeriesType.Pie;

                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    Telerik.Reporting.Charting.ChartSeriesItem _ChartSeriesItem = new Telerik.Reporting.Charting.ChartSeriesItem();
                    string percentage = dt.Rows[i][perField].ToString();
                    _ChartSeriesItem.YValue = Convert.ToDouble(percentage);
                    _ChartSeriesItem.Name = dt.Rows[i][lblField].ToString();
                    //Legend Text with percentage may used in future
                    // _ChartSeriesItem.Name = dt.Rows[i][lblField].ToString() + " - " + percentage + " %";

                    _ChartSeriesItem.Appearance.Exploded = true;
                    _ChartSeriesItem.Label.TextBlock.Text = percentage + " %";
                    _ChartSeriesItem.Label.TextBlock.Appearance.FillStyle.MainColor = Color.White;
                    _ChartSeriesItem.Label.TextBlock.Appearance.FillStyle.FillType = Telerik.Reporting.Charting.Styles.FillType.Solid;
                    _ChartSeriesItem.Appearance.FillStyle.MainColor = colors[i];
                    _ChartSeriesItem.Appearance.FillStyle.FillType = Telerik.Reporting.Charting.Styles.FillType.Solid;


                    _ChartSeries.Items.Add(_ChartSeriesItem);


                }

                _ChartSeries.Appearance.LegendDisplayMode = Telerik.Reporting.Charting.ChartSeriesLegendDisplayMode.ItemLabels;

                //Telerik.Reporting.Charting.ChartLegend obj = new Telerik.Reporting.Charting.ChartLegend();

                _ChartSeries.Appearance.FillStyle.MainColor = Color.WhiteSmoke;
                _ChartSeries.Appearance.FillStyle.SecondColor = Color.WhiteSmoke;
                _ChartSeries.Appearance.FillStyle.FillType = Telerik.Reporting.Charting.Styles.FillType.Solid;
                _PieChart.Series.Add(_ChartSeries);
                _PieChart.Appearance.FillStyle.MainColor = Color.White;
            }
            catch (Exception ex)
            {

            }
        }

        public static Telerik.Reporting.Report GenerateReport(string ReportName, string appCssPath, dynamic ReportParams)
        {
            Telerik.Reporting.Report rpt = new Telerik.Reporting.Report();
            _appCssPath = appCssPath;
            try
            {
                //rpt = GetInstance <Telerik.Reporting.Report>(Type.GetType(ReportName), paramObject);
                rpt = GetReportInstance(ReportName, ReportParams);
                return rpt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private static Telerik.Reporting.Report GetReportInstance(string ReportName, params object[] args)
        {
            try
            {
                var rtype = getReportWithClient(ReportName);
                if (rtype == null)
                    rtype = getReport(ReportName);
                if (rtype == null) throw new InvalidOperationException("Valid Report not found.");
                return (Telerik.Reporting.Report)Activator.CreateInstance(rtype, args);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        private static T GetInstance<T>(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }
        private static Type getReportWithClient(string ReportName)
        {
            string strClientCode = "/" + ClientCode.Replace("Star", "");
            if (CustomizedClient != "")
                strClientCode = "/" + CustomizedClient.Replace("Star", "");

            string strNameSpacePath = ReportName;
            if (!ReportName.Contains("SIMELockton"))
            {//comment:Both Howden and HowdenSG using  same path for generating report
                if (strClientCode.Contains("HowdenSG")) // && (ReportName.Contains("DebitNoteRptGeneral")) || ReportName.Contains("Brokerage")) 
                    strClientCode = "/Howden";
                if (!ReportName.Contains("Galaxy"))
                {
                    if (!ReportName.Contains(strClientCode))
                        strNameSpacePath = ReportName.Substring(0, ReportName.LastIndexOf("/")) + strClientCode + ReportName.Substring(ReportName.LastIndexOf("/"));
                }
            }
            string TypeName = "eProStarReports." + strNameSpacePath.Replace("/", ".");
            return Type.GetType(TypeName);
        }
        private static Type getReport(string ReportName)
        {
            string TypeName = "eProStarReports." + ReportName.Replace("/", ".");
            return Type.GetType(TypeName);
        }

        #region LogFile function is create by Gopal to write log on 18/02/2015
        public void LogFile(string printtxt, string Message, string pageName, string status, string Foldername)
        {
            StreamWriter log;
            //string Foldername = string.Empty;

            //Foldername =Server.MapPath("~\\eProAcc\\LogFiles");
            //if (Directory.Exists(Foldername+ "\\logfile.txt"))
            //{
            //    Directory.Delete(Foldername+ "\\logfile.txt");
            //}
            if (!Directory.Exists(Foldername))
            {
                try
                {
                    CreateNewFolder(Foldername);

                    if (!File.Exists(Foldername + "\\logfile.txt"))
                    {

                        log = new StreamWriter(Foldername + "\\logfile.txt");
                    }
                    else
                    {

                        log = File.AppendText(Foldername + "\\logfile.txt");

                    }
                }
                catch { throw; }
            }
            else
            {
                log = File.AppendText(Foldername + "\\logfile.txt");
            }

            if (status != "Error")
            {
                log.WriteLine("================================ Start Block =======================================");
                log.WriteLine("");
                log.WriteLine("Data Time:" + DateTime.Now);
                log.WriteLine("");
                log.WriteLine("Text:" + printtxt);
                log.WriteLine("");
                log.WriteLine("Message:" + Message);
                log.WriteLine("");
                log.WriteLine("fileName:" + pageName);

                log.WriteLine("================================ End Block =========================================");
            }



            log.Close();
        }
        public void LogFile(string printtxt, string sExceptionName, string sEventName, string sControlName, int nErrorLineNo, string sFormName, string status)
        {
            StreamWriter log;

            if (!File.Exists("logfile.txt"))
            {

                log = new StreamWriter("logfile.txt");

            }
            else
            {

                log = File.AppendText("logfile.txt");

            }
            if (status != "Error")
            {
                log.WriteLine("=============== Start Block ====================");
                log.WriteLine("Data Time:" + DateTime.Now);
                log.WriteLine("Text:" + printtxt);
                log.WriteLine("=============== End Block ======================");
            }
            else
            {
                log.WriteLine("=============== Start Error Block ====================");
                log.WriteLine("Data Time:" + DateTime.Now);

                log.WriteLine("Exception Name:" + sExceptionName);

                log.WriteLine("Event Name:" + sEventName);

                log.WriteLine("Control Name:" + sControlName);

                log.WriteLine("Error Line No.:" + nErrorLineNo);

                log.WriteLine("Form Name:" + sFormName);

                log.WriteLine("=============== End Error Block ====================");
            }


            log.Close();
        }
        public bool CreateNewFolder(string pFolderName)
        {
            System.IO.DirectoryInfo ObjDirectory = new System.IO.DirectoryInfo(pFolderName);
            try
            {
                ObjDirectory.Create();
                return true;
            }
            catch { return false; }
        }
        #endregion
        #region utility methods
        public string DecimalToWords(double number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + DecimalToWords(Math.Abs(number));

            string words = "";

            int intPortion = (int)number;
            double fraction = (number - intPortion) * 100;
            int decPortion = (int)fraction;

            words = NumberToWords(intPortion);
            words += " BAHT ";
            if (decPortion > 0)
            {
                words += " and ";
                words += NumberToWords(decPortion);
                words += " satang";
            }
            words += " only";
            return words;
        }
        public string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static string MyFormat(decimal num)
        {
            string format = "{0:N2}";
            if (num < 0)
            {
                format = "({0:N2})";
            }
            return string.Format(format, Math.Abs(num));
        }


        /*public static string strCSSfor
        {
            get
            {
                string strCSSfor = "";
                clsCommon objclscommom = new clsCommon();
                strCSSfor = objclscommom.GetClientCSS();
                return strCSSfor;
            }
        }*/
        public static string ClientCode
        {
            get
            {
                clsCommon objclscommom = new clsCommon();
                return objclscommom.GetClient();
            }
        }
        public static string CustomizedClient
        {
            get
            {
                clsCommon objclscommom = new clsCommon();
                return objclscommom.GetCustomizedClient();
            }
        }
        public static string ClientLogo
        {
            get
            {
                return _appCssPath + "/images/logo.png";
            }
        }
        public static string ClientLogoBW
        {
            get
            {
                return _appCssPath + "/images/LogoBW.png";
            }
        }
        public static string OrinialStamp
        {
            get
            {
                return _appCssPath + "/images/Capture1.png";
            }
        }

        #endregion
    }
}
