using System;

namespace PersonAgeValidator
{

    public class AgeValidator
    {
        public bool IsValidAge(int age)
        {
            return age >= 18 && age <= 70;
        }
    }
}