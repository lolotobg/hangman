interface IHangman
{
    int Mistakes { get; }

    bool HelpUsed { get; }

    bool GameIsOver();

    char RevealLetter();
     
    int GuessLetter(char letter);

    string GetCurrentStateOfWord();
}