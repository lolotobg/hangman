interface IScoreBoard
{
    bool AddScore(string name, int mistakesCount);

    void Reset();

    string ToString();
}