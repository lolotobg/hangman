using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;


[TestClass]
public class HangmanTests
{
    [TestMethod]
    public void TestFourRevealLetterCommands()
    {
        Random fixedGenerator = new Random(5);
        Hangman game = new Hangman();

        Type type =  typeof(Hangman);
        var fieldValue = type.GetField("randomGenerator", BindingFlags.Instance | BindingFlags.NonPublic);
        fieldValue.SetValue(game, fixedGenerator);

        game.Reset();
        game.RevealLetter();
        game.RevealLetter();
        game.RevealLetter();
        game.RevealLetter();
        string actual = game.GetCurrentStateOfWord();
        string expected = "d e b u _ _ _ _ ";

        Assert.AreEqual(expected, actual);
    }
}