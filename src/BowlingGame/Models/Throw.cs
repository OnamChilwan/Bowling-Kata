namespace BowlingGame.Models
{
    public class Throw
    {
        public Throw(int numberOfPinsKnocked)
        {
            this.NumberOfPinsKnocked = numberOfPinsKnocked;
        }

        public int NumberOfPinsKnocked { get; private set; }
    }
}