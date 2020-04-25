using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Utility
{
    public static class Files
    {
        public static string currentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string currentUser = SystemInformation.UserName;
        public static List<string> lstConnectString = new List<string>()
        {
            "ServerName=Dev;DatabaseName=MJSSYSAUD;uid=mjsadmin;pwd=mjsfpt2017;",
            "ServerName=Dev;DatabaseName=MJSDEFAULT;uid=mjsadmin;pwd=mjsfpt2017;",
            "ServerName=Dev;DatabaseName=MJSCOMMON;uid=mjsadmin;pwd=mjsfpt2017;",
            "ServerName=Dev;DatabaseName=MYNCOMMON;uid=mjsadmin;pwd=mjsfpt2017;",
            "ServerName=Dev;DatabaseName=MASCOMMON;uid=mjsadmin;pwd=mjsfpt2017;",
            "ServerName=Dev;DatabaseName=HAPCOMMON;uid=mjsadmin;pwd=mjsfpt2017;",
            "ServerName=Dev;DatabaseName=DEPCOMMON;uid=mjsadmin;pwd=mjsfpt2017;",
            "ServerName=Dev;DatabaseName=WFLCOMMON;uid=mjsadmin;pwd=mjsfpt2017;",
            "ServerName=Dev;DatabaseName=SELCOMMON;uid=mjsadmin;pwd=mjsfpt2017;",
            "ServerName=Dev;DatabaseName=MASDT9999999999999999;uid=mjsadmin;pwd=mjsfpt2017;",
            "ServerName=Dev;DatabaseName=HAPDTXXX99999999;uid=mjsadmin;pwd=mjsfpt2017;",
            "ServerName=Dev;DatabaseName=DEPDTXXX99999999;uid=mjsadmin;pwd=mjsfpt2017;",
            "ServerName=Dev;DatabaseName=WFLDTXXX99999999;uid=mjsadmin;pwd=mjsfpt2017;",
            "ServerName=Dev;DatabaseName=SELDTXXX99999999;uid=mjsadmin;pwd=mjsfpt2017;"
        };
        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        /// <summary> 
        /// Get List FilePath In Folder
        /// </summary>
        /// <param name="strPath"></param>
        /// <param name="isSearchAllDirectories"></param>
        /// <param name="patternSearch"></param>
        /// <returns></returns>
        public static List<string> GetListFilePathInFolder1(string strPath, bool isSearchAllDirectories, string patternSearch = "*cs")
        {
            var result = Directory.GetFiles(strPath, patternSearch, isSearchAllDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Where(file => Regex.IsMatch(file, @"^.+\.(cs)$")).ToList();
            return result;
        }

        public static List<string> GetListFilePathInFolder2(string strPath, bool isSearchAllDirectories, string patternSearch = "*cs")
        {
            var result = Directory.EnumerateFiles(strPath, patternSearch, isSearchAllDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Where(file => Regex.IsMatch(file, @"^.+\.(cs)$")).ToList();
            return result;
        }

        public static List<string> GetListFilePathInFolder3(string strPath, bool isSearchAllDirectories, string patternSearch = "*")
        {
            var result = Directory.EnumerateFiles(strPath, patternSearch, isSearchAllDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).ToList(); //.Where(file => Regex.IsMatch(file, @"^.+\.(cs)$")).ToList();
            return result;
        }

        public static List<string> GetListFilePathInFolder(string strPath, bool isSearchAllDirectories, string patternType = @"^.+\.(cs|js|ts|html|json)$", string patternSearch = "*")
        {
            var files = Directory.EnumerateFiles(strPath, patternSearch, isSearchAllDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
            .Where(file => Regex.IsMatch(file, patternType)).ToList();
            return files;
        }

        /// <summary>
        /// Get string value between [first] a and [last] b.
        /// </summary>
        public static string Between(this string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }

        /// <summary>
        /// Get string value after [first] a.
        /// </summary>
        public static string Before(this string value, string a)
        {
            int posA = value.IndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            return value.Substring(0, posA);
        }

        /// <summary>
        /// Get string value after [last] a.
        /// </summary>
        public static string After(this string value, string a)
        {
            int posA = value.LastIndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }
            return value.Substring(adjustedPosA);
        }
    }
}
