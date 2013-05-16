namespace HangmanGame
{
    public interface IScoreBoard
    {
        void AddScore(string name, int mistakesCount);

        bool CheckScoreIsHighscore(int score);

        void Reset();

        string ToString();
    }
}