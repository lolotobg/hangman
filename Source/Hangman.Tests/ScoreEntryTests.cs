using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanGame;

[TestClass]
public class ScoreEntryTests
{
    [TestMethod]
    public void TestCompareToSameNamesDifferentMistakesCount()
    {
        ScoreEntry newScoreEntry = new ScoreEntry("Pesho", 2);
        ScoreEntry other = new ScoreEntry("Pesho", 1);
        var result = newScoreEntry.MistakesCount.CompareTo(other.MistakesCount);
        var condition = newScoreEntry.MistakesCount - other.MistakesCount;
        Assert.AreEqual(condition, result);
    }

    [TestMethod]
    public void TestCompareToSameMistakesCountDifferentNames()
    {
        ScoreEntry newScoreEntry = new ScoreEntry("Asya", 2);
        ScoreEntry other = new ScoreEntry("Pesho", 2);
        var result = newScoreEntry.Name.CompareTo(other.Name);
        Assert.AreEqual(-1, result);
    }
}

