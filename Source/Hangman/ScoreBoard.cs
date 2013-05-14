using System;
using System.Text;
using System.Collections.Generic;

public class ScoreBoard: IScoreBoard
{
    public const int MaxScoresCount = 5;
    private readonly string[] topPlayers = new string[MaxScoresCount];
    private readonly int[] mistakes = new int[MaxScoresCount];
    private bool isEmpty;

    private List<ScoreEntry> highScores = new List<ScoreEntry>();

    public ScoreBoard() 
    {
        for (int i = 0; i < topPlayers.Length; i++)
        {
            topPlayers[i] = null;
            mistakes[i] = int.MaxValue;
        }
        isEmpty = true;
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
            for (int i = 0; i < highScores.Count; i++)
            {
                if (highScores[i] != null)
                {
                    sb.AppendFormat("{0}. {1} ---> {2} mistake(s)!", i + 1, highScores[i].Name, highScores[i].MistakesCount);
                    sb.AppendLine();
                }
            }
        }
        return sb.ToString();
    }

    public void AddScore(string name, int mistakesCount)
    {
        ScoreEntry newScore = new ScoreEntry(name, mistakesCount);

        if (highScores.Count < 5)
        {
            highScores.Add(newScore);
            highScores.Sort();
            isEmpty = false;
        }
        else
        {
            for (int i = 0; i < highScores.Count; i++)
            {
                if (newScore.MistakesCount<highScores[i].MistakesCount)
                {
                    highScores.RemoveAt(highScores.Count-1);
                    highScores.Add(newScore);
                    highScores.Sort();
                    break;
                }
            }
        }
    }

    public int GetWorstTopScore()
    {
        int worstTopScore = int.MaxValue;
        if (topPlayers[topPlayers.Length - 1] != null) 
        { 
            worstTopScore = mistakes[topPlayers.Length - 1]; 
        }
        return worstTopScore;
    }

    public void Reset() 
    {
        highScores.Clear();
        isEmpty = true;
    }
}
