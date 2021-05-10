using System;
using System.Collections.Generic;

namespace Sounds
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Maak een interface ISound met 1 methode MakeNoise()
            // Maak drie klassen aan die die interface implementeren:
            // Human, die print "speak"
            // Dog, die print "woof"
            // Cat, die print "miauw"
            // Maak een lijstje van die drie objecten (in de bovenstaande volgorde) en laat ze geluid maken met de methode MakeNoise()

            List<ISound> sounds = new List<ISound>();
            sounds.Add(new Human());
            sounds.Add(new Dog());
            sounds.Add(new Cat());

            foreach( var s in sounds)
            {
                s.MakeNoise();
            }
        }
    }
}
