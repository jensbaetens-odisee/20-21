using System;
using System.Collections.Generic;
using System.Linq;

namespace Les2
{
    class Program
    {
        //isFemale & isMale doen met lambda expressies in Where
        //bepaal average age studenten met Average

        public static List<int> NumbersManipulation(List<int> numbers)
        {

            return numbers.Select(x => x * 2).ToList();

            //sorteer de list van oneven getallen
            IEnumerable<int> gesorteerd = numbers.Where(x => x % 2 != 0).OrderBy(x => x);
            return gesorteerd.ToList();
        }

        static void Main(string[] args)
        {
            List<int> lijst = new List<int>() { 7, 10, 15, 20, 9, -1, -3, 100, 101, 39, 29 };

            lijst.First(x => x < 0);

            //IEnumerable<int> result = from number in lijst where number % 2 == 0 select number;     // query syntax
            //result = lijst.Where(x => x % 2 == 0); // method syntax

            List<int> bewerkteLijst = NumbersManipulation(lijst);

            foreach(var r in bewerkteLijst)
            {
                //if(number %2 == 0) { 
                    Console.WriteLine(r);
                //}
            }

            /*
            Console.WriteLine(lijst.Max());
            Console.WriteLine(lijst.Min());
            Console.WriteLine(lijst.Average());
            Console.WriteLine(lijst.Sum());
             */
            
            List<Student> studenten = new List<Student>();
            studenten.Add(new Student("Bart", "Naam1", 20, Geslacht.Mannelijk));
            studenten.Add(new Student("Lisa", "Naam2", 19, Geslacht.Vrouwelijk));
            studenten.Add(new Student("Maggy", "Naam3", 18, Geslacht.Vrouwelijk));
            studenten.Add(new Student("Homer", "Naam4", 22, Geslacht.Mannelijk));
            studenten.Add(new Student("Marge", "Naam5", 23, Geslacht.Vrouwelijk));

            //Select
            IEnumerable<string> voornamen = studenten.Where(s => s.Age>20).Select(s => s.Firstname);

            IEnumerable<Student> vrouwelijkeStudenten = studenten.Where(IsFemale);
            double avgAgeStudenten = studenten.Average(GetAge);
            
            IEnumerable<Student> studentsOlderThan20 = studenten.Where(IsOlderThan20);
            //lambda expressies
            // Func<int, int, int> sum= (inputs) => { statements }
            Func<int, int, int> sum = (a, b) =>  a + b;
            Func<int, bool> isPositive = a => a >= 0;
            studentsOlderThan20 = studenten.Where(s => s.Age > 20);

            IEnumerable<Student> mannelijkeStudenten = studenten.Where(IsMale);

            foreach (var r in studentsOlderThan20)
            {
                //if(number %2 == 0) { 
                Console.WriteLine(r.Firstname);
                //}
            }

            // Zoek alle studenten die ouder zijn dan 20

            Console.ReadLine();
        }

        static bool IsOlderThan20(Student student)
        {
            return student.Age > 20;
        }

        static int GetAge(Student student)
        {
            return student.Age;
        }

        static bool IsFemale(Student student)
        {
            return student.Sex == Geslacht.Vrouwelijk;
        }

        static bool IsMale(Student student)
        {
            return student.Sex == Geslacht.Mannelijk;
        }
    }
}
