using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_6
{
    class ABBAStrings
    {

        public void ABBA(string a, string b)
        {
            string result = $"{a}{b}{b}{a}";
            Console.WriteLine(result);
        }

    }
}
