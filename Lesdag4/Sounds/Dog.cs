using System;
using System.Collections.Generic;
using System.Text;

namespace Sounds
{
    class Dog : ISound
    {
        public void MakeNoise()
        {
            Console.WriteLine("woof");
        }
    }
}
