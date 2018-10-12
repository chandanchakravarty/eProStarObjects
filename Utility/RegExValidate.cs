using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace Utility
{
    /// <summary>
    /// To Validate strings against Regular Expression strings.
    /// </summary>
    public class RegExValidate
    {
        static ArrayList RegexStrings;
        static RegExValidate()
        {
            RegexStrings = new ArrayList();
            //DATE YYYYMMDD
            RegexStrings.Insert((int)Constants.ValidationTypes.DateYYYYMMDD, @"^(\d{4}((0[1-9]|1[012])(0[1-9]|1\d|2[0-8])|(0[13456789]|1[012])(29|30)|(0[13578]|1[02])31)|([02468][048]|[13579][26])0229)$");
            //Positive Integer
            RegexStrings.Insert((int)Constants.ValidationTypes.PositiveInteger, @"^\d\d*$");
            //Alphanumeric Only
            RegexStrings.Insert((int)Constants.ValidationTypes.AlphaNumeric, @"^\w+$");
            //Positive Decimal
            RegexStrings.Insert((int)Constants.ValidationTypes.PositiveIntAndDecimal, @"(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.(\d{1,2})*$)");
            //Alphabet only
            RegexStrings.Insert((int)Constants.ValidationTypes.Alphabet, @"^[a-zA-Z ]*$");
            //Numeric 4 Digits only
            RegexStrings.Insert((int)Constants.ValidationTypes.Numeric4Digits, @"^\d\d\d\d$");
            //Alphanumeric with Special Chars Like -.
            RegexStrings.Insert((int)Constants.ValidationTypes.AlphaNumericWithSpecialChars, @"^[\(\)\+\=\/\-a-zA-Z0-9 ]*$");
            //DATE DDMMYYYY
            RegexStrings.Insert((int)Constants.ValidationTypes.DateDDMMYYYY, @"^(?=\d)(?:(?!(?:(?:0?[5-9]|1[0-4])(?:\.|-|\/)10(?:\.|-|\/)(?:1582))|(?:(?:0?[3-9]|1[0-3])(?:\.|-|\/)0?9(?:\.|-|\/)(?:1752)))(31(?!(?:\.|-|\/)(?:0?[2469]|11))|30(?!(?:\.|-|\/)0?2)|(?:29(?:(?!(?:\.|-|\/)0?2(?:\.|-|\/))|(?=\D0?2\D(?:(?!000[04]|(?:(?:1[^0-6]|[2468][^048]|[3579][^26])00))(?:(?:(?:\d\d)(?:[02468][048]|[13579][26])(?!\x20BC))|(?:00(?:42|3[0369]|2[147]|1[258]|09)\x20BC))))))|2[0-8]|1\d|0?[1-9])([-.\/])(1[012]|(?:0?[1-9]))\2((?=(?:00(?:4[0-5]|[0-3]?\d)\x20BC)|(?:\d{4}(?:$|(?=\x20\d)\x20)))\d{4}(?:\x20BC)?))?$");
            //AlphaNumeric only
            RegexStrings.Insert((int)Constants.ValidationTypes.AlphaNumericCheck, @"^[a-zA-Z0-9\-\.]+$");

        }

        /// <summary>
        /// Method returns true if unknown string matches the 
        /// regular expression defined by type
        /// </summary>
        /// <param name="type">ValidationTypes enum</param>
        /// <param name="unknown">String to validate</param>
        /// <returns>True if string validates</returns>
        public static bool Process(Constants.ValidationTypes type, string strToValidate)
        {
            string strToValidateTmp = strToValidate;

            if (strToValidate.Length > 0)
            {
                #region "Date Set"
                if (type.ToString().Equals("DateDDMMYYYY"))
                {
                    strToValidate = string.Empty;

                    if (strToValidateTmp.IndexOf("/") > 0)
                    {
                        try
                        {
                            if (strToValidateTmp.Split('/')[0] != null)
                            {
                                if (strToValidateTmp.Split('/')[0].Length == 1)
                                    strToValidate += "0" + strToValidateTmp.Split('/')[0].ToString().Trim() + "/";
                                else
                                    strToValidate += strToValidateTmp.Split('/')[0].ToString().Trim() + "/";
                            }
                        }
                        catch (Exception ex)
                        {
                            strToValidate += "/";
                        }

                        try
                        {
                            if (strToValidateTmp.Split('/')[1] != null)
                            {
                                if (strToValidateTmp.Split('/')[1].Length == 1)
                                    strToValidate += "0" + strToValidateTmp.Split('/')[1].ToString().Trim() + "/";
                                else
                                    strToValidate += strToValidateTmp.Split('/')[1].ToString().Trim() + "/";
                            }
                        }
                        catch (Exception ex)
                        {
                            strToValidate += "/";
                        }


                        try
                        {
                            if (strToValidateTmp.Split('/')[2] != null)
                            {
                                if (strToValidateTmp.Split('/')[2].Length == 1)
                                    strToValidate += DateTime.Today.Year.ToString().Substring(0, 3) + strToValidateTmp.Split('/')[2].ToString().Trim();
                                else if (strToValidateTmp.Split('/')[2].Length == 2)
                                    strToValidate += DateTime.Today.Year.ToString().Substring(0, 2) + strToValidateTmp.Split('/')[2].ToString().Trim();
                                else if (strToValidateTmp.Split('/')[2].Length == 3)
                                    strToValidate += DateTime.Today.Year.ToString().Substring(0, 1) + strToValidateTmp.Split('/')[2].ToString().Trim();
                                else
                                    strToValidate += strToValidateTmp.Split('/')[2].ToString().Trim();
                            }
                        }
                        catch (Exception ex)
                        {
                            strToValidate += "/";
                        }
                    }
                }
                #endregion
                return new Regex(RegexStrings[(int)type].ToString()).Match(strToValidate).Success;
            }
            else
                return true;
        }
    }
}
