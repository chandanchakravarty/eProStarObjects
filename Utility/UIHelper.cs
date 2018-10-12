using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using Telerik.Web.UI;
using System.Xml;
//using System.Web.Mail;
using System.IO;
using System.Reflection;
using AjaxControlToolkit;
using System.Configuration;
using System.Net.Mail;
using System.Net;


namespace Utility
{
    public static class UIHelper
    {
        static bool makeReadOnly = false;

        public static void MakeReadOnly(HtmlForm currentForm, bool isReadOnly)
        {
            makeReadOnly = isReadOnly;
            foreach (Control control in currentForm.Controls)
            {
                ControlsList(control, "R");
                ChildControlsList(control, "R");
            }
        }
        public static void MaintainHiddenFieldForMaster(MasterPage Master,string value)
        {
            HiddenField HidIdForAuditLog = (HiddenField)Master.FindControl("HidIdForAuditLog");
            HidIdForAuditLog.Value = value;
            HiddenField HidIsUseDefaultValue = (HiddenField)Master.FindControl("HidIsUseDefaultValue");
            HidIsUseDefaultValue.Value = "true";
        }
        public static void MakeReadOnly(RadPageView currentForm, bool isReadOnly)
        {
            makeReadOnly = isReadOnly;
            foreach (Control control in currentForm.Controls)
            {
                ControlsList(control, "R");
                ChildControlsList(control, "R");
            }
        }
        /// <summary>
        /// Method is used for Set Controls Visisblity & ReadOnly Mode on the bases of Write Accessibility
        /// </summary>
        /// <param name="WriteAccess">true,false OR 0,1 (let us know read mode or write mode)</param>
        /// <param name="frm">HTML of current form</param>
        /// <param name="isReadOnly">True, False on the bases of user and records</param>
        /// <param name="controls">Controls that need to be visible false(provide controls in comma seperation) if don't need any operation on any control leave this paramenter</param>
        public static void makeControlsDisable(string WriteAccess,HtmlForm frm, bool isReadOnly, params Control[] controls)
        {
            if (!string.IsNullOrEmpty(WriteAccess) && (WriteAccess == "true" || WriteAccess == "1"))
            {
                if (isReadOnly)
                {
                    UIHelper.MakeReadOnly(frm, true);
                    ControlsVisiblity(controls, false);
                }
                else
                {
                    UIHelper.MakeReadOnly(frm, false);
                    ControlsVisiblity(controls, true);
                }
            }
            else
            {
                Utility.UIHelper.MakeReadOnly(frm, true);
                ControlsVisiblity(controls, false);
            }
        }
        /// <summary>
        /// Controls Visiblility
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="isVisible"></param>
        public static void ControlsVisiblity(Control[] controls, bool isVisible)
        {
            foreach (Control item in controls)
            {
                item.Visible = isVisible;
            }
        }
        /// <summary>
        /// This method provide either user have readonly mode or not
        /// </summary>
        /// <param name="id">Add mode or Edit Mode (provide 0 if add mode else any id in edit mode)</param>
        /// <param name="EffectiveToDate"></param>
        /// <param name="strOverrideAccess"></param>
        /// <returns></returns>
        public static bool getModeForUser(string id, string EffectiveToDate, string strOverrideAccess)
        {
            bool isRead = false;
            if (Convert.ToBoolean(strOverrideAccess) == false && id.Trim() != "" && id != "0")
            {
                DateTime datDateStarted;
                if (EffectiveToDate.Trim() == "")
                {
                    datDateStarted = DateTime.MaxValue;
                }
                else
                {
                    DateTime.TryParseExact(EffectiveToDate.Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out datDateStarted);
                }

                if (datDateStarted < DateTime.Now.Date)
                {
                    isRead = true;
                }
            }
            return isRead;
        }

        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

        public static void AlphaNumericValidation(HtmlForm currentForm)
        {
            foreach (Control control in currentForm.Controls)
            {
                ControlsList(control, "V");
                ChildControlsList(control, "V");
            }
        }

