using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs27Homework
{
    public class GoatLatin
    {
        public string Translate(string input)
        {
            if (input == "")
            {
                throw new InvalidOperationException();
            }
            string firstLetter, trimmedWord, translated;
            string[] words = input.Split(' ');
            string addA = "a";

            for (int i = 0; i < words.Length; i++)
            {

                if (words[i].ToLower().StartsWith("a") ||
                    words[i].ToLower().StartsWith("e") ||
                    words[i].ToLower().StartsWith("i") ||
                    words[i].ToLower().StartsWith("o") ||
                    words[i].ToLower().StartsWith("u"))
                {
                    words[i] = string.Concat(words[i], "ma", addA);
                }
                else
                {
                    firstLetter = words[i].Substring(0, 1);
                    trimmedWord = words[i].Remove(0, 1);
                    words[i] = string.Concat(trimmedWord, firstLetter, "ma", addA);
                }
                addA = addA + "a";
            }
            translated = string.Join(" ", words);

            return translated;
        }
    }
}
