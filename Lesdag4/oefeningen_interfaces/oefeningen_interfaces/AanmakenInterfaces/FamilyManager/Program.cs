using System;
using System.Collections.Generic;

namespace FamilyManager
{
    class Program
    {
        List<INameable> family = new List<INameable>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Program p = new Program();
            p.family.Add(new Knuffeldier("Nemo"));

            foreach(var f in p.family)
            {
                f.GetName();
            }
        }
    }
}
