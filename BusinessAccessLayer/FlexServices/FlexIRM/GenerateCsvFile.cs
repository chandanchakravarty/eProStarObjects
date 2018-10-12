using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;


namespace BusinessAccessLayer.FlexServices.FlexIRM
{
    public class GenerateCsvFile
    {
        private string exportToCSVfile(SqlDataReader dr, string separator, string fileOut)
        {
            StreamWriter sw = new StreamWriter(fileOut, false);
            string strRow=string.Empty;
            while (dr.Read())
            {
                strRow = "";
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    strRow += dr.GetString(i);
                    if (i < dr.FieldCount - 1)
                    {
                        strRow += separator;
                    }
                }
                sw.WriteLine(strRow);
            }
            sw.Close();
            return strRow;

        }

        public string exportToCSVfile(DataSet ds, string Columnseparator, string Rowseparator, string fileOut)
        {
            FileStream MyFileStream = new FileStream(fileOut, FileMode.Append, FileAccess.Write, FileShare.None);
            StreamWriter sw = new StreamWriter(MyFileStream);
            string strRow = string.Empty;
            if(ds!=null)
                if(ds.Tables.Count >0)
                {
                    strRow = "";
                    foreach (DataRow drow in ds.Tables[0].Rows)
                    {
                        for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                        {

                            strRow += drow[i].ToString();
                            if (i < ds.Tables[0].Columns.Count - 1)
                            {
                                strRow += Columnseparator;
                            }
                        }
                        strRow += Rowseparator;
                    }
                    sw.Write(strRow);
                }
            sw.Close();
            return strRow;
        }

        private string GetDirectoryPath()
        {
            string dirpath = ConfigurationSettings.AppSettings["FileUploadPath"].ToString().Trim() + "\\" + "Exported";
            if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
            return dirpath;
        }

        //public void SaveDebitNoteCsv()
        //{

        //    DataAccess dataAccess = new DataAccess();
        //    DataSet ds = new DataSet();
        //    ds = dataAccess.LoadDataSet("Select * from TM_DebitNoteWOCoverNote", "DebitNote");
        //    string strFile = "QCI_" + System.DateTime.Now.ToString().Trim().Replace(" ", "").Replace("/", "_").Replace(":", "_") + ".txt";
        //    //string FilePath = GetDirectoryPath()+strFile+"";
        //    string FilePath = @"D:\Doc\" + strFile + "";
        //    exportToCSVfile(ds,"^","|",FilePath);
        
        //}
    }
}