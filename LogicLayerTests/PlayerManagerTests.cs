using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessFakes;
using DataObjects;
using DataAccessInterfaces;
using LogicLayer;

namespace LogicLayerTests
{
    [TestClass]
    public class PlayerManagerTests
    {
        private PlayerManager _playerManager = null;

        [TestInitialize]
        public void TestSetup()
        {
            _playerManager = new PlayerManager(new PlayerAccessorFake());
        }

        [TestMethod]
        public void TestRetriveDefenseReturnCorrectList()
        {
            // Arragne
            int expectedResult = 1;
            int actualResult = 0;

            // Act
            var players = _playerManager.RetrieveDefense();
            actualResult = players.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRetriveDefensiveLinemenReturnCorrectList()
        {
            // Arragne
            int expectedResult = 1;
            int actualResult = 0;

            // Act
            var players = _playerManager.RetrieveDefensiveLinemen();
            actualResult = players.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRetriveKickersReturnCorrectList()
        {
            // Arragne
            int expectedResult = 1;
            int actualResult = 0;

            // Act
            var players = _playerManager.RetrieveKickers();
            actualResult = players.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRetriveLinebackersReturnCorrectList()
        {
            // Arragne
            int expectedResult = 1;
            int actualResult = 0;

            // Act
            var players = _playerManager.RetrieveLinebackers();
            actualResult = players.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRetriveQuarterbacksReturnCorrectList()
        {
            // Arragne
            int expectedResult = 1;
            int actualResult = 0;

            // Act
            var players = _playerManager.RetrieveQuarterBacks();
            actualResult = players.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRetriveRunningbacksReturnCorrectList()
        {
            // Arragne
            int expectedResult = 1;
            int actualResult = 0;

            // Act
            var players = _playerManager.RetrieveRunningBacks();
            actualResult = players.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRetriveTideEndsReturnCorrectList()
        {
            // Arragne
            int expectedResult = 1;
            int actualResult = 0;

            // Act
            var players = _playerManager.RetrieveTideEnds();
            actualResult = players.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRetriveWideReciversReturnCorrectList()
        {
            // Arragne
            int expectedResult = 1;
            int actualResult = 0;

            // Act
            var players = _playerManager.RetrieveWideRecivers();
            actualResult = players.Count;

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
