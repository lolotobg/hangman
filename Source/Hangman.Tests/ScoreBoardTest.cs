using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman.Tests
{
    [TestClass]
    public class ScoreBoardTest
    {
        [TestMethod]
        public void TestEmptyScoreBoard()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            Assert.IsTrue(scoreBoard.IsEmpty, "true");
        }

        [TestMethod] 
        public void TestEmptyScoreBoardToString()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            var result = scoreBoard.ToString();
            Assert.AreEqual("Scoreboard is empty.\n", result);
        }

        [TestMethod]
        public void TestScoreBoardWithOneScoreToString()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddScore("Pesho", 2);
            var result = scoreBoard.ToString();
            Assert.AreEqual("1. Pesho ---> 2 mistake(s)!\n", result);
        }

        [TestMethod]
        public void TestScoreBoardWithTwoScoresToString()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddScore("Pesho", 2);
            scoreBoard.AddScore("Pesho", 0);
            var result = scoreBoard.ToString();
            Assert.AreEqual("1. Pesho ---> 0 mistake(s)!\n"+
            "2. Pesho ---> 2 mistake(s)!\n", result);
        }

        [TestMethod]
        public void TestScoreBoardWithFiveScoresToString()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.AddScore("Pesho", 2);
            scoreBoard.AddScore("Pesho", 0);
            scoreBoard.AddScore("Asya", 1);
            scoreBoard.AddScore("Gergana",0);
            scoreBoard.AddScore("Ivan", 5);
            var result = scoreBoard.ToString();
            Assert.AreEqual("1. Gergana ---> 0 mistake(s)!\n" +
            "2. Pesho ---> 0 mistake(s)!\n"+
            "3. Asya ---> 1 mistake(s)!\n"+
            "4. Pesho ---> 2 mistake(s)!\n"+
            "5. Ivan ---> 5 mistake(s)!\n", result); 
        }

    }
}
