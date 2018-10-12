using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace FormsNReports
{
   public class ReportUtility
   {
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
   }

   //public interface IReportUtility
   //{

   //}
}
