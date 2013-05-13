using System;

public class ScoreBoard
{
    public const int ScoresCount = 5;
    private readonly string[] topPlayers = new string[ScoresCount];
    private readonly int[] mistakes = new int[ScoresCount];
    private bool isEmpty;

    public ScoreBoard() 
    {
        for (int i = 0; i < topPlayers.Length; i++)
        {
            topPlayers[i] = null;
            mistakes[i] = int.MaxValue;
        }
        isEmpty = true;
    }

    public string[] TopPlayers
    {
        get { return this.topPlayers; }
        private set { }
    }

    public int[] Mistakes
    { 
        get { return this.mistakes; } 
        private set { }
    }

    public void Print() 
    {
        if (isEmpty)
        {
            Console.WriteLine("Scoreboard is empty!");
        }
        else 
        {
            Console.WriteLine("Scoreboard:");
          
            for (int i = 0; i < topPlayers.Length; i++)
            {
                if (topPlayers[i] != null)
                {
                    Console.WriteLine("{0}. {1} ---> {2} mistake(s)!", i + 1, topPlayers[i], mistakes[i]);
                }
            }
        }
    }

    public void AddNewScore(string name, int mistakesCount) 
    {
        int indexToPutNewScore = FindIndexWhereToPutNewScore(mistakesCount);
        if (indexToPutNewScore == topPlayers.Length)
        {
            return;
        }
        else 
        {
            MoveScoresDownByOnePosition(indexToPutNewScore);
            topPlayers[indexToPutNewScore] = name;
            mistakes[indexToPutNewScore] = mistakesCount;
            isEmpty = false;
        }
    }

    private int FindIndexWhereToPutNewScore(int mistakesCount) 
    {
        for (int i = 0; i < mistakes.Length; i++)
        {
            if (mistakesCount < mistakes[i])
            {
                return i;
            }
        }
        return topPlayers.Length;
    }

    private void MoveScoresDownByOnePosition(int startPosition) 
    {
        for (int i = topPlayers.Length - 1; i > startPosition; i--)
        {
            topPlayers[i] = topPlayers[i - 1];
            mistakes[i] = mistakes[i - 1];
        }
    }

    public int GetWorstTopScore() 
    {
        int worstTopScore = int.MaxValue;
        if (topPlayers[topPlayers.Length - 1] != null) { worstTopScore = mistakes[topPlayers.Length - 1]; }
        return worstTopScore;
    }

    public void Reset() 
    {
        for (int i = 0; i < topPlayers.Length; i++)
        {
            topPlayers[i] = null;
            mistakes[i] = 0;
        }
        isEmpty = true;
    }
}
