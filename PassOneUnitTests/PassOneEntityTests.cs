using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using PassOne;
using PassOne.Domain;
using PassOne.Service;
using PassOne.Service.Factories;

namespace PassOneUnitTests
{
   public abstract class PassOneEntityTests
   {
       private byte[] _testKey = new byte[]
           {
               220, 1, 103, 95, 8, 241, 44, 75, 252, 211, 167, 232, 169, 41, 181, 122, 51, 118,
               66, 175, 96
               ,
               102, 163, 243, 26, 232, 40, 189, 174, 181, 229, 13
           };

       private byte[] _testVector =
           new byte[] {229, 219, 79, 110, 4, 98, 121, 23, 194, 214, 43, 142, 22, 247, 128, 206};

       protected readonly EntityFactory Factory;
       protected readonly User TestUser;
       protected readonly User TestUser2;

       protected readonly Credential TestCredentials;
       protected readonly Credential TestCredentials2;

       protected PassOneEntityTests()
       {
           Factory = new EntityFactory();
           TestUser = new User()
               {
                   Id = 1,
                   FirstName = "Peter",
                   LastName = "Varner-Howland",
                   Username = "pvarnerhowland",
                   Password = "testPass321",
                   k = _testKey,
                   v = _testVector
               };
           TestUser2 = new User()
               {
                   Id = 2,
                   FirstName = "Arwen",
                   LastName = "Varner-Howland",
                   Username = "avarnerhowland",
                   Password = "testPass123",
                   k = _testKey,
                   v = _testVector
               };
           TestCredentials = new Credential()
               {
                   Title = "Regis WorldClass",
                   Url = "https://worldclass.regis.edu/",
                   Username = "pvarnerhowland",
                   Password = "testpass123",
                   Email = "pvarnerhowland@regis.edu",
                   Id = 1
               };
           TestCredentials2 = new Credential()
               {
                   Title = "Regis InSite",
                   Url = "https://in2.regis.edu/CookieAuth.dll?GetLogon?curl=Z2F&reason=0&formdir=6",
                   Username = "pvarnerhowland",
                   Password = "testpass456",
                   Email = "pvarnerhowland@regis.edu",
                   Id = 2
               };
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
