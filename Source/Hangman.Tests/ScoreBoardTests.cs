using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanGame;

[TestClass]
public class ScoreBoardTest
{
    [TestMethod]
    public void TestIsEmpty()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        Assert.IsTrue(scoreBoard.IsEmpty, "true");
    }

    [TestMethod]
    public void TestToStringWithEmptyScoreBoard()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        var result = scoreBoard.ToString();
        Assert.AreEqual("Scoreboard is empty.\n", result);
    }

    [TestMethod]
    public void TestToStringWithOneScore()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        scoreBoard.AddScore("Pesho", 2);
        var result = scoreBoard.ToString();
        Assert.AreEqual("1. Pesho ---> 2 mistake(s)!\n", result);
    }

    [TestMethod]
    public void TestToStringWithTwoScores()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        scoreBoard.AddScore("Pesho", 2);
        scoreBoard.AddScore("Pesho", 0);
        var result = scoreBoard.ToString();
        Assert.AreEqual("1. Pesho ---> 0 mistake(s)!\n"+
        "2. Pesho ---> 2 mistake(s)!\n", result);
    }

    [TestMethod]
    public void TestToStringWithFiveScores()
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

    [TestMethod]
    public void TestAddScoreWithSevenScoresLastAreBetter()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        scoreBoard.AddScore("Pesho", 100);
        scoreBoard.AddScore("Pesho", 50);
        scoreBoard.AddScore("Asya", 150);
        scoreBoard.AddScore("Gergana", 20);
        scoreBoard.AddScore("Ivan", 300);
        scoreBoard.AddScore("Petkan", 4);
        scoreBoard.AddScore("Stoyan", 2);

        string actual = scoreBoard.ToString();
        string expected = "1. Stoyan ---> 2 mistake(s)!\n" +
        "2. Petkan ---> 4 mistake(s)!\n" +
        "3. Gergana ---> 20 mistake(s)!\n" +
        "4. Pesho ---> 50 mistake(s)!\n" +
        "5. Pesho ---> 100 mistake(s)!\n";
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestAddScoreWithSevenScoresLastAreWorse()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        scoreBoard.AddScore("Pesho", 100);
        scoreBoard.AddScore("Pesho", 50);
        scoreBoard.AddScore("Asya", 150);
        scoreBoard.AddScore("Gergana", 20);
        scoreBoard.AddScore("Ivan", 300);
        scoreBoard.AddScore("Petkan", 4);
        scoreBoard.AddScore("Stoyan", 11111);

        string actual = scoreBoard.ToString();
        string expected = "1. Petkan ---> 4 mistake(s)!\n" +
        "2. Gergana ---> 20 mistake(s)!\n" +
        "3. Pesho ---> 50 mistake(s)!\n" +
        "4. Pesho ---> 100 mistake(s)!\n" +
        "5. Asya ---> 150 mistake(s)!\n";
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestReset()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        scoreBoard.AddScore("Pesho", 2);
        scoreBoard.AddScore("Pesho", 0);
        scoreBoard.AddScore("Asya", 1);
        scoreBoard.AddScore("Gergana", 0);
        scoreBoard.AddScore("Ivan", 5);
        scoreBoard.Reset();
        bool result = scoreBoard.IsEmpty;
        Assert.AreEqual(result, true);
    }

    [TestMethod]

    public void TestCheckScoreIsHighscoreWithThreeScores()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        List<ScoreEntry> highScores = new List<ScoreEntry>();
        highScores.Add(new ScoreEntry("Pesho", 2));
        highScores.Add(new ScoreEntry("Pesho", 0));
        highScores.Add(new ScoreEntry("Pesho", 1));

        bool result = scoreBoard.CheckScoreIsHighscore(0);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestCheckScoreIsHighscoreWithSixHighscores()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        List<ScoreEntry> highScores = new List<ScoreEntry>();
        highScores.Add(new ScoreEntry("Pesho", 2));
        highScores.Add(new ScoreEntry("Pesho", 0));
        highScores.Add(new ScoreEntry("Pesho", 1));
        highScores.Add(new ScoreEntry("Pesho", 1));
        highScores.Add(new ScoreEntry("Pesho", 1));
        highScores.Add(new ScoreEntry("Pesho", 1));
     
        bool result = scoreBoard.CheckScoreIsHighscore(0);
        Assert.IsTrue(result);
    }

    public void TestCheckScoreIsHighscoreWithMoreThanFiveRecordsAndCheckBetter()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        scoreBoard.AddScore("Pesho", 2);
        scoreBoard.AddScore("Pesho", 0);
        scoreBoard.AddScore("Asya", 1);
        scoreBoard.AddScore("Gergana", 0);
        scoreBoard.AddScore("Ivan", 5);
        bool isHighscore = scoreBoard.CheckScoreIsHighscore(4);
        Assert.IsTrue(isHighscore);
    }

    [TestMethod]
    public void TestCheckScoreIsHighscoreWithMoreThanFiveRecordsAndCheckTheSame()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        scoreBoard.AddScore("Pesho", 2);
        scoreBoard.AddScore("Pesho", 0);
        scoreBoard.AddScore("Asya", 1);
        scoreBoard.AddScore("Gergana", 0);
        scoreBoard.AddScore("Ivan", 5);
        bool isHighscore = scoreBoard.CheckScoreIsHighscore(5);
        Assert.IsFalse(isHighscore);
    }

    [TestMethod]
    public void TestCheckScoreIsHighscoreWithMoreThanFiveRecordsAndCheckWorse()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        scoreBoard.AddScore("Pesho", 2);
        scoreBoard.AddScore("Pesho", 0);
        scoreBoard.AddScore("Asya", 1);
        scoreBoard.AddScore("Gergana", 0);
        scoreBoard.AddScore("Ivan", 5);
        bool isHighscore = scoreBoard.CheckScoreIsHighscore(6);
        Assert.IsFalse(isHighscore);
    }

    [TestMethod]
    public void TestCheckScoreIsHighscoreWithLessThanFiveRecordsAndCheckBetter()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        scoreBoard.AddScore("Pesho", 2);
        scoreBoard.AddScore("Pesho", 0);
        scoreBoard.AddScore("Ivan", 5);
        bool isHighscore = scoreBoard.CheckScoreIsHighscore(4);
        Assert.IsTrue(isHighscore);
    }

    [TestMethod]
    public void TestCheckScoreIsHighscoreWithLessThanFiveRecordsAndCheckWorse()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        scoreBoard.AddScore("Pesho", 2);
        scoreBoard.AddScore("Pesho", 0);
        scoreBoard.AddScore("Ivan", 5);
        bool isHighscore = scoreBoard.CheckScoreIsHighscore(6);
        Assert.IsTrue(isHighscore);
    }

    [TestMethod]
    public void TestCheckScoreIsHighscoreWithZeroRecords()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        bool isHighscore = scoreBoard.CheckScoreIsHighscore(6);
        Assert.IsTrue(isHighscore);
    }

    [TestMethod]
    public void TestCheckScoreIsHighscoreWithAllPerfectScores()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        scoreBoard.AddScore("Pesho", 0);
        scoreBoard.AddScore("Pesho", 0);
        scoreBoard.AddScore("Asya", 0);
        scoreBoard.AddScore("Gergana", 0);
        scoreBoard.AddScore("Ivan", 0);
        bool isHighscore = scoreBoard.CheckScoreIsHighscore(0);
        Assert.IsTrue(isHighscore);
    }

    [TestMethod]
    public void TestResetMethod()
    {
        ScoreBoard scoreBoard = new ScoreBoard();
        scoreBoard.AddScore("Pesho", 2);
        scoreBoard.AddScore("Pesho", 0);
        scoreBoard.AddScore("Asya", 1);
        scoreBoard.AddScore("Gergana", 0);
        scoreBoard.AddScore("Ivan", 5);
        scoreBoard.Reset();
        bool result = scoreBoard.IsEmpty;
        Assert.AreEqual(result, true);
    }
}
