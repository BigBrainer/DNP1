using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Exercise_8
{
    class SurroundString
    {
        public string MakeOutWord(string outerString, string innerString)
        {
            return $"{outerString[0]}{outerString[1]}{innerString}{outerString[2]}{outerString[3]}";
        }
    }
}
