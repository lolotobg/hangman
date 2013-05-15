namespace HangmanGame
{
    interface IScoreBoard
    {
        void AddScore(string name, int mistakesCount);

        void Reset();

        string ToString();
    }
}