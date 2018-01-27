using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        public static string ValidateInput ()
        {
            bool loop = true;
            Console.WriteLine("Enter a word or phrase you want to translate!");
            string x = Console.ReadLine();
            while (loop == true)
            {
                if (x.Length >= 1 && Regex.Match(x, @"\w").Success)
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Sorry! Try again!");
                    x = Console.ReadLine();
                }
            }
            return x;
        }

        public static void Print(string[] x)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            char[] punctuation = { '!', ',', '.', ';', ':', '?' };

            for (int i = 0; i < x.Length; i++)
            {
                if (Regex.IsMatch(x[i], @"(\!|\,|\.|\;|\:|\?)$") == true)
                {
                    x[i].LastIndexOfAny(punctuation); ////////// work in progress for removing and re-adding punctuation
                }
                if (Regex.IsMatch(x[i], @"^[a-zA-Z\']+$") == true)
                {
                    if (x[i].IndexOfAny(vowels) == 0)
                    {
                        Console.Write(x[i] + "way ");
                        continue;
                    }
                    else
                    {
                        PrintConst(x, i, vowels);
                        continue;
                    }
                }
                else if (Regex.IsMatch(x[i], @"^[a-zA-Z\u0021-\u0040]+$") == true)
                {
                    Console.Write(x[i] + " ");
                }
            }
        }
        
        public static void PrintConst(string[] x, int i, char[] y)
        {
            int vowelIndex = x[i].IndexOfAny(y);
            string toAppend = x[i].Substring(0, vowelIndex);
            Console.Write(x[i].Remove(0, vowelIndex) + toAppend + "ay ");
        }

        static void Main(string[] args)
        {
            bool loop = true;
            while (loop == true)
            {
                string[] Test = ValidateInput().Split(' ');
                Print(Test);

                Console.WriteLine();

                Console.WriteLine("Translate another word or phrase? (y/n)");
                if (string.Compare(Console.ReadLine(), "y", true) == 0)
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    loop = false;
                }
            }
        }
    }
}
