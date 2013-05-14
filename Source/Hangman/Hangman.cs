using System;
using System.Text;

public class Hangman : IHangman
{
    private string wordToGuess;
    private char[] guessedLetters;
    private int mistakes;
    private bool helpUsed;
    private readonly Random randomGenerator = new Random();
    private readonly string[] words = { "computer", "programmer", "software", "debugger", "compiler", 
                                          "developer", "algorithm", "array", "method", "variable" };

    public Hangman() 
    {
        Initialize();
    }

    public int Mistakes
    {
        get
        {
            return this.mistakes;
        }
    }

    public bool HelpUsed 
    {
        get
        {
            return this.helpUsed;
        }
    }

    public bool IsOver()
    {
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            if (guessedLetters[i] == '_')
            {
                return false;
            }
        }

        return true;
    }

    public char RevealLetter() 
    {
        char letterToReveal = char.MinValue;
        for (int i = 0; i < this.guessedLetters.Length; i++)
        {
            if (this.guessedLetters[i] == '_') 
            {
                this.guessedLetters[i] = this.wordToGuess[i];
                letterToReveal = this.wordToGuess[i];
                this.helpUsed = true;
                break;
            }
        }
        return letterToReveal;
    }

    public int GuessLetter(char letter) 
    {
        int count = 0;
        for (int i = 0; i < this.wordToGuess.Length; i++)
        {
            if (this.wordToGuess[i] == letter) 
            {
                this.guessedLetters[i] = letter;
                count++;
            }
        }

        if (count == 0)
        {
            this.mistakes++;
        }

        return count;
    }

    public string GetCurrentStateOfWord() 
    {
        StringBuilder word = new StringBuilder();
        
        for (int i = 0; i < this.guessedLetters.Length; i++)
        {
            word.Append(this.guessedLetters[i]);
            word.Append(' ');
        }

        return word.ToString();    
    }

    private void Initialize()
    {
        this.wordToGuess = GetRandomWord();
        this.guessedLetters = new char[wordToGuess.Length];

        for (int i = 0; i < this.wordToGuess.Length; i++)
        {
            this.guessedLetters[i] = '_';
        }

        this.mistakes = 0;
        this.helpUsed = false;
    }

    private string GetRandomWord()
    {
        int choice = randomGenerator.Next(words.Length);

        return words[choice];
    }

    public void Reset()
    {
        Initialize();
    }
}