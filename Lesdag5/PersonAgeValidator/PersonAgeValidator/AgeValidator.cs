using System;

namespace PersonAgeValidator
{
    // Add interface for creating test double
    public interface IAgeValidator
    {
        bool IsValidAge(int age);
    }

    // let Age validator implement the interface
    public class AgeValidator : IAgeValidator
    {
        public bool IsValidAge(int age)
        {
            return age >= 18 && age <= 70;
        }
    }
}