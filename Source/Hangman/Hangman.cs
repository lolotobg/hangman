using System;
using System.Text;

namespace HangmanGame
{
    public class Hangman : IHangman
    {
        private string wordToGuess;
        private readonly char[] guessedLetters;
        private int mistakes;
        private bool helpUsed;

        private string Word
        {
            set
            {
                if(String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("word", "Word cannot be null, empty or whitespace only!");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("word", "Word cannot shorter than 5 symbols!");
                }

                this.wordToGuess = value;
            }
        }

        public Hangman(string word)
        {
            this.Word = word;

            this.guessedLetters = new char[wordToGuess.Length];

            for (int i = 0; i < this.wordToGuess.Length; i++)
            {
                this.guessedLetters[i] = '_';
            }

            this.mistakes = 0;
            this.helpUsed = false;
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
            bool gameIsOver = IsOver();
            if (gameIsOver)
            {
                string error = "The game is over - there are no more letter to reveal!";
                string hint = "Check if game is over with IsOver() method before calling RevealLeter()";
                throw new ApplicationException(error + hint);
            }

            char letterToReveal = GetLetterToReveal();
            this.helpUsed = true;

            for (int i = 0; i < this.guessedLetters.Length; i++)
            {
                if (this.wordToGuess[i] == letterToReveal)
                {
                    this.guessedLetters[i] = letterToReveal;
                }
            }

            return letterToReveal;
        }

        private char GetLetterToReveal()
        {
            for (int i = 0; i < this.guessedLetters.Length; i++)
            {
                if (this.guessedLetters[i] == '_')
                {
                    return (this.wordToGuess[i]);
                }
            }

            throw new ApplicationException("No letters to reveal");
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
    }
}