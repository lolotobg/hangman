namespace HangmanGame
{
    public interface IHangman
    {
        int Mistakes { get; }

        bool HelpUsed { get; }

        bool IsOver();

        char RevealLetter();

        int GuessLetter(char letter);

        string GetCurrentStateOfWord();
    }
}