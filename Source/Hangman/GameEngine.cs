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
            int choice = randomGenerator.Next(words.Length);
            return words[choice];
        }

        public GameEngine()
        {
            scoreBoard = new ScoreBoard();
            string word = this.GetRandomWord();
            game = new Hangman(word);
            Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");
            command = null;
        }

        public void CheckScoreHasMadeScoreBoard()
        {
            if (scoreBoard.GetWorstTopScore() <= game.Mistakes)
            {
                Console.WriteLine("You won with {0} mistake(s) but you score did not enter in the scoreboard",
                    game.Mistakes);
            }
            else
            {
                Console.Write("Please enter your name for the top scoreboard: ");
                string name = Console.ReadLine();
                scoreBoard.AddScore(name, game.Mistakes);
                Console.WriteLine(scoreBoard.ToString());
            }
        }

        public string ExecuteCommand(string command, ScoreBoard scoreBoard, IHangman game)
        {
            string resultStringOfExecution = "Incorrect guess or command!";
            switch (command)
            {
                case "top":
                    resultStringOfExecution = scoreBoard.ToString();
                    break;
                case "help":
                    char revealedLetter = game.RevealLetter();
                    resultStringOfExecution = string.Format("OK, I reveal for you the next letter '{0}'.", revealedLetter);
                    break;
                case "restart":
                    scoreBoard.Reset();
                    resultStringOfExecution = "\nWelcome to “Hangman” game. Please try to guess my secret word.";
                    string word = GetRandomWord();
                    game = new Hangman(word);
                    break;
                case "exit":
                    resultStringOfExecution = "Good bye!";
                    break;
            }
            return resultStringOfExecution;
        }

        public void HandleUserGuessInput(char guess)
        {
            int occuranses = game.GuessLetter(guess);
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
            command = Console.ReadLine();
            command.ToLower();
            if (command.Length == 1)
            {
                HandleUserGuessInput(command[0]);
            }
            else
            {
                this.ExecuteCommand(command, scoreBoard, game);
            }
        }

        public void GameLoop()
        {
            do
            {
                Console.WriteLine();
                Console.Write("The secret word is: ");
                string currentState = game.GetCurrentStateOfWord();
                Console.WriteLine(currentState);
                Console.WriteLine();
                if (game.IsOver())
                {
                    if (game.HelpUsed)
                    {
                        Console.WriteLine("You won with {0} mistake(s) but you have cheated." +
                            " You are not allowed to enter into the scoreboard.", game.Mistakes);
                    }
                    else
                    {
                        CheckScoreHasMadeScoreBoard();
                    }
                    string word = GetRandomWord();
                    game = new Hangman(word);
                }
                else
                {
                    HandleInput();
                }
            } while (command != "exit");
        }
    }
}