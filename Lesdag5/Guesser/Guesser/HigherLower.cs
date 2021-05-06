using System;

namespace Guesser
{
    public class HigherLower
    {
        int number;

        public HigherLower():this(new RandomWrapper())
        {

        }
        public HigherLower(IRandom random)
        {
            number = random.Next(100);
        }

        public string MakeAGuess(int guess)
        {
            if (number == guess)
            {
                return "Correct";
            }
            else if (number < guess)
            {
                return "Lower";
            }
            else
            {
                return "Higher";
            }
        }
    }
}
