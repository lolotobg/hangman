using System;
using System.Text;

class Hangman
{
	// besenicata e egati tupata igra! ujasssssssssssss, spasete me ot besiloto!
    private string wordToGuess;
    private char[] guessedLetters;
    private int mistakes;
    private bool helpUsed;

    public Hangman() 
    {
        Reset();
    }

    public void Reset()
    {
        this.wordToGuess = IzberiRandomWord();
        guessedLetters = new char[wordToGuess.Length];

        for (int i = 0; i < wordToGuess.Length; i++)
        {
            guessedLetters[i] = '_';
        }

        mistakes = 0;
        helpUsed = false;
    }

    public int Mistakes
    {
        get { return this.mistakes; }
    }

    public bool HelpUsed 
    {
        get { return this.helpUsed; }
    }

    public char RevealLetter() 
    {
        char letterToReveal = char.MinValue;
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            if (guessedLetters[i] == '_') 
            {
                guessedLetters[i] = wordToGuess[i];
                letterToReveal = wordToGuess[i];
                helpUsed = true;
                break;
            }
        }
        return letterToReveal;
    }

    public int GuessLetter(char letter) 
    {
        int count = 0;
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            if (wordToGuess[i] == letter) 
            {
                guessedLetters[i] = letter;
                count++;
            }
        }
        if (count == 0) { mistakes++; }
        return count;
    }

    public string GetCurrentStateOfWord() 
    {
        StringBuilder word = new StringBuilder();
        
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            word.Append(guessedLetters[i]);
            word.Append(' ');
        }
        return word.ToString();    
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

    private string[] words = {"computer", "programmer", "software", "debugger","compiler", "developer", "algorithm",
                                      "array", "method", "variable" };

    private readonly Random randomGenerator = new Random();

    private string IzberiRandomWord()
    {
        int choice = randomGenerator.Next(words.Length);

        return words[choice];
    }
}
