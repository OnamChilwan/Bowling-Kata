namespace BowlingGame.Models
{
    public class Roll
    {
        public Roll(int numberOfPinsKnocked)
        {
            this.NumberOfPinsKnocked = numberOfPinsKnocked;
        }

        public int NumberOfPinsKnocked { get; private set; }
    }
}