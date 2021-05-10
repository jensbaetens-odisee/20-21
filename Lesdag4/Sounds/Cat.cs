using System;
using System.Collections.Generic;
using System.Text;

namespace Sounds
{
    class Cat : ISound
    {
        public void MakeNoise()
        {
            Console.WriteLine("miauw");
        }
    }
}
