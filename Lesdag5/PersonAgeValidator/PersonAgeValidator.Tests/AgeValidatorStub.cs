using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidator.Tests._1
{
    //Dit is onze test double
    //Stub omdat het hardcoded waarden gaat bevatten
    // moet interface implementeren
    class AgeValidatorStub : IAgeValidator
    {
        bool returnValue;

        public AgeValidatorStub(bool returnValue)
        {
            this.returnValue = returnValue;
        }

        public bool IsValidAge(int age)
        {
            //Alle implementatie details van de isValidAge niet nodig/verborgen
            return returnValue;
        }
    }
}
