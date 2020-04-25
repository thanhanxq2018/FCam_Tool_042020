using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MapOpennet.App_Code
{
    public static class AuthOTP
    {
        public static bool IsInsideAuthenticatedByOTP(string usr, string pwd, int clientOTP)
        {
            bool authenticated = false;
            try
            {
                net.fpt.accountotp.Service insideAccount = new net.fpt.accountotp.Service();
                authenticated = insideAccount.LogOn(usr, pwd, clientOTP);
            }
            catch (Exception ex)
            {
                //not authenticated
            }
            return authenticated;
        }

        public static string[] GetUserByToken(string token, string ip)
        {
            try
            {
                net.fpt.accountotp.Service insideAccount = new net.fpt.accountotp.Service();
                return insideAccount.GetUserByToken(token, ip);
            }
            catch (Exception ex)
            {
                //not authenticated
            }
            return new string[0];
        }

        public static bool LogoutSSO(string token, string ip)
        {
            try
            {
                net.fpt.accountotp.Service insideAccount = new net.fpt.accountotp.Service();
                return insideAccount.LogoutSSO(token, ip);
            }
            catch (Exception ex)
            {
                //not authenticated
                return false;
            }
        }
        public static string GetClientIP(HttpRequestBase request)
        {
            String ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            try
            {
                if (string.IsNullOrEmpty(ip))
                    ip = request.ServerVariables["REMOTE_ADDR"];
                else
                    ip = ip.Split(',')[0];
            }
            catch (Exception)
            {
                ip = request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
        }

        public static string EncodePass(string password)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
        }

    }
}