using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace eProStarServices
{
    internal class ServiceUtility
    {
        public static void WriteLog(string text)
        {
            WriteLog(text, "");
        }
        public static void WriteLog(string text, string ClientCode)
        {
            try
            {
                //string DirectoryPath = ConfigurationSettingReader.LogFilePath;
                string DirectoryPath ="";
                if (ClientCode.Trim() != "")
                    DirectoryPath = System.AppDomain.CurrentDomain.BaseDirectory + ClientCode;
                else
                    DirectoryPath = System.AppDomain.CurrentDomain.BaseDirectory;

                if (DirectoryPath.Length-1 == DirectoryPath.LastIndexOf('\\'))
                    DirectoryPath = DirectoryPath.Substring(0,DirectoryPath.Length-1);

                if (Directory.Exists(DirectoryPath) == false)
                {
                    Directory.CreateDirectory(DirectoryPath);
                }
                string path = DirectoryPath + @"\eProStarServiceLog_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine(DateTime.Now.ToString() + " : " + text + "\n");
                sw.Close();
            }
            catch (Exception err)
            {
                //throw err;
            }
        }
    }
}
