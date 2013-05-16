using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using System.Reflection;
using HangmanGame;
using System.IO;

[TestClass]
public class GameEngineTests
{
    [TestMethod]
    public void CheckScoreHasMadeScoreBoardNotEnoughScores()
    {
        //Arrange
        GameEngine gameEngine = new GameEngine();
        ScoreBoard customScoreBoard = new ScoreBoard();
        customScoreBoard.AddScore("pesho", 50);
        customScoreBoard.AddScore("pesho", 50);
        customScoreBoard.AddScore("pesho", 50);
        customScoreBoard.AddScore("pesho", 50);
        customScoreBoard.AddScore("pesho", 50);
        customScoreBoard.AddScore("pesho", 50);
        customScoreBoard.AddScore("pesho", 50);
        customScoreBoard.AddScore("pesho", 50);

        Type type = typeof(GameEngine);
        var fieldValue = type.GetField("scoreBoard", BindingFlags.Instance | BindingFlags.NonPublic);

        //var mockedScoreBoard = Mock.Create<IScoreBoard>();
        //Telerik.JustMock.Mock.Arrange(() => mockedScoreBoard.CheckScoreIsHighscore(5)).Returns(false);

        fieldValue.SetValue(gameEngine, customScoreBoard);

        //Act
        string actual = gameEngine.CheckScoreHasMadeScoreBoard(88);
        string expected = "You won with 88 mistake(s) but you score did not enter in the scoreboard\n" +
        "1. pesho ---> 50 mistake(s)!\n" +
        "2. pesho ---> 50 mistake(s)!\n" +
        "3. pesho ---> 50 mistake(s)!\n" +
        "4. pesho ---> 50 mistake(s)!\n" +
        "5. pesho ---> 50 mistake(s)!\n";

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void CheckScoreHasMadeScoreBoardEnoughScores()
    {
        GameEngine gameEngine = new GameEngine();
        //Arrange console in
        string input = "myName\r\n";
        string expectedConsoleOut = "Please enter your name for the top scoreboard: ";
        string actual = null;
        string expected = "\n1. myName ---> 4 mistake(s)!\n";
        string consoleOut = null;
        StringWriter sw = new StringWriter();
        StringReader sr = new StringReader(input);
        //Act
        try
        {
            Console.SetIn(sr);
            Console.SetOut(sw);
            actual = gameEngine.CheckScoreHasMadeScoreBoard(4);
            consoleOut = sw.ToString();
        }
        finally
        {
            sw.Dispose();
            sr.Dispose();
        }
        //Assert
        Assert.AreEqual(expectedConsoleOut, consoleOut);
        Assert.AreEqual(expected, actual);
    }
}