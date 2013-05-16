using System;
using System.Text;
using System.Collections.Generic;

namespace HangmanGame
{
    public class ScoreBoard : IScoreBoard
    {
        public const int MaxScoreEntries = 5;
        private readonly List<ScoreEntry> highScores;

        public ScoreBoard()
        {
            this.highScores = new List<ScoreEntry>();
        }

        public bool IsEmpty
        {
            get
            {
                return (this.highScores.Count == 0);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (IsEmpty)
            {
                sb.Append("Scoreboard is empty.\n");
            }
            else
            {
                for (int i = 0; i < highScores.Count; i++)
                {
                    if (highScores[i] != null)
                    {
                        sb.AppendFormat("{0}. {1} ---> {2} mistake(s)!\n", i + 1, highScores[i].Name, highScores[i].MistakesCount);
                    }
                }
            }
            return sb.ToString();
        }

        public void AddScore(string name, int mistakesCount)
        {
            bool scoreShouldBeAdded = CheckScoreIsHighscore(mistakesCount);

            if (scoreShouldBeAdded)
            {
                ScoreEntry newScore = new ScoreEntry(name, mistakesCount);

                highScores.Add(newScore);
                highScores.Sort();
                if (highScores.Count > MaxScoreEntries)
                {
                    highScores.RemoveAt(highScores.Count-1);
                }
            }
        }

        public bool CheckScoreIsHighscore(int mistakes)
        {
            if (this.highScores.Count < MaxScoreEntries)
            {
                return true;
            }
            else
            {
                if (mistakes < highScores[highScores.Count - 1].MistakesCount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Reset()
        {
            highScores.Clear();
        }
    }
}