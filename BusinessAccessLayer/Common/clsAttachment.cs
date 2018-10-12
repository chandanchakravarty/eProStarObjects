using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using BusinessObjectLayer.Common;
using DataAccessLayer;

namespace BusinessAccessLayer.Common
{
    public class clsAttachment
    {
        private const string MNT_ATTACHMENT_LIST = "MNT_ATTACHMENT_LIST";

        #region variables, function and Constants to be used for imporsonation
        // Declare the logon types as constants
        const int LOGON32_LOGON_INTERACTIVE = 2;
        const int LOGON32_LOGON_NETWORK = 3;

        // Declare the logon providers as constants
        const int LOGON32_PROVIDER_DEFAULT = 0;
        const int LOGON32_PROVIDER_WINNT50 = 3;
        const int LOGON32_PROVIDER_WINNT40 = 2;
        const int LOGON32_PROVIDER_WINNT35 = 1;

        WindowsImpersonationContext impersonationContext;

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int LogonUser(String lpszUserName, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        [DllImport("advapi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public extern static int DuplicateToken(IntPtr hToken, int impersonationLevel, ref IntPtr hNewToken);
        #endregion

        public clsAttachment()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region ImpersonateUser
        /// <summary>
        /// Impersonate the specified user on specifed domain with specified password
        /// </summary>
        /// <param name="userName">Login Name</param>
        /// <param name="password">Password of Login</param>
        /// <param name="domainName">Domain Name</param>
        /// <returns></returns>
        public bool ImpersonateUser(String userName, String password, String domainName)
        {
            WindowsIdentity tempWindowsIdentity;
            IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;
            bool authentication = false;

            try
            {
                //Temprary code for Block Impersonation (Use for Development)
                if (ConfigurationSettings.AppSettings.Get("Impersonate") == "0")
                {
                    authentication = true;
                }
                else
                {

                    if (LogonUser(userName, domainName, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref token) != 0)
                    {
                        if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                        {
                            tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                            impersonationContext = tempWindowsIdentity.Impersonate();
                            if (impersonationContext != null)
                                authentication = true;
                            else
                                authentication = false;
                        }
                        else
                            authentication = false;
                    }
                    else
                        authentication = false;
                }
            }
            catch (Exception err)
            {

            }
            return authentication;
        }
        #endregion

        #region end impersonate
        /// <summary>
        /// End the imporsonation
        /// </summary>
        public void endImpersonation()
        {
            try
            {
                if (impersonationContext != null) impersonationContext.Undo();
            }
            catch (Exception ex)
            {
                //System.Diagnostics.EventLog.WriteEntry("EbixASP WebMerge 3.0", "Impersionation Error; Message:-" + ex.Message);
            }
        }
        #endregion

    }
}