        private static void ChildControlsList(Control ctrl, string flag)
        {
            foreach (Control cntrl in ctrl.Controls)
            {
                switch (cntrl.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.Button":
                        if (flag == "R")
                        {
                            Button addNew = (Button)cntrl;
                            if(addNew.Text.ToLower().Contains("add new"))
                            {
                            addNew.Enabled = (!makeReadOnly);
                            }
                        }
                        break;
                    case "System.Web.UI.WebControls.TextBox":
                        if (flag == "R")
                            ((TextBox)cntrl).ReadOnly = makeReadOnly;
                        else
                            ((TextBox)cntrl).Attributes.Add("onkeypress", "return jsVISION_KeyUpText_AlphaNumeric('',event)");
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        if (flag == "R")
                            ((DropDownList)cntrl).Enabled = (!makeReadOnly);
                        break;
                    case "System.Web.UI.WebControls.CheckBox":
                        if (flag == "R")
                            ((CheckBox)cntrl).Enabled = (!makeReadOnly);
                        break;
                    case "System.Web.UI.WebControls.CheckBoxList":
                        if (flag == "R")
                            ((CheckBoxList)cntrl).Enabled = (!makeReadOnly);
                        break;
                    case "System.Web.UI.WebControls.RadioButtonList":
                        if (flag == "R")
                            ((RadioButtonList)cntrl).Enabled = (!makeReadOnly);
                        break;
                    case "Telerik.Web.UI.RadDatePicker":
                        if (flag == "R")
                            ((RadDatePicker)cntrl).Enabled = (!makeReadOnly);
                        break;
                    case "Telerik.Web.UI.RadTextBox":
                        if (flag == "R")
                            ((RadTextBox)cntrl).ReadOnly = makeReadOnly;
                        else
                            ((RadTextBox)cntrl).Attributes.Add("onkeypress", "return jsVISION_KeyUpText_AlphaNumeric('',event)");
                        break;
                    case "Telerik.Web.UI.RadComboBox":
                        if (flag == "R")
                            ((RadComboBox)cntrl).Enabled = (!makeReadOnly);
                        break;
                    case "Telerik.Web.UI.RadNumericTextBox":
                        if (flag == "R")
                            ((RadNumericTextBox)cntrl).Enabled = (!makeReadOnly);
                        break;
                    case "Telerik.Web.UI.RadGrid":
                        if (flag == "R")
                            ((Telerik.Web.UI.RadGrid)cntrl).Enabled = (!makeReadOnly);
                        break;
                    case "System.Web.UI.WebControls.GridView":
                        if (flag == "R")
                            ((GridView)cntrl).Enabled = (!makeReadOnly);
                        break;
                    default:
                        break;
                }
                ChildControlsList(cntrl, flag);
            }
        }

        private static void ControlsList(Control cntrl, string flag)
        {
            switch (cntrl.GetType().ToString())
            {
                case "System.Web.UI.WebControls.TextBox":
                    if (flag == "R")
                        ((TextBox)cntrl).ReadOnly = makeReadOnly;
                    else
                        ((TextBox)cntrl).Attributes.Add("onkeypress", "return jsVISION_KeyUpText_AlphaNumeric('',event)");
                    break;
                case "System.Web.UI.WebControls.DropDownList":
                    if (flag == "R")
                        ((DropDownList)cntrl).Enabled = (!makeReadOnly);
                    break;
                case "System.Web.UI.WebControls.CheckBox":
                    if (flag == "R")
                        ((CheckBox)cntrl).Enabled = (!makeReadOnly);
                    break;
                case "System.Web.UI.WebControls.CheckBoxList":
                    if (flag == "R")
                        ((CheckBoxList)cntrl).Enabled = (!makeReadOnly);
                    break;
                case "System.Web.UI.WebControls.RadioButtonList":
                    if (flag == "R")
                        ((RadioButtonList)cntrl).Enabled = (!makeReadOnly);
                    break;
                case "Telerik.Web.UI.RadDatePicker":
                    if (flag == "R")
                        ((RadDatePicker)cntrl).Enabled = (!makeReadOnly);
                    break;
                case "AjaxControlToolkit.CalendarExtender":
                    ((AjaxControlToolkit.CalendarExtender)cntrl).Enabled = (!makeReadOnly);
                    break;
                case "Telerik.Web.UI.RadTextBox":
                    if (flag == "R")
                        ((RadTextBox)cntrl).ReadOnly = makeReadOnly;
                    else
                        ((RadTextBox)cntrl).Attributes.Add("onkeypress", "return jsVISION_KeyUpText_AlphaNumeric('',event)");
                    break;
                case "Telerik.Web.UI.RadComboBox":
                    if (flag == "R")
                        ((RadComboBox)cntrl).Enabled = (!makeReadOnly);
                    break;
                case "Telerik.Web.UI.RadNumericTextBox":
                    if (flag == "R")
                        ((RadNumericTextBox)cntrl).Enabled = (!makeReadOnly);
                    break;
                case "Telerik.Web.UI.RadGrid":
                    if (flag == "R")
                        ((Telerik.Web.UI.RadGrid)cntrl).Enabled = (!makeReadOnly);
                    break;
                default:
                    break;
            }
        }
        public static void Bind_DropDown_FromDS(DataSet ds, params Control[] _Control)
        {
            if (ds == null) { } return;
            if (ds.Tables.Count < _Control.Length) return;

            for (int i = 0; i < _Control.Length; i++)
            {
                if (_Control[i] is DropDownList)
                {
                    DropDownList ddl = (DropDownList)_Control[i];
                    UIHelper.BindDropDownList(ds.Tables[i], "display", "code", ddl);
                }
            }
        }
        public static void BindDropDownList(DataTable dataTable, string textFiled, string valueFiled, DropDownList dropdownList)
        {
            if (dataTable != null)
            {
                dropdownList.DataSource = dataTable;
                dropdownList.DataTextField = textFiled;
                dropdownList.DataValueField = valueFiled;
                dropdownList.DataBind();
            }
            dropdownList.Items.Insert(0, new ListItem("Please Select", ""));
        }

