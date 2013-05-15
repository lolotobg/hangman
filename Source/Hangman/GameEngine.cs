using System;

namespace HangmanGame
{
    public class GameEngine
    {
        private ScoreBoard scoreBoard;
        private IHangman game;
        private string command;
        private readonly Random randomGenerator = new Random();
        private readonly string[] words = { "computer", "programmer", "software", "debugger", "compiler", 
                                          "developer", "algorithm", "array", "method", "variable" };

        private string GetRandomWord()
        {
            int choice = this.randomGenerator.Next(words.Length);
            return words[choice];
        }

        public GameEngine()
        {
            this.scoreBoard = new ScoreBoard();
            string word = this.GetRandomWord();
            this.game = new Hangman(word);
            Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");
            this.command = null;
        }

        public void CheckScoreHasMadeScoreBoard()
        {
            if (this.scoreBoard.GetWorstTopScore() <= this.game.Mistakes)
            {
                Console.WriteLine("You won with {0} mistake(s) but you score did not enter in the scoreboard",
                    this.game.Mistakes);
            }
            else
            {
                Console.Write("Please enter your name for the top scoreboard: ");
                string name = Console.ReadLine();
                this.scoreBoard.AddScore(name, this.game.Mistakes);
                Console.WriteLine(this.scoreBoard.ToString());
            }
        }

        public string ExecuteCommand(string command)
        {
            string resultStringOfExecution = "Incorrect guess or command!";
            switch (command)
            {
                case "top":
                    resultStringOfExecution = this.scoreBoard.ToString();
                    break;
                case "help":
                    char revealedLetter = this.game.RevealLetter();
                    resultStringOfExecution = string.Format("OK, I reveal for you the next letter '{0}'.", revealedLetter);
                    break;
                case "restart":
                    this.scoreBoard.Reset();
                    resultStringOfExecution = "\nWelcome to “Hangman” game. Please try to guess my secret word.";
                    string word = this.GetRandomWord();
                    this.game = new Hangman(word);
                    break;
                case "exit":
                    resultStringOfExecution = "Good bye!";
                    break;
            }
            return resultStringOfExecution;
        }

        public void HandleUserGuessInput(char guess)
        {
            int occuranses = this.game.GuessLetter(guess);
            //TODO: if input is not in english must handle with a differrent message than the ones bellow
            if (occuranses == 0)
            {
                Console.WriteLine("Sorry! There are no unrevealed letters “{0}”.", guess);
            }
            else
            {
                Console.WriteLine("Good job! You revealed {0} letter(s).", occuranses);
            }
        }

        public void HandleInput()
        {
            Console.Write("Enter your guess: ");
            this.command = Console.ReadLine();
            this.command.ToLower();
            if (this.command.Length == 1)
            {
                this.HandleUserGuessInput(command[0]);
            }
            else
            {
                Console.WriteLine(this.ExecuteCommand(command));
            }
        }

        public void GameLoop()
        {
            do
            {
                Console.WriteLine();
                Console.Write("The secret word is: ");
                string currentState = this.game.GetCurrentStateOfWord();
                Console.WriteLine(currentState);
                Console.WriteLine();
                if (this.game.IsOver())
                {
                    if (this.game.HelpUsed)
                    {
                        Console.WriteLine("You won with {0} mistake(s) but you have cheated." +
                            " You are not allowed to enter into the scoreboard.", this.game.Mistakes);
                    }
                    else
                    {
                        this.CheckScoreHasMadeScoreBoard();
                    }
                    string word = this.GetRandomWord();
                    this.game = new Hangman(word);
                }
                else
                {
                    this.HandleInput();
                }
            } while (this.command != "exit");
        }
    }
}