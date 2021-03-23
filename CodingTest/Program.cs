using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    class Program
    {
        //private readonly IValidateBowlingGame _iValidateBowlingGame;
        //public readonly IBowling _iBowling;

        //public Program(IBowling iBowling)
        //{
        //    this._iBowling = iBowling;
        //}

        //public void CheckRoll(int roll)
        //{
        //    this._iBowling.Roll(roll);
        //}
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter Number of Frames");
            int noOfFrames = 10;
            int i = 1;

            
            bool isStrike = false;
            Bowling bowling = new Bowling();
            StringBuilder sb = new StringBuilder();
            while (i < noOfFrames*2 +4)
            {
                Console.WriteLine("Enter Roll");
                int intRoll = Convert.ToInt16(Console.ReadLine());

                bowling.Roll(intRoll);
                Console.WriteLine("This is your "+ i + " Roll");
                if (intRoll == 10 && i % 2 != 0)
                {
                    i = i+1;
                    sb.Append("[" + intRoll + " ]");
                    isStrike = true;

                    Console.WriteLine("It's a Strike!");
                }
                else
                {

                    if (i % 2 == 0 && !isStrike)
                    {
                        sb.Append(+intRoll + "]");
                        isStrike = false;
                    }
                    else
                    {
                        sb.Append("[ " + intRoll + " |");
                        isStrike = false;
                    }


                }
                i++;
            }
            Console.WriteLine(sb);
            
            Console.WriteLine("Bowling Score is =" + Convert.ToString(bowling.Score()));
        }
    }
}
