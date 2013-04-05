﻿using System;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassOne.Domain;
using PassOne.Service;

namespace PassOneUnitTests.ServiceTests
{
    [TestClass]
    public class UserSoapImplSoapTests : PassOneSoapTests
    {
        private readonly ISerializeSvc _userSvc;

        public UserSoapImplSoapTests()
        {
            _userSvc = Factory.GetSoapService(Services.UserSoapSerializer, Path) as ISerializeSvc;
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


        [TestMethod]
        public void TestStoreUser()
        {
            _userSvc.UpdateTable(TestPassOneUser);
            Assert.AreEqual(TestPassOneUser, _userSvc.RetreiveById(TestPassOneUser.Id));
        }

        [TestMethod]
        public void TestStoreMultipleUsers()
        {
            _userSvc.UpdateTable(TestPassOneUser);
            _userSvc.UpdateTable(TestUser2);
            Assert.AreEqual(TestUser2, _userSvc.RetreiveById(TestUser2.Id));
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            _userSvc.UpdateTable(TestPassOneUser);
            TestPassOneUser.Password = TestUser2.Password;
            _userSvc.UpdateTable(TestPassOneUser);
            Assert.AreEqual(TestUser2.Password, ((PassOneUser)_userSvc.RetreiveById(TestPassOneUser.Id)).Password);
        }
    }
}