namespace BowlingGame.Tests
{
    using System;
    using System.Linq;

    using BowlingGame.Models;

    using NUnit.Framework;

    public class BowlingGameTests
    {
        [TestFixture]
        public class Given_A_Ball_Roll_A_New_Frame_Is_Added_To_Game
        {
            private Game game;

            [SetUp]
            public void When_Ball_Is_Rolled()
            {
                this.game = new Game();
                this.game.Roll(5);
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
            private Game game;

            [SetUp]
            public void When_Two_Roll_Attempts_Have_Been_Made()
            {
                this.game = new Game();
                this.game.Roll(4);
                this.game.Roll(2);
            }

            [Test]
            public void Then_The_Score_Is_Calculated_Correctly()
            {
                var frame = this.game.Frames.Last();

                Assert.That(frame.NumberOfPinsKnocked, Is.EqualTo(6));
            }
        }

        [TestFixture]
        public class Given_Multiple_Rolls
        {
            private Game game;

            [SetUp]
            public void When_Multiple_Balls_Are_Rolled()
            {
                this.game = new Game();

                this.game.Roll(6);
                this.game.Roll(2);

                this.game.Roll(2);
                this.game.Roll(3);

                this.game.Roll(4);
                this.game.Roll(2);
            }

            [Test]
            public void Then_The_First_Frame_Score_Is_Correct()
            {
                Assert.That(this.game.Frames[0].NumberOfPinsKnocked, Is.EqualTo(8));
            }

            [Test]
            public void Then_The_Second_Frame_Score_Is_Correct()
            {
                Assert.That(this.game.Frames[1].NumberOfPinsKnocked, Is.EqualTo(5));
            }

            [Test]
            public void Then_The_Third_Frame_Score_Is_Correct()
            {
                Assert.That(this.game.Frames[2].NumberOfPinsKnocked, Is.EqualTo(6));
            }

            [Test]
            public void Then_Multiple_Frames_Are_Created()
            {
                Assert.That(this.game.Frames.Count, Is.EqualTo(3));
            }
        }

        [TestFixture]
        public class Given_A_Spare_Is_Rolled
        {
            private Frame frame;

            [SetUp]
            public void When_All_Ten_Pins_Are_Knocked_Down_With_Two_Attempts()
            {
                var subject = new Game();
                subject.Roll(8);
                subject.Roll(2);

                this.frame = subject.Frames.Last();
            }

            [Test]
            public void Then_The_Score_Is_Correct()
            {
                Assert.That(this.frame.NumberOfPinsKnocked, Is.EqualTo(10));
            }

            [Test]
            public void Then_The_Frame_Is_A_Spare()
            {
                Assert.That(this.frame.IsSpare, Is.True);
            }
        }

        [TestFixture]
        public class Given_Calculating_The_Bonus_For_A_Spare
        {
            private Game game;

            [SetUp]
            public void When_A_Spare_Is_Rolled_Along_With_A_Normal_Roll()
            {
                this.game = new Game();

                this.game.Roll(1);
                this.game.Roll(4);

                this.game.Roll(6);
                this.game.Roll(4);

                this.game.Roll(1);
                this.game.Roll(4);
            }

            [Test]
            public void Then_The_First_Frames_Points_Are_Set_Correctly()
            {
                var frame = this.game.Frames.First();
                Assert.That(frame.NumberOfPinsKnocked, Is.EqualTo(5));
            }

            [Test]
            public void Then_The_Second_Frames_Points_Are_Set_Correctly()
            {
                var frame = this.game.Frames[1];
                Assert.That(frame.NumberOfPinsKnocked, Is.EqualTo(10));
                Assert.That(frame.IsSpare, Is.True);
            }

            [Test]
            public void Then_The_Third_Frames_Points_Are_Set_Correctly()
            {
                Assert.That(this.game.Frames[2].NumberOfPinsKnocked, Is.EqualTo(5));
            }
        }

        [TestFixture]
        public class Given_A_Strike_Is_Rolled
        {
            private Frame frame;

            [SetUp]
            public void When_All_Ten_Pins_Are_Knocked_Down_With_Single_Attempt()
            {
                var subject = new Game();
                subject.Roll(10);

                this.frame = subject.Frames.Last();
            }

            [Test]
            public void Then_The_Score_Is_Correct()
            {
                Assert.That(this.frame.NumberOfPinsKnocked, Is.EqualTo(10));
            }

            [Test]
            public void Then_The_Frame_Is_A_Spare()
            {
                Assert.That(this.frame.IsStrike(), Is.True);
            }
        }

        [TestFixture]
        public class Given_Calculating_The_Bonus_For_A_Strike
        {
            private Game game;

            [SetUp]
            public void When_A_Strike_Is_Rolled_Along_With_A_Normal_Roll()
            {
                this.game = new Game();

                this.game.Roll(10);

                this.game.Roll(4);
                this.game.Roll(1);

                this.game.Roll(3);
                this.game.Roll(3);
            }

            [Test]
            public void Then_The_First_Frames_Points_Are_Set_Correctly()
            {
                var frame = this.game.Frames.First();
                Assert.That(frame.NumberOfPinsKnocked, Is.EqualTo(10));
                Assert.That(frame.IsStrike, Is.True);
            }

            [Test]
            public void Then_The_Second_Frames_Points_Are_Set_Correctly()
            {
                var frame = this.game.Frames[1];
                Assert.That(frame.NumberOfPinsKnocked, Is.EqualTo(5));
            }

            [Test]
            public void Then_The_Third_Frames_Points_Are_Set_Correctly()
            {
                Assert.That(this.game.Frames[2].NumberOfPinsKnocked, Is.EqualTo(6));
            }
        }

        [TestFixture]
        public class Given_Played_A_Full_Game
        {
            private Game game;

            [SetUp]
            public void When_Playing_A_Full_Game()
            {
                this.game = new Game();

                this.game.Roll(1);
                this.game.Roll(4);

                this.game.Roll(4);
                this.game.Roll(5);

                this.game.Roll(6);
                this.game.Roll(4);

                this.game.Roll(5);
                this.game.Roll(5);

                this.game.Roll(10);

                this.game.Roll(0);
                this.game.Roll(1);

                this.game.Roll(7);
                this.game.Roll(3);

                this.game.Roll(6);
                this.game.Roll(4);

                this.game.Roll(10);

                this.game.Roll(2);
                this.game.Roll(8);
                this.game.Roll(6);
            }

            [Test]
            public void Then_The_Total_Score_Is_Correct()
            {
                Assert.That(this.game.CalculateScore(), Is.EqualTo(133));
            }
        }
    }
}