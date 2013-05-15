using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanGame;

[TestClass]
public class HangmanTests
{
    [TestMethod]
    public void TestFourRevealLetterCommands()
    {
        Random fixedGenerator = new Random(5);
        Hangman game = new Hangman();

        Type type = typeof(Hangman);
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

    [TestMethod]
    public void TestRevealLetterCommandAfterSuccessiveLetterGuess()
    {
        Random fixedGenerator = new Random(5);
        Hangman game = new Hangman();

        Type type = typeof(Hangman);
        var fieldValue = type.GetField("randomGenerator", BindingFlags.Instance | BindingFlags.NonPublic);
        fieldValue.SetValue(game, fixedGenerator);

        game.Reset();
        game.GuessLetter('d');
        game.RevealLetter();

        string actual = game.GetCurrentStateOfWord();
        string expected = "d e _ _ _ _ _ _ ";

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestGuessLetterCommandExistingLetter()
    {
        Random fixedGenerator = new Random(5);
        Hangman game = new Hangman();

        Type type = typeof(Hangman);
        var fieldValue = type.GetField("randomGenerator", BindingFlags.Instance | BindingFlags.NonPublic);
        fieldValue.SetValue(game, fixedGenerator);

        game.Reset();
        int guessedLetters = game.GuessLetter('e');
        string actual = game.GetCurrentStateOfWord();
        string expected = "_ e _ _ _ _ e _ ";

        Assert.AreEqual(expected, actual);
        Assert.AreEqual(2, guessedLetters);
    }

    [TestMethod]
    public void TestGuessLetterCommandNonExistingLetter()
    {
        Random fixedGenerator = new Random(5);
        Hangman game = new Hangman();

        Type type = typeof(Hangman);
        var fieldValue = type.GetField("randomGenerator", BindingFlags.Instance | BindingFlags.NonPublic);
        fieldValue.SetValue(game, fixedGenerator);

        game.Reset();
        int guessedLetters = game.GuessLetter('a');
        int misstakes = game.Mistakes;
        string actual = game.GetCurrentStateOfWord();
        string expected = "_ _ _ _ _ _ _ _ ";

        Assert.AreEqual(expected, actual);
        Assert.AreEqual(0, guessedLetters);
        Assert.AreEqual(1, misstakes);
    }

    [TestMethod]
    public void TestGuessAllLetters()
    {
        Random fixedGenerator = new Random(5);
        Hangman game = new Hangman();

        Type type = typeof(Hangman);
        var fieldValue = type.GetField("randomGenerator", BindingFlags.Instance | BindingFlags.NonPublic);
        fieldValue.SetValue(game, fixedGenerator);

        game.Reset();
        game.GuessLetter('d');
        game.GuessLetter('e');
        game.GuessLetter('b');
        game.GuessLetter('u');
        game.GuessLetter('g');
        game.GuessLetter('r');

        bool isGameOve = game.IsOver();
        string actual = game.GetCurrentStateOfWord();
        string expected = "d e b u g g e r ";

        Assert.AreEqual(expected, actual);
        Assert.IsTrue(isGameOve);
    }

    [TestMethod]
    public void TestIsOverBeforeGameOver()
    {
        Random fixedGenerator = new Random(5);
        Hangman game = new Hangman();

        Type type = typeof(Hangman);
        var fieldValue = type.GetField("randomGenerator", BindingFlags.Instance | BindingFlags.NonPublic);
        fieldValue.SetValue(game, fixedGenerator);

        game.Reset();
        game.GuessLetter('d');
        game.GuessLetter('e');
        game.GuessLetter('b');

        bool isGameOve = game.IsOver();

        Assert.IsFalse(isGameOve);
    }

    [TestMethod]
    public void TestHelpUsedTrue()
    {
        Hangman game = new Hangman();

        game.GuessLetter('f');
        game.RevealLetter();

        bool helpUsed = game.HelpUsed;

        Assert.IsTrue(helpUsed);
    }

    [TestMethod]
    public void TestHelpUsedFalse()
    {
        Hangman game = new Hangman();

        game.GuessLetter('f');

        bool helpUsed = game.HelpUsed;

        Assert.IsFalse(helpUsed);
    }
}