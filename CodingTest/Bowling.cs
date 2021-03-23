using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        ValidateBowlingGame validateBowlingGame = new ValidateBowlingGame();
        LoggingBlock loggerBlock = new LoggingBlock();

        List<int> resultsRoll = new List<int>();

        public void Roll(int pins)
        {
            try
            {
                if (validateBowlingGame.IsPinAllowed(pins).isAllowed)
                {
                    resultsRoll.Add(pins);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                loggerBlock.LogWriter.Write(ex.Message, "General", 5, 2000, TraceEventType.Information);
                throw ex;
            }
        }

        public int Score()
        {
            try
            {
                //make sure it will not return more than 10 Frames
             return resultsRoll.CalculateScores().Take(intFrameAllowed).Sum();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                loggerBlock.LogWriter.Write(ex.Message, "General", 5, 2000, TraceEventType.Information);
                throw ex;
            }
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

                // Avoiding Index not found Error, however during calculation we are only taking 10 frames.
                if (i + 2 >= framePins.Count)
                {
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
