using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_11
{
    class ArrayClumps
    {
        public int CountClumps(int[] numbers)
        {
            //First number needs to be checked and saved. If the first number is the same as the next number, add 1 to count and check the next numbers until the number changes - when 
            //it does change, design the changed number as the lastNumber variable.
            int lastNumber = numbers[0];
            int count = 0;
            bool alreadyCounted = false;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (lastNumber == numbers[i + 1] && alreadyCounted == false)
                {
                    count++;
                    alreadyCounted = true;
                }
                else
                {
                    lastNumber = numbers[i + 1];
                    alreadyCounted = false;
                }
            }
            return count;
        }
    }
}
