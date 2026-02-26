using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core
{
    public static class ConfigClass
    {
        //Scaffold-DbContext "Server=localhost;Database=OnlineConsent;Trusted_Connection=True;User Id=sa;Password=123;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DBModels -Force
        //var con = Startup.ConnectionString;
        //optionsBuilder.UseSqlServer(con);

        //public static string ConnectionString = "Data Source=localhost;Initial Catalog=MseBloodDonors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static string ConnectionString = "Server=localhost;Database=DiriWebPortal;User Id=sa; Password=123";
        //public static string ConnectionString = "Server=167.86.90.42;Database=DiriWebPortal;User Id=sa; Password=DiriWeb";

        public static string SUCCESS = "000";
        public static string SUCCESS_MESSAGE = "Success";        

        public static string USER_NOT_AUTHENTICATED = "001";
        public static string USER_NOT_AUTHENTICATED_MESSAGE = "User not authenticated";

        public static string DATA_NOT_FOUND = "002";
        public static string DATA_NOT_FOUND_MESSAGE = "No data found!";

        public static string ERROR = "003";
        public static string ERROR_MESSAFGE = "Error";

    }
}
