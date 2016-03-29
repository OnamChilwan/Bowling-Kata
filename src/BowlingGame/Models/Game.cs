namespace BowlingGame.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        public Game()
        {
            this.Frames = new List<Frame> { new Frame() };
        }

        public void Roll(int numberOfPinsKnocked)
        {
            var currentFrame = this.Frames.Last();

            if (currentFrame.IsComplete())
            {
                currentFrame = new Frame();
                this.Frames.Add(currentFrame);
            }

            currentFrame.RecordRollResult(new Roll(numberOfPinsKnocked));

            this.ApplySpareBonusPoints();
            this.ApplyStrikeBonusPoints();
        }

        public int CalculateScore()
        {
            return this.Frames.Sum(x => x.TotalPoints);
        }

        private void ApplySpareBonusPoints()
        {
            var currentFrame = this.Frames.Last();
            var previousFrame = this.GetPreviousFrame();

            if (previousFrame != null && previousFrame.IsSpare() && currentFrame.IsComplete())
            {
                previousFrame.ApplyBonusPoints(currentFrame.Attempts.First().NumberOfPinsKnocked);
            }
        }

        private void ApplyStrikeBonusPoints()
        {
            var currentFrame = this.Frames.Last();
            var previousFrame = this.GetPreviousFrame();

            if (previousFrame != null && previousFrame.IsStrike() && currentFrame.IsComplete())
            {
                previousFrame.ApplyBonusPoints(currentFrame.NumberOfPinsKnocked);
            }
        }

        private Frame GetPreviousFrame()
        {
            if (this.Frames.Count > 1)
            {
                return this.Frames[this.Frames.Count - 2];
            }

            return null;
        }

        public List<Frame> Frames { get; }
    }
}