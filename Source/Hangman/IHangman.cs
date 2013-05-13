interface IHangman
{
    int Mistakes { get; }

    bool HelpUsed { get; }

    bool IsOver { get; }

    char RevealLetter();
     
    int GuessLetter(char letter);

    string GetCurrentStateOfWord();

    void Reset();
}