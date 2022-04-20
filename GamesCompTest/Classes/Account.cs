using Microsoft.VisualStudio.TestTools.UnitTesting;
using GamesCompLogic.Containers;
using GamesCompLogic.Classes;
using System.Linq;
using System;
using System.Collections.Generic;

namespace GamesCompTest
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void CreateAccount()
        {
            //arrange
            var Name = "User1";
            var AccountId = 1;
            var Password = "Wachtwoord";
            var Email = "Mymail@gmail.com";
            var IsAdmin = false;
            //act
            var account = new Account(AccountId, Name, Password, Email, IsAdmin);
            //assert
            Assert.AreEqual(account.Name, Name, "Names do not match");
            Assert.AreEqual(account.AccountId, AccountId, "Id's do not match");
            Assert.AreEqual(account.Password, Password, "Passwords do not match");
            Assert.AreEqual(account.Email, Email, "Emails do not match");
            Assert.AreEqual(account.IsAdmin, IsAdmin, "IsAdmin does not match");
        }
    }
}