        public static void BindDropDownList(DataRow[] dataRow, DataTable dataTable, string textFiled, string valueFiled, DropDownList dropdownList)
        {
            if (dataRow != null)
            {
                DataTable dtResult = dataTable.Clone();

                foreach (DataRow dr in dataRow)
                    dtResult.ImportRow(dr);

                dropdownList.DataSource = dtResult;
                dropdownList.DataTextField = textFiled;
                dropdownList.DataValueField = valueFiled;
                dropdownList.DataBind();
            }
            dropdownList.Items.Insert(0, new ListItem("Please Select", ""));
        }

        public static void BindDropDownListWithoutSelect(DataTable dataTable, string textFiled, string valueFiled, DropDownList dropdownList)
        {
            if (dataTable != null)
            {
                DataView dv = new DataView(dataTable, "", textFiled +" ASC",DataViewRowState.CurrentRows );
                dropdownList.DataSource = dv;
                dropdownList.DataTextField = textFiled;
                dropdownList.DataValueField = valueFiled;
                dropdownList.DataBind();
            }
        }

        public static void BindDropDownListWithoutSelectDefault(DataTable dataTable, string textFiled, string valueFiled, DropDownList dropdownList)
        {
            if (dataTable != null)
            {
                dropdownList.DataSource = dataTable;
                dropdownList.DataTextField = textFiled;
                dropdownList.DataValueField = valueFiled;
                dropdownList.DataBind();
            }
        }

        public static void BindDropDownListWithDefault(DataTable dataTable, string textFiled, string valueFiled, DropDownList dropdownList)
        {
            if (dataTable != null)
            {
                dropdownList.DataSource = dataTable;
                dropdownList.DataTextField = textFiled;
                dropdownList.DataValueField = valueFiled;
                dropdownList.DataBind();
            }
            dropdownList.Items.Insert(0, new ListItem("Please Select", "0"));
        }

        public static void BindRADDropDownList(DataTable dataTable, string textFiled, string valueFiled, RadComboBox dropdownList)
        {
            if (dataTable != null)
            {
                dropdownList.DataSource = dataTable;
                dropdownList.DataTextField = textFiled;
                dropdownList.DataValueField = valueFiled;
                dropdownList.DataBind();
            }
            dropdownList.Items.Insert(0, new RadComboBoxItem("Please Select", ""));
        }

        public static void BindRADDropDownListWithoutSelect(DataTable dataTable, string textFiled, string valueFiled, RadComboBox dropdownList)
        {
            if (dataTable != null)
            {
                dropdownList.DataSource = dataTable;
                dropdownList.DataTextField = textFiled;
                dropdownList.DataValueField = valueFiled;
                dropdownList.DataBind();
                string emptyMessage = "[Select...]";
                int maxWidth = 0;
                int emptyWidth = emptyMessage.ToUpper().Length * 7;
                foreach (RadComboBoxItem item in dropdownList.Items)
                    maxWidth = (item.Text.ToUpper().Length > maxWidth) ? item.Text.Length : maxWidth;
                maxWidth = maxWidth * 7;
                dropdownList.EmptyMessage = "[Select...]";
                if (maxWidth > emptyWidth)
                {
                    dropdownList.DropDownWidth = maxWidth + 50;
                    dropdownList.Width = maxWidth + 50;
                }
                else
                {
                    dropdownList.DropDownWidth = emptyWidth + 30;
                    dropdownList.Width = emptyWidth + 30;
                }

            }
        }

