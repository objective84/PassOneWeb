using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassOne;
using PassOne.Domain;
using PassOne.Service;

namespace PassOneUnitTests.ServiceTests
{
    [TestClass]
    public class EntityCredentialsImplementationTests : PassOneEntityTests
    {
        private EntityCredentialsImplementation _service;

        public EntityCredentialsImplementationTests()
        {
            _service = new EntityCredentialsImplementation();
        }
        [TestMethod]
        public void TestRetrieveById()
        {
            var expected = ConvertToDomainObject(TestCredentials);
            var actual = _service.RetreiveById(TestCredentials.Id);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCreate()
        {
            var creds = ConvertToDomainObject(TestCredentials);
            _service.Create(creds);

            PassOneCredentials expected = creds;
            PassOneCredentials actual;
            using (var db = new PassOneContext())
            {
                db.Database.Connection.Open();
                var query = from u in db.Credentials select u;
                actual = ConvertToDomainObject(query.ToList().FirstOrDefault(creds1 => creds1.Id == creds.Id));
            }
            Assert.AreEqual(expected, actual);

            using (var db = new PassOneContext())
            {
                db.Database.Connection.Open();
                var credsQuery = from c in db.Credentials select c;
                var remove = credsQuery.ToList().FirstOrDefault(creds1 => creds1.Id == creds.Id);
                db.Credentials.Remove(remove);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDelete()
        {
            _service.Delete(ConvertToDomainObject(TestCredentials));
            using (var db = new PassOneContext())
            {
                var query = from u in db.Credentials select u;
                var actual = query.ToList().FirstOrDefault(creds => creds.Id == TestCredentials.Id);

                Assert.IsNull(actual);
            }
        }

        private PassOneCredentials ConvertToDomainObject(Credential entity)
        {
            return new PassOneCredentials(entity.Id, entity.UserId, entity.Title, entity.Url, entity.Username, entity.Email, entity.Password);
        }

        private Credential ConvertToEntity(PassOneObject obj)
        {
            var creds = (PassOneCredentials)obj;
            var newCred = new Credential
            {
                Id = creds.Id,
                UserId = creds.UserId,
                Title = creds.Website,
                Url = creds.Url,
                Username = creds.Username,
                Email = creds.EmailAddress,
                Password = creds.Password
            };
            return newCred;
        }
    }
}
