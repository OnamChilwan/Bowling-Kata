namespace BowlingGame
{
    using System;

    using BowlingGame.Models;

    class Program
    {
        private static Game game;

        static void Main(string[] args)
        {
            game = new Game();

            for (int i = 1; i < 10; i++)
            {
                var pinsKnocked = int.Parse(Write("Enter number of pins knocked: "));
                game.Roll(pinsKnocked);
                Console.Clear();

                Display();
            }
        }

        static void Display()
        {
            foreach (var frame in game.Frames)
            {
                Console.Write("--");
                Console.Write("\t");
            }

            Console.WriteLine("\n");

            foreach (var frame in game.Frames)
            {
                //Console.Write(frame.TotalPoints.ToString("00"));
                Console.Write("\t");
            }

            Console.WriteLine("\n");

            foreach (var frame in game.Frames)
            {
                Console.Write("--");
                Console.Write("\t");
            }
        }

        static string Write(string message)
        {
            Console.WriteLine("\n");
            Console.WriteLine(message);

            return Console.ReadLine();
        }
    }
}