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
            SqlConnection conn = null;
            try
            {
                conn = GetConnection();
                conn.Open();
                using (var db = new PassOneDataContext())
                {
                    db.Users.Add(new UserEntity(TestUser.Id, TestUser.FirstName, TestUser.LastName, TestUser.Username,
                                                TestUser.Password));
                    db.SaveChanges();
                }
            }
            finally
            {
                conn.Close();
            }
          

            var expected = TestUser;
            var actual = new UserEntity();


        }
    }
}
