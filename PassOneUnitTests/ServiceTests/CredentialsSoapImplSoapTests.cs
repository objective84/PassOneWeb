using System;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassOne.Domain;
using PassOne.Service;

namespace PassOneUnitTests.ServiceTests
{
    [TestClass]
    public class CredentialsSoapImplSoapTests : PassOneSoapTests
    {

        private readonly ISerializeSvc _credSrv;

        //Constructor
        public CredentialsSoapImplSoapTests()
        {
            _credSrv = Factory.GetSoapService(Services.CredentialsSoapSerializer, Path, TestPassOneUser) as ISerializeSvc;
        }

        //Setup and TearDown
        [TestInitialize]
        public void Init()
        {
        }

        [TestCleanup]
        public void Dispose()
        {
            Directory.Delete(Path, true);
        }

        /// <summary>
        /// Test to store a single set of credentials, should pass.
        /// </summary>
        [TestMethod]
        public void StoreCredentialsTest()
        {
            _credSrv.UpdateTable(TestPassOneCredentials);
            TestPassOneCredentials.Decrypt(TestPassOneUser.Encryption);
            Assert.AreEqual(TestPassOneCredentials, _credSrv.RetreiveById(1));
        }

        /// <summary>
        /// Test to store multiple credentials, should pass.
        /// </summary>
        [TestMethod]
        public void StoreMultipleCredentials()
        {
            _credSrv.UpdateTable(TestPassOneCredentials);
            _credSrv.UpdateTable(TestCredentials2);
            TestPassOneCredentials.Decrypt(TestPassOneUser.Encryption);
            TestCredentials2.Decrypt(TestPassOneUser.Encryption);
            Assert.AreEqual(TestPassOneCredentials, _credSrv.RetreiveById(1));
            Assert.AreEqual(TestCredentials2, _credSrv.RetreiveById(2));
        }

        /// <summary>
        /// Test updating a pre-existing credential set.
        /// </summary>
        [TestMethod]
        public void UpdateCredentialsTest()
        {
            _credSrv.UpdateTable(TestPassOneCredentials);
            TestPassOneCredentials.Password = TestCredentials2.Password;
            _credSrv.UpdateTable(TestPassOneCredentials);
            var creds = _credSrv.RetreiveById(1);
            Assert.AreEqual(TestCredentials2.Password, ((PassOneCredentials)creds).Password);
        }
    }
}
