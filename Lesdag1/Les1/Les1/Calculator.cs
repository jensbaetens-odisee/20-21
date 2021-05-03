using System;
using System.Collections.Generic;
using System.Text;

namespace Les1
{
    public class Calculator
    {
        public int Sum(int number1, int number2)
        {
            return number1 + number2;
        }

        public int Minus(int number1, int number2)
        {
            return number1 - number2;
        }

        public int FlooredMinus(int number1, int number2)
        {
            int result = number1 - number2;
            if(result < 0)
            {
                return 0;
            }

            return result;
        }
    }
}
