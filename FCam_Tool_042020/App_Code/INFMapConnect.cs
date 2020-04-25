using System.Configuration;

namespace MapOpennet.App_Code
{
    public class INFMapConnect
    {
        public static string sqlConnectString = ConfigurationManager.ConnectionStrings["INFMapConnectString"].ConnectionString;
        public static string sqlReadConnectString = ConfigurationManager.ConnectionStrings["INFMapReadConnectString"].ConnectionString;

        public static string userName = "";
    }
}