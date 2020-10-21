using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_9
{
    class WordTwister
    {
        public string Twister(string word, int howMany)
        {
            string result = "";
            for (int i = 0; i < howMany; i++)
            {
                result += $"{word[i]}";
            }
            for (int i = 0; i < howMany; i++)
            {
                result += $"{word[word.Length - howMany + i]}";
            }
            return result;
        }

        public string SubstringTwister(string word, int howMany)
        {
            string result = "";
            for (int i = 0; i < howMany; i++)
            {
                result += $"{word[i]}";
            }
            string substring = word.Substring(word.Length - howMany);
            for (int i = 0; i < howMany; i++)
            {
                result += $"{substring[i]}";
            }
            return result;
        }
    }
}
