using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guesser
{
    public interface IRandom
    {
        int Next(int maxValue);
    }
}
