using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.IO; 
namespace Utility
{
    public static class LogEvent
    {
        public static void WriteError(Exception ex, string strMessage, Dictionary<string, object> dict)
        {
            LogEntry logEntry = new LogEntry();
            logEntry.Message = strMessage;
            logEntry.Categories.Add("General");
            if (dict != null)
                logEntry.ExtendedProperties = dict;
            Logger.Write(logEntry);
        }
        public static void WriteErrorLog(Exception ex, string strMessage)
        {
            try
            {
                string DirectoryPath = System.AppDomain.CurrentDomain.BaseDirectory + "/Logs";
                if (Directory.Exists(DirectoryPath) == false)
                {
                    Directory.CreateDirectory(DirectoryPath);
                }
                string path = DirectoryPath + @"\eMailLog.txt";
                StringBuilder strInfo = new StringBuilder();
                Exception objEx = ex;
                strInfo.Append("Exception Information : ");
                while (true)
                {
                    if (objEx == null)
                        break;
                    strInfo.Append(objEx.Message);
                    objEx = objEx.InnerException;
                    if (objEx == null)
                        break;

                    strInfo.Append(" :: Inner Exception Information : ");
                }

                if (ex != null)
                    strInfo.AppendFormat(Environment.NewLine + " : " + ex.StackTrace);
                else
                    strInfo.AppendFormat("{0}{0}No Exception.{0}", Environment.NewLine);

                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine(DateTime.Now.ToString() + " : " + strInfo.ToString() + ": " + strMessage + "\n");
                sw.Close();
            }
            catch (Exception err)
            {
                try
                {
                    WriteError(err, strMessage, null);
                }
                catch{}
            }
        }
    }
}
