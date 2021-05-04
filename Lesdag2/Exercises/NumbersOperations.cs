using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class NumbersOperations
    {

        int[] numbers;

        public NumbersOperations(int[] numbers)
        {
            this.numbers = numbers;
        }

        public IEnumerable<int> GetAllNumbersLargerOrEqualTo50()
        {
            return numbers.Where(x => x >= 50);
        }

        public int GetLastNumberWithSquareLessThan2000()
        {
           // Math.Sqrt(numbers.Select(x => x * x).Last(x => x < 2000));
            return numbers.Last(x => x * x < 2000);
        }

    }
}
