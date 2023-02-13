using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessFakes;
using DataObjects;

namespace LogicLayerTests
{
    [TestClass]
    public class UserManagerTests
    {
        IUserManager userManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            userManager = new UserManager(new UserAccessorFake());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHashSHA256ThrowsExceptionForEmptyString()
        {
            // Arrange
            const string source = "";

            // Act
            userManager.HashSha256(source);

            // Assert
        }

        [TestMethod]
        public void TestHashSHA256ReturnsCorrectHash()
        {
            // Arrange
            const string source = "newuser";
            const string expectedResult =
                "9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e";
            string actualResult = "";

            // Act
            actualResult = userManager.HashSha256(source);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestLoginUserPassesWithCorrectEmailAndPassword()
        {
            // Arragne
            const string email = "tess@fbfl.com";
            const string password = "newuser";
            int expectedResult = 999999;
            int actualResult = 0;

            // Act
            User testUser = userManager.LoginUser(email, password);
            actualResult = testUser.MemberID;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestLoginUserFailsWithBadEmail()
        {
            // Arragne
            const string email = "bad-tess@fbfl.com";
            const string password = "newuser";

            // Act
            User testUser = userManager.LoginUser(email, password);

            // Assert
        }
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestLoginUserFailsWithBadPassword()
        {
            // Arragne
            const string email = "tess@fbfl.com";
            const string password = "bad-newuser";

            // Act
            User testUser = userManager.LoginUser(email, password);

            // Assert
        }
    }
}
