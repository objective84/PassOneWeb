using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using PassOne.Domain;
using PassOne.Service;
using PassOne.Service.Factories;

namespace PassOneUnitTests
{
   public abstract class PassOneEntityTests
   {
       protected readonly EntityFactory Factory;
       protected readonly User TestUser = new User(1, "Peter", "Varner-Howland", "pvarnerhowland", "testPass321");
       protected readonly User TestUser2 = new User(2, "Arwen", "Varner-Howland", "avarnerhowland", "testPass123");

       protected readonly Credentials TestCredentials = new Credentials("Regis WorldClass", "https://worldclass.regis.edu/",
                                                             "pvarnerhowland",
                                                             "testpass123", "pvarnerhowland@regis.edu", 1);
       protected readonly Credentials TestCredentials2 = new Credentials("Regis InSite", "https://in2.regis.edu/CookieAuth.dll?GetLogon?curl=Z2F&reason=0&formdir=6",
                                                             "pvarnerhowland",
                                                             "testpass456", "pvarnerhowland@regis.edu", 2);

       protected PassOneEntityTests()
       {
           Factory = new EntityFactory();
       }

       protected SqlConnection GetConnection()
       {
           //string connectionString = string.Empty;
           //connectionString = WebConfigurationManager.ConnectionStrings
           //[DBConnectionString].ConnectionString;
           string connectionString =
           @"Server=58826db7-1b25-484d-80ee-a18f014cef68.sqlserver.sequelizer.com;Database=db58826db71b25484d80eea18f014cef68;User ID=ldzbbqvkzfaguknu;Password=ykp6nDRswdkxFMSXgysvPc2dGvzU6Fu5D2hoExn4yLP8CA2rBkhxgihvskxYe6vX;";

           return new SqlConnection(connectionString);
       }
    }
}
