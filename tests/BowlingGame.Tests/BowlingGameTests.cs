namespace BowlingGame.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BowlingGame.Models;

    using NUnit.Framework;

    public class BowlingGameTests
    {
        [TestFixture]
        public class Given_Adding_A_Frame_To_New_Game
        {
            private Game game;

            [SetUp]
            public void When_Creating_A_New_Frame()
            {
                this.game = new Game();
                this.game.CreateFrame();
            }

            [Test]
            public void Then_A_Frame_Has_Been_Added()
            {
                Assert.That(this.game.Frames, Has.Count.EqualTo(1));
            }
        }

        [TestFixture]
        public class Given_A_Frame_Is_Played_Successfully
        {
            private Frame result;

            [SetUp]
            public void When_Two_Throw_Attempts_Have_Been_Made()
            {
                var game = new Game();
                game.CreateFrame();
                game.Throw(4);
                game.Throw(2);

                this.result = game.Frames.Last();
            }

            [Test]
            public void Then_The_Score_Is_Calculated_Correctly()
            {
                Assert.That(this.result.CalculateScore(), Is.EqualTo(6));
            }
        }

        [TestFixture]
        public class Given_Overplaying_A_Frame
        {
            private Game game;

            [SetUp]
            public void When_Exceeding_Number_Of_Throw_Attempts()
            {
                this.game = new Game();
                this.game.CreateFrame();
                this.game.Throw(6);
                this.game.Throw(2);
            }

            [Test]
            public void Then_An_Inavlid_Operation_Is_Thrown()
            {
                Assert.Throws<InvalidOperationException>(() => this.game.Throw(1));
            }
        }

        [TestFixture]
        public class Given_A_Spare_Is_Thrown
        {
            private Frame result;

            [SetUp]
            public void When_All_Ten_Pins_Are_Knocked_Down_With_Two_Attempts()
            {
                var subject = new Game();
                subject.CreateFrame();
                subject.Throw(8);
                subject.Throw(2);

                this.result = subject.Frames.Last();
            }

            [Test]
            public void Then_The_Score_Is_Correct()
            {
                Assert.That(this.result.CalculateScore(), Is.EqualTo(10));
            }

            [Test]
            public void Then_The_Frame_Is_A_Spare()
            {
                Assert.That(this.result.IsSpare, Is.True);
            }
        }

        [TestFixture]
        public class Given_Calculating_The_Bonus_For_A_Spare
        {
            private List<Frame> frames;

            [SetUp]
            public void When_Throwing_A_Spare_And_A_Normal_Throw()
            {
                var subject = new Game();
                subject.CreateFrame();
                subject.Throw(8);
                subject.Throw(2);

                subject.CreateFrame();
                subject.Throw(1);
                subject.Throw(3);

                this.frames = subject.Frames;
            }

            [Test]
            public void Then_The_First_Frames_Points_Are_Updated_To_Reflect_Bonus()
            {
                var previousFrame = this.frames.First();

                Assert.That(previousFrame.CalculateScore(), Is.EqualTo(13));
            }

            [Test]
            public void Then_The_Current_Frame_Points_Are_Set_Correctly()
            { }
        }
    }
}