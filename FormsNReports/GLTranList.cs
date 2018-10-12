namespace FormsNReports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Data;

    /// <summary>
    /// Summary description for GLTranList.
    /// </summary>
    public partial class GLTranList : Telerik.Reporting.Report
    {
        int counter = 0;
        public GLTranList()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
           
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public GLTranList(DataSet Ds,string [] str,DataSet DsComp)
        {
            InitializeComponent();
            string _name = string.Empty;
            string GLCode = string.Empty;

            if (str[0].Trim() == "'R'")
            {
                _name = "Receipt";
            }
           else if (str[0].Trim() == "'P'")
            {
                _name = "Payment";
            }
            else if (str[0].Trim() == "'C'")
            {
                _name = "Credit Note";

            }
            else if (str[0].Trim() == "'D'")
            {
                _name = "Debit Note";
            }
            else if (str[0].Trim() == "'J'")
            {
                _name = "Journal";
            }
            else
            {
                _name = "All";
            }
            textBox1.Value=  DsComp.Tables[0].Rows[0]["CompName"].ToString();
            //textBox24.Value = str[0].Trim() == "'R'" ? "Receipt" : "All";// str[0] == "P" ? "Payment" : str[0] == "J" ? "Journal": str[0] == "D" ? "Debit Note": str[0] == "C" ? "Credit Note":"gf" ;
            textBox24.Value = _name;
           // textBox26.Value = str[1].Trim().Replace("'", "") + "-" + str[2].Trim().Replace("'", "");
            textBox12.Value = "Debit(" + DsComp.Tables[0].Rows[0]["CurrCode"].ToString() + ")";
            textBox13.Value = "Credit(" + DsComp.Tables[0].Rows[0]["CurrCode"].ToString() + ")";
            if (str[1].Trim().Replace("'", "") + "-" + str[2].Trim().Replace("'", "") == "-")
            {
                textBox26.Value = (str[1].Trim().Replace("'", "") + "-" + str[2].Trim().Replace("'", "")).Replace("-", "");
            }
            else
            {
                textBox26.Value = str[1].Trim().Replace("'", "") + "-" + str[2].Trim().Replace("'", "");
            }

            if (str[3].Trim().Replace("'", "") + "-" + str[4].Trim().Replace("'", "") == "-")
            {
                textBox28.Value = (str[3].Trim().Replace("'", "") + "-" + str[4].Trim().Replace("'", "")).Replace("-", "");
            }
            else
            {
                textBox28.Value = str[3].Trim().Replace("'", "") + "-" + str[4].Trim().Replace("'", "");
            }
            textBox30.Value = str[7].Trim().Replace("'", "") == "Y" ? "Posted" : "Not Posted";
            textBox32.Value = str[8].Trim().Replace("'", "");
            table1.DataSource = Ds;
            
        }

        private void textBox24_ItemDataBinding(object sender, EventArgs e)
        {
            counter++;
            if (counter > 1)
           {
               textBox4.Visible =  false;
               textBox5.Visible =  false;
               textBox23.Visible = false;
               textBox24.Visible = false;
               textBox25.Visible = false;
               textBox26.Visible = false;
               textBox27.Visible = false;
               textBox28.Visible = false;
               textBox29.Visible = false;
               textBox30.Visible = false;
               textBox31.Visible = false;
               textBox32.Visible = false;
           }
        }
       
    }


}