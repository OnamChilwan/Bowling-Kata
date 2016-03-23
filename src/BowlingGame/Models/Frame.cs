namespace BowlingGame.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Frame
    {
        private readonly List<Throw> throws;

        public Frame()
        {
            this.throws = new List<Throw>();
        }

        public int CalculateScore()
        {
            return this.throws.Sum(x => x.NumberOfPinsKnocked);
        }

        public bool IsSpare()
        {
            return this.CalculateScore() == 10
                   && this.GetNumberOfTries() == 2;
        }

        public bool HasExceededNumberOfTries()
        {
            return this.throws.Count >= 2;
        }

        public int GetNumberOfTries()
        {
            return this.throws.Count;
        }

        public void RecordThrowAttempt(Throw @throw)
        {
            this.throws.Add(@throw);
        }
    }
}