        public static void BindRADDropDownList(DataTable dataTable, string textFiled, string valueFiled, RadComboBox dropdownList, bool ShowAll)
        {
            if (dataTable != null)
            {
                dropdownList.DataSource = dataTable;
                dropdownList.DataTextField = textFiled;
                dropdownList.DataValueField = valueFiled;
                dropdownList.DataBind();
                int maxWidth = 0;
                foreach (RadComboBoxItem item in dropdownList.Items)
                    maxWidth = (item.Text.Length > maxWidth) ? item.Text.Length : maxWidth;
                maxWidth = maxWidth * 7;
                if (maxWidth > 200)
                {
                    dropdownList.DropDownWidth = maxWidth;
                    dropdownList.Width = maxWidth + 20;
                }
            }
            if (ShowAll == true)
            { dropdownList.Items.Insert(0, new RadComboBoxItem("Please Select", "")); }
        }

        public static void SelectValueDropDownList(string pstrValue, System.Web.UI.WebControls.DropDownList pComboName)
        {
            for (int i = 0; i < pComboName.Items.Count; i++) if
                (pComboName.Items[i].Value.ToString().Trim() == pstrValue.Trim())
                { pComboName.Items[i].Selected = true; break; }
        }

        public static void BindCheckBoxList(DataTable dataTable, string textFiled, string valueFiled, CheckBoxList checkboxList)
        {
            if (dataTable != null)
            {
                checkboxList.DataSource = dataTable;
                checkboxList.DataTextField = textFiled;
                checkboxList.DataValueField = valueFiled;
                checkboxList.DataBind();
            }
        }
        public static void SetDefaultValue(HtmlForm currentForm)
        {
            foreach (Control control in currentForm.Controls)
            {
                ChildControlsListForDefault(control);
                ControlsListForDefault(control);
            }
        }

        public static void SetDefaultValueSpecific(HtmlForm currentForm)
        {
            foreach (Control control in currentForm.Controls)
            {
                ChildControlsListForDefaultSpecific(control);
                ControlsListForDefaultSpecific(control);
            }
        }

        public static void SetDefaultValue(RadPageView currentForm)
        {
            foreach (Control control in currentForm.Controls)
            {
                ChildControlsListForDefault(control);
                ControlsListForDefault(control);
            }
        }

        public static void BindRadioButtonList(DataTable dataTable, string textFiled, string valueFiled, RadioButtonList radioButtonList)
        {
            if (dataTable != null)
            {
                radioButtonList.DataSource = dataTable;
                radioButtonList.DataTextField = textFiled;
                radioButtonList.DataValueField = valueFiled;
                radioButtonList.DataBind();
            }
        }

