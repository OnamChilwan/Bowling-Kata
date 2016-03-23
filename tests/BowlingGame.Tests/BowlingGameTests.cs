namespace BowlingGame.Tests
{
    using System;
    using System.Linq;

    using BowlingGame.Models;

    using NUnit.Framework;

    public class BowlingGameTests
    {
        [Test]
        public void When_Creating_A_New_Game()
        {
            var subject = new Game();

            Assert.That(subject.Frames, Is.Not.Null);
        }

        [Test]
        public void When_Creating_A_New_Frame()
        {
            var subject = new Game();
            subject.CreateFrame();

            Assert.That(subject.Frames, Has.Count.EqualTo(1));
        }

        [Test]
        public void When_A_Frame_Is_Played_Successfully()
        {
            var subject = new Game();
            subject.CreateFrame();
            subject.Throw(6);
            subject.Throw(2);

            var result = subject.Frames.Last();

            Assert.That(result.CalculateScore(), Is.EqualTo(8));
            Assert.That(result.IsSpare, Is.False);
        }

        [Test]
        public void When_A_Frame_Is_Played_Which_Exceeds_Number_Of_Attempts()
        {
            var subject = new Game();
            subject.CreateFrame();
            subject.Throw(6);
            subject.Throw(2);

            Assert.Throws<InvalidOperationException>(() => subject.Throw(1));
        }

        [Test]
        public void When_All_Ten_Pins_Are_Knocked_Down_With_Two_Attempts()
        {
            var subject = new Game();
            subject.CreateFrame();
            subject.Throw(8);
            subject.Throw(2);

            var result = subject.Frames.Last();

            Assert.That(result.CalculateScore(), Is.EqualTo(10));
            Assert.That(result.IsSpare, Is.True);
        }

        [Test]
        public void When_Throwing_A_Spare_Bonus_Points_Are_Applied()
        {
            var subject = new Game();
            subject.CreateFrame();
            subject.Throw(8);
            subject.Throw(2);

            subject.CreateFrame();
            subject.Throw(1);
            subject.Throw(3);

            var result = subject.Frames.First();

            Assert.That(result.CalculateScore(), Is.EqualTo(13));
        }
    }
}