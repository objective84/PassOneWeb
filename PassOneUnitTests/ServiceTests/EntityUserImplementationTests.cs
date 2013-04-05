using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassOne;
using PassOne.Service;

namespace PassOneUnitTests.ServiceTests
{
    [TestClass]
    public class EntityUserImplementationTests : PassOneEntityTests
    {
        private IService _service;

        public EntityUserImplementationTests()
        {
            _service = Factory.GetEntityService(Services.EntityUserImplementation);
            

        }

        [TestMethod]
        public void TestRetrieveById()
        {
            try
            {

                using (var db = new PassOneDataContext())
                {
                    db.Database.Connection.Open();
                    var user = new UserEntity();
                    user.Id = 2;
                    user.FirstName = "AnotherFN";
                    user.LastName = "AnotherLN";
                    user.Username = "AnotherUN";
                    user.Password = "MainPass";
                    var cred = new CredentialsEntity();

                    cred.Id =
                    cred.UserId = 2;
                    cred.Title = "CredTitle";
                    cred.Url = "url";
                    cred.Username = "CredUN";
                    cred.Email = "CredEmail";
                    cred.Password = "CredPass";
                    cred.User = user;
                    user.Credentials.Add(cred);
                    db.UserEntities.Add(user);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
