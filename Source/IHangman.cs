interface IHangman
{
    int Mistakes { get; }

    bool HelpUsed { get; }

    bool IsOver { get; }

    void Reset();

    char RevealLetter();
     
    int GuessLetter(char letter);

    string GetCurrentProgress();    
}