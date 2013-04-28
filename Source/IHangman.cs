interface IHangman
{
    int Mistakes { get; }

    bool HelpUsed { get; }

    bool IsOver { get; }

    void Reset();

    char RevealLetter();
     
    bool GuessLetter(char letter);

    string GetCurrentProgress();    
}