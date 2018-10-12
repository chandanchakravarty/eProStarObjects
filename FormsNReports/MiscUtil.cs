using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessAccessLayer.Common;

namespace FormsNReports
{
    
   static class MiscUtil
    {
      
       public static string MyFormat(decimal num)
       {
           string format = "{0:N2}";
           if (num < 0)
           {
               format = "({0:N2})";
           }
           return string.Format(format, Math.Abs(num));
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
