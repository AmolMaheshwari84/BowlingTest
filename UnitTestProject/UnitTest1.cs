using System;
using CodingTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private Bowling _bowling;
        private ValidateBowlingGame _ValidateBowlingGame;
        

        [TestInitialize]
        public void Init()
        {
            _bowling = new Bowling();
            _ValidateBowlingGame = new ValidateBowlingGame();
        }

        [TestCleanup]
        public void CleanUP()
        {
            _bowling = null;
            _ValidateBowlingGame = null;
        }

        [TestMethod]
        public void TestGame()
        {
        }
        
        [TestMethod]
        public void TestValidateIsValidPin()
        {
            Assert.AreEqual(false, _ValidateBowlingGame.IsPinAllowed(11).isAllowed);
        }

        [TestMethod]
        public void TestValidPin()
        {
            Assert.AreEqual(true, _ValidateBowlingGame.IsPinAllowed(10).isAllowed);
        }

        [TestMethod]
        public void TestValidateIsStrike()
        {
         Assert.AreEqual(true, ValidateBowlingGame.IsStrike(10));
        }
        [TestMethod]
        public void TestValidateIsNotStrike()
        {
            Assert.AreEqual(false, ValidateBowlingGame.IsStrike(9));
        }

        [TestMethod]
        public void TestValidateIsNeitherStrikeNorSpare()
        {
          Assert.AreEqual(true, ValidateBowlingGame.IsNoBonusFrame(6,3));
        }

        [TestMethod]
        public void TestValidateIsSpare()
        {
            Assert.AreEqual(false, ValidateBowlingGame.IsNoBonusFrame(6, 4));
        }

        [TestMethod]
        public void TestRoll()
        {
            _bowling.Roll(0);
        }
        [TestMethod]
        public void TestMoreThan10FrameScores()
        {
            MultipleRolls(25, 1);
            //score will only calculate for First 10 frames
            Assert.AreEqual(20, _bowling.Score());
        }

        [TestMethod]
        public void TestScore()
        {
            MultipleRolls(20, 1);
            Assert.AreEqual(20, _bowling.Score());
        }

        [TestMethod]
        public void TestSpare()
        {
            RollSpare();
            _bowling.Roll(2);
            MultipleRolls(17, 0);
            Assert.AreEqual(14, _bowling.Score());
        }

        [TestMethod]
        public void TestStrike()
        {
            RollStrike();
            _bowling.Roll(3);
            _bowling.Roll(4);
            MultipleRolls(16, 0);
            Assert.AreEqual(24, _bowling.Score());
        }

        [TestMethod]
        public void AttemptAllStrikes()
        {
            //Max- Attempt All strikes
            MultipleRolls(12, 10);
            Assert.AreEqual(300, _bowling.Score());
        }
        [TestMethod]
        public void AttemptRandomStrikesAndSpares()
        {
            //Max- Attempt All strikes
            _bowling.Roll(3); 
            _bowling.Roll(4);
            _bowling.Roll(9); 
            _bowling.Roll(1);
            _bowling.Roll(3); 
            _bowling.Roll(4);
            _bowling.Roll(9); 
            _bowling.Roll(1);
            _bowling.Roll(3); 
            _bowling.Roll(4);
            _bowling.Roll(9); 
            _bowling.Roll(1);//6 Frames

            _bowling.Roll(10);
            _bowling.Roll(10);
            _bowling.Roll(10);//9 frames

            _bowling.Roll(9);
            _bowling.Roll(1);
            _bowling.Roll(3);

            Assert.AreEqual(159, _bowling.Score());
        }

        [TestMethod]
        public void AttemptAllSpares()
        {
            //Attempting All spare
            _bowling.Roll(9);
            _bowling.Roll(1); //1stFrame
            _bowling.Roll(9);
            _bowling.Roll(1);//2ndframe
            _bowling.Roll(9);
            _bowling.Roll(1);//3rdFrame
            _bowling.Roll(9);
            _bowling.Roll(1);//4thFrame
            _bowling.Roll(9);
            _bowling.Roll(1);//5thFrame
            _bowling.Roll(9);
            _bowling.Roll(1);//6thFrame
            _bowling.Roll(9);
            _bowling.Roll(1);//7thFrame
            _bowling.Roll(9);
            _bowling.Roll(1);//8thFrame
            _bowling.Roll(9);
            _bowling.Roll(1);//9th Frame
            _bowling.Roll(9);
            _bowling.Roll(1);
            _bowling.Roll(9);//10Frame
            Assert.AreEqual(190, _bowling.Score());
        }

        private void MultipleRolls(int turns, int value)
        {
            for (int i = 0; i < turns; i++)
            {
                _bowling.Roll(value);
            }
        }
        private void RollSpare()
        {
            _bowling.Roll(4);
            _bowling.Roll(6);
        }

        private void RollStrike()
        {
            _bowling.Roll(10);
        }
    }
}
