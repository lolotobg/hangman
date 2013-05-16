using System;
using System.Linq;

namespace HangmanGame
{
    public class ScoreEntry : IComparable<ScoreEntry>
    {
        private string name;
        private int mistakesCount;

        public ScoreEntry(string name, int mistakesCount)
        {
            this.Name = name;
            this.MistakesCount = mistakesCount;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null, empty or whitespace.", "name");
                }

                this.name = value;
            }
        }

        public int MistakesCount
        {
            get
            {
                return this.mistakesCount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The mistakes cannot be less than zero.", "mistakesCount");
                }

                this.mistakesCount = value;
            }
        }

        public int CompareTo(ScoreEntry other)
        {
            // Alphabetic sort if the mistakes are equal
            if (this.MistakesCount == other.MistakesCount)
            {
                return this.Name.CompareTo(other.Name);
            }
            // Sort
            return this.MistakesCount.CompareTo(other.MistakesCount);
        }

    }
}