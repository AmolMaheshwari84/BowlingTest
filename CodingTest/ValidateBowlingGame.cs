using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    public class ValidateBowlingGame /*: IValidateBowlingGame*/
    {
        ValidateBowlingErrorMsg ErrMsgObj = new ValidateBowlingErrorMsg();

        public ValidateBowlingErrorMsg IsPinAllowed(int pins)
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
