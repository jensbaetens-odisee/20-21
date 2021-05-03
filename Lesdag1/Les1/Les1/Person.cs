using System;
using System.Collections.Generic;
using System.Text;

namespace Les1
{
    public class Person
    {
        public int Age { get; set; }

        public bool CanVote()
        {
            if (Age >= 18)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
