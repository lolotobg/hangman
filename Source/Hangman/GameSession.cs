using System;

class GameSession
{
    static ScoreBoard scoreBoard;
    static Hangman game;
    static string command;

    static void Initialize()
    {
        scoreBoard = new ScoreBoard();
        game = new Hangman();
        Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");
        command = null;
    }

    private static void CheckScoreHasMadeScoreBoard()
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
            scoreBoard.AddNewScore(name, game.Mistakes);
            Console.WriteLine(scoreBoard.ToString());
        }
    }

    static void ExecuteCommand(string command, ScoreBoard scoreBoard, Hangman game)
    {
        switch (command)
        {
            case "top":
                {
                    Console.WriteLine(scoreBoard.ToString());
                }
                break;
            case "help":
                {
                    char revealedLetter = game.RevealLetter();
                    Console.WriteLine("OK, I reveal for you the next letter '{0}'.", revealedLetter);
                }
                break;
            case "restart":
                {
                    scoreBoard.Reset();
                    Console.WriteLine("\nWelcome to “Hangman” game. Please try to guess my secret word.");
                    game = new Hangman();
                }
                break;
            case "exit":
                {
                    Console.WriteLine("Good bye!");
                    return;
                } break;
            default:
                {
                    Console.WriteLine("Incorrect guess or command!");
                }
                break;
        }
    }

    private static void HandleUserGuessInput()
    {
        int occuranses = game.GuessLetter(command[0]);
        //TODO: if input is not in english must handle with a differrent message than the ones bellow
        if (occuranses == 0)
        {
            Console.WriteLine("Sorry! There are no unrevealed letters “{0}”.", command[0]);
        }
        else
        {
            Console.WriteLine("Good job! You revealed {0} letter(s).", occuranses);
        }
    }

    private static void HandleInput()
    {
        Console.Write("Enter your guess: ");
        command = Console.ReadLine();
        command.ToLower();
        if (command.Length == 1)
        {
            HandleUserGuessInput();
        }
        else
        {
            ExecuteCommand(command, scoreBoard, game);
        }
    }

    private static void GameLoop()
    {
        do
        {
            Console.WriteLine();
            Console.Write("The secret word is: ");
            string currentState = game.GetCurrentStateOfWord();
            Console.WriteLine(currentState);
            Console.WriteLine();
            if (game.CheckGameIsOver())
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
                game = new Hangman();
            }
            else
            {
                HandleInput();
            }
        } while (command != "exit");
    }

    static void Main()
    {
        Initialize();
        GameLoop();
    }
}