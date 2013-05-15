using System;
using System.Text;

namespace HangmanGame
{
    public class Hangman : IHangman
    {
        private string wordToGuess;
        private char[] guessedLetters;
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
    }
}