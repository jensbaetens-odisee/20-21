using System;
using System.Collections.Generic;
using System.Text;

namespace Sounds
{
    class Human : ISound
    {
        public void MakeNoise()
        {
            Console.WriteLine("speak");
        }
    }
}
