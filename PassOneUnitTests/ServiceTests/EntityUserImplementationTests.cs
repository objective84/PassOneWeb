using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassOne;
using PassOne.Domain;
using PassOne.Service;

namespace PassOneUnitTests.ServiceTests
{
    [TestClass]
    public class EntityUserImplementationTests : PassOneEntityTests
    {
        private EntityUserImplementation _service;

        public EntityUserImplementationTests()
        {
            _service = Factory.GetEntityService(Services.EntityUserImplementation) as EntityUserImplementation;
        }

        

        [TestMethod]
        public void TestRetrieveById()
        {
            var expected = new PassOneUser(TestUser.Id, TestUser.FirstName, TestUser.LastName, TestUser.Username,
                                           TestUser.Password);
            var actual = _service.RetreiveById(TestUser.Id);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCreate()
        {

            var user = new PassOneUser(_service.GetNextIdValue(), TestUser2.FirstName, TestUser2.LastName,
                                       TestUser2.Username,
                                       TestUser2.Password, TestUser2.k, TestUser2.v);
            _service.Create(user);

            User actual;
            using (var db = new PassOneContext())
            {
                db.Database.Connection.Open();
                var query = from u in db.Users select u;
                actual = query.ToList().FirstOrDefault(user1 => user1.Id == user.Id);
            }
            Assert.IsNotNull(actual);

            using (var db = new PassOneContext())
            {
                db.Database.Connection.Open();
                var userQuery = from u in db.Users select u;
                var remove = userQuery.ToList().FirstOrDefault(user1 => user1.Id == user.Id);
                db.Users.Remove(remove);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDelete()
        {
            using (var db = new PassOneContext())
            {
                db.Database.Connection.Open();
                var credsQuery = from c in db.Credentials select c;
                var creds = credsQuery.ToList().FirstOrDefault((creds1 => creds1.Id == TestCredentials.Id));
                db.Credentials.Remove(creds);
                db.SaveChanges();
                var user = new PassOneUser(TestUser.Id, TestUser.FirstName, TestUser.LastName, TestUser.Username,
                                           TestUser.Password, TestUser.k, TestUser.v);
                _service.Delete(user);

                var userQuery = from u in db.Users select u;
                var actual = userQuery.ToList().FirstOrDefault(user1 => user1.Id == user.Id);

                Assert.IsNull(actual);
            }
        }
    }
}
