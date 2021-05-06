using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guesser
{
    class RandomWrapper : IRandom
    {
        Random random = new Random();
        public int Next(int maxValue)
        {
            return random.Next(maxValue);
        }
    }
}
