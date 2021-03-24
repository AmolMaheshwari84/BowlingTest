using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    public class ValidateBowlingGame
    {
        ValidateBowlingErrorMsg ErrMsgObj = new ValidateBowlingErrorMsg();
        LoggingBlock loggerBlock = new LoggingBlock();
        public ValidateBowlingErrorMsg IsPinAllowed(int pins)
        {
            try
            {
                if (pins > 10)
                {
                    ErrMsgObj.ErrorMgs = "Invalid Pin, Please try again";
                    ErrMsgObj.isAllowed = false;
                    return ErrMsgObj;
                }
                ErrMsgObj.isAllowed = true;
                return ErrMsgObj;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                loggerBlock.LogWriter.Write(ex.Message, "Error", 5, 2000, TraceEventType.Error);
                throw ex;
            }
        }

        public static bool IsStrike(int pins)
        {
            if (pins == 10)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool IsNoBonusFrame(int pin1, int pin2)
        {
            if (pin1 + pin2 < 10)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
    public class ValidateBowlingErrorMsg
    {
        public string ErrorMgs { get; set; }
        public bool isAllowed { get; set; }

    }

