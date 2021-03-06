﻿using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanGame;

[TestClass]
public class HangmanTests
{
    [TestMethod]
    public void TestFourRevealLetterCommands()
    {
        Hangman game = new Hangman("debugger");

        game.RevealLetter();
        game.RevealLetter();
        game.RevealLetter();
        game.RevealLetter();
        string actual = game.GetCurrentStateOfWord();
        string expected = "d e b u _ _ e _ ";

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestRevealLetterOneOccurance()
    {
        Hangman game = new Hangman("methanol");

        game.RevealLetter();
        string actual = game.GetCurrentStateOfWord();
        string expected = "m _ _ _ _ _ _ _ ";

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestRevealLetterMoreOccurances()
    {
        Hangman game = new Hangman("memanol");

        game.RevealLetter();
        string actual = game.GetCurrentStateOfWord();
        string expected = "m _ m _ _ _ _ ";

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestRevealLetterCommandAfterSuccessiveLetterGuess()
    {
        Hangman game = new Hangman("debugger");

        game.GuessLetter('d');
        game.RevealLetter();

        string actual = game.GetCurrentStateOfWord();
        string expected = "d e _ _ _ _ e _ ";

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestGuessLetterCommandExistingLetter()
    {
        Hangman game = new Hangman("debugger");

        int guessedLetters = game.GuessLetter('e');
        string actual = game.GetCurrentStateOfWord();
        string expected = "_ e _ _ _ _ e _ ";

        Assert.AreEqual(expected, actual);
        Assert.AreEqual(2, guessedLetters);
    }

    [TestMethod]
    public void TestGuessLetterCommandNonExistingLetter()
    {
        Hangman game = new Hangman("debugger");

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
        Hangman game = new Hangman("debugger");

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
        Hangman game = new Hangman("debugger");

        game.GuessLetter('d');
        game.GuessLetter('e');
        game.GuessLetter('b');

        bool isGameOve = game.IsOver();

        Assert.IsFalse(isGameOve);
    }

    [TestMethod]
    public void TestHelpUsedTrue()
    {
        Hangman game = new Hangman("debugger");

        game.GuessLetter('f');
        game.RevealLetter();

        bool helpUsed = game.HelpUsed;

        Assert.IsTrue(helpUsed);
    }

    [TestMethod]
    public void TestHelpUsedFalse()
    {
        Hangman game = new Hangman("debugger");

        game.GuessLetter('f');

        bool helpUsed = game.HelpUsed;

        Assert.IsFalse(helpUsed);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestNullWord()
    {
        Hangman game = new Hangman(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestEmptyWord()
    {
        Hangman game = new Hangman(String.Empty);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestWhiteSpaceWord()
    {
        Hangman game = new Hangman("          ");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestWordLengthLessThanFiveSymbols()
    {
        Hangman game = new Hangman("rock");
    }

    [TestMethod]
    [ExpectedException(typeof(ApplicationException))]
    public void TestRevealLetterAfterGameIsOver()
    {
        Hangman game = new Hangman("aabbccdd");
        game.RevealLetter();
        game.RevealLetter();
        game.RevealLetter();
        game.RevealLetter();
        game.RevealLetter();
    }
}