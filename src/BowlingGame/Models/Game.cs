namespace BowlingGame.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        public Game()
        {
            this.Frames = new List<Frame>(10) { new Frame() };
        }

        public void Roll(int numberOfPinsKnocked)
        {
            var currentFrame = this.Frames.Last();

            if (currentFrame.IsComplete() && !this.IsLastFrame())
            {
                currentFrame = new Frame();
                this.Frames.Add(currentFrame);
            }

            currentFrame.RecordRollResult(new Roll(numberOfPinsKnocked));
        }

        public int CalculateScore()
        {
            var score = 0;

            foreach (var frame in this.Frames)
            {
                score += frame.NumberOfPinsKnocked;

                if (frame.IsStrike())
                {
                    score += this.StrikeBonus(this.Frames.IndexOf(frame));
                }

                if (frame.IsSpare())
                {
                    score += this.SpareBonus(this.Frames.IndexOf(frame));
                }
            }

            return score;
        }

        private int SpareBonus(int index)
        {
            return this.Frames[index + 1].Rolls[0].NumberOfPinsKnocked;
        }

        private bool IsLastFrame()
        {
            return this.Frames.Count == 10;
        }

        private int StrikeBonus(int index)
        {
            const int PenultimateRoll = 8;
            var nextFrame = this.Frames[index + 1];
            var bonus = nextFrame.NumberOfPinsKnocked;

            if (index == PenultimateRoll)
            {
                var firstRoll = nextFrame.Rolls[0].NumberOfPinsKnocked;
                var secondRoll = nextFrame.Rolls[1].NumberOfPinsKnocked;

                bonus = firstRoll + secondRoll;
            }

            return bonus;
        }

        public List<Frame> Frames { get; }
    }
}