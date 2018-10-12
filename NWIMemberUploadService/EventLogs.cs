using System;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Collections.Generic;
using System.IO;

namespace MemberUploadService
{
    public class EventLogs
    {
        // Following are used by the LogEvent function
        static bool isLoggingEnabled = false;
        static bool LoggingErrorEvents = false;
        static bool LoggingWarnEvents = false;
        static bool LoggingInfoEvents = false;
        static bool LoggingAuditSuccessEvents = false;
        static bool LoggingAuditFailureEvents = false;
        static string EventLogName = "";
        static string EventLogSourceName = "";
        static Dictionary<string, object> dict = null;
        static LogEntry logEntry = null;

        static EventLogs()
        {
            // Get logging values from web.config
            try
            {
                //isLoggingEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["LogEnabled"]);
                //LoggingErrorEvents = Convert.ToBoolean(ConfigurationManager.AppSettings["LogErrorEvents"]);
                //LoggingWarnEvents = Convert.ToBoolean(ConfigurationManager.AppSettings["LogWarningEvents"]);
                //LoggingInfoEvents = Convert.ToBoolean(ConfigurationManager.AppSettings["LogInformationEvents"]);
                //LoggingAuditSuccessEvents = Convert.ToBoolean(ConfigurationManager.AppSettings["LogAuditSuccessEvents"]);
                //LoggingAuditFailureEvents = Convert.ToBoolean(ConfigurationManager.AppSettings["LogAuditFailureEvents"]);
                //EventLogName = ConfigurationManager.AppSettings["EventLogName"];
                //EventLogSourceName = ConfigurationManager.AppSettings["EventLogSourceName"];

                isLoggingEnabled = true;
                LoggingErrorEvents = true;
                LoggingWarnEvents = true;
                LoggingInfoEvents = true;
                LoggingAuditSuccessEvents = true;
                LoggingAuditFailureEvents = true;
                EventLogName = "NWIMemberUploadServiceLog";
                EventLogSourceName = "NWIMemberUploadServiceLog";
            }
            catch
            {
                // Set to defaults values				
                isLoggingEnabled = true;
                LoggingErrorEvents = true;
                LoggingWarnEvents = true;
                LoggingInfoEvents = true;
                LoggingAuditSuccessEvents = true;
                LoggingAuditFailureEvents = true;
                EventLogName = "NWIMemberUploadServiceLog";
                EventLogSourceName = "NWIMemberUploadServiceLog";
            }
        }
        public static bool Publish(Exception ex)
        {
            bool boolExceptionPublished = false;
            if (LogEvent("[Source: " + ex.Source + "] " + ex.Message, System.Diagnostics.EventLogEntryType.Error))
                boolExceptionPublished = true;
            return boolExceptionPublished;
        }

        public static bool Publish(string ErrMessage)
        {
            bool boolExceptionPublished = false;
            if (LogEvent(ErrMessage, System.Diagnostics.EventLogEntryType.Error)) boolExceptionPublished = true;
            return boolExceptionPublished;
        }

        public static bool Publish(string message, System.Diagnostics.EventLogEntryType type)
        {
            bool boolExceptionPublished = false;
            if (LogEvent(message, type)) boolExceptionPublished = true;
            return boolExceptionPublished;
        }

        private static bool LogEvent(string message, System.Diagnostics.EventLogEntryType type)
        {
            bool loggingType = false;
            try
            {
                bool logExists = System.Diagnostics.EventLog.Exists(EventLogName);
                if (!logExists)
                {
                    // log doesn't exist
                    System.Diagnostics.EventLog.CreateEventSource(EventLogSourceName, EventLogName);
                }
                System.Diagnostics.EventLog myEventLog = new System.Diagnostics.EventLog(EventLogName);
                myEventLog.Source = EventLogSourceName;
                if (isLoggingEnabled)
                {
                    switch (type)
                    {
                        case System.Diagnostics.EventLogEntryType.Error:
                            loggingType = LoggingErrorEvents;
                            break;

                        case System.Diagnostics.EventLogEntryType.Warning:
                            loggingType = LoggingWarnEvents;
                            break;

                        case System.Diagnostics.EventLogEntryType.Information:
                            loggingType = LoggingInfoEvents;
                            break;

                        case System.Diagnostics.EventLogEntryType.SuccessAudit:
                            loggingType = LoggingAuditSuccessEvents;
                            break;

                        case System.Diagnostics.EventLogEntryType.FailureAudit:
                            loggingType = LoggingAuditFailureEvents;
                            break;

                        default:
                            loggingType = false;
                            break;
                    }

                    if (loggingType)
                    {
                        if (type == System.Diagnostics.EventLogEntryType.Error)
                        {
                            try
                            {
                                dict = null;
                                dict = new Dictionary<string, object>();
                                dict.Add("Date & Time   :", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                                dict.Add("Message       :", message);
                                logEntry = new LogEntry();
                                logEntry.Message = "MSIG Data Service Process - # : " + message;
                                logEntry.Categories.Add("General");
                                if (dict != null)
                                    logEntry.ExtendedProperties = dict;
                                Logger.Write(logEntry);
                            }
                            catch
                            {
                            }
                        }
                        // max length for an event log message is 32k
                        myEventLog.WriteEntry((message.Length > 31500 ? message.Substring(0, 31500) + "...Message Truncated" : message), type);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        } // end log event

        
    }
}
