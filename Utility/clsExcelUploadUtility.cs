using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace Utility
{
    public class clsExcelUploadUtility
    {
        public static DataTable csv_to_datatable(string csvFile, char deliminator)
        {
            FileStream fs = new FileStream(csvFile, FileMode.Open, FileAccess.Read,
                                                      FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string[] Lines = File.ReadAllLines(csvFile);

            string[] Fields = Lines[0].Split(new char[] { deliminator });
            DataTable dt = new DataTable();
            int Cols = Fields.GetLength(0);

            //1st row must be column names. 
            for (int i = 0; i < Cols; i++)
            {
                dt.Columns.Add(Fields[i], typeof(string));
            }

            DataRow Row;
            for (int i = 1; i < Lines.GetLength(0); i++)
            {
                Fields = Lines[i].Split(new char[] { deliminator });
                Row = dt.NewRow();
                for (int j = 0; j < Cols; j++)
                {
                    Row[j] = Fields[j];
                }

                dt.Rows.Add(Row);
            }
            return dt;
        }
        public static DataTable RemoveEmprtyRows(DataTable dt)
        {
            var v = from m in dt.AsEnumerable() where m.ItemArray.Any(x => string.IsNullOrEmpty(x.ToString().Trim()) == false) select m;
            if (v.Count() > 0)
            {
                dt = v.CopyToDataTable();
            }
            return dt;
        }
        public static bool genericValidationForExcel(DataTable dtExcel, int columnCount,ref string error, params string[] columnArr)
        {
            if (dtExcel == null)
            {
                error = "Sheet is Empty.";
                return false;
            }
            if (dtExcel.Columns.Count != columnCount)
            {
                error = "Invalid Column Count in Sheet.";
                return false;
            }
            foreach (string strColmName in columnArr)
            {
                if (dtExcel.Columns.Contains(strColmName.Trim()) == false)
                {
                    error = "Columns Header should not contain spaces, special characters and should be in correct sequence.";
                    return false;
                }
            }

            dtExcel = RemoveEmprtyRows(dtExcel);
            if (dtExcel.Rows.Count == 0)
            {
                error = "No Data Found !";
                return false;
            }
            return true;
        }
        public static bool validateDateField(string ColumnValue, string ColumnName, int lineNumber, string type, ref string error)
        {
            if (checkEmpty(ColumnValue, ColumnName, lineNumber,ref error) == false) { return false; }
            switch (type.ToLower().Trim())
            {
                case "date":
                    {
                        string dt2 = Utility.ProcessRequest.DMYtoMDY(ColumnValue.Trim());
                        try
                        {
                            DateTime.Parse(dt2);
                        }
                        catch
                        {
                            error = "Invalid Data In " + ColumnName + " To Field : Please Check " + ColumnName + " !";
                            return false;
                        }
                        break;
                    }
                default:
                    break;
            }
            return true;
        }
        public static bool checkEmpty(string ColumnValue, string ColumnName, int lineNumber, ref string error)
        {
            if (ColumnValue == "")
            {
                error = ColumnName + " On Line No. " + lineNumber + " Can Not Be Blank !";
                return false;
            }
            return true;
        }
        public static string appendDateTimeinFileNameAndPath(string fileName, string path)
        {
            string fName = "";

            fName = "\\" + fileName.Replace("\\", "").Remove((fileName.Replace("\\", "").Length) - 4, 4)
                   + "_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day +
                   DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            path = string.Concat(path + fileName);

            return path;
        }
    }
}
