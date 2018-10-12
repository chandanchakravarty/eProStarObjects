using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using Telerik.Charting.Styles;
using BusinessAccessLayer.Common;

namespace NWILetterReport
{
    public static class clsReportUtility
    {
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
                    _ChartSeriesItem.Name = dt.Rows[i][lblField].ToString() ;
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


        public static string strCSSfor
        {
            get
            {
                string strCSSfor = "";

                //if (ConfigurationManager.AppSettings["ClientCSS"] != null)
                //    strGetcss = ConfigurationManager.AppSettings["ClientCSS"].ToString();
                clsCommon objclscommom = new clsCommon();

                strCSSfor = objclscommom.GetClientCSS();
                return strCSSfor;

            }

        }

        public static string setClientLogo()
        {
            return System.Web.HttpContext.Current.Server.MapPath("~/" + strCSSfor + "/images/logo.png");
        }
       
    }
}