        public static void BindRadComboBox(DataTable dataTable, string textFiled, string valueFiled, RadComboBox RadComboBox1)
        {
            if (dataTable != null)
            {
                RadComboBox1.DataSource = dataTable;
                RadComboBox1.DataTextField = textFiled;
                RadComboBox1.DataValueField = valueFiled;
                RadComboBox1.DataBind();
                int maxWidth = 0;
                foreach (RadComboBoxItem item in RadComboBox1.Items)
                    maxWidth = (item.Text.Length > maxWidth) ? item.Text.Length : maxWidth;
                maxWidth = maxWidth * 7;
                if (maxWidth > 200)
                {
                    RadComboBox1.DropDownWidth = maxWidth;
                    RadComboBox1.Width = maxWidth + 20;
                }
            }
            RadComboBox1.Items.Insert(0, new RadComboBoxItem("[Select...]", ""));

        }
        private static void ChildControlsListForDefault(Control ctrl)
        {
            foreach (Control cntrl in ctrl.Controls)
            {
                switch (cntrl.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)cntrl).Text = "";
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        ((DropDownList)cntrl).SelectedIndex = -1;
                        break;
                    case "System.Web.UI.WebControls.CheckBox":
                        ((CheckBox)cntrl).Checked = false;
                        break;
                    case "System.Web.UI.WebControls.CheckBoxList":
                        ((CheckBoxList)cntrl).ClearSelection();
                        ((CheckBoxList)cntrl).SelectedIndex = -1;
                        break;
                    //case "System.Web.UI.WebControls.Label":
                    //    ((Label)cntrl).Text = "";
                    //    break;
                    case "System.Web.UI.WebControls.RadioButton":
                        ((RadioButton)cntrl).Enabled = true;
                        break;
                    case "System.Web.UI.WebControls.RadioButtonList":
                        ((RadioButtonList)cntrl).ClearSelection();
                        break;
                    case "Telerik.Web.UI.RadDatePicker":
                        ((RadDatePicker)cntrl).Clear();
                        break;
                    case "Telerik.Web.UI.RadTextBox":
                        ((Telerik.Web.UI.RadTextBox)cntrl).Text = "";
                        break;
                    case "Telerik.Web.UI.RadComboBox":
                        ((Telerik.Web.UI.RadComboBox)cntrl).Text = null;
                        ((Telerik.Web.UI.RadComboBox)cntrl).ClearSelection();
                        break;
                    case "Telerik.Web.UI.RadNumericTextBox":
                        ((RadNumericTextBox)cntrl).Text = "";
                        break;
                    case "Telerik.Web.UI.RadGrid":
                        ((Telerik.Web.UI.RadGrid)cntrl).Controls.Clear();
                        break;
                    default:
                        break;
                }
                ChildControlsListForDefault(cntrl);
            }
        }

        private static void ChildControlsListForDefaultSpecific(Control ctrl)
        {
            foreach (Control cntrl in ctrl.Controls)
            {
                switch (cntrl.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)cntrl).Text = "";
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        ((DropDownList)cntrl).SelectedIndex = -1;
                        break;
                    case "System.Web.UI.WebControls.CheckBox":
                        ((CheckBox)cntrl).Checked = false;
                        break;
                    case "System.Web.UI.WebControls.CheckBoxList":
                        ((CheckBoxList)cntrl).ClearSelection();
                        ((CheckBoxList)cntrl).SelectedIndex = -1;
                        break;
                    case "System.Web.UI.WebControls.Label":
                        ((Label)cntrl).Text = "";
                        break;
                    case "System.Web.UI.WebControls.RadioButton":
                        ((RadioButton)cntrl).Enabled = true;
                        break;
                    case "System.Web.UI.WebControls.RadioButtonList":
                        ((RadioButtonList)cntrl).ClearSelection();
                        break;
                    case "Telerik.Web.UI.RadDatePicker":
                        ((RadDatePicker)cntrl).Clear();
                        break;
                    case "Telerik.Web.UI.RadTextBox":
                        ((Telerik.Web.UI.RadTextBox)cntrl).Text = "";
                        break;
                    case "Telerik.Web.UI.RadComboBox":
                        ((Telerik.Web.UI.RadComboBox)cntrl).Text = null;
                        ((Telerik.Web.UI.RadComboBox)cntrl).ClearSelection();
                        break;
                    case "Telerik.Web.UI.RadNumericTextBox":
                        ((RadNumericTextBox)cntrl).Text = "";
                        break;
                    case "Telerik.Web.UI.RadGrid":
                        ((Telerik.Web.UI.RadGrid)cntrl).Controls.Clear();
                        break;
                    default:
                        break;
                }
                ChildControlsListForDefaultSpecific(cntrl);
            }
        }

        private static void ControlsListForDefault(Control cntrl)
        {
            switch (cntrl.GetType().ToString())
            {
                case "System.Web.UI.WebControls.TextBox":
                    ((TextBox)cntrl).Text = "";
                    break;
                case "System.Web.UI.WebControls.DropDownList":
                    ((DropDownList)cntrl).SelectedIndex = -1;
                    break;
                case "System.Web.UI.WebControls.CheckBox":
                    ((CheckBox)cntrl).Checked = false;
                    break;
                case "System.Web.UI.WebControls.CheckBoxList":
                    ((CheckBoxList)cntrl).ClearSelection();
                    ((CheckBoxList)cntrl).SelectedIndex = -1;
                    break;
                //case "System.Web.UI.WebControls.Label":
                //    ((Label)cntrl).Text = "";
                //    break;
                case "System.Web.UI.WebControls.RadioButton":
                    ((RadioButton)cntrl).Enabled = true;
                    break;
                case "System.Web.UI.WebControls.RadioButtonList":
                    ((RadioButtonList)cntrl).ClearSelection();
                    break;
                case "Telerik.Web.UI.RadDatePicker":
                    ((RadDatePicker)cntrl).Clear();
                    break;
                case "Telerik.Web.UI.RadTextBox":
                    ((Telerik.Web.UI.RadTextBox)cntrl).Text = "";
                    break;
                case "Telerik.Web.UI.RadComboBox":
                    ((Telerik.Web.UI.RadComboBox)cntrl).Text = null;
                    ((Telerik.Web.UI.RadComboBox)cntrl).ClearSelection();
                    break;
                case "Telerik.Web.UI.RadNumericTextBox":
                    ((RadNumericTextBox)cntrl).Text = "";
                    break;
                case "Telerik.Web.UI.RadGrid":
                    ((Telerik.Web.UI.RadGrid)cntrl).Controls.Clear();
                    break;
                default:
                    break;
            }
        }


        private static void ControlsListForDefaultSpecific(Control cntrl)
        {
            switch (cntrl.GetType().ToString())
            {
                case "System.Web.UI.WebControls.TextBox":
                    ((TextBox)cntrl).Text = "";
                    break;
                case "System.Web.UI.WebControls.DropDownList":
                    ((DropDownList)cntrl).SelectedIndex = -1;
                    break;
                case "System.Web.UI.WebControls.CheckBox":
                    ((CheckBox)cntrl).Checked = false;
                    break;
                case "System.Web.UI.WebControls.CheckBoxList":
                    ((CheckBoxList)cntrl).ClearSelection();
                    ((CheckBoxList)cntrl).SelectedIndex = -1;
                    break;
                case "System.Web.UI.WebControls.Label":
                    ((Label)cntrl).Text = "";
                    break;
                case "System.Web.UI.WebControls.RadioButton":
                    ((RadioButton)cntrl).Enabled = true;
                    break;
                case "System.Web.UI.WebControls.RadioButtonList":
                    ((RadioButtonList)cntrl).ClearSelection();
                    break;
                case "Telerik.Web.UI.RadDatePicker":
                    ((RadDatePicker)cntrl).Clear();
                    break;
                case "Telerik.Web.UI.RadTextBox":
                    ((Telerik.Web.UI.RadTextBox)cntrl).Text = "";
                    break;
                case "Telerik.Web.UI.RadComboBox":
                    ((Telerik.Web.UI.RadComboBox)cntrl).Text = null;
                    ((Telerik.Web.UI.RadComboBox)cntrl).ClearSelection();
                    break;
                case "Telerik.Web.UI.RadNumericTextBox":
                    ((RadNumericTextBox)cntrl).Text = "";
                    break;
                case "Telerik.Web.UI.RadGrid":
                    ((Telerik.Web.UI.RadGrid)cntrl).Controls.Clear();
                    break;
                default:
                    break;
            }
        }

        public static string getXMLData(string strXMLXqueryPath, string fileName)
        {
            XmlDocument xdDoc = new XmlDocument();
            string strFilePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            strFilePath += @"\" + fileName;
            xdDoc.Load(strFilePath);
            XmlNode xnContent = xdDoc.SelectSingleNode(strXMLXqueryPath);
            return xnContent.InnerText;
        }

        //public static void SendEmail(string strFrom, string To, string Subject, string Body, string strLoginID, string strCompanyId, string strToCompanyId, string strMailType, bool SaveMail, string strRefNo)
        //{
        //    string strDeliveryStatus = "Y";
        //    string strError = "";
        //    Exception exError = null;
        //    try
        //    {
        //        if (To.Trim().Length > 0)
        //        {
        //            MailMessage objEmail = new MailMessage();
        //            objEmail.BodyFormat = MailFormat.Html;
        //            objEmail.From = strFrom;
        //            objEmail.To = To;
        //            objEmail.Subject = Subject;
        //            objEmail.Body = Body;
        //            string mstrSmtpSvr = System.Configuration.ConfigurationManager.AppSettings["SMTPServer"].ToString().Trim();
        //            if (mstrSmtpSvr.Length > 0)
        //            {
        //                SmtpMail.SmtpServer = mstrSmtpSvr;
        //                SmtpMail.Send(objEmail);
        //            }
        //            else
        //            {
        //                SendMailViaGMAILSMTP("smtp.gmail.com", 465, "arunpec121@gmail.com", "revlalitha", "", strFrom, "", To, Subject, Body, true);
        //            }
        //        }
        //        else
        //        {
        //            strDeliveryStatus = "N";
        //            strError = "No email address found to mail the user";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        exError = ex;
        //        strDeliveryStatus = "N";
        //        strError = (ex.Message.Length > 1000) ? ex.Message.Substring(0, 990) : ex.Message;
        //    }
        //    finally
        //    {
        //        if (SaveMail)
        //        {
        //            new ETrekVision.Database("eProfessional_N").ExecuteNonQuery("EXEC p_SaveMailAlerts '" +
        //                strFrom + "','" +
        //                To + "','" +
        //                Subject + "','" +
        //                Body + "','" +
        //                strLoginID + "','" +
        //                strCompanyId + "','" +
        //                strToCompanyId + "','" +
        //                strMailType + "','" +
        //                strDeliveryStatus + "','" +
        //                strRefNo + "','" +
        //                strError.Replace("'", "''") + "'");
        //        }
        //    }
        //    if (exError != null)
        //    {
        //        throw exError;
        //    }
        //}

        public static void SendMailViaGMAILSMTP(string sHost, int nPort, string sUserName, string sPassword, string sFromName, string sFromEmail,
        string sToName, string sToEmail, string sHeader, string sMessage, bool fSSL)
        {
            if (sToName.Length == 0)
                sToName = sToEmail;
            if (sFromName.Length == 0)
                sFromName = sFromEmail;

            System.Web.Mail.MailMessage Mail = new System.Web.Mail.MailMessage();
            Mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = sHost;
            Mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendusing"] = 2;

            Mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"] = nPort.ToString();
            if (fSSL)
                Mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpusessl"] = "true";

            if (sUserName.Length == 0)
            {
                //Ingen auth 
            }
            else
            {
                Mail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1;
                Mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = sUserName;
                Mail.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = sPassword;
            }

            Mail.To = sToEmail;
            Mail.From = sFromEmail;
            Mail.Subject = sHeader;
            Mail.Body = sMessage;
            Mail.BodyFormat = System.Web.Mail.MailFormat.Html;

            System.Web.Mail.SmtpMail.SmtpServer = sHost;
            System.Web.Mail.SmtpMail.Send(Mail);
        }

        public static bool SentMail(string strFrom,string strTo, string strSubject, string strBody)
        {
            try
            {
                //strFrom = "meghag@ebix.com"; strTo = "anshul.gupta@ebix.com";
                System.Net.Mail.MailMessage objmailMessage = new System.Net.Mail.MailMessage();

                string[] arr = strTo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string i in arr)
                {

                    System.Net.Mail.MailAddress obj = new System.Net.Mail.MailAddress(i);
                    objmailMessage.To.Add(obj);

                }
                System.Net.Mail.MailAddress strfrom = new System.Net.Mail.MailAddress(strFrom);
                objmailMessage.From =  strfrom;
                objmailMessage.Subject = strSubject;
                objmailMessage.IsBodyHtml = true;
                objmailMessage.Body =  strBody;
                objmailMessage.Priority = System.Net.Mail.MailPriority.High;
               // objmailMessage.DeliveryNotificationOptions |=  System.Net.Mail.DeliveryNotificationOptions.OnSuccess | System.Net.Mail.DeliveryNotificationOptions.OnFailure;
                objmailMessage.DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnFailure;
               // System.Net.NetworkCredential objCredential = new System.Net.NetworkCredential();
                System.Net.Mail.SmtpClient objSmtpClient = new System.Net.Mail.SmtpClient();
                //objSmtpClient.Credentials
                objSmtpClient.EnableSsl = false;
                objSmtpClient.Send(objmailMessage);
                return true;
            }
            catch(Exception ex)
            {
                LogEvent.WriteErrorLog(ex, "Email could not be sent to " + strTo);
                return false;
            }
            
        }

        
        public static bool MailFromGMail(string strFrom, string strTo, string strSubject, string strBody)
        {
           // System.Net.Mail.MailMessage objmailMessage = new System.Net.Mail.MailMessage();
            var message = new MailMessage();
            string mail = "";
            string paswrd = "";
            if (ConfigurationManager.AppSettings["FromGMailAdress"] != null)
                mail = ConfigurationManager.AppSettings["FromGMailAdress"].ToString().Trim();
            if (ConfigurationManager.AppSettings["GMailPassword"] != null)
                paswrd = ConfigurationManager.AppSettings["GMailPassword"].ToString().Trim();

            message.From = new MailAddress(mail, "KibEbix");
            var fromAddress = new MailAddress(mail, "KibEbix");
            string[] arr = strTo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string i in arr)
            {

                System.Net.Mail.MailAddress obj = new System.Net.Mail.MailAddress(i);
                message.To.Add(obj);

            }
            //if (arr[0])
            //{
            //    strTo = strTo.Remove(strTo.Length - 1);

            //}

           // strTo = strTo.Replace(",", "");
            //var toAddress = new MailAddress(strTo, strTo);
            string fromPassword = paswrd;
            string subject = strSubject;
            string body = strBody;
            body = System.Net.WebUtility.HtmlDecode(body);
            try
            {
                var smtp = new SmtpClient();

                smtp.Host = ConfigurationManager.AppSettings["GMailServer"].ToString().Trim();
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["GmailServerPort"].ToString().Trim());
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
                smtp.Timeout = 20000;


                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                smtp.Send(message);
                return true;

            }
            catch (Exception ex)
            {
                LogEvent.WriteErrorLog(ex, "Email could not be sent to " + strTo);
                return false;
            }

        }

        public static bool SendApprovalMail(string strFrom, string mailTo, string name, string MailFor, string status, string DateFormat)
        {
            //UIHelper objMailClass = new Utility.UIHelper();
            string strTo, strSubject, strBody;
            string mail = "";
            string paswrd = "";
            //strTo = TextBox1.Text.ToString();
            strTo = mailTo.Replace(";", ",");

            

            //Body for html format---
            StringBuilder sb = new StringBuilder();
            sb.Append("<html><body>");
            sb.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\">");
            sb.Append("<tr><td>Greetings!</td></tr>");
            sb.Append("<tr><td>&nbsp;&nbsp;</td></tr>");
            sb.Append("<tr><td>&nbsp;&nbsp;</td></tr>");
            if (status != "L1REJ" && status != "L2REJ" && status != "L3REJ")
            {
                if (status != "APPRV")
                {
                    strSubject = "Request Mail For Approval";
                    sb.Append("<tr><td>" + MailFor + " " + name + " has been submitted for approval, please login into the system to Approve or Reject the request.</td></tr>");
                }
                else
                {
                    strSubject = "Request Approved";
                    sb.Append("<tr><td>" + MailFor + " " + name + " has been successfully approved, please login into the system for further proceedings.</td></tr>");
                }
            }
            else
            {
                strSubject = "Request Rejected";
                sb.Append("<tr><td>" + "Request for " + name + " has been rejected, please login into the system for further proceedings.</td></tr>");
            }
            sb.Append("<tr><td>&nbsp;&nbsp;</td></tr>");
            sb.Append("<tr><td>Have a nice day.</td></tr>");
            //sb.Append("<tr><td>You are requested to approve the client.</td></tr>");
            sb.Append("<tr><td>Thanks and regards.</td></tr>");
            sb.Append("<tr><td>&nbsp;&nbsp;</td></tr>");
            sb.Append("<tr><td>" + DateTime.Now.ToString(DateFormat) + "</td></tr>");
            sb.Append("</table>");
            sb.Append("</body></html>");
            strBody = sb.ToString();

            bool mailFromConfig=false;
            bool result;
            if (ConfigurationManager.AppSettings["FromGMailAdress"] != null )
            {
                if (ConfigurationManager.AppSettings["FromGMailAdress"].ToString().Trim() != "")
                {
                    mail = ConfigurationManager.AppSettings["FromGMailAdress"].ToString().Trim();
                }
                try
                {
                    var addr = new System.Net.Mail.MailAddress(mail);
                    mailFromConfig = true;
                }
                catch
                {
                    mailFromConfig = false;
                }
            }

            if (ConfigurationManager.AppSettings["GMailPassword"] != null )
            {
                if (ConfigurationManager.AppSettings["GMailPassword"].ToString().Trim() != "")
                {
                    paswrd = ConfigurationManager.AppSettings["GMailPassword"].ToString().Trim();
                }
            }

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; 
            if (mailFromConfig)
            {
                result = MailFromGMail(strFrom, strTo, strSubject, strBody);
            }
            else
            {
                result = SentMail(strFrom, strTo, strSubject, strBody);
            }

            return result;
        }

        public static string F_ConvertSpecialChar(string strToConvert)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strToConvert.Length; i++)
            {
                char c = strToConvert[i];
                if (c == '*' || c == '%' || c == '[' || c == ']')
                    sb.Append("[").Append(c).Append("]");
                else if (c == '\'')
                    sb.Append("''");

                else
                    sb.Append(c);
            }
            return sb.ToString();
            //return strToConvert.Replace("'", "''");
        }

        // Note : Sometime We are replaced "'" by "~" 
        public static string F_ConvertSpecialCharByTild(string strToConvert)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strToConvert.Length; i++)
            {
                char c = strToConvert[i];
                if (c == '*' || c == '%' || c == '[' || c == ']')
                    sb.Append("[").Append(c).Append("]");
                else if (c == '\'')
                    sb.Append("''");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

    }
}
