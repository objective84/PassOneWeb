using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using PassOne.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PassOne.Domain;

namespace PassOneUnitTests.BusinessTests
{
    /// <summary>
    ///This is a test class for CredentialsManagerTest and is intended
    ///to contain all CredentialsManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CredentialsManagerSoapTests : PassOneSoapTests
    {
        public SoapFormatter Soap = new SoapFormatter();
        public FileStream Stream;
        public TestContext TestContextInstance;
        private CredentialsManager _manager = new CredentialsManager();

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return TestContextInstance;
            }
            set
            {
                TestContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _manager = new CredentialsManager();
            if (!Directory.Exists(Path + "data"))
                Directory.CreateDirectory(Path+ "data");
            Stream = new FileStream(Path + "data\\data.bin", FileMode.Create, FileAccess.ReadWrite);
        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            Stream.Close();
            Directory.Delete(Path, true);
        }
        
        #endregion


        /// <summary>
        ///A test for CreateUser
        ///</summary>
        [TestMethod()]
        public void CreateTest()
        {
            Stream.Close();
            var user = TestPassOneUser; 
            var creds = TestPassOneCredentials;
            _manager.CreateCredentials(user, TestPassOneCredentials, Path);
            Stream = new FileStream(Path + "data\\data.bin", FileMode.Open, FileAccess.Read);
            var table = Soap.Deserialize(Stream) as Hashtable;
            var expected = creds;
            var actual = table[TestPassOneCredentials.Id];
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            PassOneCredentials creds = TestPassOneCredentials.Copy();
            PassOneUser passOneUser = TestPassOneUser;
            creds.Encrypt(passOneUser.Encryption);

            var table = new Hashtable() { { TestPassOneCredentials.Id, TestPassOneCredentials } };
            Soap.Serialize(Stream, table);
            Stream.Close();
            creds.Decrypt(passOneUser.Encryption);
            _manager.DeleteCredentials(creds, passOneUser, Path);
            Stream = new FileStream(Path + "data\\data.bin", FileMode.Open, FileAccess.Read);
            table = Soap.Deserialize(Stream)as Hashtable;
            Assert.AreEqual(0, table.Count);

        }

        /// <summary>
        ///A test for Find
        ///</summary>
        [TestMethod()]
        public void FindTest()
        {
            PassOneUser passOneUser = TestPassOneUser;
            int id = TestPassOneCredentials.Id;
            var expected = TestPassOneCredentials.Copy();
            expected.Encrypt(passOneUser.Encryption);
            var table = new Hashtable() { { expected.Id, expected } };
            Soap.Serialize(Stream, table);
            Stream.Close();
            expected.Decrypt(passOneUser.Encryption);

            PassOneCredentials actual = _manager.FindCredentials(passOneUser, id, Path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            PassOneUser passOneUser = TestPassOneUser;
            PassOneCredentials creds = TestPassOneCredentials.Copy();
            var table = new Hashtable() { { creds.Id, creds } };
            Soap.Serialize(Stream, table);
            Stream.Close();
            creds.Username = TestCredentials2.Username;
            _manager.UpdateCredentials(passOneUser, creds, Path);
            var expected = TestCredentials2.Username;

            Stream = new FileStream(Path + "data\\data.bin", FileMode.Open, FileAccess.Read);
            table = Soap.Deserialize(Stream) as Hashtable;
            creds = ((PassOneCredentials) table[TestPassOneCredentials.Id]);
            creds.Decrypt(passOneUser.Encryption);
            var actual = creds.Username;
            
            Assert.AreEqual(expected, actual);
        }
    }
}
