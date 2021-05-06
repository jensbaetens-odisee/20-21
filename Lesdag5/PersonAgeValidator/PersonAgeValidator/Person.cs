using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidator
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        private AgeValidator ageValidator = new AgeValidator();

        public Person(string firstName, string lastName, int age)
        {
            if (!ageValidator.IsValidAge(age))
            {
                throw new Exception("age invalid");
            }
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
