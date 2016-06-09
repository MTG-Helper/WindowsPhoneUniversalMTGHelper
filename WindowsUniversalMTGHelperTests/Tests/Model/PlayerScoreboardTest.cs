using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using WindowsUniversalMTGHelper.Model;

namespace WindowsUniversalMTGHelperTests
{
    [TestClass]
    public class PlayerScoreboardTest
    {
        [TestMethod]
        public void TestDadoUnPlayerScoreboardCuandoLePreguntoSusPuntosDeVidaResponde20()
        {
            PlayerScoreboard sut = new PlayerScoreboard();
            Assert.AreEqual(20, sut.getLifePoints());
        }

        [TestMethod]
        public void TestDadoUnPlayerScoreboardCon20PuntosDeVidaYLeSumoUnaVidaCuandoLePreguntoSusPuntosDeVidaREsponde21()
        {
            PlayerScoreboard sut = new PlayerScoreboard();
            sut.addOneLifePoints();
            Assert.AreEqual(21, sut.getLifePoints());
        }

        [TestMethod]
        public void TestDadoUnPlayerScoreboardCon20PuntosDeVidaYLeRestoUnaVidaCuandoLePreguntoSusPuntosDeVidaREsponde19()
        {
            PlayerScoreboard sut = new PlayerScoreboard();
            sut.subOneLifePoints();
            Assert.AreEqual(19, sut.getLifePoints());
        }

        [TestMethod]
        public void TestDadoUnPlayerScoreboardCon20PuntosDeVidaYLeSumo5PuntosDeVidaCuandoLePreguntoSusPuntosDeVidaREsponde25()
        {
            PlayerScoreboard sut = new PlayerScoreboard();
            sut.addFiveLifePoints();
            Assert.AreEqual(25, sut.getLifePoints());
        }

        [TestMethod]
        public void TestDadoUnPlayerScoreboardCon20PuntosDeVidaYLeResto5PuntosDeVidaCuandoLePreguntoSusPuntosDeVidaREsponde25()
        {
            PlayerScoreboard sut = new PlayerScoreboard();
            sut.subFiveLifePoints();
            Assert.AreEqual(15, sut.getLifePoints());
        }

        [TestMethod]
        public void TestDadoUnPlayerScoreboardCon0PuntosDeVenenoCuandoLePreguntoSusPuntosDeVidaResponde0()
        {
            PlayerScoreboard sut = new PlayerScoreboard();
            Assert.AreEqual(0, sut.getPoisonPoints());
        }

        [TestMethod]
        public void TestDadoUnPlayerScoreboardCon0PuntosDeVenenoYLeSumoUnPuntoDeVenenoCuandoLePreguntoSusPuntosDeVidaResponde1()
        {
            PlayerScoreboard sut = new PlayerScoreboard();
            sut.addOnePoisonPoint();
            Assert.AreEqual(1, sut.getPoisonPoints());
        }

        [TestMethod]
        public void TestDadoUnPlayerScoreboardCon0PuntosDeVenenoYLeRestoUnPuntoDeVenenoCuandoLePreguntoSusPuntosDeVidaResponde0()
        {
            PlayerScoreboard sut = new PlayerScoreboard();
            sut.subOnePoisonPoint();
            Assert.AreEqual(0, sut.getPoisonPoints());
        }

        [TestMethod]
        public void TestDadoUnPlayerScoreboardConPlayerNameFooCuandoLePreguntoPorSuPlayerNameRespondeFoo()
        {
            PlayerScoreboard sut = new PlayerScoreboard();
            Assert.AreEqual("Foo", sut.getPlayerName());
        }

        [TestMethod]
        public void TestDadoUnPlayerScoreboardConPlayerNameAlQueLeCambioElNombrePorPepeCuandoLePreguntoPorSuPlayerNameRespondeFoo()
        {
            PlayerScoreboard sut = new PlayerScoreboard();
            sut.changeName("Pepe");
            Assert.AreEqual("Pepe", sut.getPlayerName());
        }


    }
}
