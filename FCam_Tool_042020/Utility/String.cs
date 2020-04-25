using System.Globalization;

namespace Utility
{
    static class SubstringExtensions
    {
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

        /// <summary>
        /// Tra ve chuoi in hoa dau dong
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToUpperFirstCharString(this string value)
        {
            value = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            return value;
        }

        /// <summary>
        /// Tra ve chuoi in hoa dau dong
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToLowerFirstCharString(this string value)
        {
            value = value.Substring(0, 1).ToLower() + value.Substring(1);
            return value;
        }

        /// <summary>
        /// Tra ve chuoi da viet hoa dau dong
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        /// <summary>
        /// Tra ve chuoi da viet hoa dau dong, bo khoang trang
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTitleCaseWithoutSpace(this string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()).Replace(" ", "").Replace("  ","");
        }
    }

}
