using System;
using System.Text;
using System.Collections.Generic;

namespace HangmanGame
{
    public class ScoreBoard : IScoreBoard
    {
        public const int MaxScoresCount = 5;
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

            private set
            {
                throw new NotImplementedException("IsEmpty setter is no implemented!");
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
            ScoreEntry newScore = new ScoreEntry(name, mistakesCount);

            if (highScores.Count < 5)
            {
                highScores.Add(newScore);
                highScores.Sort();
            }
            else
            {
                for (int i = 0; i < highScores.Count; i++)
                {
                    if (newScore.MistakesCount < highScores[i].MistakesCount)
                    {
                        highScores.RemoveAt(highScores.Count - 1);
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
            if (highScores.Count > 0)
            {
                if (highScores[highScores.Count - 1] != null)
                {
                    worstTopScore = highScores[highScores.Count - 1].MistakesCount;
                }
            }
            return worstTopScore;
        }

        public bool CheckScoreIsHighscore(int score)
        {
            if (score < 0)
            {
                throw new ArgumentOutOfRangeException("score", "The score cannot be negative!");
            }

            if (score == 0)
            {
                return true;
            }

            if (this.highScores.Count < MaxScoresCount)
            {
                return true;
            }
            else
            {
                if (highScores.Count > 0)
                {
                    return (score < highScores[highScores.Count - 1].MistakesCount);
                }
            }

            return false;
        }

        public void Reset()
        {
            highScores.Clear();
        }
    }
}