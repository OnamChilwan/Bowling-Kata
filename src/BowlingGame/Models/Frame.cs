namespace BowlingGame.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Frame
    {
        public Frame()
        {
            this.Rolls = new List<Roll>();
        }

        public bool IsComplete()
        {
            return this.Rolls.Count == 2 || this.IsStrike();
        }

        public bool IsSpare()
        {
            return this.NumberOfPinsKnocked == 10 && this.Rolls.Count == 2;
        }

        public bool IsStrike()
        {
            return this.NumberOfPinsKnocked == 10 && this.Rolls.Count == 1;
        }

        public void RecordRollResult(Roll roll)
        {
            this.Rolls.Add(roll);
        }

        public int NumberOfPinsKnocked
        {
            get
            {
                return this.Rolls.Sum(x => x.NumberOfPinsKnocked);
            }
        }

        public List<Roll> Rolls { get; }
    }
}