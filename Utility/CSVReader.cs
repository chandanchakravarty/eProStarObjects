using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Utility
{
   public class CSVReader
   {
       private Stream objStream;
       private StreamReader objReader;
    
       public CSVReader(Stream filestream) : this(filestream, null) 
       { 
            
       }

       public CSVReader(Stream filestream, Encoding enc)
       {
           this.objStream = filestream;
           if (!filestream.CanRead)
           {
               return;
           }
           objReader = (enc != null) ? new StreamReader(filestream, enc) : new StreamReader(filestream);
       }

       //parse the Line
       public string[] GetCSVLine()
       {
           string data = objReader.ReadLine();
           if (data == null) return null;
           if (data.Length == 0) return new string[0];
           if (data.Replace(',', ' ').Trim().Length == 0) return new string[0];

           ArrayList result = new ArrayList();
           ParseCSVData(result, data);
           return (string[])result.ToArray(typeof(string));
       }
    
       private void ParseCSVData(ArrayList result, string data)
       {
           int position = -1;
           while (position < data.Length)
               result.Add(ParseCSVField(ref data, ref position));
       }
    
       private string ParseCSVField(ref string data, ref int StartSeperatorPos)
       {
           if (StartSeperatorPos == data.Length - 1)
           {
               StartSeperatorPos++;
               return "";
           }
    
           int fromPos = StartSeperatorPos + 1;
           if (data[fromPos] == '"')
           {
              int nextSingleQuote = GetSingleQuote(data, fromPos + 1);
               int lines = 1;
               while (nextSingleQuote == -1)
               {
                   data = data + "\n" + objReader.ReadLine();
                   nextSingleQuote = GetSingleQuote(data, fromPos + 1);
                   lines++;
                   if (lines > 20)
                       throw new Exception("lines overflow " + data);
               }
               StartSeperatorPos = nextSingleQuote + 1;
               string tempString = data.Substring(fromPos + 1, nextSingleQuote - fromPos - 1);
               tempString = tempString.Replace("'", "''");
               return tempString.Replace("\"\"", "\"");
          }
   
           int nextComma = data.IndexOf(',', fromPos);
           if (nextComma == -1)
           {
               StartSeperatorPos = data.Length;
             return data.Substring(fromPos);
           }
           else
          {
               StartSeperatorPos = nextComma;
              return data.Substring(fromPos, nextComma - fromPos);
           }
       }
    
       private int GetSingleQuote(string data, int SFrom)
       {
           int i = SFrom - 1;
           while (++i < data.Length)
               if (data[i] == '"')
               {
                 if (i < data.Length - 1 && data[i + 1] == '"')
                  {
                      i++;
                      continue;
                  }
                  else
                      return i;
              }
          return -1;
      }

       public void WriteDataTableToCSV(DataTable sourceTable, TextWriter writer, bool includeHeaders)
       {
           if (includeHeaders)
           {
               List<string> headerValues = new List<string>();
               foreach (DataColumn column in sourceTable.Columns)
               {
                   headerValues.Add(QuoteValue(column.ColumnName));
               }

               writer.WriteLine(String.Join(",", headerValues.ToArray()));
           }

           string[] items = null;
           foreach (DataRow row in sourceTable.Rows)
           {
               items = row.ItemArray.Select(o => QuoteValue(o.ToString())).ToArray();
               writer.WriteLine(String.Join(",", items));
           }

           writer.Flush();
       }

       private string QuoteValue(string value)
       {
           return String.Concat("\"", value.Replace("\"", "\"\""), "\"");
       }
  }
   
}