using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise_10
{
    class BiggestDifference
    {

        public int BigDiff(int[] numbers)
        {
            int biggest = numbers.Max();
            int smallest = numbers.Min();
            return biggest - smallest;
        }

    }
}
