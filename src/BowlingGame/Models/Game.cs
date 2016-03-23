namespace BowlingGame.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        public Game()
        {
            this.Frames = new List<Frame>();
        }

        public void Throw(int numberOfPinsKnocked)
        {
            var currentFrame = this.Frames.Last();

            if (currentFrame.HasExceededNumberOfTries())
            {
                throw new InvalidOperationException("Number of attempts / throws exceeded for frame.");
            }

            currentFrame.RecordThrowAttempt(new Throw(numberOfPinsKnocked));
        }

        public void CreateFrame()
        {
            this.Frames.Add(new Frame());
        }

        public List<Frame> Frames { get; private set; }
    }
}