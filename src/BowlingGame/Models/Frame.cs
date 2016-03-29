namespace BowlingGame.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Frame
    {
        public Frame()
        {
            this.Attempts = new List<Roll>();
        }

        public bool IsComplete()
        {
            return this.Attempts.Count == 2 || this.IsStrike();
        }

        public bool IsSpare()
        {
            return this.NumberOfPinsKnocked == 10 && this.Attempts.Count == 2;
        }

        public bool IsStrike()
        {
            return this.NumberOfPinsKnocked == 10 && this.Attempts.Count == 1;
        }

        public void RecordRollResult(Roll roll)
        {
            this.Attempts.Add(roll);
        }

        public void ApplyBonusPoints(int points)
        {
            this.BonusPoints = points;
        }

        public int NumberOfPinsKnocked
        {
            get
            {
                return this.Attempts.Sum(x => x.NumberOfPinsKnocked);
            }
        }

        public int BonusPoints { get; private set; }

        public List<Roll> Attempts { get; }

        public int TotalPoints => this.NumberOfPinsKnocked + this.BonusPoints;
    }
}