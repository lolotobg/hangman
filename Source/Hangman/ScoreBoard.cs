using System;
using System.Text;
using System.Collections.Generic;

public class ScoreBoard
{
    public const int MaxScoresCount = 5;
    private readonly string[] topPlayers = new string[MaxScoresCount];
    private readonly int[] mistakes = new int[MaxScoresCount];
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

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (isEmpty)
        {
            sb.AppendLine("Scoreboard is empty.");
        }
        else
        {
            for (int i = 0; i < topPlayers.Length; i++)
            {
                if (topPlayers[i] != null)
                {
                    sb.AppendFormat("{0}. {1} ---> {2} mistake(s)!", i + 1, topPlayers[i], mistakes[i]);
                    sb.AppendLine();
                }
            }
        }
        return sb.ToString();
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
