using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTest
{
    public interface IBowling
    {
        void Roll(int pins);
        int Score();
    }
    public class Bowling
    {
        /// <summary>
        /// No Of Frames allowed in the game
        /// </summary>
        private const int intFrameAllowed = 10;
        ValidateBowlingGame _iValidateBowlingGame = new ValidateBowlingGame();

        //private readonly IValidateBowlingGame _iValidateBowlingGame;

        //public Bowling (IValidateBowlingGame iValidateBowlingGame)
        //{
        //    this._iValidateBowlingGame = iValidateBowlingGame;
        //}
        
        List<int> resultsRoll = new List<int>();


        public void Roll(int pins)
        {
            if (_iValidateBowlingGame.IsPinAllowed(pins).isAllowed)
            {
               resultsRoll.Add(pins);
            }
            
        }

        public int Score()
        {
            return resultsRoll.CalculateScores().Take(10).Sum();
        }
        
    }

    public static class ListExtensions
    {
         public static IEnumerable<int> CalculateScores(this IList<int> framePins)
        {

            //Looping Frame wise
            for (int i = 0; i + 1 < framePins.Count; i += 2)
            {

                if (ValidateBowlingGame.IsNoBonusFrame(framePins[i], framePins[i + 1]))
                {
                    yield return framePins[i] + framePins[i + 1];
                    continue;
                }

                // Avoiding Index not found Error
                if (i + 2 >= framePins.Count)
                {
                    yield return framePins[i-1] + framePins[i] + framePins[i + 1];
                    break;
                }

                //both in case of Strike and spare
                yield return framePins[i] + framePins[i + 1] + framePins[i + 2];

                //Strike -1 as will be missing once chance of Pin
                if (ValidateBowlingGame.IsStrike(framePins[i]))
                    i--;
            }
        }
    }
}
