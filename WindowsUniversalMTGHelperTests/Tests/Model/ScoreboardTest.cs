using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using WindowsUniversalMTGHelper.Model;

namespace WindowsUniversalMTGHelperTests.Tests.Model
{
    [TestClass]
    public class ScoreboardTest
    {
        [TestMethod]
        public void TestDadoUnScoreboardRecienCreadoCuandoLePreguntoCuantosPlayerScoreboardTieneResponde0()
        {
            Scoreboard sut = new Scoreboard();
            Assert.AreEqual(0, sut.numberOfScoreboardsCreated());
        }

        [TestMethod]
        public void TestDadoUnScoreboardRecienCreadoAlCualLeAgregoUnPlayerScoreboardCuandoLePreguntoCuantosPlayerScoreboardsTieneResponde1()
        {
            Scoreboard sut = new Scoreboard();
            sut.addAPlayerScoreboard();
            Assert.AreEqual(1, sut.numberOfScoreboardsCreated());
        }

        [TestMethod]
        public void TestDadoUnScoreboardConUnPlayerScoreboardAlQueLeEliminoDichoPlayerScoreboardCuandoLePreguntoCuantosPlayerScoreboardsTieneResponde0()
        {
            Scoreboard sut = new Scoreboard();
            PlayerScoreboard pScoreboard = sut.addAPlayerScoreboard();
            sut.removeplayerScoreboard(pScoreboard);
            Assert.AreEqual(0, sut.numberOfScoreboardsCreated());
        }
    }
}
